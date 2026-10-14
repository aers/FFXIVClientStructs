from __future__ import annotations

import itertools
from collections import deque
from dataclasses import dataclass, field
from typing import Any

from anytree import Node, RenderTree, PreOrderIter

from data_schema import DefinedData, DefinedDataClass, DefinedDataClassInstance, DefinedDataClassVtable

STANDARD_IMAGE_BASE = 0x140000000


@dataclass(eq=False)
class Vtbl:
    """A class's vtbl."""
    # Address of vtbl
    ea: int
    # Name of the base class this vtbl inherits, if it exists
    base_name: str | None = None
    # Explicit size of vtbl used to override cases where size detection fails
    size: int | None = None
    resolved_base: FfxivClass | None = None

    @classmethod
    def from_data(cls, vtbl_data: DefinedDataClassVtable, rebase_offset: int = 0) -> Vtbl:
        """A vtbl from its data.yml definition, rebased by rebase_offset."""
        return cls(ea=vtbl_data.ea + rebase_offset, base_name=vtbl_data.base, size=vtbl_data.size)


@dataclass(eq=False, repr=False)
class FfxivClass:
    """A class of data.yml."""
    # Disassembler api, see BaseApi in ffxiv_idarename.py
    api: Any
    name: str
    vtbls: list[Vtbl] = field(default_factory=list)
    # Mapping of vtbl index to func names
    vfuncs: dict[int, str] = field(default_factory=dict)
    # Mapping of effective addresses to func names
    funcs: dict[int, str] = field(default_factory=dict)
    # List of global instances of the object
    instances: list[DefinedDataClassInstance] = field(default_factory=list)
    first_base: FfxivClass | None = None

    _main_vtbl_size: int = 0
    _inheritance_tree: Node | None = None
    _finalized: bool = False

    @classmethod
    def from_data(cls, api: Any, class_name: str, class_data: DefinedDataClass) -> FfxivClass:
        """A class from its data.yml definition."""
        # Offset the vtbl and funcs if the program has been rebased
        rebase_offset = api.get_image_base() - STANDARD_IMAGE_BASE

        return cls(
            api=api,
            name=class_name,
            vtbls=[Vtbl.from_data(vtbl, rebase_offset) for vtbl in class_data.vtbls],
            vfuncs={vfunc.num: vfunc.name for vfunc in class_data.vfuncs},
            funcs={func.num + rebase_offset: func.name for func in class_data.functions},
            instances=class_data.instances,
        )

    # region vtbl_size

    @property
    def main_vtbl_size(self) -> int:
        """The vfunc count, the data.yml size or up to the first non-offset or xref."""
        if not self.vtbls:
            return self._main_vtbl_size

        if self.vtbls[0].size:
            self._main_vtbl_size = self.vtbls[0].size
            return self._main_vtbl_size

        if self._main_vtbl_size == 0:
            self._main_vtbl_size = 1  # Set to 1, skip the first entry
            for ea in itertools.count(self.vtbls[0].ea + 8, 8):
                if self.api.get_addr_name(ea) != '':
                    break

                if self.api.is_offset(ea) and self.api.xrefs_to(ea) == []:
                    self._main_vtbl_size += 1
                else:
                    break

            if self.vtbls[0].resolved_base and self._main_vtbl_size < self.vtbls[0].resolved_base._main_vtbl_size:
                print(
                    "Error: The sum of \"{0}\"'s base vtbl sizes ({1}) is greater than the actual class itself ({2})"
                        .format(self.name, self.vtbls[0].resolved_base._main_vtbl_size, self._main_vtbl_size))

        return self._main_vtbl_size

    # endregion

    @property
    def inheritance_tree(self) -> Node:
        def recurse_tree(current_node: Node, current_class: FfxivClass, all_bases: set[str]):
            for vtbl in current_class.vtbls:
                if vtbl.resolved_base and vtbl.resolved_base.name not in all_bases:
                    new_node = Node(vtbl.resolved_base.name, parent=current_node)
                    all_bases.add(vtbl.resolved_base.name)
                    recurse_tree(new_node, vtbl.resolved_base, all_bases)

        if not self._inheritance_tree:
            self._inheritance_tree = Node(self.name)
            base_set = set()
            recurse_tree(self._inheritance_tree, self, base_set)

        return self._inheritance_tree

    # region finalized

    @property
    def finalized(self) -> bool:
        """If the class and its hierarchy have been written out."""
        if self.vtbls:
            return self._finalized and all(
                vtbl.resolved_base is not None and vtbl.resolved_base._finalized for vtbl in self.vtbls)
        else:
            return self._finalized

    @finalized.setter
    def finalized(self, value: bool):
        """Set if the class has been written out."""
        self._finalized = value

    # endregion

    # region finalize

    def finalize(self):
        """Write out this class."""
        self._inherit_func_names_from_main_base()
        self._comment_vtbls_with_inheritance_tree()

        self._write_vtbl_functions()
        self._write_funcs()

        self._write_instances()

        self.finalized = True

    def _inherit_func_names_from_main_base(self):
        """A base is finalized before its child, so it has the vfunc names of its bases."""
        if self.vtbls and self.vtbls[0].resolved_base:
            for idx, base_vfunc_name in self.vtbls[0].resolved_base.vfuncs.items():
                if idx in self.vfuncs:
                    print("Warning: 0x{0:X} \"{1}\" overwrites the name of inherited function \"{2}\"".format(
                        self.vtbls[0].ea, self.name, base_vfunc_name))
                else:
                    self.vfuncs[idx] = base_vfunc_name

    def _comment_vtbls_with_inheritance_tree(self):
        """Comment the inheritance tree at the start of the vtbl."""
        for vtbl in self.vtbls:
            comment = self.api.get_comment(vtbl.ea) or ""

            for pre, _, node in RenderTree(self.inheritance_tree):
                if comment:
                    comment += "\n"
                comment += pre + self.api.format_class_name(node.name)
            self.api.set_comment(vtbl.ea, comment)

    def write_vtbl_names(self):
        """Write out the vtbl names."""
        self.api.set_addr_name(self.vtbls[0].ea, self.api.format_class_name_for_vtbl(self.name))
        for vtbl in self.vtbls[1:]:
            self.api.set_addr_name(vtbl.ea, self.api.format_class_name_for_secondary_vtbl(self.name,
                                                                                          vtbl.base_name))

    def _write_vtbl_functions(self):
        """Write out the vtbl function names."""

        def collect_vtbl_functions(ea: int, size: int, class_name: str, vfunc_names: dict[int, str],
                                   base_class_names: list[str]) -> list[tuple[int, str]]:
            vtbl_builder = []
            # Iterate through each offset
            for func_idx in range(0, size):
                vtbl_vfunc_ea = ea + func_idx * 8
                vfunc_ea = self.api.get_qword(vtbl_vfunc_ea)  # type: int

                current_func_name = self.api.get_addr_name(vfunc_ea)  # type: str
                proposed_func_name = vfunc_names.get(func_idx, "vf{0}".format(func_idx))
                formatted_class_name = self.api.format_class_name(class_name)

                formatted_func_name = self.api.format_vfunc_name(vfunc_ea, current_func_name, proposed_func_name,
                                                                 formatted_class_name,
                                                                 base_class_names)

                if formatted_func_name == "":
                    pass
                elif formatted_func_name is None:
                    print(
                        "Error: Function at 0x{0:X} had unexpected name \"{1}\" during naming of {2}.{3} (vtbl[{4}])"
                            .format(vfunc_ea, current_func_name, self.name, proposed_func_name, func_idx))
                else:
                    vtbl_builder.append((vfunc_ea, formatted_func_name))

            return vtbl_builder

        if self.vtbls:
            formatted_base_class_names = [self.api.format_class_name(node.name) for node in
                                          PreOrderIter(self.inheritance_tree)]
            formatted_base_class_names.remove(self.name)
            for idx, vtbl in enumerate(self.vtbls):
                if idx == 0:
                    funcs = collect_vtbl_functions(vtbl.ea, self.main_vtbl_size, self.name, self.vfuncs,
                                                   formatted_base_class_names)
                else:
                    funcs = collect_vtbl_functions(vtbl.ea, vtbl.resolved_base.main_vtbl_size,
                                                   self.name + "___" + vtbl.resolved_base.name,
                                                   vtbl.resolved_base.vfuncs, formatted_base_class_names)
                for (func_ea, func_name) in funcs:
                    self.api.set_addr_name(func_ea, func_name)

    def _write_funcs(self):
        """Write the names of all non-vtbl funcs."""
        for func_ea, proposed_func_name in self.funcs.items():
            current_func_name = self.api.get_addr_name(func_ea)  # type: str

            func_name = self.api.format_func_name(func_ea, current_func_name, proposed_func_name, self.name)
            if func_name == "":
                pass
            elif func_name is None:
                print("Error: Function at 0x{0:X} had unexpected name \"{1}\" during naming of {2}.{3}"
                      .format(func_ea, current_func_name, self.name, proposed_func_name))
            else:
                self.api.set_addr_name(func_ea, func_name)

    def _write_instances(self):
        """Write the names of all instances."""
        for instance in self.instances:
            name = "g_{}_{}".format(self.name, instance.name or "Instance")
            self.api.set_addr_name(instance.ea, name)

    # endregion

    def __repr__(self):
        return "<{0}(\"{1}\")>".format(self.__class__.__name__, self.name)


@dataclass
class FfxivClassFactory:
    # Disassembler api, see BaseApi in ffxiv_idarename.py
    api: Any
    _vtbl_addresses: list[int] = field(default_factory=list)
    _classes: dict[str, FfxivClass] = field(default_factory=dict)
    _finalize_stack: deque[FfxivClass] = field(default_factory=deque)

    def register(self, class_name: str, class_data: DefinedDataClass | None = None):
        """Register a class, a placeholder if class_data is omitted."""
        if class_data is None:
            class_data = DefinedDataClass()

        for vtbl in class_data.vtbls:
            if vtbl.ea != 0x0 and vtbl.ea in self._vtbl_addresses:
                print("Error: Multiple vtables are defined at 0x{0:X}".format(vtbl.ea))
                return

        if class_name in self._classes:
            print("Error: Multiple classes are registered with the name \"{0}\"".format(class_name))
            return
        for vtbl in class_data.vtbls:
            self._vtbl_addresses.append(vtbl.ea)

        self._classes[class_name] = FfxivClass.from_data(self.api, class_name, class_data)

    def finalize(self):
        """Name every class."""
        self._resolve_base_classes()

        # We write the vtbl names first for an added check so that
        # the size finder will not advance past a named offset.
        for cls in self._classes.values():
            if cls.vtbls:
                cls.write_vtbl_names()

        for cls in self._classes.values():
            self._finalize_class(cls)

    def _resolve_base_classes(self):
        """Resolve the base classes, missing ones get a stub entry and a warning."""
        for cls in list(self._classes.values()):
            for idx, vtbl in enumerate(cls.vtbls):
                if vtbl.resolved_base is None and vtbl.base_name:
                    if vtbl.base_name not in self._classes:
                        print("Warning: Inherited class \"{0}\" is not documented, add a placeholder entry".format(
                            vtbl.base_name))
                        self.register(class_name=vtbl.base_name)
                    vtbl.resolved_base = self._classes[vtbl.base_name]
                    if idx == 0:
                        cls.first_base = self._classes[vtbl.base_name]

    def _finalize_class(self, cls: FfxivClass):
        """Name a single class."""
        if cls in self._finalize_stack:
            names = [c.name for c in self._finalize_stack] + [cls.name]
            names = "\n".join(["    - {0}".format(name) for name in names])
            raise ValueError("Inheritance cycle detected: \n{0}".format(names))

        if not cls.finalized:
            self._finalize_stack.append(cls)
            for vtbl in cls.vtbls:
                if vtbl.resolved_base and not vtbl.resolved_base.finalized:
                    self._finalize_class(vtbl.resolved_base)
            cls.finalize()

            self._finalize_stack.pop()


def apply_data(api: Any, data: DefinedData):
    """Name everything in data.yml."""
    for section in (data.globals, data.functions):
        for ea, name in (section or {}).items():
            if not isinstance(ea, int):
                print('Warning: {0} has an invalid address {1}'.format(name, ea))
                continue
            api.set_addr_name(ea, name)

    if data.classes:
        factory = FfxivClassFactory(api)
        for class_name, class_data in data.classes.items():
            factory.register(class_name, class_data)

        factory.finalize()

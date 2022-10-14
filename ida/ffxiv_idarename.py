# current exe version: 2020.12.29.0000.0000
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_idarename

from __future__ import print_function
import os
import yaml
from anytree import Node, RenderTree, PreOrderIter

try:
    from typing import Any, Dict, List, Optional, Union  # noqa
except ImportError:
    pass

import sys
import itertools
from abc import abstractmethod
from collections import deque

if sys.version_info[0] >= 3:
    long = int


# region Api

class BaseApi(object):
    @property
    @abstractmethod
    def data_file_path(self):
        """
        Get the Path to the data.yml File
        :return: Path to the data.yml File
        :rtype: str
        """

    @abstractmethod
    def get_image_base(self):
        """
        Get the image base ea
        :return: Image base ea
        :rtype: int
        """

    @abstractmethod
    def is_offset(self, ea):
        """
        Is the given address an offset to something else
        :param ea: Effective address
        :type ea: int
        :return: Is offset or not
        :rtype: bool
        """

    @abstractmethod
    def xrefs_to(self, ea):
        """
        Retrieve all xrefs to the given address
        :param ea: Effective address
        :type ea: int
        :return: List of addresses
        :rtype: List[int]
        """

    @abstractmethod
    def get_qword(self, ea):
        """
        Read a qword of data from an address
        :param ea: Effective address
        :type ea: int
        :return: 64bits of data
        :rtype: int
        """

    @abstractmethod
    def get_addr_name(self, ea):
        """
        Get the name of a given address
        :param ea: Effective address
        :type ea: int
        :return: Name or empty
        :rtype: str
        """

    @abstractmethod
    def set_addr_name(self, ea, name):
        """
        Set the name of a given address (function)
        :param ea: Effective address
        :type ea: int
        :param name: Name to set
        :type name: str
        :return: Success/failure
        :rtype: bool
        """

    @abstractmethod
    def get_comment(self, ea):
        """
        Get the comment at an address
        :param ea: Effective address
        :type ea: int
        :return: Comment
        :rtype: str
        """

    @abstractmethod
    def set_comment(self, ea, comment):
        """
        Add a comment to an address
        :param ea: Effective address
        :type ea: int
        :param comment: Comment
        :type comment: str
        :return: None
        """

    def format_class_name_for_vtbl(self, class_name):
        """
        Format a class name for special representation in the vtbl
        By default, looks similar to vtbl_Component::Gui::AtkResNode
        :param class_name: Name as contained in data.yml
        :type class_name: str
        :return: Formatted class name
        :rtype: str
        """
        return "vtbl_{0}".format(class_name)

    def format_class_name_for_secondary_vtbl(self, class_name, secondary_name):
        """
        Format a class name for special representation in the vtbl
        By default, looks similar to vtbl_classname_secondaryname
        :param class_name: Name as contained in data.yml
        :type class_name: str
        :param secondary_name: Name as contained in data.yml
        :type secondary_name: str
        :return: Formatted class name
        :rtype: str
        """
        return "vtbl_{0}___{1}".format(class_name, secondary_name)

    def format_class_name(self, class_name):
        """
        Format a class name for representation in the toolset
        By default, looks similar to Component::Gui::AtkResNode
        :param class_name: Name as contained in data.yml
        :type class_name: str
        :return: Formatted class name
        :rtype: str
        """
        return class_name

    @abstractmethod
    def format_vfunc_name(self, ea, current_func_name, proposed_func_name, class_name, base_class_names):
        """
        Name a function (vfunc) based on how it is currently named, what it is proposed to be named,
        and the names of the current and base classes. If None is returned, it is assumed
        that the current func was named something unexpectedly and will be warned about. Return
        an empty string "" if no renaming should take place.
        :param ea: Func effective address
        :type ea: int
        :param current_func_name: Current func name as in the disassembler
        :type current_func_name: str
        :param proposed_func_name: Either a name from data.yml or vfX where X is the vfunc index
        :type proposed_func_name: str
        :param class_name: Class name
        :type class_name: str
        :param base_class_names: base class names
        :type base_class_names: List[str]
        :return: Formatted vfunc name
        :rtype: Optional[str]
        """

    @abstractmethod
    def format_func_name(self, ea, current_func_name, proposed_func_name, class_name):
        """
        Name a function based on how it is currently named, what it is proposed to be named,
        and the name of the current  class. If None is returned, it is assumed that the current
        func was named something unexpectedly and will be warned about. Return an empty string ""
        if no renaming should take place.
        :param ea: Func effective address
        :type ea: int
        :param current_func_name: Current func name as in the disassembler
        :type current_func_name: str
        :param proposed_func_name: A name from data.yml
        :type proposed_func_name: str
        :param class_name: Class name
        :type class_name: str
        :return: Formatted func name
        :rtype: Optional[str]
        """


api = None

# region IDA Api

if api is None:
    try:
        import idaapi  # noqa
        import idc  # noqa
        import idautils  # noqa
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi):

            @property
            def data_file_path(self):
                return os.path.join(os.path.dirname(os.path.realpath(__file__)), "data.yml")

            def get_image_base(self):
                return idaapi.get_imagebase()

            def is_offset(self, ea):
                return idc.is_off0(idc.get_full_flags(ea))

            def xrefs_to(self, ea):
                return [xref.to for xref in idautils.XrefsTo(ea)]

            def get_qword(self, ea):
                return idc.get_qword(ea)

            def get_addr_name(self, ea):
                return idc.get_name(ea)

            def set_addr_name(self, ea, name):
                # print("{0} {1}".format(ea, name))
                result = idc.set_name(ea, name)
                return bool(result)

            def get_comment(self, ea):
                idc.get_cmt(ea, False)

            def set_comment(self, ea, comment):
                idc.set_cmt(ea, comment, False)

            def format_vfunc_name(self, ea, current_func_name, proposed_func_name, class_name, base_class_names):
                if current_func_name.startswith("j_"):  # jump
                    current_func_name = current_func_name.lstrip("j_")

                if current_func_name.startswith("qword_"):
                    idc.auto_mark_range(ea, ea + 1, idc.AU_CODE)
                    idc.create_insn(ea)
                    idc.add_func(ea)
                    current_func_name = api.get_addr_name(ea)
                    print("Info: qword in vtbl of {1} at 0x{0:X}, it may be an offset to undefined code".format(ea,
                                                                                                                class_name))

                # Previously renamed as a vfunc
                if current_func_name.startswith(class_name):
                    # return the proposed func name in case it was updated since last run
                    current_class_name = current_func_name.rsplit(".", 1)[0]
                    return "{0}.{1}".format(current_class_name, proposed_func_name)

                # This should have been handled in the base class
                if any(current_func_name.startswith(name) for name in base_class_names):
                    return ""

                if current_func_name.startswith("sub_"):
                    return "{0}.{1}".format(class_name, proposed_func_name)

                if current_func_name.startswith("nullsub_"):
                    return "{0}.{1}_nullsub".format(class_name, proposed_func_name)

                if current_func_name.startswith("loc_"):
                    return "{0}.{1}_loc".format(class_name, proposed_func_name)

                if current_func_name.startswith("locret_"):
                    return "{0}.{1}_locret".format(class_name, proposed_func_name)

                # Name it later in a child class when it gets overridden
                if current_func_name == "_purecall":
                    return ""

                # Mangled func names, thanks IDA
                if current_func_name.startswith("?") or current_func_name.startswith("_"):
                    return "{0}.{1}".format(class_name, proposed_func_name)

                return None

            def format_func_name(self, ea, current_func_name, proposed_func_name, class_name):
                if current_func_name.startswith("j_"):  # jump
                    current_func_name = current_func_name.lstrip("j_")

                # Mangled func names, thanks IDA
                if proposed_func_name.startswith("?") or proposed_func_name.startswith("_"):
                    return proposed_func_name

                proposed_qualified_func_name = "{0}.{1}".format(class_name, proposed_func_name)
                if current_func_name == proposed_qualified_func_name:
                    return ""

                if any(current_func_name.startswith(prefix) for prefix in ("sub_", "nullsub_", "loc_", "qword_")):
                    return proposed_qualified_func_name

                return None


        api = IdaApi()

# endregion
# region Ghidra Api

if api is None:
    try:
        import ghidra

        from ghidra.program.model.data import CategoryPath  # noqa
        from ghidra.program.model.data import StructureDataType  # noqa
        from ghidra.program.model.data import PointerDataType  # noqa
        from ghidra.program.model.symbol import SourceType  # noqa
    except ImportError:
        print("Warning: Unable to load Ghidra")
    else:
        # noinspection PyUnresolvedReferences
        class GhidraApi(BaseApi):
            @property
            def data_file_path(self):
                return os.path.join(os.path.dirname(str(sourceFile)), "data.yml")

            def get_image_base(self):
                return currentProgram.getImageBase().getOffset()

            def is_offset(self, ea):
                data = getDataAt(toAddr(ea))
                if not data: return False
                return data.isPointer()

            def xrefs_to(self, ea):
                return [xref.getFromAddress().getOffset() for xref in getReferencesTo(toAddr(ea))]

            def get_qword(self, ea):
                return getLong(toAddr(ea))

            def get_addr_name(self, ea):
                sym = getSymbolAt(toAddr(ea))
                if not sym:
                    return ""
                return sym.getName(True)

            def set_addr_name(self, ea, name):
                createLabel(toAddr(ea), name, True, SourceType.ANALYSIS)
                return True
                # return createLabel(toAddr(ea), name, True).checkIsValid()

            def get_comment(self, ea):
                return getEOLComment(toAddr(ea))

            def set_comment(self, ea, comment):
                if getEOLComment(toAddr(ea)) is None:
                    setEOLComment(toAddr(ea), comment)

            def format_vfunc_name(self, ea, current_func_name, proposed_func_name, class_name, base_class_names):
                if current_func_name.startswith("thunk_"):  # jump
                    current_func_name = current_func_name.lstrip("thunk_")

                # Previously renamed as a vfunc
                if current_func_name.startswith(class_name):
                    # return the proposed func name in case it was updated since last run
                    current_class_name = current_func_name.rsplit(".", 1)[0]
                    return "{0}.{1}".format(current_class_name, proposed_func_name)

                # This should have been handled in the base class
                if any(current_func_name.startswith(name) for name in base_class_names):
                    return ""

                if any(current_func_name.startswith(prefix) for prefix in ("FUN_", "LAB_", "SUB_", "LOC_", "DAT_")):
                    return "{0}.{1}".format(class_name, proposed_func_name)

                if current_func_name == "_purecall":
                    return ""

                return None

            def format_func_name(self, ea, current_func_name, proposed_func_name, class_name):
                if current_func_name.startswith("thunk_"):  # jump
                    current_func_name = current_func_name.lstrip("thunk_")

                proposed_qualified_func_name = "{0}.{1}".format(class_name, proposed_func_name)
                if current_func_name == proposed_qualified_func_name:
                    return ""

                if any(current_func_name.startswith(prefix) for prefix in ("FUN_", "LAB_", "SUB_", "LOC_", "DAT_")):
                    return proposed_qualified_func_name

                return None


        api = GhidraApi()

# endregion

if api is None:
    raise Exception("Unable to load IDA or Ghidra")


# endregion

def load_data():
    with open(api.data_file_path, "r") as fd:
        data = yaml.safe_load(fd)

    if data.get("globals"):
        for ea, name in data["globals"].items():
            if not isinstance(ea, (int, long)):
                print('Warning: {0} has an invalid address {1}'.format(name, ea))
                continue
            api.set_addr_name(ea, name)

    if data.get("functions"):
        for ea, name in data["functions"].items():
            if not isinstance(ea, (int, long)):
                print('Warning: {0} has an invalid address {1}'.format(name, ea))
                continue
            api.set_addr_name(ea, name)


    if data.get("classes"):
        factory = FfxivClassFactory()
        for class_name, class_data in data["classes"].items():
            if not class_data:
                class_data = {}

            vtbls_raw = class_data.pop("vtbls", [])
            vtbls = [(vtbl["ea"], vtbl["base"] if "base" in vtbl else None) for vtbl in vtbls_raw]
            vfuncs = class_data.pop("vfuncs", {})
            funcs = class_data.pop("funcs", {})
            instances_raw = class_data.pop("instances", [])
            instances = [(instance["ea"], instance["name"] if "name" in instance else "Instance") for instance in instances_raw]
            for leftover in class_data:
                print("Warning: Extra key \"{0}\" present in {1}".format(leftover, class_name))

            factory.register(
                class_name=class_name, vtbls=vtbls, vfuncs=vfuncs, funcs=funcs, instances=instances)

        factory.finalize()


class FfxivClassFactory:
    _vtbl_addresses = []  # type: List[int]
    _classes = {}  # type: Dict[str, FfxivClass]

    def register(self, class_name, vtbls=None, vfuncs=None, funcs=None, instances=None):
        """
        Register a class
        :param class_name: Class name
        :type class_name: str
        :param vtbls: List of (vtbl_ea, base_name) pairs
        :type vtbls: list[(int, str)]
        :param funcs: Mapping of effective addresses to func names
        :type funcs: Dict[int, str]
        :param vfuncs: Mapping of vtbl index to func names
        :type funcs: Dict[int, str]
        :param instances: List of global instances of the object
        :type instances: List[(int, str)]
        :return: None
        :rtype: None
        """
        if vtbls is None:
            vtbls = []

        if not vfuncs:
            vfuncs = {}

        if not funcs:
            funcs = {}

        for (vtbl_ea, _) in vtbls:
            if vtbl_ea != 0x0 and vtbl_ea in self._vtbl_addresses:
                print("Error: Multiple vtables are defined at 0x{0:X}".format(vtbl_ea))
                return

        if class_name in self._classes:
            print("Error: Multiple classes are registered with the name \"{0}\"".format(class_name))
            return
        for (vtbl_ea, _) in vtbls:
            self._vtbl_addresses.append(vtbl_ea)

        if not instances:
            instances = []

        self._classes[class_name] = FfxivClass(
            class_name=class_name, vtbls=vtbls, vfuncs=vfuncs, funcs=funcs, instances=instances)

    def finalize(self):
        """
        Perform the class naming
        :return: None
        :rtype: None
        """
        self._resolve_base_classes()

        # We write the vtbl names first for an added check so that
        # the size finder will not advance past a named offset.
        for cls in self._classes.values():
            if cls.vtbls:
                cls.write_vtbl_names()

        for cls in self._classes.values():
            self._finalize_class(cls)

    def _resolve_base_classes(self):
        """
        Resolve base classes for a class
        If missing, warn the user and add a stub entry.
        :return: None
        """
        for class_name, cls in list(self._classes.items()):
            if cls.vtbls:
                for idx, vtbl in enumerate(cls.vtbls):
                    if vtbl.resolved_base is None and vtbl.base_name:
                        if vtbl.base_name not in self._classes:
                            print("Warning: Inherited class \"{0}\" is not documented, add a placeholder entry".format(
                                vtbl.base_name))
                            self.register(class_name=vtbl.base_name)
                        vtbl.resolved_base = self._classes[vtbl.base_name]
                        if idx == 0:
                            cls.first_base = self._classes[vtbl.base_name]

    _finalize_stack = deque()

    def _finalize_class(self, cls):
        """
        Perform a single class naming
        :param cls: Class object
        :type cls: FfxivClass
        :return: None
        :rtype: None
        """
        if cls in self._finalize_stack:
            names = [c.name for c in self._finalize_stack] + [cls.name]
            names = "\n".join(["    - {0}".format(name) for name in names])
            raise ValueError("Inheritance cycle detected: \n{0}".format(names))

        if not cls.finalized:
            self._finalize_stack.append(cls)
            if cls.vtbls:
                for vtbl in cls.vtbls:
                    if vtbl.resolved_base and not vtbl.resolved_base.finalized:
                        self._finalize_class(vtbl.resolved_base)
            cls.finalize()

            self._finalize_stack.pop()


class Vtbl:
    resolved_base = None  # type: FfxivClass

    def __init__(self, ea, base_name=None):
        """
        Object representing a class's vtbl
        :param ea: Address of vtbl
        :type ea: int
        :param base_name: Name of the base class this vtbl inherits, if it exists
        :type base_name: str
        """
        self.ea = ea
        self.base_name = base_name


class FfxivClass:
    STANDARD_IMAGE_BASE = 0x140000000

    vtbls = None  # type: list[Vtbl]

    def __init__(self, class_name, vtbls, vfuncs, funcs, instances):
        """
        Object representing a class
        :param class_name: Class name
        :type class_name: str
        :param vtbls: List of (vtbl_ea, base_name) pairs
        :type vtbls: list[(int, str)]
        :param vfuncs: Mapping of vtbl index to func names
        :type vfuncs: Dict[int, str]
        :param funcs: Mapping of effective addresses to func names
        :type funcs: Dict[int, str]
        :param instances: List of global instances of the object
        :type instances: List[(int, str)]
        """
        self.name = class_name
        if vtbls:
            self.vtbls = [Vtbl(ea, base_name) for (ea, base_name) in vtbls]
        self.vfuncs = vfuncs
        self.funcs = funcs
        self.instances = instances

        # Offset the vtbl and funcs if the program has been rebased
        current_image_base = api.get_image_base()
        if self.STANDARD_IMAGE_BASE != current_image_base:
            rebase_offset = current_image_base - self.STANDARD_IMAGE_BASE
            if self.vtbls:
                for vtbl in self.vtbls:
                    vtbl.ea += rebase_offset
            for ea in list(funcs.keys()):
                funcs[ea + rebase_offset] = funcs.pop(ea)

    # region vtbl_size

    _main_vtbl_size = 0

    @property
    def main_vtbl_size(self):
        """
        Iterate from the vtbl start until a non-offset or xref is encountered.
        This strategy implies that the only xref in a vtbl is the first vfunc.
        :return: VTable func count
        :rtype: int
        """
        if not self.vtbls:
            return self._main_vtbl_size

        if self._main_vtbl_size == 0:
            self._main_vtbl_size = 1  # Set to 1, skip the first entry
            for ea in itertools.count(self.vtbls[0].ea + 8, 8):
                if api.get_addr_name(ea) != '':
                    break

                if api.is_offset(ea) and api.xrefs_to(ea) == []:
                    self._main_vtbl_size += 1
                else:
                    break

            if self.vtbls[0].resolved_base and self._main_vtbl_size < self.vtbls[0].resolved_base._main_vtbl_size:
                print(
                    "Error: The sum of \"{0}\"'s base vtbl sizes ({1}) is greater than the actual class itself ({2})"
                        .format(self.name, self.vtbls[0].resolved_base._main_vtbl_size, self._main_vtbl_size))

        return self._main_vtbl_size

    # endregion

    _inheritance_tree = None

    @property
    def inheritance_tree(self):
        def recurse_tree(current_node, current_class, all_bases):
            if current_class.vtbls:
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

    _finalized = False

    @property
    def finalized(self):
        """
        Has this class and its hierarchy been written out or not
        :return: bool yes/no
        :rtype: bool
        """
        if self.vtbls:
            return self._finalized and all(
                vtbl.resolved_base is not None and vtbl.resolved_base._finalized for vtbl in self.vtbls)
        else:
            return self._finalized

    @finalized.setter
    def finalized(self, value):
        """
        Set if finalized or not
        :param value: Finalized state
        :type value: bool
        :return: None
        :rtype: None
        """
        self._finalized = value

    # endregion

    # region finalize

    def finalize(self):
        """
        Write out this class
        :return: None
        :rtype: None
        """
        self._inherit_func_names_from_main_base()
        self._comment_vtbls_with_inheritance_tree()

        self._write_vtbl_functions()
        self._write_funcs()

        self._write_instances()

        self.finalized = True

    def _inherit_func_names_from_main_base(self):
        """
        A base is guaranteed to be finalized before the child,
        so a base has all the vfunc names of its base already.
        :return: None
        :rtype: None
        """
        if self.vtbls and self.vtbls[0].resolved_base:
            for idx, base_vfunc_name in self.vtbls[0].resolved_base.vfuncs.items():
                if idx in self.vfuncs:
                    print("Warning: 0x{0:X} \"{1}\" overwrites the name of inherited function \"{2}\"".format(
                        self.vtbls[0].ea, self.name, base_vfunc_name))
                    pass
                else:
                    self.vfuncs[idx] = base_vfunc_name

    def _comment_vtbls_with_inheritance_tree(self):
        """
        Adds the inheritance tree as a comment to the start of the vtbl.
        grandbase_name
            base_name
                self_name
        :return: None
        :rtype: None
        """
        if self.vtbls:
            for idx, vtbl in enumerate(self.vtbls):
                comment = api.get_comment(vtbl.ea) or ""

                for pre, fill, node in RenderTree(self.inheritance_tree):
                    if comment:
                        comment += "\n"
                    comment += pre + api.format_class_name(node.name)
                api.set_comment(vtbl.ea, comment)

    def write_vtbl_names(self):
        """
        Write out the vtbl name.
        :return: None
        """
        api.set_addr_name(self.vtbls[0].ea, api.format_class_name_for_vtbl(self.name))
        for vtbl in self.vtbls[1:]:
            api.set_addr_name(vtbl.ea, api.format_class_name_for_secondary_vtbl(self.name,
                                                                                vtbl.base_name))

    def _write_vtbl_functions(self):
        """
        Write out the vtbl function names
        :return: None
        :rtype: None
        """

        def collect_vtbl_functions(ea, size, class_name, vfunc_names, base_class_names):
            """
            :type ea: int
            :type size: int
            :type class_name: str
            :type vfunc_names: dict[int, str]
            :type base_class_names: list[str]
            """
            vtbl_builder = []
            # Iterate through each offset
            for func_idx in range(0, size):
                vtbl_vfunc_ea = ea + func_idx * 8
                vfunc_ea = api.get_qword(vtbl_vfunc_ea)  # type: int

                current_func_name = api.get_addr_name(vfunc_ea)  # type: str
                proposed_func_name = vfunc_names.get(func_idx, "vf{0}".format(func_idx))
                formatted_class_name = api.format_class_name(class_name)

                formatted_func_name = api.format_vfunc_name(vfunc_ea, current_func_name, proposed_func_name,
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
            formatted_base_class_names = [api.format_class_name(node.name) for node in
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
                    api.set_addr_name(func_ea, func_name)

    def _write_funcs(self):
        """
        Write the names of all non-vtbl funcs
        :return: None
        """
        for func_ea, proposed_func_name in self.funcs.items():
            current_func_name = api.get_addr_name(func_ea)  # type: str

            func_name = api.format_func_name(func_ea, current_func_name, proposed_func_name, self.name)
            if func_name == "":
                pass
            elif func_name is None:
                print("Error: Function at 0x{0:X} had unexpected name \"{1}\" during naming of {2}.{3}"
                      .format(func_ea, current_func_name, self.name, proposed_func_name))
            else:
                api.set_addr_name(func_ea, func_name)

    def _write_instances(self):
        """
        Write the names of all instances
        :return: None
        """
        for (instance_ea, instance_name) in self.instances:
            name = "g_{}_{}".format(self.name, instance_name)
            api.set_addr_name(instance_ea, name)

    # endregion

    def __repr__(self):
        return "<{0}(\"{1}\")>".format(self.__class__.__name__, self.name)


# endregion

print("Executing")
load_data()
print("Done")

# current exe version: 2020.12.29.0000.0000
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_idarename

from __future__ import print_function
import os
import yaml

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
    def format_vfunc_name(self, ea, current_func_name, proposed_func_name, class_name, parent_class_names):
        """
        Name a function (vfunc) based on how it is currently named, what it is proposed to be named,
        and the names of the current and parent classes. If None is returned, it is assumed
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
        :param parent_class_names: Parent class names
        :type parent_class_names: List[str]
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

    @abstractmethod
    def write_vtbl_struct(self, struct_name, struct_member_names):
        """
        Write a vtbl struct for use in decompiled source code, should not be applied to the vtbl itself.
        :param struct_name: Struct name, this will be the output of format_class_name_for_vtbl
        :type struct_name: str
        :param struct_member_names: List of struct names, no missing indexes
        :type struct_member_names: List[str]
        :return: None
        :rtype: None
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
                result = idc.set_name(ea, name)
                return bool(result)

            def get_comment(self, ea):
                idc.get_cmt(ea, False)

            def set_comment(self, ea, comment):
                idc.set_cmt(ea, comment, False)

            def format_vfunc_name(self, ea, current_func_name, proposed_func_name, class_name, parent_class_names):
                if current_func_name.startswith("j_"):  # jump
                    current_func_name = current_func_name.lstrip("j_")

                if current_func_name.startswith("qword_"):
                    idc.auto_mark_range(ea, ea + 1, idc.AU_CODE)
                    idc.create_insn(ea)
                    idc.add_func(ea)
                    current_func_name = api.get_addr_name(ea)
                    print("Info: qword in vtbl of {1} at 0x{0:X}, it may be an offset to undefined code".format(ea, class_name))

                # Previously renamed as a vfunc
                if current_func_name.startswith(class_name):
                    # return the proposed func name in case it was updated since last run
                    current_class_name = current_func_name.rsplit(".", 1)[0]
                    return "{0}.{1}".format(current_class_name, proposed_func_name)

                # This should have been handled in the parent class
                if any(current_func_name.startswith(name) for name in parent_class_names):
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

                proposed_qualified_func_name = "{0}.{1}".format(class_name, proposed_func_name)
                if current_func_name == proposed_qualified_func_name:
                    return ""

                if any(current_func_name.startswith(prefix) for prefix in ("sub_", "nullsub_", "loc_", "qword_")):
                    return proposed_qualified_func_name

                return None

            def write_vtbl_struct(self, vtbl_name, struct_member_names):
                struct_name = "{0}_struct".format(vtbl_name)
                sid = idc.get_struc_id(struct_name)
                if sid == idc.BADADDR:
                    # Doesn't exist
                    sid = idc.add_struc(-1, struct_name, is_union=0)
                else:
                    # Clear existing
                    member_offset = idc.get_first_member(sid)
                    while member_offset != idc.BADADDR:
                        idc.del_struc_member(sid, member_offset)
                        member_offset = idc.get_first_member(sid)

                for member_name in struct_member_names:
                    idc.add_struc_member(sid, member_name, offset=-1, flag=idc.FF_DATA | idc.FF_QWORD, typeid=-1, nbytes=8, reftype=idc.REF_OFF64)
                    member_offset = idc.get_last_member(sid)
                    member_id = idc.get_member_id(sid, member_offset)
                    idc.SetType(member_id, "void*")


        api = IdaApi()

# endregion
# region Ghidra Api

if api is None:
    try:
        import ghidra

        from ghidra.program.model.data import CategoryPath  # noqa
        from ghidra.program.model.data import StructureDataType  # noqa
        from ghidra.program.model.data import PointerDataType  # noqa
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
                return createLabel(toAddr(ea), name, True).checkIsValid()

            def get_comment(self, ea):
                return getEOLComment(toAddr(ea))

            def set_comment(self, ea, comment):
                if getEOLComment(toAddr(ea)) is None:
                    setEOLComment(toAddr(ea), comment)

            def format_vfunc_name(self, ea, current_func_name, proposed_func_name, class_name, parent_class_names):
                if current_func_name.startswith("thunk_"):  # jump
                    current_func_name = current_func_name.lstrip("thunk_")

                # Previously renamed as a vfunc
                if current_func_name.startswith(class_name):
                    # return the proposed func name in case it was updated since last run
                    current_class_name = current_func_name.rsplit(".", 1)[0]
                    return "{0}.{1}".format(current_class_name, proposed_func_name)

                # This should have been handled in the parent class
                if any(current_func_name.startswith(name) for name in parent_class_names):
                    return ""

                if any(current_func_name.startswith(prefix) for prefix in ("FUN_", "LAB_", "SUB_", "LOC_")):
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

                if any(current_func_name.startswith(prefix) for prefix in ("FUN_", "LAB_", "SUB_", "LOC_")):
                    return proposed_qualified_func_name

                return None

            def write_vtbl_struct(self, vtbl_name, struct_member_names):
                pass

            # def get_struct_id(self, name):
            #     gdt = currentProgram.getDataTypeManager()
            #     struct = gdt.getDataType(CategoryPath("/___vftables"), name.replace("_struct", ""))
            #     if struct: return gdt.getID(struct)
            #     return -1

            # def create_struct(self, name):
            #     structName = name.replace("_struct", "")
            #     structPath = CategoryPath("/___vftables")
            #     gdt = currentProgram.getDataTypeManager()
            #     struct = gdt.getDataType(structPath, structName)
            #     if not struct:
            #         struct = StructureDataType(structPath, structName, 0, gdt)
            #     struct.deleteAll()
            #     dt = gdt.addDataType(struct, None)
            #     return gdt.getID(dt)

            # def add_struct_member(self, sid, name):
            #     gdt = currentProgram.getDataTypeManager()
            #     struct = gdt.getDataType(sid)
            #     if not struct:
            #         return False
            #     member = struct.add(PointerDataType(), 8, name, None)
            #     return True

            # def clear_struct(self, sid):
            #     gdt = currentProgram.getDataTypeManager()
            #     struct = gdt.getDataType(sid)
            #     if not struct:
            #         return False
            #     struct.deleteAll()
            #     return True


        api = GhidraApi()

# endregion

if api is None:
    raise Exception("Unable to load IDA or Ghidra")


# endregion

def load_data():
    with open(api.data_file_path, "r") as fd:
        data = yaml.safe_load(fd)

    for ea, name in data["globals"].items():
        if not isinstance(ea, (int, long)):
            print('Warning: {0} has an invalid address {1}'.format(name, ea))
            continue
        api.set_addr_name(ea, name)

    for ea, name in data["functions"].items():
        if not isinstance(ea, (int, long)):
            print('Warning: {0} has an invalid address {1}'.format(name, ea))
            continue
        api.set_addr_name(ea, name)

    factory = FfxivClassFactory()

    for class_name, class_data in data["classes"].items():
        if not class_data:
            class_data = {}

        vtbl_ea = class_data.pop("vtbl", 0x0)
        parent_class_name = class_data.pop("inherits_from", "")
        vfuncs = class_data.pop("vfuncs", {})
        funcs = class_data.pop("funcs", {})
        for leftover in class_data:
            print("Warning: Extra key \"{0}\" present in {1}".format(leftover, class_name))

        factory.register(
            class_name=class_name, parent_class_name=parent_class_name,
            vtbl_ea=vtbl_ea, vfuncs=vfuncs, funcs=funcs)

    factory.finalize()


class FfxivClassFactory:
    _vtbl_addresses = []  # type: List[int]
    _classes = {}  # type: Dict[str, FfxivClass]

    def register(self, class_name, parent_class_name="", vtbl_ea=0x0, vfuncs=None, funcs=None):
        """
        Register a class
        :param class_name: Class name
        :type class_name: str
        :param parent_class_name: Parent class
        :type parent_class_name: str
        :param vtbl_ea: Vtable effective address
        :type vtbl_ea: int
        :param funcs: Mapping of effective addresses to func names
        :type funcs: Dict[int, str]
        :param vfuncs: Mapping of vtbl index to func names
        :type funcs: Dict[int, str]
        :return: None
        :rtype: None
        """
        if not vfuncs:
            vfuncs = {}

        if not funcs:
            funcs = {}

        if vtbl_ea != 0x0 and vtbl_ea in self._vtbl_addresses:
            print("Error: Multiple vtables are defined at 0x{0:X}".format(vtbl_ea))
            return

        if class_name in self._classes:
            print("Error: Multiple classes are registered with the name \"{0}\"".format(class_name))
            return

        self._vtbl_addresses.append(vtbl_ea)
        self._classes[class_name] = FfxivClass(
            class_name=class_name, parent_name=parent_class_name,
            vtbl_ea=vtbl_ea, vfuncs=vfuncs, funcs=funcs)

    def finalize(self):
        """
        Perform the class naming
        :return: None
        :rtype: None
        """
        self._resolve_parent_classes()
        for cls in self._classes.values():
            self._finalize_class(cls)

    def _resolve_parent_classes(self):
        """
        Set FfxivClass.parent_class to _classes[FfxivClass.parent_class_name]
        If missing, warn the user and add a stub entry.
        :return: None
        """
        for class_name, cls in list(self._classes.items()):
            if cls.parent_class is None and cls.parent_name:
                if cls.parent_name not in self._classes:
                    print("Warning: Inherited class \"{0}\" is not documented, add a placeholder entry".format(cls.parent_name))
                    self.register(class_name=cls.parent_name)
                cls.parent_class = self._classes[cls.parent_name]

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

            if cls.parent_class and not cls.parent_class.finalized:
                self._finalize_class(cls.parent_class)
            cls.finalize()

            self._finalize_stack.pop()


class FfxivClass:
    STANDARD_IMAGE_BASE = 0x140000000

    # This is set when the factory is finalized
    parent_class = None  # type: FfxivClass

    def __init__(self, class_name, parent_name, vtbl_ea, vfuncs, funcs):
        """
        Object representing a class
        :param class_name: Class name
        :type class_name: str
        :param parent_name: Parent class
        :type parent_name: str
        :param vtbl_ea: Vtable effective address
        :type vtbl_ea: int
        :param vfuncs: Mapping of vtbl index to func names
        :type funcs: Dict[int, str]
        :param funcs: Mapping of effective addresses to func names
        :type funcs: Dict[int, str]
        """
        self.name = class_name
        self.parent_name = parent_name
        self.vtbl_ea = vtbl_ea
        self.vfuncs = vfuncs
        self.funcs = funcs

        # Offset the vtbl and funcs if the program has been rebased
        current_image_base = api.get_image_base()
        if self.STANDARD_IMAGE_BASE != current_image_base:
            rebase_offset = current_image_base - self.STANDARD_IMAGE_BASE
            if self.vtbl_ea != 0x0:
                self.vtbl_ea += rebase_offset
            for ea in list(funcs.keys()):
                funcs[ea + rebase_offset] = funcs.pop(ea)

    # region parent_class_names

    _parent_names = None

    @property
    def parent_names(self):
        """
        Get the class names of the entire hierarchy as a flat list
        :return: List of parent names
        :rtype: List[str]
        """
        if self._parent_names is None:
            self._parent_names = []

            current_class = self.parent_class
            while current_class:
                self._parent_names.append(current_class.name)
                current_class = current_class.parent_class

        return self._parent_names

    # endregion

    # region vtbl_size

    _vtbl_size = 0

    @property
    def vtbl_size(self):
        """
        Iterate from the vtbl start until a non-offset or xref is encountered.
        This strategy implies that the only xref in a vtbl is the first vfunc.
        :return: VTable func count
        :rtype: int
        """
        if self.vtbl_ea == 0x0:
            return self._vtbl_size

        if self._vtbl_size == 0:
            self._vtbl_size = 1  # Set to 1, skip the first entry
            for ea in itertools.count(self.vtbl_ea + 8, 8):
                if api.is_offset(ea) and api.xrefs_to(ea) == []:
                    self._vtbl_size += 1
                else:
                    break

            if self.parent_class and self.vtbl_size < self.parent_class.vtbl_size:
                print("Error: The sum of \"{0}\"'s parent vtbl sizes ({1}) is greater than the actual class itself ({2})".format(self.name, self.parent_class.vtbl_size, self.vtbl_size))

        return self._vtbl_size

    # endregion

    # region finalized

    _finalized = False

    @property
    def finalized(self):
        """
        Has this class and its hierarchy been written out or not
        :return: bool yes/no
        :rtype: bool
        """
        if self.parent_class:
            return self._finalized and self.parent_class.finalized
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
        self._inherit_func_names_from_parent()
        self._comment_vtbl_with_inheritance_tree()

        builder, struct_members = self._build_vtbl()
        self._write_vtbl(builder)
        self._write_funcs()

        vtbl_name = api.format_class_name_for_vtbl(self.name)
        api.write_vtbl_struct(vtbl_name, struct_members)

        self.finalized = True

    def _inherit_func_names_from_parent(self):
        """
        A parent is guaranteed to be finalized before the child,
        so a parent has all the vfunc names of its parent already.
        :return: None
        :rtype: None
        """
        if self.parent_class:
            for idx, parent_vfunc_name in self.parent_class.vfuncs.items():
                if idx in self.vfuncs:
                    print("Warning: 0x{0:X} \"{1}\" overwrites the name of inherited function \"{2}\"".format(self.vtbl_ea, self.name, parent_vfunc_name))
                    pass
                else:
                    self.vfuncs[idx] = parent_vfunc_name

    def _comment_vtbl_with_inheritance_tree(self):
        """
        Adds the inheritance tree as a comment to the start of the vtbl.
        grandparent_name
            parent_name
                self_name
        :return: None
        :rtype: None
        """
        comment = api.get_comment(self.vtbl_ea) or ""
        indent = 0
        for class_name in self.parent_names[-1::-1] + [self.name]:
            if comment:
                comment += "\n"
            comment += (" " * indent) + api.format_class_name_for_vtbl(class_name)
            indent += 4
        api.set_comment(self.vtbl_ea, comment)

    def _build_vtbl(self):
        """
        Build a list of (ea, func_name) tuples to be written
        :return: List of (ea, func_name) tuples and struct names
        :rtype: Tuple[List[Tuple[int, str]], List[str]]
        """
        vtbl_builder = []
        struct_names = []

        # Iterate through each offset
        for idx in range(0, self.vtbl_size):
            vtbl_vfunc_ea = self.vtbl_ea + idx * 8
            vfunc_ea = api.get_qword(vtbl_vfunc_ea)  # type: int

            current_func_name = api.get_addr_name(vfunc_ea)  # type: str
            proposed_func_name = self.vfuncs.get(idx, "vf{0}".format(idx))
            formatted_class_name = api.format_class_name(self.name)
            formatted_parent_class_names = [api.format_class_name(name) for name in self.parent_names]

            func_name = api.format_vfunc_name(vfunc_ea, current_func_name, proposed_func_name, formatted_class_name, formatted_parent_class_names)
            struct_names.append(proposed_func_name)

            if func_name == "":
                pass
            elif func_name is None:
                print("Error: Function at 0x{0:X} had unexpected name \"{1}\" during naming of {2}.{3} (vtbl[{4}])".format(vfunc_ea, current_func_name, self.name, proposed_func_name, idx))
            else:
                vtbl_builder.append((vfunc_ea, func_name))

        return vtbl_builder, struct_names

    def _write_vtbl(self, builder):
        """
        Write out the vtbl as defined by _build_vtbl
        :param builder: List of (ea, func_name) tuples
        :type builder: List[Tuple[int, str]]
        :return: None
        :rtype: None
        """
        api.set_addr_name(self.vtbl_ea, api.format_class_name_for_vtbl(self.name))

        for (func_ea, func_name) in builder:
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
                print("Error: Function at 0x{0:X} had unexpected name \"{1}\" during naming of {2}.{3}".format(func_ea, current_func_name, self.name, proposed_func_name))
            else:
                api.set_addr_name(func_ea, func_name)

    # endregion

    def __repr__(self):
        return "<{0}(\"{1}\")>".format(self.__class__.__name__, self.name)


# endregion

print("Executing")
load_data()
print("Done")

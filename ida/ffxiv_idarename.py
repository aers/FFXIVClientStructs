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


class BaseApi(object):
    @property
    @abstractmethod
    def data_file_path(self):
        """
        Get the Path to the data.yml File
        :return: Path to the data.yml File
        :rtype: str
        """

    @property
    @abstractmethod
    def sub_prefixes(self):
        """
        Common prefixes that funcs are labeled with. "SUB_", "FUNC_", "THUNK_", etc.
        :return: List of prefixes
        :rtype: List[str]
        """

    @property
    @abstractmethod
    def nullsub_prefixes(self):
        """
        What nullsub funcs look like, might only be an IDA thing. "nullsub_<name>"
        :return: List of prefixes
        :rtype: List[str]
        """

    @property
    @abstractmethod
    def loc_prefixes(self):
        """
        What locations look like, might only be an IDA thing. "loc_<name>"
        :return: List of prefixes
        :rtype: List[str]
        """

    @property
    @abstractmethod
    def jump_prefix(self):
        """
        What jumpsubs look like, might only be an IDA thing. "j_<name>"
        :return: str
        """

    @property
    @abstractmethod
    def purecall_str(self):
        """
        Special func name case, something like "_purecall" perhaps.
        :return: str
        """

    @abstractmethod
    def get_image_base(self):
        """
        Get the image base ea
        :return: Image base ea
        :rtype: int
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
    def get_addr_name(self, ea):
        """
        Get the name of a given address
        :param ea: Effective address
        :type ea: int
        :return: Name or empty
        :rtype: str
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
    def get_struct_id(self, name):
        """
        Get the ID of a given struct by name
        :param name: Struct name
        :type name: str
        :return: Struct ID, -1 if does not exist
        :rtype: int
        """

    @abstractmethod
    def create_struct(self, name):
        """
        Create a new struct with the given Name
        :param name: Struct name
        :type name: str
        :return: Struct ID, -1 if failure
        :rtype: int
        """

    @abstractmethod
    def add_struct_member(self, sid, name):
        """
        Add a new struct member at the end of the structure
        :param sid: Struct ID
        :type sid: int
        :param name: Struct member name
        :type name: str
        :return: Success/failure
        :rtype: bool
        """

    @abstractmethod
    def clear_struct(self, sid):
        """
        Delete all struct members
        :param sid: Struct ID
        :type sid: int
        :return: Success/failure
        :rtype: bool
        """

    @abstractmethod
    def convert_to_struct(self, ea, sid):
        """
        Convert a location to a struct
        :param ea: Effective address
        :type ea: int
        :param sid: Struct ID
        :type sid: int
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

            @property
            def sub_prefixes(self):
                return ["sub_"]

            @property
            def nullsub_prefixes(self):
                return ["nullsub_"]

            @property
            def loc_prefixes(self):
                return ["loc_"]

            @property
            def jump_prefix(self):
                return "j_"

            @property
            def purecall_str(self):
                return "_purecall"

            def get_image_base(self):
                return idaapi.get_imagebase()

            def set_addr_name(self, ea, name):
                result = idc.set_name(ea, name)
                return bool(result)

            def get_addr_name(self, ea):
                return idc.get_name(ea)

            def get_qword(self, ea):
                return idc.get_qword(ea)

            def is_offset(self, ea):
                return idc.is_off0(idc.get_full_flags(ea))

            def xrefs_to(self, ea):
                return [xref.to for xref in idautils.XrefsTo(ea)]

            def get_struct_id(self, name):
                sid = idc.get_struc_id(name)
                if sid == idc.BADADDR:
                    return -1
                else:
                    return sid

            def create_struct(self, name):
                sid = idc.add_struc(-1, name, is_union=0)
                return sid

            def add_struct_member(self, sid, name):
                idc.add_struc_member(sid, name, offset=-1, flag=idc.FF_DATA | idc.FF_QWORD, typeid=-1, nbytes=8, reftype=idc.REF_OFF64)
                member_offset = idc.get_last_member(sid)
                member_id = idc.get_member_id(sid, member_offset)
                idc.SetType(member_id, "void*")

            def clear_struct(self, sid):
                member_offset = idc.get_first_member(sid)
                if member_offset == -1:
                    return False
                while member_offset != idc.BADADDR:
                    idc.del_struc_member(sid, member_offset)
                    member_offset = idc.get_first_member(sid)
                return True

            def convert_to_struct(self, ea, sid):
                struct_name = idc.get_struc_name(sid)
                result = idc.create_struct(ea, -1, struct_name)
                return bool(result)

            def get_comment(self, ea):
                idc.get_cmt(ea, False)

            def set_comment(self, ea, comment):
                idc.set_cmt(ea, comment, False)


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

            @property
            def sub_prefixes(self):
                return ["FUN_", "LAB_", "SUB_"]

            @property
            def nullsub_prefixes(self):
                return ["FUN_", "LAB_", "SUB_"]

            @property
            def loc_prefixes(self):
                return ["LOC_"]

            @property
            def jump_prefix(self):
                return "thunk_"

            @property
            def purecall_str(self):
                return "_purecall"

            def get_image_base(self):
                return currentProgram.getImageBase().getOffset()

            def set_addr_name(self, ea, name):
                return createLabel(toAddr(ea), name, True).checkIsValid()

            def get_addr_name(self, ea):
                sym = getSymbolAt(toAddr(ea))
                if not sym: return None
                return sym.getName(True)

            def get_qword(self, ea):
                return getLong(toAddr(ea))

            def is_offset(self, ea):
                data = getDataAt(toAddr(ea))
                if not data:
                    return False
                return data.isPointer()

            def xrefs_to(self, ea):
                return [xref.getFromAddress().getOffset() for xref in getReferencesTo(toAddr(ea))]

            def get_struct_id(self, name):
                gdt = currentProgram.getDataTypeManager()
                struct = gdt.getDataType(CategoryPath("/___vftables"), name.replace("_struct", ""))
                if struct: return gdt.getID(struct)
                return -1

            def create_struct(self, name):
                structName = name.replace("_struct", "")
                structPath = CategoryPath("/___vftables")
                gdt = currentProgram.getDataTypeManager()
                struct = gdt.getDataType(structPath, structName)
                if not struct:
                    struct = StructureDataType(structPath, structName, 0, gdt)
                struct.deleteAll()
                dt = gdt.addDataType(struct, None)
                return gdt.getID(dt)

            def add_struct_member(self, sid, name):
                gdt = currentProgram.getDataTypeManager()
                struct = gdt.getDataType(sid)
                if not struct:
                    return False
                member = struct.add(PointerDataType(), 8, name, None)
                return True

            def clear_struct(self, sid):
                gdt = currentProgram.getDataTypeManager()
                struct = gdt.getDataType(sid)
                if not struct:
                    return False
                struct.deleteAll()
                return True

            def convert_to_struct(self, ea, sid):
                return False

            def get_comment(self, ea):
                return getEOLComment(toAddr(ea))

            def set_comment(self, ea, comment):
                if getEOLComment(toAddr(ea)) is None:
                    setEOLComment(toAddr(ea), comment)


        api = GhidraApi()

# endregion

if api is None:
    raise Exception("Unable to load IDA or Ghidra")


def load_data():
    with open(api.data_file_path, "r") as fd:
        data = yaml.safe_load(fd)

    for ea, name in data["globals"].items():
        if not isinstance(ea, int):
            print('Warning: {0} has an invalid address {1}'.format(name, ea))
            continue
        api.set_addr_name(ea, name)

    for ea, name in data["functions"].items():
        if not isinstance(ea, int):
            print('Warning: {0} has an invalid address {1}'.format(name, ea))
            continue
        api.set_addr_name(ea, name)

    factory = FfxivClassFactory()
    for class_name, class_data in data["classes"].items():
        if not class_data:
            class_data = {}

        vtbl_ea = class_data.pop("vtbl", 0x0)
        parent_class_name = class_data.pop("inherits_from", "")
        funcs = class_data.pop("funcs", {})
        vfuncs = class_data.pop("vfuncs", {})
        for leftover in class_data:
            print("Warning: Extra key \"{0}\" present in {1}".format(leftover, class_name))

        factory.register(class_name, parent_class_name, vtbl_ea, vfuncs, funcs)

    factory.finalize()


class FfxivClassFactory:
    # {name: ea}
    _vtbls_ea = []  # type: List[int]
    # name -> {class_name: FfxivClass}
    _classes = {}  # type: Dict[str, FfxivClass]

    def register(self, class_name, parent_class_name="", vtbl_ea=0x0, funcs=None, vfuncs=None):
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
        """
        if not vfuncs:
            vfuncs = {}

        if not funcs:
            funcs = {}

        if vtbl_ea in self._vtbls_ea and vtbl_ea != 0x0:
            print("Error: Multiple vtables are defined at 0x{0:X}".format(vtbl_ea))
            return

        if class_name in self._classes:
            print("Error: Multiple classes are registered with the name \"{0}\"".format(class_name))
            return

        self._vtbls_ea.append(vtbl_ea)
        self._classes[class_name] = FfxivClass(class_name, parent_class_name, vtbl_ea, vfuncs, funcs)

    def finalize(self):
        """
        Perform the class naming
        :return: None
        """
        self._resolve_class_inheritance()
        for class_name, cls in self._classes.items():
            self._finalize_class(cls)

    def _resolve_class_inheritance(self):
        """
        Set the parent_class attribute in each cls to the object corresponding to its parent_class_name attribute
        :return: None
        """
        for class_name, cls in list(self._classes.items()):
            if cls.parent_class is None and cls.parent_class_name:
                if cls.parent_class_name not in self._classes:
                    print("Warning: Inherited class \"{0}\" is not documented, add a placeholder entry".format(cls.parent_class_name))
                    self.register(cls.parent_class_name)
                cls.parent_class = self._classes[cls.parent_class_name]

    _finalize_stack = deque()

    def _finalize_class(self, cls):
        """
        Perform a single class naming
        :param cls: Class object
        :type cls: FfxivClass
        :return: None
        """
        if cls in self._finalize_stack:
            names = [c.name for c in self._finalize_stack] + [cls.name]
            names = "\n".join(["    - {0}".format(name) for name in names])
            raise ValueError("Inheritance cycle detected: \n{0}".format(names))

        self._finalize_stack.append(cls)

        if not cls.finalized:
            if cls.parent_class and not cls.parent_class.finalized:
                self._finalize_class(cls.parent_class)
            cls.finalize()

        self._finalize_stack.pop()


class FfxivClass:
    STANDARD_IMAGE_BASE = 0x140000000

    VTBL_FORMAT = "vtbl_{cls}"
    NAMED_FUNC_FORMAT = "{cls}.{name}"
    GENERIC_SUB_FORMAT = "{cls}.vf{index}"
    GENERIC_NULLSUB_FORMAT = "{cls}.vf{index}_nullsub"
    GENERIC_LOC_FORMAT = "{cls}.vloc{index}"

    STRUCT_VTBL_FORMAT = "vtbl_{cls}_struct"
    STRUCT_NAMED_FORMAT = "{name}"
    STRUCT_GENERIC_SUB_FORMAT = "vf{index}"
    STRUCT_GENERIC_NULLSUB_FORMAT = "vf{index}_nullsub"
    STRUCT_GENERIC_LOC_FORMAT = "vloc{index}"
    STRUCT_PURECALL_FORMAT = "purecall{index}"
    STRUCT_MANGLE_FORMAT = "mangled{index}"

    parent_class = None  # type: FfxivClass

    def __init__(self, class_name, parent_class_name, vtbl_ea, vfuncs, funcs):
        """
        Object representing a class
        :param class_name: Class name
        :type class_name: str
        :param parent_class_name: Parent class
        :type parent_class_name: str
        :param vtbl_ea: Vtable effective address
        :type vtbl_ea: int
        :param vfuncs: Mapping of vtbl index to func names
        :type funcs: Dict[int, str]
        :param funcs: Mapping of effective addresses to func names
        :type funcs: Dict[int, str]
        """
        self.name = class_name
        self.parent_class_name = parent_class_name
        self.vtbl_ea = vtbl_ea
        self.vfuncs = vfuncs
        self.funcs = funcs

        # Offset the vtbl and funcs if the program has been rebased
        current_image_base = api.get_image_base()
        if self.STANDARD_IMAGE_BASE != current_image_base:
            rebase_offset = current_image_base - self.STANDARD_IMAGE_BASE
            self.vtbl_ea += rebase_offset
            for ea in list(funcs.keys()):
                funcs[ea + rebase_offset] = funcs.pop(ea)

    # region parent_class_names

    _parent_class_names = None

    @property
    def parent_class_names(self):
        """
        Get the class names of the entire hierarchy as a flat list
        :return: [class_name]
        """
        if self._parent_class_names is None:
            self._parent_class_names = []

            current_class = self.parent_class
            while current_class:
                self._parent_class_names.append(current_class.name)
                current_class = current_class.parent_class

        return self._parent_class_names

    # endregion

    # region vtbl_size

    _vtbl_size = 0

    @property
    def vtbl_size(self):
        """
        Iterate from the vtbl start until a non-offset or xref is encountered.
        This strategy implies that the only xref in a vtbl is the first vfunc.
        :return: VTable func count
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
        self._finalized = value

    # endregion

    # region finalize

    def finalize(self):
        """
        Write out this class
        :return: None
        """
        self._inherit_func_names_from_parent()
        self._comment_vtbl_with_inheritance_tree()
        self._write_vtbl()
        self._write_funcs()
        self.finalized = True

    def _inherit_func_names_from_parent(self):
        if self.parent_class:
            for idx, parent_vfunc_name in self.parent_class.vfuncs.items():
                if idx in self.vfuncs:
                    print("Warning: 0x{0:X} \"{1}\" overwrites the name of inherited function \"{2}\"".format(self.vtbl_ea, self.name, parent_vfunc_name))
                    pass
                else:
                    self.vfuncs[idx] = parent_vfunc_name

    def _comment_vtbl_with_inheritance_tree(self):
        comment = api.get_comment(self.vtbl_ea) or ""
        indent = 0
        for parent_class_name in self.parent_class_names[-1::-1] + [self.name]:
            if comment:
                comment += "\n"
            comment += (" " * indent) + self.VTBL_FORMAT.format(cls=parent_class_name)
            indent += 4
        api.set_comment(self.vtbl_ea, comment)

    def _build_vtbl(self):
        class_func_addresses = []
        class_func_names = []
        struct_member_names = []

        # Iterate through each offset
        for idx in range(0, self.vtbl_size):
            vfunc_offset = self.vtbl_ea + idx * 8
            vfunc_ea = api.get_qword(vfunc_offset)  # type: int

            current_func_name = api.get_addr_name(vfunc_ea)  # type: str
            if current_func_name.startswith(api.jump_prefix):
                current_func_name = current_func_name.lstrip(api.jump_prefix)

            if idx in self.vfuncs:
                named_func = self.vfuncs[idx]
                named_full_func_name = self.NAMED_FUNC_FORMAT.format(cls=self.name, name=named_func)
                named_struct_member_name = named_func
            else:
                named_full_func_name = ""
                named_struct_member_name = ""

            if current_func_name.startswith("qword_"):
                # Problem for another day, or codatify
                if isinstance(api, IdaApi) and self.name == "Client::Graphics::Scene::Human" and idx == 61:
                    idc.auto_mark_range(vfunc_ea, vfunc_ea + 1, idc.AU_CODE)
                    idc.create_insn(vfunc_ea)
                    idc.add_func(vfunc_ea)
                    current_func_name = api.get_addr_name(vfunc_ea)  # type: str
                else:
                    print("Warning: qword in vtbl at 0x{0:X}, it may be an offset to undefined code".format(vfunc_offset))

            if self._text_has_prefix(current_func_name, self.name):
                generic_full_func_name = current_func_name
                generic_struct_member_name = current_func_name.strip(self.name).strip(".")
            elif self._text_has_prefix(current_func_name, api.sub_prefixes):
                generic_full_func_name = self.GENERIC_SUB_FORMAT.format(cls=self.name, index=idx)
                generic_struct_member_name = self.STRUCT_GENERIC_SUB_FORMAT.format(index=idx)
            elif self._text_has_prefix(current_func_name, api.nullsub_prefixes):
                generic_full_func_name = self.GENERIC_NULLSUB_FORMAT.format(cls=self.name, index=idx)
                generic_struct_member_name = self.STRUCT_GENERIC_NULLSUB_FORMAT.format(index=idx)
            elif self._text_has_prefix(current_func_name, api.loc_prefixes):
                generic_full_func_name = self.GENERIC_LOC_FORMAT.format(cls=self.name, index=idx)
                generic_struct_member_name = self.STRUCT_GENERIC_LOC_FORMAT.format(index=idx)
            elif self._text_has_prefix(current_func_name, self.parent_class_names):
                generic_full_func_name = None  # No override present
                generic_struct_member_name = current_func_name.split(".", 1)[-1]
            elif current_func_name == api.purecall_str:
                generic_full_func_name = None  # Ignored
                generic_struct_member_name = self.STRUCT_PURECALL_FORMAT.format(index=idx)
            elif current_func_name.startswith("?") or current_func_name.startswith("_"):
                generic_full_func_name = None  # Mangled
                generic_struct_member_name = self.STRUCT_MANGLE_FORMAT.format(index=idx)
            else:
                print("Error: Unexpected function name \"{0}\" at 0x{1:X}".format(current_func_name, self.vtbl_ea + idx * 8))
                generic_full_func_name = None
                generic_struct_member_name = "naming_error{0}".format(idx)

            class_func_addresses.append(vfunc_ea)

            if generic_full_func_name is None:
                class_func_names.append(None)
            else:
                class_func_names.append(named_full_func_name or generic_full_func_name)

            struct_member_names.append(named_struct_member_name or generic_struct_member_name)

        return class_func_addresses, class_func_names, struct_member_names

    def _write_vtbl(self):
        class_func_addresses, class_func_names, struct_member_names = self._build_vtbl()

        api.set_addr_name(self.vtbl_ea, self.VTBL_FORMAT.format(cls=self.name))

        for func_ea, func_name in zip(class_func_addresses, class_func_names):
            if func_name:
                api.set_addr_name(func_ea, func_name)

        struct_name = self.STRUCT_VTBL_FORMAT.format(cls=self.name)
        struct_id = api.get_struct_id(struct_name)
        if struct_id == -1:
            struct_id = api.create_struct(struct_name)
        else:
            api.clear_struct(struct_id)
        for struct_member_name in struct_member_names:
            api.add_struct_member(struct_id, struct_member_name)
        # Running the script twice will undefine vast segments of the vtbl since they're now structs
        # Need to work a method of not screwing that up.
        # api.convert_to_struct(self.vtbl_ea, struct_id)

    def _write_funcs(self):
        """
        Write the names of all non-vtbl funcs
        :return: None
        """
        for ea, func_name in self.funcs.items():
            full_func_name = self.NAMED_FUNC_FORMAT.format(cls=self.name, name=func_name)

            current_func_name = api.get_addr_name(ea)  # type: str
            if self._text_has_prefix(current_func_name, api.jump_prefix):
                current_func_name = current_func_name.lstrip(api.jump_prefix)

            if current_func_name == full_func_name:
                continue  # same name? skip it
            elif current_func_name == api.purecall_str:
                continue  # purecall? skip it
            elif current_func_name == "":
                api.set_addr_name(ea, full_func_name)
            # check that the name is unnamed
            elif self._text_has_prefix(current_func_name, api.sub_prefixes + api.nullsub_prefixes + api.loc_prefixes):
                api.set_addr_name(ea, full_func_name)
            else:
                print("Warning: 0x{0:X} \"{1}\" was already named \"{2}\"".format(ea, func_name, current_func_name))

    # endregion

    def _text_has_prefix(self, text, prefixes):
        """
        Wrapper to check if any text.startswith(prefix)
        :param text: Text to check
        :type text: str
        :param prefixes: Prefix or List of prefixes
        :type prefixes: str|List[str]
        :return: True/False
        """
        if not text:
            return False
        if isinstance(prefixes, str):
            return text.startswith(prefixes)
        return any([text.startswith(prefix) for prefix in prefixes])

    def __repr__(self):
        return "<{0}(\"{1}\")>".format(self.__class__.__name__, self.name)


# endregion

print("Executing")
load_data()
print("Done")

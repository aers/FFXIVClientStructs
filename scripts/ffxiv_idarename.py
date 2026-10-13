# current exe version: 2020.12.29.0000.0000
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_idarename
# @runtime PyGhidra

from __future__ import print_function
import os

try:
    from typing import Any, Dict, List, Optional, Union  # noqa
except ImportError:
    pass

import sys
from abc import abstractmethod

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
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        raise ValueError("Script moved to new location in ./ida/rename.py")

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
        def toAddr(offset): # noqa
            # type: (int) -> Address
            return currentProgram.getAddressFactory().getDefaultAddressSpace().getAddress(offset) # noqa

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
                if not sym and getByte(toAddr(ea).subtract(1)) & 0xFF == 0xCC:
                    disassemble(toAddr(ea))
                    createFunction(toAddr(ea), None)
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
                # override default thunk names and thunks of already named funcs with the default
                func = getFunctionAt(toAddr(ea))
                if func and func.isThunk():
                    current_func_name = "FUN_{0:x}".format(ea)

                proposed_qualified_func_name = "{0}.{1}".format(class_name, proposed_func_name)
                if current_func_name == proposed_qualified_func_name:
                    return ""

                if any(current_func_name.startswith(prefix) for prefix in ("FUN_", "LAB_", "SUB_", "LOC_", "DAT_")):
                    return proposed_qualified_func_name

                return None


        api = GhidraApi()

# endregion

if api is None:
    raise Exception("Unable to load API (supported: IDA, Ghidra, Binary Ninja)")


# endregion

def load_data():
    with open(api.data_file_path, "r") as fd:
        data = get_yaml(fd)

    apply_data(api, data)


print("Executing")
load_data()
print("Done")

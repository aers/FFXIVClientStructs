# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_structimport
# @runtime PyGhidra

from yaml import load

try:
    from yaml import CSafeLoader as Loader
except ImportError:
    from yaml import SafeLoader as Loader

import os
from abc import abstractmethod
from time import time
from structs_schema import *
from src_wrapper import SrcInterface


predefine = """#define _HAS_ITERATOR_DEBUGGING 0
#define _ITERATOR_DEBUG_LEVEL 0
#include <vector>
#include <set>
#include <map>
#include <string>
#include <list>
#include <deque>
#include <cstdint>

"""

class BaseApi:
    @abstractmethod
    def can_run(self):
        # type: () -> None
        """
        Checks if exdgetters has run before this is allowed to continue
        """

    @abstractmethod
    def create_enum_struct(self, enum):
        # type: (DefinedStructEnum) -> None
        """
        Create an enum in the database.
        """

    @abstractmethod
    def delete_enum(self, enum):
        # type: (DefinedStructEnum) -> None
        """
        Delete an enum in the database.
        """

    @abstractmethod
    def delete_struct(self, struct):
        # type: (DefinedStruct) -> None
        """
        Delete a struct in the database.
        """

    @abstractmethod
    def create_struct(self, struct):
        # type: (DefinedStruct) -> None
        """
        Create a struct in the database.
        """

    @abstractmethod
    def create_struct_members(self, struct):
        # type: (DefinedStruct) -> None
        """
        Create members for a struct in the database.
        """

    @abstractmethod
    def create_vtable(self, struct):
        # type: (DefinedStruct) -> None
        """
        Create a vtable in the database.
        """

    @abstractmethod
    def finalise_struct(self, struct):
        # type: (DefinedStruct) -> None
        """
        Finalise a struct in the database.
        """

    @abstractmethod
    def create_union(self, struct):
        # type: (DefinedStruct) -> None
        """
        Create a union in the database.
        """

    @abstractmethod
    def update_member_func(self, member_func, struct):
        # type: (DefinedStructMemFunc, DefinedStruct) -> None
        """
        Updates a member function in the database.
        """

    @abstractmethod
    def update_virt_func(self, virt_func, struct):
        # type: (DefinedStructVFunc, DefinedStruct) -> None
        """
        Updates a virtual function in the database.
        """

    @abstractmethod
    def update_static_member(self, static_member, struct):
        # type: (DefinedStructStaticMember, DefinedStruct) -> None
        """
        Updates a static member in the database.
        """

    @abstractmethod
    def should_update_member_func(self):
        # type: () -> bool
        """
        Returns if the member function types should be updated.
        """

    @abstractmethod
    def should_update_virt_func(self):
        # type: () -> bool
        """
        Returns if the virtual function types should be updated.
        """

    @property
    @abstractmethod
    def get_file_path(self):
        """
        Retrieve the file path of the yaml file.
        """

    def get_yaml(self):
        # type: () -> DefinedStructExport
        with open(self.get_file_path, "r") as fd:
            return get_yaml(fd)

    @abstractmethod
    def preprocess_yaml(self, yml: DefinedStructExport):
        """
        Preprocesses the YAML data before importing.

        For the IDA srclang importer, this fixes issues with generic base classes.
        """

    def load_data_yaml(self):
        # type: () -> dict
        path = os.path.join(os.path.dirname(self.get_file_path), "data.yml")
        if not os.path.exists(path):
            return None
        with open(path, "r") as fd:
            return load(fd, Loader=Loader)

api = None

if api is None:
    try:
        import idaapi
        import idc
        import ida_bytes
        import ida_search
        import ida_typeinf
        import ida_funcs
        import ida_name
        import ida_kernwin
        import ida_srclang
        import hashlib
        import copy
        from ida.ida_wrapper import IdaInterface
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi, IdaInterface):
            def validate_name_cfg(self):
                """Verifies that the user's IDA config allows template characters for type names"""
                temporary_name = "struc_name_test"
                template_name = "OuterStructTest<InnerStructTest<int>*>"

                def delete_test_type(name):
                    sid = self.get_struct_id(name)
                    if sid == idaapi.BADADDR:
                        return
                    if idaapi.IDA_SDK_VERSION >= 900:
                        ida_typeinf.del_named_type(idaapi.get_idati(), name, ida_typeinf.NTF_TYPE)
                    else:
                        idc.del_struc(sid)

                created_name = None
                try:
                    template_sid = self.get_struct_id(template_name)
                    temporary_sid = self.get_struct_id(temporary_name)

                    if template_sid != idaapi.BADADDR:
                        if temporary_sid != idaapi.BADADDR:
                            return True
                        
                        self.rename_struct(template_sid, temporary_name)
                        if self.get_struct_id(template_name) != idaapi.BADADDR:
                            raise RuntimeError("could not rename existing template test type")
                        
                        temporary_sid = self.get_struct_id(temporary_name)

                    if temporary_sid == idaapi.BADADDR:
                        temporary_sid = self.create_struct_type(temporary_name)

                    if temporary_sid == idaapi.BADADDR:
                        raise RuntimeError("could not create temporary struct")
                    
                    created_name = temporary_name

                    self.rename_struct(temporary_sid, template_name)
                    if self.get_struct_id(template_name) == idaapi.BADADDR:
                        raise RuntimeError("could not rename temporary struct to template type name")
                    
                    created_name = template_name
                except Exception as exc:
                    return False # dropping exception, but will prompt the user to fix their cfg and exit
                
                finally:
                    if created_name is not None:
                        delete_test_type(created_name)
                    delete_test_type(temporary_name)

                return True

            def get_fallback_vfunc_name(self, class_name, index, visited=None):
                # type: (str, int, set) -> str
                if not hasattr(self, "data_yaml") or not self.data_yaml or "classes" not in self.data_yaml:
                    return None
                
                if visited is None:
                    visited = set()
                
                if class_name in visited:
                    return None
                visited.add(class_name)

                if class_name not in self.data_yaml["classes"]:
                    return None
                
                class_data = self.data_yaml["classes"][class_name]
                if not class_data:
                    return None

                if "vfuncs" in class_data and index in class_data["vfuncs"]:
                    return class_data["vfuncs"][index]

                if "vtbls" in class_data and isinstance(class_data["vtbls"], list) and len(class_data["vtbls"]) > 0:
                    vtbl = class_data["vtbls"][0]
                    if "base" in vtbl:
                        res = self.get_fallback_vfunc_name(vtbl["base"], index, visited)
                        if res:
                            return res

                return None

            def get_vft_from_data(self, class_name):
                # type: (str) -> dict | None
                if not self.data_yaml or "classes" not in self.data_yaml:
                    return None

                class_data = self.data_yaml["classes"].get(class_name) or {}
                vtables = class_data.get("vtbls", [])
                if not isinstance(vtables, list) or not vtables:
                    return None

                vtable = vtables[0]
                return vtable if isinstance(vtable, dict) else None

            def get_vfunc_ea_from_data(self, class_name, offset):
                # type: (str, int) -> int
                vtable = self.get_vft_from_data(class_name)
                if vtable is None or "ea" not in vtable:
                    return idc.BADADDR

                # assuming data.yml will continue using default windows base
                vtable_ea = vtable["ea"] + idaapi.get_imagebase() - 0x140000000
                return idc.get_qword(vtable_ea + offset)

            def delete_struct_members(self, fullname):
                # type: (str) -> None
                pass

            @property
            def get_file_path(self):
                return os.path.join(
                    os.path.dirname(os.path.realpath(__file__)), "ffxiv_structs.yml"
                )
            
            def generate_hashed_type_name(self, name: str) -> str:                
                return ""

            def get_srclang_type_name(self, name: str) -> str:
                return ""

            def can_run(self):
                return self.enum_exists("Component::Exd::SheetsEnum")

            def create_enum_struct(self, enum):
                # type: (DefinedStructEnum) -> None
                return

            def delete_enum(self, enum):
                # type: (DefinedStructEnum) -> None
                return

            def delete_struct(self, struct):
                # type: (DefinedStruct) -> None
                return

            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                return

            def validate_srclang_struct(self, struct: DefinedStruct):
                pass

            def get_srclang_fill_type(self, available_bytes: int, current_offset: int) -> tuple[str, int]:
                return ("", 0)

            def append_srclang_padding(self, decl: list[str], current_size: int, target_size: int) -> int:
                return 0

            def create_srclang_decl(self, struct: DefinedStruct) -> str:
                return ""

            def create_struct_member_fill(self, struct_name, offset):
                # type: (str, int) -> None
                pass
                
            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                pass

            def create_vtable(self, struct):
                # type: (DefinedStruct) -> None
                pass

            def finalise_struct(self, struct: DefinedStruct):
                pass

            def create_union(self, struct):
                # type: (DefinedStruct) -> None
                pass

            def update_member_func(self, member_func, struct):
                # type: (DefinedStructMemFunc, DefinedStruct) -> None
                func_name = "{0}.{1}".format(
                    self.clean_name(struct.type), member_func.name
                )
                ea = self.get_func_ea_by_name(func_name)
                if ea == idc.BADADDR:
                    ea = self.get_func_ea_by_sig(member_func.signature)
                if ea == idc.BADADDR:
                    print(
                        "Error: {0} not found bad sig? {1}".format(
                            func_name, member_func.signature
                        )
                    )
                    return
                if ida_funcs.get_func_name(ea) == "sub_{0:X}".format(ea):
                    idc.set_name(ea, func_name)
                tif = ida_typeinf.tinfo_t()
                ida_typeinf.guess_tinfo(tif, ea)
                func_data = ida_typeinf.func_type_data_t()
                tif.get_func_details(func_data)
                func_data.clear()
                func_data.cc = ida_typeinf.CM_CC_FASTCALL
                func_data.rettype = self.get_tinfo_from_type(member_func.return_type)
                for param in member_func.parameters:
                    arg = ida_typeinf.funcarg_t()
                    try:
                        arg.type = self.get_tinfo_from_type(param.type)
                    except ValueError as exc:
                        print(
                            "Error: update_member_func: function={!r}, ea={:#x}, "
                            "parameter={!r}, type={!r}, error={}".format(
                                func_name, ea,
                                param.name, param.type, exc
                            )
                        )
                        raise
                    arg.name = param.name
                    func_data.push_back(arg)
                tif.create_func(func_data)
                ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def update_virt_func(self, virt_func, struct):
                # type: (DefinedStructVFunc, DefinedStruct) -> None
                func_name = "{0}.{1}".format(
                    self.clean_name(struct.type), virt_func.name
                )

                ea = self.get_func_ea_by_name(func_name)
                if ea == idc.BADADDR:
                    ea = self.get_vfunc_ea_from_data(struct.type, virt_func.offset)
                    if ea in (0, idc.BADADDR):
                        print(f"Error: {func_name} not found and its VFT slot could not be resolved")
                        return

                    actual_name = ida_funcs.get_func_name(ea) or ""
                    normalized_name = actual_name
                    for prefix in ("j_", "thunk_"):
                        if normalized_name.startswith(prefix):
                            normalized_name = normalized_name[len(prefix):]

                    # pure virtual, nothing to do
                    if normalized_name == "_purecall":
                        return

                    primary_vtable = self.get_vft_from_data(struct.type)
                    primary_base = primary_vtable.get("base") if primary_vtable else None
                    if primary_base:
                        base_ea = self.get_vfunc_ea_from_data(primary_base, virt_func.offset)
                        # if the derived vft slot points to the same as the baseclass, leave baseclass type
                        if base_ea == ea:
                            return

                    # does it look inherited based on name? leave it alone
                    if (
                        normalized_name.endswith("." + virt_func.name)
                        and not normalized_name.startswith(self.clean_name(struct.type) + ".")
                    ):
                        return

                tif = ida_typeinf.tinfo_t()
                ida_typeinf.guess_tinfo(tif, ea)

                func_data = ida_typeinf.func_type_data_t()
                tif.get_func_details(func_data)

                func_data.clear()
                func_data.cc = ida_typeinf.CM_CC_FASTCALL
                func_data.rettype = self.get_tinfo_from_type(virt_func.return_type)

                for param in virt_func.parameters:
                    arg = ida_typeinf.funcarg_t()
                    try:
                        arg.type = self.get_tinfo_from_type(param.type)
                    except ValueError as exc:
                        print(
                            "Error: update_virt_func: function={!r}, ea={:#x}, "
                            "parameter={!r}, type={!r}, error={}".format(
                                func_name, ea, param.name, param.type, exc
                            )
                        )
                        raise

                    arg.name = param.name
                    func_data.push_back(arg)

                tif.create_func(func_data)
                ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def update_static_member(self, static_member, struct):
                # type: (DefinedStructStaticMember, DefinedStruct) -> None
                ea = self.search_binary(
                    0, static_member.signature, ida_search.SEARCH_DOWN
                )
                if ea == idc.BADADDR:
                    print(
                        "Error: {0} not found something is wrong".format(
                            static_member.signature
                        )
                    )
                    return
                for follows in static_member.relative_offsets:
                    ea = ea + follows
                    ea = ea + 4 + self.get_dword(ea)
                tif = ida_typeinf.tinfo_t()
                ida_typeinf.guess_tinfo(tif, ea)
                return_type = static_member.return_type
                if static_member.is_pointer:
                    return_type = return_type + "*"
                ida_typeinf.apply_tinfo(
                    ea,
                    self.get_tinfo_from_type(return_type),
                    ida_typeinf.TINFO_DEFINITE,
                )
                if static_member.is_pointer:
                    ida_name.set_name(
                        ea,
                        "g_{0}_{1}".format(self.clean_name(struct.type), "PtrInstance"),
                    )
                else:
                    ida_name.set_name(
                        ea, "g_{0}_{1}".format(self.clean_name(struct.type), "Instance")
                    )

            def should_update_member_func(self):
                return (
                    ida_kernwin.ask_yn(
                        ida_kernwin.ASKBTN_YES, "Update member function types?"
                    )
                    == ida_kernwin.ASKBTN_YES
                )

            def should_update_virt_func(self):
                return (
                    ida_kernwin.ask_yn(
                        ida_kernwin.ASKBTN_YES, "Update virtual function types?"
                    )
                    == ida_kernwin.ASKBTN_YES
                )

        api = IdaApi()
        if not api.validate_name_cfg():
            ida_kernwin.warning(
                "Type name validation failed.\n"
                "\n"
                "Your IDA.cfg is missing necessary NameChars and TypeNameChars.\n"
                "\n"
                "Please see https://github.com/aers/FFXIVClientStructs/blob/main/ida/idauser.cfg to update your config accordingly.")
            exit()

if api is None:
    try:
        import ghidra
        import re

        try:
            from ghidra.ghidra_builtins import *
        except ImportError:
            pass

        from yaml import SafeLoader as Loader

        from ghidra.program.model.data import *
        from ghidra.program.model.listing import *
        from ghidra.program.model.symbol import SourceType
        from ghidra.app.util import SymbolPathParser
        from java.util import ArrayList

    except ImportError:
        print("Warning: Unable to load Ghidra")
    else:
        # noinspection PyUnresolvedReferences

        class GhidraApi(BaseApi):
            def can_run(self):
                return True
            
            def get_size_from_type(self, name):
                # type: (str) -> int
                dt = self.get_datatype(name)
                if dt is not None:
                    return dt.getLength()
                return 0

            def fix_generic_name(self, name):
                # type: (str) -> str
                if "<" not in name:
                    return name
                for match in re.finditer(r"unsigned _*[\w*]{3,}|[:\w*]{3,}", name):
                    tn = self.get_ghidra_type(
                        SymbolPathParser.parse(match.group(0)).getLast()
                    )
                    name = name.replace(match.group(0), tn)
                return name

            def get_ghidra_type(self, name):
                # type: (str) -> str
                if name == "__int8":
                    return "char"
                elif name == "__int16":
                    return "short"
                elif name == "__int64":
                    return "longlong"
                elif name == "unsigned __int16":
                    return "ushort"
                elif name == "unsigned int":
                    return "uint"
                elif name == "unsigned __int64":
                    return "ulonglong"
                elif name == "__int8*":
                    return "char*"
                elif name == "__int16*":
                    return "short*"
                elif name == "__int64*":
                    return "longlong*"
                elif name == "unsigned __int16*":
                    return "ushort*"
                elif name == "unsigned int*":
                    return "uint*"
                elif name == "unsigned __int64*":
                    return "ulonglong*"
                elif name == "__fastcall":
                    return "void*"
                return name

            def get_category_path(self, typename):
                # type: (str) -> CategoryPath
                syms = SymbolPathParser.parse(typename)
                return CategoryPath("/" + "/".join(syms.subList(0, syms.size() - 1)))

            def get_datatype(self, typename):
                # type: (str) -> DataType
                raw_type = self.get_ghidra_type(typename)
                if not raw_type:
                    return raw_type
                typename = raw_type.rstrip("*")
                pointer_count = len(raw_type) - len(typename)

                syms = SymbolPathParser.parse(typename)
                syms[-1] = self.fix_generic_name(syms.getLast())

                dtm = currentProgram.getDataTypeManager()
                dt = dtm.getDataType("/" + "/".join(syms))
                for i in range(pointer_count):
                    dt = dtm.getPointer(dt)
                return dt

            def create_datatype(self, datatype):
                # type: (DataType) -> DataType
                dtm = currentProgram.getDataTypeManager()
                old = dtm.getDataType(datatype.getDataTypePath())
                if old is not None:
                    old.replaceWith(datatype)
                    return old
                else:
                    return dtm.addDataType(datatype, None)

            def create_function_def(self, func):
                # type: (DefinedStructVFunc) -> FunctionDefinitionDataType
                fd = FunctionDefinitionDataType(func.name)
                return_type = self.get_datatype(func.return_type)
                fd.setReturnType(return_type)
                args = []
                for arg in func.parameters:
                    arg_type = self.get_datatype(arg.type)
                    ad = ParameterDefinitionImpl(arg.name, arg_type, None)
                    args.append(ad)
                fd.setArguments(args)
                return fd

            def get_func_by_name(self, name):
                # type: (str) -> Function
                funcs = getGlobalFunctions(name)
                return funcs.first if not funcs.size() == 0 else None

            def create_memberfunc_args(self, member_func):
                # type: (DefinedStructMemFunc) -> ArrayList
                arg_vars = ArrayList()
                for param in member_func.parameters:
                    dt = self.get_datatype(param.type)
                    if not dt:
                        return ArrayList()
                    arg_vars.add(ParameterImpl(param.name, dt, currentProgram))
                return arg_vars

            @property
            def get_file_path(self):
                return os.path.join(
                    os.path.dirname(str(sourceFile)), "ffxiv_structs.yml"
                )

            def create_enum_struct(self, enum):
                # type: (DefinedStructEnum) -> None
                if monitor.isCancelled():
                    return
                enum_size = self.get_size_from_type(enum.underlying) or 4
                dt = EnumDataType(enum.name, enum_size)
                dt.setCategoryPath(self.get_category_path(enum.type))
                for value in enum.values:
                    if not dt.contains(enum.values[value]):
                        dt.add(value, enum.values[value])
                self.create_datatype(dt)

            def delete_enum(self, enum):
                # type: (DefinedStructEnum) -> None
                pass

            def delete_struct(self, struct):
                # type: (DefinedStruct) -> None
                pass

            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                if monitor.isCancelled():
                    return

                name = struct.name
                syms = SymbolPathParser.parse(struct.type)
                if syms.size() > 0:
                    name = syms.getLast()

                name = self.fix_generic_name(name)
                if struct.union:
                    dt = UnionDataType(name)
                else:
                    dt = StructureDataType(name, struct.size or 0)
                dt.setCategoryPath(self.get_category_path(struct.type))
                self.create_datatype(dt)

            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                dt = self.get_datatype(struct.type)
                if dt is None:
                    return

                struct.fields.sort(key=lambda fld: fld.offset)
                dtsize = dt.getLength() if not dt.isZeroLength() else 0
                if (
                    dtsize == 0
                    and struct.virtual_functions is not None
                    and not struct.union
                ):
                    dt.growStructure(8)

                for field in struct.fields:
                    if monitor.isCancelled():
                        return

                    offset = field.offset
                    dtsize = dt.getLength() if not dt.isZeroLength() else 0

                    ft = self.get_datatype(field.type)
                    if ft is None:
                        continue

                    if isinstance(field, DefinedStructFixedField):
                        ft = ArrayDataType(ft, int(field.size), ft.getLength() or -1)

                    if not struct.union:
                        if dtsize <= offset and not struct.size:
                            dt.growStructure(((offset - dtsize) or 0) + ft.getLength())

                        if (
                            dt.getLength() <= offset
                            or dt.getLength() < offset + ft.getLength()
                        ):
                            print(
                                f"Field {field.name} (off=0x{offset:X} size=0x{ft.getLength():X}) not within Struct {dt.getDataTypePath()} (size=0x{dt.getLength():X})"
                            )
                            break

                        dt.replaceAtOffset(offset, ft, -1, field.name, "")
                    else:
                        dt.add(ft, ft.getLength(), field.name, "")

            def create_vtable(self, struct):
                # type: (DefinedStruct) -> None
                if monitor.isCancelled():
                    return
                dtm = currentProgram.getDataTypeManager()
                dt = self.get_datatype(struct.type)

                struct.virtual_functions.sort(key=lambda fn: fn.offset)
                vt_type = StructureDataType("VTable", 0)
                vt_type.setCategoryPath(
                    CategoryPath(dt.getCategoryPath(), [dt.getName()])
                )
                vt_type = self.create_datatype(vt_type)
                if struct.fields != [] and struct.fields[0].offset == 0:
                    u_type = UnionDataType("Union")
                    u_type.setCategoryPath(
                        CategoryPath(dt.getCategoryPath(), [dt.getName()])
                    )
                    u_type.add(dtm.getPointer(vt_type), -1, "VTable", "")
                    comp = dt.getComponentContaining(0)
                    if comp and not Undefined.isUndefined(comp.getDataType()):
                        u_type.add(
                            comp.getDataType(), -1, comp.getFieldName(), "parent class"
                        )
                    self.create_datatype(u_type)

                void_ptr = dtm.getPointer(VoidDataType.dataType)
                for func in struct.virtual_functions:
                    if func.return_type and func.parameters:
                        func_def = self.create_function_def(func)
                        func_def.setCategoryPath(
                            CategoryPath(vt_type.getCategoryPath(), [vt_type.getName()])
                        )
                        vt_type.insertAtOffset(
                            func.offset,
                            dtm.getPointer(func_def),
                            -1,
                            func.name,
                            f"vf{int(func.offset / 8)}",
                        )
                    else:
                        dtc = vt_type.getComponentAt(func.offset)
                        if dtc and Undefined.isUndefined(dtc.getDataType()):
                            vt_type.replaceAtOffset(
                                func.offset,
                                void_ptr,
                                -1,
                                func.name,
                                f"vf{int(func.offset / 8)}",
                            )
                        else:
                            vt_type.insertAtOffset(
                                func.offset,
                                void_ptr,
                                -1,
                                func.name,
                                f"vf{int(func.offset / 8)}",
                            )
                
                if struct.vtable_size:
                    vt_size = struct.vtable_size
                    vt_type.setLength(vt_size)
                else:
                    vt_size = struct.virtual_functions[-1].offset
                for offset in range(0, vt_size, 8):
                    dtc = vt_type.getComponentContaining(offset)
                    if not dtc or Undefined.isUndefined(dtc.getDataType()):
                        vt_type.replaceAtOffset(
                            offset, void_ptr, -1, f"vf{int(offset / 8)}", None
                        )

            def finalise_struct(self, struct):
                return

            def create_union(self, struct):
                # type: (DefinedStruct) -> None
                if monitor.isCancelled() or not struct.virtual_functions:
                    return

                dtm = currentProgram.getDataTypeManager()
                void_ptr = dtm.getPointer(VoidDataType.dataType)
                dt = self.get_datatype(struct.type)
                u_type = self.get_datatype(struct.type + "::Union")
                vt_type = self.get_datatype(struct.type + "::VTable")

                if vt_type:
                    dtc = dt.getComponentContaining(0)
                    while dtc and not Undefined.isUndefined(dtc.getDataType()):
                        if monitor.isCancelled():
                            return
                        parent = dtc.getDataType()
                        parent_vt = dtm.getDataType(
                            CategoryPath(parent.getCategoryPath(), [parent.getName()]),
                            "VTable",
                        )
                        if parent_vt:
                            if parent_vt.getLength() > vt_type.getLength():
                                vt_type.replaceWith(parent_vt)
                            else:
                                for c in parent_vt.getComponents():
                                    if (
                                        vt_type.getComponentContaining(c.getOffset())
                                        .getDataType()
                                        .equals(void_ptr)
                                    ):
                                        vt_type.replaceAtOffset(
                                            c.getOffset(),
                                            c.getDataType(),
                                            -1,
                                            c.getFieldName(),
                                            c.getComment(),
                                        )
                            dtc = parent_vt.getComponentContaining(0)
                        else:
                            break

                if u_type and struct.fields != [] and struct.fields[0].offset == 0:
                    dt.replaceAtOffset(
                        0, u_type, -1, "Union", "vtable and parent union"
                    )
                elif vt_type:
                    dt.replaceAtOffset(0, dtm.getPointer(vt_type), -1, "VTable", "")

            def update_member_func(self, member_func, struct):
                # type: (DefinedStructMemFunc, DefinedStruct) -> None
                if monitor.isCancelled():
                    return
                if not member_func.parameters:
                    return
                func_name = f"{struct.type}.{member_func.name}"
                func = self.get_func_by_name(func_name)
                if not func:
                    return
                arg_vars = self.create_memberfunc_args(member_func)
                return_type = self.get_datatype(member_func.return_type)
                if not return_type:
                    return
                return_var = ReturnParameterImpl(return_type, currentProgram)
                update_type = Function.FunctionUpdateType.DYNAMIC_STORAGE_ALL_PARAMS
                func.updateFunction(
                    "__fastcall",
                    return_var,
                    arg_vars,
                    update_type,
                    False,
                    SourceType.USER_DEFINED,
                )

            def update_virt_func(self, virt_func, struct):
                # type: (DefinedStructVFunc, DefinedStruct) -> None
                if monitor.isCancelled():
                    return
                func_name = f"{struct.type}.{virt_func.name}"
                func = self.get_func_by_name(func_name)
                if not func:
                    return
                arg_vars = self.create_memberfunc_args(virt_func)
                return_type = self.get_datatype(virt_func.return_type)
                if not return_type:
                    return
                return_var = ReturnParameterImpl(return_type, currentProgram)
                update_type = Function.FunctionUpdateType.DYNAMIC_STORAGE_ALL_PARAMS
                func.updateFunction(
                    "__fastcall",
                    return_var,
                    arg_vars,
                    update_type,
                    False,
                    SourceType.USER_DEFINED,
                )

            def update_static_member(self, static_member, struct):
                # type: (DefinedStructStaticMember, DefinedStruct) -> None
                pass

            def should_update_member_func(self):
                # type: () -> bool
                return askYesNo("ffxiv_structimporter", "Update member function types?")

            def should_update_virt_func(self):
                # type: () -> bool
                return askYesNo(
                    "ffxiv_structimporter", "Update virtual function types?"
                )

            def preprocess_yaml(self, yaml: DefinedStructExport):
                return
            
        api = GhidraApi()


if api is None:
    raise Exception("Unable to load API (supported: IDA, Ghidra, Binary Ninja)")

start_time = time()


def get_time():
    val = round(time() - start_time, 6).__str__()
    while val.split(".")[-1].__len__() < 6:
        val += "0"
    return val

def run():
    if not api.can_run():
        raise RuntimeError("This script depends on exdgetters. Run that script before retrying")
    
    update_virt_func = api.should_update_virt_func()
    update_member_func = api.should_update_member_func()

    print("{0} Loading yaml".format(get_time()))
    yaml = api.get_yaml()
    
    print("{0} Loading data yaml".format(get_time()))
    api.data_yaml = api.load_data_yaml()

    if isinstance(api, IdaApi):
        print("{0} Generating src file in memory".format(get_time()))
        src_interface = SrcInterface()
        header, vtables = src_interface.build_export_string(yaml)

        predef_header = """#define _HAS_ITERATOR_DEBUGGING 0
#define _ITERATOR_DEBUG_LEVEL 0
#include <vector>
#include <set>
#include <map>
#include <string>
#include <list>
#include <deque>
#include <cstdint>

"""

        print("{0} Importing src file".format(get_time()))
        api.select_parser()
        api.parse_string(predef_header + header, vtables)
    else:
        print("{0} Deleting old structs".format(get_time()))
        for struct in yaml.structs[::-1]:
            api.delete_struct(struct)

        print("{0} Deleting old enums and creating new ones".format(get_time()))
        for enum in yaml.enums:
            api.delete_enum(enum)
        
        for enum in yaml.enums:
            api.create_enum_struct(enum)

        print("{0} Creating new structs".format(get_time()))
        for struct in yaml.structs:
            api.create_struct(struct)

        print("{0} Creating members for structs".format(get_time()))
        for struct in yaml.structs:
            api.create_struct_members(struct)

        print("{0} Finalising structs".format(get_time()))
        for struct in yaml.structs:
            api.finalise_struct(struct)

        print("{0} Creating vtables for structs".format(get_time()))
        for struct in yaml.structs:
            if struct.virtual_functions:
                api.create_vtable(struct)

        print("{0} Mapping unions/vtables for structs".format(get_time()))
        for struct in yaml.structs:
            api.create_union(struct)

    if update_virt_func:
        for struct in yaml.structs:
            if struct.virtual_functions:
                print(
                    "{0} Updating virtual functions for {1}".format(
                        get_time(), struct.type
                    )
                )
                for virt_func in struct.virtual_functions:
                    if virt_func is None:
                        continue

                    if virt_func.return_type != None and virt_func.parameters != None:
                        api.update_virt_func(virt_func, struct)

    if update_member_func:
        for struct in yaml.structs:
            if struct.member_functions != []:
                print(
                    "{0} Updating member functions for {1}".format(
                        get_time(), struct.type
                    )
                )
                for member_func in struct.member_functions:
                    api.update_member_func(member_func, struct)

            if struct.static_member_functions:
                print(
                    "{0} Updating static member functions for {1}".format(
                        get_time(), struct.type
                    )
                )
                for member_func in struct.static_member_functions:
                    api.update_member_func(member_func, struct)

            if struct.static_members:
                print(
                    "{0} Updating static members for {1}".format(
                        get_time(), struct.type
                    )
                )
                for member in struct.static_members:
                    api.update_static_member(member, struct)

run()

# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_structimport
# @runtime Jython

from yaml import load

try:
    from yaml import CSafeLoader as Loader
except ImportError:
    from yaml import SafeLoader as Loader

import os
from abc import abstractmethod
from time import time
from data_schema import *


class BaseApi:
    @abstractmethod
    def create_enum_struct(self, enum):
        # type: (DefinedEnum) -> None
        """
        Create an enum in the database.
        """

    @abstractmethod
    def delete_enum(self, enum):
        # type: (DefinedEnum) -> None
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
    def create_union(self, struct):
        # type: (DefinedStruct) -> None
        """
        Create a union in the database.
        """

    @abstractmethod
    def update_member_func(self, member_func, struct):
        # type: (DefinedMemFunc, DefinedStruct) -> None
        """
        Updates a member function in the database.
        """

    @abstractmethod
    def update_virt_func(self, virt_func, struct):
        # type: (DefinedVFunc, DefinedStruct) -> None
        """
        Updates a virtual function in the database.
        """

    @abstractmethod
    def update_static_member(self, static_member, struct):
        # type: (DefinedStaticMember, DefinedStruct) -> None
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
        # type: () -> DefinedExport
        dic = load(
            open(self.get_file_path), Loader=Loader
        )  # type: dict[str, dict[str, list[dict[str, str | int | list[dict[str, str | int]]]]]]
        enums = []
        structs = []
        for enum in dic["enums"]:
            enums.append(
                DefinedEnum(
                    enum["name"],
                    enum["type"],
                    enum["underlying"],
                    enum["namespace"],
                    enum["flags"],
                    enum["values"],
                )
            )
        for struct in dic["structs"]:
            fields = []
            virtual_functions = None
            member_functions = []
            static_member_functions = None
            static_members = None
            for field in struct["fields"]:
                base = field["base"] if "base" in field else False
                if "size" in field:
                    fields.append(
                        DefinedFixedField(
                            field["name"],
                            field["type"],
                            field["offset"],
                            base,
                            field["size"],
                        )
                    )
                elif "return_type" in field:
                    parameters = []
                    for param in field["parameters"]:
                        parameters.append(
                            DefinedFuncParam(param["name"], param["type"])
                        )
                    fields.append(
                        DefinedFuncField(
                            field["name"],
                            field["type"],
                            field["offset"],
                            base,
                            field["return_type"],
                            parameters,
                        )
                    )
                else:
                    fields.append(
                        DefinedField(
                            field["name"], field["type"], field["offset"], base
                        )
                    )
            if "virtual_functions" in struct:
                virtual_functions = []
                for vfunc in struct["virtual_functions"]:
                    parameters = (
                        [
                            DefinedFuncParam(param["name"], param["type"])
                            for param in vfunc["parameters"]
                        ]
                        if "parameters" in vfunc
                        else None
                    )
                    virtual_functions.append(
                        DefinedVFunc(
                            vfunc["name"],
                            vfunc["return_type"] if "return_type" in vfunc else None,
                            vfunc["offset"],
                            parameters,
                        )
                    )
            for memfunc in struct["member_functions"]:
                parameters = []
                for param in memfunc["parameters"]:
                    parameters.append(DefinedFuncParam(param["name"], param["type"]))
                member_functions.append(
                    DefinedMemFunc(
                        memfunc["signature"],
                        memfunc["return_type"],
                        parameters,
                        memfunc["name"],
                    )
                )
            if "static_member_functions" in struct:
                static_member_functions = []
                for smemfunc in struct["static_member_functions"]:
                    parameters = []
                    for param in smemfunc["parameters"]:
                        parameters.append(
                            DefinedFuncParam(param["name"], param["type"])
                        )
                    static_member_functions.append(
                        DefinedMemFunc(
                            smemfunc["signature"],
                            smemfunc["return_type"],
                            parameters,
                            smemfunc["name"],
                        )
                    )
            if "static_members" in struct:
                static_members = []
                for sm in struct["static_members"]:
                    static_members.append(
                        DefinedStaticMember(
                            sm["signature"],
                            sm["relative_follow_offsets"],
                            sm["return_type"],
                            sm["is_pointer"] if "is_pointer" in sm else False,
                        )
                    )
            size = None
            if "size" in struct:
                size = struct["size"]
            vtable_size = None
            if "vtable_size" in struct:
                vtable_size = struct["vtable_size"]
            structs.append(
                DefinedStruct(
                    struct["name"],
                    struct["type"],
                    struct["namespace"],
                    fields,
                    size,
                    vtable_size,
                    virtual_functions,
                    member_functions,
                    struct["union"],
                    static_member_functions,
                    static_members,
                )
            )
        return DefinedExport(enums, structs)


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
        from ida_wrapper import IdaInterface
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi, IdaInterface):
            def __init__(self, full_padding):
                # type: (bool) -> None
                self.full_padding = full_padding

            def delete_struct_members(self, fullname):
                # type: (str) -> None
                self.remove_struct_members(self.get_struct_id(fullname))

            def delete_enum_members(self, enum):
                # type: (DefinedEnum) -> None
                e = self.get_enum_id(enum.type)
                for value in enum.values:
                    self.remove_enum_member(e, value, enum.name)

            @property
            def get_file_path(self):
                return os.path.join(
                    os.path.dirname(os.path.realpath(__file__)), "ffxiv_structs.yml"
                )

            def create_enum_struct(self, enum):
                # type: (DefinedEnum) -> None
                fullname = enum.type
                self.create_enum(fullname)
                e = self.get_enum_id(fullname)
                self.set_enum_width(e, self.get_size_from_ida_type(enum.underlying))
                if self.is_signed(enum.underlying):
                    self.set_enum_flag(e, 0x20000)
                if enum.flags:
                    self.set_enum_as_bf(e)
                for value in enum.values:
                    self.add_enum_member(
                        e, "{0}.{1}".format(enum.name, value), enum.values[value]
                    )

            def delete_enum(self, enum):
                # type: (DefinedEnum) -> None
                self.delete_enum_members(enum)

            def delete_struct(self, struct):
                # type: (DefinedStruct) -> None
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                fullname = self.clean_struct_name(struct.type)
                self.delete_struct_members(fullname)
                self.delete_struct_members(fullname + "_vtbl")
                idaapi.end_type_updating(idaapi.UTP_STRUCT)

            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_struct_name(struct.type)
                if self.get_struct_id(fullname) == idaapi.BADADDR:
                    self.create_struct_type(fullname, struct.union)
                if struct.virtual_functions:
                    self.create_struct_type(fullname + "_vtbl")

            def create_struct_member_fill(self, struct_name, offset):
                # type: (str, int) -> None
                s = self.get_struct(self.get_struct_id(struct_name))
                prev_size = self.get_struct_size(s)
                if self.full_padding:
                    flag = self.get_idc_type_from_size(prev_size)
                    size = self.get_size_from_idc_type(flag)
                    if size > offset - prev_size:
                        flag = self.get_idc_type_from_size(
                            offset - prev_size, prev_size
                        )
                        size = self.get_size_from_idc_type(flag)

                    self.create_struct_member(
                        s, "field_{0:X}".format(prev_size), prev_size, flag, None, size
                    )
                else:
                    self.create_struct_member(
                        s,
                        "field_{0:X}".format(prev_size),
                        prev_size,
                        ida_bytes.byte_flag(),
                        None,
                        offset - prev_size,
                    )

            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                fullname = self.clean_struct_name(struct.type)
                s = self.get_struct(self.get_struct_id(fullname))

                if struct.virtual_functions != None and (
                    struct.fields == [] or struct.fields[0].offset > 0
                ):
                    self.create_struct_member(
                        s, "__vftable", 0, ida_bytes.qword_flag(), None, 8
                    )
                    type = fullname + "_vtbl*" if struct.virtual_functions else "void**"
                    meminfo = self.get_struct_member_by_name(s, "__vftable")
                    self.set_struct_member_info(
                        s, meminfo, 0, self.get_tinfo_from_type(type), 0
                    )

                contiguous_fields = True
                for field in struct.fields:
                    offset = field.offset

                    prev_size = self.get_struct_size(s)
                    while offset > prev_size:
                        contiguous_fields = False
                        self.create_struct_member_fill(fullname, offset)
                        prev_size = self.get_struct_size(s)

                    field_is_base = field.base and contiguous_fields
                    field_name = (
                        field.name
                        if not field_is_base
                        else "baseclass_{0:X}".format(offset)
                    )
                    field_type = self.clean_name(field.type)
                    if field_type == "__fastcall":
                        self.create_struct_member(
                            s,
                            field_name,
                            offset,
                            self.get_idc_type_from_ida_type("__int64"),
                            None,
                            self.get_size_from_ida_type("__int64"),
                        )
                        field_type = self.clean_name(field.return_type)
                        field_type = field_type + "(__fastcall* " + field_name + ")("
                        for param in field.parameters:
                            field_type = field_type + self.clean_name(param.type) + ""
                            field_type = field_type + param.name + ","
                        field_type = field_type[:-2] + ")"
                    elif (
                        self.get_idc_type_from_ida_type(
                            self.clean_struct_name(field_type)
                        )
                        == self.get_struct_flag()
                    ):
                        field_type = self.clean_struct_name(field_type)
                        self.create_struct_member(
                            s,
                            field_name,
                            offset,
                            self.get_idc_type_from_ida_type(field_type),
                            self.get_struct_opinfo_from_type(field_type),
                            self.get_size_from_ida_type(field_type),
                        )
                    elif (
                        self.get_idc_type_from_ida_type(field_type)
                        == self.get_enum_flag()
                    ):
                        self.create_struct_member(
                            s,
                            field_name,
                            offset,
                            self.get_idc_type_from_ida_type(field_type),
                            self.get_enum_opinfo_from_type(field_type),
                            self.get_size_from_ida_type(field_type),
                        )
                    else:
                        self.create_struct_member(
                            s,
                            field_name,
                            offset,
                            self.get_idc_type_from_ida_type(field_type),
                            None,
                            self.get_size_from_ida_type(field_type),
                        )
                    meminfo = self.get_struct_member_by_name(s, field_name)
                    if field_is_base:
                        meminfo.props |= self.get_base_class_flag()
                    array_size = field.size if hasattr(field, "size") else 0
                    self.set_struct_member_info(
                        s,
                        meminfo,
                        0,
                        self.get_tinfo_from_type(field_type, array_size),
                        0,
                    )

                if struct.size is not None and struct.size != 0:
                    prev_size = self.get_struct_size(s)
                    while struct.size > prev_size:
                        self.create_struct_member_fill(fullname, struct.size)
                        prev_size = self.get_struct_size(s)

                idaapi.end_type_updating(idaapi.UTP_STRUCT)

            def create_vtable(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_name(struct.type)
                s = self.get_struct(self.get_struct_id(fullname + "_vtbl"))
                for virt_func in struct.virtual_functions:
                    offset = virt_func.offset
                    field_name = virt_func.name
                    self.create_struct_member(
                        s,
                        field_name,
                        offset,
                        self.get_idc_type_from_ida_type("__int64"),
                        None,
                        self.get_size_from_ida_type("__int64"),
                    )
                    if virt_func.return_type == None or virt_func.parameters == None:
                        continue

                    meminfo = self.get_struct_member_by_name(s, field_name)
                    field_type = self.clean_name(virt_func.return_type)
                    field_type = field_type + "(__fastcall* " + field_name + ")("
                    for param in virt_func.parameters:
                        field_type = field_type + self.clean_name(param.type) + " "
                        field_type = field_type + param.name + ","
                    field_type = field_type[:-1] + ")"

                    self.set_struct_member_info(
                        s, meminfo, 0, self.get_tinfo_from_type(field_type), 0
                    )
                if struct.vtable_size:
                    size = int(struct.vtable_size / 8)
                else:
                    size = int(self.get_struct_size(s) / 8)
                for i in range(size):
                    if self.get_struct_member_id(s, i * 8) == idc.BADADDR:
                        self.create_struct_member(
                            s,
                            "vf{0}".format(i),
                            i * 8,
                            self.get_idc_type_from_ida_type("__int64"),
                            None,
                            self.get_size_from_ida_type("__int64"),
                        )
                        meminfo = self.get_struct_member_by_name(s, "vf{0}".format(i))
                        self.set_struct_member_info(
                            s, meminfo, 0, self.get_tinfo_from_type("__int64"), 0
                        )

            def create_union(self, struct):
                # type: (DefinedStruct) -> None
                pass

            def update_member_func(self, member_func, struct):
                # type: (DefinedMemFunc, DefinedStruct) -> None
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
                    arg.type = self.get_tinfo_from_type(param.type)
                    arg.name = param.name
                    func_data.push_back(arg)
                tif.create_func(func_data)
                ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def update_virt_func(self, virt_func, struct):
                # type: (DefinedVFunc, DefinedStruct) -> None
                func_name = "{0}.{1}".format(
                    self.clean_name(struct.type), virt_func.name
                )
                ea = self.get_func_ea_by_name(func_name)
                if ea == idc.BADADDR:
                    print("Error: {0} not found using base?".format(func_name))
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
                    arg.type = self.get_tinfo_from_type(param.type)
                    arg.name = param.name
                    func_data.push_back(arg)
                tif.create_func(func_data)
                ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def update_static_member(self, static_member, struct):
                # type: (DefinedStaticMember, DefinedStruct) -> None
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

        full_padding = (
            ida_kernwin.ask_buttons(
                "Full Padding",
                "Array Padding",
                "",
                ida_kernwin.ASKBTN_YES,
                "HIDECANCEL\nWhat padding style to use?\n\nFull Padding: Adds padding based on allignment of 1,2,4,8\nArray Padding: Adds padding based on the size between fields with byte arrays\n\nFull Padding will take longer to add padding between fields but is recommended for quick struct modifications.",
            )
            == ida_kernwin.ASKBTN_YES
        )
        api = IdaApi(full_padding)


if api is None:
    try:
        import ghidra
        import re

        try:
            from ghidra.ghidra_builtins import *
        except ImportError:
            pass

        from ghidra.program.model.data import *
        from ghidra.program.model.listing import *
        from ghidra.program.model.symbol import SourceType
        from ghidra.app.util import SymbolPathParser

    except ImportError:
        print("Warning: Unable to load Ghidra")
    else:
        # noinspection PyUnresolvedReferences

        class GhidraApi(BaseApi):
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
                    return "sbyte"
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
                # type: (DefinedVFunc) -> FunctionDefinitionDataType
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
                # type: (DefinedMemFunc) -> list[ParameterImpl]
                arg_vars = []
                for param in member_func.parameters:
                    dt = self.get_datatype(param.type)
                    if not dt:
                        return []
                    arg_vars.append(ParameterImpl(param.name, dt, currentProgram))
                return arg_vars

            @property
            def get_file_path(self):
                return os.path.join(
                    os.path.dirname(str(sourceFile)), "ffxiv_structs.yml"
                )

            def create_enum_struct(self, enum):
                # type: (DefinedEnum) -> None
                if monitor.isCancelled():
                    return
                enum_size = self.get_size_from_type(enum.underlying) or 4
                dt = EnumDataType(enum.name, enum_size)
                dt.setCategoryPath(self.get_category_path(enum.type))
                for value in enum.values:
                    dt.add(value, enum.values[value])
                self.create_datatype(dt)

            def delete_enum(self, enum):
                # type: (DefinedEnum) -> None
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

                    if isinstance(field, DefinedFixedField):
                        ft = ArrayDataType(ft, int(field.size), ft.getLength() or -1)

                    if not struct.union:
                        if dtsize <= offset and not struct.size:
                            dt.growStructure(((offset - dtsize) or 0) + ft.getLength())

                        if (
                            dt.getLength() <= offset
                            or dt.getLength() < offset + ft.getLength()
                        ):
                            print(
                                "Field {0} (off=0x{1:X} size=0x{2:X}) not within Struct {3} (size=0x{4:X})".format(
                                    field.name,
                                    offset,
                                    ft.getLength(),
                                    dt.getDataTypePath(),
                                    dt.getLength(),
                                )
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
                            "vf{0}".format(func.offset / 8),
                        )
                    else:
                        dtc = vt_type.getComponentAt(func.offset)
                        if dtc and Undefined.isUndefined(dtc.getDataType()):
                            vt_type.replaceAtOffset(
                                func.offset,
                                void_ptr,
                                -1,
                                func.name,
                                "vf{0}".format(func.offset / 8),
                            )
                        else:
                            vt_type.insertAtOffset(
                                func.offset,
                                void_ptr,
                                -1,
                                func.name,
                                "vf{0}".format(func.offset / 8),
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
                            offset, void_ptr, -1, "vf{0}".format(offset / 8), None
                        )

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
                # type: (DefinedMemFunc, DefinedStruct) -> None
                if monitor.isCancelled():
                    return
                if not member_func.parameters:
                    return
                func_name = "{0}.{1}".format(struct.type, member_func.name)
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
                # type: (DefinedVFunc, DefinedStruct) -> None
                if monitor.isCancelled():
                    return
                func_name = "{0}.{1}".format(struct.type, virt_func.name)
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
                # type: (DefinedStaticMember, DefinedStruct) -> None
                pass

            def should_update_member_func(self):
                # type: () -> bool
                return askYesNo("ffxiv_structimporter", "Update member function types?")

            def should_update_virt_func(self):
                # type: () -> bool
                return askYesNo(
                    "ffxiv_structimporter", "Update virtual function types?"
                )

        api = GhidraApi()

if api is None:
    try:
        import binaryninja
        import struct
    except ImportError:
        print("Warning: Unable to load Binary Ninja")
    else:
        # TODO: VTables, Unions
        class BinjaApi(BaseApi):
            def get_binja_type(self, name):
                # type: (str) -> str
                lookup = {
                    "__int8": "int8_t",
                    "__int16": "int16_t",
                    "__int32": "int32_t",
                    "__int64": "int64_t",
                    "unsigned __int8": "uint8_t",
                    "unsigned __int16": "uint16_t",
                    "unsigned __int32": "uint32_t",
                    "unsigned __int64": "uint64_t",
                    "unsigned int": "uint32_t",
                    "_DWORD": "uint32_t",
                    "float": "float",
                }
                if name in lookup:
                    return lookup[name]
                else:
                    return name

            def get_type(self, name):
                # type: (str) -> binaryninja.Type
                if name == "__fastcall":
                    return None

                fixed_name = self.get_binja_type(name)

                pointer_count = 0
                while fixed_name.endswith("*"):
                    fixed_name = fixed_name[:-1]
                    pointer_count += 1

                type = None

                try:
                    type = bv.parse_type_string(fixed_name)[0]
                except:
                    # Sometimes it just throws. Dunno why
                    type = bv.types[fixed_name]

                if pointer_count > 0:
                    type = binaryninja.Type.pointer(type=type, arch=bv.arch)

                return type

            def get_size_from_type(self, name):
                # type: (str) -> int
                type_obj = self.get_type(name)
                if type_obj is None:
                    return 4
                return type_obj.width

            @property
            def get_file_path(self):
                # type: () -> str
                return os.path.join(os.path.dirname(__file__), "ffxiv_structs.yml")

            def create_enum_struct(self, enum):
                # type: (DefinedEnum) -> None
                members = []
                for value in enum.values:
                    members.append((value, enum.values[value]))
                enum_type = binaryninja.Type.enumeration(
                    members=members, width=self.get_size_from_type(enum.underlying)
                )
                bv.define_user_type(enum.type, enum_type)

            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                struct_type = binaryninja.Type.structure(
                    type=binaryninja.StructureVariant.ClassStructureType
                )
                bv.define_user_type(struct.type, struct_type)

            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                struct_type = bv.types[
                    struct.type
                ].mutable_copy()  # type: binaryninja.StructureBuilder

                for field in struct.fields:
                    field_type = self.get_type(field.type)
                    if field_type is None:
                        continue

                    if isinstance(field, DefinedFixedField):
                        field_type = binaryninja.Type.array(field_type, int(field.size))
                    struct_type.add_member_at_offset(
                        field.name,
                        field_type,
                        int(field.offset),
                    )

                bv.define_user_type(struct.type, struct_type)

            def get_func_ea_by_sig(self, pattern):
                # type: (str) -> int
                regex = ""
                for part in pattern.split(" "):
                    if part == "??":
                        regex = regex + "."
                    else:
                        regex = regex + "\\x" + part
                compiled = re.compile(regex.encode("utf-8"))

                for segment in bv.segments:
                    data = bv.read(segment.start, segment.end - segment.start)
                    match = compiled.search(data)
                    if match:
                        match_start = match.start()
                        addr = segment.start + match_start
                        if data[match_start] == 0xE8 or data[match_start] == 0xE9:
                            addr += 5
                            addr += struct.unpack(
                                "<I", data[match_start + 1 : match_start + 5]
                            )[0]
                        return addr

            def update_member_func(self, member_func, struct):
                # type: (DefinedMemFunc, DefinedStruct) -> None
                func_name = "{0}.{1}".format(struct.type, member_func.name)

                func = None
                symbol = bv.get_symbol_by_raw_name(func_name)
                if symbol:
                    func = bv.get_function_at(symbol.address)

                if not func:
                    func_addr = self.get_func_ea_by_sig(member_func.signature)
                    if func_addr is not None:
                        func = bv.get_function_at(func_addr)

                if not func:
                    return

                if member_func.return_type != "void":
                    new_return_type = self.get_type(member_func.return_type)
                    if new_return_type is not None:
                        func.return_type = new_return_type

                for i, param in enumerate(member_func.parameters):
                    if i < len(func.parameter_vars):
                        param_var = func.parameter_vars[i]
                        if param_var is None:
                            continue

                        new_param_type = self.get_type(param.type)
                        if new_param_type is not None:
                            param_var.type = new_param_type
                        param_var.name = param.name

            def update_virt_func(self, virt_func, struct):
                # type: (DefinedVFunc, DefinedStruct) -> None
                func_name = "{0}.{1}".format(struct.type, virt_func.name)

                func = None
                symbol = bv.get_symbol_by_raw_name(func_name)
                if symbol:
                    func = bv.get_function_at(symbol.address)

                if not func:
                    return

                if virt_func.return_type != "void":
                    new_return_type = self.get_type(virt_func.return_type)
                    if new_return_type is not None:
                        func.return_type = new_return_type

                for i, param in enumerate(virt_func.parameters):
                    if i < len(func.parameter_vars):
                        param_var = func.parameter_vars[i]
                        if param_var is None:
                            continue

                        new_param_type = self.get_type(param.type)
                        if new_param_type is not None:
                            param_var.type = new_param_type
                        param_var.name = param.name

            def update_static_member(self, static_member, struct):
                # type: (DefinedStaticMember, DefinedStruct) -> None
                pass

            def should_update_member_func(self):
                # type: () -> bool
                return (
                    binaryninja.get_choice_input(
                        "Update member function types?",
                        "ffxiv_structimporter",
                        ["Yes", "No"],
                    )
                    == 0
                )

            def should_update_virt_func(self):
                # type: () -> bool
                return (
                    binaryninja.get_choice_input(
                        "Update virtual function types?",
                        "ffxiv_structimporter",
                        ["Yes", "No"],
                    )
                    == 0
                )

        api = BinjaApi()


if api is None:
    raise Exception("Unable to load API (supported: IDA, Ghidra, Binary Ninja)")

start_time = time()


def get_time():
    val = round(time() - start_time, 6).__str__()
    while val.split(".")[-1].__len__() < 6:
        val += "0"
    return val


def run():
    print("{0} Loading yaml".format(get_time()))
    yaml = api.get_yaml()

    print("{0} Deleting old structs".format(get_time()))
    for struct in yaml.structs[::-1]:
        api.delete_struct(struct)

    print("{0} Deleting old enums and creating new ones".format(get_time()))
    for enum in yaml.enums:
        api.delete_enum(enum)
        api.create_enum_struct(enum)

    print("{0} Creating new structs".format(get_time()))
    for struct in yaml.structs:
        api.create_struct(struct)

    print("{0} Creating members for structs".format(get_time()))
    for struct in yaml.structs:
        api.create_struct_members(struct)

    print("{0} Creating vtables for structs".format(get_time()))
    for struct in yaml.structs:
        if struct.virtual_functions:
            api.create_vtable(struct)

    print("{0} Mapping unions/vtables for structs".format(get_time()))
    for struct in yaml.structs:
        api.create_union(struct)

    if api.should_update_virt_func():
        for struct in yaml.structs:
            if struct.virtual_functions:
                print(
                    "{0} Updating virtual functions for {1}".format(
                        get_time(), struct.type
                    )
                )
                for virt_func in struct.virtual_functions:
                    if virt_func.return_type != None and virt_func.parameters != None:
                        api.update_virt_func(virt_func, struct)

    if api.should_update_member_func():
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

# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_structimport

from yaml import safe_load
import os
from abc import abstractmethod
from time import time


class DefinedBase:
    def __init__(self, name, type, namespace):
        # type: (str, str, str) -> None
        self.name = name
        self.type = type
        self.namespace = namespace


class DefinedEnum(DefinedBase, object):
    def __init__(self, name, type, underlying, namespace, values):
        # type: (str, str, str, str, dict[str, int]) -> None
        super(DefinedEnum, self).__init__(name, type, namespace)
        self.name = name
        self.type = type
        self.values = values
        self.underlying = underlying


class DefinedFuncParam:
    def __init__(self, name, type):
        # type: (str, str) -> None
        self.name = name
        self.type = type


class DefinedVFunc:
    def __init__(self, name, return_type, offset, parameters):
        # type: (str, str, int, list[DefinedFuncParam]) -> None
        self.name = name
        self.return_type = return_type
        self.offset = offset
        self.parameters = parameters


class DefinedMemFunc:
    def __init__(self, signature, return_type, parameters, name):
        # type: (str, str, list[DefinedFuncParam], str) -> None
        self.signature = signature
        self.return_type = return_type
        self.parameters = parameters
        self.name = name


class DefinedField(DefinedFuncParam, object):
    def __init__(self, name, type, offset, base):
        # type: (str, str, int, bool) -> None
        super(DefinedField, self).__init__(name, type)
        self.offset = offset
        self.base = base


class DefinedFuncField(DefinedField, object):
    def __init__(self, name, type, offset, base, return_type, params):
        # type: (str, str, int, bool, str | None, list[DefinedFuncParam] | None) -> None
        super(DefinedFuncField, self).__init__(name, type, offset, base)
        self.return_type = return_type
        self.parameters = params


class DefinedFixedField(DefinedField, object):
    def __init__(self, name, type, offset, base, size):
        # type: (str, str, int, bool, str | None) -> None
        super(DefinedFixedField, self).__init__(name, type, offset, base)
        self.size = size


class DefinedStruct(DefinedBase, object):
    def __init__(
        self,
        name,
        type,
        namespace,
        fields,
        size,
        virtual_functions,
        member_functions,
        union,
    ):
        # type: (str, str, str, list[DefinedField], int | None, list[DefinedVFunc], list[DefinedMemFunc], str) -> None
        super(DefinedStruct, self).__init__(name, type, namespace)
        self.fields = fields
        self.size = size
        self.virtual_functions = virtual_functions
        self.member_functions = member_functions
        self.union = bool(union)


class DefinedExport:
    def __init__(self, enums, structs):
        # type: (list[DefinedEnum], list[DefinedStruct]) -> None
        self.enums = enums
        self.structs = structs


class BaseApi:
    @abstractmethod
    def create_enum(self, enum):
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
        dic = safe_load(
            open(self.get_file_path)
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
                    enum["values"],
                )
            )
        for struct in dic["structs"]:
            fields = []
            virtual_functions = None
            member_functions = []
            for field in struct["fields"]:
                base = field["base"] if "base" in field else False
                if "size" in field:
                    fields.append(
                        DefinedFixedField(
                            field["name"], field["type"], field["offset"], base, field["size"]
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
                        DefinedField(field["name"], field["type"], field["offset"], base)
                    )
            if "virtual_functions" in struct:
                virtual_functions = []
                for vfunc in struct["virtual_functions"]:
                    parameters = [DefinedFuncParam(param["name"], param["type"]) for param in vfunc["parameters"]] if "parameters" in vfunc else None
                    virtual_functions.append(
                        DefinedVFunc(
                            vfunc["name"], vfunc["return_type"] if "return_type" in vfunc else None, vfunc["offset"], parameters
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
            if "size" in struct:
                structs.append(
                    DefinedStruct(
                        struct["name"],
                        struct["type"],
                        struct["namespace"],
                        fields,
                        struct["size"],
                        virtual_functions,
                        member_functions,
                        struct["union"],
                    )
                )
            else:
                structs.append(
                    DefinedStruct(
                        struct["name"],
                        struct["type"],
                        struct["namespace"],
                        fields,
                        None,
                        virtual_functions,
                        member_functions,
                        struct["union"],
                    )
                )
        return DefinedExport(enums, structs)


api = None

if api is None:
    try:
        import idaapi
        import idc
        import ida_bytes
        import ida_nalt
        import ida_struct
        import ida_enum
        import ida_search
        import ida_ida
        import ida_typeinf
        import ida_funcs
        import ida_name
        import ida_kernwin
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi):
            def get_idc_type_from_ida_type(self, type):
                # type: (str) -> int
                if (
                    type == "unsigned __int8"
                    or type == "__int8"
                    or type == "bool"
                    or type == "char"
                    or type == "unsigned char"
                    or type == "byte"
                ):
                    return ida_bytes.byte_flag()
                elif type == "unsigned __int16" or type == "__int16":
                    return ida_bytes.word_flag()
                elif (
                    type == "unsigned __int32"
                    or type == "__int32"
                    or type == "int"
                    or type == "unsigned int"
                    or type == "_DWORD"
                ):
                    return ida_bytes.dword_flag()
                elif (
                    type == "unsigned __int64"
                    or type == "__int64"
                    or type == "__fastcall"
                    or type.endswith("*")
                ):
                    return ida_bytes.qword_flag()
                elif type == "float":
                    return ida_bytes.float_flag()
                elif ida_struct.get_struc_id(type) == idaapi.BADADDR:
                    return ida_bytes.enum_flag()
                else:
                    return ida_bytes.stru_flag()

            def is_signed(self, type):
                # type: (str) -> bool
                if (
                    type == "__int8"
                    or type == "__int16"
                    or type == "__int32"
                    or type == "__int64"
                    or type == "int"
                    or type == "_DWORD"
                ):
                    return True
                else:
                    return False

            def get_size_from_ida_type(self, type):
                # type: (str) -> int
                if (
                    type == "unsigned __int8"
                    or type == "__int8"
                    or type == "bool"
                    or type == "char"
                    or type == "unsigned char"
                    or type == "byte"
                ):
                    return 1
                elif type == "unsigned __int16" or type == "__int16":
                    return 2
                elif (
                    type == "unsigned __int32"
                    or type == "__int32"
                    or type == "int"
                    or type == "unsigned int"
                    or type == "_DWORD"
                    or type == "float"
                ):
                    return 4
                elif (
                    type == "unsigned __int64"
                    or type == "__int64"
                    or type == "__fastcall"
                    or type.endswith("*")
                ):
                    return 8
                elif ida_struct.get_struc_id(type) == idaapi.BADADDR:
                    return ida_enum.get_enum_width(ida_enum.get_enum(type))
                else:
                    return ida_struct.get_struc_size(ida_struct.get_struc_id(type))

            def get_named_type(self, name):
                # type: (str) -> idaapi.tinfo_t
                tinfo = ida_typeinf.tinfo_t()
                if (
                    ida_struct.get_struc_id(self.clean_struct_name(name))
                    != idaapi.BADADDR
                ):
                    if not tinfo.get_named_type(idaapi.get_idati(), name):
                        tinfo.get_named_type(
                            idaapi.get_idati(), self.clean_struct_name(name)
                        )
                        return tinfo
                    
                if name == "void":
                    idaapi.parse_decl(tinfo, idaapi.get_idati(), "void (__fastcall)();", idaapi.PT_SIL)
                    return tinfo.get_rettype()

                terminated = name + ";"
                idaapi.parse_decl(tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL)

                tinfo_str = tinfo.dstr()
                if tinfo_str == name or tinfo_str == self.clean_struct_name(name):
                    return tinfo

                terminated = self.clean_struct_name(name) + ";"
                idaapi.parse_decl(tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL)
                return tinfo

            def get_tinfo_from_type(self, raw_type, array_size=0):
                # type: (str, int) -> idaapi.tinfo_t
                """
                Retrieve a tinfo_t from a raw type string.
                """

                type = raw_type.rstrip("*")
                ptr_count = len(raw_type) - len(type)

                type_tinfo = self.get_named_type(type)

                ptr_tinfo = None
                if ptr_count > 0:
                    for i in range(ptr_count):
                        ptr_tinfo = idaapi.tinfo_t()
                        if not ptr_tinfo.create_ptr(type_tinfo):
                            print("! failed to create pointer")
                            return None
                        type_tinfo = ptr_tinfo
                else:
                    ptr_tinfo = type_tinfo

                if array_size > 0:
                    array_tinfo = idaapi.tinfo_t()
                    if not array_tinfo.create_array(ptr_tinfo, array_size):
                        print("! failed to create array")
                        return None

                    ptr_tinfo = array_tinfo

                return ptr_tinfo

            def get_tinfo_from_func_data(self, data):
                # type: (DefinedFuncField) -> idaapi.tinfo_t
                tinfo = ida_typeinf.tinfo_t()
                func_data = ida_typeinf.func_type_data_t()
                func_data.cc = ida_typeinf.CM_CC_FASTCALL
                func_data.rettype = self.get_tinfo_from_type(data.return_type)
                for param in data.parameters:
                    arg = ida_typeinf.funcarg_t()
                    arg.type = self.get_tinfo_from_type(param.type)
                    arg.name = param.name
                    func_data.push_back(arg)

                tinfo.create_func(func_data)
                return tinfo

            def get_struct_opinfo_from_type(self, raw_type):
                # type: (str) -> ida_nalt.opinfo_t
                opinf = ida_nalt.opinfo_t()
                opinf.tid = ida_struct.get_struc_id(raw_type)
                return opinf

            def get_enum_opinfo_from_type(self, raw_type):
                # type: (str) -> ida_nalt.opinfo_t
                opinf = ida_nalt.opinfo_t()
                opinf.ec.tid = ida_enum.get_enum(raw_type)
                return opinf

            def clean_name(self, name):
                # type: (str) -> str
                return name

            def clean_struct_name(self, name):
                # type: (str) -> str
                return (
                    name.replace(" ", "")
                    .replace("unsigned", "u")
                    .replace("__int64", "long")
                    .replace("__int32", "int")
                    .replace("__int16", "short")
                    .replace("__int8", "byte")
                )

            def search_binary(self, ea, pattern, flag):
                # type: (int, str, int) -> int
                return ida_search.find_binary(
                    ea,
                    flag & 1 and ida_ida.cvar.inf.max_ea or ida_ida.cvar.inf.min_ea,
                    pattern,
                    16,
                    flag,
                )

            def get_func_ea_by_name(self, name):
                # type: (str) -> int
                return ida_name.get_name_ea(0, name)

            def get_func_ea_by_sig(self, pattern):
                # type: (str) -> int
                ea = self.search_binary(0, pattern, ida_search.SEARCH_DOWN)

                if ida_funcs.get_func(ea) is None:
                    finf = ida_funcs.func_t()
                    finf.start_ea = ea
                    finf.end_ea = idc.BADADDR
                    ida_funcs.add_func_ex(finf)

                if ida_funcs.get_func(ea).start_ea == ea:
                    return ea
                mnem = idc.print_insn_mnem(ea)
                if not mnem:
                    return idc.BADADDR

                opType0 = idc.get_operand_type(ea, 0)
                if mnem == "jmp" or mnem == "call" or mnem[0] == "j":
                    if opType0 != idc.o_near and opType0 != idc.o_mem:
                        print(
                            "Error: Can't follow opType0 {0}".format(
                                self.opTypeAsName(opType0)
                            )
                        )
                        return idc.BADADDR
                    return idc.get_operand_value(ea, 0)

                if idc.next_head(ea) == ea + idc.get_item_size(ea) and idc.is_flow(
                    idc.get_full_flags(idc.next_head(ea))
                ):
                    return idc.next_head(ea)

            def opTypeAsName(self, n):
                for item in [x for x in dir(idc) if x.startswith("o_")]:
                    if getattr(idc, item) == n:
                        return item

            def delete_struct_members(self, fullname):
                # type: (str) -> None
                s = ida_struct.get_struc(ida_struct.get_struc_id(fullname))
                if s is not None and ida_struct.get_struc_size(s) != 0:
                    ida_struct.del_struc_members(
                        s, 0, ida_struct.get_struc_last_offset(s) + 1
                    )

            def delete_enum_members(self, enum):
                # type: (DefinedEnum) -> None
                e = ida_enum.get_enum(enum.type)
                for value in enum.values:
                    mem = ida_enum.get_enum_member_by_name(
                        "{0}.{1}".format(enum.name, value)
                    )
                    ida_enum.del_enum_member(
                        e,
                        ida_enum.get_enum_member_value(mem),
                        ida_enum.get_enum_member_serial(mem),
                        ida_enum.get_enum_member_bmask(mem),
                    )

            @property
            def get_file_path(self):
                return os.path.join(
                    os.path.dirname(os.path.realpath(__file__)), "ffxiv_structs.yml"
                )

            def create_enum(self, enum):
                # type: (DefinedEnum) -> None
                fullname = enum.type
                ida_enum.add_enum(idc.BADADDR, fullname, 0)
                e = ida_enum.get_enum(fullname)
                ida_enum.set_enum_width(e, self.get_size_from_ida_type(enum.underlying))
                if self.is_signed(enum.underlying):
                    ida_enum.set_enum_flag(e, 0x20000)
                for value in enum.values:
                    ida_enum.add_enum_member(
                        e, "{0}.{1}".format(enum.name, value), enum.values[value]
                    )

            def delete_enum(self, enum):
                # type: (DefinedEnum) -> None
                self.delete_enum_members(enum)

            def delete_struct(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_struct_name(struct.type)
                self.delete_struct_members(fullname)
                self.delete_struct_members(fullname + "_vtbl")

            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_struct_name(struct.type)
                if ida_struct.get_struc_id(fullname) == idaapi.BADADDR:
                    ida_struct.add_struc(-1, fullname, struct.union)
                if struct.virtual_functions:
                    ida_struct.add_struc(-1, fullname + "_vtbl")

            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_struct_name(struct.type)
                s = ida_struct.get_struc(ida_struct.get_struc_id(fullname))

                if struct.virtual_functions != None and (struct.fields == [] or struct.fields[0].offset > 0):
                    ida_struct.add_struc_member(s, "__vftable", 0, ida_bytes.qword_flag(), None, 8)
                    type = fullname + "_vtbl*" if struct.virtual_functions else "void**"
                    meminfo = ida_struct.get_member(s, 0)
                    ida_struct.set_member_tinfo(s, meminfo, 0, self.get_tinfo_from_type(type), 0)

                contiguous_fields = True
                for field in struct.fields:
                    offset = field.offset

                    # add padding between previous field and current
                    prev_size = ida_struct.get_struc_size(s)
                    if offset > prev_size:
                        contiguous_fields = False
                        ida_struct.add_struc_member(
                            s,
                            f"field_{prev_size:X}",
                            prev_size,
                            ida_bytes.byte_flag(),
                            None,
                            offset - prev_size
                        )

                    field_is_base = field.base and contiguous_fields
                    field_name = field.name if not field_is_base else f'baseclass_{offset:X}'
                    field_type = self.clean_name(field.type)
                    if field_type == "__fastcall":
                        ida_struct.add_struc_member(
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
                        == ida_bytes.stru_flag()
                    ):
                        field_type = self.clean_struct_name(field_type)
                        ida_struct.add_struc_member(
                            s,
                            field_name,
                            offset,
                            self.get_idc_type_from_ida_type(field_type),
                            self.get_struct_opinfo_from_type(field_type),
                            self.get_size_from_ida_type(field_type),
                        )
                    elif (
                        self.get_idc_type_from_ida_type(field_type)
                        == ida_bytes.enum_flag()
                    ):
                        ida_struct.add_struc_member(
                            s,
                            field_name,
                            offset,
                            self.get_idc_type_from_ida_type(field_type),
                            self.get_enum_opinfo_from_type(field_type),
                            self.get_size_from_ida_type(field_type),
                        )
                    else:
                        ida_struct.add_struc_member(
                            s,
                            field_name,
                            offset,
                            self.get_idc_type_from_ida_type(field_type),
                            None,
                            self.get_size_from_ida_type(field_type),
                        )
                    meminfo = ida_struct.get_member_by_name(s, field_name)
                    if field_is_base:
                        meminfo.props |= ida_struct.MF_BASECLASS
                    array_size = field.size if hasattr(field, "size") else 0
                    ida_struct.set_member_tinfo(s, meminfo, 0, self.get_tinfo_from_type(field_type, array_size), 0)

                if struct.size is not None and struct.size != 0:
                    prev_size = ida_struct.get_struc_size(s)
                    if struct.size > prev_size:
                        ida_struct.add_struc_member(
                            s,
                            f"field_{prev_size:X}",
                            prev_size,
                            ida_bytes.byte_flag(),
                            None,
                            struct.size - prev_size
                        )

            def create_vtable(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_name(struct.type)
                s = ida_struct.get_struc(ida_struct.get_struc_id(fullname + "_vtbl"))
                for virt_func in struct.virtual_functions:
                    offset = virt_func.offset
                    field_name = virt_func.name
                    ida_struct.add_struc_member(
                        s,
                        field_name,
                        offset,
                        self.get_idc_type_from_ida_type("__int64"),
                        None,
                        self.get_size_from_ida_type("__int64"),
                    )
                    if virt_func.return_type == None or virt_func.parameters == None:
                        continue

                    meminfo = ida_struct.get_member_by_name(s, field_name)
                    field_type = self.clean_name(virt_func.return_type)
                    field_type = field_type + "(__fastcall* " + field_name + ")("
                    for param in virt_func.parameters:
                        field_type = field_type + self.clean_name(param.type) + " "
                        field_type = field_type + param.name + ","
                    field_type = field_type[:-1] + ")"

                    ida_struct.set_member_tinfo(
                        s, meminfo, 0, self.get_tinfo_from_type(field_type), 0
                    )
                size = int(ida_struct.get_struc_size(s) / 8)
                for i in range(size):
                    if ida_struct.get_member_id(s, i * 8) == idc.BADADDR:
                        ida_struct.add_struc_member(
                            s,
                            "vf{0}".format(i),
                            i * 8,
                            self.get_idc_type_from_ida_type("__int64"),
                            None,
                            self.get_size_from_ida_type("__int64"),
                        )
                        meminfo = ida_struct.get_member_by_name(s, "vf{0}".format(i))
                        ida_struct.set_member_tinfo(
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

if api is None:
    try:
        import ghidra
        import re

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
                for match in re.finditer(r"unsigned __[\w*]{3,}|[:\w*]{3,}", name):
                    tn = self.get_ghidra_type(
                        SymbolPathParser.parse(match.group(0)).getLast()
                    )
                    name = name.replace(match.group(0), tn)
                return name

            def get_ghidra_type(self, name):
                # type: (str) -> str
                if name == "__int8":
                    return "byte"
                elif name == "__int16":
                    return "short"
                elif name == "unsigned __int16" or name == "unsigned short":
                    return "ushort"
                elif name == "__int32":
                    return "int"
                elif (
                    name == "unsigned __int32"
                    or name == "_DWORD"
                    or name == "unsigned int"
                ):
                    return "uint"
                elif name == "__int64":
                    return "longlong"
                elif name == "unsigned __int64":
                    return "ulonglong"
                elif name == "__int8*":
                    return "byte*"
                elif name == "__int16*":
                    return "short*"
                elif name == "unsigned __int16*":
                    return "ushort*"
                elif name == "__int32*":
                    return "int*"
                elif name == "unsigned __int32*" or name == "unsigned int*":
                    return "uint*"
                elif name == "__int64*":
                    return "longlong*"
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

            def create_enum(self, enum):
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
                    dt = StructureDataType(name, int(struct.size or "0"))
                dt.setCategoryPath(self.get_category_path(struct.type))
                self.create_datatype(dt)

            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                dt = self.get_datatype(struct.type)
                if dt is None:
                    return

                dtsize = dt.getLength() if not dt.isZeroLength() else 0
                if dtsize == 0 and struct.virtual_functions != None and not struct.union:
                    dt.growStructure(8)

                for field in struct.fields:
                    if monitor.isCancelled():
                        return

                    offset = int(field.offset)
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

                last_offset = int(struct.virtual_functions[-1].offset)
                for func in struct.virtual_functions:
                    func_def = self.create_function_def(func)
                    func_def.setCategoryPath(
                        CategoryPath(vt_type.getCategoryPath(), [vt_type.getName()])
                    )
                    vt_type.insertAtOffset(
                        int(func.offset),
                        dtm.getPointer(func_def),
                        -1,
                        func.name,
                        "vf{0}".format(int(func.offset) / 8),
                    )

                void_ptr = dtm.getPointer(VoidDataType.dataType)
                for offset in range(last_offset):
                    dtc = vt_type.getComponentContaining(offset)
                    if not dtc or Undefined.isUndefined(dtc.getDataType()):
                        vt_type.replaceAtOffset(
                            offset, void_ptr, -1, "vf{0}".format(offset / 8), ""
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

            def create_enum(self, enum):
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
        api.create_enum(enum)

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


run()

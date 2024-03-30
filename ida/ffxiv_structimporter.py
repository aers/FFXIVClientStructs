from yaml import safe_load
import os


class DefinedBase:
    def __init__(self, name, type, namespace):
        # type: (str, str, str) -> None
        self.name = name
        self.type = type
        self.namespace = namespace

class DefinedEnum(DefinedBase):
    def __init__(self, name, type, underlying, namespace, values):
        # type: (str, str, str, str, dict[str, int]) -> None
        super(DefinedEnum, self).__init__(name, type, namespace)
        self.name = name
        self.type = type
        self.values = values

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
    def __init__(self, signature, return_type, parameters):
        # type: (str, str, list[DefinedFuncParam]) -> None
        self.signature = signature
        self.return_type = return_type
        self.parameters = parameters

class DefinedField(DefinedFuncParam):
    def __init__(self, name, type, offset):
        # type: (str, str, int) -> None
        super(DefinedField, self).__init__(name, type)
        self.offset = offset

class DefinedStruct(DefinedBase):
    def __init__(self, name, type, namespace, fields, size, virtual_functions, member_functions):
        # type: (str, str, str, list[DefinedField], int | None, list[DefinedVFunc], list[DefinedMemFunc]) -> None
        super(DefinedStruct, self).__init__(name, type, namespace)
        self.fields = fields
        self.size = size
        self.virtual_functions = virtual_functions
        self.member_functions = member_functions

class DefinedExport:
    def __init__(self, enums, structs) -> None:
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
    def update_member_func(self, member_func):
        # type: (DefinedMemFunc) -> None
        """
        Updates a member function in the database.
        """
    
    @property
    @abstractmethod
    def get_file_path(self):
        """
        Retrieve the file path of the yaml file.
        """
    
    def get_yaml(self):
        # type: () -> DefinedExport
        return safe_load(open(self.get_file_path))

api = None

if api is None:
    try:
        import idaapi
        import idc
        import ida_bytes
        import ida_nalt
        import ida_struct
        import ida_enum
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi):
            def get_idc_type_from_ida_type(type: str):
                if(type == 'unsigned __int8' or type == '__int8' or type == 'bool' or type == 'char' or type == 'unsigned char' or type == 'byte'):
                    return ida_bytes.byte_flag()
                elif(type == 'unsigned __int16' or type == '__int16'):
                    return ida_bytes.word_flag()
                elif(type == 'unsigned __int32' or type == '__int32' or type == 'int' or type == 'unsigned int' or type == '_DWORD'):
                    return ida_bytes.dword_flag()
                elif(type == 'unsigned __int64' or type == '__int64' or type == '__fastcall' or type.endswith("*")):
                    return ida_bytes.qword_flag()
                elif(type == 'float'):
                    return ida_bytes.float_flag()
                else:
                    return ida_bytes.stru_flag()
                
            def is_signed(type: str):
                if(type == '__int8' or type == '__int16' or type == '__int32' or type == '__int64' or type == 'int' or type == '_DWORD'):
                    return True
                else:
                    return False

            def get_size_from_ida_type(type: str):
                if(type == 'unsigned __int8' or type == '__int8' or type == 'bool' or type == 'char' or type == 'unsigned char' or type == 'byte'):
                    return 1
                elif(type == 'unsigned __int16' or type == '__int16'):
                    return 2
                elif(type == 'unsigned __int32' or type == '__int32' or type == 'int' or type == 'unsigned int' or type == '_DWORD' or type == 'float'):
                    return 4
                elif(type == 'unsigned __int64' or type == '__int64' or type == '__fastcall' or type.endswith("*")):
                    return 8
                elif ida_struct.get_struc_id(type) == idaapi.BADADDR:
                    return ida_enum.get_enum_width(ida_enum.get_enum(type))
                else:
                    return ida_struct.get_struc_size(ida_struct.get_struc_id(type))
                    
            def get_tinfo_from_type(raw_type: str):
                """
                Retrieve a tinfo_t from a raw type string.
                """

                type_tinfo = idaapi.tinfo_t()
                ptr_tinfo = None

                ptr_count = raw_type.count("*")
                type = raw_type.rstrip("*")

                if not type_tinfo.get_named_type(idaapi.get_idati(), type):
                    terminated = type + ";"
                    if (idaapi.parse_decl(type_tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL) is None):
                        print("! failed to parse type '{0}'".format(type))
                        return None

                if ptr_count > 0:
                    ptr_tinfo = idaapi.tinfo_t()
                    for i in range(ptr_count):
                        if not ptr_tinfo.create_ptr(type_tinfo):
                            print("! failed to create pointer")
                            return None
                else:
                    ptr_tinfo = type_tinfo

                return ptr_tinfo

            def get_opinfo_from_type(raw_type: str):
                opinf = ida_nalt.opinfo_t()
                opinf.tid = ida_struct.get_struc_id(raw_type)
                return opinf
            
            def clean_name(name):
                ret = name.replace("<", "__").replace("*>", "Ptr").replace(">", "").replace("*, ", "Ptr_").replace(", ","_")
                if name.count("<") > 0:
                    return ret.replace(" ", "")
                return ret

            @property
            def get_file_path():
                return os.path.join(os.path.dirname(os.path.realpath(__file__)), "ffxiv_structs.yml")
            
            def create_enum(self, enum):
                # type: (DefinedEnum) -> None
                fullname = enum.type
                name = enum.name
                ida_enum.add_enum(idc.BADADDR, fullname, 0)
                e = ida_enum.get_enum(fullname)
                ida_enum.set_enum_width(e, self.get_size_from_ida_type(enum.underlying))
                if self.is_signed(enum.underlying):
                    ida_enum.set_enum_flag(e, 0x20000)
                for value in enum.values:
                    ida_enum.add_enum_member(e, value, enum.values[value])

            def delete_enum(self, enum):
                # type: (DefinedEnum) -> None
                ida_enum.del_enum(ida_enum.get_enum(enum.type))
            
            def delete_struct(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_name(struct.type)
                ida_struct.del_struc(ida_struct.get_struc(ida_struct.get_struc_id(fullname)))
                ida_struct.del_struc(ida_struct.get_struc(ida_struct.get_struc_id(fullname + "VTable")))
                ida_struct.del_struc(ida_struct.get_struc(ida_struct.get_struc_id(fullname + "Union")))
            
            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_name(struct.type)
                ida_struct.add_struc(-1, fullname)
                s = 0
                if struct["virtual_functions"] != []:
                    s = ida_struct.add_struc(-1, fullname + "VTable")
                if s != 0 and struct["fields"] != [] and struct["fields"][0]["offset"] == 0:
                    ida_struct.add_struc(-1, fullname + "Union", True)
            
            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_name(struct.type)
                s = ida_struct.get_struc(ida_struct.get_struc_id(fullname))
                for field in struct["fields"]:
                    offset = field["offset"]
                    if offset == 0 and struct["virtual_functions"] != []:
                        continue
                    field_name = field["name"]
                    field_type = field["type"].replace("<", "__").replace("*>", "Ptr").replace(">", "").replace("*, ", "Ptr_").replace(", ","_")
                    if field["type"].count("<") > 0:
                        field_type = field_type.replace(" ", "")
                    if field_type == '__fastcall':
                        field_type = field['return_type'] + " (__fastcall)("
                        for param in field['parameters']:
                            param_type = param["type"].replace("<", "__").replace("*>", "Ptr").replace(">", "").replace("*, ", "Ptr_").replace(", ","_")
                            if param["type"].count("<") > 0:
                                param_type = param_type.replace(" ", "")
                            field_type += " " + param_type + " " + param["name"] + ","
                        field_type = field_type[:-1] + ")"
                    if self.get_idc_type_from_ida_type(field_type) == ida_bytes.stru_flag():
                        ida_struct.add_struc_member(s, field_name, offset, self.get_idc_type_from_ida_type(field_type), self.get_opinfo_from_type(field_type), self.get_size_from_ida_type(field_type))
                    else:
                        ida_struct.add_struc_member(s, field_name, offset, self.get_idc_type_from_ida_type(field_type), None, self.get_size_from_ida_type(field_type))
                    meminfo = ida_struct.get_member_by_name(s, field_name)
                    ida_struct.set_member_tinfo(s, meminfo, 0, self.get_tinfo_from_type(field_type), 0)
                if 'size' in struct and struct["size"] != 0:
                    size = struct["size"] - 1
                    if struct["size"] != ida_struct.get_struc_size(s):
                        ida_struct.add_struc_member(s, "field_{0}".format(hex(size)[2:]), size, self.get_idc_type_from_ida_type("__int8"), None, self.get_size_from_ida_type('__int8'))
            
            def create_vtable(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_name(struct.type)
                s = ida_struct.get_struc(ida_struct.get_struc_id(fullname + "VTable"))
                for virt_func in struct["virtual_functions"]:
                    offset = virt_func["offset"]
                    field_name = virt_func["name"]
                    return_type = virt_func["return_type"]
                    field_type = return_type + " (__fastcall)("
                    for param in virt_func["parameters"]:
                        param_type = param["type"].replace("<", "__").replace("*>", "Ptr").replace(">", "").replace("*, ", "Ptr_").replace(", ","_")
                        if param["type"].count("<") > 0:
                            param_type = param_type.replace(" ", "")
                        field_type += " " + param_type + " " + param["name"] + ","
                    field_type = field_type[:-1] + ")"
                    ida_struct.add_struc_member(s, field_name, offset, self.get_idc_type_from_ida_type('__int64'), None, self.get_size_from_ida_type('__int64'))
                    meminfo = ida_struct.get_member_by_name(s, field_name)
                    ida_struct.set_member_tinfo(s, meminfo, 0, self.get_tinfo_from_type(field_type), 0)
            
            def create_union(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_name(struct.type)
                union_struc = ida_struct.get_struc(ida_struct.get_struc_id(fullname + "Union"))
                if union_struc != None and struct["fields"] != [] and struct["fields"][0]["offset"] == 0:
                    ida_struct.add_struc_member(union_struc, "vtable", 0, self.get_idc_type_from_ida_type("__int64"), None, self.get_size_from_ida_type("__int64"))
                    meminfo = ida_struct.get_member_by_name(union_struc, "vtable")
                    ida_struct.set_member_tinfo(union_struc, meminfo, 0, self.get_tinfo_from_type(fullname + "VTable*"), 0)
                    field = struct["fields"][0]
                    field_type = field["type"].replace("<", "__").replace("*>", "Ptr").replace(">", "").replace("*, ", "Ptr_").replace(", ","_")
                    field_name = field["name"]
                    if field["type"].count("<") > 0:
                        field_type = field_type.replace(" ", "")
                    if self.get_idc_type_from_ida_type(field_type) == ida_bytes.stru_flag():
                        ida_struct.add_struc_member(union_struc, field_name, idaapi.BADADDR, self.get_idc_type_from_ida_type(field_type), self.get_opinfo_from_type(field_type), self.get_size_from_ida_type(field_type))
                    else:
                        ida_struct.add_struc_member(union_struc, field_name, idaapi.BADADDR, self.get_idc_type_from_ida_type(field_type), None, self.get_size_from_ida_type(field_type))
                    meminfo = ida_struct.get_member_by_name(union_struc, field_name)
                    ida_struct.set_member_tinfo(union_struc, meminfo, 0, self.get_tinfo_from_type(field_type), 0)
                    s = ida_struct.get_struc(ida_struct.get_struc_id(fullname))
                    ida_struct.add_struc_member(s, "union", 0, self.get_idc_type_from_ida_type(fullname + "Union"), self.get_opinfo_from_type(fullname + "Union"), self.get_size_from_ida_type(fullname + "Union"))
                    meminfo = ida_struct.get_member_by_name(s, "union")
                    ida_struct.set_member_tinfo(s, meminfo, 0, self.get_tinfo_from_type(fullname + "Union"), 0)
                elif struct['virtual_functions'] != []:
                    s = ida_struct.get_struc(ida_struct.get_struc_id(fullname))
                    ida_struct.add_struc_member(s, "vtable", 0, self.get_idc_type_from_ida_type("__int64"), None, self.get_size_from_ida_type("__int64"))
                    meminfo = ida_struct.get_member_by_name(s, "vtable")
                    ida_struct.set_member_tinfo(s, meminfo, 0, self.get_tinfo_from_type(fullname + "VTable*"), 0)

            def update_member_func(self, member_func):
                # type: (DefinedMemFunc) -> None
                pass

        api = IdaApi()

if api is None:
    try:
        import ghidra

    except ImportError:
        print("Warning: Unable to load Ghidra")
    else:
        # noinspection PyUnresolvedReferences
        class GhidraApi(BaseApi):
            def get_file_path(self):
                return os.path.join(os.path.dirname(str(sourceFile)), "ffxiv_structs.yml")
            
            def create_enum(self, enum):
                # type: (DefinedEnum) -> None
                pass
            
            def delete_enum(self, enum):
                # type: (DefinedEnum) -> None
                pass
            
            def delete_struct(self, struct):
                # type: (DefinedStruct) -> None
                pass
            
            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                pass
            
            def create_struct_members(self, struct):
                # type: (DefinedStruct) -> None
                pass
            
            def create_vtable(self, struct):
                # type: (DefinedStruct) -> None
                pass
            
            def create_union(self, struct):
                # type: (DefinedStruct) -> None
                pass
            
            def update_member_func(self, member_func):
                # type: (DefinedMemFunc) -> None
                pass
            

if api is None:
    raise Exception("Unable to load IDA or Ghidra")

def run():
    yaml = api.get_yaml()

    for struct in yaml["structs"][::-1]:
        api.delete_struct(struct)

    for enum in yaml["enums"]:
        api.delete_enum(enum)
        api.create_enum(enum)

    for struct in yaml["structs"]:
        api.create_struct(struct)

    for struct in yaml["structs"]:
        api.create_struct_members(struct)

    for struct in yaml["structs"]:
        if struct["virtual_functions"] != []:
            api.create_vtable(struct)

    for struct in yaml["structs"]:
        api.create_union(struct)
    
    for struct in yaml["structs"]:
        for member_func in struct["member_functions"]:
            api.update_member_func(member_func)

run()
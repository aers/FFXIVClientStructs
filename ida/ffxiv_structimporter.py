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
            dic = load(fd, Loader=Loader)  # type: dict[str, dict[str, list[dict[str, str | int | list[dict[str, str | int]]]]]]
        enums = []
        structs = []
        for enum in dic["enums"]:
            enums.append(
                DefinedStructEnum(
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
                        DefinedStructFixedField(
                            field["name"],
                            field["type"],
                            field["offset"],
                            base,
                            field["size"],
                            field["is_string"]
                        )
                    )
                elif "return_type" in field:
                    parameters = []
                    for param in field["parameters"]:
                        parameters.append(
                            DefinedStructFuncParam(param["name"], param["type"])
                        )
                    fields.append(
                        DefinedStructFuncField(
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
                        DefinedStructField(
                            field["name"], field["type"], field["offset"], base
                        )
                    )
            if "virtual_functions" in struct:
                virtual_functions = []
                for vfunc in struct["virtual_functions"]:
                    parameters = (
                        [
                            DefinedStructFuncParam(param["name"], param["type"])
                            for param in vfunc["parameters"]
                        ]
                        if "parameters" in vfunc
                        else None
                    )
                    virtual_functions.append(
                        DefinedStructVFunc(
                            vfunc["name"],
                            vfunc["return_type"] if "return_type" in vfunc else None,
                            vfunc["offset"],
                            parameters,
                        )
                    )
            for memfunc in struct["member_functions"]:
                parameters = []
                for param in memfunc["parameters"]:
                    parameters.append(DefinedStructFuncParam(param["name"], param["type"]))
                member_functions.append(
                    DefinedStructMemFunc(
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
                            DefinedStructFuncParam(param["name"], param["type"])
                        )
                    static_member_functions.append(
                        DefinedStructMemFunc(
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
                        DefinedStructStaticMember(
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
        return DefinedStructExport(enums, structs)

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
        from ida_wrapper import IdaInterface
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi, IdaInterface):
            def __init__(self, full_padding, srclang_importer):
                # type: (bool, bool) -> None
                self.full_padding = full_padding
                self.srclang_importer = srclang_importer
                if self.srclang_importer:
                    self.srclang_types = {}

            def validate_name_cfg(self):
                """Verifies that the user's IDA config allows template characters for type names"""
                temporary_name = "sruc_name_test"
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

            def delete_struct_members(self, fullname):
                # type: (str) -> None
                self.remove_struct_members(self.get_struct_id(fullname))

            @property
            def get_file_path(self):
                return os.path.join(
                    os.path.dirname(os.path.realpath(__file__)), "ffxiv_structs.yml"
                )
            
            def generate_hashed_type_name(self, name: str) -> str:                
                name = self.clean_struct_name(name)

                name = hashlib.sha1(name.encode()).hexdigest()

                return "struc_" + name

            def get_srclang_type_name(self, name: str) -> str:
                if not self.srclang_importer:
                    return name
                
                ptr_count = 0
                i = len(name) - 1
                while i >= 0 and name[i] == '*':
                    ptr_count += 1
                    i -= 1

                full_name = name
                if ptr_count > 0:
                    name = name.strip("*")

                cname = self.srclang_types.get(name)
                if cname is None:
                    cname = self.srclang_types.get(self.clean_struct_name(name))
                    
                if cname is not None:
                    return cname + "*" * ptr_count
                
                return full_name

            def can_run(self):
                return self.enum_exists("Component::Exd::SheetsEnum")

            def create_enum_struct(self, enum):
                # type: (DefinedStructEnum) -> None
                fullname = enum.type
                
                e = self.get_enum_id(fullname)
                if e == idaapi.BADADDR:
                    e = self.create_enum(fullname)

                self.set_enum_width(e, self.get_size_from_ida_type(enum.underlying))
                if self.is_signed(enum.underlying):
                    self.set_enum_flag(e, 0x20000)
                if enum.flags:
                    if idaapi.IDA_SDK_VERSION < 900:
                        self.add_enum_member(e, "{0}.{1}".format(enum.name, "tmp"), self.get_enum_default_mask(e))
                    self.set_enum_as_bf(e)
                for value in enum.values:
                    self.add_enum_member(
                        e, "{0}.{1}".format(enum.name, value), enum.values[value]
                    )
                if enum.flags and idaapi.IDA_SDK_VERSION < 900:
                    self.remove_enum_member(e, "tmp", enum.name)

            def delete_enum(self, enum):
                # type: (DefinedStructEnum) -> None
                eid = idc.get_enum(enum.type)
                if eid != idaapi.BADADDR:
                    self.delete_enum_members(eid)
                    idc.set_enum_bf(eid, False)

            def delete_struct(self, struct):
                # type: (DefinedStruct) -> None
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                fullname = self.clean_struct_name(struct.type)
                self.delete_struct_members(fullname)
                self.delete_struct_members(fullname + "_vtbl")

                # also check C types in case of an incomplete C run
                if self.srclang_importer:
                    cname = self.get_srclang_type_name(fullname)
                    self.delete_struct_members(cname)
                    self.delete_struct_members(cname + "_vtbl")

                idaapi.end_type_updating(idaapi.UTP_STRUCT)

            def create_struct(self, struct):
                # type: (DefinedStruct) -> None
                fullname = self.clean_struct_name(struct.type)

                if self.srclang_importer:
                    # rename C++ -> C or create new C struct
                    cname = self.generate_hashed_type_name(fullname)
                    print(
                        "Creating struct: yaml={!r}, ida={!r}, importer=SrcLang".format(
                            struct.type, cname
                        )
                    )
                    self.srclang_types[fullname] = cname
                    
                    sid = self.get_struct_id(fullname)
                    if sid == idaapi.BADADDR:
                        if self.get_struct_id(cname) == idaapi.BADADDR:
                            self.create_struct_type(cname, struct.union)
                    else:
                        self.rename_struct(sid, cname)
                    
                    if not struct.virtual_functions:
                        return
                    
                    sid = self.get_struct_id(fullname + "_vtbl")
                    if sid == idaapi.BADADDR:
                        if self.get_struct_id(cname + "_vtbl") == idaapi.BADADDR:
                            self.create_struct_type(cname + "_vtbl")
                    else:
                        self.rename_struct(sid, cname + "_vtbl")

                    return

                print(
                    "Creating struct: yaml={!r}, ida={!r}, importer=Legacy".format(
                        struct.type, fullname
                    )
                )
                if self.get_struct_id(fullname) == idaapi.BADADDR:
                    self.create_struct_type(fullname, struct.union)

                if struct.virtual_functions:
                    self.create_struct_type(fullname + "_vtbl")

            def validate_srclang_struct(self, struct: DefinedStruct):
                cname = self.get_srclang_type_name(self.clean_struct_name(struct.type))
                sid = self.get_struct_id(cname)
                if sid == idaapi.BADADDR:
                    ida_kernwin.warning(f"Struct {cname} ({struct.type}) not found during validation")
                    exit()
                
                ti = self.get_struct(sid)

                seen_fields = {}
                
                last_offset = -1
                for field in struct.fields:
                    if field.offset == last_offset:
                        continue

                    last_offset = field.offset

                    if field.offset is None or field.base:
                        continue

                    if field.offset == 0 and field.name == "_vtable":
                        continue

                    # ugly hack to workaround duplicate field names in structs
                    field_name = field.name
                    if field_name in seen_fields:
                        next = seen_fields[field_name] + 1
                        seen_fields["field_name"] = next

                        field_name += f"_{next}"
                    else:
                        seen_fields[field_name] = 1

                    (idx, udm) = ti.get_udm(field_name)
                    if idx == -1:
                        ida_kernwin.warning(f"Field {field_name} not found in struct {cname} ({struct.type}) during validation")
                        exit()

                    if (udm.offset / 8) != field.offset:
                        ida_kernwin.warning(f"Field \"{field_name}\" offset mismatch in struct {cname} ({struct.type}) during validation.\nExpected {field.offset}, got {(udm.offset/8)}")
                        exit()

            def get_srclang_fill_type(self, available_bytes: int, current_offset: int) -> tuple[str, int]:
                if available_bytes >= 8 and (current_offset % 8) == 0:
                    return ("__int64", 8)
                elif available_bytes >= 4 and (current_offset % 4) == 0:
                    return ("__int32", 4)
                elif available_bytes >= 2 and (current_offset % 2) == 0:
                    return ("__int16", 2)
                else:
                    return ("char", 1)

            def create_srclang_decl(self, struct: DefinedStruct) -> str:
                fullname = self.get_srclang_type_name(self.clean_struct_name(struct.type))

                decl = [ "_" ] # placeholder, filled after we determine base classes

                cur_size = 0

                contiguous_fields = True
                
                seen_fields = {}

                inherits_from = []

                has_explicit_vtable = (len(struct.fields) != 0 and struct.fields[0].name == "_vtable")
                
                if struct.virtual_functions != None or has_explicit_vtable:
                    # the placeholder will force IDA to mark the _vtbl struct as a VFT
                    # and attach it to this struct
                    decl.append("virtual void _placeholder();")

                    # TODO(caitlyn): we are assuming that parent classes are always virtual
                    # doing this properly will require checking the parent
                    # eventually we'll probably want to build an inheritance hierarchy
                    # so that we can propagate vfunc names and determine the need to
                    # offset data members here
                    #
                    # some types also have a base class which is not correctly flagged as such
                    # so we're not checking the baseclass flag here
                    #
                    # we may want to check up-front if this struct has a struct type at offset 0 and a VFT
                    # and automatically mark that as the baseclass
                    needs_alloc = \
                        len(struct.fields) == 0 or \
                        struct.fields[0].offset != 0
                    
                    if needs_alloc or has_explicit_vtable:
                        cur_size += 8

                last_field_offset = -1
                for field in struct.fields:
                    offset = field.offset

                    # skip explicit vtable fields
                    if offset == 0 and field.name == "_vtable":
                        continue

                    if offset == last_field_offset and not struct.union:
                        # TODO(caitlyn): Ghidra creates unions for this, but it's currently silently skipped for IDA
                        print(f"Skipping {struct.type}.{field.name} as it is at a duplicate offset.")
                        continue

                    last_field_offset = offset

                    while offset > cur_size:
                        contiguous_fields = False

                        # TODO(caitlyn): move this into a separate function
                        if self.full_padding:
                            (fill_type, fill_size) = self.get_srclang_fill_type(offset - cur_size, cur_size)
                            decl.append(f"{fill_type} field_{cur_size:X};")
                            cur_size += fill_size
                        else:
                            arr_size = offset - cur_size
                            decl.append(f"char field_{cur_size:X}[{arr_size}];")
                            cur_size += arr_size

                    field_is_base = field.base and contiguous_fields
                    field_name = (
                        field.name
                        if not field_is_base
                        else f"baseclass_{offset:X}"
                    )

                    # ugly hack to workaround duplicate field names in structs
                    if field_name in seen_fields:
                        next = seen_fields[field_name] + 1
                        seen_fields["field_name"] = next

                        field_name += f"_{next}"
                    else:
                        seen_fields[field_name] = 1
                    
                    array_size = field.size if hasattr(field, "size") else 0

                    field_type = self.clean_name(field.type)
                    if field_type == "__fastcall":
                        field_decl = self.get_srclang_type_name(self.clean_name(field.return_type))
                        field_decl = field_decl + "(__fastcall* " + field_name + ")("
                        for param in field.parameters:
                            field_decl = field_decl + self.get_srclang_type_name(self.clean_name(param.type)) + ""
                            field_decl = field_decl + param.name + ","
                        field_decl = field_decl[:-2] + ")"

                        decl.append(field_decl)
                        cur_size += 8

                        continue

                    field_size = 0
                    
                    # struct type
                    if self.get_idc_type_from_ida_type(
                        self.get_srclang_type_name(self.clean_struct_name(field_type))
                    ) == self.get_struct_flag():
                        field_type = self.get_srclang_type_name(self.clean_struct_name(field_type))

                        tinfo = self.get_tinfo_from_type(field_type)
                        field_size = tinfo.get_size()

                    # enum type
                    elif (
                        self.get_idc_type_from_ida_type(field_type)
                        == self.get_enum_flag()
                    ):
                        field_size = idc.get_enum_width(self.get_enum_id(field_type))

                    # primitive type
                    else:
                        field_size = self.get_size_from_ida_type(field_type)

                        if field_type.endswith("*"):
                            field_type = self.get_srclang_type_name(field_type)

                    field_decl = f"{field_type} {field_name}"
                    if array_size > 0:
                        field_size *= array_size
                        field_decl += f"[{array_size}];"
                    else:
                        field_decl += ";"

                    if field_is_base:
                        inherits_from.append(field_type)
                    else:
                        decl.append(field_decl)

                    cur_size += field_size
                
                if struct.size is not None and struct.size != 0:
                    # TODO(caitlyn): move this into a separate function

                    while cur_size < struct.size:
                        if self.full_padding:
                            (fill_type, fill_size) = self.get_srclang_fill_type(struct.size - cur_size, cur_size)
                            decl.append(f"{fill_type} field_{cur_size:X};")
                            cur_size += fill_size
                        else:
                            arr_size = struct.size - cur_size
                            decl.append(f"char field_{cur_size:X}[{arr_size}];")
                            cur_size += arr_size

                decl.append("};")

                # set struct type
                if struct.union:
                    decl[0] = f"union {fullname} "
                else:
                    decl[0] = f"struct __attribute__((packed)) {fullname} "
                if len(inherits_from) > 0:
                    decl[0] += f": {", ".join(inherits_from)}"
                
                decl[0] += " {"
                
                return "\n".join(decl)

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

                if self.srclang_importer:
                    idaapi.begin_type_updating(idaapi.UTP_STRUCT)

                    decl = self.create_srclang_decl(struct)
                    num_errors = ida_srclang.parse_decls_for_srclang(
                        ida_srclang.SRCLANG_C,
                        None,
                        decl,
                        False
                    )

                    if num_errors != 0:
                        # show messagebox
                        print(f"above errors occurred while parsing the following:\n---\n{decl}\n---")
                        ida_kernwin.warning(f"Error parsing srclang decl for {struct.type}, please see errors in Output window.")
                        exit()

                    if struct.virtual_functions:
                        # delete the _placeholder function from the VFT
                        cname = self.srclang_types[self.clean_struct_name(struct.type)]
                        sid = self.get_struct_id(f"{cname}_vtbl")
                        tinfo = self.get_struct(sid)
                        tinfo.del_udm(0)

                    idaapi.end_type_updating(idaapi.UTP_STRUCT)

                    self.validate_srclang_struct(struct)
                    return

                fullname = self.clean_struct_name(struct.type)

                tid = self.get_struct_id(fullname)
                if tid == idaapi.BADADDR:
                    print("Error: Struct {0} not found when trying to create members".format(fullname))
                    return

                s = self.get_struct(tid)

                if struct.virtual_functions != None and (
                    struct.fields == [] or struct.fields[0].offset > 0
                ):
                    self.create_struct_member(
                        s, "__vftable", 0, ida_bytes.qword_flag(), None, 8
                    )
                    type = fullname + "_vtbl*" if struct.virtual_functions else "void**"
                    meminfo = self.get_struct_member_by_name(s, "__vftable")
                    self.set_struct_member_info(
                        s, meminfo, 0, self.get_tinfo_from_type(type), 0, False
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
                    if meminfo is not None:    
                        if field_is_base:
                            if idaapi.IDA_SDK_VERSION >= 900:
                                meminfo.set_baseclass()
                            else:
                                meminfo.props |= self.get_base_class_flag()
                                
                        array_size = field.size if hasattr(field, "size") else 0
                        self.set_struct_member_info(
                            s,
                            meminfo,
                            0,
                            self.get_tinfo_from_type(field_type, array_size),
                            0,
                            field.is_string if hasattr(field, "is_string") and (field_type == "char" or field_type == "wchar_t") else False
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
                    if virt_func is None:
                        continue

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
                    if meminfo is None:
                        raise RuntimeError("Failed to find member {0} in struct {1}".format(field_name, fullname))

                    field_type = self.clean_name(virt_func.return_type)
                    field_type = field_type + "(__fastcall* " + field_name + ")("
                    for param in virt_func.parameters:
                        field_type = field_type + self.clean_name(param.type) + " "
                        field_type = field_type + param.name + ","
                    field_type = field_type[:-1] + ")"

                    self.set_struct_member_info(
                        s, meminfo, 0, self.get_tinfo_from_type(field_type), 0, False
                    )
                if struct.vtable_size:
                    size = int(struct.vtable_size / 8)
                else:
                    size = int(self.get_struct_size(s) / 8)
                for i in range(size):
                    if self.get_struct_member_id(s, i * 8) == idc.BADADDR:
                        name = "vf{0}".format(i)
                        
                        fallback_name = self.get_fallback_vfunc_name(struct.type, i)
                        if fallback_name:
                            name = fallback_name
                        
                        self.create_struct_member(
                            s,
                            name,
                            i * 8,
                            self.get_idc_type_from_ida_type("__int64"),
                            None,
                            self.get_size_from_ida_type("__int64"),
                        )
                        meminfo = self.get_struct_member_by_name(s, name)
                        self.set_struct_member_info(
                            s, meminfo, 0, self.get_tinfo_from_type("__int64"), 0, False
                        )

            def finalise_struct(self, struct: DefinedStruct):
                if not self.srclang_importer:
                    return
                
                fullname = self.clean_struct_name(struct.type)
                cname = self.get_srclang_type_name(fullname)

                sid = self.get_struct_id(cname)
                if sid == idaapi.BADADDR:
                    ida_kernwin.warning(f"Failed to find and finalise struct {cname}")
                
                self.rename_struct(sid, fullname)

                if not struct.virtual_functions:
                    return
                
                sid = self.get_struct_id(cname + "_vtbl")
                if sid == idaapi.BADADDR:
                    ida_kernwin.warning(f"Failed to find and finalise vtable for struct {cname}")
                    return
                
                self.rename_struct(sid, fullname + "_vtbl")

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
                    if getattr(virt_func, "inherited_from_preprocess", False):
                        return
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

            def preprocess_yaml(self, yaml: DefinedStructExport) -> None:
                if not self.srclang_importer:
                    return
                
                class Node:
                    def __init__(self, struct: DefinedStruct):
                        self.base: 'Node' | None = None
                        self.children: list['Node'] = []
                        self.struct: DefinedStruct = struct

                    def is_virtual(self) -> bool:
                        return self.struct.virtual_functions is not None

                nodes: dict[str, Node] = {struct.type: Node(struct) for struct in yaml.structs}

                def make_virtual(node: Node) -> None:
                    if node.struct.virtual_functions is None:
                        node.struct.virtual_functions = []
                        node.struct.vtable_size = 0

                    if node.base:
                        make_virtual(node.base)

                # discover hierarchical relationships and fix missing base flags
                for node in nodes.values():
                    if not node.struct.fields:
                        continue
                    
                    # remove explicit/placeholder _vtable field
                    if node.struct.fields and node.struct.fields[0].name == "_vtable":
                        node.struct.fields.pop(0)
                        
                        if not node.is_virtual():
                            node.struct.virtual_functions = []
                            node.struct.vtable_size = 0

                    for field in node.struct.fields:
                        # if a struct has a VFT but the field at offset 0 wasn't marked base,
                        # we assume it's the baseclass and fix the flag
                        if node.is_virtual() and field.offset == 0 and not field.base:
                            print("Warning: Fixing missing baseclass '{0}' for '{1}'".format(field.type, node.struct.type))
                            field.base = True

                        if field.offset != 0 or not field.base:
                            continue
                        
                        parent = nodes.get(field.type)
                        if parent is None:
                            print("Warning: Could not find baseclass '{0}' for '{1}'".format(field.type, node.struct.type))
                            field.base = False
                            node.struct.virtual_functions = None
                            node.struct.vtable_size = 0
                            break

                        parent.children.append(node)
                        node.base = parent

                        if node.is_virtual() and not parent.is_virtual():
                            #log.write(f"Warning: Adding missing VFT for virtual baseclass '{parent.struct.type}'\n")
                            make_virtual(parent)
                        elif parent.is_virtual() and not node.is_virtual():
                            #log.write(f"Warning: Fixing missing VFT for virtual subclass '{node.struct.type}'\n")
                            node.struct.virtual_functions = []
                            node.struct.vtable_size = 0

                # normalize VFTs into indexable lists
                for node in nodes.values():
                    if not node.is_virtual():
                        continue

                    vfuncs = node.struct.virtual_functions or []

                    max_offset = max((vf.offset for vf in vfuncs if vf is not None), default=-1)
                    vft_size = max_offset + 8 if max_offset >= 0 else 0

                    if node.struct.vtable_size and node.struct.vtable_size > vft_size:
                        vft_size = node.struct.vtable_size

                    # take baseclass VFT size if larger
                    if node.base and (node.base.struct.vtable_size or 0) > vft_size:
                        vft_size = node.base.struct.vtable_size

                    new_vft = [None] * (vft_size // 8)
                    for vf in vfuncs:
                        if vf is not None:
                            new_vft[vf.offset // 8] = vf

                    node.struct.virtual_functions = new_vft
                    node.struct.vtable_size = vft_size

                # propagate known VFs down into subclasses
                def propagate_vft_down(node: Node) -> None:
                    if not node.is_virtual():
                        return
                    
                    parent_vfs = node.struct.virtual_functions
                    if not parent_vfs:
                        return

                    for child in node.children:
                        if not child.is_virtual():
                            #log.write(f"Warning: Fixing non-virtual child '{child.struct.type}' of virtual parent '{node.struct.type}'\n")
                            child.struct.virtual_functions = [None] * len(parent_vfs)
                            child.struct.vtable_size = node.struct.vtable_size
                        elif len(child.struct.virtual_functions) < len(parent_vfs):
                            #log.write(f"Warning: Fixing VFT size mismatch: parent '{node.struct.type}' has {len(parent_vfs)} slots, child '{child.struct.type}' has {len(child.struct.virtual_functions)} slots\n")
                            extra_slots = len(parent_vfs) - len(child.struct.virtual_functions)
                            child.struct.virtual_functions += [None] * extra_slots
                            child.struct.vtable_size = max(child.struct.vtable_size or 0, node.struct.vtable_size)
                    
                        for i, vf in enumerate(parent_vfs):
                            if vf is None or child.struct.virtual_functions[i] is not None:
                                continue

                            new_vf = copy.deepcopy(vf)
                            new_vf.inherited_from_preprocess = True
                            if hasattr(new_vf, 'parameters') and new_vf.parameters:
                                new_vf.parameters[0].type = child.struct.type + "*"

                            #log.write(f"Propagating virtual function '{new_vf.name}' from '{node.struct.type}' down to subclass '{child.struct.type}'\n")
                            child.struct.virtual_functions[i] = new_vf

                        propagate_vft_down(child)

                visited_nodes: set[str] = set()
                def propagate_vft_up(node: Node) -> None:
                    if node.struct.type in visited_nodes:
                        return
                    
                    visited_nodes.add(node.struct.type)

                    if not node.is_virtual():
                        return

                    for child in node.children:
                        # propagate from bottom up
                        propagate_vft_up(child)
                        
                        child_vfs = child.struct.virtual_functions
                        parent_vfs = node.struct.virtual_functions
                        if not child_vfs or not parent_vfs:
                            continue

                        for i, vf in enumerate(child_vfs):
                            if i >= len(parent_vfs):
                                break

                            if (vf is None or parent_vfs[i] is not None):
                                continue

                            new_vf = copy.deepcopy(vf)
                            new_vf.inherited_from_preprocess = True
                            if hasattr(new_vf, 'parameters') and new_vf.parameters:
                                new_vf.parameters[0].type = node.struct.type + "*"

                            #log.write(f"Propagating virtual function '{new_vf.name}' from '{child.struct.type}' up to baseclass '{node.struct.type}'\n")
                            parent_vfs[i] = new_vf
                    
                for node in nodes.values():
                    propagate_vft_down(node)

                    if not node.is_virtual() or node.base is not None:
                        continue

                    propagate_vft_up(node)
                    propagate_vft_down(node)

        full_padding = False
        srclang_importer = False
        if idaapi.IDA_SDK_VERSION >= 900: # TODO(caitlyn): check for support on older versions
            srclang_importer = (
                ida_kernwin.ask_buttons(
                    "SrcLang Importer",
                    "Legacy Importer",
                    "",
                    ida_kernwin.ASKBTN_YES,
                    "HIDECANCEL\nWhich importer should be used?\n\nSrcLang Importer: Experimental - faster importer with full padding, and improved support for inheritance and virtual function calls.\n\nLegacy Importer: The original, battle-tested importer. Full Padding on the Legacy Importer on IDA 9+ can take 8 hours or longer.",
                )
                == ida_kernwin.ASKBTN_YES
            )

            if srclang_importer:
                full_padding = True

        if not srclang_importer:
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

        api = IdaApi(full_padding, srclang_importer)
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
                # type: (DefinedStructVFunc, DefinedStruct) -> None
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
    try:
        import binaryninja
        import struct
    except ImportError:
        print("Warning: Unable to load Binary Ninja")
    else:
        # TODO: VTables, Unions
        class BinjaApi(BaseApi):
            def can_run(self):
                return True
            
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
                # type: (DefinedStructEnum) -> None
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

                    if isinstance(field, DefinedStructFixedField):
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
                # type: (DefinedStructMemFunc, DefinedStruct) -> None
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
                # type: (DefinedStructVFunc, DefinedStruct) -> None
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
                # type: (DefinedStructStaticMember, DefinedStruct) -> None
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
            
            def preprocess_yaml(self, yaml: DefinedStructExport):
                return

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
    if not api.can_run():
        raise RuntimeError("This script depends on exdgetters. Run that script before retrying")
    
    update_virt_func = api.should_update_virt_func()
    update_member_func = api.should_update_member_func()

    print("{0} Loading yaml".format(get_time()))
    yaml = api.get_yaml()
    
    print("{0} Loading data yaml".format(get_time()))
    api.data_yaml = api.load_data_yaml()

    print("{0} Preprocessing yaml".format(get_time()))
    api.preprocess_yaml(yaml)

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

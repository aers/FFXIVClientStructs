from yaml import safe_load as yload, Loader
import os

import idaapi
import idc
import ida_bytes
import ida_nalt
import ida_struct
import ida_enum
import ida_kernwin
import ida_search
import ida_ida
import ida_typeinf
import ida_hexrays

def get_idc_type_from_ida_type(type: str):
    if(type == 'unsigned __int8' or type == '__int8' or type == 'bool'):
        return ida_bytes.byte_flag()
    elif(type == 'unsigned __int16' or type == '__int16'):
        return ida_bytes.word_flag()
    elif(type == 'unsigned __int32' or type == '__int32' or type == 'int' or type == 'unsigned int' or type == '_DWORD'):
        return ida_bytes.dword_flag()
    elif(type == 'unsigned __int64' or type == '__int64'):
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
    elif(type == 'unsigned __int64' or type == '__int64'):
        return 8
    else:
        if type.endswith("*"):
            return 8
        elif ida_struct.get_struc_id(type) == -1:
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

def run():
    yaml = yload(open(os.path.join(os.path.dirname(os.path.realpath(__file__)), "ffxiv_structs.yml")))
    for enum in yaml["enums"]:
        fullname = enum["type"]
        name = enum["name"]
        ida_enum.add_enum(idc.BADADDR, fullname, 0)
        e = ida_enum.get_enum(fullname)
        ida_enum.set_enum_width(e, get_size_from_ida_type(enum["underlying"]))
        if is_signed(enum["underlying"]):
            ida_enum.set_enum_flag(e, 0x20000)
        for value in enum["values"]:
            ida_enum.add_enum_member(e, value, enum["values"][value])
        
    for struct in yaml["structs"]:
        fullname = struct["type"]
        ida_struct.del_struc(ida_struct.get_struc(ida_struct.get_struc_id(fullname)))
        ida_struct.add_struc(-1, fullname)

    for struct in yaml["structs"]:
        fullname = struct["type"]
        name = struct["name"]
        size = struct["size"]
        s = ida_struct.get_struc(ida_struct.get_struc_id(fullname))
        for field in struct["fields"]:
            offset = field["offset"]
            field_name = field["name"]
            field_type = field["type"]
            if field_type == '__fastcall':
                continue
            ida_struct.add_struc_member(s, field_name, offset, get_idc_type_from_ida_type(field_type), None, get_size_from_ida_type(field_type))
            meminfo = ida_struct.get_member_by_name(s, field_name)
            ida_struct.set_member_tinfo(s, meminfo, 0, get_tinfo_from_type(field_type), 0)

    for struct in yaml["structs"]:
        fullname = struct["type"]
        name = struct["name"]
        size = struct["size"]
        ida_struct.del_struc(ida_struct.get_struc(ida_struct.get_struc_id(fullname + "_VTable")))
        s = ida_struct.get_struc(ida_struct.add_struc(-1, fullname + "_VTable"))
        for virt_func in struct["virtual_functions"]:
            offset = virt_func["offset"]
            field_name = virt_func["name"]
            field_type = virt_func["type"]
            ida_struct.add_struc_member(s, field_name, offset, get_idc_type_from_ida_type(field_type), None, get_size_from_ida_type(field_type))
            meminfo = ida_struct.get_member_by_name(s, field_name)
            ida_struct.set_member_tinfo(s, meminfo, 0, get_tinfo_from_type(field_type), 0)
            ida_bytes.create_data(offset, get_idc_type_from_ida_type(field_type), get_size_from_ida_type(field_type), ida_ida.struflag())
            ida_bytes.opinfo_t(get_opinfo_from_type(field_type))


run()
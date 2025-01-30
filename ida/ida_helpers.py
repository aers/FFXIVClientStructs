import idaapi
import ida_typeinf
import idc
import ida_bytes
import ida_ida

def get_tinfo_by_tid(tid):
    #type: (int) -> idaapi.tinfo_t
    tif = ida_typeinf.tinfo_t()
    if tif.get_type_by_tid(tid):
        return tif
    return None

def get_struc_tinfo_by_tid(struct_tid):
    #type: (int) -> idaapi.tinfo_t
    tif = get_tinfo_by_tid(struct_tid)
    if tif is not None and (tif.is_struct() or tif.is_union()):
        return tif
    return None

def clean_struct_name(name):
    # type: (str) -> str
    if name == "Tm":
        return "tm" # tm is a keyword in IDA for the time struct but C# exports it as Tm
    return (
        name.replace(" ", "")
        .replace("unsigned", "u")
        .replace("__int64", "long")
        .replace("__int32", "int")
        .replace("__int16", "short")
        .replace("__int8", "byte")
    )
    
def get_named_type(name):
    # type: (str) -> idaapi.tinfo_t
    tinfo = ida_typeinf.tinfo_t()
    clean_name = clean_struct_name(name)
    if (
        idc.get_struc_id(clean_name)
        != idaapi.BADADDR
        or 
        idc.get_enum(clean_name)
        != idaapi.BADADDR
    ):
        if not tinfo.get_named_type(idaapi.get_idati(), clean_name):
            raise ValueError("{0} not found in IDA database".format(clean_name))
            
        return tinfo


    if name == "void":
        idaapi.parse_decl(
            tinfo, idaapi.get_idati(), "void (__fastcall)();", idaapi.PT_SIL
        )
        return tinfo.get_rettype()

    terminated = name + ";"
    idaapi.parse_decl(tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL)

    tinfo_str = tinfo.dstr()
    if tinfo_str == name or tinfo_str == clean_name:
        return tinfo

    terminated = clean_name + ";"
    idaapi.parse_decl(tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL)
    return tinfo

def get_tinfo_from_type(raw_type, array_size=0):
    # type: (str, int) -> idaapi.tinfo_t
    """
    Retrieve a tinfo_t from a raw type string.
    """

    type = raw_type.rstrip("*")
    ptr_count = len(raw_type) - len(type)

    type_tinfo = get_named_type(type)

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

def get_idc_type_from_ida_type(type):
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
    elif type == "unsigned __int16" or type == "__int16" or type == "wchar_t":
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
    elif type == "double":
        return ida_bytes.double_flag()
    elif idc.get_struc_id(type) == idaapi.BADADDR:
        return ida_bytes.enum_flag()
    else:
        return ida_bytes.stru_flag()
    
def search_binary(ea, pattern, flag=ida_bytes.BIN_SEARCH_FORWARD|ida_bytes.BIN_SEARCH_NOSHOW):
    # type: (int, str, int) -> int
    return ida_bytes.find_bytes(pattern, ea, range_end=ida_ida.inf_get_max_ea(), flags=flag)

def create_udm(name, offset, typ):
    # type: (str, int, idaapi.tinfo_t) -> idaapi.udm_t
    udm = ida_typeinf.udm_t()
    udm.name = name
    udm.offset = offset*8
    udm.type = typ
    udm.size = typ.get_size()*8
    return udm

def get_idc_type_from_size(size):
    # type: (int) -> int
    if size == 1:
        return ida_bytes.byte_flag()
    elif size >= 2 and size < 4:
        return ida_bytes.word_flag()
    elif size >= 4 and size < 8:
        return ida_bytes.dword_flag()
    else:
        return ida_bytes.qword_flag()

def get_idc_type_from_size(size, offset=0):
    # type: (int, int) -> int
    if offset % 8 == 0 and size >= 8:
        return ida_bytes.qword_flag()
    elif offset % 4 == 0 and size >= 4:
        return ida_bytes.dword_flag()
    elif offset % 2 == 0 and size >= 2:
        return ida_bytes.word_flag()
    else:
        return ida_bytes.byte_flag()

def get_size_from_idc_type(type):
    # type: (int) -> int
    if type == ida_bytes.byte_flag():
        return 1
    elif type == ida_bytes.word_flag():
        return 2
    elif type == ida_bytes.dword_flag():
        return 4
    elif type == ida_bytes.qword_flag():
        return 8
    elif type == ida_bytes.float_flag():
        return 4
    elif type == ida_bytes.double_flag():
        return 8
    else:
        return 0

def delete_struct_members(fullname):
    # type: (str) -> None
    s = get_tinfo_from_type(fullname)
    if s is None or s == idc.BADADDR or s.is_empty_udt():
        return
    s.del_udms(0, s.get_udt_nmembers())
import idaapi
import idc
import ida_bytes
import ida_nalt
import ida_kernwin
import ida_search
import ida_ida
import ida_typeinf
import ida_hexrays
import ida_name
import ida_funcs
from structs_schema import *

from abc import abstractmethod

# For more information about TERR_ constants, see:
# https://docs.hex-rays.com/developer-guide/idapython/idapython-porting-guide-ida-9#type-information-error-codes

class BaseIdaInterface(object):
    @abstractmethod
    def get_struct_id(self, name):
        pass

    @abstractmethod
    def get_enum_id(self, name):
        pass

    @abstractmethod
    def delete_enum_members(self, eid: int):
        """Remove all enum members

        Args:
            eid (int): The id of the enum
        """
        pass

    def enum_exists(self, name: str):
        return self.get_enum_id(name) != idaapi.BADADDR

    def get_idc_type_from_ida_type(self, type: str):
        """Retrieve the idc type from the ida type.

        Args:
            type (str): Name of the type.
        """
        if (
            type == "unsigned byte"
            or type == "unsigned char"
            or type == "unsigned __int8"
            or type == "ubyte"
            or type == "byte"
            or type == "bool"
            or type == "char"
            or type == "uchar"
            or type == "__int8"
        ):
            return ida_bytes.byte_flag()
        elif (
            type == "unsigned short"
            or type == "ushort"
            or type == "unsigned __int16"
            or type == "short"
            or type == "__int16"
            or type == "_WORD"
            or type == "wchar_t"
        ):
            return ida_bytes.word_flag()
        elif (
            type == "unsigned int"
            or type == "unsigned __int32"
            or type == "uint"
            or type == "int"
            or type == "__int32"
            or type == "_DWORD"
        ):
            return ida_bytes.dword_flag()
        elif (
            type == "unsigned long"
            or type == "unsigned __int64"
            or type == "ulong"
            or type == "long"
            or type == "__int64"
            or type == "__fastcall"
            or type.endswith("*")
        ):
            return ida_bytes.qword_flag()
        elif type == "float":
            return ida_bytes.float_flag()
        elif type == "double":
            return ida_bytes.double_flag()
        elif self.get_enum_id(type) != idaapi.BADADDR:
            return ida_bytes.enum_flag()
        elif self.get_struct_id(type) != idaapi.BADADDR:
            return ida_bytes.stru_flag()
        else:
            return ida_bytes.stru_flag()

    def get_idc_type_from_size(self, size: int, offset=0):
        if offset == 0:
            offset = size
        if offset % 8 == 0 and size >= 8:
            return ida_bytes.qword_flag()
        elif offset % 4 == 0 and size >= 4:
            return ida_bytes.dword_flag()
        elif offset % 2 == 0 and size >= 2:
            return ida_bytes.word_flag()
        else:
            return ida_bytes.byte_flag()

    def get_size_from_idc_type(self, type: int):
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

    def is_signed(self, type: str):
        if (
            type == "__int8"
            or type == "__int16"
            or type == "__int32"
            or type == "__int64"
            or type == "int"
        ):
            return True
        else:
            return False

    def get_size_from_ida_type(self, type: str):
        return self.get_size_from_idc_type(self.get_idc_type_from_ida_type(type))

    def clean_name(self, name: str):
        """Clean a name

        Args:
            name (str): The name

        Returns:
            str: The cleaned name
        """
        return name

    def clean_struct_name(self, name: str):
        """Clean a struct name

        Args:
            name (str): The struct name

        Returns:
            str: The cleaned struct name
        """

        if name == "Tm":
            return "tm"  # tm is a keyword in IDA for the time struct but C# exports it as Tm
        return (
            name.replace(" ", "")
            .replace("unsigned", "u")
            .replace("__int64", "long")
            .replace("__int32", "int")
            .replace("__int16", "short")
            .replace("__int8", "byte")
        )

    def get_named_type(self, name: str):
        """Retrieve a tinfo_t from the named type.

        Args:
            name (str): Name of the type.
        """

        tinfo = ida_typeinf.tinfo_t()
        clean_name = self.clean_struct_name(name)
        if (
            self.get_struct_id(clean_name) != idaapi.BADADDR
            or self.get_enum_id(clean_name) != idaapi.BADADDR
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

    def get_tinfo_from_type(self, raw_type: str, array_size=0):
        """Retrieve a tinfo_t from a raw type string.

        Args:
            raw_type (str): Raw type string.
            array_size (int, optional): Size of the array. Defaults to 0.
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

    def rename_struct(self, sid: int, new_name: str):
        """Rename a struct in IDA.

        Args:
            sid (int): The struct ID.
            new_name (str): The new struct name.
        """
        idc.set_struc_name(sid, new_name)
        

if idaapi.IDA_SDK_VERSION < 900:
    import ida_struct # pyright: ignore[reportMissingImports]
    import ida_enum # pyright: ignore[reportMissingImports]
else:
    print("Using IDA 9+ API")

class IdaInterface(BaseIdaInterface):
    # This is only for IDA 7 and 8 due to a change in the API for IDA 9
    if idaapi.IDA_SDK_VERSION < 900 and idaapi.IDA_SDK_VERSION >= 700:

        def get_tinfo_from_func_data(self, data: DefinedStructFuncField):
            """Retrieve a tinfo_t from a raw function data.

            Args:
                data (DefinedStructFuncField): Function data.

            Returns:
                idaapi.tinfo_t: tinfo_t created from the function data.
            """
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

        def get_struct_opinfo_from_type(self, raw_type: str):
            """Retrieve an opinfo_t from a raw structure type string.

            Args:
                raw_type (str): Raw structure type string.

            Returns:
                ida_nalt.opinfo_t: opinfo_t created from the structure type string.
            """
            opinf = ida_nalt.opinfo_t()
            opinf.tid = ida_struct.get_struc_id(raw_type)
            return opinf

        def get_enum_opinfo_from_type(self, raw_type: str):
            """Retrieve an opinfo_t from a raw enum type string.

            Args:
                raw_type (str): Raw enum type string.

            Returns:
                ida_nalt.opinfo_t: opinfo_t created from the enum type string.
            """
            opinf = ida_nalt.opinfo_t()
            opinf.ec.tid = ida_enum.get_enum(raw_type)
            return opinf

        def search_binary(self, ea: int, pattern: str, flag: int):
            """Search for a pattern in a binary

            Args:
                ea (int): The address to start searching from
                pattern (str): The pattern to search for
                flag (int): The search flags

            Returns:
                int: The start address of the pattern
            """
            return ida_search.find_binary(
                ea,
                flag & 1 and ida_ida.cvar.inf.max_ea or ida_ida.cvar.inf.min_ea,
                pattern,
                16,
                flag,
            )

        def get_dword(self, ea: int):
            """Retrieve a dword (32-bit value) from the specified address.

            Args:
                ea (int): The effective address to read the dword from.

            Returns:
                int: The dword value read from the given address.
            """
            return ida_bytes.get_original_dword(ea)

        def get_func_ea_by_name(self, name: str):
            """Retrieve the effective address of a function by its name.

            Args:
                name (str): The name of the function.

            Returns:
                int: The effective address of the function.
            """
            return ida_name.get_name_ea(0, name)

        def get_func_ea_by_sig(self, pattern: str):
            """Retrieve the effective address of a function by its signature.

            Args:
                pattern (str): The signature of the function.

            Returns:
                int: The effective address of the function.
            """
            ea = self.search_binary(0, pattern, ida_search.SEARCH_DOWN)

            if ida_funcs.get_func(ea) is None:
                finf = ida_funcs.func_t()
                finf.start_ea = ea
                finf.end_ea = idc.BADADDR
                ida_funcs.add_func_ex(finf)

            if ida_funcs.get_func(ea) is None:
                return idc.BADADDR

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

            return idc.BADADDR

        def opTypeAsName(self, n: int):
            """
            Retrieve the name of the operand type constant.

            Args:
                n (int): The integer value of the operand type.

            Returns:
                str: The name of the operand type constant if found; otherwise, None.
            """

            for item in [x for x in dir(idc) if x.startswith("o_")]:
                if getattr(idc, item) == n:
                    return item

        def create_struct_type(self, name: str, union: bool = False) -> int:
            """Create a struct type

            Args:
                name (str): The name of the struct
                union (bool, optional): Whether the struct is a union. Defaults to False.

            Returns:
                int: The struct id
            """
            return ida_struct.add_struc(idc.BADADDR, name, union)

        def get_struct_id(self, name: str) -> int:
            """Get the struct id

            Args:
                name (str): The name of the struct

            Returns:
                int: The struct id
            """
            return ida_struct.get_struc_id(name)

        def get_struct(self, sid: int) -> ida_struct.struc_t:
            """Get the struct

            Args:
                sid (int): The struct id

            Returns:
                ida_struct.struc_t: The struct
            """
            return ida_struct.get_struc(sid)

        def get_struct_size(self, sid: ida_struct.struc_t) -> int:
            """Get the struct size

            Args:
                sid (ida_struct.struc_t): The struct

            Returns:
                int: The struct size
            """
            return ida_struct.get_struc_size(sid)

        def create_struct_member(
            self,
            sid: ida_struct.struc_t,
            name: str,
            offset: int = -1,
            flag: int = idc.FF_DATA | idc.FF_QWORD,
            typeid: int | None = None,
            nbytes: int = 8,
        ):
            """Create a struct member

            Args:
                sid (ida_struct.struc_t): The struct to add the member to
                name (str): The name of the member
                offset (int, optional): The offset of the member. Defaults to -1.
                flag (int, optional): The type flag of the member. Defaults to idc.FF_DATA | idc.FF_QWORD.
                typeid (int | None, optional): The type id of the member. Defaults to None.
                nbytes (int, optional): The number of bytes of the member. Defaults to 8.

            Returns:
                struc_error_t: Unknown IDA documentation for this
            """
            return ida_struct.add_struc_member(sid, name, offset, flag, typeid, nbytes)

        def remove_struct_member(self, sid: int, name: str) -> bool:
            """Remove a struct member

            Args:
                sid (int): The struct id
                name (str): The name of the member

            Returns:
                bool: True if successful
            """
            return ida_struct.del_struc_member(sid, name)

        def remove_struct_members(self, sid: int) -> int:
            """Remove all struct members

            Args:
                sid (int): The struct id

            Returns:
                int: The number of members removed or -1 if failed
            """
            return ida_struct.del_struc_members(
                ida_struct.get_struc(sid),
                0,
                ida_struct.get_struc_size(sid) + 1,
            )

        def get_struct_member(
            self, sid: ida_struct.struc_t, offset: int
        ) -> ida_struct.member_t:
            """Get a struct member

            Args:
                sid (ida_struct.struc_t): The struct
                offset (int): The offset of the member

            Returns:
                ida_struct.member_t: The member data
            """
            return ida_struct.get_member(sid, offset)

        def get_struct_member_by_name(
            self, sid: ida_struct.struc_t, name: str
        ) -> ida_struct.member_t:
            """Get a struct member

            Args:
                sid (ida_struct.struc_t): The struct
                name (str): The name of the member

            Returns:
                ida_struct.member_t: The member data
            """
            return ida_struct.get_member_by_name(sid, name)

        def set_struct_member_info(
            self,
            sid: ida_struct.struc_t,
            member: ida_struct.member_t,
            offset: int,
            tif: ida_typeinf.tinfo_t,
            flag: int = 0,
        ):
            """Set the info of a struct member

            Args:
                sid (ida_struct.struc_t): The struct
                member (ida_struct.member_t): The member
                offset (int): The offset in the member
                tif (ida_typeinf.tinfo_t): The type info
                flag (int, optional): The flag of the member type. Defaults to 0.

            Returns:
                smt_code_t: Unknown IDA documentation
            """
            return ida_struct.set_member_tinfo(sid, member, offset, tif, flag)

        def get_struct_member_id(self, sid: ida_struct.struc_t, offset: int) -> int:
            """Get the member id

            Args:
                sid (ida_struct.struc_t): The struct
                offset (int): The offset of the member in the struct

            Returns:
                int: The member id inside of the struct
            """
            return ida_struct.get_member_id(sid, offset)

        def get_base_class_flag(self):
            """Get the base class flag

            Returns:
                int: The flag for the base class type
            """
            return ida_struct.MF_BASECLASS

        def get_enum_id(self, name: str):
            """Get the id of an enum by its name

            Args:
                name (str): The name of the enum

            Returns:
                int: The id of the enum
            """
            return ida_enum.get_enum(name)

        def remove_enum_member(self, eid: int, value: str, name: str):
            """Remove an enum member by its value and name

            Args:
                eid (int): The id of the enum
                value (str): The value of the enum member
                name (str): The name of the enum member
            """
            mem = ida_enum.get_enum_member_by_name("{0}.{1}".format(name, value))
            ida_enum.del_enum_member(
                eid,
                ida_enum.get_enum_member_value(mem),
                ida_enum.get_enum_member_serial(mem),
                ida_enum.get_enum_member_bmask(mem),
            )

        def delete_enum_members(self, eid: int):
            """Remove all enum members

            Args:
                eid (int): The id of the enum
            """

            masks = [ -1 ]
            if idc.is_bf(eid):
                mask = idc.get_first_bmask(eid)
                while mask != idaapi.DEFMASK:
                    masks.append(mask)
                    mask = idc.get_next_bmask(eid, mask)

            members = []
            for mask in masks:
                mem_val = idc.get_first_enum_member(eid, mask)
                while mem_val != idaapi.BADNODE:
                    cid = ida_enum.get_first_serial_enum_member(eid, mem_val, mask)
                    members.append(cid[0])
                    mem_val = idc.get_next_enum_member(eid, mem_val, mask)

            for cid in members:
                ida_enum.del_enum_member(
                    eid,
                    ida_enum.get_enum_member_value(cid),
                    ida_enum.get_enum_member_serial(cid),
                    ida_enum.get_enum_member_bmask(cid)
                )
                
        def create_enum(self, name: str) -> int:
            """Create an enum by its name

            Args:
                name (str): The name of the enum

            Returns:
                int: The id of the added enum
            """
            return ida_enum.add_enum(idc.BADADDR, name, 0)

        def set_enum_width(self, eid: int, width: int):
            """Set the width of an enum by its id

            Args:
                eid (int): The id of the enum
                width (int): The width of the enum
            """
            ida_enum.set_enum_width(eid, width)

        def set_enum_flag(self, eid: int, flag: int):
            """Set a flag on an enum by its id

            Args:
                eid (int): The id of the enum
                flag (int): The flag to set
            """
            ida_enum.set_enum_flag(eid, flag)

        def get_enum_default_mask(self, eid: int):
            """Get the default bitmask for an enum

            Args:
                eid (int): The id of the enum

            Returns:
                int: The default bitmask for the enum
            """
            width = idc.get_enum_width(eid)
            mask = (1 << (width * 8)) - 1

            if mask == ida_enum.DEFMASK:
                mask >>= 1
            
            return mask
        
        def get_enum_name(self, eid: int):
            return idc.get_enum_name(eid)
        
        def get_enum_bf(self, eid: int):
            return ida_enum.is_bf(eid)

        def set_enum_as_bf(self, eid: int):
            ida_enum.set_enum_bf(eid, True)

            name = self.get_enum_name(eid)
            bmask = self.get_enum_default_mask(eid)

            # this shouldn't happen under normal circumstances
            if ida_enum.get_bmask_name(eid, bmask) == f"{name}_Mask":
                return

            ida_enum.set_bmask_name(eid, bmask, f"{name}_Mask")

        def add_enum_member(self, eid: int, name: str, value: int, mask: int = -1):
            """Add an enum member to an enum by its id
            Args:
                eid (int): The id of the enum
                name (str): The name of the enum member
                value (int): The value of the enum member
                mask (int): The bitmask of the enum member, or -1 to use the default mask
            """
            if mask == -1 and self.get_enum_bf(eid):
                mask = self.get_enum_default_mask(eid)

            # print(f"Adding value: {value} with name: {name} and mask: {mask}")
            ec = ida_enum.add_enum_member(eid, name, value, mask)
            # print(f"Got error code: {ec}")
            
            if ec == ida_enum.ENUM_MEMBER_ERROR_MASK:
                ida_enum.add_enum_member(eid, name, value)

        def get_struct_flag(self):
            """Get the flag for a struct data type

            Returns:
                int: The flag for a struct data type
            """
            return ida_bytes.stru_flag()

        def get_enum_flag(self):
            """Get the flag for an enum data type

            Returns:
                int: The flag for an enum data type
            """
            return ida_bytes.enum_flag()

    elif idaapi.IDA_SDK_VERSION >= 900:

        def get_tinfo_from_func_data(self, data: DefinedStructFuncField):
            """Retrieve a tinfo_t from a raw function data.

            Args:
                data (DefinedStructFuncField): Function data.

            Returns:
                idaapi.tinfo_t: tinfo_t created from the function data.
            """
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

        def get_struct_opinfo_from_type(self, raw_type: str):
            """Retrieve an opinfo_t from a raw structure type string.

            Args:
                raw_type (str): Raw structure type string.

            Returns:
                ida_nalt.opinfo_t: opinfo_t created from the structure type string.
            """
            opinf = ida_nalt.opinfo_t()
            opinf.tid = ida_typeinf.get_named_type_tid(raw_type)
            
            return opinf

        def get_enum_opinfo_from_type(self, raw_type: str):
            """Retrieve an opinfo_t from a raw enum type string.

            Args:
                raw_type (str): Raw enum type string.

            Returns:
                ida_nalt.opinfo_t: opinfo_t created from the enum type string.
            """
            opinf = ida_nalt.opinfo_t()
            opinf.ec.tid = idc.get_enum(raw_type)
            
            return opinf

        def search_binary(self, ea: int, pattern: str, flag: int):
            """Search for a pattern in a binary

            Args:
                ea (int): The address to start searching from
                pattern (str): The pattern to search for
                flag (int): The search flags

            Returns:
                int: The start address of the pattern
            """
            return ida_bytes.find_bytes(
                pattern, ea, None, ida_ida.inf_get_max_ea(), None, flag
            )

        def get_dword(self, ea: int):
            """Retrieve a dword (32-bit value) from the specified address.

            Args:
                ea (int): The effective address to read the dword from.

            Returns:
                int: The dword value read from the given address.
            """
            return ida_bytes.get_original_dword(ea)

        def get_func_ea_by_name(self, name: str):
            """Retrieve the effective address of a function by its name.

            Args:
                name (str): The name of the function.

            Returns:
                int: The effective address of the function.
            """
            return ida_name.get_name_ea(0, name)

        def get_func_ea_by_sig(self, pattern: str):
            """Retrieve the effective address of a function by its signature.

            Args:
                pattern (str): The signature of the function.

            Returns:
                int: The effective address of the function.
            """
            ea = self.search_binary(0, pattern, ida_search.SEARCH_DOWN)

            if ida_funcs.get_func(ea) is None:
                finf = ida_funcs.func_t()
                finf.start_ea = ea
                finf.end_ea = idc.BADADDR
                ida_funcs.add_func_ex(finf)

            if ida_funcs.get_func(ea) is None:
                return idc.BADADDR

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

            return idc.BADADDR

        def opTypeAsName(self, n: int):
            """
            Retrieve the name of the operand type constant.

            Args:
                n (int): The integer value of the operand type.

            Returns:
                str: The name of the operand type constant if found; otherwise, None.
            """

            for item in [x for x in dir(idc) if x.startswith("o_")]:
                if getattr(idc, item) == n:
                    return item

        def create_struct_type(self, name: str, union: bool = False) -> int:
            """Create a struct type

            Args:
                name (str): The name of the struct
                union (bool, optional): Whether the struct is a union. Defaults to False.

            Returns:
                int: The struct id
            """

            udt = ida_typeinf.udt_type_data_t()
            udt.is_union = union

            tinfo = ida_typeinf.tinfo_t()
            if not tinfo.create_udt(udt):
                return idc.BADADDR
            
            if tinfo.set_named_type(None, name) != ida_typeinf.TERR_OK:
                return idc.BADADDR
            
            return tinfo.get_tid()

        def get_struct_id(self, name: str) -> int:
            """Get the struct id

            Args:
                name (str): The name of the struct

            Returns:
                int: The struct id
            """
            return ida_typeinf.get_named_type_tid(name)

        def get_struct(self, sid: int) -> ida_typeinf.tinfo_t:
            """Get the struct

            Args:
                sid (int): The struct id

            Returns:
                ida_typeinf.tinfo_t: The struct's parent tinfo_t
            """
            return ida_typeinf.tinfo_t(tid=sid)

        def get_struct_size(self, sid: ida_typeinf.tinfo_t | int) -> int:
            """Get the struct size

            Args:
                sid (ida_typeinf.tinfo_t): The struct

            Returns:
                int: The struct size
            """
            if isinstance(sid, int):
                sid = self.get_struct(sid)
            return sid.get_size()

        def create_struct_member(
            self,
            sid: ida_typeinf.tinfo_t,
            name: str,
            offset: int = -1,
            flag: int = idc.FF_DATA | idc.FF_QWORD,
            typeid: int | idaapi.opinfo_t | None = None,
            nbytes: int = 8,
        ):
            """Create a struct member

            Args:
                sid (ida_typeinf.tinfo_t): The struct to add the member to
                name (str): The name of the member
                offset (int, optional): The offset of the member. Defaults to -1.
                flag (int, optional): The type flag of the member. Defaults to idc.FF_DATA | idc.FF_QWORD.
                typeid (int | None, optional): The type id of the member. Defaults to None.
                nbytes (int, optional): The number of bytes of the member. Defaults to 8.

            Returns:
                bool: True if successful
            """

            if typeid is None:
                typeid = -1

            if isinstance(typeid, idaapi.opinfo_t):
                tinfo = ida_typeinf.tinfo_t()
                if tinfo.get_type_by_tid(typeid.tid):
                    nbytes = tinfo.get_size()
                else:
                    raise ValueError("Cannot find type with tid {0}".format(typeid.tid))
                
                typeid = typeid.tid
            
            ec = idc.add_struc_member(sid.get_tid(), name, offset, flag, typeid, nbytes)
            if ec != ida_typeinf.TERR_OK:
                return False

            return True

        def remove_struct_member(self, sid: int, name: str) -> bool:
            """Remove a struct member

            Args:
                sid (int): The struct id
                name (str): The name of the member

            Returns:
                tinfo_code_t: See ida_typeinfo.TERR_ constants
            """
            try:
                tinfo = ida_typeinf.tinfo_t(tid=sid)
                idx = tinfo.find_udm(name=name)
                if idx == -1:
                    return True
                
                return tinfo.del_udm(idx)
            except:
                return ida_typeinf.TERR_BAD_ARG

        def remove_struct_members(self, sid: int) -> int:
            """Remove all struct members

            Args:
                sid (int): The struct id

            Returns:
                int: The number of members removed or -1 if failed
            """
            try:
                tinfo = ida_typeinf.tinfo_t()
                if not tinfo.get_type_by_tid(sid):
                    return -1
                
                size = tinfo.get_udt_nmembers()
                tinfo.del_udms(0, size)
                return size
            except:
                return -1
            
        def get_struct_member(
            self, sid: ida_typeinf.tinfo_t, offset: int
        ) -> ida_typeinf.udm_t:
            """Get a struct member

            Args:
                sid (ida_typeinf.tinfo_t): The struct
                offset (int): The offset of the member

            Returns:
                ida_typeinf.udm_t: The member data
            """
            _, udm = sid.get_udm_by_offset(offset)
            return udm

        def get_struct_member_by_name(
            self, sid: ida_typeinf.tinfo_t, name: str
        ) -> ida_typeinf.udm_t:
            """Get a struct member

            Args:
                sid (ida_typeinf.tinfo_t): The struct
                name (str): The name of the member

            Returns:
                ida_typeinf.udm_t: The member data
            """
            _, udm = sid.get_udm(name)
            return udm

        def set_struct_member_info(
            self,
            sid: ida_typeinf.tinfo_t,
            member: ida_typeinf.udm_t,
            offset: int,
            tif: ida_typeinf.tinfo_t,
            flag: int = 0,
        ):
            """Set the info of a struct member

            Args:
                sid (ida_typeinf.tinfo_t): The struct
                member (ida_typeinf.udm_t): The member
                offset (int): The offset in the member
                tif (ida_typeinf.tinfo_t): The type info
                flag (int, optional): The flag of the member type. Defaults to 0.

            Returns:
                tinfo_code_t: See ida_typeinfo.TERR_ constants
            """
            if offset != 0:
                raise ValueError("IDA 9+ does not support offset != 0 in set_struct_member_info")
            
            memberIdx, _ = sid.get_udm_by_offset(member.offset)
            return sid.set_udm_type(index=memberIdx, tif=tif)

        def get_struct_member_id(self, sid: ida_typeinf.tinfo_t, offset: int) -> int:
            """Get the member id

            Args:
                sid (ida_typeinf.tinfo_t): The struct
                offset (int): The offset of the member in the struct

            Returns:
                int: The member id inside of the struct or -1 if not found
            """
            idx, _ = sid.get_udm_by_offset(offset)
            return idx

        def get_enum_id(self, name: str):
            """Get the id of an enum by its name

            Args:
                name (str): The name of the enum

            Returns:
                int: The id of the enum
            """
            
            return idc.get_enum(name)

        def remove_enum_member(self, eid: int, value: str, name: str):
            """Remove an enum member by its value and name

            Args:
                eid (int): The id of the enum
                value (str): The value of the enum member
                name (str): The name of the enum member
            """

            mem = idc.get_enum_member_by_name("{0}.{1}".format(name, value))
            if mem != idc.BADADDR and idc.get_enum_member_value(mem) != None:
                idc.del_enum_member(
                    eid,
                    idc.get_enum_member_value(mem),
                    0,
                    idc.get_enum_member_bmask(mem) or -1,
                )

        def delete_enum_members(self, eid: int):
            """Remove all enum members

            Args:
                eid (int): The id of the enum
            """
            tif = ida_typeinf.tinfo_t()
            if not tif.get_type_by_tid(eid):
                raise RuntimeError(f'Failed to get tinfo_t for enum {eid}')

            eti = ida_typeinf.enum_type_data_t()
            if not tif.get_enum_details(eti):
                raise RuntimeError(f'Failed to get enum details for enum id {eid}')
            
            # must clear values before groups

            values = []
            for (idx, _, _) in eti.all_constants():
                values.append(eti[idx].name)

            for name in values:
                tif.del_edm(name)

            groups = []
            for (idx, _) in eti.all_groups():
                groups.append(eti[idx].name)

            for name in groups:
                tif.del_edm(name)

        def create_enum(self, name: str) -> int:
            """Create an enum by its name

            Args:
                name (str): The name of the enum

            Returns:
                int: The id of the added enum
            """
            return idc.add_enum(0, name, 0)

        def set_enum_width(self, eid: int, width: int):
            """Set the width of an enum by its id

            Args:
                eid (int): The id of the enum
                width (int): The width of the enum
            """
            # TODO(caitlyn): handle changing the width of a bitfield enum

            idc.set_enum_width(eid, width)

        def get_enum_default_mask(self, eid: int):
            """Get the default bitmask for an enum

            Args:
                eid (int): The id of the enum

            Returns:
                int: The default bitmask for the enum
            """
            width = idc.get_enum_width(eid)
            mask = (1 << (width * 8)) - 1

            # IDA 9+ has an issue wherein the default mask for 64-bit
            # enums is equal to DEFMASK64. This causes issues when
            # creating and assigning members to the default group.
            #
            # To work around this, we drop the highest order bit
            # from the default group for 64-bit enums.
            if mask == ida_typeinf.DEFMASK64:
                mask >>= 1
            
            return mask

        def set_enum_flag(self, eid: int, flag: int):
            """Set a flag on an enum by its id

            Args:
                eid (int): The id of the enum
                flag (int): The flag to set
            """
            idc.set_enum_flag(eid, flag)
        
        def get_enum_bf(self, eid: int):
            return idc.is_bf(eid)
        
        def get_enum_name(self, eid: int):
            return idc.get_enum_name(eid)
        
        def get_enum_bitmask_field(self, eid: int):
            name = self.get_enum_name(eid)
            bmask = self.get_enum_default_mask(eid)

            return (f"{name}_Mask", bmask)

        def set_enum_as_bf(self, eid: int):
            if idc.is_bf(eid):
                return
            
            idc.set_enum_bf(eid, True)

            (name, bmask) = self.get_enum_bitmask_field(eid)

            # this shouldn't happen under normal circumstances
            if idc.get_enum_member_by_name(f"{name}_Mask") != idaapi.BADADDR:
                return

            idc.add_enum_member(eid, f"{name}_Mask", bmask, bmask)

        def add_enum_member(self, eid: int, name: str, value: int, mask: int = -1):
            """Add an enum member to an enum by its id
            Args:
                eid (int): The id of the enum
                name (str): The name of the enum member
                value (int): The value of the enum member
                mask (int): The bitmask of the enum member, or -1 to use the default mask
            """

            if mask == -1 and idc.is_bf(eid):
                mask = self.get_enum_default_mask(eid)

            # IDA 9+ requires all enum member names be unique across the DB.
            # We attempt to avoid collisions by appending up to 3 underscores to the name.
            retries = 0
            processedName = name
            while idc.get_enum_member_by_name(processedName) != idaapi.BADADDR:
                if retries >= 3:
                    raise RuntimeError(f"Error: too many duplicate enum member names for '{name}'")
                retries += 1
                processedName += "_"
            
            # IDA 9.0 - 9.2 vary in how they handle errors.
            # IDA 9.0 will return a TERR_ code, while IDA 9.2 will raise an exception.
            # This will effectively convert the TERR_ to an equivalent ValueError for 9.0.
            ec = idc.add_enum_member(eid, processedName, value, mask)
            if ec != ida_typeinf.TERR_OK:
                raise ValueError(ida_typeinf.tinfo_errstr(ec))

        def get_struct_flag(self):
            """Get the flag for a struct data type

            Returns:
                int: The flag for a struct data type
            """
            return ida_bytes.stru_flag()

        def get_enum_flag(self):
            """Get the flag for an enum data type

            Returns:
                int: The flag for an enum data type
            """
            return ida_bytes.enum_flag()
    else:
        raise RuntimeError("Unsupported IDA version")
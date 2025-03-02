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
import ida_name
import ida_funcs
from data_schema import *


class IdaInterface(object):
    def get_idc_type_from_ida_type(self, type: str):
        """Retrieve the idc type from the ida type.

        Args:
            type (str): Name of the type.
        """
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

    def get_named_type(self, name: str):
        """Retrieve a tinfo_t from the named type.

        Args:
            name (str): Name of the type.
        """

        tinfo = ida_typeinf.tinfo_t()
        clean_name = self.clean_struct_name(name)
        if (
            ida_struct.get_struc_id(clean_name) != idaapi.BADADDR
            or ida_enum.get_enum(clean_name) != idaapi.BADADDR
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

    def get_tinfo_from_func_data(self, data: DefinedFuncField):
        """Retrieve a tinfo_t from a raw function data.

        Args:
            data (DefinedFuncField): Function data.

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
                    "Error: Can't follow opType0 {0}".format(self.opTypeAsName(opType0))
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

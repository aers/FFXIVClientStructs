import idaapi
import idc
import ida_bytes
import ida_nalt
import ida_search
import ida_ida
import ida_idp
import ida_typeinf
import ida_name
import ida_funcs
import ida_srclang
import ida_kernwin
from structs_schema import *
from form_builder import DynamicForm
from data_schema import get_yaml, DefinedData, DefinedDataClassVtable

from abc import abstractmethod
from platform import system
from pathlib import Path
from webbrowser import open as webopen
import os

def pick_folder(form_content: list[dict[str, any]]) -> str | None:
    f = DynamicForm(form_content)
    f.Compile()
    try:
        if f.Execute() == 1:          # 1 = OK, 0 = Cancel
            return f.folder.value or None
        return None
    finally:
        f.Free()
        
fields = [
  { "type": "label", "text": "Select msvc"},
  { "type": "space" },
  { "type": "label", "text": "It should be located where you used:", "prepend": True},
  { "type": "button", "key": "msvcdownload", "label": "mstorsjo/msvc-wine", "on_click": lambda: webopen("https://github.com/mstorsjo/msvc-wine")},
  { "type": "space" },
  { "type": "folder", "key": "folder", "label": "Folder", "value": "", "tip": "Pick the folder where ./vsdownload.sh was run" }
]

def first_subfolder(base: Path) -> Path | None:
    for p in sorted(base.iterdir()):
        if p.is_dir():
            return p
    return None

def _get_ida_major() -> int:
    return idaapi.IDA_SDK_VERSION // 100

if _get_ida_major() < 9:
    raise "Unsupported IDA version used. Need to be on IDA 9 or newer."

class IdaInterface(object):
    data_yaml: DefinedData

    def get_base_path(self):
        return os.path.join(
            os.path.dirname(os.path.realpath(__file__)), ".."
        )

    def get_data_path(self):
        return os.path.join(self.get_base_path(), "data.yml")

    def load_data_yml(self):
        with open(self.get_data_path()) as f:
            self.data_yaml = get_yaml(f)

    def get_struct_path(self):
        return os.path.join(self.get_base_path(), "ffxiv_structs.yml")

    def get_enum_id(self, name: str):
        """Get the id of an enum by its name

        Args:
            name (str): The name of the enum

        Returns:
            int: The id of the enum
        """

        return idc.get_enum(name)

    def get_struct_id(self, name: str) -> int:
        """Get the struct id

        Args:
            name (str): The name of the struct

        Returns:
            int: The struct id
        """
        return ida_typeinf.get_named_type_tid(name)

    def get_named_type(self, name: str):
        """Retrieve a tinfo_t from the named type.

        Args:
            name (str): Name of the type, or any declaration IDA can parse.

        Returns:
            tinfo_t | None: The type, None if IDA does not know it.
        """

        tinfo = ida_typeinf.tinfo_t()
        if tinfo.get_named_type(idaapi.get_idati(), name):
            return tinfo

        if name == "void":
            return ida_typeinf.tinfo_t(ida_typeinf.BT_VOID)

        if name == "__fastcall":
            # function pointer parameters are exported without their signature
            name = "void (__fastcall *)()"

        if "<" in name and tinfo.get_named_type(
            idaapi.get_idati(), get_template_alias(name)
        ):
            # use the type behind the typedef so IDA shows the real name
            target = ida_typeinf.tinfo_t()
            if target.get_named_type(idaapi.get_idati(), tinfo.get_final_type_name()):
                return target
            return tinfo

        terminated = name.rstrip(";") + ";"
        if idaapi.parse_decl(tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL) is None:
            return None

        return tinfo

    def get_tinfo_from_type(self, raw_type: str, array_size=0):
        """Retrieve a tinfo_t from a raw type string.

        Args:
            raw_type (str): Raw type string.
            array_size (int, optional): Size of the array. Defaults to 0.

        Returns:
            tinfo_t | None: The type, None if it could not be built.
        """

        type = raw_type.rstrip("*")
        ptr_count = len(raw_type) - len(type)

        tinfo = self.get_named_type(type)
        if tinfo is None:
            return None

        for _ in range(ptr_count):
            ptr_tinfo = idaapi.tinfo_t()
            if not ptr_tinfo.create_ptr(tinfo):
                return None
            tinfo = ptr_tinfo

        if array_size > 0:
            array_tinfo = idaapi.tinfo_t()
            if not array_tinfo.create_array(tinfo, array_size):
                return None
            tinfo = array_tinfo

        return tinfo

    def apply_func_type(self, ea: int, func_name: str, return_type: str, parameters: list[DefinedStructFuncParam]) -> bool:
        """Apply a __fastcall prototype built from the yml types to a function.

        Returns:
            bool: False if one of the types is not known to IDA.
        """
        func_data = ida_typeinf.func_type_data_t()
        func_data.cc = ida_typeinf.CM_CC_FASTCALL

        rettype = self.get_tinfo_from_type(return_type)
        if rettype is None:
            print(f"Error: {func_name} @ {ea:#x} has unknown return type {return_type!r}")
            return False
        func_data.rettype = rettype

        for param in parameters:
            arg = ida_typeinf.funcarg_t()
            arg_type = self.get_tinfo_from_type(param.type)
            if arg_type is None:
                print(f"Error: {func_name} @ {ea:#x} has unknown type {param.type!r} on parameter {param.name!r}")
                return False
            arg.type = arg_type
            arg.name = param.name
            func_data.push_back(arg)

        tif = ida_typeinf.tinfo_t()
        if not tif.create_func(func_data):
            print(f"Error: {func_name} @ {ea:#x} failed to create its function type")
            return False
        if not ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE):
            print(f"Error: {func_name} @ {ea:#x} failed to apply {tif.dstr()!r}")
            return False
        return True

    def allow_template_type_names(self):
        """Allow the characters clang puts in template instantiation names.

        Names such as 'std::vector<int, std::allocator<int>>::_Reallocation_guard2'
        contain spaces, which TypeNameChars rejects by default (and which the
        idauser.cfg from this repository does not add). IDA then fails with
        "Failed to prepare forward declaration ... is not acceptable", and a
        single such error makes the clang parser drop every top level declaration.
        """
        ida_idp.process_config_directive(
            'TypeNameChars = "~.<>?!/,*&[]-+ "'
            '"_:$()`\'{}"'
            '"0123456789"'
            '"ABCDEFGHIJKLMNOPQRSTUVWXYZ"'
            '"abcdefghijklmnopqrstuvwxyz";'
        )

    def select_parser(self):
        """Sets the parser used for building struct data."""
        self.allow_template_type_names()
        includes = ""
        if system() != "Windows":
            path = pick_folder(fields)
            if path == None:
                raise "Has to have msvc includes for the parsers to work with the project"
            path = Path(path)
            vc_path = path / "vc" / "tools" / "msvc"
            vc_path = first_subfolder(vc_path) / "include"
            window_kit = first_subfolder(path / "kits" / "10" / "include")
            winsdk_ucrt_path = window_kit / "ucrt"
            winsdk_um_path = window_kit / "um"
            winsdk_shared_path = window_kit / "shared"
            includes = f" -I{vc_path.as_posix()} -I\"{winsdk_ucrt_path.as_posix()}\" -I\"{winsdk_um_path.as_posix()}\" -I\"{winsdk_shared_path.as_posix()}\""

        ida_srclang.set_parser_argv(
            "clang",
            f"-x c++ -target x86_64-pc-windows-msvc -fms-compatibility -fms-extensions -U__int64 -std=c++17{includes}",
        )

    def parse_string(self, decl: str, vtables: list[str]) -> int:
        """Parse declarations with the clang parser and mark the vtable types.

        Returns:
            int: The number of parser errors reported by IDA.
        """
        error_count = ida_srclang.parse_decls_with_parser("clang", None, decl, False)
        if error_count < 0:
            raise RuntimeError(
                "parse_decls_with_parser failed: the clang parser is not available"
            )
        if error_count > 0:
            print(f"Error: clang parser reported {error_count} error(s) while importing declarations")
        else:
            print("Clang parser imported declarations without errors")

        vtable_errors = []
        for vtable in vtables:
            error = self.mark_as_vtable(vtable)
            if error is not None:
                vtable_errors.append(error)
        for error in vtable_errors:
            print(f"Error: mark_as_vtable: {error}")
        print(f"Marked {len(vtables) - len(vtable_errors)}/{len(vtables)} vtables ({len(vtable_errors)} failed)")

        return error_count

    def op_type_as_name(self, n: int):
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
    
    def get_vft_from_data(self, class_name: str) -> DefinedDataClassVtable | None:
        class_data = self.data_yaml.classes.get(class_name)
        if class_data is None or not class_data.vtbls:
            return None

        return class_data.vtbls[0]

    def get_vfunc_ea_from_data(self, class_name: str, offset: int) -> int:
        vtable = self.get_vft_from_data(class_name)
        if vtable is None:
            return idc.BADADDR

        vtable_ea = vtable.ea + idaapi.get_imagebase() - 0x140000000
        return idc.get_qword(vtable_ea + offset)

    def set_func_name(self, ea, name, cmt):
        ida_name.set_name(ea, name)
        ida_bytes.set_cmt(ea, cmt, 0)

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

        if ida_funcs.get_func_start(ea) == idc.BADADDR:
            ida_funcs.add_func(ea)

        func_start = ida_funcs.get_func_start(ea)
        if func_start == idc.BADADDR:
            return idc.BADADDR

        if func_start == ea:
            return ea
        mnem = idc.print_insn_mnem(ea)
        if not mnem:
            return idc.BADADDR

        opType0 = idc.get_operand_type(ea, 0)
        if mnem == "jmp" or mnem == "call" or mnem[0] == "j":
            if opType0 != idc.o_near and opType0 != idc.o_mem:
                print(f"Error: Can't follow opType0 {self.op_type_as_name(opType0)}")
                return idc.BADADDR
            return idc.get_operand_value(ea, 0)

        if idc.next_head(ea) == ea + idc.get_item_size(ea) and idc.is_flow(
            idc.get_full_flags(idc.next_head(ea))
        ):
            return idc.next_head(ea)

        return idc.BADADDR

    def update_member_func(self, member_func: DefinedStructMemFunc, struct: DefinedStruct) -> None:
        func_name = f"{struct.type}.{member_func.name}"
        ea = self.get_func_ea_by_name(func_name)
        if ea == idc.BADADDR:
            ea = self.get_func_ea_by_sig(member_func.signature)
        if ea == idc.BADADDR:
            print(
                f"Error: {func_name} not found bad sig? {member_func.signature}"
            )
            return
        if ida_funcs.get_func_name(ea) == f"sub_{ea:X}":
            idc.set_name(ea, func_name)
        self.apply_func_type(ea, func_name, member_func.return_type, member_func.parameters)

    def update_virt_func(self, virt_func: DefinedStructVFunc, struct: DefinedStruct):
        func_name = f"{struct.type}.{virt_func.name}"

        ea = self.get_func_ea_by_name(func_name)
        if ea == idc.BADADDR:
            if self.get_vft_from_data(struct.type) is None:
                # no vtable address in data.yml, so there is no slot to look up
                return
            ea = self.get_vfunc_ea_from_data(struct.type, virt_func.offset)
            if ea in (0, idc.BADADDR):
                print(f"Error: {func_name} not found and its VFT slot could not be resolved")
                return

            actual_name = ida_funcs.get_func_name(ea) or ""
            normalized_name = actual_name
            for prefix in ("j_", "thunk_"):
                if normalized_name.startswith(prefix):
                    normalized_name = normalized_name[len(prefix):]

            if normalized_name == "_purecall":
                return

            primary_vtable = self.get_vft_from_data(struct.type)
            primary_base = primary_vtable.base if primary_vtable else None
            if primary_base:
                base_ea = self.get_vfunc_ea_from_data(primary_base, virt_func.offset)
                if base_ea == ea:
                    return

            if (
                normalized_name.endswith("." + virt_func.name)
                and not normalized_name.startswith(struct.type + ".")
            ):
                return
        self.apply_func_type(ea, func_name, virt_func.return_type, virt_func.parameters)

    def update_static_member(self, static_member: DefinedStructStaticMember, struct: DefinedStruct):
        ea = self.search_binary(
            0, static_member.signature, ida_search.SEARCH_DOWN
        )
        if ea == idc.BADADDR:
            print(f"Error: {static_member.signature} not found something is wrong")
            return
        for follows in static_member.relative_offsets:
            ea = ea + follows
            ea = ea + 4 + self.get_dword(ea)
        if ida_bytes.get_item_head(ea) != ea and static_member.return_type != struct.type:
            # points into an already typed item (ex. a field of the struct instance)
            return
        return_type = static_member.return_type
        if static_member.is_pointer:
            return_type = return_type + "*"
        tif = self.get_tinfo_from_type(return_type)
        if tif is None:
            print(f"Error: static member of {struct.type} @ {ea:#x} has unknown type {return_type!r}")
        else:
            ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)
        ida_name.set_name(ea, f"g_{struct.type}_{static_member.name}")
    
    def mark_as_vtable(self, vtbl_name: str) -> str | None:
        """
        Mark a struct as a vtable (TAUDT_VFTABLE).

        Returns:
            An error string on failure, None on success.
        """
        tif = ida_typeinf.tinfo_t()

        if not tif.get_named_type(None, vtbl_name):
            return f"Type '{vtbl_name}' not found in type library"

        if not tif.is_struct():
            actual = (
                "union" if tif.is_union() else "enum" if tif.is_enum() else "unknown"
            )
            return f"'{vtbl_name}' is not a struct (got {actual})"

        udt = ida_typeinf.udt_type_data_t()
        if not tif.get_udt_details(udt):
            return f"Failed to retrieve UDT details for '{vtbl_name}'"

        if udt.taudt_bits & ida_typeinf.TAUDT_VFTABLE:
            return None

        udt.taudt_bits |= ida_typeinf.TAUDT_VFTABLE

        if not tif.create_udt(udt, ida_typeinf.BTF_STRUCT):
            return (
                f"Failed to reconstruct UDT for '{vtbl_name}' after setting vtable flag"
            )

        result = tif.set_named_type(None, vtbl_name, ida_typeinf.NTF_REPLACE)

        if result != ida_typeinf.TERR_OK:
            return (
                f"Failed to write back '{vtbl_name}' to type library: "
                f"{ida_typeinf.tinfo_errstr(result)}"
            )

        return None
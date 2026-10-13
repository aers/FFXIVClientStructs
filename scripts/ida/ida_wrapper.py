import idaapi
import idc
import idautils
import ida_bytes
import ida_search
import ida_ida
import ida_idp
import ida_typeinf
import ida_name
import ida_funcs
import ida_srclang
import ida_hexrays
from structs_schema import *
from form_builder import DynamicForm
from data_schema import get_yaml, DefinedData, DefinedDataClassVtable

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
    BADADDR = idc.BADADDR

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
        return idc.get_enum(name)

    def get_struct_id(self, name: str) -> int:
        return ida_typeinf.get_named_type_tid(name)

    def get_named_type(self, name: str):
        """Returns None if IDA does not know the type."""
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
        """Returns None if the type could not be built."""
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
        """Returns False if one of the types is not known to IDA."""
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
        if not self.apply_tinfo(ea, tif):
            print(f"Error: {func_name} @ {ea:#x} failed to apply {tif.dstr()!r}")
            return False
        return True

    def apply_tinfo(self, ea: int, tif) -> bool:
        return ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

    def can_guess_func_type(self, ea: int) -> bool:
        """Returns False if IDA can not work out the type of the function, even after decompiling it."""
        tif, funcdata = ida_typeinf.tinfo_t(), ida_typeinf.func_type_data_t()

        ida_typeinf.guess_tinfo(tif, ea)
        if tif.get_func_details(funcdata):
            return True

        ida_hexrays.decompile(ea)
        ida_typeinf.guess_tinfo(tif, ea)
        return tif.get_func_details(funcdata)

    def allow_template_type_names(self):
        """clang puts spaces in template instantiation names, a single rejected name makes it drop every top level declaration."""
        ida_idp.process_config_directive(
            'TypeNameChars = "~.<>?!/,*&[]-+ "'
            '"_:$()`\'{}"'
            '"0123456789"'
            '"ABCDEFGHIJKLMNOPQRSTUVWXYZ"'
            '"abcdefghijklmnopqrstuvwxyz";'
        )

    def select_parser(self):
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
        """Returns the number of parser errors reported by IDA."""
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

        vtable_ea = vtable.ea + self.get_image_base() - 0x140000000
        return self.get_qword(vtable_ea + offset)

    def set_func_name(self, ea, name, cmt=None, unique=False):
        """
        :param unique: Only name functions IDA has not named yet, a number is appended if the name is taken by another address
        """
        if unique:
            if not idc.get_func_name(ea).startswith("sub_"):
                return
            base_name, count = name, 1
            while self.get_func_ea_by_name(name) not in (idc.BADADDR, ea):
                count += 1
                name = f"{base_name}{count}"
            print(name)

        ida_name.set_name(ea, name)
        if cmt is not None:
            ida_bytes.set_cmt(ea, cmt, 0)

    def get_image_base(self) -> int:
        return idaapi.get_imagebase()

    def is_offset(self, ea: int) -> bool:
        return idc.is_off0(idc.get_full_flags(ea))

    def xrefs_to(self, ea: int) -> list[int]:
        return [xref.to for xref in idautils.XrefsTo(ea)]

    def get_qword(self, ea: int) -> int:
        return idc.get_qword(ea)

    def get_addr_name(self, ea: int) -> str:
        name = idc.get_name(ea)
        # if name is None or '' and segment name is .text then create the function and get the name of it.
        # this is done for parts of the code that has no xrefs to it due to how IDA detects function boundaries
        if (name is None or name == '') and idc.get_segm_name(ea) == '.text':
            ida_funcs.add_func(ea)
            name = idc.get_name(ea)
        return name

    def set_addr_name(self, ea: int, name: str) -> bool:
        if ida_bytes.get_item_head(ea) != ea:
            return True
        result = idc.set_name(ea, name)
        return bool(result)

    def get_comment(self, ea: int):
        idc.get_cmt(ea, False)

    def set_comment(self, ea: int, comment: str):
        idc.set_cmt(ea, comment, False)

    def get_func_name(self, ea: int) -> str:
        """Name of the function containing ea."""
        return idc.get_func_name(ea)

    def get_func_start(self, ea: int) -> int:
        """Start of the function containing ea."""
        return ida_funcs.get_func(ea).start_ea

    def get_string_from_ptr(self, ea: int) -> str:
        val = idc.get_strlit_contents(ea)
        if val == None:
            val = idc.get_strlit_contents(idc.get_qword(ea))
        return val.decode('utf-8')

    def heads_before(self, ea: int, count: int):
        """The instructions in front of ea, closest first, ex. the argument setup of a call."""
        for _ in range(count):
            ea = idc.prev_head(ea)
            yield ea

    def heads_until_call(self, ea: int, func_name: str):
        """The instructions from ea up to the call of the named function."""
        while not (idc.print_insn_mnem(ea) == 'call' and idc.print_operand(ea, 0) == func_name):
            yield ea
            ea = idc.next_head(ea)

    def get_registers(self, eas, mnemonics=None) -> dict[str, dict[str, object]]:
        """
        Collect what the instructions write to each register, keyed by register name.
        :param eas: Instruction addresses to look at, later ones win
        :param mnemonics: Only look at these instructions, all of them if omitted
        """
        regs = {}
        for ea in eas:
            if mnemonics is not None and idc.print_insn_mnem(ea) not in mnemonics:
                continue
            val_text = idc.print_operand(ea, 1)
            val = idc.get_operand_value(ea, 1)
            if val_text.startswith('cs:'):
                val_text = self.get_string_from_ptr(val)
            regs[idc.print_operand(ea, 0)] = {'val_text': val_text, 'val': val}
        return regs

    def get_func_xrefs(self, ea: int) -> list[int]:
        """The addresses calling ea."""
        return [xref for xref in idautils.CodeRefsTo(ea, True) if idc.print_insn_mnem(xref).lower() == "call"]

    def format_class_name_for_vtbl(self, class_name: str) -> str:
        return f"vtbl_{class_name}"

    def format_class_name_for_secondary_vtbl(self, class_name: str, secondary_name: str) -> str:
        return f"vtbl_{class_name}___{secondary_name}"

    def format_class_name(self, class_name: str) -> str:
        return class_name

    def format_vfunc_name(self, ea: int, current_func_name: str, proposed_func_name: str, class_name: str, base_class_names: list[str]) -> str | None:
        if current_func_name.startswith("j_"):  # jump
            current_func_name = current_func_name.lstrip("j_")

        if current_func_name.startswith("qword_"):
            idc.auto_mark_range(ea, ea + 1, idc.AU_CODE)
            idc.create_insn(ea)
            idc.add_func(ea)
            current_func_name = self.get_addr_name(ea)
            print(f"Info: qword in vtbl of {class_name} at 0x{ea:X}, it may be an offset to undefined code")

        # Previously renamed as a vfunc
        if current_func_name.startswith(class_name):
            # return the proposed func name in case it was updated since last run
            current_class_name = current_func_name.rsplit(".", 1)[0]
            return f"{current_class_name}.{proposed_func_name}"

        # This should have been handled in the base class
        if any(current_func_name.startswith(name) for name in base_class_names):
            return ""

        if current_func_name.startswith("sub_"):
            return f"{class_name}.{proposed_func_name}"

        if current_func_name.startswith("unknown_libname_"):
            return f"{class_name}.{proposed_func_name}"

        if current_func_name.startswith("nullsub_"):
            return f"{class_name}.{proposed_func_name}_nullsub"

        if current_func_name.startswith("loc_"):
            return f"{class_name}.{proposed_func_name}_loc"

        if current_func_name.startswith("locret_"):
            return f"{class_name}.{proposed_func_name}_locret"

        # Name it later in a child class when it gets overridden
        if current_func_name == "_purecall":
            return ""

        # Mangled func names, thanks IDA
        if current_func_name.startswith("?") or current_func_name.startswith("_"):
            return f"{class_name}.{proposed_func_name}"

        return None

    def format_func_name(self, ea: int, current_func_name: str, proposed_func_name: str, class_name: str) -> str | None:
        if current_func_name.startswith("j_"):  # jump
            current_func_name = current_func_name.lstrip("j_")

        # Mangled func names, thanks IDA
        if proposed_func_name.startswith("?") or proposed_func_name.startswith("_"):
            return proposed_func_name

        proposed_qualified_func_name = f"{class_name}.{proposed_func_name}"
        if current_func_name == proposed_qualified_func_name:
            return ""

        if any(current_func_name.startswith(prefix) for prefix in ("sub_", "nullsub_", "loc_", "qword_", "unknown_libname_", "?", "_")):
            return proposed_qualified_func_name

        return None

    def search_binary(self, ea: int, pattern: str, flag: int = ida_search.SEARCH_DOWN):
        return ida_bytes.find_bytes(
            pattern, ea, None, ida_ida.inf_get_max_ea(), None, flag
        )

    def search_binary_all(self, pattern: str, ea: int = 0):
        """Every address matching the pattern, starting from ea."""
        ea = self.search_binary(ea, pattern)
        while ea != idc.BADADDR:
            yield ea
            ea = self.search_binary(ea + 1, pattern)

    def get_dword(self, ea: int):
        return ida_bytes.get_original_dword(ea)

    def get_func_ea_by_name(self, name: str):
        return ida_name.get_name_ea(0, name)

    def get_func_ea_by_sig(self, pattern: str):
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

    def get_static_member_ea(self, static_member: DefinedStructStaticMember) -> int:
        """Address the static member's signature resolves to, BADADDR if the signature is not found."""
        ea = self.search_binary(0, static_member.signature)
        if ea == idc.BADADDR:
            return ea
        for follows in static_member.relative_offsets:
            ea = ea + follows
            ea = ea + 4 + self.get_dword(ea)
        return ea

    def update_static_member(self, static_member: DefinedStructStaticMember, struct: DefinedStruct):
        ea = self.get_static_member_ea(static_member)
        if ea == idc.BADADDR:
            print(f"Error: {static_member.signature} not found something is wrong")
            return
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
            self.apply_tinfo(ea, tif)
        ida_name.set_name(ea, f"g_{struct.type}_{static_member.name}")
    
    def mark_as_vtable(self, vtbl_name: str) -> str | None:
        """Returns an error string on failure, None on success."""
        tif = ida_typeinf.tinfo_t()

        if not tif.get_named_type(None, vtbl_name):
            return f"Type '{vtbl_name}' not found in type library"

        if not tif.is_struct():
            actual = (
                "union" if tif.is_union() else "enum" if tif.is_enum() else "unknown"
            )
            return f"'{vtbl_name}' is not a struct (got {actual})"

        if tif.is_vftable():
            return None

        udt = ida_typeinf.udt_type_data_t()
        if not tif.get_udt_details(udt):
            return f"Failed to retrieve UDT details for '{vtbl_name}'"

        udt.set_vftable()

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
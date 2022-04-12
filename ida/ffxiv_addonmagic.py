import sys
from pathlib import Path
from typing import Iterable, List, Optional

import ida_bytes
import ida_funcs
import ida_nalt
import idaapi
import idautils
import idc
from ida_ua import insn_t

"""
=====INSTRUCTIONS=====
1. Find any addon
2. Enter Component::GUI::Addon<Name>_LoadUldResourceHandle (vfunc 43 as of FFXIV 6.1)

(It should look like this)
sub_140CDDA30 proc near
mov     r9d, 6
lea     rdx, aMultiplehelpwi ; "MultipleHelpWindow"
xor     r8d, r8d
jmp     sub_14050BB10  <-- Set LOOKUP_VALUE to this address
sub_140CDDA30 endp

char __fastcall sub_140CDDA30(__int64 a1)
{
  return sub_14050BB10(a1, (__int64)"MultipleHelpWindow", 0, 6u);
}

3. Set the lookup value to the function address inside the LoadUldResourceHandle method.
"""

LOOKUP_VALUE = 0x14050BB10
VFUNC_INDEX = 43

OUTPUT = sys.stdout
# OUTPUT = Path(r"C:\Somewhere\On\Your\Disk\addon_magic.log").open("w")


def read_str(ea: int) -> Optional[str]:
    length = ida_bytes.get_max_strlit_length(ea, ida_nalt.STRTYPE_C)
    value = ida_bytes.get_strlit_contents(ea, length, ida_nalt.STRTYPE_C)
    return value.decode("utf-8") if value else value


def is_in_text_segm(ea: int) -> bool:
    return get_segm_name(ea) == ".text"


def is_in_rdata_segm(ea: int) -> bool:
    return get_segm_name(ea) == ".rdata"


def get_segm_name(ea: int) -> Optional[str]:
    return idaapi.get_segm_name(idaapi.getseg(ea))


def get_lea_rdata_operand_strings(func_ea: int) -> Iterable[str]:
    insn_eas: List[int] = list(idautils.FuncItems(func_ea))

    for insn_ea in insn_eas:
        insn: insn_t = idautils.DecodeInstruction(insn_ea)

        if insn.get_canon_mnem() != "lea":
            continue

        if idc.print_operand(insn_ea, 0) != "rdx":
            continue

        op1_ea = idc.get_operand_value(insn_ea, 1)
        if not is_in_rdata_segm(op1_ea):
            continue

        addon_name = read_str(op1_ea)
        if addon_name is None:
            continue

        addon_name = addon_name.strip()
        if addon_name:
            yield f"Addon{addon_name}"


def main() -> None:
    """
    Methodology:
    Get the xrefs from the LoadUldResourceHandle method
    Backtrack to the vtable
    Name the table with the argument from the lookup method.
    """
    xrefs = [x.frm for x in idautils.XrefsTo(LOOKUP_VALUE)]
    xrefs = [x for x in xrefs if is_in_text_segm(x)]

    xref: int
    for xref in xrefs:
        func_ea: int = ida_funcs.get_func(xref).start_ea

        vtbl_xrefs = [x.frm for x in idautils.XrefsTo(func_ea)]
        vtbl_xrefs = [x for x in vtbl_xrefs if is_in_rdata_segm(x)]
        vtbl_eas = [ea - (VFUNC_INDEX * 8) for ea in vtbl_xrefs]

        addon_names = list(get_lea_rdata_operand_strings(func_ea))
        addon_name = " | ".join(addon_names) or "<MISSING>"

        for i, vtbl_ea in enumerate(vtbl_eas):
            print(f"0x{vtbl_ea:X} {addon_name}", file=OUTPUT)


if __name__ == "__main__":
    main()

from os import path
import idautils
import ida_auto
import idc
import ida_kernwin
import idaapi

print("Loading ffxiv_idarename.py")
exec(open(path.join(path.dirname(path.realpath(__file__)), "ffxiv_idarename.py")).read())

print("Loading ffxiv_exdgetters.py")
exec(open(path.join(path.dirname(path.realpath(__file__)), "ffxiv_exdgetters.py")).read())

print("Loading ffxiv_structimporter.py")
exec(open(path.join(path.dirname(path.realpath(__file__)), "ffxiv_structimporter.py")).read())

ida_base = ida_kernwin.ask_buttons(
    "ffxiv_dx11.exe",
    "__ImageBase",
    "",
    ida_kernwin.ASKBTN_YES,
    "HIDECANCEL\nWhich name would you prefer from base offset?\n\nffxiv_dx11.exe : CheatEngine and a few other utilities will use the offset of ffxiv_dx11.exe+ as the base.\n__ImageBase : This is the default IDA behavior.",
) == ida_kernwin.ASKBTN_YES

if (ida_base):
    idc.set_name(idaapi.get_imagebase(), "ffxiv_dx11.exe")

for s in idautils.Segments():
    start = idc.get_segm_start(s)
    end = idc.get_segm_end(s)
    ida_auto.plan_range(start, end)
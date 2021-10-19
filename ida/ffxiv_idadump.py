import idautils
import ida_nalt
import idc


def is_user_name(ea, name):
    PREFIXES = ["jpt_", "au_re_", "def_", "nullsub_"]

    if any((name.startswith(prefix) for prefix in PREFIXES)):
        return False

    if ida_segment.is_spec_ea(ea):
        return False

    func_flags = idc.get_func_flags(ea)
    if func_flags == -1:
        return ida_nalt.is_userti(ea)
    else:
        return (func_flags & idc.FUNC_THUNK) == 0 and (func_flags & idc.FUNC_LIB) == 0


with open("idadump.txt", "w") as f:
    user_names = [
        (name, ea) for (ea, name) in idautils.Names() if is_user_name(ea, name)
    ]
    for (name, ea) in user_names:
        print(name, f"0x{ea:X}", file=f)

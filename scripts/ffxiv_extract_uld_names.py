import idaapi
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
import os

patterns = [
    "48 8D 15 ?? ?? ?? ?? 41 B9 ?? ?? ?? ?? 45 33 C0 E8 ?? ?? ?? ??",
    "48 8D 15 ?? ?? ?? ?? 45 33 C0 48 8B CB 48 83 C4 20 5B E9 ?? ?? ?? ??",
    "48 8D 15 ?? ?? ?? ?? 45 33 C0 E9 ?? ?? ?? ??",
]

strings = []


def search_binary(ea, pattern, flag):
    return ida_search.find_binary(
        ea,
        flag & 1 and ida_ida.cvar.inf.max_ea or ida_ida.cvar.inf.min_ea,
        pattern,
        16,
        flag,
    )


def get_string(offset):
    return ida_bytes.get_strlit_contents(offset, -1, ida_nalt.STRTYPE_TERMCHR).decode(
        "UTF-8"
    )


def do_pattern(pattern):
    ea = 0
    while True:
        ea = search_binary(
            ea + 1,
            pattern,
            ida_search.SEARCH_DOWN,
        )

        if ea == 0xFFFFFFFFFFFFFFFF:
            break

        offset = ida_bytes.get_original_dword(ea + 3)

        string = get_string(offset + ea + 0x7)

        strings.append(string)


for pattern in patterns:
    do_pattern(pattern)

txtFile = os.path.join(os.path.dirname(os.path.realpath(__file__)), "uld_names.txt")

if os.path.exists(txtFile):
    os.remove(txtFile)

strings.sort()

filestr = ""

for string in strings:
    filestr = f'{filestr},\n"ui/uld/{string}.uld"'

with open(txtFile, "w") as f:
    f.write(filestr)

print(strings)

from os.path import join, dirname
import sys

sys.path.append(join(dirname(__file__), ".."))

from lumina_wrapper import get_excel_header_files
from exdschema_wrapper import (
    create_struct_from_header_and_schema,
    get_exdschema_data,
    exd_comment_patterns,
    exd_func_patterns,
)
from src_wrapper import SrcInterface
from ida_wrapper import IdaInterface
from form_builder import DynamicForm
from structs_schema import get_yaml
import ida_bytes
import ida_search
import ida_typeinf
import ida_hexrays
import idc
import idaapi

src = SrcInterface()
ida = IdaInterface()
print("Loading data.yml")
ida.load_data_yml()

check_fields = [
    {"type": "label", "text": "Check version match."},
    {"type": "space"},
    {"type": "label", "text": f"Loaded with ver: {ida.data_yaml.version}"},
    {"type": "label", "text": "Check if this matches with what is reported in the version files of the game."}
]

form = DynamicForm(check_fields)
form.Compile()
try:
    if form.Execute() != 1:
        raise "Version is not correct please update repo"
finally:
    form.Free()

ida.select_parser()
fields = [
    {"type": "label", "text": "Select function types to update"},
    {"type": "space"},
    {"type": "label", "text": "Types to update"},
    {
        "type": "checks",
        "key": "function_types",
        "items": [
            ("virtual", "Virtual functions"),
            ("member", "Member functions"),
        ],
    },
    {"type": "space"},
    {"type": "label", "text": "Base name?"},
    {
        "type": "radios",
        "key": "base_name",
        "items": [
            ("ffxiv_dx11.exe", "x64dbg offset (ffxiv_dx11.exe)"),
            ("__ImageBase", "IDA defualt (__ImageBase)"),
        ],
    }
]
form = DynamicForm(fields)
form.Compile()
try:
    if form.Execute() == 1:
        _function_update_options = form.results()["function_types"]
        idc.set_name(idaapi.get_imagebase(), form.results()["base_name"])
    else:
        _function_update_options = {
            "virtual": False,
            "member": False,
        }
finally:
    form.Free()

print("Grabbing ExdSchema and Lumina")

excel_header_files = get_excel_header_files()
exdschema = get_exdschema_data("latest")

excel_structs, excel_map = create_struct_from_header_and_schema(
    excel_header_files, exdschema
)

exd_map = {excel_map[k]: k for k in excel_map}

excel_header, excel_vtables = src.build_export_string(excel_structs, 4)


print("Parsing ffxiv_structs.yml")

with open(ida.get_struct_path()) as f:
    import_structs = get_yaml(f)

struct_header, struct_vtables = src.build_export_string(import_structs, 1)

print("Parsing combined Excel and FFXIV declarations")
ida.parse_string(
    f"""{src.get_predef_header()}
{excel_header}
{struct_header}
""",
    [*excel_vtables, *struct_vtables],
)

def do_pattern(pattern, suffix, sheetSearchPattern, sheetSearchOffset):
    ea = 0

    while True:
        ea = ida.search_binary(ea + 1, pattern, ida_search.SEARCH_DOWN)

        if ea == 0xFFFFFFFFFFFFFFFF:
            break

        if sheetSearchPattern == None:
            sheetEa = ea + sheetSearchOffset
        else:
            sheetEa = (
                ida.search_binary(ea, sheetSearchPattern, ida_search.SEARCH_DOWN)
                + sheetSearchOffset
            )
        sheetIdx = ida.get_dword(sheetEa)
        origName = idc.get_func_name(ea)

        # don't rename any funcs that are already named
        if origName[0:4] == "sub_":
            if exd_map.get(sheetIdx) == None:
                print(
                    f"Func @ 0x{ea:X} references unknown sheet {sheetIdx}! sheet dword offset = 0x{sheetEa:X}"
                )
                continue

            sheetName = exd_map[sheetIdx]

            if suffix == None:
                suffix = ""

            fnName = "Component::Exd::ExdModule_Get%s%s" % (
                exd_map[sheetIdx],
                suffix,
            )

            uniquifier = 0
            while True:
                uniqueName = fnName + (f"_{uniquifier}" if uniquifier > 0 else "")

                if idc.get_name_ea_simple(uniqueName) == idc.BADADDR and uniquifier > 0:
                    fnName = uniqueName
                    break

                uniquifier += 1

            ida.set_func_name(
                ea, fnName, "Sheet: {0} ({1})".format(sheetName, sheetIdx)
            )

            if suffix == "SheetIndex":
                continue

            tif, funcdata = (
                ida_typeinf.tinfo_t(),
                ida_typeinf.func_type_data_t(),
            )

            ida_typeinf.guess_tinfo(tif, ea)
            if not tif.get_func_details(funcdata):
                ida_hexrays.decompile(ea)
                ida_typeinf.guess_tinfo(tif, ea)
                if not tif.get_func_details(funcdata):
                    print("Failed to get func details for %s @ %X" % (fnName, ea))
                    continue

            if suffix == "RowAndSubRowId":
                tif = ida.get_tinfo_from_type(
                    f"Component::Exd::Sheets::{exd_map[sheetIdx]} *__fastcall func(unsigned int rowId, unsigned int subRowId);"
                )
            elif suffix == "RowCount":
                tif = ida.get_tinfo_from_type(
                    f"Component::Exd::Sheets::{exd_map[sheetIdx]} *__fastcall func();"
                )
            else:
                tif = ida.get_tinfo_from_type(
                    f"Component::Exd::Sheets::{exd_map[sheetIdx]} *__fastcall func(unsigned int rowIdOrIndex);"
                )

            ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)


def get_all_eas(pattern: str):
    ea = ida.search_binary(0, pattern, ida_search.SEARCH_DOWN)
    while ea != idc.BADADDR:
        yield ea
        ea = ea + 1
        ea = ida.search_binary(ea, pattern, ida_search.SEARCH_DOWN)

print("Fixing up Excel functions")

for pattern in exd_func_patterns:
    suffix, search = exd_func_patterns[pattern]
    if suffix is not None:
        print(f"Finding exd funcs of {suffix}... please wait.")
    searchPattern, searchOffset = search
    do_pattern(pattern, suffix, searchPattern, searchOffset)


for pattern_key in exd_comment_patterns:
    for ea in list(get_all_eas(pattern_key)):
        sheetIdx = ida.get_dword(ea + exd_comment_patterns[pattern_key])
        sheetName = exd_map.get(sheetIdx)
        if sheetName is None:
            print(f"Sheet getter @ 0x{ea:X} references unknown sheet {sheetIdx}!")
            continue
        ida_bytes.set_cmt(ea, "Sheet: {0} ({1})".format(sheetName, sheetIdx), 0)

if _function_update_options["virtual"]:
    for struct in import_structs.structs:
        if struct.virtual_functions:
            print(f"Updating virtual functions for {struct.type}")
            for virt_func in struct.virtual_functions:
                if virt_func is None:
                    continue

                if virt_func.return_type is not None and virt_func.parameters is not None:
                    ida.update_virt_func(virt_func, struct)

print("Fixing up CS defined functions")

if _function_update_options["member"]:
    for struct in import_structs.structs:
        if struct.member_functions != []:
            print(f"Updating member functions for {struct.type}")
            for member_func in struct.member_functions:
                ida.update_member_func(member_func, struct)

        if struct.static_member_functions:
            print(f"Updating static member functions for {struct.type}")
            for member_func in struct.static_member_functions:
                ida.update_member_func(member_func, struct)

        if struct.static_members:
            print(f"Updating static members for {struct.type}")
            for member in struct.static_members:
                ida.update_static_member(member, struct)
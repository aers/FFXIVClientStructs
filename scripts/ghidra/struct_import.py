# Imports the Excel sheets and ffxiv_structs.yml as data types, and names and types the functions using them
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_struct_import
# @runtime PyGhidra

from os.path import join, dirname
import sys

try:
    script_dir = dirname(__file__)
except NameError:
    script_dir = dirname(str(sourceFile))  # noqa

for import_path in (script_dir, join(script_dir, "..", "shared")):
    if import_path not in sys.path:
        sys.path.append(import_path)

from java.util import ArrayList
from ghidra.util.exception import CancelledException

from lumina_wrapper import get_excel_header_files, find_game_path, is_game_path
from exdschema_wrapper import (
    create_struct_from_header_and_schema,
    get_exdschema_data,
    exd_comment_patterns,
    exd_func_patterns,
)
from src_wrapper import SrcInterface
from ghidra_wrapper import GhidraInterface
from structs_schema import get_yaml, DefinedStructFuncParam

src = SrcInterface()
# one filler field per gap, clang gets slow on a struct with a field for every unknown qword
src.full_padding = False
ghidra = GhidraInterface(currentProgram, monitor)  # noqa
print("Loading data.yml")
ghidra.load_data_yml()

if not askYesNo(  # noqa
    "Check version match.",
    f"Loaded with ver: {ghidra.data_yaml.version}\n"
    "Check if this matches with what is reported in the version files of the game.",
):
    raise RuntimeError("Version is not correct please update repo")

msvc_path = None
if sys.platform != "win32":
    msvc_path = str(askDirectory(  # noqa
        "Select msvc, the folder where ./vsdownload.sh of mstorsjo/msvc-wine was run", "Select"
    ))
ghidra.select_parser(msvc_path)

game_path = find_game_path()
if game_path is None:
    game_path = str(askDirectory(  # noqa
        "Select the game install, the folder holding both game and boot", "Select"
    ))
    if not is_game_path(game_path):
        raise RuntimeError(f"No game or boot folder in {game_path}, select the folder holding both")
print(f"Using game install at {game_path}")

function_types = {"virtual": "Virtual functions", "member": "Member functions"}
try:
    _selected = askChoices(  # noqa
        "Select function types to update",
        "Types to update",
        ArrayList(list(function_types.keys())),
        ArrayList(list(function_types.values())),
    )
    _function_update_options = {key: key in _selected for key in function_types}
except CancelledException:
    _function_update_options = {
        "virtual": False,
        "member": False,
    }

print("Grabbing ExdSchema and Lumina")

excel_header_files = get_excel_header_files(game_path)
exdschema = get_exdschema_data("latest")

excel_structs, excel_map = create_struct_from_header_and_schema(
    excel_header_files, exdschema
)

exd_map = {excel_map[k]: k for k in excel_map}

excel_header, excel_vtables = src.build_export_string(excel_structs, 4)


print("Parsing ffxiv_structs.yml")

with open(ghidra.get_struct_path()) as f:
    import_structs = get_yaml(f)

struct_header, struct_vtables = src.build_export_string(import_structs, 1)

print("Parsing combined Excel and FFXIV declarations")
ghidra.parse_string(
    f"""{src.get_predef_header()}
{excel_header}
{struct_header}
""",
    [*excel_vtables, *struct_vtables],
)

def do_pattern(pattern, suffix, sheetSearchPattern, sheetSearchOffset):
    for ea in ghidra.search_binary_all(pattern, 1):
        if sheetSearchPattern == None:
            sheetEa = ea + sheetSearchOffset
        else:
            sheetEa = (
                ghidra.search_binary(ea, sheetSearchPattern)
                + sheetSearchOffset
            )
        sheetIdx = ghidra.get_dword(sheetEa)

        # don't rename any funcs that are already named
        if ghidra.has_default_name(ea):
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

                if ghidra.get_func_ea_by_name(uniqueName) == ghidra.BADADDR and uniquifier > 0:
                    fnName = uniqueName
                    break

                uniquifier += 1

            ghidra.set_func_name(
                ea, fnName, "Sheet: {0} ({1})".format(sheetName, sheetIdx)
            )

            if suffix == "SheetIndex":
                continue

            sheetType = f"Component::Exd::Sheets::{exd_map[sheetIdx]}*"
            if suffix == "RowAndSubRowId":
                parameters = [
                    DefinedStructFuncParam("rowId", "unsigned int"),
                    DefinedStructFuncParam("subRowId", "unsigned int"),
                ]
            elif suffix == "RowCount":
                parameters = []
            else:
                parameters = [DefinedStructFuncParam("rowIdOrIndex", "unsigned int")]

            ghidra.apply_func_type(ea, fnName, sheetType, parameters)


print("Fixing up Excel functions")

for pattern in exd_func_patterns:
    suffix, search = exd_func_patterns[pattern]
    if suffix is not None:
        print(f"Finding exd funcs of {suffix}... please wait.")
    searchPattern, searchOffset = search
    do_pattern(pattern, suffix, searchPattern, searchOffset)


for pattern_key in exd_comment_patterns:
    for ea in list(ghidra.search_binary_all(pattern_key)):
        sheetIdx = ghidra.get_dword(ea + exd_comment_patterns[pattern_key])
        sheetName = exd_map.get(sheetIdx)
        if sheetName is None:
            print(f"Sheet getter @ 0x{ea:X} references unknown sheet {sheetIdx}!")
            continue
        ghidra.set_comment(ea, "Sheet: {0} ({1})".format(sheetName, sheetIdx))

if _function_update_options["virtual"]:
    for struct in import_structs.structs:
        if struct.virtual_functions:
            print(f"Updating virtual functions for {struct.type}")
            for virt_func in struct.virtual_functions:
                if virt_func is None:
                    continue

                if virt_func.return_type is not None and virt_func.parameters is not None:
                    ghidra.update_virt_func(virt_func, struct)

print("Fixing up CS defined functions")

if _function_update_options["member"]:
    for struct in import_structs.structs:
        if struct.member_functions != []:
            print(f"Updating member functions for {struct.type}")
            for member_func in struct.member_functions:
                ghidra.update_member_func(member_func, struct)

        if struct.static_member_functions:
            print(f"Updating static member functions for {struct.type}")
            for member_func in struct.static_member_functions:
                ghidra.update_member_func(member_func, struct)

        if struct.static_members:
            print(f"Updating static members for {struct.type}")
            for member in struct.static_members:
                ghidra.update_static_member(member, struct)

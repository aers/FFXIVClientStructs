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
import ida_bytes
import ida_search
import ida_typeinf
import ida_hexrays
import idc

src = SrcInterface()

excel_header_files = get_excel_header_files()
exdschema = get_exdschema_data("latest")

struct_export, excel_map = create_struct_from_header_and_schema(
    excel_header_files, exdschema
)

exd_map = {excel_map[k]: k for k in excel_map}

header, vtables = src.build_export_string(struct_export)

ida = IdaInterface()

ida.select_parser()
ida.parse_string(header, vtables)


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

                # check if this name is unique now
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


for pattern in exd_func_patterns:
    suffix, search = exd_func_patterns[pattern]
    if suffix is not None:
        print(f"Finding exd funcs of {suffix}... please wait.")
    searchPattern, searchOffset = search
    do_pattern(pattern, suffix, searchPattern, searchOffset)


for pattern_key in exd_comment_patterns:
    for ea in list(get_all_eas(pattern_key)):
        try:
            sheetIdx = ida.get_dword(ea + exd_comment_patterns[pattern_key])
            sheetName = exd_map[sheetIdx]
            ida_bytes.set_cmt(ea, "Sheet: {0} ({1})".format(sheetName, sheetIdx), 0)
        except Exception as e:
            print(f"An unexpected error occurred at {hex(ea)}: {e}")
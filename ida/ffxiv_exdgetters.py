# ffxiv-exdgetters.py
#
# Automagically labels most exd getter functions along with a hint indicating which sheet/sheet id its fetching from
#

from json import load
from os import getenv
from os.path import join
from luminapie.game_data import GameData, ParsedFileName
from luminapie.excel import ExcelListFile, ExcelHeaderFile
from abc import abstractmethod


class BaseApi:
    @abstractmethod
    def create_enum_struct(self, name, values, width=0):
        # type: (str, dict[int, str], int) -> None
        pass

    @abstractmethod
    def create_struct(self, name, fields):
        # type: (str, dict[str, str]) -> None
        pass

    @abstractmethod
    def get_next_func(self, ea, pattern, flag):
        # type: (int, str, int) -> int
        pass

    @abstractmethod
    def set_func_name(self, ea, name, cmt):
        # type: (int, str, str) -> None
        pass

    @abstractmethod
    def process_pattern(self, pattern):
        # type: (int, str) -> None
        pass

    @abstractmethod
    def set_func_types(self):
        # type: () -> None
        pass


api = None

if api is None:
    try:
        import idaapi
        import ida_bytes
        import ida_search
        import ida_typeinf
        import ida_hexrays
        import ida_name
        import idc
        from ida_wrapper import IdaInterface
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi, IdaInterface):
            def do_pattern(self, pattern, suffix, struct_parsed):
                ea = 0

                if suffix != None:
                    print(f"Finding exd funcs of {suffix}... please wait.")
                    row_id_arg = ida_typeinf.funcarg_t()
                    row_id_arg.type = self.get_tinfo_from_type("unsigned int")
                    row_id_arg.name = "rowId"
                    sub_row_id_arg = ida_typeinf.funcarg_t()
                    sub_row_id_arg.type = self.get_tinfo_from_type("__int16")
                    sub_row_id_arg.name = "subRowId"

                while True:
                    ea = self.search_binary(ea + 1, pattern, ida_search.SEARCH_DOWN)

                    if ea == 0xFFFFFFFFFFFFFFFF:
                        break

                    funcEa = ea

                    # This gets the first instance of EDX register followed by the RCX register, we need the value that is sent to the EDX register
                    ins = idc.get_operand_value(ea, 0)
                    while ins != 0x2:
                        if ins == 0x0:
                            ea = ea + 7
                        elif ins == 0x4:
                            ea = ea + 4
                        elif ins == 0x8 or ins == 0x9:
                            ins = idc.get_operand_type(ea, 1)
                            if ins == 0x1:
                                ea = ea + 3
                            elif ins == 0x4:
                                ea = ea + 7
                            else:
                                raise Exception(
                                    "Unknown instruction {0} on function {1}".format(
                                        hex(ins), hex(funcEa)
                                    )
                                )
                        elif ins == 0x1:
                            ea = ea + 4
                        elif ins == 0x28:
                            ea = ea + 9
                        else:
                            raise Exception(
                                "Unknown instruction {0} on function {1}".format(
                                    hex(ins), hex(funcEa)
                                )
                            )
                        ins = idc.get_operand_value(ea, 0)

                    sheetEa = ea + 1
                    ea = funcEa
                    sheetIdx = self.get_dword(sheetEa)
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
                            uniqueName = fnName + (
                                f"_{uniquifier}" if uniquifier > 0 else ""
                            )

                            # check if this name is unique now
                            if (
                                idc.get_name_ea_simple(uniqueName) == idc.BADADDR
                                and uniquifier > 0
                            ):
                                fnName = uniqueName
                                break

                            uniquifier += 1

                        self.set_func_name(
                            ea, fnName, "Sheet: {0} ({1})".format(sheetName, sheetIdx)
                        )

                        if struct_parsed:
                            tif, funcdata = (
                                ida_typeinf.tinfo_t(),
                                ida_typeinf.func_type_data_t(),
                            )

                            ida_typeinf.guess_tinfo(tif, ea)
                            if not tif.get_func_details(funcdata):
                                ida_hexrays.decompile(ea)
                                ida_typeinf.guess_tinfo(tif, ea)
                                if not tif.get_func_details(funcdata):
                                    print(
                                        "Failed to get func details for %s @ %X"
                                        % (fnName, ea)
                                    )
                                    continue

                            rettype = self.get_tinfo_from_type(
                                f"{exd_struct_map[sheetIdx]} *"
                            )

                            if rettype == None:
                                print(
                                    "Failed to get rettype for %s"
                                    % exd_struct_map[sheetIdx]
                                )
                                continue

                            funcdata.empty()
                            
                            funcdata.push_back(row_id_arg)

                            if suffix == "RowAndSubRowId":
                                funcdata.push_back(sub_row_id_arg)

                            funcdata.rettype = rettype

                            if not tif.create_func(funcdata):
                                print("! failed to create function type for", fnName)
                                return

                            ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def create_enum_struct(self, name, values, width = 0):
                enum_id = self.create_enum(name)
                enum_id = self.get_enum_id(name)
                self.set_enum_width(enum_id, width)
                for key in values:
                    self.remove_enum_member(enum_id, key, values[key])
                    self.add_enum_member(enum_id, values[key], key)

            def create_struct(self, name, fields):
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                struct_id = self.create_struct_type(name)
                if struct_id == idaapi.BADADDR:
                    struct_id = self.get_struct_id(name)
                    self.remove_struct_members(struct_id)
                struct_type = self.get_struct(struct_id)
                for [index, [type, name]] in fields.items():
                    self.create_struct_member(
                        struct_type,
                        name,
                        index,
                        self.get_idc_type_from_ida_type(type),
                        None,
                        self.get_size_from_ida_type(type),
                    )
                    meminfo = self.get_struct_member_by_name(struct_type, name)
                    self.set_struct_member_info(
                        struct_type, meminfo, 0, self.get_tinfo_from_type(type), 0
                    )
                idaapi.end_type_updating(idaapi.UTP_STRUCT)

            def set_func_name(self, ea, name, cmt):
                ida_name.set_name(ea, name)
                ida_bytes.set_cmt(ea, cmt, 0)

            def process_pattern(self, pattern):
                suffix = exd_func_patterns[pattern]
                if suffix == None or suffix == "RowCount" or suffix == "SheetIndex":
                    self.do_pattern(pattern, suffix, False)
                else:
                    self.do_pattern(pattern, suffix, True)
                pass

        api = IdaApi()

if api is None:
    try:
        import ghidra
        import re

        from ghidra.program.model.data import *
        from ghidra.program.model.listing import *
        from ghidra.program.model.symbol import SourceType
        from ghidra.app.util import SymbolPathParser

    except ImportError:
        print("Warning: Unable to load Ghidra")
    else:
        # noinspection PyUnresolvedReferences
        class GhidraApi(BaseApi):
            def create_enum_struct(self, name, values, width = 0):
                # type: (str, dict[str, int], int) -> None
                pass

            def create_struct(self, name, fields):
                # type: (str, dict[str, str]) -> None
                pass

            def get_next_func(self, ea, pattern, flag):
                # type: (int, str, int) -> int
                pass

            def get_dword(self, ea):
                # type: (int) -> int
                pass

            def set_func_name(self, ea, name, cmt):
                # type: (int, str, str) -> None
                pass

            def process_pattern(self, pattern):
                # type: (int, str) -> None
                pass

            def set_func_types(self):
                # type: () -> None
                pass

        api = GhidraApi()

if api is None:
    print("Warning: No API available, exiting.")
    exit(1)


f = open(join(getenv("APPDATA"), "XIVLauncher", "launcherConfigV3.json"), "r")

config = load(f)

f.close()

game_data = GameData(join(config["GamePath"], "game"))

# nb: "pattern": ("func suffix", "instance pointer sig") OR None
exd_func_patterns = {
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "Row",
    "48 83 EC 28 85 C9 74 20 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 07 33 C0 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "Row",
    "48 83 EC 38 48 8B 05 ? ? ? ? 44 8B CA 44 8B C1 48 C7 44 24 ? ? ? ? ? BA ? ? ? ? 48 C7 44 24 ? ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 38 C3 48 8B 00 48 83 C4 38 C3": "RowAndSubRowId",
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 44 0F B6 C1 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "RowIndex",
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8D 81 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "RowIndex",
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 74 14 48 8B 10 48 8B C8 FF 52 08 84 C0 75 07 B0 01 48 83 C4 28 C3 32 C0 48 83 C4 28 C3": "SheetIndex",
    "48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E9 ? ? ? ?": "RowCount",
    # this last one doesn't seem to exist in the binary anymore
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 74 17 48 8B 08 48 85 C9 74 0F 8B 01 25 ? ? ? ? 48 03 C1 48 83 C4 28 C3 33 C0 48 83 C4 28 C3": None,
}

exd_map = ExcelListFile(game_data.get_file(ParsedFileName("exd/root.exl"))).dict
exd_struct_map: dict[str, str] = {}
exd_headers: tuple[dict[int, tuple[str, str]], dict[str, dict[int, str]], int] = {}

api.create_enum_struct("Component::Exd::SheetsEnum", exd_map)

for key in exd_map:
    print(f"Parsing schema for {exd_map[key]}.")
    exd_headers[key] = ExcelHeaderFile(
        game_data.get_file(ParsedFileName("exd/" + exd_map[key] + ".exh"))
    ).map_names(game_data.get_exd_schema(exd_map[key]))

for key in exd_headers:
    [exd_header, exd_header_enums, exd_header_count] = exd_headers[key]
    struct_name = f"Component::Exd::Sheets::{exd_map[key]}"
    exd_struct_map[key] = struct_name
    for enum_key in exd_header_enums:
        api.create_enum_struct(f"{struct_name}::{enum_key}", exd_header_enums[enum_key], 1)
    api.create_struct(struct_name, exd_header)

# if a new pattern is found, add it to the exd_func_patterns dict
for pattern in exd_func_patterns:
    api.process_pattern(pattern)

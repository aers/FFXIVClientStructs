# ffxiv-exdgetters.py
#
# Automagically labels most exd getter functions along with a hint indicating which sheet/sheet id its fetching from
#

from urllib.request import urlopen, Request
from urllib.error import HTTPError, URLError
from io import BufferedReader
from enum import IntEnum
from zlib import decompress
from json import load, loads
from zipfile import ZipFile
from tempfile import TemporaryFile
from yaml import load as yload, Loader
from re import sub
from os import listdir, walk, getenv
from os.path import isdir, join
from luminapie.game_data import GameData, ParsedFileName
from luminapie.excel import ExcelListFile, ExcelHeaderFile
from abc import abstractmethod


class BaseApi:
    @abstractmethod
    def create_enum(self, name, values):
        # type: (str, dict[str, int]) -> None
        pass

    @abstractmethod
    def create_struct(self, name, fields):
        # type: (str, dict[str, str]) -> None
        pass

    @abstractmethod
    def parse_name(self, name):
        # type: (str) -> str
        pass

    @abstractmethod
    def get_next_func(self, ea, pattern, flag):
        # type: (int, str, int) -> int
        pass

    @abstractmethod
    def get_dword(self, ea):
        # type: (int) -> int
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
    class IDAVersionException(Exception):
        pass
    try:
        import idaapi
        if idaapi.IDA_SDK_VERSION < 900:
            raise IDAVersionException
        import ida_bytes
        import ida_search
        import ida_ida
        import ida_typeinf
        import ida_hexrays
        import ida_name
        import idc
        import ctypes
        import ida_helpers
    except ImportError:
        print("Warning: Unable to load IDA")
    except IDAVersionException:
        pass
    else:
        # noinspection PyUnresolvedReferences
        class Ida9Api(BaseApi):
            def do_pattern(self, pattern, suffix, struct_parsed):
                ea = 0

                if suffix != None:
                    print(f"Finding exd funcs of {suffix}... please wait.")
                    row_id_arg = ida_typeinf.funcarg_t()
                    row_id_arg.type = ida_helpers.get_tinfo_from_type("unsigned int")
                    row_id_arg.name = "rowId"
                    sub_row_id_arg = ida_typeinf.funcarg_t()
                    sub_row_id_arg.type = ida_helpers.get_tinfo_from_type("__int16")
                    sub_row_id_arg.name = "subRowId"

                while True:
                    ea = ida_helpers.search_binary(ea + 1, pattern, flag=ida_search.SEARCH_DOWN)

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
                                raise Exception("Unknown instruction {0} on function {1}".format(hex(ins), hex(funcEa)))
                        elif ins == 0x1:
                            ea = ea + 4
                        elif ins == 0x28:
                            ea = ea + 9
                        else:
                            raise Exception("Unknown instruction {0} on function {1}".format(hex(ins), hex(funcEa)))
                        ins = idc.get_operand_value(ea, 0)
                    
                    sheetIdx = self.get_dword(ea + 1)
                    ea = funcEa
                    origName = idc.get_func_name(ea)
                    
                    # don't rename any funcs that are already named
                    if origName[0:4] == "sub_":
                        if exd_map.get(sheetIdx) == None:
                            print(
                                f"Func @ 0x{ea:X} references unknown sheet {sheetIdx}!"
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

                            # func_info = ida_typeinf.tinfo_t()
                            # funcdata = ida_typeinf.func_type_data_t()
                            # if not ida_nalt.get_tinfo(func_info, ea):
                            #     print(func_info.is_funcptr() or func_info.is_func())
                            #     print("Failed to get tinfo for %s @ %X" % (fnName, ea))
                            #     continue

                            # if not func_info.get_func_details(funcdata):
                            #     print("Failed to get func details for %s @ %X" % (fnName, ea))
                            #     continue

                            rettype = ida_helpers.get_tinfo_from_type(f"{exd_struct_map[sheetIdx]} *")

                            if rettype is None:
                                print(
                                    "Failed to get rettype for %s"
                                    % exd_struct_map[sheetIdx]
                                )
                                continue

                            funcdata.push_back(row_id_arg)

                            if suffix == "RowAndSubRowId":
                                funcdata.push_back(sub_row_id_arg)

                            funcdata.rettype = rettype

                            if not tif.create_func(funcdata):
                                print("! failed to create function type for", fnName)
                                return

                            ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def create_enum(self, name, values):
                enum_id = idc.add_enum(idaapi.BADADDR, name, 0)
                if enum_id == idaapi.BADADDR:
                    tif = ida_helpers.get_named_type(name)
                    tif.del_edms(0, ctypes.c_size_t(-1).value)
                else:
                    tif = ida_helpers.get_tinfo_by_tid(enum_id)
                for key in values:
                    edm = ida_typeinf.edm_t()
                    edm.name = values[key]
                    edm.value = key
                    tif.add_edm(edm)

            def create_struct(self, name, fields):
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                struct_id = idc.add_struc(-1, name, 0)
                if struct_id == idaapi.BADADDR:
                    ida_helpers.delete_struct_members(name)
                idaapi.end_type_updating(idaapi.UTP_STRUCT)
            
            def create_struct_members(self, name, fields):
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                tif = ida_helpers.get_tinfo_from_type(name)
                for [index, [type, name]] in fields.items():
                    udm = ida_helpers.create_udm(name, index, ida_helpers.get_tinfo_from_type(type))
                    tif.add_udm(udm)
                idaapi.end_type_updating(idaapi.UTP_STRUCT)
                
            def parse_name(self, name):
                return name

            def get_next_func(self, ea, pattern, flag):
                return ida_search.find_binary(
                    ea,
                    flag & 1 and ida_ida.cvar.inf.max_ea or ida_ida.cvar.inf.min_ea,
                    pattern,
                    16,
                    flag,
                )

            def get_dword(self, ea):
                return ida_bytes.get_original_dword(ea)

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

        api = Ida9Api()

if api is None:
    try:
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
        import idc
    except ImportError:
        print("Warning: Unable to load IDA")
    else:
        # noinspection PyUnresolvedReferences
        class Ida7Api(BaseApi):
            def get_tinfo_from_type(self, raw_type):
                """
                Retrieve a tinfo_t from a raw type string.
                """

                type_tinfo = idaapi.tinfo_t()
                ptr_tinfo = None

                ptr_count = raw_type.count("*")
                type = raw_type.rstrip("*")

                if not type_tinfo.get_named_type(idaapi.get_idati(), type):
                    terminated = type + ";"
                    if (
                        idaapi.parse_decl(
                            type_tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL
                        )
                        is None
                    ):
                        print("! failed to parse type '{0}'".format(type))
                        return None

                if ptr_count > 0:
                    ptr_tinfo = idaapi.tinfo_t()
                    for i in range(ptr_count):
                        if not ptr_tinfo.create_ptr(type_tinfo):
                            print("! failed to create pointer")
                            return None
                else:
                    ptr_tinfo = type_tinfo

                return ptr_tinfo

            def get_idc_type_from_ida_type(self, type):
                # type: (str) -> int
                if type == "unsigned __int8" or type == "__int8" or type == "bool":
                    return ida_bytes.byte_flag()
                elif type == "unsigned __int16" or type == "__int16":
                    return ida_bytes.word_flag()
                elif type == "unsigned __int32" or type == "__int32":
                    return ida_bytes.dword_flag()
                elif type == "unsigned __int64" or type == "__int64":
                    return ida_bytes.qword_flag()
                elif type == "float":
                    return ida_bytes.float_flag()

            def get_size_from_ida_type(self, type):
                # type: (str) -> int
                if type == "unsigned __int8" or type == "__int8" or type == "bool":
                    return 1
                elif type == "unsigned __int16" or type == "__int16":
                    return 2
                elif type == "unsigned __int32" or type == "__int32" or type == "float":
                    return 4
                elif type == "unsigned __int64" or type == "__int64":
                    return 8

            def search_binary(self, ea, pattern, flag):
                return ida_search.find_binary(
                    ea,
                    flag & 1 and ida_ida.cvar.inf.max_ea or ida_ida.cvar.inf.min_ea,
                    pattern,
                    16,
                    flag,
                )

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
                                raise Exception("Unknown instruction {0} on function {1}".format(hex(ins), hex(funcEa)))
                        elif ins == 0x1:
                            ea = ea + 4
                        elif ins == 0x28:
                            ea = ea + 9
                        else:
                            raise Exception("Unknown instruction {0} on function {1}".format(hex(ins), hex(funcEa)))
                        ins = idc.get_operand_value(ea, 0)
                    
                    sheetIdx = self.get_dword(ea + 1)
                    ea = funcEa
                    origName = idc.get_func_name(ea)
                    
                    # don't rename any funcs that are already named
                    if origName[0:4] == "sub_":
                        if exd_map.get(sheetIdx) == None:
                            print(
                                f"Func @ 0x{ea:X} references unknown sheet {sheetIdx}!"
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

                            # func_info = ida_typeinf.tinfo_t()
                            # funcdata = ida_typeinf.func_type_data_t()
                            # if not ida_nalt.get_tinfo(func_info, ea):
                            #     print(func_info.is_funcptr() or func_info.is_func())
                            #     print("Failed to get tinfo for %s @ %X" % (fnName, ea))
                            #     continue

                            # if not func_info.get_func_details(funcdata):
                            #     print("Failed to get func details for %s @ %X" % (fnName, ea))
                            #     continue

                            rettype = self.get_tinfo_from_type(
                                f"{exd_struct_map[sheetIdx]} *"
                            )

                            if rettype == None:
                                print(
                                    "Failed to get rettype for %s"
                                    % exd_struct_map[sheetIdx]
                                )
                                continue

                            funcdata.push_back(row_id_arg)

                            if suffix == "RowAndSubRowId":
                                funcdata.push_back(sub_row_id_arg)

                            funcdata.rettype = rettype

                            if not tif.create_func(funcdata):
                                print("! failed to create function type for", fnName)
                                return

                            ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def create_enum(self, name, values):
                enum_id = ida_enum.add_enum(idaapi.BADADDR, name, 0)
                for key in values:
                    ida_enum.add_enum_member(enum_id, values[key], key)

            def create_struct(self, name, fields):
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                struct_id = ida_struct.add_struc(-1, name)
                if struct_id == idaapi.BADADDR:
                    struct_id = ida_struct.get_struc_id(name)
                    ida_struct.del_struc_members(
                        ida_struct.get_struc(struct_id),
                        0,
                        ida_struct.get_struc_size(struct_id) + 1,
                    )
                struct_type = ida_struct.get_struc(struct_id)
                for [index, [type, name]] in fields.items():
                    ida_struct.add_struc_member(
                        struct_type,
                        name,
                        index,
                        self.get_idc_type_from_ida_type(type),
                        None,
                        self.get_size_from_ida_type(type),
                    )
                    meminfo = ida_struct.get_member_by_name(struct_type, name)
                    ida_struct.set_member_tinfo(
                        struct_type, meminfo, 0, self.get_tinfo_from_type(type), 0
                    )
                idaapi.end_type_updating(idaapi.UTP_STRUCT)

            def parse_name(self, name):
                return name

            def get_next_func(self, ea, pattern, flag):
                return ida_search.find_binary(
                    ea,
                    flag & 1 and ida_ida.cvar.inf.max_ea or ida_ida.cvar.inf.min_ea,
                    pattern,
                    16,
                    flag,
                )

            def get_dword(self, ea):
                return ida_bytes.get_original_dword(ea)

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

        api = Ida7Api()

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
            def create_enum(self, name, values):
                # type: (str, dict[str, int]) -> None
                pass

            def create_struct(self, name, fields):
                # type: (str, dict[str, str]) -> None
                pass

            def create_struct_members(self, name, fields):
                # type: (str, dict[str, str]) -> None
                pass

            def parse_name(self, name):
                # type: (str) -> str
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
exd_struct_map = {}
exd_headers = {}

api.create_enum(api.parse_name("Component::Exd::SheetsEnum"), exd_map)

for key in exd_map:
    print(f"Parsing schema for {exd_map[key]}.")
    exd_headers[key] = ExcelHeaderFile(
        game_data.get_file(ParsedFileName("exd/" + exd_map[key] + ".exh"))
    ).map_names(game_data.get_exd_schema(exd_map[key]))

for key in exd_headers:
    [exd_header, exd_header_count] = exd_headers[key]
    struct_name = f"Component::Exd::Sheets::{exd_map[key]}"
    exd_struct_map[key] = struct_name
    api.create_struct(api.parse_name(struct_name), exd_header)

for (key, struct_name) in exd_struct_map.items():
    [exd_header, exd_header_count] = exd_headers[key]
    api.create_struct_members(api.parse_name(struct_name), exd_header)

# if a new pattern is found, add it to the exd_func_patterns dict
for pattern in exd_func_patterns:
    api.process_pattern(pattern)

# Automagically labels most exd getter functions along with a hint indicating which sheet/sheet id its fetching from
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_exdgetters
# @runtime PyGhidra

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
    def set_func_name(self, ea, name, cmt):
        # type: (int, str, str) -> None
        pass

    @abstractmethod
    def process_pattern(self, pattern):
        # type: (str) -> None
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
    except ImportError as e:
        print("Warning: Unable to load IDA failed with {0}".format(e))
    else:
        # noinspection PyUnresolvedReferences
        class IdaApi(BaseApi, IdaInterface):
            def do_pattern(self, pattern, suffix, sheetSearchPattern, sheetSearchOffset):
                ea = 0

                while True:
                    ea = self.search_binary(ea + 1, pattern, ida_search.SEARCH_DOWN)

                    if ea == 0xFFFFFFFFFFFFFFFF:
                        break
                    
                    if sheetSearchPattern == None:
                        sheetEa = ea + sheetSearchOffset
                    else:
                        sheetEa = self.search_binary(ea, sheetSearchPattern, ida_search.SEARCH_DOWN) + sheetSearchOffset
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
                                print(
                                    "Failed to get func details for %s @ %X"
                                    % (fnName, ea)
                                )
                                continue


                        if suffix == "RowAndSubRowId":
                            tif = self.get_tinfo_from_type(
                                f"{exd_struct_map[sheetIdx]} *__fastcall func(unsigned int rowId, unsigned int subRowId);"
                            )
                        elif suffix == "RowCount":
                            tif = self.get_tinfo_from_type(
                                f"{exd_struct_map[sheetIdx]} *__fastcall func();"
                            )
                        else:
                            tif = self.get_tinfo_from_type(
                                f"{exd_struct_map[sheetIdx]} *__fastcall func(unsigned int rowIdOrIndex);"
                            )

                        ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

            def create_enum_struct(self, name, values, width = 0):
                # type: (str, dict[int, str], int) -> None
                if len(name.split("::")) > 3:
                    sheet_name = name.split("::")[-2]
                else:
                    sheet_name = name.split("::")[-1]

                # create or reset if exists
                enum_id = self.get_enum_id(name)
                if enum_id == idaapi.BADADDR:
                    enum_id = self.create_enum(name)
                else:
                    self.delete_enum_members(enum_id)
                    idc.set_enum_bf(enum_id, False)
                    
                self.set_enum_width(enum_id, width)
                if width == 1:
                    if idaapi.IDA_SDK_VERSION < 900:
                        self.add_enum_member(enum_id, f"{sheet_name}.tmp", self.get_enum_default_mask(enum_id))
                    self.set_enum_as_bf(enum_id)
                        
                for key in values:
                    self.add_enum_member(enum_id, f"{sheet_name}.{values[key]}", key)

                if width == 1 and idaapi.IDA_SDK_VERSION < 900:
                    self.remove_enum_member(enum_id, "tmp", sheet_name)

            def create_struct(self, name, fields):
                idaapi.begin_type_updating(idaapi.UTP_STRUCT)
                struct_id = self.get_struct_id(name)
                if struct_id == idaapi.BADADDR:
                    struct_id = self.create_struct_type(name)
                else:
                    self.remove_struct_members(struct_id)
                struct_type = self.get_struct(struct_id)
                for [index, [type, name]] in fields.items():
                    if (
                        self.get_idc_type_from_ida_type(
                            self.clean_struct_name(type)
                        )
                        == self.get_struct_flag()
                    ):
                        type = self.clean_struct_name(type)
                        self.create_struct_member(
                            struct_type,
                            name,
                            index,
                            self.get_idc_type_from_ida_type(type),
                            self.get_struct_opinfo_from_type(type),
                            self.get_size_from_ida_type(type),
                        )
                    elif (
                        self.get_idc_type_from_ida_type(type)
                        == self.get_enum_flag()
                    ):
                        self.create_struct_member(
                            struct_type,
                            name,
                            index,
                            self.get_idc_type_from_ida_type(type),
                            self.get_enum_opinfo_from_type(type),
                            self.get_size_from_ida_type(type),
                        )
                    else:
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

            def process_pattern(self, pattern: str):
                (suffix, search) = exd_func_patterns[pattern]
                if suffix is not None:
                    print(f"Finding exd funcs of {suffix}... please wait.")
                (searchPattern, searchOffset) = search
                self.do_pattern(pattern, suffix, searchPattern, searchOffset)

            def get_all_eas(self, pattern: str):
                ea = self.search_binary(0, pattern, ida_search.SEARCH_DOWN)
                while ea != idc.BADADDR:
                    yield ea
                    ea = ea + 1
                    ea = self.search_binary(ea, pattern, ida_search.SEARCH_DOWN)
            
            def comment_rows(self, pattern: dict[str, int], values: dict[int, str]):
                for pattern_key in pattern:
                    for ea in list(self.get_all_eas(pattern_key)):
                        sheetIdx = self.get_dword(ea + pattern[pattern_key])
                        sheetName = values[sheetIdx]
                        ida_bytes.set_cmt(ea, "Sheet: {0} ({1})".format(sheetName, sheetIdx), 0)
                pass

        api = IdaApi()

if api is None:
    try:
        import ghidra
        import re
        try:
            from ghidra.ghidra_builtins import * # ghidra-stubs
        except ImportError:
            pass

        from ghidra.program.model.data import *
        from ghidra.program.model.listing import *
        from ghidra.program.model.symbol import SourceType
        from ghidra.app.util import SymbolPathParser
        from java.util import ArrayList

    except ImportError:
        print("Warning: Unable to load Ghidra")
    else:
        # noinspection PyUnresolvedReferences
        class GhidraApi(BaseApi):
            def create_enum_struct(self, name, values, width = 0):
                # type: (str, dict[int, str], int) -> None
                path = self.get_datatype_path(name)
                enum_dt = EnumDataType(path.getCategoryPath(), path.getDataTypeName(), width or 8)
                is_sheets_enum = name == "Component::Exd::SheetsEnum"
                for enum_value, enum_name in values.items():
                    if monitor.isCancelled():
                        break
                    if not is_sheets_enum and "_" in enum_name:
                        enum_name = "".join(enum_name.split("_")[1:])
                    enum_dt.add(enum_name, enum_value)
                if width == 0:
                    enum_dt.setLength(enum_dt.getMinimumPossibleLength())
                if enum_dt.getName(0) is None:
                    enum_dt.add("None", 0)
                dt = currentProgram.getDataTypeManager().getDataType(path)
                if dt is None:
                    currentProgram.getDataTypeManager().addDataType(enum_dt, None)
                else:
                    dt.replaceWith(enum_dt)

            def create_struct(self, name, fields):
                # type: (str, dict[str, str]) -> None
                dt_path = self.get_datatype_path(name)
                struct = StructureDataType(dt_path.getCategoryPath(), dt_path.getDataTypeName(), 0)
                struct.setExplicitMinimumAlignment(4)
                for [offset, [type_name, field_name]] in fields.items():
                    if monitor.isCancelled():
                        break
                    field_dt = currentProgram.getDataTypeManager().getDataType(self.get_datatype_path(type_name))
                    if field_dt is None:
                        print(f"Warning: Data type {name} field {field_name} has missing type {type_name} ({dt_path})")
                        continue
                    struct.insertAtOffset(offset, field_dt, -1, field_name, None)
                dt = currentProgram.getDataTypeManager().getDataType(dt_path)
                if dt is None:
                    currentProgram.getDataTypeManager().addDataType(struct, None)
                else:
                    dt.replaceWith(struct)

            def set_func_name(self, ea, name, cmt):
                # type: (int, str, str) -> None
                func = getFunctionAt(ea)
                if func is not None:
                    func.setName(None, SourceType.DEFAULT)
                    func.setName(name, SourceType.USER_DEFINED)
                    func.setComment(cmt)

            def process_pattern(self, pattern):
                # type: (str) -> None
                (suffix, _) = exd_func_patterns[pattern]
                pattern = "".join(["\\x" + x if x != "?" else "." for x in pattern.split(" ")])
                if suffix is not None:
                    print(f"Finding exd funcs of {suffix}... please wait.")
                self.do_pattern(pattern, suffix)

            def do_pattern(self, pattern, suffix):
                # type: (string, string) -> None
                block = currentProgram.getMemory().getBlock(".text")
                address_set = currentProgram.getAddressFactory().getAddressSet(block.getStart(), block.getEnd())
                result_list = findBytes(address_set, pattern, 8192, 1)
                for ea in result_list:
                    if monitor.isCancelled():
                        break
                    sheet_index = self.get_sheet_index(ea)
                    sheet_name = exd_map.get(sheet_index)
                    if sheet_name is None:
                        print(f"Warning: sheet index {sheet_index} is undefined at {ea}")
                        continue
                    func_name = f"Component::Exd::ExdModule.Get{sheet_name}{suffix}"
                    self.set_func_name(ea, func_name, f"Sheet: {sheet_name} ({sheet_index})")
                    if suffix == "SheetIndex":
                        return

                    return_type = PointerDataType(VoidDataType.dataType)
                    if suffix == "RowCount":
                        return_type = IntegerDataType()
                    else:
                        path = self.get_datatype_path(f"{exd_struct_map[sheet_index]}")
                        dt = currentProgram.getDataTypeManager().getDataType(path)
                        if dt is not None:
                            return_type = PointerDataType(dt)

                    return_var = ReturnParameterImpl(return_type, currentProgram)
                    arg_vars = ArrayList()
                    arg_vars.add(ParameterImpl("rowId", UnsignedIntegerDataType(), currentProgram))
                    if suffix == "RowAndSubRowId":
                        arg_vars.add(ParameterImpl("subRowId", UnsignedIntegerDataType(), currentProgram))
                    elif suffix == "RowCount":
                        arg_vars.clear()

                    update_type = Function.FunctionUpdateType.DYNAMIC_STORAGE_ALL_PARAMS
                    getFunctionAt(ea).updateFunction("__fastcall", return_var, arg_vars, update_type, False, SourceType.USER_DEFINED)

            def get_sheet_index(self, ea):
                # type: (Address) -> int
                func = getFunctionAt(ea)
                if func is None and disassemble(ea):
                    func = createFunction(ea, None)
                if func is None:
                    return -1
                min_address = func.getBody().getMinAddress().getOffset()
                instructions = currentProgram.getListing().getInstructions(func.getBody(), True)
                for insn in instructions:
                    if monitor.isCancelled():
                        break
                    if insn.getFlowType().isCall():
                        return self.get_rdx_arg(insn, min_address)
                return -1

            def get_rdx_arg(self, insn, min_address):
                # type: (Instruction, int) -> int
                target = insn.getRegister("RDX")
                while insn is not None and insn.getMinAddress().getOffset() >= min_address:
                    if monitor.isCancelled():
                        break
                    insn = insn.getPrevious()
                    if insn is None:
                        break
                    outp = insn.getResultObjects()
                    if outp.length == 0 or outp[0] != target:
                        continue
                    value = insn.getScalar(1)
                    if value is not None:
                        return value.getValue()
                return -1

            def get_datatype_path(self, name):
                # type: (str) -> DataTypePath
                if name == "__int8": name = "char"
                if name == "__int16": name = "short"
                if name == "__int32": name = "int"
                if name == "__int64": name = "longlong"
                if name == "unsigned __int8" or name == "unsigned char": name = "byte"
                if name == "unsigned __int16" or name == "unsigned short": name = "ushort"
                if name == "unsigned __int32" or name == "unsigned int": name = "uint"
                if name == "unsigned __int64" or name == "unsigned long long": name = "ulonglong"
                path_parts = SymbolPathParser.parse(name)
                return DataTypePath("/" + "/".join(path_parts[:-1]), path_parts[-1])
            
            def comment_rows(self, pattern: dict[str, int], values: dict[int, str]):
                pass

        api = GhidraApi()

if api is None:
    print("Warning: No API available, exiting.")
    exit(1)


f = open(join(getenv("APPDATA"), "XIVLauncher", "launcherConfigV3.json"), "r")

config = load(f)

f.close()

game_data = GameData(join(config["GamePath"], "game"))

# nb: "pattern": ("func suffix", ("instance pointer sig" or None, offset from sig start or func start))
exd_func_patterns: dict[str, tuple[str, tuple[str | None, int]]] = {
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8": ("Row", ("48 8B 05 ? ? ? ? 44 8B C1 BA", 11)),
    "48 83 EC 28 85 C9 74 20 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8": ("Row", ("48 8B 05 ? ? ? ? 44 8B C1 BA", 11)),
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 44 0F B6 C1 48 8B 88 ? ? ? ? E8": ("Row", ("48 8B 05 ? ? ? ? BA", 8)),
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 44 0F B7 C1 48 8B 88 ? ? ? ? E8": ("Row", ("48 8B 05 ? ? ? ? BA", 8)),
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 44 0F B7 81 ? ? ? ? 48 8B 88 ? ? ? ? E8": ("Row", ("48 8B 05 ? ? ? ? BA", 8)),
    "40 53 48 83 EC 20 48 8B 05 ? ? ? ? 44 8B C1 8B DA BA ? ? ? ? 48 8B 88 ? ? ? ? E8": ("Row", ("44 8B C1 8B DA BA", 6)),
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 84 D2 BA ? ? ? ? 48 8B 88 ? ? ? ? 74 07 E8": ("Row", ("44 8B C1 84 D2 BA", 6)),
    "48 83 EC 38 48 8B 05 ? ? ? ? 44 8B CA 44 8B C1 48 C7 44 24 ? ? ? ? ? BA ? ? ? ? 48 C7 44 24 ? ? ? ? ? 48 8B 88 ? ? ? ? E8": ("RowAndSubRowId", ("C1 48 C7 44 24 ? ? ? ? ? BA", 11)),
    "48 83 EC 38 48 8B 05 ? ? ? ? 44 8B C1 44 0F ? CA BA ? ? ? ? 48 C7 44 24 28 ? ? ? ? 48 C7 44 24 20 ? ? ? ? 48 8B 88 ? ? ? ? E8": ("RowAndSubRowId", ("44 8B C1 44 0F ? CA BA", 8)),
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8D 81 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8": ("RowIndex", ("05 ? ? ? ? 44 8D 81 ? ? ? ? BA", 13)),
    "48 83 EC 28 8D 41 ? 3D ? ? ? ? 77 20 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8": ("RowIndex", ("48 8B 05 ? ? ? ? 44 8B C1 BA", 11)),
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8": ("SheetIndex", ("48 8B 05 ? ? ? ? BA", 8)),
    "48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E9 ? ? ? ?": ("RowCount", (None, 8))
}

exd_comment_patterns: dict[str, int] = {
    "48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 40 2B 00 00": 8,
    "48 8B 05 ? ? ? ? BA ? ? ? ? 44 0F": 8,
    "48 8B 05 ? ? ? ? 44 8B C1 8B DA BA": 13,
    "48 8B 05 ? ? ? ? 44 8B C1 BA": 11,
    "48 8B 05 ? ? ? ? 44 8B CA 44 8B C1 48 C7 44 24 ? ? ? ? ? BA": 23,
    "48 8B 05 ? ? ? ? 44 8B C1 84 D2 BA": 13,
    "48 8B 05 ? ? ? ? 44 8B C1 44 0F ? CA BA": 15,
    "48 8B 05 ? ? ? ? 44 8D 81 ? ? ? ? BA": 15
}

exd_map = ExcelListFile(game_data.get_file(ParsedFileName("exd/root.exl"))).dict
exd_struct_map: dict[str, str] = {}
exd_headers: tuple[dict[int, tuple[str, str]], dict[str, dict[int, str]], int] = {}

api.create_enum_struct("Component::Exd::SheetsEnum", exd_map, 4)

for key in exd_map:
    print(f"Parsing schema for {exd_map[key]}.")
    exd_headers[key] = ExcelHeaderFile(
        game_data.get_file(ParsedFileName("exd/" + exd_map[key] + ".exh")),
        exd_map[key]
    ).map_names(game_data.get_exd_schema(exd_map[key]))

for key in exd_headers:
    [exd_header, exd_header_enums, exd_header_count] = exd_headers[key]
    struct_name = f"Component::Exd::Sheets::{exd_map[key]}"
    print(f'Creating struct {struct_name}.')
    exd_struct_map[key] = struct_name
    for enum_key in exd_header_enums:
        api.create_enum_struct(f"{struct_name}::{enum_key}", exd_header_enums[enum_key], 1)
    api.create_struct(struct_name, exd_header)

# if a new pattern is found, add it to the exd_func_patterns dict
for func_pattern in exd_func_patterns:
    api.process_pattern(func_pattern)

api.comment_rows(exd_comment_patterns, exd_map)

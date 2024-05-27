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

import idaapi
import idc
import ida_bytes
import ida_nalt
import ida_struct
import ida_enum
import ida_kernwin
import ida_search
import ida_ida
import ida_typeinf
import ida_hexrays


def get_definition(schema: dict[str, str]) -> dict[str, str]:
    if "type" in schema:
        if schema["type"] == "array":
            return RepeatDefinition(schema)
    return Definition(schema)


class Definition:
    def __init__(self, obj: dict[str, str]) -> None:
        self.name = obj["name"]

    def __repr__(self) -> str:
        return self.name


class RepeatDefinition:
    def __init__(self, obj: dict[str, str]) -> None:
        self.obj = obj
        self.name = obj["name"]
        self.count = obj["count"]
        self.inner_defs = []
        self.process_inner()

    def process_inner(self):
        if "fields" in self.obj:
            for field in self.obj["fields"]:
                if "name" in field:
                    self.inner_defs.append(get_definition(field))
                else:
                    self.inner_defs.append(Definition({"name": ""}))
        if self.inner_defs == []:
            self.inner_defs.append(Definition({"name": ""}))

    def flatten(self, extern: str) -> list[Definition]:
        defs = []
        extern = extern + self.name
        for i in range(0, int(self.count)):
            for inner in self.inner_defs:
                if isinstance(inner, RepeatDefinition):
                    defs.extend(inner.flatten(extern + i.__str__()))
                else:
                    defs.append(Definition({"name": extern + i.__str__() + inner.name}))
        return defs

    def __repr__(self) -> str:
        return f'{self.flatten("")}'


class Crc32:
    def __init__(self):
        self.poly = 0xEDB88320
        self.table = [0] * 256 * 16
        for i in range(256):
            res = i
            for j in range(16):
                for k in range(8):
                    if res & 1 == 1:
                        res = self.poly ^ (res >> 1)
                    else:
                        res = res >> 1
                self.table[i + j * 256] = res

    def calc(self, value: bytes):
        start = 0
        size = len(value)
        crc_local = 4294967295 ^ 0
        while size >= 16:
            a = (
                self.table[(3 * 256) + value[start + 12]]
                ^ self.table[(2 * 256) + value[start + 13]]
                ^ self.table[(1 * 256) + value[start + 14]]
                ^ self.table[(0 * 256) + value[start + 15]]
            )
            b = (
                self.table[(7 * 256) + value[start + 8]]
                ^ self.table[(6 * 256) + value[start + 9]]
                ^ self.table[(5 * 256) + value[start + 10]]
                ^ self.table[(4 * 256) + value[start + 11]]
            )
            c = (
                self.table[(11 * 256) + value[start + 4]]
                ^ self.table[(10 * 256) + value[start + 5]]
                ^ self.table[(9 * 256) + value[start + 6]]
                ^ self.table[(8 * 256) + value[start + 7]]
            )
            d = (
                self.table[(15 * 256) + (self.byte(crc_local) ^ value[start])]
                ^ self.table[(14 * 256) + (self.byte(crc_local, 1) ^ value[start + 1])]
                ^ self.table[(13 * 256) + (self.byte(crc_local, 2) ^ value[start + 2])]
                ^ self.table[(12 * 256) + (self.byte(crc_local, 3) ^ value[start + 3])]
            )
            crc_local = d ^ c ^ b ^ a
            start += 16
            size -= 16

        while size > 0:
            crc_local = self.table[(crc_local ^ value[start]) & 0xFF] ^ (crc_local >> 8)
            start += 1
            size -= 1

        return ~(crc_local ^ 4294967295) % (1 << 32)

    def byte(self, number: int, i=0):
        return (number & (0xFF << (i * 8))) >> (i * 8)

    def calc_index(self, path: str):
        path_parts = path.split("/")
        filename = path_parts[-1]
        folder = path.rstrip(filename).rstrip("/")

        foldercrc = self.calc(folder.encode("utf-8"))
        filecrc = self.calc(filename.encode("utf-8"))

        return foldercrc << 32 | filecrc

    def calc_index2(self, path: str):
        return self.calc(path.encode("utf-8"))


crc = Crc32()


class SqPackCatergories(IntEnum):
    COMMON = 0x0
    BGCOMMON = 0x1
    BG = 0x2
    CUT = 0x3
    CHARA = 0x4
    SHADER = 0x5
    UI = 0x6
    SOUND = 0x7
    VFX = 0x8
    UI_SCRIPT = 0x9
    EXD = 0xA
    GAME_SCRIPT = 0xB
    MUSIC = 0xC
    SQPACK_TEST = 0x12
    DEBUG = 0x13


class SqPackPlatformId(IntEnum):
    Win32 = 0x0
    PS3 = 0x1
    PS4 = 0x2


class SqPackFileType(IntEnum):
    Empty = (1,)
    Standard = (2,)
    Model = (3,)
    Texture = (4,)


class DatBlockType(IntEnum):
    Compressed = (4713,)
    Uncompressed = (32000,)


class ExcelColumnDataType(IntEnum):
    String = (0x0,)
    Bool = (0x1,)
    Int8 = (0x2,)
    UInt8 = (0x3,)
    Int16 = (0x4,)
    UInt16 = (0x5,)
    Int32 = (0x6,)
    UInt32 = (0x7,)
    # unused?
    Unk = (0x8,)
    Float32 = (0x9,)
    Int64 = (0xA,)
    UInt64 = (0xB,)
    # unused?
    Unk2 = (0xC,)

    # 0 is read like data & 1, 1 is like data & 2, 2 = data & 4, etc...
    PackedBool0 = (0x19,)
    PackedBool1 = (0x1A,)
    PackedBool2 = (0x1B,)
    PackedBool3 = (0x1C,)
    PackedBool4 = (0x1D,)
    PackedBool5 = (0x1E,)
    PackedBool6 = (0x1F,)
    PackedBool7 = 0x20


def column_data_type_to_ida_type(column_data_type: ExcelColumnDataType) -> str:
    if column_data_type == ExcelColumnDataType.Bool:
        return "bool"
    elif column_data_type == ExcelColumnDataType.Int8:
        return "__int8"
    elif column_data_type == ExcelColumnDataType.UInt8:
        return "unsigned __int8"
    elif column_data_type == ExcelColumnDataType.Int16:
        return "__int16"
    elif column_data_type == ExcelColumnDataType.UInt16:
        return "unsigned __int16"
    elif column_data_type == ExcelColumnDataType.Int32:
        return "int"
    elif column_data_type == ExcelColumnDataType.UInt32:
        return "unsigned int"
    elif column_data_type == ExcelColumnDataType.Float32:
        return "float"
    elif column_data_type == ExcelColumnDataType.Int64:
        return "__int64"
    elif column_data_type == ExcelColumnDataType.UInt64:
        return "unsigned __int64"
    elif (
        column_data_type == ExcelColumnDataType.PackedBool0
        or column_data_type == ExcelColumnDataType.PackedBool1
        or column_data_type == ExcelColumnDataType.PackedBool2
        or column_data_type == ExcelColumnDataType.PackedBool3
        or column_data_type == ExcelColumnDataType.PackedBool4
        or column_data_type == ExcelColumnDataType.PackedBool5
        or column_data_type == ExcelColumnDataType.PackedBool6
        or column_data_type == ExcelColumnDataType.PackedBool7
    ):
        return "unsigned __int8"  # IDA doesn't support bitfields in decompilation, so we'll just use a byte. A different method would be to create an enum for each bitfield, but that's a lot of work that i cant be bothered doing.
    elif column_data_type == ExcelColumnDataType.String:
        return "_DWORD"  # strings are stored as a 4 byte offset to a string table, so we'll just use a 4 byte unknown type since another function handles reasign of strings.


def column_data_type_to_size(column_data_type: ExcelColumnDataType) -> int:
    if (
        column_data_type == ExcelColumnDataType.Bool
        or column_data_type == ExcelColumnDataType.Int8
        or column_data_type == ExcelColumnDataType.UInt8
        or column_data_type == ExcelColumnDataType.PackedBool0
        or column_data_type == ExcelColumnDataType.PackedBool1
        or column_data_type == ExcelColumnDataType.PackedBool2
        or column_data_type == ExcelColumnDataType.PackedBool3
        or column_data_type == ExcelColumnDataType.PackedBool4
        or column_data_type == ExcelColumnDataType.PackedBool5
        or column_data_type == ExcelColumnDataType.PackedBool6
        or column_data_type == ExcelColumnDataType.PackedBool7
    ):
        return 1
    elif (
        column_data_type == ExcelColumnDataType.Int16
        or column_data_type == ExcelColumnDataType.UInt16
    ):
        return 2
    elif (
        column_data_type == ExcelColumnDataType.Int32
        or column_data_type == ExcelColumnDataType.UInt32
        or column_data_type == ExcelColumnDataType.Float32
        or column_data_type == ExcelColumnDataType.String
    ):
        return 4
    elif (
        column_data_type == ExcelColumnDataType.Int64
        or column_data_type == ExcelColumnDataType.UInt64
    ):
        return 8


def get_game_data_folders(root: str):
    for folder in listdir(join(root, "sqpack")):
        if isdir(join(root, "sqpack", folder)):
            yield folder


def get_files(path):
    files: list[bytes] = []
    for dir_path, dir_names, file_names in walk(path):
        files.extend(join(dir_path, file) for file in file_names)

    return files


def get_sqpack_files(root: str, path: str):
    for file in get_files(join(root, "sqpack", path)):
        ext = file.split(".")[-1]
        if ext.startswith("dat"):
            yield file


def get_sqpack_index(root: str, path: str):
    for file in get_files(join(root, "sqpack", path)):
        if file.endswith(".index"):
            yield file


def get_sqpack_index2(root: str, path: str):
    for file in get_files(join(root, "sqpack", path)):
        if file.endswith(".index2"):
            yield file


class SqPackFileInfo:
    def __init__(self, bytes: bytes, offset: int):
        self.header_size = int.from_bytes(bytes[0:4], byteorder="little")
        self.type = SqPackFileType(int.from_bytes(bytes[4:8], byteorder="little"))
        self.raw_file_size = int.from_bytes(bytes[8:12], byteorder="little")
        self.unknown = [
            int.from_bytes(bytes[12:16], byteorder="little"),
            int.from_bytes(bytes[16:20], byteorder="little"),
        ]
        self.number_of_blocks = int.from_bytes(bytes[20:24], byteorder="little")
        self.offset = offset


class DatStdFileBlockInfos:
    def __init__(self, bytes: bytes):
        self.offset = int.from_bytes(bytes[0:4], byteorder="little")
        self.compressed_size = int.from_bytes(bytes[4:6], byteorder="little")
        self.uncompressed_size = int.from_bytes(bytes[6:8], byteorder="little")


class DatBlockHeader:
    def __init__(self, bytes: bytes):
        self.size = int.from_bytes(bytes[0:4], byteorder="little")
        self.unknown1 = int.from_bytes(bytes[4:8], byteorder="little")
        self.block_data_size = int.from_bytes(bytes[8:12], byteorder="little")
        self.dat_block_type = int.from_bytes(bytes[12:16], byteorder="little")


class SqPackHeader:
    def __init__(self, file: BufferedReader):
        self.magic = file.read(8)
        self.platform_id = SqPackPlatformId(
            int.from_bytes(file.read(1), byteorder="little")
        )
        self.unknown = file.read(3)
        if self.platform_id != SqPackPlatformId.PS3:
            self.size = int.from_bytes(file.read(4), byteorder="little")
            self.version = int.from_bytes(file.read(4), byteorder="little")
            self.type = int.from_bytes(file.read(4), byteorder="little")
        else:
            raise Exception("PS3 is not supported")


class SqPackIndexHeader:
    def __init__(self, bytes: bytes):
        self.size = int.from_bytes(bytes[0:4], byteorder="little")
        self.version = int.from_bytes(bytes[4:8], byteorder="little")
        self.index_data_offset = int.from_bytes(bytes[8:12], byteorder="little")
        self.index_data_size = int.from_bytes(bytes[12:16], byteorder="little")
        self.index_data_hash = bytes[16:80]
        self.number_of_data_file = int.from_bytes(bytes[80:84], byteorder="little")
        self.synonym_data_offset = int.from_bytes(bytes[84:88], byteorder="little")
        self.synonym_data_size = int.from_bytes(bytes[88:92], byteorder="little")
        self.synonym_data_hash = bytes[92:156]
        self.empty_block_data_offset = int.from_bytes(
            bytes[156:160], byteorder="little"
        )
        self.empty_block_data_size = int.from_bytes(bytes[160:164], byteorder="little")
        self.empty_block_data_hash = bytes[164:228]
        self.dir_index_data_offset = int.from_bytes(bytes[228:232], byteorder="little")
        self.dir_index_data_size = int.from_bytes(bytes[232:236], byteorder="little")
        self.dir_index_data_hash = bytes[236:300]
        self.index_type = int.from_bytes(bytes[300:304], byteorder="little")
        self.reserved = bytes[304:960]
        self.hash = bytes[960:1024]


class SqPackIndexHashTable:
    def __init__(self, bytes: bytes):
        self.hash = int.from_bytes(bytes[0:8], byteorder="little")
        self.data = int.from_bytes(bytes[8:12], byteorder="little")
        self.padding = int.from_bytes(bytes[12:16], byteorder="little")

    def is_synonym(self):
        return (self.data & 0b1) == 0b1

    def data_file_id(self):
        return (self.data & 0b1110) >> 1

    def data_file_offset(self):
        return (self.data & ~0xF) * 0x08


class SqPack:
    def __init__(self, root: str, path: str):
        self.root = root
        self.path = path
        self.file = open(path, "rb")
        self.header = SqPackHeader(self.file)

    def get_index_header(self):
        self.file.seek(self.header.size)
        return SqPackIndexHeader(self.file.read(1024))

    def get_index_hash_table(self, index_header: SqPackIndexHeader):
        self.file.seek(index_header.index_data_offset)
        entry_count = index_header.index_data_size // 16
        return [SqPackIndexHashTable(self.file.read(16)) for _ in range(entry_count)]

    def load_index_header(self):
        self.index_header = self.get_index_header()

    def load_hash_table(self):
        self.hash_table = self.get_index_hash_table(self.index_header)

    def discover_data_files(self):
        self.load_index_header()
        self.load_hash_table()
        self.data_files: list[str] = []
        for file in get_sqpack_files(
            self.root, self.path.rsplit("\\", 1)[0].split("\\")[-1]
        ):
            for i in range(0, self.index_header.number_of_data_file):
                name = self.path.rsplit(".", 1)[0] + ".dat" + str(i)
                if file == name:
                    self.data_files.append(file)

    def read_file(self, offset: int):
        if self.path.rsplit(".", 1)[1][0:3] != "dat":
            raise Exception("Not a data file")
        self.file.seek(offset)
        file_info_bytes = self.file.read(24)
        file_info = SqPackFileInfo(file_info_bytes, offset)
        data: list[bytes] = []
        if file_info.type == SqPackFileType.Empty:
            raise Exception(f"File located at 0x{hex(offset)} is empty.")
        elif file_info.type == SqPackFileType.Standard:
            data = self.read_standard_file(file_info)
        else:
            raise Exception("Type: " + str(file_info.type) + " not implemented.")
        return data

    def read_standard_file(self, file_info: SqPackFileInfo):
        block_bytes = self.file.read(file_info.number_of_blocks * 8)
        data: list[bytes] = []
        for i in range(file_info.number_of_blocks):
            block = DatStdFileBlockInfos(block_bytes[i * 8 : i * 8 + 8])
            self.file.seek(file_info.offset + file_info.header_size + block.offset)
            block_header = DatBlockHeader(self.file.read(16))
            if block_header.dat_block_type == 32000:
                data.append(self.file.read(block_header.block_data_size))
            else:
                data.append(
                    decompress(self.file.read(block_header.block_data_size), wbits=-15)
                )

        return data


class Repository:
    def __init__(self, name: str, root: str):
        self.root = root
        self.name = name
        self.sqpacks: list[SqPack] = []
        self.index: dict[int, tuple[SqPackIndexHashTable, SqPack]] = {}
        self.expansion_id = 0
        self.get_expansion_id()

    def get_expansion_id(self):
        if self.name.startswith("ex"):
            self.expansion_id = int(self.name.removeprefix("ex"))

    def parse_version(self):
        versionPath = ""
        if self.name == "ffxiv":
            versionPath = join(self.root, "ffxivgame.ver")
        else:
            versionPath = join(self.root, "sqpack", self.name, self.name + ".ver")
        with open(versionPath, "r") as f:
            self.version = SemanticVersion(
                *(int(v) for v in f.read().strip().split("."))
            )

    def setup_indexes(self):
        for file in get_sqpack_index(self.root, self.name):
            self.sqpacks.append(SqPack(self.root, file))

        for sqpack in self.sqpacks:
            sqpack.discover_data_files()
            for indexes in sqpack.hash_table:
                self.index[indexes.hash] = [indexes, sqpack]

    def get_index(self, hash: int):
        return self.index[hash]

    def get_file(self, hash: int):
        index, sqpack = self.get_index(hash)
        id = index.data_file_id()
        offset = index.data_file_offset()
        return SqPack(self.root, sqpack.data_files[id]).read_file(offset)


class ParsedFileName:
    def __init__(self, path: str):
        self.path = path.lower().strip()
        parts = self.path.split("/")
        self.category = parts[0]
        self.index = crc.calc_index(self.path)
        self.index2 = crc.calc_index2(self.path)
        self.repo = parts[1]
        if self.repo[0] != "e" or self.repo[1] != "x" or not self.repo[2].isdigit():
            self.repo = "ffxiv"


class GameData:
    def __init__(self, root: str):
        self.root = root
        self.repositories: dict[int, Repository] = {}
        self.setup()

    def get_repo_index(self, folder: str):
        if folder == "ffxiv":
            return 0
        else:
            return int(folder.removeprefix("ex"))

    def setup(self):
        for folder in get_game_data_folders(self.root):
            self.repositories[self.get_repo_index(folder)] = Repository(
                folder, self.root
            )

        for folder in self.repositories:
            repo = self.repositories[folder]
            repo.parse_version()
            repo.setup_indexes()

    def get_file(self, file: ParsedFileName):
        return self.repositories[self.get_repo_index(file.repo)].get_file(file.index)


class ExcelListFile:
    def __init__(self, data: list[bytes]):
        self.data = b"".join(data).split("\r\n".encode("utf-8"))
        self.parse()

    def parse(self):
        self.header = self.data[0].decode("utf-8").split(",")
        self.version = int(self.header[1])
        self.data = self.data[1:]
        self.dict: dict[int, str] = {}
        for line in [x.decode("utf-8") for x in self.data]:
            if line == "":
                continue
            linearr = line.split(",")
            if linearr[1] == "-1":
                continue
            self.dict[int(linearr[1])] = linearr[0]


class ExcelHeader:
    def __init__(self, data: bytes):
        self.data = data
        self.parse()

    def parse(self):
        self.magic = self.data[0:4]
        self.version = int.from_bytes(self.data[4:6], "big")
        self.data_offset = int.from_bytes(self.data[6:8], "big")
        self.column_count = int.from_bytes(self.data[8:10], "big")
        self.page_count = int.from_bytes(self.data[10:12], "big")
        self.language_count = int.from_bytes(self.data[12:14], "big")
        self.unknown1 = int.from_bytes(self.data[14:16], "big")
        self.unknown2 = self.data[17]
        self.variant = self.data[18]
        self.unknown3 = int.from_bytes(self.data[19:20], "big")
        self.row_count = int.from_bytes(self.data[20:24], "big")
        self.unknown4 = [
            int.from_bytes(self.data[24:28], "big"),
            int.from_bytes(self.data[28:32], "big"),
        ]


class ExcelColumnDefinition:
    def __init__(self, data: bytes):
        self.data = data
        self.parse()

    def parse(self):
        self.type = ExcelColumnDataType(int.from_bytes(self.data[0:2], "big"))
        self.offset = int.from_bytes(self.data[2:4], "big")

    def __lt__(self, other: "ExcelColumnDefinition") -> bool:
        return self.offset <= other.offset


class ExcelDataPagination:
    def __init__(self, data: bytes):
        self.data = data
        self.parse()

    def parse(self):
        self.start_id = int.from_bytes(self.data[0:2], "big")
        self.row_count = int.from_bytes(self.data[2:4], "big")


class ExcelHeaderFile:
    def __init__(self, data: list[bytes]):
        self.data = data[0]
        self.column_definitions: list[ExcelColumnDefinition] = []
        self.pagination: list[ExcelDataPagination] = []
        self.languages: list[int] = []
        self.header: ExcelHeader = None
        self.parse()

    def parse(self):
        self.header = ExcelHeader(self.data[0:32])
        if self.header.magic != b"EXHF":
            raise Exception("Invalid EXHF header")
        self.column_definitions: list[ExcelColumnDefinition] = []
        for i in range(self.header.column_count):
            self.column_definitions.append(
                ExcelColumnDefinition(self.data[32 + (i * 4) : 32 + ((i + 1) * 4)])
            )
        self.column_definitions = sorted(self.column_definitions)
        self.pagination: list[ExcelDataPagination] = []
        for i in range(self.header.page_count):
            self.pagination.append(
                ExcelDataPagination(
                    self.data[
                        32
                        + (self.header.column_count * 4)
                        + (i * 4) : 32
                        + (self.header.column_count * 4)
                        + ((i + 1) * 4)
                    ]
                )
            )
        self.languages: list[int] = []
        for i in range(self.header.language_count):
            self.languages.append(
                self.data[
                    32
                    + (self.header.column_count * 4)
                    + (self.header.page_count * 4)
                    + i
                ]
            )

    def map_names(
        self, names: list[Definition]
    ) -> tuple[dict[int, tuple[str, str]], int]:
        mapped: dict[int, tuple[str, str]] = {}
        largest_offset_index: int = 0
        for i in range(self.header.column_count):
            if (
                self.column_definitions[i].offset
                > self.column_definitions[largest_offset_index].offset
            ):
                largest_offset_index = i

        size = self.column_definitions[
            largest_offset_index
        ].offset + column_data_type_to_size(
            self.column_definitions[largest_offset_index].type
        )

        for i in range(self.header.column_count):
            if (
                self.column_definitions[i].offset in mapped
                and mapped[self.column_definitions[i].offset] is not None
            ):
                [_, name] = mapped[self.column_definitions[i].offset]
                if name.split("_")[0] == "Unknown":
                    continue
                if (
                    column_data_type_to_ida_type(self.column_definitions[i].type)
                    != "unsigned __int8"
                ):
                    continue
                else:
                    mapped[self.column_definitions[i].offset] = (
                        column_data_type_to_ida_type(self.column_definitions[i].type),
                        f"{name}_{names[i].name}",
                    )
            else:
                mapped[self.column_definitions[i].offset] = (
                    column_data_type_to_ida_type(self.column_definitions[i].type),
                    names[i].name,
                )
        mapped = dict(sorted(mapped.items()))
        return [mapped, size]


class SemanticVersion:
    """Represents a semantic version string that can compare versions"""

    year: int
    month: int
    date: int
    patch: int
    build: int

    def __init__(
        self, year: int, month: int, date: int, patch: int, build: int = 0
    ) -> None:
        self.year = year
        self.month = month
        self.date = date
        self.patch = patch
        self.build = build

    def __lt__(self, other: "SemanticVersion") -> bool:
        return (
            self.year < other.year
            or self.month < other.month
            or self.date < other.date
            or self.patch < other.patch
            or self.build < other.build
        )

    def __repr__(self) -> str:
        return f'{self.year}.{self.month.__str__().rjust(2, "0")}.{self.date.__str__().rjust(2, "0")}.{self.patch.__str__().rjust(4, "0")}.{self.build.__str__().rjust(4, "0")}'

    def __eq__(self, __value: object) -> bool:
        if not isinstance(__value, SemanticVersion):
            return False
        return (
            self.year == __value.year
            and self.month == __value.month
            and self.date == __value.date
            and self.patch == __value.patch
            and self.build == __value.build
        )

    def __hash__(self) -> int:
        return hash(repr(self))


def xiv_version_compare(a: str, b: str) -> int:
    a = a.split(".")
    b = b.split(".")
    for i in range(0, len(a)):
        if int(a[i]) > int(b[i]):
            return 1
        elif int(a[i]) < int(b[i]):
            return -1
    return 0


def get_url(url: str, supress: bool = False) -> bytes | None:
    req = Request(url)
    try:
        resp = urlopen(req)
        return resp.read()
    except HTTPError as e:
        if not supress:
            print("HTTP Error code: ", e.code, " for url: ", url)
        return None
    except URLError as e:
        if not supress:
            print("HTTP Reason: ", e.reason, " for url: ", url)
        return None


def get_latest_schema() -> dict[SemanticVersion, str]:
    json = loads(
        get_url("https://api.github.com/repos/xivdev/EXDSchema/releases/latest")
    )
    assetsJson = json["assets"]
    assets = {}
    for asset in assetsJson:
        version = SemanticVersion(*(int(x) for x in asset["name"].split(".")[0:5]))
        assets[version] = asset["browser_download_url"]
    assets = dict(sorted(assets.items()))
    return assets


def get_latest_schema_url(ver: SemanticVersion) -> str:
    latest_release = get_latest_schema()
    # check if the current version can be retrieved
    if ver in latest_release:
        return latest_release[ver]
    # grab the version before the current version if it can't be retrieved
    for version in latest_release:
        if version < ver:
            return latest_release[version]


def get_definitions(schema: dict[str, str]) -> list[Definition]:
    defs = []
    for field in schema:
        defin = get_definition(field)
        if isinstance(defin, RepeatDefinition):
            defs.extend(defin.flatten(""))
        else:
            defs.append(defin)
    return defs


f = open(join(getenv("APPDATA"), "XIVLauncher", "launcherConfigV3.json"), "r")

config = load(f)

f.close()

game_data = GameData(join(config["GamePath"], "game"))

# nb: "pattern": "func suffix" OR None
exd_func_patterns = {
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "Row",
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 44 0F B6 C1 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "RowIndex",
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8D 81 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "RowIndex",
    "48 83 EC 38 48 8B 05 ? ? ? ? 44 8B CA 44 8B C1 48 C7 44 24 ? ? ? ? ? BA ? ? ? ? 48 C7 44 24 ? ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 38 C3 48 8B 00 48 83 C4 38 C3": "RowAndSubRowId",
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 74 14 48 8B 10 48 8B C8 FF 52 08 84 C0 75 07 B0 01 48 83 C4 28 C3 32 C0 48 83 C4 28 C3": "SheetIndex",
    "48 83 EC 28 85 C9 74 20 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 07 33 C0 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": "Row2",
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 74 17 48 8B 08 48 85 C9 74 0F 8B 01 25 ? ? ? ? 48 03 C1 48 83 C4 28 C3 33 C0 48 83 C4 28 C3": None,
    # unsure if this is totally accurate but it looks to be the case
    "48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E9 ? ? ? ?": "RowCount",
}

# todo: figure out how/where these exd getters are used
# .text:0000000140622200                         sub_140622200   proc near               ; CODE XREF: sub_14067D8E0+D3
# .text:0000000140622200 48 8B 05 F1 7F 46 01                    mov     rax, cs:qword_141A8A1F8
# .text:0000000140622207 BA 59 01 00 00                          mov     edx, 159h
# .text:000000014062220C 48 8B 88 E8 2B 00 00                    mov     rcx, [rax+2BE8h]
# .text:0000000140622213 E9 28 E2 E2 FF                          jmp     sub_140450440
# .text:0000000140622213                         sub_140622200   endp
exd_map = ExcelListFile(game_data.get_file(ParsedFileName("exd/root.exl"))).dict
exd_struct_map = {}
exd_schema_map = {}

with TemporaryFile() as schema:
    schema.write(
        get_url(get_latest_schema_url(game_data.repositories[0].version), True)
    )
    schema.seek(0)
    schemaZip = ZipFile(schema)

    for file in schemaZip.namelist():
        if file.endswith(".yml"):
            schema_yml = yload(schemaZip.read(file), Loader=Loader)
            exd_schema_map[file.rsplit(".", 1)[0].rsplit("/", 1)[1]] = schema_yml[
                "fields"
            ]


def get_tinfo_from_type(raw_type):
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
            idaapi.parse_decl(type_tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL)
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


def get_idc_type_from_ida_type(type: str):
    if type == "unsigned __int8" or type == "__int8" or type == "bool":
        return ida_bytes.byte_flag()
    elif type == "unsigned __int16" or type == "__int16":
        return ida_bytes.word_flag()
    elif (
        type == "unsigned __int32"
        or type == "__int32"
        or type == "int"
        or type == "unsigned int"
        or type == "_DWORD"
    ):
        return ida_bytes.dword_flag()
    elif type == "unsigned __int64" or type == "__int64":
        return ida_bytes.qword_flag()
    elif type == "float":
        return ida_bytes.float_flag()


def get_size_from_ida_type(type: str):
    if type == "unsigned __int8" or type == "__int8" or type == "bool":
        return 1
    elif type == "unsigned __int16" or type == "__int16":
        return 2
    elif (
        type == "unsigned __int32"
        or type == "__int32"
        or type == "int"
        or type == "unsigned int"
        or type == "_DWORD"
        or type == "float"
    ):
        return 4
    elif type == "unsigned __int64" or type == "__int64":
        return 8


def do_structs():
    exd_headers: dict[int, tuple[dict[int, tuple[str, str]], int]] = {}

    exd_enum_struct = ida_enum.add_enum(idc.BADADDR, "Component::Exd::SheetsEnum", 0)

    for key in exd_map:
        print(f"Parsing schema for {exd_map[key]}.")
        ida_enum.add_enum_member(exd_enum_struct, exd_map[key], key)
        exd_headers[key] = ExcelHeaderFile(
            game_data.get_file(ParsedFileName("exd/" + exd_map[key] + ".exh"))
        ).map_names(get_definitions(exd_schema_map[exd_map[key]]))

    print(
        "Making structs... please wait. This may take a while. Undo buffer will be cleared due to the large amount of changes."
    )

    for key in exd_headers:
        [exd_header, exd_header_count] = exd_headers[key]
        struct_name = f"Component::Exd::Sheets::{exd_map[key]}"
        struct_id = ida_struct.add_struc(-1, struct_name)
        struct_type = ida_struct.get_struc(struct_id)
        exd_struct_map[key] = struct_name
        for index in exd_header:
            [type, name] = exd_header[index]
            ida_struct.add_struc_member(
                struct_type,
                name,
                index,
                get_idc_type_from_ida_type(type),
                None,
                get_size_from_ida_type(type),
            )
            meminfo = ida_struct.get_member_by_name(struct_type, name)
            ida_struct.set_member_tinfo(
                struct_type, meminfo, 0, get_tinfo_from_type(type), 0
            )


def search_binary(ea, pattern, flag):
    return ida_search.find_binary(
        ea,
        flag & 1 and ida_ida.cvar.inf.max_ea or ida_ida.cvar.inf.min_ea,
        pattern,
        16,
        flag,
    )


def do_pattern(pattern, suffix, struct_parsed):
    ea = 0

    if suffix != None:
        print(f"Finding exd funcs of {suffix}... please wait.")
        row_id_arg = ida_typeinf.funcarg_t()
        row_id_arg.type = get_tinfo_from_type("unsigned int")
        row_id_arg.name = "rowId"
        sub_row_id_arg = ida_typeinf.funcarg_t()
        sub_row_id_arg.type = get_tinfo_from_type("__int16")
        sub_row_id_arg.name = "subRowId"

    while True:
        ea = search_binary(ea + 1, pattern, ida_search.SEARCH_DOWN)

        if ea == 0xFFFFFFFFFFFFFFFF:
            break

        # this is mega retarded but it works rofl
        ins = search_binary(ea, "BA ? ? ? ?", ida_search.SEARCH_DOWN)
        sheetIdx = idc.get_wide_dword(ins + 1)

        origName = idc.get_func_name(ea)

        # don't rename any funcs that are already named
        if origName[0:4] == "sub_":
            if exd_map.get(sheetIdx) == None:
                print(f"Func @ 0x{ea:X} references unknown sheet {sheetIdx}!")
                continue

            sheetName = exd_map[sheetIdx]

            if suffix == None:
                suffix = ""

            fnName = "Component::Exd::ExdModule_Get%s%s" % (exd_map[sheetIdx], suffix)

            uniquifier = 0
            while True:
                uniqueName = fnName + (f"_{uniquifier}" if uniquifier > 0 else "")

                # check if this name is unique now
                if idc.get_name_ea_simple(uniqueName) == idc.BADADDR and uniquifier > 0:
                    fnName = uniqueName
                    break

                uniquifier += 1

            idc.set_name(ea, fnName)
            idc.set_cmt(ins, "Sheet: %s (%i)" % (sheetName, sheetIdx), 0)

        if struct_parsed:
            tif, funcdata = ida_typeinf.tinfo_t(), ida_typeinf.func_type_data_t()

            ida_typeinf.guess_tinfo(tif, ea)
            if not tif.get_func_details(funcdata):
                ida_hexrays.decompile(ea)
                ida_typeinf.guess_tinfo(tif, ea)
                if not tif.get_func_details(funcdata):
                    print("Failed to get func details for %s @ %X" % (fnName, ea))
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

            rettype = get_tinfo_from_type(f"{exd_struct_map[sheetIdx]} *")

            if rettype == None:
                print("Failed to get rettype for %s" % exd_struct_map[sheetIdx])
                continue

            funcdata.push_back(row_id_arg)

            if suffix == "RowAndSubRowId":
                funcdata.push_back(sub_row_id_arg)

            funcdata.rettype = rettype

            if not tif.create_func(funcdata):
                print("! failed to create function type for", fnName)
                return

            ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)


def run():
    do_structs()

    ea = search_binary(
        0,
        "40 53 48 83 EC 20 48 8B 49 20 41 8B D8 48 8B 01 ?? ?? ?? 48 85 C0 74 2F 4C 8B 08 45 33 C0 8B D3 48 8B C8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 18 48 8B 10 48 8B C8 ?? ?? ?? 48 8B 13 48 8B CB 48 83 C4 20 5B ?? ?? ?? ?? 33 C0 48 83 C4 20 5B C3",
        ida_search.SEARCH_DOWN,
    )
    tif, funcdata = ida_typeinf.tinfo_t(), ida_typeinf.func_type_data_t()
    arg1 = ida_typeinf.funcarg_t()
    arg1.type = get_tinfo_from_type("__int64")
    arg1.name = "a1"
    arg2 = ida_typeinf.funcarg_t()
    arg2.type = get_tinfo_from_type("Component::Exd::SheetsEnum")
    arg2.name = "sheetIndex"
    arg3 = ida_typeinf.funcarg_t()
    arg3.type = get_tinfo_from_type("unsigned int")
    arg3.name = "row"
    arg4 = ida_typeinf.funcarg_t()
    arg4.type = get_tinfo_from_type("__int16")
    arg4.name = "subRow"
    arg5 = ida_typeinf.funcarg_t()
    arg5.type = get_tinfo_from_type("__int64 *")
    arg5.name = "a5"
    arg6 = ida_typeinf.funcarg_t()
    arg6.type = get_tinfo_from_type("__int64 *")
    arg6.name = "a6"

    ida_typeinf.guess_tinfo(tif, ea)
    if not tif.get_func_details(funcdata):
        print("Failed to get func details for GetRowBySheetIndexAndRowId @ %X" % ea)
    else:
        if not funcdata.empty():
            funcdata.clear()
        funcdata.push_back(arg1)
        funcdata.push_back(arg2)
        funcdata.push_back(arg3)

        funcdata.rettype = get_tinfo_from_type("__int64")

        if not tif.create_func(funcdata):
            print("! failed to create function type for GetRowBySheetIndexAndRowId")
            return

        ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

    ea = search_binary(
        0,
        "40 53 55 56 57 41 56 48 83 EC 40 48 8B 05 ?? ?? ?? 01 48 33 C4 48 89 44 24 38 48 8B 49 20 45 8B F1 48 8B B4 24 90 00 00 00 41 8B E8 48 8B BC 24 98 00 00 00 48 8B 01 FF 50 08 48 8B D8 48 85 F6 74 03 48 89 06 48 85 DB 74 61 48 8D 4C 24 28 E8 ?? ?? ?? 01 41 B9 01 00 00 00 66 44 89 74 24 20 4C 8D 44 24 20 8B D5 48 8D 4C 24 28 E8 ?? ?? ?? 01 48 8B 03 48 8D 54 24 28 45 33 C0 48 8B CB FF 50 50 48 8B D8 48 85 FF 74 03 48 89 07 48 85 DB 74 19 48 85 FF 75 09 48 8B 10 48 8B CB FF 52 08 48 8B 03 48 8B CB FF 50 10 EB 02 33 C0 48 8B 4C 24 38 48 33 CC E8 ?? ?? ?? 01 48 83 C4 40 41 5E 5F 5E 5D 5B C3",
        ida_search.SEARCH_DOWN,
    )

    ida_typeinf.guess_tinfo(tif, ea)
    if not tif.get_func_details(funcdata):
        print(
            "Failed to get func details for GetRowBySheetIndexAndRowIdAndSubId @ %X"
            % ea
        )
    else:
        if not funcdata.empty():
            funcdata.clear()
        funcdata.push_back(arg1)
        funcdata.push_back(arg2)
        funcdata.push_back(arg3)
        funcdata.push_back(arg4)
        funcdata.push_back(arg5)
        funcdata.push_back(arg6)

        funcdata.rettype = get_tinfo_from_type("__int64")

        if not tif.create_func(funcdata):
            print(
                "! failed to create function type for GetRowBySheetIndexAndRowIdAndSubId"
            )
            return

        ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

    ea = search_binary(
        0,
        "48 89 5C 24 08 57 48 83 EC 20 48 8B F9 41 8B D8 48 8B 49 20 48 8B 01 ?? ?? ?? 44 8B C3 48 8B CF 48 8B D0 48 8B 5C 24 30 48 83 C4 20 5F E9 ?? ?? ?? ??",
        ida_search.SEARCH_DOWN,
    )

    ida_typeinf.guess_tinfo(tif, ea)
    if not tif.get_func_details(funcdata):
        print("Failed to get func details for GetRowBySheetIndexAndRowIndex @ %X" % ea)
    else:
        if not funcdata.empty():
            funcdata.clear()
        funcdata.push_back(arg1)
        funcdata.push_back(arg2)
        funcdata.push_back(arg3)

        funcdata.rettype = get_tinfo_from_type("__int64")

        if not tif.create_func(funcdata):
            print("! failed to create function type for GetRowBySheetIndexAndRowIndex")
            return

            ida_typeinf.apply_tinfo(ea, tif, ida_typeinf.TINFO_DEFINITE)

    # todo: this doesnt find all getters, there's a few slightly different ones
    # along with others that call different virts in slightly different ways/different args
    for pattern, suffix in exd_func_patterns.items():
        if suffix == None or suffix == "RowCount" or suffix == "SheetIndex":
            do_pattern(pattern, suffix, False)
        else:
            do_pattern(pattern, suffix, True)


class ffxiv_exdgetters_t(idaapi.plugin_t):
    flags = idaapi.PLUGIN_UNL

    wanted_name = "FFXIV - Annotate EXD Getters"
    wanted_hotkey = ""

    comment = "Automagically names EXD getter funcs"
    help = "no"

    def init(self):
        return idaapi.PLUGIN_OK

    def run(self, arg):
        print("run")
        run()

    def term(self):
        pass


def PLUGIN_ENTRY():
    return ffxiv_exdgetters_t()


run()

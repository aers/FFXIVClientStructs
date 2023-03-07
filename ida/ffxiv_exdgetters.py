# ffxiv-exdgetters.py
#
# Automagically labels most exd getter functions along with a hint indicating which sheet/sheet id its fetching from
#

import idaapi
import idc
import ida_bytes

import os
from io import BufferedReader
import enum
import zlib
import json


class SqPackCatergories(enum.IntEnum):
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


class SqPackPlatformId(enum.IntEnum):
    Win32 = 0x0
    PS3 = 0x1
    PS4 = 0x2


class SqPackFileType(enum.IntEnum):
    Empty = 1,
    Standard = 2,
    Model = 3,
    Texture = 4,


class DatBlockType(enum.IntEnum):
    Compressed = 4713,
    Uncompressed = 32000,


class SqPackFileInfo:
    def __init__(self, bytes: bytes, offset: int):
        self.header_size = int.from_bytes(bytes[0:4], byteorder='little')
        self.type = SqPackFileType(int.from_bytes(bytes[4:8], byteorder='little'))
        self.raw_file_size = int.from_bytes(bytes[8:12], byteorder='little')
        self.unknown = [int.from_bytes(bytes[12:16], byteorder='little'), int.from_bytes(bytes[16:20], byteorder='little')]
        self.number_of_blocks = int.from_bytes(bytes[20:24], byteorder='little')
        self.offset = offset


class DatStdFileBlockInfos:
    def __init__(self, bytes: bytes):
        self.offset = int.from_bytes(bytes[0:4], byteorder='little')
        self.compressed_size = int.from_bytes(bytes[4:6], byteorder='little')
        self.uncompressed_size = int.from_bytes(bytes[6:8], byteorder='little')


class DatBlockHeader:
    def __init__(self, bytes: bytes):
        self.size = int.from_bytes(bytes[0:4], byteorder='little')
        self.unknown1 = int.from_bytes(bytes[4:8], byteorder='little')
        self.block_data_size = int.from_bytes(bytes[8:12], byteorder='little')
        self.dat_block_type = int.from_bytes(bytes[12:16], byteorder='little')

    def __str__(self):
        return f'''Size: {self.size} Unknown1: {self.unknown1} DatBlockType: {self.dat_block_type} BlockDataSize: {self.block_data_size}'''


class SqPackHeader:
    def __init__(self, file: BufferedReader):
        self.magic = file.read(8)
        self.platform_id = SqPackPlatformId(int.from_bytes(file.read(1), byteorder='little'))
        self.unknown = file.read(3)
        if (self.platform_id != SqPackPlatformId.PS3):
            self.size = int.from_bytes(file.read(4), byteorder='little')
            self.version = int.from_bytes(file.read(4), byteorder='little')
            self.type = int.from_bytes(file.read(4), byteorder='little')
        else:
            raise Exception('PS3 is not supported')

    def __str__(self):
        return f'''Magic: {self.magic} Platform: {self.platform_id} Size: {self.size} Version: {self.version} Type: {self.type}'''


class SqPackIndexHeader:
    def __init__(self, bytes: bytes):
        self.size = int.from_bytes(bytes[0:4], byteorder='little')
        self.version = int.from_bytes(bytes[4:8], byteorder='little')
        self.index_data_offset = int.from_bytes(bytes[8:12], byteorder='little')
        self.index_data_size = int.from_bytes(bytes[12:16], byteorder='little')
        self.index_data_hash = bytes[16:80]
        self.number_of_data_file = int.from_bytes(bytes[80:84], byteorder='little')
        self.synonym_data_offset = int.from_bytes(bytes[84:88], byteorder='little')
        self.synonym_data_size = int.from_bytes(bytes[88:92], byteorder='little')
        self.synonym_data_hash = bytes[92:156]
        self.empty_block_data_offset = int.from_bytes(bytes[156:160], byteorder='little')
        self.empty_block_data_size = int.from_bytes(bytes[160:164], byteorder='little')
        self.empty_block_data_hash = bytes[164:228]
        self.dir_index_data_offset = int.from_bytes(bytes[228:232], byteorder='little')
        self.dir_index_data_size = int.from_bytes(bytes[232:236], byteorder='little')
        self.dir_index_data_hash = bytes[236:300]
        self.index_type = int.from_bytes(bytes[300:304], byteorder='little')
        self.reserved = bytes[304:960]
        self.hash = bytes[960:1024]

    def __str__(self):
        return f'''Size: {self.size} Version: {self.version} Index Data Offset: {self.index_data_offset} Index Data Size: {self.index_data_size} Index Data Hash: {self.index_data_hash} Number Of Data File: {self.number_of_data_file} Synonym Data Offset: {self.synonym_data_offset} Synonym Data Size: {self.synonym_data_size} Synonym Data Hash: {self.synonym_data_hash} Empty Block Data Offset: {self.empty_block_data_offset} Empty Block Data Size: {self.empty_block_data_size} Empty Block Data Hash: {self.empty_block_data_hash} Dir Index Data Offset: {self.dir_index_data_offset} Dir Index Data Size: {self.dir_index_data_size} Dir Index Data Hash: {self.dir_index_data_hash} Index Type: {self.index_type} Reserved: {self.reserved} Hash: {self.hash}'''


class SqPackIndexHashTable:
    def __init__(self, bytes: bytes):
        self.hash = int.from_bytes(bytes[0:8], byteorder='little')
        self.data = int.from_bytes(bytes[8:12], byteorder='little')
        self.padding = int.from_bytes(bytes[12:16], byteorder='little')

    def is_synonym(self):
        return (self.data & 0b1) == 0b1

    def data_file_id(self):
        return (self.data & 0b1110) >> 1

    def data_file_offset(self):
        return (self.data & ~0xF) * 0x08

    def __str__(self):
        return f'''Hash: {self.hash} Data: {self.data} Padding: {self.padding} Is Synonym: {self.is_synonym()} Data File ID: {self.data_file_id()} Data File Offset: {self.data_file_offset()}'''


class SqPack:
    def __init__(self, root: str, path: str):
        self.root = root
        self.path = path
        self.file = open(path, 'rb')
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
        for file in get_sqpack_files(self.root, self.path.rsplit('\\', 1)[0].split('\\')[-1]):
            for i in range(0, self.index_header.number_of_data_file):
                name = self.path.rsplit('.', 1)[0] + '.dat' + str(i)
                if file == name:
                    self.data_files.append(file)

    def read_file(self, offset: int):
        if self.path.rsplit('.', 1)[1][0:3] != 'dat':
            raise Exception('Not a data file')
        self.file.seek(offset)
        file_info_bytes = self.file.read(24)
        file_info = SqPackFileInfo(file_info_bytes, offset)
        data: list[bytes] = []
        if file_info.type == SqPackFileType.Empty:
            raise Exception(f'File located at 0x{hex(offset)} is empty.')
        elif file_info.type == SqPackFileType.Standard:
            data = self.read_standard_file(file_info)
        else:
            raise Exception('Type: ' + str(file_info.type) + ' not implemented.')
        return data

    def read_standard_file(self, file_info: SqPackFileInfo):
        block_bytes = self.file.read(file_info.number_of_blocks*8)
        data: list[bytes] = []
        for i in range(file_info.number_of_blocks):
            block = DatStdFileBlockInfos(block_bytes[i*8:i*8+8])
            self.file.seek(file_info.offset + file_info.header_size + block.offset)
            block_header = DatBlockHeader(self.file.read(16))
            if(block_header.dat_block_type == 32000):
                data.append(self.file.read(block_header.block_data_size))
            else:
                data.append(zlib.decompress(self.file.read(block_header.block_data_size), wbits=-15))

        return data
    
    def __str__(self):
        return f'''Path: {os.path.join(self.root, 'sqpack', self.path)} Header: {self.header}'''


class Repository:
    def __init__(self, name: str, root: str):
        self.root = root
        self.name = name
        self.sqpacks: list[SqPack] = []
        self.index: dict[int, tuple[SqPackIndexHashTable, SqPack]] = {}
        self.expansion_id = 0
        self.get_expansion_id()

    def get_expansion_id(self):
        if (self.name.startswith('ex')):
            self.expansion_id = int(self.name.removeprefix('ex'))

    def parse_version(self):
        versionPath = ""
        if (self.name == 'ffxiv'):
            versionPath = os.path.join(self.root, 'ffxivgame.ver')
        else:
            versionPath = os.path.join(self.root, 'sqpack', self.name, self.name + '.ver')
        with open(versionPath, 'r') as f:
            self.version = f.read().strip()
        print(f'Found {self.name} version {self.version}')

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
    
    def __str__(self):
        return f'''Repository: {self.name} ({self.version}) - {self.expansion_id}'''


class GameData:
    def __init__(self, root: str):
        self.root = root
        self.repositories: dict[int, Repository] = {}
        self.setup()

    def get_repo_index(self, folder: str):
        if (folder == 'ffxiv'):
            return 0
        else:
            return int(folder.removeprefix('ex'))

    def setup(self):
        for folder in get_game_data_folders(self.root):
            self.repositories[self.get_repo_index(folder)] = Repository(folder, self.root)

        for folder in self.repositories:
            repo = self.repositories[folder]
            repo.parse_version()
            repo.setup_indexes()

    def get_file(self, file: 'ParsedFileName'):
        return self.repositories[self.get_repo_index(file.repo)].get_file(file.index)

    def __str__(self):
        return f'''Repositories: {self.repositories}'''


class ExcelListFile:
    def __init__(self, data: list[bytes]):
        self.data = b''.join(data).split('\r\n'.encode('utf-8'))
        self.parse()

    def parse(self):
        self.header = self.data[0].decode('utf-8').split(',')
        self.version = int(self.header[1])
        self.data = self.data[1:]
        self.dict: dict[int, str] = {}
        for line in [x.decode('utf-8') for x in self.data]:
            if line == '':
                continue
            linearr = line.split(',')
            if linearr[1] == '-1':
                continue
            self.dict[int(linearr[1])] = linearr[0]
        

class ParsedFileName:
    def __init__(self, path: str):
        self.path = path.lower().strip()
        parts = self.path.split('/')
        self.category = parts[0]
        self.index = crc.calc_index(self.path)
        self.index2 = crc.calc_index2(self.path)
        self.repo = parts[1]
        if self.repo[0] != 'e' or self.repo[1] != 'x' or not self.repo[2].isdigit():
            self.repo = 'ffxiv'


class Crc32:
    def __init__(self):
        self.poly = 0xEDB88320
        self.table = [0] * 256 * 16
        for i in range(256):
            res = i
            for j in range(16):
                for k in range(8):
                    if res & 1:
                        res = (res >> 1) ^ self.poly
                    else:
                        res >>= 1
                self.table[i + j * 256] = res

    def calc(self, value: bytes):
        start = 0
        size = len(value)
        crc_local = 4294967295 ^ 0
        while size >= 16:
            a = self.table[(3*256) + value[start + 12]] ^ self.table[(2*256) + value[start + 13]] ^ self.table[(1*256) + value[start + 14]] ^ self.table[(0*256) + value[start + 15]]
            b = self.table[(7*256) + value[start + 8]] ^ self.table[(6*256) + value[start + 9]] ^ self.table[(5*256) + value[start + 10]] ^ self.table[(4*256) + value[start + 11]]
            c = self.table[(11*256) + value[start + 4]] ^ self.table[(10*256) + value[start + 5]] ^ self.table[(9*256) + value[start + 6]] ^ self.table[(8*256) + value[start + 7]]
            d = self.table[(15*256) + value[start + 0]] ^ self.table[(14*256) + value[start + 1]] ^ self.table[(13*256) + value[start + 2]] ^ self.table[(12*256) + value[start + 3]]
            crc_local = d ^ c ^ b ^ a
            start += 16
            size -= 16

        while size > 0:
            crc_local = self.table[(crc_local ^ value[start]) & 0xFF] ^ (crc_local >> 8)
            start += 1
            size -= 1

        return ~(crc_local ^ 4294967295) % (1 << 32)

    def calc_index(self, path: str):
        path_parts = path.split('/')
        filename = path_parts[-1]
        folder = path.rstrip(filename).rstrip('/')

        foldercrc = self.calc(folder.encode('utf-8'))
        filecrc = self.calc(filename.encode('utf-8'))

        return foldercrc << 32 | filecrc

    def calc_index2(self, path: str):
        return self.calc(path.encode('utf-8'))


crc = Crc32()


def get_game_data_folders(root: str):
    for folder in os.listdir(os.path.join(root, 'sqpack')):
        if (os.path.isdir(os.path.join(root, 'sqpack', folder))):
            yield folder


def get_files(path):
    files: list[bytes] = []
    for (dir_path, dir_names, file_names) in os.walk(path):
        files.extend(os.path.join(dir_path, file) for file in file_names)

    return files


def get_sqpack_files(root: str, path: str):
    for file in get_files(os.path.join(root, 'sqpack', path)):
        ext = file.split('.')[-1]
        if (ext.startswith('dat')):
            yield file


def get_sqpack_index(root: str, path: str):
    for file in get_files(os.path.join(root, 'sqpack', path)):
        if (file.endswith('.index')):
            yield file


def get_sqpack_index2(root: str, path: str):
    for file in get_files(os.path.join(root, 'sqpack', path)):
        if (file.endswith('.index2')):
            yield file

f = open(os.path.join(os.getenv('APPDATA'), 'XIVLauncher', 'launcherConfigV3.json'), 'r')

config = json.load(f)

f.close()

game_data = GameData(os.path.join(config['GamePath'], 'game'))

# nb: "pattern": "func suffix" OR None
exd_func_patterns = {
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": None,
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 44 0F B6 C1 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": None,
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8D 81 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": None,
    "48 83 EC 38 48 8B 05 ? ? ? ? 44 8B CA 44 8B C1 48 C7 44 24 ? ? ? ? ? BA ? ? ? ? 48 C7 44 24 ? ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 05 48 83 C4 38 C3 48 8B 00 48 83 C4 38 C3": None,
    "48 83 EC 28 48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 74 14 48 8B 10 48 8B C8 FF 52 08 84 C0 75 07 B0 01 48 83 C4 28 C3 32 C0 48 83 C4 28 C3": None,
    "48 83 EC 28 85 C9 74 20 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 75 07 33 C0 48 83 C4 28 C3 48 8B 00 48 83 C4 28 C3": None,
    "48 83 EC 28 48 8B 05 ? ? ? ? 44 8B C1 BA ? ? ? ? 48 8B 88 ? ? ? ? E8 ? ? ? ? 48 85 C0 74 17 48 8B 08 48 85 C9 74 0F 8B 01 25 ? ? ? ? 48 03 C1 48 83 C4 28 C3 33 C0 48 83 C4 28 C3": None,

    # unsure if this is totally accurate but it looks to be the case
    "48 8B 05 ? ? ? ? BA ? ? ? ? 48 8B 88 ? ? ? ? E9 ? ? ? ?": "::rowCount"
}

# todo: figure out how/where these exd getters are used
# .text:0000000140622200                         sub_140622200   proc near               ; CODE XREF: sub_14067D8E0+D3
# .text:0000000140622200 48 8B 05 F1 7F 46 01                    mov     rax, cs:qword_141A8A1F8
# .text:0000000140622207 BA 59 01 00 00                          mov     edx, 159h
# .text:000000014062220C 48 8B 88 E8 2B 00 00                    mov     rcx, [rax+2BE8h]
# .text:0000000140622213 E9 28 E2 E2 FF                          jmp     sub_140450440
# .text:0000000140622213                         sub_140622200   endp
exd_map = ExcelListFile(game_data.get_file(ParsedFileName('exd/root.exl'))).dict

def do_pattern(pattern, suffix = ""):
    ea = 0

    while True:
        ea = idc.find_binary(ea + 1, idc.SEARCH_DOWN, pattern)

        if ea == 0xFFFFFFFFFFFFFFFF:
            break

        # this is mega retarded but it works rofl
        ins = idc.find_binary(ea, idc.SEARCH_DOWN, "BA ? ? ? ?")
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

            print("found exd func @ %x -> mapped to %s (%i)" % (ea, sheetName, sheetIdx))

            idc.set_name(ea, fnName)
            idc.set_cmt(ins, "Sheet: %s (%i)" % (sheetName, sheetIdx), 0)


def run():
    # todo: this doesnt find all getters, there's a few slightly different ones
    # along with others that call different virts in slightly different ways/different args
    for pattern, suffix in exd_func_patterns.items():
        do_pattern(pattern, suffix)


class ffxiv_exdgetters_t(idaapi.plugin_t):
    flags = idaapi.PLUGIN_UNL

    wanted_name = "FFXIV - Annotate EXD Getters"
    wanted_hotkey = ""

    comment = 'Automagically names EXD getter funcs'
    help = 'no'
 
    def init(self):
        return idaapi.PLUGIN_OK
 
    def run(self, arg):
        print('run')
        run()
 
    def term(self):
        pass
 
def PLUGIN_ENTRY():
    return ffxiv_exdgetters_t()

run()
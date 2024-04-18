from luminapie.enums import SqPackFileType, SqPackPlatformId
from io import BufferedReader
import os
import zlib
from luminapie.file_handlers import get_sqpack_files


class SqPackFileInfo:
    def __init__(self, bytes: bytes, offset: int):
        self.header_size = int.from_bytes(bytes[0:4], byteorder='little')
        self.type = SqPackFileType(int.from_bytes(bytes[4:8], byteorder='little'))
        self.raw_file_size = int.from_bytes(bytes[8:12], byteorder='little')
        self.unknown = [
            int.from_bytes(bytes[12:16], byteorder='little'),
            int.from_bytes(bytes[16:20], byteorder='little'),
        ]
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

    def __repr__(self):
        return f'''Size: {self.size} Unknown1: {self.unknown1} DatBlockType: {self.dat_block_type} BlockDataSize: {self.block_data_size}'''


class SqPackHeader:
    def __init__(self, file: BufferedReader):
        self.magic = file.read(8)
        self.platform_id = SqPackPlatformId(int.from_bytes(file.read(1), byteorder='little'))
        self.unknown = file.read(3)
        if self.platform_id != SqPackPlatformId.PS3:
            self.size = int.from_bytes(file.read(4), byteorder='little')
            self.version = int.from_bytes(file.read(4), byteorder='little')
            self.type = int.from_bytes(file.read(4), byteorder='little')
        else:
            raise Exception('PS3 is not supported')

    def __repr__(self):
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

    def __repr__(self):
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

    def __repr__(self):
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
        block_bytes = self.file.read(file_info.number_of_blocks * 8)
        data: list[bytes] = []
        for i in range(file_info.number_of_blocks):
            block = DatStdFileBlockInfos(block_bytes[i * 8 : i * 8 + 8])
            self.file.seek(file_info.offset + file_info.header_size + block.offset)
            block_header = DatBlockHeader(self.file.read(16))
            if block_header.dat_block_type == 32000:
                data.append(self.file.read(block_header.block_data_size))
            else:
                data.append(zlib.decompress(self.file.read(block_header.block_data_size), wbits=-15))

        return data

    def __repr__(self):
        return f'''Path: {os.path.join(self.root, 'sqpack', self.path)} Header: {self.header}'''

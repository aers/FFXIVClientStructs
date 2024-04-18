from luminapie.sqpack import SqPack, SqPackIndexHashTable
from luminapie.file_handlers import get_game_data_folders, get_sqpack_index
from luminapie.se_crc import Crc32
from luminapie.exdschema import get_definitions
from luminapie.definitions import SemanticVersion
import os

crc = Crc32()


class Repository:
    def __init__(self, name: str, root: str):
        self.root = root
        self.name = name
        self.sqpacks: list[SqPack] = []
        self.index: dict[int, tuple[SqPackIndexHashTable, SqPack]] = {}
        self.expansion_id = 0
        self.get_expansion_id()

    def get_expansion_id(self):
        if self.name.startswith('ex'):
            self.expansion_id = int(self.name.removeprefix('ex'))

    def parse_version(self):
        versionPath = ""
        if self.name == 'ffxiv':
            versionPath = os.path.join(self.root, 'ffxivgame.ver')
        else:
            versionPath = os.path.join(self.root, 'sqpack', self.name, self.name + '.ver')
        if os.path.exists(versionPath):
            with open(versionPath, 'r') as f:
                self.version = SemanticVersion(*(int(v) for v in f.read().strip().split('.')))
        else:
            self.version = SemanticVersion(0, 0, 0, 0)

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

    def __repr__(self):
        return f'''Repository: {self.name} ({self.version}) - {self.expansion_id}'''


class GameData:
    def __init__(self, root: str, load_schema: bool = True):
        self.root = root
        self.repositories: dict[int, Repository] = {}
        self.load_schema = load_schema
        self.setup()

    def get_repo_index(self, folder: str):
        if folder == 'ffxiv':
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

        if self.load_schema:
            self.schema = get_definitions(self.repositories[0].version)

    def get_file(self, file: 'ParsedFileName'):
        return self.repositories[self.get_repo_index(file.repo)].get_file(file.index)

    def get_exd_schema(self, key: str):
        return self.schema[key]

    def __repr__(self):
        return f'''Repositories: {self.repositories}'''


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

    def __repr__(self):
        return f'''ParsedFileName: {self.path}, category: {self.category}, index: {self.index:X}, index2: {self.index2:X}, repo: {self.repo}'''

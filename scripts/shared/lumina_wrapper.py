from urllib.request import urlopen
from zipfile import ZipFile
from io import BytesIO
from os.path import join, basename, abspath, dirname, isdir, isfile
from os import getenv, getcwd, makedirs, listdir
from sys import path
from shutil import rmtree
from xml.dom import pulldom
from pythonnet import load as dotnetload
from json import load as jsonload
from yaml import load as yamlload, dump as yamldump
from yaml_loader import Loader, Dumper
from typing import Callable
from enum import IntEnum
import re
from dataclasses import dataclass
import gc

default_game_path = r"C:\Program Files (x86)\SquareEnix\FINAL FANTASY XIV - A Realm Reborn"
steam_install_folder = "FINAL FANTASY XIV Online"
# one file per data.yml version, so Lumina only reads the game once for each version
excel_header_folder = abspath(join(dirname(__file__), "..", "excel_headers"))


def is_game_path(game_path: str | None) -> bool:
    """If the folder holds both game and boot."""
    return bool(game_path) and isdir(join(game_path, "game", "sqpack")) and isdir(join(game_path, "boot"))


def _get_xlcore_game_path() -> str | None:
    if getenv("HOME") is None:
        return None
    launcher_ini = join(getenv("HOME"), ".xlcore", "launcher.ini")
    if not isfile(launcher_ini):
        return None
    with open(launcher_ini, "r") as f:
        for line in f:
            if line.startswith("GamePath="):
                return line.split("=", 1)[1].strip()
    return None


def _get_xivlauncher_game_path() -> str | None:
    if getenv("APPDATA") is None:
        return None
    launcher_config = join(getenv("APPDATA"), "XIVLauncher", "launcherConfigV3.json")
    if not isfile(launcher_config):
        return None
    with open(launcher_config, "r") as f:
        return jsonload(f).get("GamePath")


def _get_steam_paths() -> list[str]:
    steam_paths = []
    try:
        import winreg

        with winreg.OpenKey(winreg.HKEY_CURRENT_USER, r"Software\Valve\Steam") as key:
            steam_paths.append(winreg.QueryValueEx(key, "SteamPath")[0])
    except (ImportError, OSError):
        pass
    steam_paths.append(r"C:\Program Files (x86)\Steam")
    if getenv("HOME") is not None:
        steam_paths.extend(
            join(getenv("HOME"), *folder)
            for folder in (
                (".local", "share", "Steam"),
                (".steam", "steam"),
                (".var", "app", "com.valvesoftware.Steam", ".local", "share", "Steam"),
            )
        )
    return steam_paths


def _get_steam_game_paths() -> list[str]:
    """The game folder in every Steam library."""
    libraries = []
    for steam_path in _get_steam_paths():
        libraries.append(steam_path)
        library_folders = join(steam_path, "steamapps", "libraryfolders.vdf")
        if isfile(library_folders):
            with open(library_folders, "r", encoding="utf-8") as f:
                libraries.extend(
                    library.replace("\\\\", "\\")
                    for library in re.findall(r'"path"\s+"([^"]+)"', f.read())
                )
    return [join(library, "steamapps", "common", steam_install_folder) for library in dict.fromkeys(libraries)]


def find_game_path() -> str | None:
    """The game install from it's known locations, None if none of them hold it."""
    for get_paths in (
        lambda: [_get_xlcore_game_path()],
        lambda: [_get_xivlauncher_game_path()],
        lambda: [default_game_path],
        _get_steam_game_paths,
    ):
        try:
            game_paths = get_paths()
        except (OSError, ValueError):
            # a config that can not be read is the same as not having one
            continue
        for game_path in game_paths:
            if is_game_path(game_path):
                return game_path
    return None


class ExcelColumnDataType(IntEnum):
    String = 0x0
    Bool = 0x1
    Int8 = 0x2
    UInt8 = 0x3
    Int16 = 0x4
    UInt16 = 0x5
    Int32 = 0x6
    UInt32 = 0x7
    # unused?
    Unk = 0x8
    Float32 = 0x9
    Int64 = 0xA
    UInt64 = 0xB
    # unused?
    Unk2 = 0xC
    # 0 is read like data & 1, 1 is like data & 2, 2 = data & 4, etc...
    PackedBool0 = 0x19
    PackedBool1 = 0x1A
    PackedBool2 = 0x1B
    PackedBool3 = 0x1C
    PackedBool4 = 0x1D
    PackedBool5 = 0x1E
    PackedBool6 = 0x1F
    PackedBool7 = 0x20


@dataclass
class ExcelColumnDefinition:
    type: ExcelColumnDataType
    offset: int

    def is_packed_bool(self):
        return self.type >= ExcelColumnDataType.PackedBool0

    def get_base_type_string(self):
        match self.type:
            case ExcelColumnDataType.Bool:
                return "bool"
            case ExcelColumnDataType.UInt8:
                return "uint8_t"
            case ExcelColumnDataType.Int8:
                return "int8_t"
            case ExcelColumnDataType.UInt16:
                return "uint16_t"
            case ExcelColumnDataType.Int16:
                return "int16_t"
            case ExcelColumnDataType.String | ExcelColumnDataType.UInt32:
                return "uint32_t"
            case ExcelColumnDataType.Int32:
                return "int32_t"
            case ExcelColumnDataType.Float32:
                return "float"
            case ExcelColumnDataType.Int64:
                return "int64_t"
            case ExcelColumnDataType.UInt64:
                return "uint64_t"
            case _ if self.is_packed_bool():
                return "uint8_t"
            case _:
                raise ValueError(f"Unhandled type: {self.type}")

    def __lt__(self, other):
        return self.offset < other.offset

    def __repr__(self):
        return self.get_base_type_string()


def get_nugpkg_and_extract(tempdirname: str, package: str, version: str = ""):
    with urlopen(
        f"https://www.nuget.org/api/v2/package/{package}/{version}"
    ) as response:
        nupkg = response.read()
        with ZipFile(BytesIO(nupkg)) as z:
            for file in z.namelist():
                file_path = join(tempdirname, basename(file))
                with open(file_path, "wb") as f:
                    f.write(z.read(file))


def get_nugpkg_deps(nuspec_path: str) -> list[tuple[str, str]]:
    deps = []
    stream = pulldom.parse(nuspec_path)
    for event, node in stream:
        if event == "START_ELEMENT" and node.nodeName == "dependency":
            stream.expandNode(node)
            deps.append((node.getAttribute("id"), node.getAttribute("version")))
    return deps


def get_nugpkg(tempdirname: str, package: str, version: str = ""):
    ver_str = f"version {version}" if version != "" else "latest version"
    print(f"Requesting nugpkg {package} with {ver_str}")
    get_nugpkg_and_extract(tempdirname, package, version)
    return get_nugpkg_deps(join(tempdirname, f"{package}.nuspec"))


def get_excel_header_file_path(version: str) -> str:
    return join(excel_header_folder, f"{version}.yml")


def _load_excel_header_files(file_path: str) -> dict[str, tuple[int, list[ExcelColumnDefinition]]]:
    with open(file_path, "r", encoding="utf-8") as f:
        excel_header_files = yamlload(f, Loader)
    return {
        name: (id, [ExcelColumnDefinition(type, offset) for type, offset in columns])
        for name, (id, columns) in excel_header_files.items()
    }


def _save_excel_header_files(file_path: str, excel_header_files: dict[str, tuple[int, list[ExcelColumnDefinition]]]):
    makedirs(excel_header_folder, exist_ok=True)
    with open(file_path, "w", encoding="utf-8") as f:
        yamldump(
            {
                name: [id, [[int(column.type), column.offset] for column in columns]]
                for name, (id, columns) in excel_header_files.items()
            },
            f, Dumper, default_flow_style=None, sort_keys=False, width=1 << 16,
        )


def get_excel_header_files(
    version: str | None, get_game_path: Callable[[], str]
) -> dict[str, tuple[int, list[ExcelColumnDefinition]]]:
    """The saved headers of the version, read with Lumina if there are none."""
    if not version:
        return _read_excel_header_files(get_game_path())

    file_path = get_excel_header_file_path(version)
    if isfile(file_path):
        print(f"Using Excel headers from {file_path}")
        return _load_excel_header_files(file_path)

    excel_header_files = _read_excel_header_files(get_game_path())
    _save_excel_header_files(file_path, excel_header_files)
    print(f"Saved Excel headers to {file_path}")
    return excel_header_files


def _read_excel_header_files(game_path: str) -> dict[str, tuple[int, list[ExcelColumnDefinition]]]:
    """The headers Lumina reads from the game install."""
    tempdirname = join(getcwd(), "luminatmp")
    makedirs(tempdirname, exist_ok=True)
    dotnetload("coreclr")
    def _isolated_clr():
        import clr

        deps = get_nugpkg(tempdirname, "Lumina")
        deps_gotten: dict[str, str] = {}

        while len(deps) > 0:
            local_deps = []
            for package, version in deps:
                if package not in deps_gotten or deps_gotten[package] != version:
                    local_deps.extend(get_nugpkg(tempdirname, package, version))
                    deps_gotten[package] = version
            deps = local_deps

        path.append(tempdirname)

        from System.Runtime.Loader import AssemblyLoadContext # type: ignore
        from System import Activator, GC # type: ignore
        from System.IO import File, MemoryStream # type: ignore

        ctx = AssemblyLoadContext("temp", isCollectible=True)

        def _isolated_extract(context):
            assemblies: dict = {}

            for file in listdir(tempdirname):
                if file.endswith(".dll"):
                    # LoadFromAssemblyPath would keep the file locked until the process exits
                    assemblies[file] = context.LoadFromStream(
                        MemoryStream(File.ReadAllBytes(abspath(join(tempdirname, file))))
                    )

            assembly = assemblies["Lumina.dll"]
            game_data_type = assembly.GetType("Lumina.GameData")
            game_data_instance = Activator.CreateInstance(
                game_data_type, [join(game_path, "game", "sqpack"), None]
            )

            excel_list_type = assembly.GetType("Lumina.Data.Files.Excel.ExcelListFile")
            excel_header_type = assembly.GetType("Lumina.Data.Files.Excel.ExcelHeaderFile")

            root_exl = game_data_instance.GetFile[excel_list_type]("exd/root.exl")

            excel_header_files: dict[str, tuple[int, list[ExcelColumnDefinition]]] = {}

            for kvp in root_exl.ExdMap:
                key = kvp.Key
                value = kvp.Value

                if value != -1:
                    defs: list[ExcelColumnDefinition] = []
                    header = game_data_instance.GetFile[excel_header_type](f"exd/{key}.exh")
                    for column_definition in header.ColumnDefinitions:
                        defs.append(
                            ExcelColumnDefinition(
                                int(column_definition.Type), column_definition.Offset
                            )
                        )
                    excel_header_files[key] = (value, sorted(defs))
            

            return excel_header_files

        excel_header_files = _isolated_extract(ctx)

        ctx.Unload()

        del ctx

        gc.collect()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        return excel_header_files

    # pythonnet.unload() would break every later use of clr in the same process
    excel_header_files = _isolated_clr()

    rmtree(tempdirname, ignore_errors=True)

    return excel_header_files

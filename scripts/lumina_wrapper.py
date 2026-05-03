from urllib.request import urlopen
from zipfile import ZipFile
from io import BytesIO
from os.path import join, basename, abspath
from os import getenv, getcwd, makedirs, listdir
from sys import platform, path
from shutil import rmtree
from xml.dom import pulldom
from pythonnet import load as dotnetload
from json import load as jsonload
from enum import IntEnum
from dataclasses import dataclass

dotnetload("coreclr")
import clr

tempdirname = join(getcwd(), "luminatmp")
try:
    rmtree(tempdirname)
except:
    pass  # ignore error
finally:
    makedirs(tempdirname)

if platform.startswith("linux"):
    launcher_ini = join(getenv("HOME"), ".xlcore", "launcher.ini")
    game_path = None

    f = open(launcher_ini, "r")
    try:
        for line in f:
            if line.startswith("GamePath="):
                game_path = line.split("=", 1)[1].strip()
                break
    finally:
        f.close()

    if not game_path:
        raise ValueError("GamePath key not found in {0}".format(launcher_ini))
else:
    f = open(join(getenv("APPDATA"), "XIVLauncher", "launcherConfigV3.json"), "r")
    try:
        config = jsonload(f)
    finally:
        f.close()
    game_path = config["GamePath"]


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
            case ExcelColumnDataType.Bool | ExcelColumnDataType.UInt8:
                return "size8_t"
            case ExcelColumnDataType.Int8:
                return "size8_st"
            case ExcelColumnDataType.UInt16:
                return "size16_t"
            case ExcelColumnDataType.Int16:
                return "size16_st"
            case ExcelColumnDataType.String | ExcelColumnDataType.UInt32:
                return "size32_t"
            case ExcelColumnDataType.Int32:
                return "size32_st"
            case ExcelColumnDataType.Float32:
                return "float"
            case ExcelColumnDataType.Int64:
                return "size64_st"
            case ExcelColumnDataType.UInt64:
                return "size64_t"
            case _ if self.is_packed_bool():
                return "size8_t"
            case _:
                raise ValueError(f"Unhandled type: {self.type}")

    def __lt__(self, other):
        return self.offset < other.offset


def get_nugpkg_and_extract(package: str, version: str = ""):
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


def get_nugpkg(package: str, version: str = ""):
    ver_str = f"version {version}" if version != "" else "latest version"
    print(f"Requesting nugpkg {package} with {ver_str}")
    get_nugpkg_and_extract(package, version)
    return get_nugpkg_deps(join(tempdirname, f"{package}.nuspec"))


def get_excel_header_files() -> dict[str, list[ExcelColumnDefinition]]:
    deps = get_nugpkg("Lumina")
    deps_gotten: dict[str, str] = {}

    while len(deps) > 0:
        local_deps = []
        for package, version in deps:
            if package not in deps_gotten or deps_gotten[package] != version:
                local_deps.extend(get_nugpkg(package, version))
                deps_gotten[package] = version
        deps = local_deps

    path.append(tempdirname)

    from System.Runtime.Loader import AssemblyLoadContext # type: ignore
    from System import Activator # type: ignore

    ctx = AssemblyLoadContext("temp", isCollectible=True)
    assemblies: dict = {}

    for file in listdir(tempdirname):
        if file.endswith(".dll"):
            assemblies[file] = ctx.LoadFromAssemblyPath(
                abspath(join(tempdirname, file))
            )

    assembly = assemblies["Lumina.dll"]
    game_data_type = assembly.GetType("Lumina.GameData")
    game_data_instance = Activator.CreateInstance(
        game_data_type, [join(game_path, "game", "sqpack"), None]
    )

    excel_list_type = assembly.GetType("Lumina.Data.Files.Excel.ExcelListFile")
    excel_header_type = assembly.GetType("Lumina.Data.Files.Excel.ExcelHeaderFile")

    root_exl = game_data_instance.GetFile[excel_list_type]("exd/root.exl")

    excel_files: dict[int, str] = {}
    excel_header_files: dict[str, list[ExcelColumnDefinition]] = {}

    for kvp in root_exl.ExdMap:
        key = kvp.Key
        value = kvp.Value
        if value != -1:
            excel_files[value] = key

        if value != -1:
            defs: list[ExcelColumnDefinition] = []
            header = game_data_instance.GetFile[excel_header_type](f"exd/{key}.exh")
            for column_definition in header.ColumnDefinitions:
                defs.append(
                    ExcelColumnDefinition(
                        int(column_definition.Type), column_definition.Offset
                    )
                )
            excel_header_files[key] = sorted(defs)

    return excel_header_files

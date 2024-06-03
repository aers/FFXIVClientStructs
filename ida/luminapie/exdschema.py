from urllib.request import urlopen, Request
from urllib.error import HTTPError, URLError
from json import loads
from luminapie.definitions import (
    Definition,
    RepeatDefinition,
    get_definition,
    SemanticVersion,
)
from yaml import load, Loader
from zipfile import ZipFile
from tempfile import TemporaryFile


def get_url(url, supress=False):
    # type: (str, bool) -> bytes | None
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


def get_latest_schema():
    # type: () -> dict[SemanticVersion, str]
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


def get_latest_schema_url(ver):
    # type: (SemanticVersion) -> str
    latest_release = get_latest_schema()
    # check if the current version can be retrieved
    if ver in latest_release:
        return latest_release[ver]
    # grab the version before the current version if it can't be retrieved
    for version in latest_release:
        if version < ver:
            return latest_release[version]


def get_definitions(schema):
    # type: (SemanticVersion) -> dict[str, list[Definition]]
    exd_schema_map = {}
    with TemporaryFile() as f:
        f.write(get_url(get_latest_schema_url(schema), True))
        f.seek(0)
        schema_zip = ZipFile(f)

        for file in schema_zip.namelist():
            if file.endswith(".yml"):
                schema_yml = load(schema_zip.read(file), Loader=Loader)
                exd_schema_map[file.rsplit(".", 1)[0].rsplit("/", 1)[1]] = schema_yml[
                    "fields"
                ]

    defs_map = {}
    for exd in exd_schema_map:
        defs = []
        for field in exd_schema_map[exd]:
            defin = get_definition(field)
            if isinstance(defin, RepeatDefinition):
                defs.extend(defin.flatten(""))
            else:
                defs.append(defin)
        defs_map[exd] = defs
    return defs_map

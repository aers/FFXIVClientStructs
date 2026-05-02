from urllib.request import urlopen, Request
from urllib.error import HTTPError, URLError
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


# TODO: Add the ability to use previous version schemas as well
def get_definitions(schema):
    # type: (SemanticVersion) -> dict[str, list[Definition]]
    exd_schema_map = {}
    with TemporaryFile() as f:
        f.write(
            get_url(
                "https://github.com/xivdev/EXDSchema/archive/refs/heads/latest.zip",
                True,
            )
        )
        f.seek(0)
        schema_zip = ZipFile(f)

        for file in schema_zip.namelist():
            if file.endswith(".yml") and ".github" not in file:
                schema_yml = load(schema_zip.read(file), Loader=Loader)
                if "pendingFields" in schema_yml:
                    exd_schema_map[file.rsplit(".", 1)[0].rsplit("/")[1]] = schema_yml[
                        "pendingFields"
                    ]
                else:
                    exd_schema_map[file.rsplit(".", 1)[0].rsplit("/")[1]] = schema_yml[
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

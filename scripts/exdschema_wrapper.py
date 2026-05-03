from urllib.request import urlopen
from zipfile import ZipFile
from io import BytesIO
from json import load as jsonload
from dataclasses import dataclass
from yaml import load as yamlload
from typing import TypeAlias, Union
from lumina_wrapper import ExcelColumnDefinition, ExcelColumnDataType
from structs_schema import (
    DefinedStruct,
    DefinedStructEnum,
    DefinedStructFixedField,
    DefinedStructField,
    DefinedStructExport,
    Fields,
)

try:
    from yaml import CSafeLoader as Loader
except ImportError:
    from yaml import SafeLoader as Loader

exd_namespace = "Component::Exd::Sheets"

ExdSchemaYaml: TypeAlias = list[dict[str, Union[str, int, "ExdSchemaYaml"]]]


@dataclass
class Definition:
    name: str
    comment: str | None

    def size(self) -> int:
        return 1


@dataclass
class RepeatDefinition(Definition):
    count: int
    fields: "DefinitionFields"

    def size(self) -> int:
        return len(self.fields) * self.count


DefinitionFields: TypeAlias = list[Union[Definition, RepeatDefinition]]


def get_exdschema_versions():
    with urlopen("https://api.github.com/repos/xivdev/exdschema/branches") as response:
        vers: list[str] = []
        for branch in jsonload(response):
            vers.append(branch["name"])
        return vers


def process_exdschema_definition(fields: ExdSchemaYaml):
    definitions: DefinitionFields = []
    for field in fields:
        if "type" in field and field["type"] == "array":
            definitions.append(
                RepeatDefinition(
                    field["name"] if "name" in field else "",
                    field["comment"] if "comment" in field else None,
                    field["count"],
                    (
                        process_exdschema_definition(field["fields"])
                        if "fields" in field
                        else []
                    ),
                )
            )
        elif "name" in field:
            definitions.append(
                Definition(
                    field["name"], field["comment"] if "comment" in field else None
                )
            )
    return definitions


def get_exdschema_data(version: str):
    with urlopen(
        f"https://github.com/xivdev/EXDSchema/archive/refs/heads/{version}.zip"
    ) as response:
        with ZipFile(BytesIO(response.read())) as z:
            exd_schema_map: dict[str, DefinitionFields] = {}
            for file in z.namelist():
                if file.endswith(".yml") and ".github" not in file:
                    yaml_data = yamlload(z.read(file), Loader)
                    exd_schema_map[file.rsplit(".", 1)[0].rsplit("/")[1]] = (
                        process_exdschema_definition(yaml_data["fields"])
                    )
            return exd_schema_map


def get_size_from_string(type: str) -> int:
    if type == "size8_st" or type == "size8_t":
        return 1
    if type == "size16_st" or type == "size16_t":
        return 2
    if type == "size32_st" or type == "size32_t" or type == "float":
        return 4
    if type == "size64_st" or type == "size64_t" or type == "double":
        return 8
    return 0


def find_struct(structs: list[DefinedStruct], name: str):
    for struct in structs:
        if struct.name == name:
            return struct
    return None


def create_struct_from_header_and_schema(
    header: list[ExcelColumnDefinition],
    schema: DefinitionFields,
    header_index_offset: int = 0,
    schema_name: str = "",
):
    fields: Fields = []
    enums: list[DefinedStructEnum] = []
    enum_field_map: dict[int, int] = {}
    structs: list[DefinedStruct] = []
    for index in range(len(schema)):
        header_index = sum(f.size() for f in schema[:index]) + header_index_offset
        definition = header[header_index]
        field = schema[index]

        if isinstance(field, RepeatDefinition):
            exported = create_struct_from_header_and_schema(
                header, field.fields, header_index, field.name
            )
            if len(exported.structs) == 0:
                base_type = definition.get_base_type_string()
                fields.append(
                    DefinedStructFixedField(
                        field.name,
                        base_type,
                        definition.offset,
                        False,
                        field.count,
                        False,
                    )
                )
                pass
            else:
                fields.append(
                    DefinedStructFixedField(
                        field.name,
                        exported.structs[-1].name,
                        definition.offset,
                        False,
                        field.count,
                        False,
                    )
                )
                structs.extend(exported.structs)
                enums.extend(exported.enums)
                pass
        else:
            if definition.is_packed_bool():
                if definition.offset in enum_field_map:
                    enums[enum_field_map[definition.offset]].values[field.name] = (
                        definition.type - ExcelColumnDataType.PackedBool0
                    )
                    pass
                else:
                    enum_index = len(enums)
                    enum_field_map[definition.offset] = enum_index
                    enum_type = f"{schema_name}PackedBool{definition.offset:X}"
                    enum_name = f"{exd_namespace}::{enum_type}"
                    enums.append(
                        DefinedStructEnum(
                            enum_name,
                            enum_type,
                            exd_namespace,
                            definition.get_base_type_string(),
                            True,
                            {
                                field.name: definition.type
                                - ExcelColumnDataType.PackedBool0
                            },
                        )
                    )
                    fields.append(
                        DefinedStructField(
                            f"PackedBool{definition.offset:X}",
                            enum_name,
                            definition.offset,
                            False,
                        )
                    )
                pass
            else:
                fields.append(
                    DefinedStructField(
                        field.name,
                        definition.get_base_type_string(),
                        definition.offset,
                        False,
                    )
                )
                pass

    size: int = 0
    for field in fields:
        if isinstance(field, DefinedStructFixedField):
            struct = find_struct(structs, field.type)
            if struct == None:
                field_size = get_size_from_string(field.type)
                if field_size == 0:
                    field_size = 1
                size += field_size
            else:
                size += struct.size * field.size
        else:
            field_size = get_size_from_string(field.type)
            if field_size == 0:
                field_size = 1
            size += field_size

    size = (size + 3) & ~3

    if len(fields) != 0:
        structs.append(
            DefinedStruct(
                f"{exd_namespace}::{schema_name}",
                schema_name,
                exd_namespace,
                fields,
                size,
                None,
                None,
                [],
                False,
                None,
                None,
                [],
            )
        )

    return DefinedStructExport(enums, structs)

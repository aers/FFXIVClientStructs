from dataclasses import dataclass
from typing import TypeAlias, Union
from yaml import load

try:
    from yaml import CSafeLoader as Loader
except ImportError:
    from yaml import SafeLoader as Loader

YamlStructValuesExport: TypeAlias = list[dict[str, Union[str, int, "YamlStructValuesExport"]]]
YamlStructExport: TypeAlias = dict[str, YamlStructValuesExport]
YamlExport: TypeAlias = dict[str, list[YamlStructExport]]

@dataclass
class DefinedStructBase:
    name: str
    type: str
    namespace: str


@dataclass
class DefinedStructEnum(DefinedStructBase):
    underlying: str
    flags: bool
    values: dict[str, int]


@dataclass
class DefinedStructFuncParam:
    name: str
    type: str


@dataclass
class DefinedStructVFunc:
    name: str
    return_type: str | None
    offset: int
    parameters: list[DefinedStructFuncParam] | None


@dataclass
class DefinedStructMemFunc:
    signature: str
    return_type: str
    parameters: list[DefinedStructFuncParam]
    name: str


@dataclass
class DefinedStructField(DefinedStructFuncParam):
    offset: int
    base: bool


@dataclass
class DefinedStructFuncField(DefinedStructField):
    return_type: str | None
    parameters: list[DefinedStructFuncParam] | None


@dataclass
class DefinedStructStaticMember:
    signature: str
    relative_offsets: list[int]
    return_type: str
    is_pointer: bool


@dataclass
class DefinedStructFixedField(DefinedStructField):
    size: int
    is_string: bool

Fields: TypeAlias = list[DefinedStructField | DefinedStructFixedField]

@dataclass
class DefinedStruct(DefinedStructBase):
    fields: Fields
    size: int
    vtable_size: int | None
    virtual_functions: list[DefinedStructVFunc] | None
    member_functions: list[DefinedStructMemFunc]
    union: bool
    static_member_functions: list[DefinedStructMemFunc] | None
    static_members: list[DefinedStructStaticMember] | None
    template_types: list[str]


@dataclass
class DefinedStructExport:
    enums: list[DefinedStructEnum]
    structs: list[DefinedStruct]


def get_yaml(stream, loader = Loader) -> DefinedStructExport:
    dic: YamlExport = load(
        stream, loader
    )
    enums = []
    structs = []
    for enum in dic["enums"]:
        enums.append(
            DefinedStructEnum(
                enum["name"],
                enum["type"],
                enum["namespace"],
                enum["underlying"],
                enum["flags"],
                enum["values"],
            )
        )
    for struct in dic["structs"]:
        fields = []
        virtual_functions = None
        member_functions = []
        static_member_functions = None
        static_members = None
        for field in struct["fields"]:
            base = field["base"] if "base" in field else False
            if "size" in field:
                fields.append(
                    DefinedStructFixedField(
                        field["name"],
                        field["type"],
                        field["offset"],
                        base,
                        field["size"],
                        field["is_string"]
                    )
                )
            elif "return_type" in field:
                parameters = []
                for param in field["parameters"]:
                    parameters.append(
                        DefinedStructFuncParam(param["name"], param["type"])
                    )
                fields.append(
                    DefinedStructFuncField(
                        field["name"],
                        field["type"],
                        field["offset"],
                        base,
                        field["return_type"],
                        parameters,
                    )
                )
            else:
                fields.append(
                    DefinedStructField(
                        field["name"], field["type"], field["offset"], base
                    )
                )
        if "virtual_functions" in struct:
            virtual_functions = []
            for vfunc in struct["virtual_functions"]:
                parameters = (
                    [
                        DefinedStructFuncParam(param["name"], param["type"])
                        for param in vfunc["parameters"]
                    ]
                    if "parameters" in vfunc
                    else None
                )
                virtual_functions.append(
                    DefinedStructVFunc(
                        vfunc["name"],
                        vfunc["return_type"] if "return_type" in vfunc else None,
                        vfunc["offset"],
                        parameters,
                    )
                )
        for memfunc in struct["member_functions"]:
            parameters = []
            for param in memfunc["parameters"]:
                parameters.append(DefinedStructFuncParam(param["name"], param["type"]))
            member_functions.append(
                DefinedStructMemFunc(
                    memfunc["signature"],
                    memfunc["return_type"],
                    parameters,
                    memfunc["name"],
                )
            )
        if "static_member_functions" in struct:
            static_member_functions = []
            for smemfunc in struct["static_member_functions"]:
                parameters = []
                for param in smemfunc["parameters"]:
                    parameters.append(
                        DefinedStructFuncParam(param["name"], param["type"])
                    )
                static_member_functions.append(
                    DefinedStructMemFunc(
                        smemfunc["signature"],
                        smemfunc["return_type"],
                        parameters,
                        smemfunc["name"],
                    )
                )
        if "static_members" in struct:
            static_members = []
            for sm in struct["static_members"]:
                static_members.append(
                    DefinedStructStaticMember(
                        sm["signature"],
                        sm["relative_follow_offsets"],
                        sm["return_type"],
                        sm["is_pointer"] if "is_pointer" in sm else False,
                    )
                )
        size = None
        if "size" in struct:
            size = struct["size"]
        vtable_size = None
        if "vtable_size" in struct:
            vtable_size = struct["vtable_size"]
        structs.append(
            DefinedStruct(
                struct["name"],
                struct["type"],
                struct["namespace"],
                fields,
                size,
                vtable_size,
                virtual_functions,
                member_functions,
                struct["union"],
                static_member_functions,
                static_members,
                []
            )
        )
    return DefinedStructExport(enums, structs)
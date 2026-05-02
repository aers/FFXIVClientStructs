from dataclasses import dataclass


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

@dataclass
class DefinedStruct(DefinedStructBase):
    fields: list[DefinedStructField]
    size: int | None
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

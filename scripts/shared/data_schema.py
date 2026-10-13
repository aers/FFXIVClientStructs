from dataclasses import dataclass, field, fields
from typing import TypeAlias
from yaml import load

try:
    from yaml import CSafeLoader as Loader
except ImportError:
    from yaml import SafeLoader as Loader


@dataclass
class DefinedDataClassInstance:
    ea: int
    pointer: bool = False
    name: str | None = None


@dataclass
class DefinedDataClassVtable:
    ea: int
    base: str | None = None
    size: int | None = None


@dataclass
class DefinedDataClassFunction:
    num: int
    name: str


@dataclass
class DefinedDataClass:
    instances: list[DefinedDataClassInstance] = field(default_factory=list)
    vtbls: list[DefinedDataClassVtable] = field(default_factory=list)
    functions: list[DefinedDataClassFunction] = field(
        default_factory=list, metadata={"yaml_name": "funcs"}
    )
    vfuncs: list[DefinedDataClassFunction] = field(default_factory=list)


@dataclass
class DefinedData:
    classes: dict[str, DefinedDataClass] = field(default_factory=dict)
    version: str | None = None
    globals: dict[int, str] = field(default_factory=dict)
    functions: dict[int, str] = field(default_factory=dict)


YamlExport: TypeAlias = dict[str, object]


def get_yaml(stream, loader=Loader) -> DefinedData:
    dic: YamlExport = load(stream, loader)
    classes = {}
    class_keys = {f.metadata.get("yaml_name", f.name) for f in fields(DefinedDataClass)}
    for name, class_values in (dic.get("classes") or {}).items():
        class_values = class_values or {}
        values = dict(class_values)

        for leftover in class_values.keys() - class_keys:
            print('Warning: Extra key "{0}" present in {1}'.format(leftover, name))

        for key, value_type in (
            ("instances", DefinedDataClassInstance),
            ("vtbls", DefinedDataClassVtable),
        ):
            if key in class_values and class_values[key] is not None:
                values[key] = [
                    _from_dict(value_type, value) for value in class_values[key]
                ]
            else:
                values.pop(key, None)

        for yaml_key in ("funcs", "vfuncs"):
            if yaml_key in class_values and class_values[yaml_key] is not None:
                values[yaml_key] = [
                    DefinedDataClassFunction(num, function_name)
                    for num, function_name in class_values[yaml_key].items()
                ]
            else:
                values.pop(yaml_key, None)

        classes[name] = _from_dict(DefinedDataClass, values)

    return _from_dict(DefinedData, {**dic, "classes": classes})


def _from_dict(data_class, values):
    class_values = {}
    for data_field in fields(data_class):
        key = data_field.metadata.get("yaml_name", data_field.name)
        if key in values:
            class_values[data_field.name] = values[key]
    return data_class(**class_values)

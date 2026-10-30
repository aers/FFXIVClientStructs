import os
import re
from dataclasses import replace

# the crash recovery of libclang takes the SIGSEGV the JVM raises on purpose and kills Ghidra, read when the index is created
os.environ.setdefault("LIBCLANG_DISABLE_CRASH_RECOVERY", "1")

from clang.cindex import Config, Cursor, CursorKind, Index, Type, TypeKind
from src_wrapper import layout_probe_prefix
from structs_schema import (
    DefinedStruct,
    DefinedStructEnum,
    DefinedStructExport,
    DefinedStructField,
    DefinedStructFixedField,
    DefinedStructFuncField,
    DefinedStructFuncParam,
)

main_file = "ffxiv_structs.hpp"
# an instantiation can use templates that are only pointed to themselves
max_instantiation_passes = 8

# named like structs.yml does, sized for x86_64-pc-windows-msvc
primitive_types = {
    TypeKind.VOID: "void",
    TypeKind.BOOL: "bool",
    TypeKind.CHAR_S: "char",
    TypeKind.CHAR_U: "byte",
    TypeKind.SCHAR: "__int8",
    TypeKind.UCHAR: "byte",
    TypeKind.WCHAR: "wchar_t",
    TypeKind.CHAR16: "unsigned __int16",
    TypeKind.CHAR32: "unsigned int",
    TypeKind.SHORT: "__int16",
    TypeKind.USHORT: "unsigned __int16",
    TypeKind.INT: "int",
    TypeKind.UINT: "unsigned int",
    TypeKind.LONG: "int",
    TypeKind.ULONG: "unsigned int",
    TypeKind.LONGLONG: "__int64",
    TypeKind.ULONGLONG: "unsigned __int64",
    TypeKind.FLOAT: "float",
    TypeKind.DOUBLE: "double",
    TypeKind.LONGDOUBLE: "double",
    TypeKind.NULLPTR: "void*",
}

record_kinds = (CursorKind.STRUCT_DECL, CursorKind.CLASS_DECL, CursorKind.UNION_DECL)
pointer_kinds = (TypeKind.POINTER, TypeKind.LVALUEREFERENCE, TypeKind.RVALUEREFERENCE)
function_kinds = (TypeKind.FUNCTIONPROTO, TypeKind.FUNCTIONNOPROTO)


def split_type_path(name: str) -> list[str]:
    """Split a type on its namespaces, not the ones in template arguments."""
    parts, depth, start, index = [], 0, 0, 0
    while index < len(name):
        if name[index] == "<":
            depth += 1
        elif name[index] == ">":
            depth -= 1
        elif depth == 0 and name[index : index + 2] == "::":
            parts.append(name[start:index])
            start = index + 2
            index += 1
        index += 1
    parts.append(name[start:])
    return parts


class RecordCollector(object):
    """Turns the records clang laid out into the same structs structs.yml is read as."""

    def __init__(self):
        self.enums: dict[str, DefinedStructEnum] = {}
        # in dependency order, a struct comes after everything it holds by value
        self.structs: dict[str, DefinedStruct] = {}
        # only ever pointed to, so they are imported without their members
        self.opaque: dict[str, bool] = {}
        # typedef name to the type behind it, see get_template_alias in structs_schema
        self.aliases: dict[str, str] = {}
        # template instances that are only pointed to, clang did not lay those out
        self.incomplete: set[str] = set()
        # records that are pointed to, laid out once the struct pointing to them is done to keep the dependency order
        self._deferred: list[tuple[Type, Cursor, str]] = []

    def collect(self, cursor: Cursor):
        """Everything declared in the string and what it needs from the headers."""
        self._collect_declarations(cursor)
        while self._deferred:
            type, decl, name = self._deferred.pop()
            if name not in self.structs:
                self.add_record(type, decl, name)

    def _collect_declarations(self, cursor: Cursor):
        for child in cursor.get_children():
            if child.location.file is None or child.location.file.name != main_file:
                continue
            if child.kind in (CursorKind.NAMESPACE, CursorKind.LINKAGE_SPEC):
                self._collect_declarations(child)
            elif child.kind in record_kinds and child.is_definition():
                if "(" not in child.type.spelling:
                    self.get_type_string(child.type, True, True)
                    self._collect_declarations(child)
            elif child.kind == CursorKind.ENUM_DECL and child.is_definition():
                self.get_enum(child)
            elif child.kind == CursorKind.TYPEDEF_DECL and child.spelling.startswith("__cs_"):
                type_string = self.get_type_string(child.underlying_typedef_type, True, False)
                if type_string is not None:
                    self.aliases[child.spelling] = type_string

    def get_export(self) -> DefinedStructExport:
        self.wrap_primary_bases()
        opaque = [
            self.new_struct(name, [], None, union)
            for name, union in self.opaque.items()
            if name not in self.structs
        ]
        return DefinedStructExport(list(self.enums.values()), [*opaque, *self.structs.values()])

    def get_primary_base(self, struct: DefinedStruct) -> DefinedStruct | None:
        """The base at offset 0, it shares its vtable pointer with the struct inheriting it."""
        if struct.union:
            return None
        base_field = next((field for field in struct.fields if field.base and field.offset == 0), None)
        if base_field is None:
            return None
        base = self.structs.get(base_field.type)
        return None if base is None or base.union else base

    def has_vtable_pointer(self, struct: DefinedStruct) -> bool:
        """The struct or a base at offset 0 starts with __vtable."""
        if any(field.offset == 0 and field.name == "__vtable" for field in struct.fields):
            return True
        base = self.get_primary_base(struct)
        return base is not None and self.has_vtable_pointer(base)

    def wrap_primary_bases(self):
        """Ghidra can not retype the vtable pointer inside an embedded base, so a struct with a vtable of its own
        holds its offset 0 base in a union with __vtable pointing to its own VTable, the base keeps its layout."""
        wrappers: dict[str, DefinedStruct] = {}
        for name, struct in self.structs.items():
            vtable_name = f"{name}::VTable"
            base = self.get_primary_base(struct)
            if vtable_name not in self.structs or base is None or not self.has_vtable_pointer(base):
                continue
            base_field = next(field for field in struct.fields if field.base and field.offset == 0)
            # ghidra settles a tie between union members on the first, so a vtable call goes through __vtable
            wrapper = self.new_struct(
                f"{name}::__primary_base",
                [
                    DefinedStructField("__vtable", f"{vtable_name}*", 0, False, [], []),
                    replace(base_field, name=re.sub(r"\W", "_", split_type_path(base.type)[-1]), base=False),
                ],
                base.size,
                True,
            )
            wrappers[name] = wrapper

        # replaced after the loop, so every base is looked at as clang laid it out
        # every union comes right before the struct holding it, after the base and vtable it is made of
        structs: dict[str, DefinedStruct] = {}
        for name, struct in self.structs.items():
            if name in wrappers:
                wrapper = wrappers[name]
                structs[wrapper.type] = wrapper
                struct = replace(struct, fields=[
                    replace(field, type=wrapper.type) if field.base and field.offset == 0 else field
                    for field in struct.fields
                ])
            structs[name] = struct
        self.structs = structs

    def new_struct(self, type_name: str, fields: list, size: int | None, union: bool) -> DefinedStruct:
        parts = split_type_path(type_name)
        return DefinedStruct(
            parts[-1], type_name, ".".join(parts[:-1]), fields, size,
            None, [], [], union, None, None, [], [], [], False,
        )

    def get_decl_name(self, decl: Cursor) -> str:
        name = re.sub(r"\s+([*&])", r"\1", decl.type.spelling)
        if "(" in name:
            # ex. Foo::(unnamed union at file:9:175)
            name = f"{name[:name.index('(')]}anon_{decl.location.line}_{decl.location.column}"
        return name

    def get_type_string(self, type: Type, follow: bool, by_value: bool) -> str | None:
        """The type as structs.yml spells it, None if it can not be described."""
        type = type.get_canonical()
        if type.kind in primitive_types:
            return primitive_types[type.kind]

        if type.kind in pointer_kinds:
            pointee = type.get_pointee().get_canonical()
            if pointee.kind in function_kinds:
                return "__fastcall"
            return (self.get_type_string(pointee, follow, False) or "void") + "*"

        if type.kind in (TypeKind.CONSTANTARRAY, TypeKind.INCOMPLETEARRAY) and not by_value:
            # a pointer to an array points at its first element
            return self.get_type_string(type.element_type, follow, False)

        if type.kind == TypeKind.ENUM:
            return self.get_enum(type.get_declaration())

        if type.kind == TypeKind.RECORD:
            return self.get_record(type, follow, by_value)

        return None

    def get_enum(self, decl: Cursor) -> str:
        decl = decl.get_definition() or decl
        name = self.get_decl_name(decl)
        if name not in self.enums:
            short_name = split_type_path(name)[-1]
            values = {
                child.spelling.removeprefix(f"{short_name}_"): child.enum_value
                for child in decl.get_children()
                if child.kind == CursorKind.ENUM_CONSTANT_DECL
            }
            underlying = primitive_types.get(decl.enum_type.get_canonical().kind, "int")
            self.enums[name] = DefinedStructEnum(
                short_name, name, ".".join(split_type_path(name)[:-1]), underlying, False, values
            )
        return name

    def get_record(self, type: Type, follow: bool, by_value: bool) -> str:
        decl = type.get_declaration()
        decl = decl.get_definition() or decl
        name = self.get_decl_name(decl)
        if name in self.structs:
            return name

        if type.get_size() >= 0 and by_value:
            self.add_record(type, decl, name)
        elif type.get_size() >= 0 and follow:
            self._deferred.append((type, decl, name))
        else:
            if follow and "<" in name:
                self.incomplete.add(name)
            self.opaque[name] = decl.kind == CursorKind.UNION_DECL
        return name

    def add_record(self, type: Type, decl: Cursor, name: str):
        # what a header of the compiler or windows points to is not followed, that would pull in most of it
        follow = decl.location.file is not None and decl.location.file.name == main_file
        fields = []

        # clang does not report where a base is, they are laid out in order before the fields
        offset = 0
        for child in decl.get_children():
            if child.kind != CursorKind.CXX_BASE_SPECIFIER:
                continue
            base = child.type.get_canonical()
            if base.get_size() < 0 or self.is_empty(base):
                continue
            offset = -(-offset // base.get_align()) * base.get_align()
            fields.append(
                DefinedStructField(f"baseclass_{offset:X}", self.get_type_string(base, follow, True), offset, True, [], [])
            )
            offset += base.get_size()

        union = decl.kind == CursorKind.UNION_DECL
        # libclang validates the whole record for every offset asked for, so it is only asked where alignment moved a field
        max_field_align = type.get_align()
        end = offset
        ask_clang = False
        for index, field in enumerate(type.get_fields()):
            if field.is_bitfield():
                ask_clang = True
                continue
            field_type = field.type.get_canonical()
            field_size, field_align = field_type.get_size(), field_type.get_align()
            if union:
                field_offset = 0
            elif ask_clang or index == 0 or field_size < 0 or field_align <= 0:
                bit_offset = field.get_field_offsetof()
                if bit_offset < 0 or bit_offset % 8 != 0:
                    continue
                field_offset = bit_offset // 8
            else:
                field_align = min(field_align, max_field_align)
                field_offset = -(-end // field_align) * field_align
                if field_offset != end:
                    bit_offset = field.get_field_offsetof()
                    if bit_offset != field_offset * 8:
                        ask_clang = True
                        if bit_offset < 0 or bit_offset % 8 != 0:
                            continue
                        field_offset = bit_offset // 8
            end = field_offset + max(field_size, 0)
            defined_field = self.get_field(field, field_offset, follow)
            if defined_field is not None:
                fields.append(defined_field)

        self.structs[name] = self.new_struct(name, fields, type.get_size(), union)

    def is_empty(self, type: Type) -> bool:
        """An empty base takes up no room in the struct inheriting it."""
        if next(iter(type.get_fields()), None) is not None:
            return False
        return all(
            self.is_empty(child.type.get_canonical())
            for child in type.get_declaration().get_children()
            if child.kind == CursorKind.CXX_BASE_SPECIFIER
        )

    def get_field(self, field: Cursor, offset: int, follow: bool):
        name = field.spelling or f"anon_{offset:X}"
        type = field.type.get_canonical()
        count = None
        while type.kind == TypeKind.CONSTANTARRAY:
            # ghidra gets the flattened array, ex. int[2][3] as int[6]
            count = (count or 1) * type.element_count
            type = type.element_type.get_canonical()
        if count == 0 or type.kind == TypeKind.INCOMPLETEARRAY:
            return None

        if count is None and type.kind == TypeKind.POINTER and type.get_pointee().get_canonical().kind == TypeKind.FUNCTIONPROTO:
            function = type.get_pointee().get_canonical()
            names = [child.spelling for child in field.get_children() if child.kind == CursorKind.PARM_DECL]
            parameters = [
                DefinedStructFuncParam(
                    names[index] if index < len(names) and names[index] else f"a{index + 1}",
                    self.get_type_string(argument, follow, False) or "__int64",
                )
                for index, argument in enumerate(function.argument_types())
            ]
            return_type = self.get_type_string(function.get_result(), follow, False) or "__int64"
            return DefinedStructFuncField(name, "__fastcall", offset, False, [], [], return_type, parameters)

        type_string = self.get_type_string(type, follow, True)
        if type_string is None:
            # ex. a member pointer, keep its room in the struct
            type_string, count = "byte", field.type.get_size()
            if count <= 0:
                return None

        if count is not None:
            return DefinedStructFixedField(name, type_string, offset, False, [], [], count, False)
        return DefinedStructField(name, type_string, offset, False, [], [])


class ClangInterface(object):
    def __init__(self, args: list[str], library_file: str | None = None):
        """Uses the libclang of the python package unless library_file is given."""
        if library_file is not None and not Config.loaded:
            Config.set_library_file(library_file)
        self.args = args

    def parse_string(self, decl: str) -> tuple[DefinedStructExport, dict[str, str], int]:
        """The layout of every struct, the template typedefs and the error count."""
        index = Index.create()
        forced: list[str] = []
        for _ in range(max_instantiation_passes):
            # sizeof needs the complete type, that makes clang instantiate the templates only used behind a pointer
            source = decl + "".join(
                f"\nstatic const auto __cs_instantiate_{number} = sizeof(::{name});"
                for number, name in enumerate(forced)
            )
            unit = index.parse(main_file, args=self.args, unsaved_files=[(main_file, source)])
            collector = RecordCollector()
            collector.collect(unit.cursor)
            missing = sorted(collector.incomplete.difference(forced))
            if not missing:
                break
            forced.extend(missing)

        errors = [diagnostic for diagnostic in unit.diagnostics if diagnostic.severity >= 3]
        for diagnostic in errors[:50]:
            location = diagnostic.location
            print(f"Error: clang: {location.file}:{location.line}:{location.column}: {diagnostic.spelling}")
        if len(errors) > 50:
            print(f"Error: clang: {len(errors) - 50} more error(s) not shown")

        return collector.get_export(), collector.aliases, len(errors)

    def parse_layout_probe(self, source: str) -> dict[str, tuple[int, int]]:
        """Size and offset of value in each probe struct of SrcInterface.get_layout_probe."""
        unit = Index.create().parse(main_file, args=self.args, unsaved_files=[(main_file, source)])
        layouts: dict[str, tuple[int, int]] = {}
        for child in unit.cursor.get_children():
            if child.kind != CursorKind.STRUCT_DECL or not child.spelling.startswith(layout_probe_prefix):
                continue
            for field in child.type.get_fields():
                size, bit_offset = field.type.get_size(), field.get_field_offsetof()
                if field.spelling == "value" and size > 0 and bit_offset >= 0:
                    layouts[child.spelling] = (size, bit_offset // 8)
        return layouts

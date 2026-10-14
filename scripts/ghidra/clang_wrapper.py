import os
import re

# the crash recovery of libclang takes the SIGSEGV the JVM raises on purpose and kills Ghidra, read when the index is created
os.environ.setdefault("LIBCLANG_DISABLE_CRASH_RECOVERY", "1")

from clang.cindex import Config, Cursor, CursorKind, Index, Type, TypeKind
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

# named like ffxiv_structs.yml does, sized for x86_64-pc-windows-msvc
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
    """Split a type on its namespaces, the ones inside template arguments are left alone."""
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
    """Turns the records clang laid out into the same structs ffxiv_structs.yml is read as."""

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
        """Everything declared in the parsed string, and whatever that needs from the headers it includes."""
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
        opaque = [
            self.new_struct(name, [], None, union)
            for name, union in self.opaque.items()
            if name not in self.structs
        ]
        return DefinedStructExport(list(self.enums.values()), [*opaque, *self.structs.values()])

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
        """
        :param follow: Lay out the records this type points to, they are only declared by name otherwise
        :param by_value: The type is held and not pointed to, so its layout is needed
        :return: None if the type can not be described
        """
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
                DefinedStructField(f"baseclass_{offset:X}", self.get_type_string(base, follow, True), offset, True, [])
            )
            offset += base.get_size()

        for field in type.get_fields():
            bit_offset = field.get_field_offsetof()
            if field.is_bitfield() or bit_offset < 0 or bit_offset % 8 != 0:
                continue
            defined_field = self.get_field(field, bit_offset // 8, follow)
            if defined_field is not None:
                fields.append(defined_field)

        self.structs[name] = self.new_struct(name, fields, type.get_size(), decl.kind == CursorKind.UNION_DECL)

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
            return DefinedStructFuncField(name, "__fastcall", offset, False, [], return_type, parameters)

        type_string = self.get_type_string(type, follow, True)
        if type_string is None:
            # ex. a member pointer, keep its room in the struct
            type_string, count = "byte", field.type.get_size()
            if count <= 0:
                return None

        if count is not None:
            return DefinedStructFixedField(name, type_string, offset, False, [], count, False)
        return DefinedStructField(name, type_string, offset, False, [])


class ClangInterface(object):
    def __init__(self, args: list[str], library_file: str | None = None):
        """
        :param args: Arguments for clang, the same ones the compiler would get
        :param library_file: Path of the libclang to use, the one of the python package if omitted
        """
        if library_file is not None and not Config.loaded:
            Config.set_library_file(library_file)
        self.args = args

    def parse_string(self, decl: str) -> tuple[DefinedStructExport, dict[str, str], int]:
        """
        Let clang work out the layout of every struct, template instances included.
        :return: The structs and enums, the typedefs for templated types, the number of parser errors
        """
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

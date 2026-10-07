from structs_schema import (
    DefinedStruct,
    DefinedStructFixedField,
    DefinedStructField,
    DefinedStructExport,
    DefinedStructEnum,
    DefinedStructVFunc,
)
from indent_writer import IndentWriter

class SrcInterface(object):
    full_padding: bool = True

    def get_type_and_type_size_from_gap(self, gap: int, offset: int = 0) -> tuple[str, int]:
        if offset == 0:
            offset = gap
        if offset % 8 == 0 and gap >= 8:
            return ("uint64_t", 8)
        elif offset % 4 == 0 and gap >= 4:
            return ("uint32_t", 4)
        elif offset % 2 == 0 and gap >= 2:
            return ("uint16_t", 2)
        else:
            return ("uint8_t", 1)

    def get_size_from_string(self, type: str) -> int:
        """
        Gets the int of a base type string.
        """
        if type in ("int8_t", "uint8_t", "bool", "char", "unsigned char", "signed char"):
            return 1
        if type in ("int16_t", "uint16_t", "wchar_t"):
            return 2
        if type in ("int32_t", "uint32_t", "float"):
            return 4
        if (
            type == "int64_t"
            or type == "uint64_t"
            or type == "double"
            or type.endswith("*")
        ):
            return 8
        return 0

    def _split_template_type(self, type_name: str) -> tuple[str, list[str]]:
        """Split a type's base name and top-level template arguments."""
        type_name = type_name.strip()
        template_start = type_name.find("<")
        if template_start < 0:
            return type_name, []

        depth = 0
        argument_start = template_start + 1
        arguments: list[str] = []
        for index in range(template_start, len(type_name)):
            char = type_name[index]
            if char == "<":
                depth += 1
            elif char == ">":
                depth -= 1
                if depth == 0:
                    if argument_start < index:
                        arguments.append(type_name[argument_start:index].strip())
                    if type_name[index + 1 :].strip():
                        return type_name, []
                    return type_name[:template_start].strip(), arguments
            elif char == "," and depth == 1:
                arguments.append(type_name[argument_start:index].strip())
                argument_start = index + 1

        return type_name, []

    def _normalize_type(self, type_name: str) -> str:
        """Normalize whitespace without losing nested template structure."""
        type_name = type_name.strip()
        pointer_suffix = ""
        while type_name.endswith("*"):
            pointer_suffix += "*"
            type_name = type_name[:-1].strip()

        base_type, template_args = self._split_template_type(type_name)
        if template_args:
            normalized = f"{base_type}<{','.join(self._normalize_type(arg) for arg in template_args)}>"
        else:
            normalized = " ".join(base_type.split())
        return normalized + pointer_suffix

    def _get_field_type(
        self,
        field: DefinedStructField | DefinedStructFixedField,
        template_struct_lookup: dict[str, DefinedStruct],
    ) -> str:
        field_type = field.type.strip()
        pointer_suffix = ""
        while field_type.endswith("*"):
            pointer_suffix += "*"
            field_type = field_type[:-1].strip()

        if (
            field.template_args
            and not self._split_template_type(field_type)[1]
            and self._normalize_type(field_type) in template_struct_lookup
        ):
            field_type += f"<{', '.join(field.template_args)}>"
        return field_type + pointer_suffix

    def _substitute_template_types(
        self, type_name: str, substitutions: dict[str, str]
    ) -> str:
        type_name = type_name.strip()
        pointer_suffix = ""
        while type_name.endswith("*"):
            pointer_suffix += "*"
            type_name = type_name[:-1].strip()

        base_type, template_args = self._split_template_type(type_name)
        if template_args:
            substituted = (
                f"{base_type}<"
                f"{', '.join(self._substitute_template_types(arg, substitutions) for arg in template_args)}>"
            )
        else:
            substituted = substitutions.get(base_type, base_type)
        return substituted + pointer_suffix

    def get_size_from_type(
        self,
        type_name: str,
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
        template_struct_lookup: dict[str, DefinedStruct] | None = None,
        template_parameters: tuple[str, ...] = (),
    ) -> int:
        """Resolve a field's size using schema types and the target x64 ABI."""
        type_name = type_name.strip()
        if type_name.endswith("*"):
            return 8
        if type_name in template_parameters:
            return 0

        normalized_type = self._normalize_type(type_name)
        if normalized_type in struct_lookup:
            return struct_lookup[normalized_type]
        if normalized_type in enum_lookup:
            return enum_lookup[normalized_type]

        primitive_size = self.get_size_from_string(type_name)
        if primitive_size:
            return primitive_size

        base_type, template_args = self._split_template_type(type_name)
        if not template_args:
            return 0

        stl_type_sizes = {
            "std::vector": 24,
            "std::set": 16,
            "std::map": 16,
            "std::string": 32,
            "std::wstring": 32,
            "std::basic_string": 32,
            "std::list": 16,
            "std::deque": 32,
            "std::linkedlist": 24,
        }
        if base_type in stl_type_sizes:
            return stl_type_sizes[base_type]

        if base_type == "std::pair":
            if len(template_args) != 2:
                raise ValueError(f"std::pair requires two type arguments: {type_name}")
            first_size = self.get_size_from_type(
                template_args[0], struct_lookup, enum_lookup, template_struct_lookup
            )
            second_size = self.get_size_from_type(
                template_args[1], struct_lookup, enum_lookup, template_struct_lookup
            )
            first_alignment = self._get_type_alignment(
                template_args[0], struct_lookup, enum_lookup, template_struct_lookup
            )
            second_alignment = self._get_type_alignment(
                template_args[1], struct_lookup, enum_lookup, template_struct_lookup
            )
            alignment = max(first_alignment, second_alignment)
            second_offset = self._align_size(first_size, second_alignment)
            return self._align_size(second_offset + second_size, alignment)

        template_struct_lookup = template_struct_lookup or {}
        template_struct = template_struct_lookup.get(self._normalize_type(base_type))
        if template_struct is not None:
            return self._get_template_struct_size(
                template_struct,
                template_args,
                struct_lookup,
                enum_lookup,
                template_struct_lookup,
            )

        raise ValueError(f"Cannot determine size for template type: {type_name}")

    def _get_type_alignment(
        self,
        type_name: str,
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
        template_struct_lookup: dict[str, DefinedStruct] | None = None,
    ) -> int:
        type_name = type_name.strip()
        if type_name.endswith("*"):
            return 8

        normalized_type = self._normalize_type(type_name)
        if normalized_type in struct_lookup:
            size = struct_lookup[normalized_type]
        elif normalized_type in enum_lookup:
            size = enum_lookup[normalized_type]
        else:
            size = self.get_size_from_string(type_name)
            if size == 0:
                base_type, template_args = self._split_template_type(type_name)
                if base_type in ("std::vector", "std::set", "std::map", "std::string", "std::wstring", "std::basic_string", "std::list", "std::deque", "std::linkedlist"):
                    return 8
                if base_type == "std::pair":
                    if len(template_args) != 2:
                        raise ValueError(f"std::pair requires two type arguments: {type_name}")
                    return max(
                        self._get_type_alignment(
                            arg, struct_lookup, enum_lookup, template_struct_lookup
                        )
                        for arg in template_args
                    )
                size = self.get_size_from_type(
                    type_name,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                )
        return min(size & -size, 8) if size else 1

    @staticmethod
    def _align_size(size: int, alignment: int) -> int:
        return (size + alignment - 1) // alignment * alignment

    def _get_template_struct_size(
        self,
        struct: DefinedStruct,
        template_args: list[str],
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
        template_struct_lookup: dict[str, DefinedStruct],
    ) -> int:
        if len(template_args) != len(struct.template_types):
            raise ValueError(
                f"Template type {struct.type} expects {len(struct.template_types)} "
                f"arguments, got {len(template_args)}"
            )
        if struct.size is not None:
            return struct.size

        substitutions = dict(zip(struct.template_types, template_args))
        extent = 0
        for field in struct.fields:
            if field.type == "__fastcall":
                field_size = 8
            else:
                field_type = self._get_field_type(field, template_struct_lookup)
                field_type = self._substitute_template_types(field_type, substitutions)
                field_size = self.get_size_from_type(
                    field_type,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                )
                if field_size == 0:
                    raise ValueError(
                        f"Cannot determine size of {field_type} in template type {struct.type}"
                    )
                if isinstance(field, DefinedStructFixedField):
                    field_size *= field.size

            field_end = field.offset + field_size
            if struct.union:
                extent = max(extent, field_size)
            else:
                extent = max(extent, field_end)
        return extent
    
    def get_string_define_and_size(
        self,
        field: DefinedStructField | DefinedStructFixedField,
        namespace: str,
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
        template_struct_lookup: dict[str, DefinedStruct] | None = None,
        template_parameters: tuple[str, ...] = (),
    ) -> tuple[str, int]:
        template_struct_lookup = template_struct_lookup or {}
        field_type = self._get_field_type(field, template_struct_lookup)
        field_name = field.name
        field_size = self.get_size_from_type(
            field_type,
            struct_lookup,
            enum_lookup,
            template_struct_lookup,
            template_parameters,
        )
        display_type = field_type
        if display_type.startswith(namespace):
            display_type = display_type.removeprefix(f"{namespace}::")
        return (f"{display_type} {field_name};", field_size)

    def get_short_name(self, full_type: str) -> str:
        """Extract the short name from a fully qualified type name."""
        depth = 0
        last_namespace_separator = -1
        index = 0
        while index < len(full_type) - 1:
            if full_type[index] == "<":
                depth += 1
            elif full_type[index] == ">":
                depth -= 1
            elif full_type[index : index + 2] == "::" and depth == 0:
                last_namespace_separator = index + 1
                index += 1
            index += 1
        return full_type[last_namespace_separator + 1 :]

    def build_vfunc_signature(self, vfunc: DefinedStructVFunc) -> str:
        """Build a function pointer signature for a virtual function.
        
        Args:
            vfunc: Virtual function definition
            
        Returns:
            Function pointer signature string
        """
        if not (vfunc.return_type and vfunc.parameters):
            return f"void* {vfunc.name};"

        return_type = vfunc.return_type if vfunc.return_type else "void"
        
        # Build parameter list
        param_list = ""
        if vfunc.parameters:
            params = [f"{param.type} {param.name}" for param in vfunc.parameters]
            param_list = ", ".join(params)
        
        return f"{return_type} (__fastcall *{vfunc.name})({param_list});"
    
    def build_export_string(
        self,
        export: DefinedStructExport,
        full_declspec_align: int = 0
    ):
        output = IndentWriter()

        struct_lookup = {
            self._normalize_type(struct.type): struct.size
            for struct in export.structs
            if struct.size is not None
        }
        enum_lookup = {
            self._normalize_type(enum.type): self.get_size_from_string(enum.underlying)
            for enum in export.enums
        }
        template_struct_lookup = {
            self._normalize_type(struct.type): struct
            for struct in export.structs
            if struct.template_types
        }

        def append_chunk(chunk: IndentWriter | str):
            chunk_text = str(chunk)
            for line in chunk_text.split("\n"):
                if not line.strip():
                    continue
                # preserve the chunk's indentation by measuring leading spaces
                leading = len(line) - len(line.lstrip(" "))
                chunk_indent = leading // 2
                prev_indent = output.indent_level
                output.indent_level = prev_indent + chunk_indent
                output.append(line.lstrip(" "))
                output.indent_level = prev_indent

        def append_ordered_chunks(chunks: list[tuple[str, IndentWriter]]):
            open_namespaces: list[str] = []
            for namespace, chunk in chunks:
                target_namespaces = namespace.split("::") if namespace else []
                shared_count = 0
                while (
                    shared_count < len(open_namespaces)
                    and shared_count < len(target_namespaces)
                    and open_namespaces[shared_count] == target_namespaces[shared_count]
                ):
                    shared_count += 1

                while len(open_namespaces) > shared_count:
                    output.unindent()
                    output.append("}")
                    open_namespaces.pop()

                for namespace_name in target_namespaces[shared_count:]:
                    output.append(f"namespace {namespace_name} {{")
                    output.indent()
                    open_namespaces.append(namespace_name)

                append_chunk(chunk)

            while open_namespaces:
                output.unindent()
                output.append("}")
                open_namespaces.pop()

        enum_chunks = [
            (enum.namespace, self.build_enum_string(enum)) for enum in export.enums
        ]
        append_ordered_chunks(enum_chunks)

        forward_chunks: list[tuple[str, IndentWriter]] = []
        definition_chunks: list[tuple[str, IndentWriter]] = []
        vtable_names: list[str] = []
        for struct in export.structs:
            forward, define, vtable, vtable_full_name = self.build_struct_string(
                struct, struct_lookup, enum_lookup, template_struct_lookup, full_declspec_align
            )
            if vtable_full_name:
                vtable_names.append(vtable_full_name)
            forward_chunks.append((struct.namespace, forward))
            definition_chunks.append((struct.namespace, define))
            definition_chunks.append((struct.namespace, vtable))

        append_ordered_chunks(forward_chunks)
        append_ordered_chunks(definition_chunks)

        return (str(output), vtable_names)

    def build_enum_string(
        self,
        enum: DefinedStructEnum,
    ):
        output = IndentWriter()

        enum_name = self.get_short_name(enum.type)
        output += f"enum {enum_name} : {enum.underlying} {{"
        output.indent()

        for value_name, value in enum.values.items():
            output += f"{enum_name}_{value_name} = {value},"

        output.unindent()
        output += "};"

        return output
    
    def get_struct_pad(self, fill_size: int, prev_size: int):
        if self.full_padding:
            type, size = self.get_type_and_type_size_from_gap(prev_size)
            if size > fill_size:
                type, size  = self.get_type_and_type_size_from_gap(fill_size, prev_size)

            return (f"{type} field_{prev_size:X};", size)
        else:
            return (f"char field_{prev_size:X}[{fill_size}];", fill_size)

    def build_struct_string(
        self,
        struct: DefinedStruct,
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
        template_struct_lookup: dict[str, DefinedStruct] | None = None,
        declspec_align: int = 0
    ) -> tuple[IndentWriter, IndentWriter, IndentWriter, str | None]:
        """Builds the C++ struct definition with namespace wrapping.

        Args:
            struct (DefinedStruct): The struct data to build
            
        Returns:
            tuple: (forward_declarations, struct_definition, vtable_definition, vtable_full_name or None)
        """
        struct_string_forward: IndentWriter = IndentWriter()
        struct_string_define: IndentWriter = IndentWriter()
        struct_string_vtable: IndentWriter = IndentWriter()
        template_struct_lookup = template_struct_lookup or {}
        template_declaration = ""
        template_suffix = ""
        if struct.template_types:
            template_declaration = (
                f"template<typename {', typename '.join(struct.template_types)}>"
            )
            template_suffix = f"<{', '.join(struct.template_types)}>"
        
        short_name = self.get_short_name(struct.type)
        vtable_full_name: str | None = None

        if declspec_align > 0:
            declspec = f"__declspec(align({declspec_align})) "
        else:
            declspec = ""

        # Forward declarations
        if template_declaration:
            struct_string_forward += template_declaration
        struct_string_forward += f"struct {short_name};"
        if struct.virtual_functions:
            if template_declaration:
                struct_string_forward += template_declaration
            struct_string_forward += f"struct {short_name}_vtbl;"

        # Struct definition
        if template_declaration:
            struct_string_define += template_declaration
        struct_define_line = f"struct {declspec}{short_name}"
        struct_extend_lines = []

        base_fields = [field for field in struct.fields if field.base]
        base_fields_used = []
        prev_size = 0
        for base_field in base_fields:
            if base_field.offset == prev_size:
                base_fields_used.append(base_field.type)
                field_type = self._get_field_type(base_field, template_struct_lookup)
                short_base_name = self.get_short_name(field_type)
                struct_extend_lines.append(short_base_name)
                prev_size += self.get_size_from_type(
                    field_type,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    tuple(struct.template_types),
                )
        
        struct_extend_line = ""
        if len(struct_extend_lines) > 0:
            struct_extend_line = " : " + ", ".join(struct_extend_lines)

        struct_string_define += f"{struct_define_line}{struct_extend_line} {{"
        struct_string_define.indent()

        # Add __vtable member if this struct has virtual functions
        if struct.virtual_functions and prev_size == 0:
            struct_string_define += f"{short_name}_vtbl{template_suffix}* __vtable;"
            prev_size = 8

        offset = 0

        for field in struct.fields:
            if field.type in base_fields_used:
                continue

            offset = field.offset

            while offset > prev_size:
                fill_size = offset - prev_size
                line, size = self.get_struct_pad(fill_size, prev_size)
                struct_string_define += line
                prev_size += size

            field_name = field.name
            field_type = field.type
            if isinstance(field, DefinedStructFixedField):
                field_define, field_define_size = self.get_string_define_and_size(
                    field,
                    struct.namespace,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    tuple(struct.template_types),
                )
                struct_string_define += f"{field_define[:-1]}[{field.size}];"
                prev_size += field_define_size * field.size
            elif field_type == "__fastcall":
                fastcall_field_define = ""
                fastcall_field_define += (
                    f"{field.return_type} ({field_type} *{field_name})("
                )
                for param in field.parameters:
                    fastcall_field_define += param.type + " " + param.name + ", "
                struct_string_define += fastcall_field_define[:-1] + ");"
                prev_size += 8
            else:
                field_define, field_define_size = self.get_string_define_and_size(
                    field,
                    struct.namespace,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    tuple(struct.template_types),
                )
                struct_string_define += field_define
                prev_size += field_define_size

        if struct.size is not None and struct.size != 0:
            while struct.size > prev_size:
                fill_size = struct.size - prev_size
                line, size = self.get_struct_pad(fill_size, prev_size)
                struct_string_define += line
                prev_size += size
        
        struct_string_define.unindent()
        struct_string_define += "};"

        # Virtual table struct definition
        if struct.virtual_functions:
            if template_declaration:
                struct_string_vtable += template_declaration
            struct_string_vtable += f"struct __cppobj {short_name}_vtbl {{"
            struct_string_vtable.indent()
            previous_offset = 0
            for vfunc in struct.virtual_functions:
                while previous_offset < vfunc.offset:
                    struct_string_vtable += f"void* vf{int(previous_offset/8)};"
                    previous_offset += 8

                struct_string_vtable += self.build_vfunc_signature(vfunc)
                previous_offset = vfunc.offset + 8
            struct_string_vtable.unindent()
            struct_string_vtable += "};"
            vtable_full_name = f"{struct.type}_vtbl"

        return (struct_string_forward, struct_string_define, struct_string_vtable, vtable_full_name)
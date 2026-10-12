from structs_schema import (
    DefinedStruct,
    DefinedStructFixedField,
    DefinedStructField,
    DefinedStructExport,
    DefinedStructEnum,
    DefinedStructVFunc,
    get_template_alias,
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

    def is_base_type(self, type: str) -> bool:
        type = type.rstrip('*')
        return type in ("byte", "wchar_t", "char", "float", "double", "bool", "int8_t", "uint8_t", "int16_t", "uint16_t", "int32_t", "uint32_t", "int64_t", "uint64_t", "void")

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

    def _qualify_template_arguments(
        self, type_name: str, template_parameters: tuple[str, ...] = ()
    ) -> str:
        """Make non-primitive template arguments independent of the current namespace."""
        type_name = type_name.strip()
        pointer_suffix = ""
        while type_name.endswith("*"):
            pointer_suffix += "*"
            type_name = type_name[:-1].strip()

        base_type, template_args = self._split_template_type(type_name)
        if not template_args:
            return type_name + pointer_suffix

        qualified_args = []
        for argument in template_args:
            argument = self._qualify_template_arguments(argument, template_parameters)
            argument_base = argument
            while argument_base.endswith("*"):
                argument_base = argument_base[:-1].strip()
            if (
                argument_base not in template_parameters
                and not self.is_base_type(argument_base)
                and not argument_base.startswith("::")
            ):
                argument = f"::{argument}"
            qualified_args.append(argument)
        return f"{base_type}<{', '.join(qualified_args)}>{pointer_suffix}"

    def _get_struct_size(
        self,
        type_name: str,
        struct_lookup: dict[str, int],
    ) -> int | None:
        normalized_type = self._normalize_type(type_name)
        if normalized_type in struct_lookup:
            return struct_lookup[normalized_type]

        return struct_lookup.get(self.get_short_name(normalized_type))

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
            template_args = [f"::{template_arg}" if not self.is_base_type(template_arg) else template_arg for template_arg in field.template_args]
            field_type += f"<{', '.join(template_args)}>"
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
        struct_definition_lookup: dict[str, DefinedStruct] | None = None,
    ) -> int:
        """Resolve a field's size using schema types and the target x64 ABI."""
        type_name = type_name.strip()
        if type_name.endswith("*"):
            return 8
        if type_name in template_parameters:
            return 0

        normalized_type = self._normalize_type(type_name)
        struct_size = self._get_struct_size(normalized_type, struct_lookup)
        if struct_size is not None:
            return struct_size
        if normalized_type in enum_lookup:
            return enum_lookup[normalized_type]

        primitive_size = self.get_size_from_string(type_name)
        if primitive_size:
            return primitive_size

        base_type, template_args = self._split_template_type(type_name)
        if not template_args:
            struct_definition_lookup = struct_definition_lookup or {}
            struct_definition = struct_definition_lookup.get(normalized_type)
            if struct_definition is not None and not struct_definition.template_types:
                return self._get_template_struct_size(
                    struct_definition,
                    [],
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup or {},
                    struct_definition_lookup,
                )
            return 0

        stl_type_sizes = {
            "std::vector": 24,
            "std::set": 16,
            "std::map": 16,
            "std::unordered_map": 64,
            "std::string": 32,
            "std::wstring": 32,
            "std::basic_string": 32,
            "std::list": 16,
            "std::deque": 40,
        }
        if base_type in stl_type_sizes:
            return stl_type_sizes[base_type]

        if base_type == "std::pair":
            if len(template_args) != 2:
                raise ValueError(f"std::pair requires two type arguments: {type_name}")
            first_size = self.get_size_from_type(
                template_args[0],
                struct_lookup,
                enum_lookup,
                template_struct_lookup,
                struct_definition_lookup=struct_definition_lookup,
            )
            second_size = self.get_size_from_type(
                template_args[1],
                struct_lookup,
                enum_lookup,
                template_struct_lookup,
                struct_definition_lookup=struct_definition_lookup,
            )
            first_alignment = self._get_type_alignment(
                template_args[0],
                struct_lookup,
                enum_lookup,
                template_struct_lookup,
                struct_definition_lookup,
            )
            second_alignment = self._get_type_alignment(
                template_args[1],
                struct_lookup,
                enum_lookup,
                template_struct_lookup,
                struct_definition_lookup,
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
                struct_definition_lookup,
            )

        raise ValueError(f"Cannot determine size for template type: {type_name}")

    def _get_type_alignment(
        self,
        type_name: str,
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
        template_struct_lookup: dict[str, DefinedStruct] | None = None,
        struct_definition_lookup: dict[str, DefinedStruct] | None = None,
    ) -> int:
        type_name = type_name.strip()
        if type_name.endswith("*"):
            return 8

        normalized_type = self._normalize_type(type_name)
        struct_size = self._get_struct_size(normalized_type, struct_lookup)
        if struct_size is not None:
            size = struct_size
        elif normalized_type in enum_lookup:
            size = enum_lookup[normalized_type]
        else:
            size = self.get_size_from_string(type_name)
            if size == 0:
                base_type, template_args = self._split_template_type(type_name)
                if base_type in ("std::vector", "std::set", "std::map", "std::unordered_map", "std::string", "std::wstring", "std::basic_string", "std::list", "std::deque", "std::linkedlist"):
                    return 8
                if base_type == "std::pair":
                    if len(template_args) != 2:
                        raise ValueError(f"std::pair requires two type arguments: {type_name}")
                    return max(
                        self._get_type_alignment(
                            arg,
                            struct_lookup,
                            enum_lookup,
                            template_struct_lookup,
                            struct_definition_lookup,
                        )
                        for arg in template_args
                    )
                size = self.get_size_from_type(
                    type_name,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    struct_definition_lookup=struct_definition_lookup,
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
        struct_definition_lookup: dict[str, DefinedStruct] | None = None,
    ) -> int:
        if len(template_args) != len(struct.template_types):
            raise ValueError(
                f"Template type {struct.type} expects {len(struct.template_types)} "
                f"arguments, got {len(template_args)}"
            )
        if struct.size is not None:
            return struct.size

        substitutions = dict(zip(struct.template_types, template_args))
        has_base_at_zero = any(
            field.base and field.offset == 0 for field in struct.fields
        )
        has_implicit_vtable = bool(struct.virtual_functions) and not has_base_at_zero
        extent = 8 if has_implicit_vtable else 1
        alignment = 8 if has_implicit_vtable else 1
        for field in struct.fields:
            if field.type == "__fastcall":
                field_size = 8
                field_alignment = 8
            else:
                field_type = self._get_field_type(field, template_struct_lookup)
                field_type = self._substitute_template_types(field_type, substitutions)
                field_size = self.get_size_from_type(
                    field_type,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    struct_definition_lookup=struct_definition_lookup,
                )
                if field_size == 0:
                    raise ValueError(
                        f"Cannot determine size of {field_type} in template type {struct.type}"
                    )
                field_alignment = self._get_type_alignment(
                    field_type,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    struct_definition_lookup,
                )
                if isinstance(field, DefinedStructFixedField):
                    field_size *= field.size

            alignment = max(alignment, field_alignment)
            field_end = field.offset + field_size
            if struct.union:
                extent = max(extent, field_size)
            else:
                extent = max(extent, field_end)
        return self._align_size(extent, alignment)
    
    def get_string_define_and_size(
        self,
        field: DefinedStructField | DefinedStructFixedField,
        namespace: str,
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
        template_struct_lookup: dict[str, DefinedStruct] | None = None,
        template_parameters: list[str] = [],
        struct_definition_lookup: dict[str, DefinedStruct] | None = None,
        field_name_override: str | None = None,
        opaque_pointer_types: set[str] | None = None,
    ) -> tuple[str, int]:
        template_struct_lookup = template_struct_lookup or {}
        field_type = self._get_field_type(field, template_struct_lookup)
        opaque_pointer_types = opaque_pointer_types or set()
        pointer_count = 0
        pointer_base = field_type
        while pointer_base.endswith("*"):
            pointer_base = pointer_base[:-1].strip()
            pointer_count += 1
        if pointer_count and self._normalize_type(pointer_base) in opaque_pointer_types:
            field_type = "void" + "*" * pointer_count
        field_name = field_name_override or field.name
        field_size = self.get_size_from_type(
            field_type,
            struct_lookup,
            enum_lookup,
            template_struct_lookup,
            template_parameters,
            struct_definition_lookup,
        )
        display_type = self._qualify_template_arguments(
            field_type, tuple(template_parameters)
        )
        if display_type.startswith(namespace):
            display_type = display_type.removeprefix(f"{namespace}::")
        elif not self.is_base_type(display_type) and not display_type.rstrip('*') in template_parameters:
            display_type = f"::{display_type}"
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

    def build_vfunc_signature(
        self, vfunc: DefinedStructVFunc, name_override: str | None = None
    ) -> str:
        """Build a function pointer signature for a virtual function.
        
        Args:
            vfunc: Virtual function definition
            
        Returns:
            Function pointer signature string
        """
        function_name = name_override or vfunc.name
        if not (vfunc.return_type and vfunc.parameters):
            return f"void* {function_name};"

        return_type = vfunc.return_type if vfunc.return_type else "void"

        if not self.is_base_type(return_type):
            return_type = f"::{return_type}"
        
        # Build parameter list
        param_list = ""
        if vfunc.parameters:
            params = []
            for param in vfunc.parameters:
                if param.type == "__fastcall":
                    # function pointer parameters are exported without their signature
                    params.append(f"void* {param.name}")
                elif not self.is_base_type(param.type):
                    params.append(f"::{param.type} {param.name}")
                else:
                    params.append(f"{param.type} {param.name}")
                    
            param_list = ", ".join(params)
        
        return f"{return_type} (__fastcall *{function_name})({param_list});"
    
    def build_export_string(
        self,
        export: DefinedStructExport,
        full_declspec_align: int = 0
    ):
        output = IndentWriter()

        all_structs: list[DefinedStruct] = []
        inline_structs: list[DefinedStruct] = []
        inline_enums: list[DefinedStructEnum] = []
        inline_type_owners: dict[str, str] = {}

        def collect_inline_types(struct: DefinedStruct):
            for inline_enum in struct.inline_enums:
                inline_enums.append(inline_enum)
            for inline_struct in struct.inline_structs:
                inline_structs.append(inline_struct)
                all_structs.append(inline_struct)
                collect_inline_types(inline_struct)

        for struct in export.structs:
            all_structs.append(struct)
            collect_inline_types(struct)

        inline_struct_types = {
            self._normalize_type(struct.type) for struct in inline_structs
        }

        def collect_inline_type_owners(struct: DefinedStruct, owner_type: str):
            for inline_struct in struct.inline_structs:
                inline_type_owners.setdefault(
                    self._normalize_type(inline_struct.type),
                    self._normalize_type(owner_type),
                )
                collect_inline_type_owners(inline_struct, owner_type)

        for struct in export.structs:
            if self._normalize_type(struct.type) not in inline_struct_types:
                collect_inline_type_owners(struct, struct.type)

        inline_enum_types = {
            self._normalize_type(enum.type) for enum in inline_enums
        }

        struct_lookup: dict[str, int] = {}
        for struct in all_structs:
            if struct.size is None:
                continue
            normalized_type = self._normalize_type(struct.type)
            struct_lookup[normalized_type] = struct.size
            struct_lookup.setdefault(self.get_short_name(normalized_type), struct.size)
        enum_lookup: dict[str, int] = {}
        for enum in [*export.enums, *inline_enums]:
            enum_lookup[self._normalize_type(enum.type)] = self.get_size_from_string(
                enum.underlying
            )
        template_struct_lookup: dict[str, DefinedStruct] = {}
        struct_definition_lookup: dict[str, DefinedStruct] = {}
        for struct in all_structs:
            normalized_type = self._normalize_type(struct.type)
            struct_definition_lookup[normalized_type] = struct
            if struct.template_types:
                template_struct_lookup[normalized_type] = struct

        top_level_structs = [
            struct
            for struct in export.structs
            if self._normalize_type(struct.type) not in inline_struct_types
        ]
        top_level_types = {
            self._normalize_type(struct.type) for struct in top_level_structs
        }
        struct_dependencies = {type_name: set() for type_name in top_level_types}

        def references_inline_type(reference: str, inline_type: str) -> bool:
            start = reference.find(inline_type)
            while start >= 0:
                end = start + len(inline_type)
                before_is_identifier = start > 0 and (
                    reference[start - 1].isalnum() or reference[start - 1] == "_"
                )
                after_is_identifier = end < len(reference) and (
                    reference[end].isalnum() or reference[end] == "_"
                )
                if not before_is_identifier and not after_is_identifier:
                    return True
                start = reference.find(inline_type, start + 1)
            return False

        def iter_struct_tree(struct: DefinedStruct):
            yield struct
            for inline_struct in struct.inline_structs:
                yield from iter_struct_tree(inline_struct)

        for struct in top_level_structs:
            struct_type = self._normalize_type(struct.type)
            references = []
            for nested_struct in iter_struct_tree(struct):
                for field in nested_struct.fields:
                    references.append(field.type)
                    references.extend(field.template_args or [])
                    field_type = self._normalize_type(field.type)
                    if (
                        field_type in struct_dependencies
                        and field_type != struct_type
                        and not field_type.endswith("*")
                    ):
                        struct_dependencies[struct_type].add(field_type)
                    if field.base:
                        if field_type in struct_dependencies and field_type != struct_type:
                            struct_dependencies[struct_type].add(field_type)
                    if hasattr(field, "return_type"):
                        references.append(field.return_type or "")
                    if getattr(field, "parameters", None):
                        references.extend(
                            parameter.type for parameter in field.parameters
                        )
                for virtual_function in nested_struct.virtual_functions or []:
                    references.append(virtual_function.return_type or "")
                    references.extend(
                        parameter.type
                        for parameter in virtual_function.parameters or []
                    )

            for inline_type, owner_type in inline_type_owners.items():
                if owner_type == struct_type or owner_type not in top_level_types:
                    continue
                if any(
                    references_inline_type(
                        self._normalize_type(reference), inline_type
                    )
                    for reference in references
                ):
                    struct_dependencies[struct_type].add(owner_type)

        ordered_structs = []
        remaining_structs = list(top_level_structs)
        emitted_types = set()
        while remaining_structs:
            ready_index = next(
                (
                    index
                    for index, struct in enumerate(remaining_structs)
                    if struct_dependencies[self._normalize_type(struct.type)]
                    <= emitted_types
                ),
                None,
            )
            if ready_index is None:
                ready_index = 0
            struct = remaining_structs.pop(ready_index)
            ordered_structs.append(struct)
            emitted_types.add(self._normalize_type(struct.type))

        ordered_type_indices = {
            self._normalize_type(struct.type): index
            for index, struct in enumerate(ordered_structs)
        }
        opaque_pointer_types_by_struct: dict[str, set[str]] = {}
        for struct in ordered_structs:
            struct_type = self._normalize_type(struct.type)
            opaque_pointer_types = set()
            for nested_struct in iter_struct_tree(struct):
                for field in nested_struct.fields:
                    field_type = self._normalize_type(field.type)
                    pointer_base = field_type
                    has_pointer = pointer_base.endswith("*")
                    while pointer_base.endswith("*"):
                        pointer_base = pointer_base[:-1].strip()
                    if not has_pointer:
                        continue
                    owner_type = inline_type_owners.get(pointer_base)
                    if (
                        owner_type is not None
                        and owner_type != struct_type
                        and owner_type in ordered_type_indices
                        and ordered_type_indices[owner_type]
                        > ordered_type_indices[struct_type]
                    ):
                        opaque_pointer_types.add(pointer_base)
            if opaque_pointer_types:
                opaque_pointer_types_by_struct[struct_type] = opaque_pointer_types

        # Windows headers define macros such as DrawState (-> DrawStateA) that
        # would silently rename the types and members sharing their name
        identifiers: set[str] = set()
        for enum in [*export.enums, *inline_enums]:
            identifiers.add(self.get_short_name(enum.name))
        for struct in all_structs:
            identifiers.add(self.get_short_name(struct.type))
            identifiers.update(field.name for field in struct.fields)
            identifiers.update(
                virtual_function.name
                for virtual_function in struct.virtual_functions or []
            )
        for identifier in sorted(identifiers):
            if identifier.isidentifier():
                output.append(f"#undef {identifier}")

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
                    formatted_name = namespace_name.replace(".", "::")
                    output.append(f"namespace {formatted_name} {{")
                    output.indent()
                    open_namespaces.append(namespace_name)

                append_chunk(chunk)

            while open_namespaces:
                output.unindent()
                output.append("}")
                open_namespaces.pop()

        enum_chunks = []
        forward_chunks: list[tuple[str, IndentWriter]] = []

        for enum in export.enums:
            if self._normalize_type(enum.type) in inline_enum_types:
                continue
            enum_forward = IndentWriter()
            enum_forward += f"enum {enum.name} : {enum.underlying};"
            forward_chunks.append((enum.namespace, enum_forward))
            enum_chunks.append((enum.namespace, self.build_enum_string(enum)))

        definition_chunks: list[tuple[str, IndentWriter]] = []
        inline_enum_definition_chunks: list[tuple[str, IndentWriter]] = []
        vtable_names: list[str] = []
        seen_vtable_names: set[str] = set()

        def collect_inline_enum_definitions(struct: DefinedStruct):
            namespace_prefix = struct.namespace.replace(".", "::")
            owner_type = struct.type
            if namespace_prefix and owner_type.startswith(f"{namespace_prefix}::"):
                owner_type = owner_type[len(namespace_prefix) + 2 :]
            if struct.template_types:
                owner_type += f"<{', '.join(struct.template_types)}>"

            for inline_enum in struct.inline_enums:
                inline_enum_definition = self.build_enum_string(
                    inline_enum, owner_type, tuple(struct.template_types)
                )
                inline_enum_definition_chunks.append(
                    (inline_enum.namespace, inline_enum_definition)
                )
            for inline_struct in struct.inline_structs:
                collect_inline_enum_definitions(inline_struct)

        def collect_vtable_names(struct: DefinedStruct):
            # a template vtable only exists in IDA as its instantiations
            if struct.virtual_functions and not struct.template_types:
                vtable_name = f"{struct.type}_vtbl"
                if vtable_name not in seen_vtable_names:
                    seen_vtable_names.add(vtable_name)
                    vtable_names.append(vtable_name)
            for inline_struct in struct.inline_structs:
                collect_vtable_names(inline_struct)

        for struct in ordered_structs:
            forward, define, vtable, vtable_full_name = self.build_struct_string(
                struct,
                struct_lookup,
                enum_lookup,
                template_struct_lookup,
                full_declspec_align,
                struct_definition_lookup,
                opaque_pointer_types_by_struct.get(
                    self._normalize_type(struct.type), set()
                ),
            )
            collect_vtable_names(struct)
            collect_inline_enum_definitions(struct)
            forward_chunks.append((struct.namespace, forward))
            definition_chunks.append((struct.namespace, define))
            definition_chunks.append((struct.namespace, vtable))

        def forward_chunk_key(key: tuple[str, IndentWriter]) -> str:
            (namespace, _) = key
            return namespace

        forward_chunks = sorted(forward_chunks, key=forward_chunk_key)

        append_ordered_chunks(forward_chunks)
        append_ordered_chunks(enum_chunks)
        append_ordered_chunks(definition_chunks)
        append_ordered_chunks(inline_enum_definition_chunks)

        for alias, type_name in self._collect_template_aliases(export.structs).items():
            output.append(f"typedef ::{type_name} {alias};")

        return (str(output), vtable_names)

    def _collect_template_aliases(self, structs: list[DefinedStruct]) -> dict[str, str]:
        """Collect the templated types used by function signatures.

        Returns:
            dict: typedef name (see get_template_alias) to the type it aliases
        """
        aliases: dict[str, str] = {}

        def collect(type_name: str | None):
            type_name = (type_name or "").strip().rstrip("*").strip()
            if "<" in type_name:
                aliases.setdefault(get_template_alias(type_name), type_name)

        def collect_struct(struct: DefinedStruct):
            # signatures of a template struct use its template parameters
            if struct.template_types:
                return
            functions = [
                *(struct.virtual_functions or []),
                *(struct.member_functions or []),
                *(struct.static_member_functions or []),
            ]
            for function in functions:
                collect(function.return_type)
                for parameter in function.parameters or []:
                    collect(parameter.type)
            for static_member in struct.static_members or []:
                collect(static_member.return_type)
            for inline_struct in struct.inline_structs:
                collect_struct(inline_struct)

        for struct in structs:
            collect_struct(struct)
        return aliases

    def build_enum_string(
        self,
        enum: DefinedStructEnum,
        enum_scope: str | None = None,
        template_types: tuple[str, ...] = (),
    ):
        output = IndentWriter()

        enum_name = enum.name
        if template_types:
            output += f"template<typename {', typename '.join(template_types)}>"
        enum_type = f"{enum_scope}::{enum_name}" if enum_scope != None else enum_name
        output += f"enum {enum_type} : {enum.underlying} {{"
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
        declspec_align: int = 0,
        struct_definition_lookup: dict[str, DefinedStruct] | None = None,
        opaque_pointer_types: set[str] | None = None,
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
        opaque_pointer_types = opaque_pointer_types or set()
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
        struct_string_forward += f"struct {struct.name};"
        
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
                struct_extend_lines.append(f"::{field_type}" if not self.is_base_type(field_type) else field_type)
                prev_size += self.get_size_from_type(
                    field_type,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    tuple(struct.template_types),
                    struct_definition_lookup,
                )
        
        struct_extend_line = ""
        if len(struct_extend_lines) > 0:
            struct_extend_line = " : " + ", ".join(struct_extend_lines)

        struct_string_define += f"{struct_define_line}{struct_extend_line} {{"
        struct_string_define.indent()

        for inline_enum in struct.inline_enums:
            struct_string_define += f"enum {self.get_short_name(inline_enum.name)} : {inline_enum.underlying};"

        def append_chunk(chunk: IndentWriter | str):
            for line in str(chunk).split("\n"):
                if not line.strip():
                    continue
                leading = len(line) - len(line.lstrip(" "))
                previous_indent = struct_string_define.indent_level
                struct_string_define.indent_level = previous_indent + leading // 2
                struct_string_define.append(line.lstrip(" "))
                struct_string_define.indent_level = previous_indent

        inline_struct_chunks = [
            self.build_struct_string(
                inline_struct,
                struct_lookup,
                enum_lookup,
                template_struct_lookup,
                declspec_align,
                struct_definition_lookup,
                opaque_pointer_types,
            )
            for inline_struct in struct.inline_structs
        ]

        for inline_forward, _, _, _ in inline_struct_chunks:
            append_chunk(inline_forward)
        for _, inline_define, inline_vtable, _ in inline_struct_chunks:
            append_chunk(inline_define)
            append_chunk(inline_vtable)

        # Add __vtable member if this struct has virtual functions
        if struct.virtual_functions and prev_size == 0:
            struct_string_define += f"{short_name}_vtbl{template_suffix}* __vtable;"
            prev_size = 8

        field_name_counts: dict[str, int] = {}
        field_name_last_indices: dict[str, int] = {}
        for field_index, field in enumerate(struct.fields):
            field_name_counts[field.name] = field_name_counts.get(field.name, 0) + 1
            field_name_last_indices[field.name] = field_index
        reserved_field_names = set(field_name_counts)
        emitted_field_names = set()
        field_names = []
        for field_index, field in enumerate(struct.fields):
            field_name = field.name
            if (
                field_name_counts[field.name] > 1
                and field_name_last_indices[field.name] != field_index
            ):
                field_name = f"{field.name}_{field.offset:X}"
                while field_name in reserved_field_names or field_name in emitted_field_names:
                    field_name += "_"
            field_names.append(field_name)
            emitted_field_names.add(field_name)

        offset = 0

        for field_index, field in enumerate(struct.fields):
            if field.type in base_fields_used:
                continue

            offset = field.offset

            if not struct.is_sequential:
                while offset > prev_size:
                    fill_size = offset - prev_size
                    line, size = self.get_struct_pad(fill_size, prev_size)
                    struct_string_define += line
                    prev_size += size

            field_name = field_names[field_index]
            field_type = field.type
            if isinstance(field, DefinedStructFixedField):
                field_define, field_define_size = self.get_string_define_and_size(
                    field,
                    struct.namespace,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    struct.template_types,
                    struct_definition_lookup,
                    field_name,
                    opaque_pointer_types,
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
                if len(field.parameters) > 0:
                    fastcall_field_define = fastcall_field_define[:-2]
                struct_string_define += fastcall_field_define + ");"
                prev_size += 8
            else:
                field_define, field_define_size = self.get_string_define_and_size(
                    field,
                    struct.namespace,
                    struct_lookup,
                    enum_lookup,
                    template_struct_lookup,
                    struct.template_types,
                    struct_definition_lookup,
                    field_name,
                    opaque_pointer_types,
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
            struct_string_vtable += f"struct {short_name}_vtbl {{"
            struct_string_vtable.indent()
            previous_offset = 0
            vfunc_name_counts: dict[str, int] = {}
            vfunc_preferred_indices: dict[str, int] = {}
            for vfunc_index, vfunc in enumerate(struct.virtual_functions):
                vfunc_name_counts[vfunc.name] = vfunc_name_counts.get(vfunc.name, 0) + 1
                preferred_index = vfunc_preferred_indices.get(vfunc.name)
                if preferred_index is None or (
                    vfunc.return_type
                    and vfunc.parameters
                    and not (
                        struct.virtual_functions[preferred_index].return_type
                        and struct.virtual_functions[preferred_index].parameters
                    )
                ):
                    vfunc_preferred_indices[vfunc.name] = vfunc_index

            emitted_vfunc_names = set()
            for vfunc_index, vfunc in enumerate(struct.virtual_functions):
                while previous_offset < vfunc.offset:
                    struct_string_vtable += f"void* vf{int(previous_offset/8)};"
                    previous_offset += 8

                vfunc_name = vfunc.name
                if (
                    vfunc_name_counts[vfunc.name] > 1
                    and vfunc_preferred_indices[vfunc.name] != vfunc_index
                ):
                    vfunc_name = f"vf{vfunc.offset // 8}"
                while vfunc_name in emitted_vfunc_names:
                    vfunc_name += "_"
                emitted_vfunc_names.add(vfunc_name)
                struct_string_vtable += self.build_vfunc_signature(
                    vfunc, vfunc_name
                )
                previous_offset = vfunc.offset + 8
            struct_string_vtable.unindent()
            struct_string_vtable += "};"
            vtable_full_name = f"{struct.type}_vtbl"

        return (struct_string_forward, struct_string_define, struct_string_vtable, vtable_full_name)
    
    def get_predef_header(self):
        return """#define _HAS_ITERATOR_DEBUGGING 0
#define _ITERATOR_DEBUG_LEVEL 0
#define _AMD64_
#undef __unaligned
#define __unaligned
#define __IZoneIdentifier2_FWD_DEFINED__
#include <cstdint>
#include <vector>
#include <set>
#include <map>
#include <unordered_map>
#include <string>
#include <list>
#include <deque>
#include <guiddef.h>
#include <xinput.h>
#include <d3d11_4.h>
#include <dinput.h>
#include <dxgidebug.h>
#include <dxgi1_6.h>
"""
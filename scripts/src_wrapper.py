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
        if type == "int8_t" or type == "uint8_t" or type == "bool":
            return 1
        if type == "int16_t" or type == "uint16_t":
            return 2
        if type == "int32_t" or type == "uint32_t" or type == "float":
            return 4
        if (
            type == "int64_t"
            or type == "uint64_t"
            or type == "double"
            or type.endswith("*")
        ):
            return 8
        return 0
    
    def get_string_define_and_size(self, field: DefinedStructField | DefinedStructFixedField, namespace: str, struct_lookup: dict[str, int], enum_lookup: dict[str, int]) -> tuple[str, int]:
        field_type = field.type
        if field_type.startswith(namespace):
            field_type = field_type.removeprefix(f"{namespace}::")
        field_name = field.name
        lookup_type = self.get_short_name(field.type)
        if lookup_type in struct_lookup:
            return (f"{field_type} {field_name};", struct_lookup[lookup_type])
        elif lookup_type in enum_lookup:
            return (f"{field_type} {field_name};", enum_lookup[lookup_type])
        else:
            return (f"{field_type} {field_name};", self.get_size_from_string(field_type))

    def get_short_name(self, full_type: str) -> str:
        """Extract the short name from a fully qualified type name."""
        return full_type.split("::")[-1]

    def build_vfunc_signature(self, vfunc: DefinedStructVFunc) -> str:
        """Build a function pointer signature for a virtual function.
        
        Args:
            vfunc: Virtual function definition
            
        Returns:
            Function pointer signature string
        """
        # Special case for Dtor
        if vfunc.name == "Dtor":
            # Find the struct name from context - this will be passed separately
            return "DTOR"
        
        return_type = vfunc.return_type if vfunc.return_type else "void"
        
        # Build parameter list
        param_list = ""
        if vfunc.parameters:
            params = [f"{param.type} {param.name}" for param in vfunc.parameters]
            param_list = ", ".join(params)
        
        return f"{return_type} (__fastcall *{vfunc.name})({param_list});"
    
    def build_export_string(
        self,
        export: DefinedStructExport
    ):
        output = IndentWriter()

        struct_lookup = {
            struct.type: struct.size for struct in export.structs if struct.size is not None
        }
        enum_lookup = {enum.type: self.get_size_from_string(enum.underlying) for enum in export.enums}

        namespace_enum_chunks: dict[str, list[IndentWriter]] = {}
        namespace_forward_chunks: dict[str, list[IndentWriter]] = {}
        namespace_define_chunks: dict[str, list[IndentWriter]] = {}
        namespace_order: list[str] = []

        def add_namespace(namespace: str):
            if namespace not in namespace_enum_chunks:
                namespace_enum_chunks[namespace] = []
                namespace_forward_chunks[namespace] = []
                namespace_define_chunks[namespace] = []
                namespace_order.append(namespace)

        for enum in export.enums:
            add_namespace(enum.namespace)
            namespace_enum_chunks[enum.namespace].append(self.build_enum_string(enum))

        vtable_names: list[str] = []

        for struct in export.structs:
            add_namespace(struct.namespace)
            forward, define, vtable, vtable_full_name = self.build_struct_string(
                struct, struct_lookup, enum_lookup
            )
            if vtable_full_name:
                vtable_names.append(vtable_full_name)
            namespace_forward_chunks[struct.namespace].append(forward)
            namespace_define_chunks[struct.namespace].append(define)
            namespace_define_chunks[struct.namespace].append(vtable)

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

        def append_namespace_content(namespace: str):
            ordered_chunks = [
                *namespace_enum_chunks[namespace],
                *namespace_forward_chunks[namespace],
                *namespace_define_chunks[namespace],
            ]
            for chunk in ordered_chunks:
                append_chunk(chunk)

        # Build an ordered namespace tree so parent namespaces are emitted only once.
        namespace_tree_children: dict[str, list[str]] = {"": []}
        for namespace in namespace_order:
            if namespace == "":
                continue

            parent_path = ""
            current_parts: list[str] = []
            for part in namespace.split("::"):
                current_parts.append(part)
                current_path = "::".join(current_parts)
                if parent_path not in namespace_tree_children:
                    namespace_tree_children[parent_path] = []
                if current_path not in namespace_tree_children[parent_path]:
                    namespace_tree_children[parent_path].append(current_path)
                if current_path not in namespace_tree_children:
                    namespace_tree_children[current_path] = []
                parent_path = current_path

        # Emit global namespace content first (if any), then recurse through namespace tree.
        if "" in namespace_enum_chunks:
            append_namespace_content("")

        def emit_namespace_subtree(parent_path: str):
            for child_path in namespace_tree_children.get(parent_path, []):
                child_name = child_path.split("::")[-1]
                output.append(f"namespace {child_name} {{")
                output.indent()

                if child_path in namespace_enum_chunks:
                    append_namespace_content(child_path)

                emit_namespace_subtree(child_path)

                output.unindent()
                output.append("}")

        emit_namespace_subtree("")

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
        
        short_name = self.get_short_name(struct.type)
        vtable_full_name: str | None = None

        # Forward declarations
        struct_string_forward += f"struct __cppobj {short_name};"
        if struct.virtual_functions:
            struct_string_forward += f"struct __cppobj {short_name}_vtbl;"

        # Struct definition
        struct_define_line = f"struct __cppobj {short_name}"
        struct_extend_lines = []

        base_fields = [field for field in struct.fields if field.base]
        base_fields_used = []
        prev_size = 0
        for base_field in base_fields:
            if base_field.offset == prev_size:
                base_fields_used.append(base_field.type)
                short_base_name = self.get_short_name(base_field.type)
                struct_extend_lines.append(short_base_name)
                prev_size += struct_lookup[base_field.type]
        
        struct_extend_line = ""
        if len(struct_extend_lines) > 0:
            struct_extend_line = " : " + ", ".join(struct_extend_lines)

        struct_string_define += f"{struct_define_line}{struct_extend_line} {{"
        struct_string_define.indent()

        # Add __vtable member if this struct has virtual functions
        if struct.virtual_functions:
            struct_string_define += f"{short_name}_vtbl* __vtable;"

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
                field_define, field_define_size = self.get_string_define_and_size(field, struct.namespace, struct_lookup, enum_lookup)
                struct_string_define += f"{field_define[:-1]}[{field.size}];"
                prev_size += field_define_size * field.size
            elif field_type == "__fastcall":
                struct_string_define += (
                    f"{field.return_type} ({field_type} *{field_name})("
                )
                for param in field.parameters:
                    struct_string_define += param.type + " " + param.name + ", "
                struct_string_define = struct_string_define[:-1] + ");"
                prev_size += 8
            else:
                field_define, field_define_size = self.get_string_define_and_size(field, struct.namespace, struct_lookup, enum_lookup)
                struct_string_define += field_define
                prev_size += field_define_size

        if struct.size is not None and struct.size != 0:
            while struct.size > prev_size:
                fill_size = offset - prev_size
                line, size = self.get_struct_pad(fill_size, prev_size)
                struct_string_define += line
                prev_size += size
        
        struct_string_define.unindent()
        struct_string_define += "};"

        # Virtual table struct definition
        if struct.virtual_functions:
            struct_string_vtable += f"struct __cppobj {short_name}_vtbl {{"
            struct_string_vtable.indent()
            for vfunc in struct.virtual_functions:
                sig = self.build_vfunc_signature(vfunc)
                # Special case for DTOR macro
                if sig.startswith("DTOR"):
                    struct_string_vtable += f"DTOR({short_name})"
                else:
                    struct_string_vtable += sig
            struct_string_vtable.unindent()
            struct_string_vtable += "};"
            vtable_full_name = f"{struct.type}_vtbl"

        return (struct_string_forward, struct_string_define, struct_string_vtable, vtable_full_name)
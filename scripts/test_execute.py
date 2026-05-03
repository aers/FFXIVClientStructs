from lumina_wrapper import get_excel_header_files
from exdschema_wrapper import create_struct_from_header_and_schema, get_exdschema_data
from structs_schema import (
    DefinedStruct,
    DefinedStructFixedField,
    DefinedStructField,
)


class SrcInterface(object):
    def get_idc_type_from_size(self, size: int, offset=0) -> int:
        if offset == 0:
            offset = size
        if offset % 8 == 0 and size >= 8:
            return 4
        elif offset % 4 == 0 and size >= 4:
            return 3
        elif offset % 2 == 0 and size >= 2:
            return 2
        else:
            return 1

    def get_size_from_idc_type(self, type: int) -> int:
        if type == 1:
            return 1
        elif type == 2:
            return 2
        elif type == 3:
            return 4
        elif type == 4:
            return 8
        elif type == 5:
            return 4
        elif type == 6:
            return 8
        else:
            return 0

    def get_string_from_idc_type_and_sign(self, type: int, signed: bool = False) -> str:
        if type == 1:
            if signed:
                return "size8_st"
            else:
                return "size8_t"
        elif type == 2:
            if signed:
                return "size16_st"
            else:
                return "size16_t"
        elif type == 3:
            if signed:
                return "size32_st"
            else:
                return "size32_t"
        elif type == 4:
            if signed:
                return "size32_st"
            else:
                return "size64_t"
        elif type == 5:
            return "float"
        elif type == 6:
            return "double"
        else:
            return ""

    def get_size_from_string(self, type: str) -> int:
        """
        Gets the size of a base type string.
        """
        if type == "size8_st" or type == "size8_t":
            return 1
        if type == "size16_st" or type == "size16_t":
            return 2
        if type == "size32_st" or type == "size32_t" or type == "float":
            return 4
        if (
            type == "size64_st"
            or type == "size64_t"
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
        if field.type in struct_lookup:
            return (f"  {field_type} {field_name};\n", struct_lookup[field.type])
        elif field.type in enum_lookup:
            return (f"  {field_type} {field_name};\n", enum_lookup[field.type])
        else:
            return (f"  {field_type} {field_name};\n", self.get_size_from_string(field_type))


    def build_struct_string(
        self,
        struct: DefinedStruct,
        struct_lookup: dict[str, int],
        enum_lookup: dict[str, int],
    ) -> tuple[str, str, list[str]]:
        """Builds the srclang definition required to parse the object.

        Args:
            struct (DefinedStruct): The struct data to build"""
        struct_string_forward: str = ""
        struct_string_define: str = ""
        struct_string_vtables: list[str] = []
        struct_name = struct.type

        struct_string_forward += f"struct {struct_name};\n"
        if struct.virtual_functions:
            struct_string_forward += f"struct {struct_name}_vtbl;\n"
            struct_string_vtables.append(f"{struct_name}_vtbl")

        struct_string_define += f"struct {struct_name}"

        prev_size = 0
        contiguous_fields = True
        for field in struct.fields:
            offset = field.offset

            while offset > prev_size:
                contiguous_fields = False
                fill_size = offset - prev_size
                if self.full_padding:
                    flag = self.get_idc_type_from_size(prev_size)
                    size = self.get_size_from_idc_type(flag)
                    if size > fill_size:
                        flag = self.get_idc_type_from_size(fill_size, prev_size)
                        size = self.get_size_from_idc_type(flag)

                    struct_string_define += f"  {self.get_string_from_idc_type_and_sign(flag)} field_{prev_size:X};\n"
                else:
                    struct_string_define += f"  char field_{prev_size:X}[{fill_size}];\n"

                prev_size += size

            field_is_base = field.base and contiguous_fields
            if contiguous_fields != field_is_base:
                struct_string_define += " {\n"
                contiguous_fields = False
            field_name = (
                field.name if not field_is_base else "baseclass_{0:X}".format(offset)
            )
            field_type = field.type
            if isinstance(field, DefinedStructFixedField):
                field_define, field_define_size = self.get_string_define_and_size(field, struct.namespace, struct_lookup, enum_lookup)
                struct_string_define += f"{field_define[:-2]}[{field.size}];\n"
                prev_size += field_define_size * field.size
            elif field_type == "__fastcall":
                struct_string_define += (
                    f"  {field.return_type} ({field_type} *{field_name})("
                )
                for param in field.parameters:
                    struct_string_define += param.type + " " + param.name + ", "
                struct_string_define = struct_string_define[:-2] + ");\n"
                prev_size += 8
            else:
                field_define, field_define_size = self.get_string_define_and_size(field, struct.namespace, struct_lookup, enum_lookup)
                struct_string_define += field_define
                prev_size += field_define_size

        if struct.size is not None and struct.size != 0:
            while struct.size > prev_size:
                fill_size = struct.size - prev_size
                if self.full_padding:
                    flag = self.get_idc_type_from_size(prev_size)
                    size = self.get_size_from_idc_type(flag)
                    if size > fill_size:
                        flag = self.get_idc_type_from_size(fill_size, prev_size)
                        size = self.get_size_from_idc_type(flag)

                    struct_string_define += f"  {self.get_string_from_idc_type_and_sign(flag)} field_{prev_size:X};\n"
                else:
                    struct_string_define += f"  char field_{prev_size:X}[{fill_size}];\n"

                prev_size += size
        
        struct_string_define += "};\n"

        return (struct_string_forward, struct_string_define, struct_string_vtables)

excel_header_files = get_excel_header_files()
exdschema = get_exdschema_data("latest")

struct_export = create_struct_from_header_and_schema(
    excel_header_files["GFATE"], exdschema["GFATE"], 0, "GFATE"
)

src = SrcInterface()
src.full_padding = True

struct_lookup = {struct.name: struct.size for struct in struct_export.structs}
enum_lookup = {enum.name: 1 for enum in struct_export.enums}

forwards: list[str] = []
defines: list[str] = []
for struct in struct_export.structs:
    forward, define, _ = src.build_struct_string(struct, struct_lookup, enum_lookup)
    forwards.append(forward)
    defines.append(define)

print("".join(forwards + defines))

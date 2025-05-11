from luminapie.enums import ExcelColumnDataType
from luminapie.definitions import Definition


class ExcelListFile:
    def __init__(self, data):
        # type: (list[bytes]) -> None
        self.data = b"".join(data).split("\r\n".encode("utf-8"))
        self.parse()

    def parse(self):
        # type: () -> None
        self.header = self.data[0].decode("utf-8").split(",")
        self.version = int(self.header[1])
        self.data = self.data[1:]
        self.dict: dict[int, str] = {}
        for line in [x.decode("utf-8") for x in self.data]:
            if line == "":
                continue
            linearr = line.split(",")
            if linearr[1] == "-1":
                continue
            self.dict[int(linearr[1])] = linearr[0]

    def __repr__(self):
        # type: () -> str
        return "ExcelListFile: {0}, {1}".format(self.header, self.dict)


class ExcelHeader:
    def __init__(self, data):
        # type: (bytes) -> None
        self.data = data
        self.parse()

    def parse(self):
        # type: () -> None
        self.magic = self.data[0:4]
        self.version = int.from_bytes(self.data[4:6], "big")
        self.data_offset = int.from_bytes(self.data[6:8], "big")
        self.column_count = int.from_bytes(self.data[8:10], "big")
        self.page_count = int.from_bytes(self.data[10:12], "big")
        self.language_count = int.from_bytes(self.data[12:14], "big")
        self.unknown1 = int.from_bytes(self.data[14:16], "big")
        self.unknown2 = self.data[17]
        self.variant = self.data[18]
        self.unknown3 = int.from_bytes(self.data[19:20], "big")
        self.row_count = int.from_bytes(self.data[20:24], "big")
        self.unknown4 = [
            int.from_bytes(self.data[24:28], "big"),
            int.from_bytes(self.data[28:32], "big"),
        ]

    def __repr__(self):
        # type: () -> str
        return "Header: {0}, version: {1}, data_offset: {2}, column_count: {3}, page_count: {4}, language_count: {5}, unknown1: {6}, unknown2: {7}, variant: {8}, unknown3: {9}, row_count: {10}, unknown4: {11}".format(
            self.magic,
            self.version,
            self.data_offset,
            self.column_count,
            self.page_count,
            self.language_count,
            self.unknown1,
            self.unknown2,
            self.variant,
            self.unknown3,
            self.row_count,
            self.unknown4,
        )


class ExcelColumnDefinition:
    def __init__(self, data):
        # type: (bytes) -> None
        self.data = data
        self.parse()

    def parse(self):
        # type: () -> None
        self.type = ExcelColumnDataType(int.from_bytes(self.data[0:2], "big"))
        self.offset = int.from_bytes(self.data[2:4], "big")

    def __lt__(self, other):
        # type: (ExcelColumnDefinition) -> bool
        return self.offset < other.offset
    
    def __eq__(self, other):
        return self.offset == other.offset and self.type == other.offset

    def __repr__(self):
        # type: () -> str
        return "Column: {0}, offset: {1}".format(self.type.name, self.offset)


class ExcelDataPagination:
    def __init__(self, data):
        # type: (bytes) -> None
        self.data = data
        self.parse()

    def parse(self):
        # type: () -> None
        self.start_id = int.from_bytes(self.data[0:2], "big")
        self.row_count = int.from_bytes(self.data[2:4], "big")

    def __repr__(self):
        # type: () -> str
        return "Pagination: {0:x}, count: {1}".format(self.start_id, self.row_count)


class ExcelHeaderFile:
    def __init__(self, data, name):
        # type: (list[bytes], str) -> None
        self.data = data[0]
        self.column_definitions: list[ExcelColumnDefinition] = []
        self.pagination: list[ExcelDataPagination] = []
        self.languages: list[int] = []
        self.header: ExcelHeader = None
        self.name = name
        self.parse()

    def parse(self):
        # type: () -> None
        self.header = ExcelHeader(self.data[0:32])
        if self.header.magic != b"EXHF":
            raise Exception("Invalid EXHF header")
        self.column_definitions: list[ExcelColumnDefinition] = []
        for i in range(self.header.column_count):
            self.column_definitions.append(
                ExcelColumnDefinition(self.data[32 + (i * 4) : 32 + ((i + 1) * 4)])
            )
        self.column_definitions = sorted(self.column_definitions)
        self.pagination: list[ExcelDataPagination] = []
        for i in range(self.header.page_count):
            self.pagination.append(
                ExcelDataPagination(
                    self.data[
                        32
                        + (self.header.column_count * 4)
                        + (i * 4) : 32
                        + (self.header.column_count * 4)
                        + ((i + 1) * 4)
                    ]
                )
            )
        self.languages: list[int] = []
        for i in range(self.header.language_count):
            self.languages.append(
                self.data[
                    32
                    + (self.header.column_count * 4)
                    + (self.header.page_count * 4)
                    + i
                ]
            )

    def map_names(self, names: list[Definition]) -> tuple[dict[int, tuple[str, str]], dict[str, dict[int, str]], int]:
        """
        Map the column definitions to the names in the header.

        Args:
            names: A list of names of the columns in the header.

        Returns:
            A tuple of a dictionary mapping column offsets to tuples of the column type
            and name, and the size of the structure.
        """
        mapped: dict[int, tuple[str, str]] = {}
        enumMapped: dict[str, dict[int, str]] = {}
        largest_offset_index: int = 0
        for i in range(self.header.column_count):
            if (
                self.column_definitions[i].offset
                > self.column_definitions[largest_offset_index].offset
            ):
                largest_offset_index = i

        size = self.column_definitions[
            largest_offset_index
        ].offset + column_data_type_to_size(
            self.column_definitions[largest_offset_index].type
        )

        if self.header.column_count != len(names):
            for i in range(self.header.column_count):
                mapped[self.column_definitions[i].offset] = (
                    column_data_type_to_c_type(self.column_definitions[i].type),
                    "field_{0}".format(i),
                )
        else:
            for i in range(self.header.column_count):
                col_def = self.column_definitions[i]
                if (
                    col_def.offset in mapped
                    and mapped[col_def.offset] is not None
                ):
                    if (col_def.type in {ExcelColumnDataType.PackedBool0, ExcelColumnDataType.PackedBool1, ExcelColumnDataType.PackedBool2, ExcelColumnDataType.PackedBool3, ExcelColumnDataType.PackedBool4, ExcelColumnDataType.PackedBool5, ExcelColumnDataType.PackedBool6, ExcelColumnDataType.PackedBool7}):
                        name = "PackedBool{0:X}".format(col_def.offset)
                        if (name in enumMapped):
                            enumMapped["PackedBool{0:X}".format(col_def.offset)][(1 << col_def.type - ExcelColumnDataType.PackedBool0)] = "{0}_{1}".format(name, names[i].get_name())
                        else:
                            # this should never be hit but just to be safe
                            enumMapped[name] = {0: "{0}_{1}".format(name, "None"), (1 << col_def.type - ExcelColumnDataType.PackedBool0): "{0}_{1}".format(name, names[i].get_name())}
                    else: 
                        [_, name] = mapped[col_def.offset]
                        if name.split("_")[0] == "Unknown":
                            continue
                        if (
                            column_data_type_to_c_type(col_def.type)
                            != "unsigned __int8"
                        ):
                            continue
                        else:
                            mapped[col_def.offset] = (
                                column_data_type_to_c_type(col_def.type),
                                names[i].get_name(),
                            )
                else:
                    if(col_def.type in {ExcelColumnDataType.PackedBool0, ExcelColumnDataType.PackedBool1, ExcelColumnDataType.PackedBool2, ExcelColumnDataType.PackedBool3, ExcelColumnDataType.PackedBool4, ExcelColumnDataType.PackedBool5, ExcelColumnDataType.PackedBool6, ExcelColumnDataType.PackedBool7}):
                        name = "PackedBool{0:X}".format(col_def.offset)
                        mapped[col_def.offset] = (
                            f"Component::Exd::Sheets::{self.name}::{name}",
                            name
                        )
                        enumMapped[name] = {0: "{0}_{1}".format(name, "None"), (1 << col_def.type - ExcelColumnDataType.PackedBool0): "{0}_{1}".format(name, names[i].get_name())}
                    else:
                        mapped[self.column_definitions[i].offset] = (
                            column_data_type_to_c_type(self.column_definitions[i].type),
                            names[i].get_name(),
                        )
        mapped = dict(sorted(mapped.items()))
        enumMapped = dict(sorted(enumMapped.items()))
        return [mapped, enumMapped, size]


def column_data_type_to_c_type(column_data_type):
    # type: (ExcelColumnDataType) -> str
    if column_data_type == ExcelColumnDataType.Bool:
        return "bool"
    elif column_data_type == ExcelColumnDataType.Int8:
        return "__int8"
    elif column_data_type == ExcelColumnDataType.UInt8:
        return "unsigned __int8"
    elif column_data_type == ExcelColumnDataType.Int16:
        return "__int16"
    elif column_data_type == ExcelColumnDataType.UInt16:
        return "unsigned __int16"
    elif column_data_type == ExcelColumnDataType.Int32:
        return "__int32"
    elif column_data_type == ExcelColumnDataType.UInt32:
        return "unsigned __int32"
    elif column_data_type == ExcelColumnDataType.Float32:
        return "float"
    elif column_data_type == ExcelColumnDataType.Int64:
        return "__int64"
    elif column_data_type == ExcelColumnDataType.UInt64:
        return "unsigned __int64"
    elif (
        column_data_type == ExcelColumnDataType.PackedBool0
        or column_data_type == ExcelColumnDataType.PackedBool1
        or column_data_type == ExcelColumnDataType.PackedBool2
        or column_data_type == ExcelColumnDataType.PackedBool3
        or column_data_type == ExcelColumnDataType.PackedBool4
        or column_data_type == ExcelColumnDataType.PackedBool5
        or column_data_type == ExcelColumnDataType.PackedBool6
        or column_data_type == ExcelColumnDataType.PackedBool7
    ):
        return "unsigned __int8"
    elif column_data_type == ExcelColumnDataType.String:
        return "unsigned __int32"


def column_data_type_to_size(column_data_type):
    # type: (ExcelColumnDataType) -> int
    if (
        column_data_type == ExcelColumnDataType.Bool
        or column_data_type == ExcelColumnDataType.Int8
        or column_data_type == ExcelColumnDataType.UInt8
        or column_data_type == ExcelColumnDataType.PackedBool0
        or column_data_type == ExcelColumnDataType.PackedBool1
        or column_data_type == ExcelColumnDataType.PackedBool2
        or column_data_type == ExcelColumnDataType.PackedBool3
        or column_data_type == ExcelColumnDataType.PackedBool4
        or column_data_type == ExcelColumnDataType.PackedBool5
        or column_data_type == ExcelColumnDataType.PackedBool6
        or column_data_type == ExcelColumnDataType.PackedBool7
    ):
        return 1
    elif (
        column_data_type == ExcelColumnDataType.Int16
        or column_data_type == ExcelColumnDataType.UInt16
    ):
        return 2
    elif (
        column_data_type == ExcelColumnDataType.Int32
        or column_data_type == ExcelColumnDataType.UInt32
        or column_data_type == ExcelColumnDataType.Float32
        or column_data_type == ExcelColumnDataType.String
    ):
        return 4
    elif (
        column_data_type == ExcelColumnDataType.Int64
        or column_data_type == ExcelColumnDataType.UInt64
    ):
        return 8

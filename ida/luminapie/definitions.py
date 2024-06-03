def get_definition(schema):
    # type: (dict[str, str]) -> Definition
    if "type" in schema:
        if schema["type"] == "array":
            return RepeatDefinition(schema)
    return Definition(schema)


class Definition:
    def __init__(self, obj):
        # type: (dict[str, str]) -> None
        self.name = obj["name"]

    def __repr__(self):
        # type: () -> str
        return self.name


class RepeatDefinition(Definition):
    def __init__(self, obj):
        # type: (dict[str, str]) -> None
        super().__init__(obj)
        self.obj = obj
        self.count = obj["count"]
        self.inner_defs = []
        self.process_inner()

    def process_inner(self):
        # type: () -> None
        if "fields" in self.obj:
            for field in self.obj["fields"]:
                if "name" in field:
                    self.inner_defs.append(get_definition(field))
                else:
                    self.inner_defs.append(Definition({"name": ""}))
        if self.inner_defs == []:
            self.inner_defs.append(Definition({"name": ""}))

    def flatten(self, extern):
        # type: (str) -> list[Definition]
        defs = []
        extern = extern + self.name
        for i in range(0, int(self.count)):
            for inner in self.inner_defs:
                if isinstance(inner, RepeatDefinition):
                    defs.extend(inner.flatten(extern + i.__str__()))
                else:
                    defs.append(Definition({"name": extern + i.__str__() + inner.name}))
        return defs

    def __repr__(self):
        # type: () -> str
        return self.flatten("")


class SemanticVersion:
    """Represents a semantic version string that can compare versions"""

    def __init__(self, year, month, date, patch, build=0):
        # type: (int, int, int, int, int) -> None
        self.year = year
        self.month = month
        self.date = date
        self.patch = patch
        self.build = build

    def __lt__(self, other):
        # type: (SemanticVersion) -> bool
        return (
            self.year < other.year
            or self.month < other.month
            or self.date < other.date
            or self.patch < other.patch
            or self.build < other.build
        )

    def __repr__(self):
        # type: () -> str
        return "{0}.{1}.{2}.{3}.{4}".format(
            self.year,
            self.month.__str__().rjust(2, "0"),
            self.date.__str__().rjust(2, "0"),
            self.patch.__str__().rjust(4, "0"),
            self.build.__str__().rjust(4, "0"),
        )

    def __eq__(self, __value):
        # type: (object) -> bool
        if not isinstance(__value, SemanticVersion):
            return False
        return (
            self.year == __value.year
            and self.month == __value.month
            and self.date == __value.date
            and self.patch == __value.patch
            and self.build == __value.build
        )

    def __hash__(self):
        # type: () -> int
        return hash(repr(self))

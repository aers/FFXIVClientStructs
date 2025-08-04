class DefinedStructBase:
    def __init__(self, name, type, namespace):
        # type: (str, str, str) -> None
        self.name = name
        self.type = type
        self.namespace = namespace


class DefinedStructEnum(DefinedStructBase, object):
    def __init__(self, name, type, underlying, namespace, flags, values):
        # type: (str, str, str, str, bool, dict[str, int]) -> None
        super(DefinedStructEnum, self).__init__(name, type, namespace)
        self.name = name
        self.type = type
        self.values = values
        self.flags = flags
        self.underlying = underlying


class DefinedStructFuncParam:
    def __init__(self, name, type):
        # type: (str, str) -> None
        self.name = name
        if type == "__fastcall":
            self.type = "__int64"
        else:
            self.type = type


class DefinedStructVFunc:
    def __init__(self, name, return_type, offset, parameters):
        # type: (str, str, int, list[DefinedStructFuncParam]) -> None
        self.name = name
        self.return_type = return_type
        self.offset = offset
        self.parameters = parameters


class DefinedStructMemFunc:
    def __init__(self, signature, return_type, parameters, name):
        # type: (str, str, list[DefinedStructFuncParam], str) -> None
        self.signature = signature
        self.return_type = return_type
        self.parameters = parameters
        self.name = name


class DefinedStructField(DefinedStructFuncParam, object):
    def __init__(self, name, type, offset, base):
        # type: (str, str, int, bool) -> None
        super(DefinedStructField, self).__init__(name, type)
        self.offset = offset
        self.base = base


class DefinedStructFuncField(DefinedStructField, object):
    def __init__(self, name, type, offset, base, return_type, params):
        # type: (str, str, int, bool, str | None, list[DefinedStructFuncParam] | None) -> None
        super(DefinedStructFuncField, self).__init__(name, type, offset, base)
        self.return_type = return_type
        self.parameters = params


class DefinedStructStaticMember:
    def __init__(self, signature, relative_offsets, return_type, is_pointer):
        # type: (str, list[int], str, bool) -> None
        self.signature = signature
        self.relative_offsets = relative_offsets
        self.return_type = return_type
        self.is_pointer = is_pointer


class DefinedStructFixedField(DefinedStructField, object):
    def __init__(self, name, type, offset, base, size):
        # type: (str, str, int, bool, str | None) -> None
        super(DefinedStructFixedField, self).__init__(name, type, offset, base)
        self.size = size


class DefinedStruct(DefinedStructBase, object):
    def __init__(
        self,
        name,
        type,
        namespace,
        fields,
        size,
        vtable_size,
        virtual_functions,
        member_functions,
        union,
        static_member_functions,
        static_members,
    ):
        # type: (str, str, str, list[DefinedStructField], int | None, int | None, list[DefinedStructVFunc] | None, list[DefinedStructMemFunc], str, list[DefinedStructMemFunc] | None, list[DefinedStructStaticMember] | None) -> None
        super(DefinedStruct, self).__init__(name, type, namespace)
        self.fields = fields
        self.size = size
        self.vtable_size = vtable_size
        self.virtual_functions = virtual_functions
        self.member_functions = member_functions
        self.union = bool(union)
        self.static_member_functions = static_member_functions
        self.static_members = static_members


class DefinedStructExport:
    def __init__(self, enums, structs):
        # type: (list[DefinedStructEnum], list[DefinedStruct]) -> None
        self.enums = enums
        self.structs = structs

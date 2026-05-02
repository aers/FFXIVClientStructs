class DefinedDataClassInstance:
    def __init__(self, ea, pointer=False, name=None):
        # type: (int, bool, str | None) -> None
        self.ea = ea
        self.pointer = pointer
        self.name = name

class DefinedDataClassVtable:
    def __init__(self, ea, base=None):
        # type: (int, None | str) -> None
        self.ea = ea
        self.base = base

class DefinedDataClassFunction:
    def __init__(self, num, name):
        # type: (int, str) -> None
        self.num = num
        self.name = name

class DefinedDataClass:
    def __init__(self, name, instances=[], vtbls=[], functions=[], vfuncs=[]):
        # type: (str, list[DefinedDataClassInstance], list[DefinedDataClassVtable], list[DefinedDataClassFunction], list[DefinedDataClassFunction]) -> None
        self.instances = instances
        self.vtbls = vtbls
        self.functions = functions
        self.vfuncs = vfuncs
        self.name = name

class DefinedData:
    def __init__(self, classes=[]):
        # type: (list[DefinedDataClass]) -> None
        self.classes = classes
        pass
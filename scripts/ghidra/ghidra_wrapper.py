from ghidra.program.flatapi import FlatProgramAPI
from ghidra.program.model.data import (
    ArrayDataType,
    BooleanDataType,
    ByteDataType,
    CategoryPath,
    CharDataType,
    DataType,
    DataUtilities,
    DoubleDataType,
    EnumDataType,
    FloatDataType,
    FunctionDefinitionDataType,
    IntegerDataType,
    LongLongDataType,
    ParameterDefinition,
    ParameterDefinitionImpl,
    ShortDataType,
    SignedByteDataType,
    StructureDataType,
    UnionDataType,
    UnsignedIntegerDataType,
    UnsignedLongLongDataType,
    UnsignedShortDataType,
    VoidDataType,
    WideCharDataType,
)
from ghidra.program.model.listing import Function, ParameterImpl, ReturnParameterImpl
from ghidra.program.model.symbol import SourceType
from java.util import ArrayList
from jpype import JArray, JByte, JLong

from structs_schema import (
    DefinedStruct,
    DefinedStructEnum,
    DefinedStructExport,
    DefinedStructFixedField,
    DefinedStructFuncField,
    DefinedStructFuncParam,
    DefinedStructMemFunc,
    DefinedStructStaticMember,
    DefinedStructVFunc,
    get_template_alias,
)
from data_schema import get_yaml, DefinedData, DefinedDataClassVtable
from clang_wrapper import ClangInterface, split_type_path

from platform import system
from pathlib import Path
import os
import re

DEFAULT_NAME_PREFIXES = ("FUN_", "LAB_", "SUB_", "LOC_", "DAT_")
# the fields SrcInterface.get_struct_pad fills the unknown parts of a struct with
PAD_FIELD_NAME = re.compile(r"field_[0-9A-F]+")

def newest_version_folder(base: Path) -> Path:
    """The highest version folder in base."""
    if not base.is_dir():
        raise RuntimeError(f"{base} is missing, select the folder msvc-wine's install.sh was run on")
    versions = [p for p in base.iterdir() if p.is_dir() and re.fullmatch(r"[\d.]+", p.name)]
    if not versions:
        raise RuntimeError(f"No version folder in {base}")
    return max(versions, key=lambda p: tuple(int(part) for part in p.name.split(".") if part))


class GhidraInterface(object):
    BADADDR = 0xFFFFFFFFFFFFFFFF

    data_yaml: DefinedData
    parser_args: list[str]
    # typedef name to the type behind it, see get_template_alias
    template_aliases: dict[str, str] = {}

    def __init__(self, program, monitor):
        """Takes currentProgram and monitor of the running script."""
        # the script globals (currentProgram, getFunctionAt, ...) only exist in the script itself
        self.program = program
        self.monitor = monitor
        self.flat = FlatProgramAPI(program, monitor)
        self.dtm = program.getDataTypeManager()
        self.listing = program.getListing()
        self.memory = program.getMemory()
        self.symbols = program.getSymbolTable()
        void_ptr = self.dtm.getPointer(VoidDataType.dataType)
        self.primitives = {
            "void": VoidDataType.dataType,
            "bool": BooleanDataType.dataType,
            "char": CharDataType.dataType,
            "wchar_t": WideCharDataType.dataType,
            "byte": ByteDataType.dataType,
            "float": FloatDataType.dataType,
            "double": DoubleDataType.dataType,
            "int": IntegerDataType.dataType,
            "unsigned int": UnsignedIntegerDataType.dataType,
            "__int8": SignedByteDataType.dataType,
            "__int16": ShortDataType.dataType,
            "__int32": IntegerDataType.dataType,
            "__int64": LongLongDataType.dataType,
            "unsigned __int8": ByteDataType.dataType,
            "unsigned __int16": UnsignedShortDataType.dataType,
            "unsigned __int32": UnsignedIntegerDataType.dataType,
            "unsigned __int64": UnsignedLongLongDataType.dataType,
            "int8_t": SignedByteDataType.dataType,
            "int16_t": ShortDataType.dataType,
            "int32_t": IntegerDataType.dataType,
            "int64_t": LongLongDataType.dataType,
            "uint8_t": ByteDataType.dataType,
            "uint16_t": UnsignedShortDataType.dataType,
            "uint32_t": UnsignedIntegerDataType.dataType,
            "uint64_t": UnsignedLongLongDataType.dataType,
            # function pointers are exported without their signature
            "__fastcall": void_ptr,
        }

    def get_base_path(self):
        return os.path.join(
            os.path.dirname(os.path.realpath(__file__)), ".."
        )

    def get_data_path(self):
        return os.path.join(self.get_base_path(), "data.yml")

    def load_data_yml(self):
        with open(self.get_data_path()) as f:
            self.data_yaml = get_yaml(f)

    def get_struct_path(self):
        return os.path.join(self.get_base_path(), "structs.yml")

    def to_addr(self, ea: int):
        return self.flat.toAddr(JLong(ea))

    def check_cancelled(self):
        if self.monitor.isCancelled():
            raise RuntimeError("Cancelled by user")

    # region types

    def get_category_path(self, type_name: str):
        """The category a type lives in, ex. /Component/GUI."""
        category = CategoryPath.ROOT
        for part in split_type_path(type_name)[:-1]:
            category = CategoryPath(category, part)
        return category

    def get_type_name(self, type_name: str) -> str:
        return split_type_path(type_name)[-1]

    def get_named_type(self, name: str):
        """Returns None if Ghidra does not know the type."""
        if name in self.primitives:
            return self.primitives[name]

        if "<" in name and get_template_alias(name) in self.template_aliases:
            # clang spells template names differently than the yml
            name = self.template_aliases[get_template_alias(name)]

        dt = self.dtm.getDataType(self.get_category_path(name), self.get_type_name(name))
        if dt is None and "::" not in name:
            # ex. windows types that came from an applied archive
            found = ArrayList()
            self.dtm.findDataTypes(name, found)
            if found.size() > 0:
                dt = found.get(0)
        return dt

    def get_tinfo_from_type(self, raw_type: str, array_size=0):
        """Returns None if the type could not be built."""
        type = raw_type.strip().rstrip("*").strip()
        ptr_count = raw_type.count("*", len(type))

        dt = self.get_named_type(type)
        if dt is None:
            if ptr_count == 0:
                return None
            # a pointer to something unknown is still a pointer
            dt = VoidDataType.dataType

        for _ in range(ptr_count):
            dt = self.dtm.getPointer(dt)

        if array_size > 0:
            dt = ArrayDataType(dt, array_size, dt.getLength())

        return dt

    def get_enum_id(self, name: str):
        return self.get_named_type(name)

    def get_struct_id(self, name: str):
        return self.get_named_type(name)

    def create_datatype(self, datatype):
        """Add the type, replacing the one with the same path."""
        old = self.dtm.getDataType(datatype.getDataTypePath())
        if old is not None:
            old.replaceWith(datatype)
            return old
        return self.dtm.addDataType(datatype, None)

    def create_enum(self, enum: DefinedStructEnum):
        underlying = self.get_named_type(enum.underlying)
        size = underlying.getLength() if underlying is not None else 4
        dt = EnumDataType(self.get_category_path(enum.type), self.get_type_name(enum.type), size)
        for name, value in enum.values.items():
            if value >= 1 << 63:
                # java longs are signed
                value -= 1 << 64
            try:
                dt.add(name, value)
            except Exception as e:
                print(f"Error: enum {enum.type} can not hold {name} = {value}: {e}")
        self.create_datatype(dt)

    def create_struct(self, struct: DefinedStruct):
        """The struct without its members, so it can be pointed to."""
        category, name = self.get_category_path(struct.type), self.get_type_name(struct.type)
        if struct.union:
            dt = UnionDataType(category, name)
        else:
            dt = StructureDataType(category, name, struct.size or 0)
        self.create_datatype(dt)

    def create_struct_members(self, struct: DefinedStruct):
        dt = self.get_named_type(struct.type)
        if dt is None:
            return

        for field in sorted(struct.fields, key=lambda fld: fld.offset):
            if PAD_FIELD_NAME.fullmatch(field.name):
                # undefined bytes are of more use in ghidra than a filler field
                continue

            if isinstance(field, DefinedStructFuncField):
                ft = self.dtm.getPointer(self.create_function_def(field, struct))
            else:
                ft = self.get_tinfo_from_type(field.type)
            if ft is None:
                print(f"Error: field {field.name} of {struct.type} has unknown type {field.type!r}")
                continue

            if isinstance(field, DefinedStructFixedField):
                if int(field.size) < 1:
                    continue
                ft = ArrayDataType(ft, int(field.size), ft.getLength() or -1)

            if struct.union:
                dt.add(ft, ft.getLength(), field.name, "")
                continue

            size = 0 if dt.isZeroLength() else dt.getLength()
            end = field.offset + ft.getLength()
            if size < end:
                if struct.size:
                    print(
                        f"Error: field {field.name} (off=0x{field.offset:X} size=0x{ft.getLength():X}) not within struct {struct.type} (size=0x{size:X})"
                    )
                    break
                dt.growStructure(end - size)

            dt.replaceAtOffset(field.offset, ft, -1, field.name, "")

    def create_function_def(self, func: DefinedStructFuncField, struct: DefinedStruct):
        """Signature of a function pointer field."""
        fd = FunctionDefinitionDataType(
            CategoryPath(self.get_category_path(struct.type), self.get_type_name(struct.type)), func.name
        )
        fd.setReturnType(self.get_tinfo_from_type(func.return_type) or DataType.DEFAULT)
        args = [
            ParameterDefinitionImpl(arg.name, self.get_tinfo_from_type(arg.type) or DataType.DEFAULT, None)
            for arg in func.parameters
        ]
        fd.setArguments(JArray(ParameterDefinition)(args))
        return fd

    def select_parser(self, msvc_path: str | None = None):
        """msvc_path is where msvc-wine was installed, not needed on windows."""
        includes = []
        if system() != "Windows":
            if msvc_path is None:
                raise RuntimeError("Has to have msvc includes for the parsers to work with the project")
            path = Path(msvc_path)
            vc_path = newest_version_folder(path / "vc" / "tools" / "msvc") / "include"
            window_kit = newest_version_folder(path / "kits" / "10" / "include")
            # as system headers like clang adds them on windows, otherwise the warnings it treats as errors in them count
            for folder in (vc_path, window_kit / "ucrt", window_kit / "um", window_kit / "shared"):
                includes += ["-isystem", folder.as_posix()]

        self.parser_args = [
            "-x", "c++", "-target", "x86_64-pc-windows-msvc", "-fms-compatibility", "-fms-extensions",
            "-U__int64", "-std=c++17", "-ferror-limit=0",
            # the libclang package is older than what newer msvc headers expect
            "-D_ALLOW_COMPILER_AND_STL_VERSION_MISMATCH", "-D_MSVC_STL_USE_ABORT_AS_DOOM_FUNCTION",
            *includes,
        ]

    def get_probe_layouts(self, source: str) -> dict[str, tuple[int, int]]:
        """Size and offset of value in each probe struct of SrcInterface.get_layout_probe."""
        return ClangInterface(
            self.parser_args, os.environ.get("LIBCLANG_LIBRARY_FILE")
        ).parse_layout_probe(source)

    def parse_string(self, decl: str, vtables: list[str]) -> int:
        """Import the declarations as clang lays them out, returns the error count."""
        export, self.template_aliases, error_count = ClangInterface(
            self.parser_args, os.environ.get("LIBCLANG_LIBRARY_FILE")
        ).parse_string(decl)
        if error_count > 0:
            print(f"Error: clang parser reported {error_count} error(s) while importing declarations")
        else:
            print("Clang parser imported declarations without errors")

        self.import_structs(export)

        missing = [vtable for vtable in vtables if self.get_named_type(vtable) is None]
        for vtable in missing:
            print(f"Error: vtable '{vtable}' not found in the data types")
        print(f"Imported {len(vtables) - len(missing)}/{len(vtables)} vtables ({len(missing)} failed)")

        return error_count

    def import_structs(self, export: DefinedStructExport) -> int:
        """Import the structs in dependency order, returns the failure count."""
        steps = [
            ("Creating enums", export.enums, self.create_enum),
            ("Creating structs", export.structs, self.create_struct),
            ("Creating members for structs", export.structs, self.create_struct_members),
        ]
        error_count = 0
        for message, items, step in steps:
            print(message)
            self.monitor.setMessage(message)
            for item in items:
                self.check_cancelled()
                try:
                    step(item)
                except Exception as e:
                    error_count += 1
                    print(f"Error: {message.lower()} failed on {item.type}: {e}")

        if error_count > 0:
            print(f"Error: {error_count} error(s) while importing declarations")
        else:
            print("Imported declarations without errors")
        return error_count

    # endregion

    # region functions

    def get_func(self, ea: int, create: bool = False):
        """Function starting at ea."""
        addr = self.to_addr(ea)
        func = self.flat.getFunctionAt(addr)
        if func is None and create:
            if self.flat.getInstructionAt(addr) is None:
                self.flat.disassemble(addr)
            func = self.flat.createFunction(addr, None)
        return func

    def has_default_name(self, ea: int) -> bool:
        """Only true for functions Ghidra named itself."""
        func = self.get_func(ea, True)
        return func is not None and func.getSymbol().getSource() == SourceType.DEFAULT

    def apply_func_type(self, ea: int, func_name: str, return_type: str, parameters: list[DefinedStructFuncParam]) -> bool:
        """Returns False if one of the types is not known to Ghidra."""
        func = self.get_func(ea, True)
        if func is None:
            print(f"Error: {func_name} @ {ea:#x} is not a function")
            return False

        rettype = self.get_tinfo_from_type(return_type)
        if rettype is None:
            print(f"Error: {func_name} @ {ea:#x} has unknown return type {return_type!r}")
            return False

        args = ArrayList()
        for param in parameters:
            arg_type = self.get_tinfo_from_type(param.type)
            if arg_type is None:
                print(f"Error: {func_name} @ {ea:#x} has unknown type {param.type!r} on parameter {param.name!r}")
                return False
            args.add(ParameterImpl(param.name, arg_type, self.program))

        try:
            func.updateFunction(
                "__fastcall",
                ReturnParameterImpl(rettype, self.program),
                args,
                Function.FunctionUpdateType.DYNAMIC_STORAGE_ALL_PARAMS,
                False,
                SourceType.USER_DEFINED,
            )
        except Exception as e:
            print(f"Error: {func_name} @ {ea:#x} failed to apply its function type: {e}")
            return False
        return True

    def get_vft_from_data(self, class_name: str) -> DefinedDataClassVtable | None:
        class_data = self.data_yaml.classes.get(class_name)
        if class_data is None or not class_data.vtbls:
            return None

        return class_data.vtbls[0]

    def get_vfunc_ea_from_data(self, class_name: str, offset: int) -> int:
        vtable = self.get_vft_from_data(class_name)
        if vtable is None:
            return self.BADADDR

        vtable_ea = vtable.ea + self.get_image_base() - 0x140000000
        try:
            return self.get_qword(vtable_ea + offset)
        except Exception:
            return self.BADADDR

    def set_func_name(self, ea, name, cmt=None, unique=False):
        """With unique only default names are replaced, a taken name gets a number."""
        if unique:
            if not self.has_default_name(ea):
                return
            base_name, count = name, 1
            while self.get_func_ea_by_name(name) not in (self.BADADDR, ea):
                count += 1
                name = f"{base_name}{count}"
            print(name)

        func = self.get_func(ea, True)
        if func is None:
            self.set_addr_name(ea, name)
            return
        func.setName(name, SourceType.USER_DEFINED)
        if cmt is not None:
            func.setComment(cmt)

    def get_func_name(self, ea: int) -> str:
        """Name of the function containing ea."""
        func = self.flat.getFunctionContaining(self.to_addr(ea))
        return func.getName() if func is not None else ""

    def get_func_start(self, ea: int) -> int:
        """Start of the function containing ea."""
        return self.flat.getFunctionContaining(self.to_addr(ea)).getEntryPoint().getOffset()

    def get_func_ea_by_name(self, name: str) -> int:
        for symbol in self.symbols.getGlobalSymbols(name):
            return symbol.getAddress().getOffset()
        return self.BADADDR

    def get_func_xrefs(self, ea: int) -> list[int]:
        """The addresses calling ea."""
        return [
            xref.getFromAddress().getOffset()
            for xref in self.flat.getReferencesTo(self.to_addr(ea))
            if xref.getReferenceType().isCall()
        ]

    def get_func_ea_by_sig(self, pattern: str) -> int:
        ea = self.search_binary(0, pattern)
        if ea == self.BADADDR:
            return ea

        if self.get_func(ea) is not None:
            return ea

        insn = self.flat.getInstructionAt(self.to_addr(ea))
        if insn is None:
            return self.BADADDR

        flow = insn.getFlowType()
        if flow.isCall() or flow.isJump():
            flows = insn.getFlows()
            if len(flows) != 1:
                print(f"Error: Can't follow {insn} @ {ea:#x}")
                return self.BADADDR
            return flows[0].getOffset()

        return self.BADADDR

    def update_member_func(self, member_func: DefinedStructMemFunc, struct: DefinedStruct) -> None:
        func_name = f"{struct.type}.{member_func.name}"
        ea = self.get_func_ea_by_name(func_name)
        if ea == self.BADADDR:
            ea = self.get_func_ea_by_sig(member_func.signature)
        if ea == self.BADADDR:
            print(
                f"Error: {func_name} not found bad sig? {member_func.signature}"
            )
            return
        if self.has_default_name(ea):
            self.set_func_name(ea, func_name)
        self.apply_func_type(ea, func_name, member_func.return_type, member_func.parameters)

    def update_virt_func(self, virt_func: DefinedStructVFunc, struct: DefinedStruct):
        func_name = f"{struct.type}.{virt_func.name}"

        ea = self.get_func_ea_by_name(func_name)
        if ea == self.BADADDR:
            if self.get_vft_from_data(struct.type) is None:
                # no vtable address in data.yml, so there is no slot to look up
                return
            ea = self.get_vfunc_ea_from_data(struct.type, virt_func.offset)
            if ea in (0, self.BADADDR):
                print(f"Error: {func_name} not found and its VFT slot could not be resolved")
                return

            normalized_name = self.get_addr_name(ea).removeprefix("thunk_")

            if normalized_name == "_purecall":
                return

            primary_base = self.get_vft_from_data(struct.type).base
            if primary_base:
                base_ea = self.get_vfunc_ea_from_data(primary_base, virt_func.offset)
                if base_ea == ea:
                    return

            if (
                normalized_name.endswith("." + virt_func.name)
                and not normalized_name.startswith(struct.type + ".")
            ):
                return
        self.apply_func_type(ea, func_name, virt_func.return_type, virt_func.parameters)

    def get_static_member_ea(self, static_member: DefinedStructStaticMember) -> int:
        """Where the static member's signature resolves to, BADADDR if not found."""
        ea = self.search_binary(0, static_member.signature)
        if ea == self.BADADDR:
            return ea
        for follows in static_member.relative_offsets:
            ea = ea + follows
            ea = ea + 4 + self.memory.getInt(self.to_addr(ea))
        return ea

    def update_static_member(self, static_member: DefinedStructStaticMember, struct: DefinedStruct):
        ea = self.get_static_member_ea(static_member)
        if ea == self.BADADDR:
            print(f"Error: {static_member.signature} not found something is wrong")
            return
        addr = self.to_addr(ea)
        data = self.listing.getDefinedDataContaining(addr)
        if data is not None and data.getAddress().getOffset() != ea and static_member.return_type != struct.type:
            # points into an already typed item (ex. a field of the struct instance)
            return
        return_type = static_member.return_type
        if static_member.is_pointer:
            return_type = return_type + "*"
        dt = self.get_tinfo_from_type(return_type)
        if dt is None:
            print(f"Error: static member of {struct.type} @ {ea:#x} has unknown type {return_type!r}")
        else:
            try:
                DataUtilities.createData(
                    self.program, addr, dt, -1, DataUtilities.ClearDataMode.CLEAR_ALL_CONFLICT_DATA
                )
            except Exception as e:
                print(f"Error: static member of {struct.type} @ {ea:#x} failed to apply {return_type!r}: {e}")
        self.set_addr_name(ea, f"g_{struct.type}_{static_member.name}")

    # endregion

    # region addresses

    def get_image_base(self) -> int:
        return self.program.getImageBase().getOffset()

    def is_offset(self, ea: int) -> bool:
        data = self.flat.getDataAt(self.to_addr(ea))
        return bool(data) and data.isPointer()

    def xrefs_to(self, ea: int) -> list[int]:
        return [xref.getFromAddress().getOffset() for xref in self.flat.getReferencesTo(self.to_addr(ea))]

    def get_qword(self, ea: int) -> int:
        return self.memory.getLong(self.to_addr(ea)) & 0xFFFFFFFFFFFFFFFF

    def get_dword(self, ea: int) -> int:
        return self.memory.getInt(self.to_addr(ea)) & 0xFFFFFFFF

    def get_addr_name(self, ea: int) -> str:
        addr = self.to_addr(ea)
        sym = self.flat.getSymbolAt(addr)
        if not sym:
            # code only reachable through a vtable is not always disassembled, it does follow the padding of the previous function
            try:
                is_padded = self.memory.getByte(addr.subtract(1)) & 0xFF == 0xCC
            except Exception:
                return ""
            if is_padded:
                self.get_func(ea, True)
                sym = self.flat.getSymbolAt(addr)
        if not sym:
            return ""
        return sym.getName(True)

    def set_addr_name(self, ea: int, name: str) -> bool:
        self.flat.createLabel(self.to_addr(ea), name, True, SourceType.ANALYSIS)
        return True

    def get_comment(self, ea: int):
        return self.flat.getEOLComment(self.to_addr(ea))

    def set_comment(self, ea: int, comment: str):
        # the callers append to what is already there, keeping the first one makes a rerun not stack them
        if self.flat.getEOLComment(self.to_addr(ea)) is None:
            self.flat.setEOLComment(self.to_addr(ea), comment)

    def get_string_from_ptr(self, ea: int) -> str:
        val = self.get_string(ea)
        if val is None:
            val = self.get_string(self.get_qword(ea))
        return val

    def get_string(self, ea: int) -> str | None:
        """Returns None if there is no printable string at ea."""
        chars = bytearray()
        try:
            while len(chars) < 256:
                char = self.memory.getByte(self.to_addr(ea + len(chars))) & 0xFF
                if char == 0:
                    break
                if not 0x20 <= char < 0x7F:
                    return None
                chars.append(char)
        except Exception:
            return None
        return chars.decode("ascii") if chars else None

    # endregion

    # region instructions

    def heads_before(self, ea: int, count: int):
        """The instructions before ea, closest first."""
        insn = self.listing.getInstructionContaining(self.to_addr(ea))
        for _ in range(count):
            insn = insn.getPrevious()
            if insn is None:
                return
            yield insn.getAddress().getOffset()

    def heads_until_call(self, ea: int, func_name: str):
        """The instructions from ea up to the call of the named function."""
        target = self.get_func_ea_by_name(func_name)
        insn = self.listing.getInstructionAt(self.to_addr(ea))
        while insn is not None:
            if insn.getFlowType().isCall() and any(flow.getOffset() == target for flow in insn.getFlows()):
                return
            yield insn.getAddress().getOffset()
            insn = insn.getNext()

    def get_registers(self, eas, mnemonics=None) -> dict[str, dict[str, object]]:
        """What the instructions write to each register, later ones win."""
        regs = {}
        for ea in eas:
            insn = self.listing.getInstructionAt(self.to_addr(ea))
            if insn is None or insn.getNumOperands() < 2:
                continue
            if mnemonics is not None and str(insn.getMnemonicString()).lower() not in mnemonics:
                continue
            val_text = str(insn.getDefaultOperandRepresentation(1)).lower()
            val = 0
            refs = insn.getOperandReferences(1)
            if len(refs) > 0:
                val = refs[0].getToAddress().getOffset()
                if refs[0].getReferenceType().isRead():
                    # the register is loaded from memory, ex. a pointer to the class name
                    val_text = self.get_string_from_ptr(val)
            elif insn.getScalar(1) is not None:
                val = insn.getScalar(1).getUnsignedValue()
            regs[str(insn.getDefaultOperandRepresentation(0)).lower()] = {'val_text': val_text, 'val': val}
        return regs

    # endregion

    # region naming

    def format_class_name_for_vtbl(self, class_name: str) -> str:
        return f"vtbl_{class_name}"

    def format_class_name_for_secondary_vtbl(self, class_name: str, secondary_name: str) -> str:
        return f"vtbl_{class_name}___{secondary_name}"

    def format_class_name(self, class_name: str) -> str:
        return class_name

    def format_vfunc_name(self, ea: int, current_func_name: str, proposed_func_name: str, class_name: str, base_class_names: list[str]) -> str | None:
        current_func_name = current_func_name.removeprefix("thunk_")  # jump

        # Previously renamed as a vfunc
        if current_func_name.startswith(class_name):
            # return the proposed func name in case it was updated since last run
            current_class_name = current_func_name.rsplit(".", 1)[0]
            return f"{current_class_name}.{proposed_func_name}"

        # This should have been handled in the base class
        if any(current_func_name.startswith(name) for name in base_class_names):
            return ""

        if current_func_name.startswith(DEFAULT_NAME_PREFIXES):
            return f"{class_name}.{proposed_func_name}"

        # Name it later in a child class when it gets overridden
        if current_func_name == "_purecall":
            return ""

        return None

    def format_func_name(self, ea: int, current_func_name: str, proposed_func_name: str, class_name: str) -> str | None:
        # override default thunk names and thunks of already named funcs with the default
        func = self.get_func(ea)
        if func and func.isThunk():
            current_func_name = f"FUN_{ea:x}"

        proposed_qualified_func_name = f"{class_name}.{proposed_func_name}"
        if current_func_name == proposed_qualified_func_name:
            return ""

        if current_func_name.startswith(DEFAULT_NAME_PREFIXES):
            return proposed_qualified_func_name

        return None

    # endregion

    # region search

    def get_search_range(self):
        """Only .text if the program has one, the signatures are all code."""
        block = self.memory.getBlock(".text")
        if block is not None:
            return block.getStart(), block.getEnd()
        return self.memory.getMinAddress(), self.memory.getMaxAddress()

    def search_binary(self, ea: int, pattern: str) -> int:
        """The pattern is space separated hex bytes, ? or ?? for a wildcard."""
        start, end = self.get_search_range()
        if ea > end.getOffset():
            return self.BADADDR
        if ea > start.getOffset():
            start = self.to_addr(ea)

        tokens = pattern.split()
        values = bytes(0 if "?" in token else int(token, 16) for token in tokens)
        masks = bytes(0 if "?" in token else 0xFF for token in tokens)
        found = self.memory.findBytes(
            start, end, JArray(JByte)(values), JArray(JByte)(masks), True, self.monitor
        )
        return found.getOffset() if found is not None else self.BADADDR

    def search_binary_all(self, pattern: str, ea: int = 0):
        """Every address matching the pattern, starting from ea."""
        ea = self.search_binary(ea, pattern)
        while ea != self.BADADDR:
            self.check_cancelled()
            yield ea
            ea = self.search_binary(ea + 1, pattern)

    # endregion

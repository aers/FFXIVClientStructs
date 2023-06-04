#!/usr/bin/env python3

import dataclasses
import logging
import os
import sys
from dataclasses import dataclass, field
from json import JSONEncoder
from pathlib import Path
from typing import Dict, Iterator, List, Optional, Set

import dacite
import ida_bytes

from ruamel.yaml import YAML
yaml = YAML()
yaml.allow_duplicate_keys = True
yaml.width = 4096

import idaapi
import idautils
import ida_funcs
import ida_segment

LOGGING = logging.DEBUG
SENTINEL = 0xDEAD_BEEF

@yaml.register_class
@dataclass
class GeneratedClass:
    func_sigs: Dict[str, str] = field(default_factory=dict)

@yaml.register_class
@dataclass
class GeneratedData:
    version: str
    global_sigs: Dict[str, str] = field(default_factory=dict)
    classes: Dict[str, Optional[GeneratedClass]] = field(default_factory=dict)

    def get_function_signature(self, cls: str, function: str) -> Optional[str]:
        if cls in self.classes:
            if function in self.classes[cls].func_sigs:
                return self.classes[cls].func_sigs[function]

        return None

    def set_function_signature(self, cls: str, function: str, sig: str) -> None:
        if cls not in self.classes:
            self.classes[cls] = GeneratedClass()
        self.classes[cls].func_sigs[function] = sig

@dataclass
class ClassVtbl:
    ea: int
    base: Optional[str]


@dataclass
class GameClass:
    g_instance: Optional[int]
    g_pointer: Optional[int]
    vtbls: List[ClassVtbl] = field(default_factory=list)
    funcs: Dict[int, str] = field(default_factory=dict)
    vfuncs: Dict[int, str] = field(default_factory=dict)

@dataclass
class ClientStructsData:
    version: str
    globals: Dict[int, str] = field(default_factory=dict)
    functions: Dict[int, str] = field(default_factory=dict)
    classes: Dict[str, Optional[GameClass]] = field(default_factory=dict)


class DataclassJSONEncoder(JSONEncoder):
    """
    Dataclass serializer
    """

    def default(self, obj):
        if dataclasses.is_dataclass(obj):
            return dataclasses.asdict(obj)
        return super().default(obj)


class Log:
    """
    A logger
    """

    @staticmethod
    def _log(level: str, message: str) -> None:
        """
        Log a message
        :param level: Log level
        :param message: The message
        :return: None
        """
        print(f'[{level}] {message}')

    @staticmethod
    def debug(message: str) -> None:
        """
        Log a debug message
        :param message: The message
        :return: None
        """
        if LOGGING >= logging.DEBUG:
            Log._log('DBG', message)

    @staticmethod
    def info(message: str) -> None:
        """
        Log an info message
        :param message: The message
        :return: None
        """
        if LOGGING >= logging.INFO:
            Log._log('INF', message)

    @staticmethod
    def warn(message: str) -> None:
        """
        Log a warning message
        :param message: The message
        :return: None
        """
        if LOGGING >= logging.WARN:
            Log._log('WRN', message)

    @staticmethod
    def error(message: str) -> None:
        """
        Log an error message
        :param message: The message
        :return: None
        """
        if LOGGING >= logging.ERROR:
            Log._log('ERR', message)


class SigGen:
    """
    Generate a variable instruction length signature on demand from a single address
    that resides within a function. Maximum sig length is decided by the smaller of
    the func length or the INSN_TO_SIG variable.
    """
    _INSN_TO_SIG = 30  # Max number of instructions to sig

    _base_addr: int  # base address
    _max_addr: int  # address of last function instruction
    _max_index: int  # count of instructions
    _insn_addr_cache: Dict[int, int]  # index: addr
    _sig_cache: Dict[int, str]  # index: sig chunk

    def __init__(self, addr: int):
        """
        Signature generator
        :param addr: Base address to start generating signatures from
        """
        self._base_addr = addr

        # FuncItems returns the address of each insn.
        # The addr can be anywhere inside the func itself.
        # So this gets all insn addresses >= the addr parameter
        func_items = [ea for ea in idautils.FuncItems(addr) if ea >= addr]

        # The last address of the function
        # Sig-able addresses can be this, but not greater than this
        self._max_addr = func_items[-1]
        self._max_index = min(self._INSN_TO_SIG, len(func_items) - 1)

        self._insn_addr_cache = {i: func_items[i] for i in range(self._max_index)}
        self._sig_cache = {}

    def __getitem__(self, count: int) -> str:
        """
        Get a signature N instructions long
        :param count: Count of instructions
        :return: A signature
        """
        if count <= 0:
            raise IndexError('Requested sig size is less than or equal to 0')
        if count > self._max_index:
            raise IndexError('Requested sig size is greater than the max allowable')

        chunks = []
        # Check the cache and fill
        for i in range(count):
            chunk = self._sig_cache.get(i, SENTINEL)
            if chunk == SENTINEL:
                addr = self._insn_addr_cache[i]
                chunk = self._sig_cache[i] = self._sig_instruction(addr)
            chunks.append(chunk)

        return ' '.join(chunks)

    def __iter__(self) -> Iterator[str]:
        for i in range(self.max_count):
            yield self[i + 1]

    @property
    def max_count(self) -> int:
        return self._max_index

    def __str__(self):
        return f'<SigGen: {self._base_addr:X}>'

    def __repr__(self):
        return self.__str__()

    def __eq__(self, other):
        return isinstance(other, SigGen) and self._base_addr == other._base_addr

    def _sig_instruction(self, addr: int) -> Optional[str]:
        """
        Get the bytes for a single instruction with wildcards
        :param addr: Instruction address
        :return: A signature chunk
        """
        # I'm not sure if either of these checks will ever happen
        # So let it explode until it does by trying to join None
        if not idaapi.is_code(idaapi.get_flags(addr)):
            return None

        if not idaapi.can_decode(addr):
            return None

        insn = idaapi.insn_t()
        insn.size = 0

        idaapi.decode_insn(insn, addr)
        if insn.size == 0:
            return None

        if insn.size < 5:
            return self._sig_bytes(insn.ea, insn.size)

        op_size = self._get_current_opcode_size(insn)
        if op_size == 0:
            return self._sig_bytes(insn.ea, insn.size)

        operand_size = insn.size - op_size
        sig = self._sig_bytes(insn.ea, op_size)

        if self._match_operands(insn.ea):
            sig += ' ' + self._sig_bytes(insn.ea + op_size, operand_size)
        else:
            sig += ' ' + self._sig_wildcards(operand_size)

        return sig

    def _sig_wildcards(self, count: int) -> str:
        """
        Get a count of wildcard bytes
        :param count: Number of wildcard entries to generate
        :return: A signature
        """
        return ' '.join('??' for _ in range(count))

    def _sig_bytes(self, addr: int, count: int) -> str:
        """
        Get the bytes for a single instruction without wildcards
        :param addr: Byte start address
        :param count: Number of bytes to get
        :return: A signature
        """
        return ' '.join(f'{b:02X}' for b in idaapi.get_bytes(addr, count))

    def _get_current_opcode_size(self, insn: idaapi.insn_t) -> int:
        """
        Get the size of the opcode associated with an instruction
        :param insn: Instruction
        :return: size
        """
        for i in range(idaapi.UA_MAXOP):
            if insn.ops[i].type == idaapi.o_void:
                return 0

            if insn.ops[i].offb != 0:
                return insn.ops[i].offb

        return 0

    def _match_operands(self, ea) -> bool:
        if idaapi.get_first_dref_from(ea) != idaapi.BADADDR:
            return False
        elif idaapi.get_first_cref_from(ea) != idaapi.BADADDR:
            return False
        else:
            return True


class FfxivSigmaker:
    DATASTORE: ClientStructsData
    GENERATED_DATASTORE: GeneratedData
    STANDARD_IMAGE_BASE = 0x1_4000_0000

    # The ".text" segment, only look for xrefs within this range
    TEXT_SEGMENT: ida_segment.segment_t = ida_segment.get_segm_by_name(".text")

    # Max number of XREFs to search through for each address
    XREFS_TO_SEARCH = 10

    # Sigs that are not unique, cache having to search short sigs multiple times
    _NOT_UNIQUE_SIGNATURES: Set[str] = set()

    def __init__(self):
        data_path = os.path.join(os.path.dirname(os.path.realpath(__file__)), "data.yml")
        with Path(data_path).open('r') as fd:
            data_dict = yaml.load(fd)
            self.DATASTORE = dacite.from_dict(ClientStructsData, data_dict)

        self._rebase_datastore()

        generated_data_path = os.path.join(os.path.dirname(os.path.realpath(__file__)), "generated_data.yml")
        with Path(generated_data_path).open('r') as fd:
            data_dict = yaml.load(fd)
            self.GENERATED_DATASTORE = data_dict #dacite.from_dict(GeneratedData, data_dict)

    def run(self) -> None:
        """
        Run the sigmaker
        :return: None
        """
        Log.debug('generating global sigs')
        total_globals = len(self.DATASTORE.globals)
        for (i, (global_ea, global_name)) in enumerate(self.DATASTORE.globals.items()):
            status = f'{i}/{total_globals} ({i / total_globals:0.2%})'

            if global_name in self.GENERATED_DATASTORE.global_sigs:
                existing_sig = self.GENERATED_DATASTORE.global_sigs[global_name]
                if existing_sig != "None":
                    Log.debug(f'{status} // {global_name} // {global_ea:X} // has existing sig: {existing_sig}')
                else:
                    Log.debug(f'{status} // {global_name} // {global_ea:X} // failed sig generation on previous run')
                continue

            sig = self._sig_address(int(global_ea), False)
            Log.debug(f'{status} // {global_name} // {global_ea:X} // {sig}')
            if sig:
                self.GENERATED_DATASTORE.global_sigs[global_name] = sig
            else:
                self.GENERATED_DATASTORE.global_sigs[global_name] = "None"

        Log.debug('generating class sigs')
        class_data: GameClass
        total = len(self.DATASTORE.classes)
        for (i, (class_name, class_data)) in enumerate(self.DATASTORE.classes.items()):
            # skip stubs
            if not class_data:
                continue

            status = f'{i}/{total} ({i / total:0.2%})'

            for (func_ea, func_name) in class_data.funcs.items():
                existing_sig = self.GENERATED_DATASTORE.get_function_signature(class_name, func_name)
                if existing_sig is not None:
                    if existing_sig == "None":
                        Log.debug(f'{status} // {class_name}::{func_name} // {func_ea:X} // failed sig generation on previous run')
                    else:
                        Log.debug(f'{status} // {class_name}::{func_name} // {func_ea:X} // has existing sig: {existing_sig}')
                    continue
                sig = self._sig_address(int(func_ea), True)
                Log.debug(f'{status} // {class_name}::{func_name} // {func_ea:X} // {sig}')
                if sig:
                    self.GENERATED_DATASTORE.set_function_signature(class_name, func_name, sig)
                else:
                    self.GENERATED_DATASTORE.set_function_signature(class_name, func_name, "None")

            # global_ea = class_data.g_pointer
            # if global_ea:
            #     sig = self._sig_address(global_ea, False)
            #     Log.debug(f'{status} // {class_name}::gPointer // {global_ea:X} // {sig}')
            #     if sig:
            #         class_data.g_pointer_sig = sig
            #
            # global_ea = class_data.g_instance
            # if global_ea:
            #     sig = self._sig_address(global_ea, False)
            #     Log.debug(f'{status} // {class_name}::gInstance // {global_ea:X} // {sig}')
            #     if sig:
            #         class_data.g_instance_sig = sig

        Log.debug(f'{total}/{total} (100.00%)')

    def export(self) -> None:
        """
        Export generated data to json
        :return: None
        """
        data_path = os.path.join(os.path.dirname(os.path.realpath(__file__)), "generated_data.yml")

        with Path(data_path).open('w') as fd:
            yaml.dump(self.GENERATED_DATASTORE, fd)

    # region Rebasing

    def _rebase_datastore(self, undo: bool = False) -> None:
        """
        Rebase all the addresses in the datastore.
        :param undo: Revert a rebasing instead
        :return: None
        """
        current_image_base = idaapi.get_imagebase()
        if self.STANDARD_IMAGE_BASE == current_image_base:
            return

        rebase_offset = current_image_base - self.STANDARD_IMAGE_BASE
        if undo:
            rebase_offset *= -1

        self.__rebase_dict(self.DATASTORE.globals, rebase_offset)
        self.__rebase_dict(self.DATASTORE.functions, rebase_offset)

        class_data: GameClass
        for (class_name, class_data) in self.DATASTORE.classes.items():
            if not class_data:
                continue

            self.__rebase_dict(class_data.funcs, rebase_offset)

            for vtbl in class_data.vtbls:
                vtbl.ea += rebase_offset

            if class_data.g_pointer:
                class_data.g_pointer += rebase_offset

            if class_data.g_instance:
                class_data.g_instance += rebase_offset

    def __rebase_dict(self, mapping: Dict[int, str], rebase_offset: int) -> None:
        """
        Rebase all addresses in a [addr, _] mapping
        :param mapping: Mapping to rebase
        :param rebase_offset: Rebase offset
        :return: None
        """
        for (addr, name) in list(mapping.items()):
            mapping[addr + rebase_offset] = mapping.pop(addr)

    # endregion

    # region Signature creation

    def _sig_address(self, addr: int, is_func: bool) -> Optional[str]:
        """
        Find the best sig available for a given address
        :param addr: Address to sig the xrefs of
        :param is_func: Address is a func start
        :return: A signature, or None
        """
        sigs = self.__get_xref_sigs(addr, is_func)
        sig = self.__find_best_sig(sigs)
        return sig

    def __get_xref_sigs(self, addr: int, is_func: bool) -> Iterator[str]:
        """
        Create a signature from a function address
        XRef sigs are preferred, however if none are available the func itself will be used
        :param addr: Function address
        :param is_func: Indicates that this address is a func, and can be signatured directly
        :return: A series of Dalamud compatible signatures
        """
        xref_addrs = [xref.frm for xref in idautils.XrefsTo(addr)]

        if is_func and not ida_funcs.get_func(addr):
            Log.warn(f'Address at {addr:X} is identified as a func, but is not in IDA, attempting to make a subroutine')
            ida_funcs.add_func(addr)

        # This should prune xrefs in places like .pdata by only keeping xrefs in a function
        xref_addrs = list(filter(ida_funcs.get_func_name, xref_addrs))

        # Grab the first N xrefs
        xref_addrs = xref_addrs[:self.XREFS_TO_SEARCH]

        if is_func:
            # Try to sig the func itself as well
            xref_addrs.insert(0, addr)

        for xref_addr in xref_addrs:
            try:
                sig_gen = SigGen(xref_addr)
                for v in sig_gen:
                    yield v
            except:
                error_details = traceback.format_exc()
                Log.error(f"Encountered an exception running SigGen on address: {xref_addr}!")
                Log.debug(error_details)

    def __find_best_sig(self, sigs: Iterator[str]) -> Optional[str]:
        """
        Find the shortest signature, with only one match in the .TEXT segment.
        :param sigs: Signatures to check
        :return: The shortest signature, or None
        """
        chosen_sig = None
        chosen_sig_size = sys.maxsize

        for sig in sigs:
            # Already have a sig shorter than this one
            if len(sig) >= chosen_sig_size:
                continue

            if sig in self._NOT_UNIQUE_SIGNATURES:
                continue

            if self.__is_sig_unique(sig):
                chosen_sig = sig
                chosen_sig_size = len(sig)
            else:
                self._NOT_UNIQUE_SIGNATURES.add(sig)

        return chosen_sig

    def __is_sig_unique(self, sig: str) -> bool:
        """
        Perform a binary sig search and determine if the signature has one unique match
        :param sig: Sig to search
        :return: True if only one address matches
        """

        # Expects a byte array
        fmt_sig = [int(s, 16).to_bytes(1, 'little') if s != '??' else b'\0' for s in sig.split(' ')]
        fmt_sig = b''.join(fmt_sig)

        # Another byte array, 0 = "??" wildcard
        sig_mask = [int(b != '??').to_bytes(1, 'little') for b in sig.split(' ')]
        sig_mask = b''.join(sig_mask)

        result_count = 0
        sig_addr = self.TEXT_SEGMENT.start_ea  # noqa
        while True:
            sig_addr = idaapi.bin_search(
                sig_addr,
                self.TEXT_SEGMENT.end_ea,  # noqa
                fmt_sig, sig_mask,
                ida_bytes.BIN_SEARCH_FORWARD,
                ida_bytes.BIN_SEARCH_NOCASE)

            # No more results
            if sig_addr == idaapi.BADADDR:
                break

            # We have a match
            result_count += 1

            # But more than one fails the signature
            if result_count > 1:
                return False

            # Starting at the match, returns the same match. So go to the next byte
            sig_addr += 1

        return True

    # endregion


Log.info("Executing sigmaker")
sigmaker = FfxivSigmaker()
sigmaker.run()
sigmaker.export()
Log.info("Done")

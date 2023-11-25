import os
import re
import idaapi
import idc
import ida_nalt
import ida_hexrays

def parse_declaration(func_name):
    """
    Parse a function to extract its arguments.
    Given the function name Tick, valid formats are:
    - No arguments, no return value: Tick
    - Arguments, no return value: Tick(Client::System::Framework::Framework* this)
    - Arguments, return value: Tick(Client::System::Framework::Framework* this) -> byte
    - No arguments, return value: Tick -> byte
    """

    regex = re.compile(
        r"^(?P<func_name>[a-zA-Z0-9_:.]+)(?:\((?P<args>.*)\))?(?:\s*->\s*(?P<ret>.*))?$"
    )
    match = regex.match(func_name)
    if match:
        func_name = match.group("func_name")
        args = match.group("args") or None
        ret = match.group("ret") or None
        return func_name, args, ret
    else:
        return None, None, None


def try_set_func_arg_type(ea, arg_idx, type, ptr=0, name=None):
    setting_type = type != "_" and type is not None

    # Create type info for this function
    tinfo = idaapi.tinfo_t()
    if not ida_nalt.get_tinfo(tinfo, ea):
        print("Unable to get type info for 0x{0:X}, trying to decompile first".format(ea))

        if not ida_hexrays.decompile(ea):
            print("Unable to decompile 0x{0:X}, moving on".format(ea))
            return

        if not ida_nalt.get_tinfo(tinfo, ea):
            print("Unable to get type info for 0x{0:X} with decompile, moving on".format(ea))
            return

    # Get function data from type info
    funcdata = idaapi.func_type_data_t()
    if not tinfo.get_func_details(funcdata):
        print("Unable to get function details for 0x{0:X}".format(ea))
        return

    # Safety checks
    if funcdata.size() <= arg_idx:
        print("Argument index out of bounds for 0x{0:X}".format(ea))
        return

    # Set name if provided
    if name is not None:
        funcdata[arg_idx].name = name

    type_tinfo = idaapi.tinfo_t()
    ptr_tinfo = None
    if setting_type:
        if not type_tinfo.get_named_type(idaapi.get_idati(), type):
            terminated = type + ";"
            if (
                idaapi.parse_decl(
                    type_tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL
                )
                is None
            ):
                print("Unable to parse type '{0}' for 0x{1:X}".format(type, ea))
                return

        # Make it a pointer if specified
        if ptr > 0:
            ptr_tinfo = idaapi.tinfo_t()
            for i in range(ptr):
                if not ptr_tinfo.create_ptr(type_tinfo):
                    print("Unable to create pointer type for 0x{0:X}".format(ea))
                    return
        else:
            ptr_tinfo = type_tinfo

        orig_type = funcdata[arg_idx].type
        if orig_type.get_size() < ptr_tinfo.get_size():
            print(
                "Error: Type size mismatch for {0} at 0x{1:X} (expected {2:X}, got {3:X})".format(
                    name, ea, orig_type.get_size(), ptr_tinfo.get_size()
                )
            )
            return

        funcdata[arg_idx].type = ptr_tinfo

    new_tinfo = idaapi.tinfo_t()
    if not new_tinfo.create_func(funcdata):
        print(
            "Error: Unable to create new function type for {0} at 0x{1:X}".format(
                name, ea
            )
        )
        return

    idaapi.apply_tinfo(ea, new_tinfo, idaapi.TINFO_DEFINITE)


def try_set_func_type(ea, args_type, ret_type):
    # Set argument types
    if args_type is not None:
        args = args_type.split(",")
        for i in range(len(args)):
            arg = args[i].strip()
            if arg is None:
                continue

            last_space = arg.rfind(" ")
            arg_type = arg[:last_space]
            arg_name = arg[last_space + 1 :]
            ptr = arg_type.count("*")
            arg_type = arg_type.rstrip("*")

            try_set_func_arg_type(ea, i, arg_type, ptr, arg_name)

    # Attempt to set return type
    if ret_type is not None:
        tinfo = idaapi.tinfo_t()
        if not tinfo.get_named_type(idaapi.get_idati(), ret_type):
            terminated = ret_type + ";"
            if (
                idaapi.parse_decl(tinfo, idaapi.get_idati(), terminated, idaapi.PT_SIL)
                is None
            ):
                print("Unable to parse return type for 0x{0:X}".format(ea))
                return

        # Get the data from the original function to replace
        func_tinfo = idaapi.tinfo_t()
        funcdata = idaapi.func_type_data_t()

        if not ida_nalt.get_tinfo(func_tinfo, ea):
            print("Unable to get type info for 0x{0:X}".format(ea))
            return

        if not func_tinfo.get_func_details(funcdata):
            print("Unable to get function details for 0x{0:X}".format(ea))
            return

        if funcdata.rettype.get_size() < tinfo.get_size():
            print(
                "Error: Return type size mismatch for 0x{0:X} (expected {1:X}, got {2:X})".format(
                    ea, funcdata.rettype.get_size(), tinfo.get_size()
                )
            )
            return

        # Create a new type info with our applied type
        funcdata.rettype = tinfo
        new_tinfo = idaapi.tinfo_t()
        if not new_tinfo.create_func(funcdata):
            print("Error: Unable to create new function type for 0x{0:X}".format(ea))
            return

        idaapi.apply_tinfo(ea, new_tinfo, idaapi.TINFO_DEFINITE)


typedecl_path = os.path.join(
    os.path.dirname(os.path.realpath(__file__)), "typedecl.txt"
)
typedecl = open(typedecl_path, "r").read()
typedecl = typedecl.strip().split("\n")

for decl in typedecl:
    comment_idx = decl.find("#")
    if comment_idx != -1:
        decl = decl[:comment_idx]

    decl = decl.strip()
    if decl == "":
        continue

    func_name, args, ret = parse_declaration(decl)
    if func_name is None:
        print("Failed to parse declaration: {}".format(decl))
        continue

    func = idaapi.get_name_ea(0, func_name)
    if func == idaapi.BADADDR:
        print("Function {} not found".format(func_name))
        continue

    try_set_func_type(func, args, ret)

print("Done.")

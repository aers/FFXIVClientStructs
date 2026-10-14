# Names the globals, functions, vtables and such of data.yml
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_rename
# @runtime PyGhidra

from os.path import join, dirname
import sys

try:
    script_dir = dirname(__file__)
except NameError:
    script_dir = dirname(str(sourceFile))  # noqa

for import_path in (script_dir, join(script_dir, "..", "shared")):
    if import_path not in sys.path:
        sys.path.append(import_path)

from ghidra_wrapper import GhidraInterface
from class_factory import apply_data

lua_namespace = "Client::Game::Event::Lua"

def apply_lua_funcs():
    """Relies on the Common::Lua::LuaState names from data.yml, so apply_data has to run first."""
    string_eas = ghidra.get_func_xrefs(ghidra.get_func_ea_by_name('Common::Lua::LuaState.SetStringField'))
    func_eas = ghidra.get_func_xrefs(ghidra.get_func_ea_by_name('Common::Lua::LuaState.SetFunctionField'))

    string_eas = [ghidra.get_func_start(x) for x in string_eas]

    eas = {}
    for x in func_eas:
        regs = ghidra.get_registers(ghidra.heads_before(x, 4))
        regs['r8'] = ghidra.get_string_from_ptr(regs['r8']['val'])
        eas.setdefault(ghidra.get_func_start(x), {'calls': []})['calls'].append({'off': x, 'regs': regs})

    eas = {k: v for k,v in eas.items() if k in string_eas}

    for func_ea in eas:
        eas[func_ea]['regs'] = ghidra.get_registers(ghidra.heads_until_call(func_ea, 'Common::Lua::LuaState.SetStringField'), ('mov',))

    for func_ea in eas:
        eas[func_ea]['name'] = eas[func_ea]['regs'][eas[func_ea]['regs']['r9']['val_text']]['val_text']
        eas[func_ea]['name_val'] = eas[func_ea]['regs'][eas[func_ea]['regs']['r9']['val_text']]['val']

    for func_ea in eas:
        if eas[func_ea]['name'] == 'r8':
            eas[func_ea]['name'] = ghidra.get_func_name(func_ea).split('.')[0].split(':')[-1]
            eas[func_ea]['name_val'] = func_ea
        if eas[func_ea]['name'] == 'rax':
            eas[func_ea]['name_val'] = ghidra.get_func_xrefs(func_ea)[0]
            eas[func_ea]['name'] = ghidra.get_func_name(eas[func_ea]['name_val']).split('.')[0].split(':')[-1]

    for func_ea in eas:
        name = f"{lua_namespace}::{eas[func_ea]['name']}"
        ghidra.set_func_name(func_ea, f"{name}.SetupLuaClass")
        for call in eas[func_ea]['calls']:
            regs = call['regs']
            func_name = regs['r8']
            ghidra.set_func_name(regs['r9']['val'], f"{name}.{func_name}", unique=True)

ghidra = GhidraInterface(currentProgram, monitor)  # noqa
print("Loading data.yml")
ghidra.load_data_yml()

print("Executing")
apply_data(ghidra, ghidra.data_yaml)
print("Naming lua functions")
apply_lua_funcs()
print("Done")

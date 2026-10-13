from os.path import join, dirname
import sys

for path in (dirname(__file__), join(dirname(__file__), "..")):
    if path not in sys.path:
        sys.path.append(path)

from ida_wrapper import IdaInterface
from class_factory import apply_data

lua_namespace = "Client::Game::Event::Lua"

def apply_lua_funcs():
    """Relies on the Common::Lua::LuaState names from data.yml, so apply_data has to run first."""
    string_eas = ida.get_func_xrefs(ida.get_func_ea_by_name('Common::Lua::LuaState.SetStringField'))
    func_eas = ida.get_func_xrefs(ida.get_func_ea_by_name('Common::Lua::LuaState.SetFunctionField'))

    string_eas = [ida.get_func_start(x) for x in string_eas]

    eas = {}
    for x in func_eas:
        regs = ida.get_registers(ida.heads_before(x, 4))
        regs['r8'] = ida.get_string_from_ptr(regs['r8']['val'])
        eas.setdefault(ida.get_func_start(x), {'calls': []})['calls'].append({'off': x, 'regs': regs})

    eas = {k: v for k,v in eas.items() if k in string_eas}

    for func_ea in eas:
        eas[func_ea]['regs'] = ida.get_registers(ida.heads_until_call(func_ea, 'Common::Lua::LuaState.SetStringField'), ('mov',))

    for func_ea in eas:
        eas[func_ea]['name'] = eas[func_ea]['regs'][eas[func_ea]['regs']['r9']['val_text']]['val_text']
        eas[func_ea]['name_val'] = eas[func_ea]['regs'][eas[func_ea]['regs']['r9']['val_text']]['val']

    for func_ea in eas:
        if eas[func_ea]['name'] == 'r8':
            eas[func_ea]['name'] = ida.get_func_name(func_ea).split('.')[0].split(':')[-1]
            eas[func_ea]['name_val'] = func_ea
        if eas[func_ea]['name'] == 'rax':
            eas[func_ea]['name_val'] = ida.get_func_xrefs(func_ea)[0]
            eas[func_ea]['name'] = ida.get_func_name(eas[func_ea]['name_val']).split('.')[0].split(':')[-1]

    for func_ea in eas:
        name = f"{lua_namespace}::{eas[func_ea]['name']}"
        ida.set_func_name(func_ea, f"{name}.SetupLuaClass")
        for call in eas[func_ea]['calls']:
            regs = call['regs']
            func_name = regs['r8']
            ida.set_func_name(regs['r9']['val'], f"{name}.{func_name}", unique=True)

ida = IdaInterface()
ida.select_parser()
print("Loading data.yml")
ida.load_data_yml()

print("Executing")
apply_data(ida, ida.data_yaml)
print("Naming lua functions")
apply_lua_funcs()
print("Done")

import idc
import ida_name
import ida_funcs

namespace = "Client::Game::Event::Lua"

def get_string_from_ptr(ea):
    val = idc.get_strlit_contents(ea)
    if val == None:
        val = idc.get_strlit_contents(idc.get_qword(ea))
    return val.decode('utf-8')

def get_asm_string(ea):
    ins = idc.print_insn_mnem(ea)
    
    op = idc.print_operand(ea, 0)
    if ins == 'push' or ins == 'call' or ins == 'jz':
        val = idc.get_operand_value(ea, 0)
        return {'ins': ins, 'op': op, 'val': val}
    
    val_text = idc.print_operand(ea, 1)
    val = idc.get_operand_value(ea, 1)
    if val_text.startswith('cs:'):
        val_text = get_string_from_ptr(val)
    return {'ins': ins, 'reg': op, 'val_text': val_text, 'val': val}

def get_registers(ea):
    regs = {}
    loop = True
    while loop:
        asm = get_asm_string(ea)
        if asm['ins'] == 'call' and asm['op'] == 'Common::Lua::LuaState.SetStringField':
            loop = False
            break
        if asm['ins'] == 'mov':
            regs[asm['reg']] = {'val_text': asm['val_text'], 'val': asm['val']}
        ea = idc.next_head(ea)
    return regs

def get_func_registers(ea, reg_count):
    regs = {}
    while reg_count > 0:
        ea = idc.prev_head(ea)
        asm = get_asm_string(ea)
        regs[asm['reg']] = {'val_text': asm['val_text'], 'val': asm['val']}
        reg_count = reg_count - 1
    return regs

def get_func_xrefs(ea):
    eas = []
    xref = idc.get_first_cref_to(ea)
    while xref != idc.BADADDR:
        if idc.print_insn_mnem(xref).lower() == "call":
            eas.append(xref)
        xref = idc.get_next_cref_to(ea, xref)
    return eas
    
def set_func_name(ea, name, count: None | int = None):
    act_name = name
    if count != None:
        act_name = f"{name}{count}"

    cur_name = idc.get_func_name(ea)
    if cur_name.startswith('sub_'):
        print(act_name)
        found_ea = ida_name.get_name_ea(0, act_name)
        if found_ea == idc.BADADDR or found_ea == ea:
            idc.set_name(ea, act_name)
        else:
            set_func_name(ea, name, 2 if count is None else count + 1)

def run():
    string_eas = get_func_xrefs(ida_name.get_name_ea(0, 'Common::Lua::LuaState.SetStringField'))
    func_eas = get_func_xrefs(ida_name.get_name_ea(0, 'Common::Lua::LuaState.SetFunctionField'))

    string_eas = [ida_funcs.get_func(x).start_ea for x in string_eas]
    
    eas = {}
    for x in func_eas:
        regs = get_func_registers(x, 4)
        regs['r8'] = get_string_from_ptr(regs['r8']['val'])
        eas.setdefault(ida_funcs.get_func(x).start_ea, {'calls': []})['calls'].append({'off': x, 'regs': regs})
    
    eas = {k: v for k,v in eas.items() if k in string_eas}

    for func_ea in eas:
        eas[func_ea]['regs'] = get_registers(func_ea)

    for func_ea in eas:
        eas[func_ea]['name'] = eas[func_ea]['regs'][eas[func_ea]['regs']['r9']['val_text']]['val_text']
        eas[func_ea]['name_val'] = eas[func_ea]['regs'][eas[func_ea]['regs']['r9']['val_text']]['val']

    for func_ea in eas:
        if eas[func_ea]['name'] == 'r8':
            eas[func_ea]['name'] = idc.get_func_name(func_ea).split('.')[0].split(':')[-1]
            eas[func_ea]['name_val'] = func_ea
        if eas[func_ea]['name'] == 'rax':
            eas[func_ea]['name_val'] = get_func_xrefs(func_ea)[0]
            eas[func_ea]['name'] = idc.get_func_name(eas[func_ea]['name_val']).split('.')[0].split(':')[-1]

    for func_ea in eas:
        name = f"{namespace}::{eas[func_ea]['name']}"
        idc.set_name(func_ea, f"{name}.SetupLuaClass")
        for call in eas[func_ea]['calls']:
            regs = call['regs']
            func_name = regs['r8']
            set_func_name(regs['r9']['val'], f"{name}.{func_name}")

run()
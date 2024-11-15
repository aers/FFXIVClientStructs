# run this from ida on *old* idb (with data.yml imported) to generate xrefs for globals that can then be used for diffing
# data.yml is expected to correspond to *old* idb
import ida_bytes
import ida_kernwin
import ida_name
import ida_funcs
import ida_segment
import ida_xref
import idaapi
import json

def enumerate_data_segments():
    for i in range(ida_segment.get_segm_qty()):
        seg = ida_segment.getnseg(i)
        name = ida_segment.get_segm_name(seg)
        if name == '.data' or name == '.rdata':
            yield seg.start_ea, seg.end_ea, name

def enumerate_globals(start_ea, end_ea):
    start_ea = ida_bytes.next_head(start_ea, end_ea)
    while start_ea != idaapi.BADADDR:
        if ida_bytes.has_any_name(ida_bytes.get_flags(start_ea)):
            yield start_ea, ida_name.get_ea_name(start_ea)
        start_ea = ida_bytes.next_head(start_ea, end_ea)

def enumerate_xrefs_to(ea):
    addr = ida_xref.get_first_dref_to(ea)
    while addr != idaapi.BADADDR:
        func = ida_funcs.get_func(addr)
        if func:
            yield func.start_ea
        addr = ida_xref.get_next_dref_to(ea, addr)

def ea_has_data_offset(ea):
    flags = ida_bytes.get_full_flags(ea)
    return (flags & ida_bytes.FF_DATA) != 0 and ida_bytes.is_off0(flags)

def enumerate_func_table(ea, required_prefix):
    res = []
    while ea_has_data_offset(ea):
        func = ida_bytes.get_qword(ea)
        if not required_prefix or ida_name.get_ea_name(func).startswith(required_prefix):
            res.append(func)
        ea += 8
    return res

file = ida_kernwin.ask_file(True, 'globals.json', 'json')
if file:
    result = {}
    for segstart, segend, segname in enumerate_data_segments():
        for ea, name in enumerate_globals(segstart, segend):
            entry = {}
            entry['name'] = name
            entry['xrefs'] = list(set(enumerate_xrefs_to(ea)))
            entry['functable'] = enumerate_func_table(ea, name[5:] if name[:5] == 'vtbl_' else None)
            result[ea] = entry
    with open(file, 'w') as fd:
        fd.write(json.dumps(result, indent='\t'))

# takes two files, dump and offsets (optional), and tries to generate a data.mapped.yml that resembles
# the structure of data.yml for easy copy and paste.
#
# dump is a newline separated file of `name address`
# offsets is a newline separated file of `old new`. if not passed in, no remapping will occur.

import sys
import yaml

assert len(sys.argv) >= 2
dump_filename = sys.argv[1]

offsets_kv = {}
if len(sys.argv) >= 3:
    with open(sys.argv[2]) as file:
        for line in file:
            [from_addr, to_addr] = line.rstrip().split()
            offsets_kv[from_addr] = to_addr

mapped = []
unmapped = []
with open(dump_filename) as file:
    for line in file:
        [name, original_offset] = line.rstrip().split()
        if original_offset in offsets_kv:
            new_offset = offsets_kv[original_offset]
            mapped.append([name, new_offset])
        else:
            unmapped.append([name, original_offset])

def build_yaml_structures(items):
    globals_ = {}
    functions = {}
    classes = {}

    for [name, offset] in items:
        offset_int = int(offset, 16)
        if name.startswith("g_"):
            globals_[offset_int] = name
        elif '::' in name:
            colon_index = name.rfind('::')
            class_name = name[:colon_index]
            function_name = name[colon_index+2:]

            if class_name not in classes:
                classes[class_name] = {'funcs': {}}

            classes[class_name]['funcs'][offset_int] = function_name
        else:
            functions[offset_int] = name

    return {
        "globals": globals_,
        "functions": functions,
        "classes": classes,
    }

def hexint_presenter(dumper, data):
    return dumper.represent_int("0x{:X}".format(data))
yaml.add_representer(int, hexint_presenter)

print(
    yaml.dump(
        {
            "mapped": build_yaml_structures(mapped),
            "unmapped": build_yaml_structures(unmapped),
        }
    ),
    file=open("data.mapped.yml", "w")
)

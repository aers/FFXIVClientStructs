from os.path import join, dirname
import sys

sys.path.append(join(dirname(__file__), "..", "shared"))

from ida_wrapper import IdaInterface
from structs_schema import get_yaml

ida = IdaInterface()
print("Loading data.yml")
ida.load_data_yml()

print("Parsing ffxiv_structs.yml")
with open(ida.get_struct_path()) as f:
    structs = {struct.type: struct for struct in get_yaml(f).structs}

# data.yml addresses are relative to the standard image base
rebase_offset = ida.get_image_base() - 0x140000000

for class_name, class_data in ida.data_yaml.classes.items():
    struct = structs.get(class_name)
    if struct is None or struct.static_members is None:
        continue
    for static_member in struct.static_members:
        ea = ida.get_static_member_ea(static_member)
        instance = next((inst for inst in class_data.instances if inst.ea + rebase_offset == ea), None)
        if instance is not None and static_member.is_pointer != instance.pointer:
            print(f"Found pointer discrepancy at {ea:X} on {class_name}")

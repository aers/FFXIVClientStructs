from time import time

current_time = time()

from structs_schema import get_yaml
from src_wrapper import SrcInterface
from exdschema_wrapper import get_exdschema_data, create_struct_from_header_and_schema
from lumina_wrapper import get_excel_header_files
from io import open

src = SrcInterface()

with open("ffxiv_structs.yml") as f:
    struct_export = get_yaml(f)

# for struct in struct_export.structs:
#     for virtual_function in struct.virtual_functions:
#         not_gui = not struct.namespace.endswith("GUI")
#         not_agent = not struct.namespace.endswith("Agent")
#         not_gui_or_agent = not_gui or not_agent
#         not_receive_event = virtual_function.name != "ReceiveEvent"
#         not_gui_or_agent_and_receive_event = not_gui_or_agent and not_receive_event
#         not_dtor = virtual_function.name != "dtor"
#         not_dtor_and_gui_or_agent_and_receive_event = not_dtor and not_gui_or_agent_and_receive_event
#         not_offset = not virtual_function.offset
#         if not_offset and not_dtor_and_gui_or_agent_and_receive_event:
#             print(f"{struct.namespace}.{struct.name}_vtbl.{virtual_function.name}", not_offset, not_dtor_and_gui_or_agent_and_receive_event, not_dtor, not_gui_or_agent_and_receive_event, not_receive_event, not_gui_or_agent, not_agent, not_gui)

header, vtables = src.build_export_string(struct_export)

excel_header_files = get_excel_header_files()
exdschema = get_exdschema_data("latest")

struct_export_excel, excel_map = create_struct_from_header_and_schema(
    excel_header_files, exdschema
)

header_excel, vtables_excel = src.build_export_string(struct_export_excel, 4)

with open("test.h", "w") as f:
     f.write(src.get_predef_header())
     f.write("\n")
     f.write(header_excel)
     f.write("\n")
     f.write(header)

running_time = time() - current_time
print(f"execution took {running_time}s")
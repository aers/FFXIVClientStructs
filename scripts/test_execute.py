from time import time

current_time = time()

from structs_schema import get_yaml
from src_wrapper import SrcInterface
from exdschema_wrapper import get_exdschema_data, create_struct_from_header_and_schema
from lumina_wrapper import get_excel_header_files
from io import open

predef_header = """#define _HAS_ITERATOR_DEBUGGING 0
#define _ITERATOR_DEBUG_LEVEL 0
#include <vector>
#include <set>
#include <map>
#include <string>
#include <list>
#include <deque>
#include <cstdint>

"""

src = SrcInterface()

with open("ffxiv_structs.yml") as f:
    struct_export = get_yaml(f)

header, vtables = src.build_export_string(struct_export)

excel_header_files = get_excel_header_files()
exdschema = get_exdschema_data("latest")

struct_export_excel, excel_map = create_struct_from_header_and_schema(
    excel_header_files, exdschema
)

header_excel, vtables_excel = src.build_export_string(struct_export_excel, 4)

with open("test.h", "w") as f:
    f.write(predef_header)
    f.write(header_excel)
    f.write(header)

running_time = time() - current_time
print(f"execution took {running_time}s")
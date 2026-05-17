from time import time

current_time = time()

from structs_schema import get_yaml
from src_wrapper import SrcInterface
from io import open

predef_header = """
#define _HAS_ITERATOR_DEBUGGING 0
#define _ITERATOR_DEBUG_LEVEL 0
#include <vector>
#include <set>
#include <map>
#include <string>
#include <list>
#include <deque>
#include <cstdint>

#define DTOR(type) type *(__fastcall *Dtor)(type *__hidden self, uint8_t freeFlags);
"""

src = SrcInterface()

with open("ffxiv_structs.yml") as f:
    struct_export = get_yaml(f)

header, vtables = src.build_export_string(struct_export)

with open("test.h", "w") as f:
    f.write(header)

running_time = time() - current_time
print(f"execution took {running_time}s")
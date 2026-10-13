from os import path
import idautils
import ida_auto
import idc

working_directory = path.dirname(path.realpath(__file__))

print("Loading rename.py")
exec(open(path.join(working_directory, "rename.py")).read())

print("Loading struct_import.py")
exec(open(path.join(working_directory, "struct_import.py")).read())

for s in idautils.Segments():
    start = idc.get_segm_start(s)
    end = idc.get_segm_end(s)
    ida_auto.plan_range(start, end)
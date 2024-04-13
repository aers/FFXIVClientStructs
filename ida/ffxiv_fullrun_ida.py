from os import path
import idautils
import ida_auto
import idc

exec(open(path.join(path.dirname(path.realpath(__file__)), "ffxiv_idarename.py")).read())
exec(open(path.join(path.dirname(path.realpath(__file__)), "ffxiv_exdgetters.py")).read())
exec(open(path.join(path.dirname(path.realpath(__file__)), "ffxiv_structimporter.py")).read())

for s in idautils.Segments():
    start = idc.get_segm_start(s)
    end = idc.get_segm_end(s)
    ida_auto.plan_range(start, end)
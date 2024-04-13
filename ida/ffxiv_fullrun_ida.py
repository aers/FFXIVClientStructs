from ffxiv_idarename import load_data as ffxiv_idarename
from ffxiv_structimporter import run as ffxiv_structimporter
from ffxiv_exdgetters import run as ffxiv_exdgetters
import idautils
import ida_auto
import idc

ffxiv_idarename()
ffxiv_exdgetters()
ffxiv_structimporter()

for s in idautils.Segments():
    start = idc.get_segm_start(s)
    end = idc.get_segm_end(s)
    ida_auto.plan_range(start, end)
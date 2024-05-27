using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("MJIMinionNoteBook")]
[StructLayout(LayoutKind.Explicit, Size = 0x630)]
public struct AddonMJIMinionNoteBook {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2A0)] public TabController TabController;
}

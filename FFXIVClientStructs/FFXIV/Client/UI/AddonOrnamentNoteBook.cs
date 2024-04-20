using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x540)]
public struct AddonOrnamentNoteBook {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x290)] public TabController TabController;
}

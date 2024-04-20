using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("LovmPaletteEdit")]
[StructLayout(LayoutKind.Explicit, Size = 0xA10)]
public struct AddonLovmPaletteEdit {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x840)] public TabController TabController;
}

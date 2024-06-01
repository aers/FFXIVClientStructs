using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("LovmPaletteEdit")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA10)]
public partial struct AddonLovmPaletteEdit {
    [FieldOffset(0x840)] public TabController TabController;
}

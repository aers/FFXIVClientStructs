using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GSInfoEditDeck")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xD80)]
public partial struct AddonGSInfoEditDeck {
    [FieldOffset(0x220)] public TabController TabController;
}

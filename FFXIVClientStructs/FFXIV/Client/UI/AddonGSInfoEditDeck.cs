using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("GSInfoEditDeck")]
[StructLayout(LayoutKind.Explicit, Size = 0xD80)]
public struct AddonGSInfoEditDeck {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public TabController TabController;
}

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("AdventureNoteBook")]
[StructLayout(LayoutKind.Explicit, Size = 0x630)]
public unsafe partial struct AddonAdventureNoteBook {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x570)] public TabController TabController;
}

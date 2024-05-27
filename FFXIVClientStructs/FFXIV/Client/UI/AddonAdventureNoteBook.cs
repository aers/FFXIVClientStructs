using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("AdventureNoteBook")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x630)]
public unsafe partial struct AddonAdventureNoteBook {
    [FieldOffset(0x570)] public TabController TabController;
}

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x540)]
public partial struct AddonOrnamentNoteBook {
    [FieldOffset(0x290)] public TabController TabController;
}

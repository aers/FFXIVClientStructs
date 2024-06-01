using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("MJIMinionNoteBook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x630)]
public partial struct AddonMJIMinionNoteBook {
    [FieldOffset(0x2A0)] public TabController TabController;
}

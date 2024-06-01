using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("Inventory")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public partial struct AddonInventory {
    [FieldOffset(0x2A8)] public AtkAddonControl AddonControl;

    [FieldOffset(0x31C)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 83 FD 11")]
    public partial void SetTab(int tab);
}

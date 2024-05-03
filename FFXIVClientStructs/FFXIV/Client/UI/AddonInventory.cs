using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("Inventory")]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public partial struct AddonInventory {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x31C)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 83 FD 11")]
    public partial void SetTab(int tab);
}

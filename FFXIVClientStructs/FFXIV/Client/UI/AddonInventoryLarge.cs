using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryLarge")]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public partial struct AddonInventoryLarge {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x320)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 41 83 FF 47")]
    public partial void SetTab(int tab);
}

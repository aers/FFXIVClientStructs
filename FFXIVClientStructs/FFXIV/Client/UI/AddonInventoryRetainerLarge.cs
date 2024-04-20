using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryRetainerLarge")]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public partial struct AddonInventoryRetainerLarge {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2F0)] public int TabIndex;

    [MemberFunction("E9 ?? ?? ?? ?? 33 D2 E8 ?? ?? ?? ?? 48 83 C4 48")]
    public partial void SetTab(int tab);
}

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryExpansion")]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public partial struct AddonInventoryExpansion {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x328)] public int TabIndex;

    [MemberFunction("E8 ?? ?? ?? ?? BB ?? ?? ?? ?? 83 EB 01")]
    public partial void SetTab(int tab, bool force);
}

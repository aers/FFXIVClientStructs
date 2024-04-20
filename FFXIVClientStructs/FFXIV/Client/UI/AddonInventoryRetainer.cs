using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("InventoryRetainer")]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public partial struct AddonInventoryRetainer {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x2E8)] public int TabIndex;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 70 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 8B F1 48 8B 89")]
    public partial void SetTab(int tab);
}

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("ArmouryBoard")]
[StructLayout(LayoutKind.Explicit, Size = 0x6C0)]
public partial struct AddonArmouryBoard {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x690)] public int TabIndex;

    [MemberFunction("E8 ?? ?? ?? ?? EB E0 84 C9")]
    public partial void NextTab(byte a2);

    [MemberFunction("40 53 48 83 EC 20 80 B9 ?? ?? ?? ?? ?? 48 8B D9 75 11")]
    public partial void PreviousTab(byte a2);
}

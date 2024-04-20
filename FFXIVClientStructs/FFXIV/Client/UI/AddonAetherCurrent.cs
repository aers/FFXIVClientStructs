using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("AetherCurrent")]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonAetherCurrent {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FixedSizeArray<Pointer<AtkComponentRadioButton>>(4)]
    [FieldOffset(0x228)] public fixed byte TabPointers[0x08 * 4];

    [FieldOffset(0x254)] public int TabIndex;
    [FieldOffset(0x258)] public int TabCount;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 65 39 9D")]
    public partial void SetTab(int tab);
}

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("Buddy")]
[StructLayout(LayoutKind.Explicit, Size = 0x1C00)]
public unsafe partial struct AddonBuddy {
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public int TabIndex;

    [FixedSizeArray<Pointer<AtkComponentRadioButton>>(3)]
    [FieldOffset(0x1BD8)] public fixed byte RadioButtons[8 * 3];

    [MemberFunction("E8 ?? ?? ?? ?? 3B AF ?? ?? ?? ?? 74 27")]
    public partial void SetTab(int tab);
}

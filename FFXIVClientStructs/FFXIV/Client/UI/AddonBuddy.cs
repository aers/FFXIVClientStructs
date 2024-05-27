using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("Buddy")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C00)]
public unsafe partial struct AddonBuddy {
    [FieldOffset(0x220)] public int TabIndex;

    [FieldOffset(0x228)] public AtkAddonControl AddonControl;

    [FieldOffset(0x1BD8), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _radioButtons;

    [MemberFunction("E8 ?? ?? ?? ?? 3B AF ?? ?? ?? ?? 74 27")]
    public partial void SetTab(int tab);
}

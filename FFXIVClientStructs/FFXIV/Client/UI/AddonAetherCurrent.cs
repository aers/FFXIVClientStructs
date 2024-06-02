using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAetherCurrent
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("AetherCurrent")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonAetherCurrent {
    [FieldOffset(0x228), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentRadioButton>> _tabPointers;

    [FieldOffset(0x254)] public int TabIndex;
    [FieldOffset(0x258)] public int TabCount;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 65 39 9D")]
    public partial void SetTab(int tab);
}

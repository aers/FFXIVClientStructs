using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonBuddy
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Buddy")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1E80)]
public unsafe partial struct AddonBuddy {
    [FieldOffset(0x230)] public int TabIndex;

    [FieldOffset(0x238)] public AtkAddonControl AddonControl;

    [FieldOffset(0x1BE8), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _radioButtons;

    [MemberFunction("E8 ?? ?? ?? ?? 3B AF ?? ?? ?? ?? 74 27")]
    public partial void SetTab(int tab);
}

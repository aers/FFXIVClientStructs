using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAetherCurrent
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("AetherCurrent")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x280)]
public unsafe partial struct AddonAetherCurrent {
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentRadioButton>> _tabs;

    [FieldOffset(0x274)] public int TabIndex;
    [FieldOffset(0x278)] public int TabCount;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 64 8B 85 ?? ?? ?? ??")]
    public partial void SetTab(int tab);
}

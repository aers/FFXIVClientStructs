using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCurrency
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Currency")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public unsafe partial struct AddonCurrency {
    [FieldOffset(0x2B0), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentRadioButton>> _tabs;
}

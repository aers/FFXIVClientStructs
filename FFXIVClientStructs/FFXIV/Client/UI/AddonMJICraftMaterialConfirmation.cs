using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMJICraftMaterialConfirmation
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MJICraftMaterialConfirmation")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x270)]
public unsafe partial struct AddonMJICraftMaterialConfirmation {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _radioButtons;
}

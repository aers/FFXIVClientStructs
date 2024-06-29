using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGrandCompanySupplyReward
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GrandCompanySupplyReward")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe partial struct AddonGrandCompanySupplyReward {
    [FieldOffset(0x230)] public AtkComponentButton* DeliverButton;
    [FieldOffset(0x238)] public AtkComponentButton* CancelButton;
}

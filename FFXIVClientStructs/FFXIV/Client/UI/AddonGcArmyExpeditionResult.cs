using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGcArmyExpeditionResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GcArmyExpeditionReport")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x238)]
public unsafe partial struct AddonGcArmyExpeditionResult {
    [FieldOffset(0x230)] public AtkComponentButton* CompleteButton;
}

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGearSetList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GearSetList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3A90)]
public partial struct AddonGearSetList {
    [FieldOffset(0x3A8D)] public bool ShouldResetPosition;
}

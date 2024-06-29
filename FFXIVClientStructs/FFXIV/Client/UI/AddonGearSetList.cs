using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGearSetList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GearSetList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3AA0)]
public partial struct AddonGearSetList {
    [FieldOffset(0x3A9D)] public bool ShouldResetPosition;
}

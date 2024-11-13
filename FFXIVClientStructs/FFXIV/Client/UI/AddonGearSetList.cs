using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGearSetList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GearSetList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3AA8)]
public partial struct AddonGearSetList {
    [FieldOffset(0x3AA5)] public bool ShouldResetPosition;
}

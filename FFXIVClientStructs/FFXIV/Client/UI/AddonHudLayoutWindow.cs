using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonHudLayoutWindow
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_HudLayoutWindow")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x280)]
public unsafe partial struct AddonHudLayoutWindow {
    [FieldOffset(0x250)] public AtkComponentButton* SaveButton;
}

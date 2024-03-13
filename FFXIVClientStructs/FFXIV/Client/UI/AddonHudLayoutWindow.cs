using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonHudLayoutWindow
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 33 C9 48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 48 89 8B ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83"
[Addon("_HudLayoutWindow")]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe struct AddonHudLayoutWindow {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x238)] public AtkComponentButton* SaveButton;
}

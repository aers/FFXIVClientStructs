using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;
// Client::UI::AddonHudLayoutWindow
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener

// _HudLayoutWindow

// size = 0x250
// ctor 40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 80 8B ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 81 8B ?? ?? ?? ?? ?? ?? ?? ?? 48 89 03 33 C0 80 8B ?? ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe struct AddonHudLayoutWindow
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x238)] public AtkComponentButton* SaveButton;
}
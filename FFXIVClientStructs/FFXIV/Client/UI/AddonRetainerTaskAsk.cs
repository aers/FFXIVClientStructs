using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskAsk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerTaskAsk")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 48 8D 83 ?? ?? ?? ?? 48 89 93 ?? ?? ?? ?? 48 89 93 ?? ?? ?? ?? 8D 4A ?? 48 89 93 ?? ?? ?? ?? 48 89 93 ?? ?? ?? ?? 48 89 93 ?? ?? ?? ?? 48 89 93 ?? ?? ?? ?? 66 90", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x2D0)]
public unsafe partial struct AddonRetainerTaskAsk {
    [FieldOffset(0x2C0)] public AtkComponentButton* AssignButton;
    [FieldOffset(0x2C8)] public AtkComponentButton* ReturnButton;
}

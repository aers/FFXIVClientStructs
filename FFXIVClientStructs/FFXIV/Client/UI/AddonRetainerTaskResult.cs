using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RetainerTaskResult")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 80 8B ?? ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 89 83", 3, 74)]
[StructLayout(LayoutKind.Explicit, Size = 0x270)]
public unsafe partial struct AddonRetainerTaskResult {
    [FieldOffset(0x258)] public AtkComponentButton* ReassignButton;
    [FieldOffset(0x260)] public AtkComponentButton* ConfirmButton;
}

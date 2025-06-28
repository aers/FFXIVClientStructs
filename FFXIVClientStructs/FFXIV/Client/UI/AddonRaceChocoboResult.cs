using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRaceChocoboResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 4C 89 83 ?? ?? ?? ?? 48 89 03", 3, 74)]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe partial struct AddonRaceChocoboResult {
    [FieldOffset(0x280)] public AtkComponentButton* LeaveButton;
}

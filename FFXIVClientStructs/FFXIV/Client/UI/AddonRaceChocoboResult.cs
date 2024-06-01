using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRaceChocoboResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 4C 89 83 60 02 00 00 48 89 03 48 8D 8B 70 02 00 00 41 8B C0 4C 89 83 68 02 00 00 4C 89 83 78 02 00 00", 3)]
public unsafe partial struct AddonRaceChocoboResult {
    [FieldOffset(0x268)] public AtkComponentButton* LeaveButton;
}

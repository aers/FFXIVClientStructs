using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRaceChocoboResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 4c 89 83 60 02 00 00 48 89 03 48 8d 8b 70 02 00 00 41 8b c0 4c 89 83 68 02 00 00 4c 89 83 78 02 00 00", 3)]
public unsafe partial struct AddonRaceChocoboResult {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x268)] public AtkComponentButton* LeaveButton;
}

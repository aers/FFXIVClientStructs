namespace FFXIVClientStructs.FFXIV.Component.GUI;
// note: Name made up
// This is the "hold to proceed" button type

// Component::GUI::AtkComponentHoldButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener

// size = 0xF0
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type ?
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public struct AtkComponentHoldButton
{
    [FieldOffset(0x0)] public AtkComponentButton AtkComponentButton;
}
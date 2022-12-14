namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentRadioButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener

// size = 0xF8
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 4
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public struct AtkComponentRadioButton
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}
namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentCheckBox
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener

// size = 0x110
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 3
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public struct AtkComponentCheckBox
{
    [FieldOffset(0x0)] public AtkComponentButton AtkComponentButton;

    public bool IsChecked => (AtkComponentButton.Flags & (1 << 18)) != 0;
}
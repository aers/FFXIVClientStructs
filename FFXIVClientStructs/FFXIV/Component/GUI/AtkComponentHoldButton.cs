namespace FFXIVClientStructs.FFXIV.Component.GUI;
// note: Name made up
// This is the "hold to proceed" button type

// Component::GUI::AtkComponentHoldButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 24
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public struct AtkComponentHoldButton {
    [FieldOffset(0x0)] public AtkComponentButton AtkComponentButton;
}

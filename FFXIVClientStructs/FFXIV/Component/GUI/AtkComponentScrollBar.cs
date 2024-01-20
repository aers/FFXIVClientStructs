namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentScrollBar
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 13
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public struct AtkComponentScrollBar {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}

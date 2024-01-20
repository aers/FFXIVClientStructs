namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentIconText
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 16
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public struct AtkComponentIconText {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}

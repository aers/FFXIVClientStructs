namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentGuildLeveCard
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 18
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public struct AtkComponentGuildLeveCard {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}

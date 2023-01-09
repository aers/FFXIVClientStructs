namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentIconText
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0xE8
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 16
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public struct AtkComponentIconText
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}
namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentGaugeBar
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0xF0
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 5
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public struct AtkComponentGaugeBar
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}
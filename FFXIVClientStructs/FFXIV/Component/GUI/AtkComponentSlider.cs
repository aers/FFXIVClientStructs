namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentSlider
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x100
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 6
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public struct AtkComponentSlider
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}
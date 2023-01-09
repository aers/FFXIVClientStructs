namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentWindow
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x108
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 2
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public struct AtkComponentWindow
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
}
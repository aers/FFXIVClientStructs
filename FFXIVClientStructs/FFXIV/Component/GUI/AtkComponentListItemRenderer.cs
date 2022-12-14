namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentListItemRenderer
//  Component::GUI::AtkComponentButton
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x1A8
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type ?
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public struct AtkComponentListItemRenderer
{
    [FieldOffset(0x0)] public AtkComponentButton AtkComponentButton;
}
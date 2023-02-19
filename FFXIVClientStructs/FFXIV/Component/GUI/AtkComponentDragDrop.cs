namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentDragDrop
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0x110
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 17
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe partial struct AtkComponentDragDrop
{
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xF8)] public AtkComponentIcon* AtkComponentIcon;
    
    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 FF 74 40")]
    public partial int GetIconId();
}
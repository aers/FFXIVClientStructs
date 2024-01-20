namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentDragDrop
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 17
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe partial struct AtkComponentDragDrop {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xC0)] public AtkDragDropInterface AtkDragDropInterface;
    [FieldOffset(0xF8)] public AtkComponentIcon* AtkComponentIcon;

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 FF 74 40")]
    public partial int GetIconId();
}

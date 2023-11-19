namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentDropDownList
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct AtkComponentDropDownList {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    [FieldOffset(0xC0)] public AtkComponentCheckBox* Checkbox;
    [FieldOffset(0xC8)] public AtkComponentList* List;

    [FieldOffset(0xD8)] public bool IsOpen;
    [FieldOffset(0xD9)] public bool OpenStateChangePending;

    [MemberFunction("E8 ?? ?? ?? ?? 45 89 3E")]
    public partial void SelectItem(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 88 9F ?? ?? ?? ?? E9")]
    public partial void DeselectItem();

    [MemberFunction("E8 ?? ?? ?? ?? 83 FD 18")]
    public partial int GetSelectedItemIndex();
}

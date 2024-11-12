using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentDropDownList
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 17", [1, 970])]
public unsafe partial struct AtkComponentDropDownList : ICreatable {
    [FieldOffset(0xC0)] public AtkComponentCheckBox* Checkbox;
    [FieldOffset(0xC8)] public AtkComponentList* List;

    [FieldOffset(0xD8)] public bool IsOpen;
    [FieldOffset(0xD9)] public bool OpenStateChangePending;
    [FieldOffset(0xDA)] public bool ShowPreview;

    [MemberFunction("E8 ?? ?? ?? ?? 44 03 FE")]
    public partial void SelectItem(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 88 9F ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 87 ?? ?? ?? ??")]
    public partial void DeselectItem();

    [MemberFunction("E8 ?? ?? ?? ?? 83 C0 41")]
    public partial int GetSelectedItemIndex();

    public void Ctor() {
        AtkComponentBase.Ctor();
        VirtualTable = StaticVirtualTablePointer;
        ShowPreview = true;
    }
}

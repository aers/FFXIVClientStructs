using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentDragDrop
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 17
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe partial struct AtkComponentDragDrop : ICreatable {
    [FieldOffset(0xC0)] public AtkDragDropInterface AtkDragDropInterface;
    [FieldOffset(0xF8)] public AtkComponentIcon* AtkComponentIcon;

    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 51 08 48 89 01 48 8D 05 ?? ?? ?? ??")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 FF 74 40")]
    public partial int GetIconId();
}

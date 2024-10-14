using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentListItemRenderer
//  Component::GUI::AtkComponentButton
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 14
[GenerateInterop]
[Inherits<AtkComponentButton>, Inherits<AtkDragDropInterface>(0xF0)]
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public partial struct AtkComponentListItemRenderer : ICreatable {
    [FieldOffset(0x184)] public int ListItemIndex;

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 33 C9 48 C7 83 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ??")]
    public partial void Ctor();
}

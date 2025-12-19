using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTab
//   Component::GUI::AtkComponentRadioButton
//     Component::GUI::AtkComponentButton
//       Component::GUI::AtkComponentBase
//         Component::GUI::AtkEventListener
// type 11
[GenerateInterop]
[Inherits<AtkComponentRadioButton>]
[StructLayout(LayoutKind.Explicit, Size = 0x168)]
public partial struct AtkComponentTab : ICreatable {
    [FieldOffset(0xF8)] public Utf8String UnkString;
    [FieldOffset(0x160)] public short OwnerNodeWidth;
    [FieldOffset(0x162)] public short ButtonTextNodeX;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 33 FF 48 8D 8B ?? ?? ?? ?? 48 89 03 89 BB ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B C3")]
    public partial void Ctor();
}

using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkNineGridNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget

// size = 0xC8
// common CreateAtkNode function E8 ?? ?? ?? ?? 48 8B 4E 08 49 8B D5 
// type 4
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct AtkNineGridNode : ICreatable
{
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xA8)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xB0)] public uint PartID;
    [FieldOffset(0xB4)] public short TopOffset;
    [FieldOffset(0xB6)] public short BottomOffset;
    [FieldOffset(0xB8)] public short LeftOffset;
    [FieldOffset(0xBA)] public short RightOffset;

    [FieldOffset(0xBC)] public uint BlendMode;

    // bit 1 = parts type, bit 2 = render type
    [FieldOffset(0xC0)] public byte PartsTypeRenderType;

    [MemberFunction(
        "E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 5D")]
    public partial void Ctor();
}
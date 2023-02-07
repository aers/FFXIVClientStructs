using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkCounterNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget

// size = 0x128
// common CreateAtkNode function E8 ?? ?? ?? ?? 48 8B 4E 08 49 8B D5 
// type 5
[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public unsafe partial struct AtkCounterNode : ICreatable
{
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xA8)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xB0)] public uint PartId;
    [FieldOffset(0xB4)] public byte NumberWidth;
    [FieldOffset(0xB5)] public byte CommaWidth;
    [FieldOffset(0xB6)] public byte SpaceWidth;
    [FieldOffset(0xB8)] public ushort TextAlign;
    [FieldOffset(0xBC)] public float Width;
    [FieldOffset(0xC0)] public Utf8String NodeText;
    
    [MemberFunction("E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 5D")]
    public partial void Ctor();
}
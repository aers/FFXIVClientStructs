using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkNineGridNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 ?? 0F B7 CD"
// type 4
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 ?? 0F B7 CD", [1, 213])]
public unsafe partial struct AtkNineGridNode : ICreatable {
    [FieldOffset(0xC0)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xC8)] public uint PartId;
    [FieldOffset(0xCC)] public short TopOffset;
    [FieldOffset(0xCE)] public short BottomOffset;
    [FieldOffset(0xD0)] public short LeftOffset;
    [FieldOffset(0xD2)] public short RightOffset;
    [FieldOffset(0xD4)] public uint BlendMode;

    // bit 1 = parts type, bit 2 = render type
    [FieldOffset(0xD8)] public byte PartsTypeRenderType;

    // 7.0 inlines this ctor
    public void Ctor() {
        AtkResNode.Ctor();
        VirtualTable = StaticVirtualTablePointer;
    }
}

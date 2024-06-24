using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkNineGridNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget
// common CreateAtkNode function "E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13"
// type 4
[GenerateInterop]
[Inherits<AtkResNode>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
[VirtualTable("E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13", [1, 213])]
public unsafe partial struct AtkNineGridNode : ICreatable {
    [FieldOffset(0xB0)] public AtkUldPartsList* PartsList;
    [FieldOffset(0xB8)] public uint PartId;
    [FieldOffset(0xBC)] public short TopOffset;
    [FieldOffset(0xBE)] public short BottomOffset;
    [FieldOffset(0xC0)] public short LeftOffset;
    [FieldOffset(0xC2)] public short RightOffset;
    [FieldOffset(0xC4)] public uint BlendMode;

    // bit 1 = parts type, bit 2 = render type
    [FieldOffset(0xC8)] public byte PartsTypeRenderType;

    // 7.0 inlines this ctor
    public void Ctor() {
        AtkResNode.Ctor();
        VirtualTable = StaticVirtualTablePointer;
    }
}

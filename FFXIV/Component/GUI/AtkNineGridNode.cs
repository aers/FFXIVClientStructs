using FFXIVClientStructs.FFXIV.Component.GUI.ULD;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkNineGridNode
    //   Component::GUI::AtkResNode
    //     Component::GUI::AtkEventTarget

    // size = 0xC8
    // common CreateAtkNode function E8 ? ? ? ? 48 8B 4E 08 49 8B D5 
    // type 4
    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public unsafe struct AtkNineGridNode
    {
        [FieldOffset(0x0)] public AtkResNode AtkResNode;
        [FieldOffset(0xA8)] public ULDPartsList* PartsList;
        [FieldOffset(0xB0)] public uint PartID;
        [FieldOffset(0xB4)] public short TopOffset;
        [FieldOffset(0xB6)] public short BottomOffset;
        [FieldOffset(0xB8)] public short LeftOffset;
        [FieldOffset(0xBA)] public short RightOffset;
        [FieldOffset(0xBC)] public uint BlendMode;
        // bit 1 = parts type, bit 2 = render type
        [FieldOffset(0xC0)] public byte PartsTypeRenderType;
    }
}

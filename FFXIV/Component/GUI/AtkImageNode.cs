using FFXIVClientStructs.FFXIV.Component.GUI.ULD;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    public enum ImageNodeFlags
    {
        FlipH = 0x01,
        FlipV = 0x02,
        // unk byte https://github.com/NotAdam/Lumina/blob/714a1d8b9c4e182b411e7c68330d49a5dfccb9bc/src/Lumina/Data/Parsing/Uld/NodeData.cs#L51
        // sets two flags 0x20, 0x40
        AutoFit = 0x80 // set if the texture pointer is null
    }

    // Component::GUI::AtkImageNode
    //   Component::GUI::AtkResNode
    //     Component::GUI::AtkEventTarget

    // size = 0xB8
    // common CreateAtkNode function E8 ? ? ? ? 48 8B 4E 08 49 8B D5 
    // type 2
    [StructLayout(LayoutKind.Explicit, Size = 0xB8)]
    public unsafe struct AtkImageNode
    {
        [FieldOffset(0x0)] public AtkResNode AtkResNode;
        [FieldOffset(0xA8)] public ULDPartsList* PartsList;
        [FieldOffset(0xB0)] public ushort PartId;
        [FieldOffset(0xB2)] public byte WrapMode;
        [FieldOffset(0xB3)] public byte Flags; // actually a bitfield
    }
}

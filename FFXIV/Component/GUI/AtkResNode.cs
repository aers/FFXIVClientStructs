using FFXIVClientStructs.FFXIV;
using FFXIVClientStructs.FFXIV.Client.Graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    public enum NodeType : ushort
    {
        Res = 1,
        Image = 2,
        Text = 3,
        NineGrid = 4,
        Counter = 5,
        Collision = 8,
        // Component: >=1000
    }

    // 'visible' will change visibility immediately, the rest rely on other stuff to happen so they dont do anything
    // top and bottom assumed based on a scrollbar, lots of left-aligned text has AnchorLeft set
    public enum NodeFlags
    {
        AnchorTop = 0x01,
        AnchorLeft = 0x02,
        AnchorBottom = 0x04,
        AnchorRight = 0x08,
        Visible = 0x10,
        Enabled = 0x20, // this is like, "button can be clicked" etc
        Clip = 0x40,
        Fill = 0x80,
        HasCollision = 0x100, // set if node type == 8, might be "HasCollision", also set if Unk2 first bit is set (https://github.com/NotAdam/Lumina/blob/714a1d8b9c4e182b411e7c68330d49a5dfccb9bc/src/Lumina/Data/Parsing/Uld/UldRoot.cs#L273)
        RespondToMouse = 0x200 // this also gets set if the above flag is set
    }

    // Component::GUI::AtkResNode
    //   Component::GUI::AtkEventTarget

    // base class for all UI "nodes" which represent elements of the UI

    // size = 0xA8
    // ctor E9 ? ? ? ? 33 C0 48 83 C4 20 5B C3 66 90 
    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public unsafe struct AtkResNode
    {
        [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
        [FieldOffset(0x8)] public uint NodeID;
        // these are all technically union types with a node ID and a pointer but should be replaced by the loader always
        [FieldOffset(0x20)] public AtkResNode* ParentNode;
        [FieldOffset(0x28)] public AtkResNode* PrevSiblingNode;
        [FieldOffset(0x30)] public AtkResNode* NextSiblingNode;
        [FieldOffset(0x38)] public AtkResNode* ChildNode;
        [FieldOffset(0x40)] public NodeType Type;
        [FieldOffset(0x42)] public ushort ChildCount;
        [FieldOffset(0x44)] public float X; // X,Y converted to floats on load, file is int16
        [FieldOffset(0x48)] public float Y;
        [FieldOffset(0x4C)] public float ScaleX;
        [FieldOffset(0x50)] public float ScaleY;
        [FieldOffset(0x54)] public float Rotation; // radians (file is degrees)
        [FieldOffset(0x58)] public fixed float UnkMatrix[3 * 2];
        [FieldOffset(0x70)] public ByteColor Color;
        // not sure what the _2s are for, the regular ones are loaded from the file
        [FieldOffset(0x74)] public float Depth;
        [FieldOffset(0x78)] public float Depth_2;
        [FieldOffset(0x7C)] public ushort AddRed;
        [FieldOffset(0x7E)] public ushort AddGreen;
        [FieldOffset(0x80)] public ushort AddBlue;
        [FieldOffset(0x82)] public ushort AddRed_2;
        [FieldOffset(0x84)] public ushort AddGreen_2;
        [FieldOffset(0x86)] public ushort AddBlue_2;
        [FieldOffset(0x88)] public byte MultiplyRed;
        [FieldOffset(0x89)] public byte MultiplyGreen;
        [FieldOffset(0x8A)] public byte MultiplyBlue;
        [FieldOffset(0x8B)] public byte MultiplyRed_2;
        [FieldOffset(0x8C)] public byte MultiplyGreen_2;
        [FieldOffset(0x8D)] public byte MultiplyBlue_2;
        [FieldOffset(0x8E)] public byte Alpha_2;
        [FieldOffset(0x8F)] public byte UnkByte_1;
        [FieldOffset(0x90)] public ushort Width;
        [FieldOffset(0x92)] public ushort Height;
        [FieldOffset(0x94)] public float OriginX;
        [FieldOffset(0x98)] public float OriginY;
        // asm accesses these fields together so this is one 32bit field with priority+flags
        [FieldOffset(0x9C)] public ushort Priority;
        [FieldOffset(0x9E)] public short Flags;
        [FieldOffset(0xA0)] public uint Flags_2; // bit 1 = has changes, ClipCount is bits 10-17, idk its a mess

        public bool IsVisible => (Flags & 0x10) == 0x10;
    }
}

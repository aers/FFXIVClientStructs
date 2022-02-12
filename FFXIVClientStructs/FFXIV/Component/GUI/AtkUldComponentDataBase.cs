namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x9)]
public struct AtkUldComponentDataBase
{
    [FieldOffset(0x0)] public byte Index;
    [FieldOffset(0x1)] public byte Up;
    [FieldOffset(0x2)] public byte Down;
    [FieldOffset(0x3)] public byte Left;
    [FieldOffset(0x4)] public byte Right;
    [FieldOffset(0x5)] public byte Cursor;
    [FieldOffset(0x6)] public byte OffsetX; // short in .uld file
    [FieldOffset(0x7)] public byte OffsetY; // short in .uld file
    [FieldOffset(0x8)] public byte Unk;
}
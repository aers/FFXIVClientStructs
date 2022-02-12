namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// common class representing colors that are 0-255 fields
[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public struct ByteColor
{
    [FieldOffset(0x0)] public byte R;
    [FieldOffset(0x1)] public byte G;
    [FieldOffset(0x2)] public byte B;
    [FieldOffset(0x3)] public byte A;
}
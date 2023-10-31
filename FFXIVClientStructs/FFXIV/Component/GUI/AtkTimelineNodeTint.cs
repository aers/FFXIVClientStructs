using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct AtkTimelineNodeTint {
    [FieldOffset(0x00)] public ByteColor MultiplyRGB;
    [FieldOffset(0x04)] public uint AddRGBBitfield;

    public readonly short AddR => (short)((short)(AddRGBBitfield & 0x3FF) - 255);
    public readonly short AddG => (short)((short)((AddRGBBitfield >> 10) & 0xFFF) - 255);
    public readonly short AddB => (short)((short)((AddRGBBitfield >> 22) & 0x3FF) - 255);
}

using System.Drawing;

namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct Rectangle
{
    [FieldOffset(0x0)] public float Left;
    [FieldOffset(0x4)] public float Top;
    [FieldOffset(0x8)] public float Right;
    [FieldOffset(0xC)] public float Bottom;

    public static implicit operator RectangleF(Rectangle rect)
    {
        return new RectangleF(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
    }
}
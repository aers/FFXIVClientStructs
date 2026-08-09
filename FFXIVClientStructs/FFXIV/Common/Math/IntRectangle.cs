namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct IntRectangle {
    [FieldOffset(0x0)] public int Left;
    [FieldOffset(0x4)] public int Top;
    [FieldOffset(0x8)] public int Right;
    [FieldOffset(0xC)] public int Bottom;

    public static implicit operator System.Drawing.Rectangle(IntRectangle rect) {
        return new System.Drawing.Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
    }
}

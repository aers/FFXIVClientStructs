using System.Drawing;

namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct Bounds {
    [FieldOffset(0x0)] public Point Pos1; // Top Left
    [FieldOffset(0x8)] public Point Pos2; // Bottom Right

    public readonly int Width => Pos2.X - Pos1.X;
    public readonly int Height => Pos2.Y - Pos1.Y;
    public readonly Vector2 Size => new(Width, Height);

    public readonly int CenterX => (Pos1.X + Pos2.X) / 2;
    public readonly int CenterY => (Pos1.Y + Pos2.Y) / 2;
    public readonly Vector2 Center => new(CenterX, CenterY);

    public readonly bool ContainsPoint(int x, int y) => x >= Pos1.X && x <= Pos2.X && y >= Pos1.Y && y <= Pos2.Y;
    public readonly bool ContainsPoint(Point p) => ContainsPoint(p.X, p.Y);

    public override string ToString() => $"{Pos1}, {Pos2}";
}

namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct Matrix2x2 : IEquatable<Matrix2x2> {
    [FieldOffset(0x0), CExportIgnore] public fixed float Matrix[4];

    [FieldOffset(0x0)] public float M11;
    [FieldOffset(0x4)] public float M12;
    [FieldOffset(0x8)] public float M21;
    [FieldOffset(0xC)] public float M22;

    public static Matrix2x2 Zero = new();
    public static Matrix2x2 Identity = new() { M11 = 1.0f, M22 = 1.0f };

    public float this[int index] {
        get => index is >= 0 and < 4 ? Matrix[index] : throw new IndexOutOfRangeException($"{index}");
        set {
            if (index is >= 0 and < 4) Matrix[index] = value;
            else throw new IndexOutOfRangeException($"{index}");
        }
    }

    public float this[int row, int column] {
        get => this[column + row * 2];
        set => this[column + row * 2] = value;
    }

    public bool Equals(Matrix2x2 other) => M11.Equals(other.M11) && M12.Equals(other.M12) && M21.Equals(other.M21) && M22.Equals(other.M22);

    public override bool Equals(object? obj) => obj is Matrix2x2 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(M11, M12, M21, M22);

    public override string ToString() => $"{{ {{M11:{M11} M12:{M12}}} {{M21:{M21} M22:{M22}}} }}";

    public static bool operator ==(Matrix2x2 left, Matrix2x2 right) => left.Equals(right);
    public static bool operator !=(Matrix2x2 left, Matrix2x2 right) => !left.Equals(right);
}

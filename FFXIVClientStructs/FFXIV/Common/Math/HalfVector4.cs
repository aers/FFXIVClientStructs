using System.Globalization;

namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct HalfVector4 : IEquatable<HalfVector4>, IFormattable {
    [FieldOffset(0x0)] public Half X;
    [FieldOffset(0x2)] public Half Y;
    [FieldOffset(0x4)] public Half Z;
    [FieldOffset(0x6)] public Half W;

    public static readonly HalfVector4 Zero = new(Half.Zero);
    public static readonly HalfVector4 One = new(Half.One);
    public static readonly HalfVector4 PositiveInfinity = new(Half.PositiveInfinity);
    public static readonly HalfVector4 NegativeInfinity = new(Half.NegativeInfinity);

    public HalfVector4(Half value) : this(value, value, value, value) { }
    public HalfVector4(Half x, Half y, Half z, Half w) {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static HalfVector4 operator +(HalfVector4 a, HalfVector4 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    public static HalfVector4 operator -(HalfVector4 a, HalfVector4 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    public static HalfVector4 operator -(HalfVector4 a) => new(-a.X, -a.Y, -a.Z, -a.W);
    public static HalfVector4 operator *(HalfVector4 a, Half d) => new(a.X * d, a.Y * d, a.Z * d, a.W * d);
    public static HalfVector4 operator *(Half d, HalfVector4 a) => new(a.X * d, a.Y * d, a.Z * d, a.W * d);
    public static HalfVector4 operator /(HalfVector4 a, Half d) => new(a.X / d, a.Y / d, a.Z / d, a.W / d);

    public static bool operator ==(HalfVector4 left, HalfVector4 right) => left.Equals(right);
    public static bool operator !=(HalfVector4 left, HalfVector4 right) => !left.Equals(right);

    public bool Equals(HalfVector4 other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
    public override bool Equals(object? obj) => obj is HalfVector4 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

    public override string ToString() => ToString(null, null);
    public string ToString(string? format, IFormatProvider? provider) {
        if (string.IsNullOrEmpty(format)) format = "HalfVector4 {{ X = {0}, Y = {1}, Z = {2}, W = {3} }}";
        provider ??= CultureInfo.CurrentCulture;
        return string.Format(provider, format, X, Y, Z, W);
    }
}

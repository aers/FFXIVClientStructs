using System.Globalization;

namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public struct HalfVector2 : IEquatable<HalfVector2>, IFormattable {
    [FieldOffset(0x0)] public Half X;
    [FieldOffset(0x2)] public Half Y;

    public static readonly HalfVector2 Zero = new(Half.Zero);
    public static readonly HalfVector2 One = new(Half.One);
    public static readonly HalfVector2 PositiveInfinity = new(Half.PositiveInfinity);
    public static readonly HalfVector2 NegativeInfinity = new(Half.NegativeInfinity);

    public HalfVector2(Half value) : this(value, value) { }
    public HalfVector2(Half x, Half y) {
        X = x;
        Y = y;
    }

    public static HalfVector2 operator +(HalfVector2 a, HalfVector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static HalfVector2 operator -(HalfVector2 a, HalfVector2 b) => new(a.X - b.X, a.Y - b.Y);
    public static HalfVector2 operator -(HalfVector2 a) => new(-a.X, -a.Y);
    public static HalfVector2 operator *(HalfVector2 a, Half d) => new(a.X * d, a.Y * d);
    public static HalfVector2 operator *(Half d, HalfVector2 a) => new(a.X * d, a.Y * d);
    public static HalfVector2 operator /(HalfVector2 a, Half d) => new(a.X / d, a.Y / d);

    public static bool operator ==(HalfVector2 left, HalfVector2 right) => left.Equals(right);
    public static bool operator !=(HalfVector2 left, HalfVector2 right) => !left.Equals(right);

    public bool Equals(HalfVector2 other) => X.Equals(other.X) && Y.Equals(other.Y);
    public override bool Equals(object? obj) => obj is HalfVector2 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() => ToString(null, null);
    public string ToString(string? format, IFormatProvider? provider) {
        if (string.IsNullOrEmpty(format)) format = "HalfVector2 {{ X = {0}, Y = {1} }}";
        provider ??= CultureInfo.CurrentCulture;
        return string.Format(provider, format, X, Y);
    }
}

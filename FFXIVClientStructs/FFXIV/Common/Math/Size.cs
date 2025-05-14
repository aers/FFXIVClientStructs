namespace FFXIVClientStructs.FFXIV.Common.Math;

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct Size : IEquatable<Size>, IComparable<Size> {
    [FieldOffset(0x0), CExportIgnore] private ulong Value;
    [FieldOffset(0x0)] public int Width;
    [FieldOffset(0x4)] public int Height;

    public bool Equals(Size other) => Value == other.Value;
    public override bool Equals(object? obj) => obj is Size other && Equals(other);
    public override int GetHashCode() => Value.GetHashCode();
    public static bool operator ==(Size left, Size right) => left.Value == right.Value;
    public static bool operator !=(Size left, Size right) => left.Value != right.Value;
    public int CompareTo(Size other) => Value.CompareTo(other);
}

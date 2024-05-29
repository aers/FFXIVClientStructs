namespace FFXIVClientStructs.Interop;

// workaround for C# not supporting pointer types as generic arguments
[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public readonly unsafe struct Pointer<T> : IEquatable<Pointer<T>>, IComparable<Pointer<T>> where T : unmanaged {
    public T* Value { get; }

    private Pointer(T* p) {
        Value = p;
    }

    public static implicit operator T*(Pointer<T> p) => p.Value;
    public static implicit operator Pointer<T>(T* p) => new(p);

    public bool Equals(Pointer<T> other) => Value == other.Value;
    public override bool Equals(object? obj) => obj is Pointer<T> other && Equals(other);
    public override int GetHashCode() => ((nint)Value).GetHashCode();
    public static bool operator ==(Pointer<T> left, Pointer<T> right) => left.Value == right.Value;
    public static bool operator !=(Pointer<T> left, Pointer<T> right) => left.Value != right.Value;

    public int CompareTo(Pointer<T> other) => ((nint)Value).CompareTo((nint)other.Value);
    public static bool operator <(Pointer<T> left, Pointer<T> right) => left.Value < right.Value;
    public static bool operator >(Pointer<T> left, Pointer<T> right) => left.Value > right.Value;
    public static bool operator <=(Pointer<T> left, Pointer<T> right) => left.Value <= right.Value;
    public static bool operator >=(Pointer<T> left, Pointer<T> right) => left.Value >= right.Value;
}

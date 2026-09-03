namespace FFXIVClientStructs.Havok.Common.Base.Math.Vector;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkVector4f : IEquatable<hkVector4f> {
    [FieldOffset(0x00)] public float X;
    [FieldOffset(0x04)] public float Y;
    [FieldOffset(0x08)] public float Z;
    [FieldOffset(0x0C)] public float W;

    public static bool operator ==(hkVector4f left, hkVector4f right) => left.Equals(right);
    public static bool operator !=(hkVector4f left, hkVector4f right) => !left.Equals(right);

    public bool Equals(hkVector4f other) {
        return X.Equals(other.X)
            && Y.Equals(other.Y)
            && Z.Equals(other.Z)
            && W.Equals(other.W);
    }

    public override bool Equals(object? obj) => obj is hkVector4f other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);
}

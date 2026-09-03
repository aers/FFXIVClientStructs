namespace FFXIVClientStructs.Havok.Common.Base.Math.Matrix;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct hkRotationf : IEquatable<hkRotationf> {
    [FieldOffset(0x00)] public hkMatrix3f hkMatrix3f;

    public static bool operator ==(hkRotationf left, hkRotationf right) => left.Equals(right);
    public static bool operator !=(hkRotationf left, hkRotationf right) => !left.Equals(right);

    public bool Equals(hkRotationf other) => hkMatrix3f.Equals(other.hkMatrix3f);
    public override bool Equals(object? obj) => obj is hkRotationf other && Equals(other);
    public override int GetHashCode() {
        return HashCode.Combine(hkMatrix3f);
    }
}

using FFXIVClientStructs.Havok.Common.Base.Math.Vector;

namespace FFXIVClientStructs.Havok.Common.Base.Math.Matrix;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct hkTransformf : IEquatable<hkTransformf> {
    [FieldOffset(0x00)] public hkRotationf Rotation;
    [FieldOffset(0x30)] public hkVector4f Translation;

    public static bool operator ==(hkTransformf left, hkTransformf right) => left.Equals(right);
    public static bool operator !=(hkTransformf left, hkTransformf right) => !left.Equals(right);

    public bool Equals(hkTransformf other) => Rotation.Equals(other.Rotation) && Translation.Equals(other.Translation);
    public override bool Equals(object? obj) => obj is hkTransformf other && Equals(other);
    public override int GetHashCode() {
        return HashCode.Combine(Rotation, Translation);
    }
}

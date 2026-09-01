namespace FFXIVClientStructs.Havok.Common.Base.Math.Vector;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkSimdFloat32 : IEquatable<hkSimdFloat32> {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray4<float> _f32;

    public static bool operator ==(hkSimdFloat32 left, hkSimdFloat32 right) => left.Equals(right);
    public static bool operator !=(hkSimdFloat32 left, hkSimdFloat32 right) => !left.Equals(right);

    public bool Equals(hkSimdFloat32 other) => F32.SequenceEqual(other.F32);
    public override bool Equals(object? obj) => obj is hkSimdFloat32 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(_f32);
}

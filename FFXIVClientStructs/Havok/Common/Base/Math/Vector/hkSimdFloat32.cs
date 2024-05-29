namespace FFXIVClientStructs.Havok.Common.Base.Math.Vector;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct hkSimdFloat32 {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray4<float> _f32;
}

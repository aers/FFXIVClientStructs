namespace FFXIVClientStructs.Havok.Common.Base.Math.Vector;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct hkSimdFloat32 {
    [FieldOffset(0x00)] public fixed float f32[4];
}

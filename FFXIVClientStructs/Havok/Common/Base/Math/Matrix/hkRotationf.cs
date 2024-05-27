namespace FFXIVClientStructs.Havok.Common.Base.Math.Matrix;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct hkRotationf {
    [FieldOffset(0x00)] public hkMatrix3f hkMatrix3f;
}

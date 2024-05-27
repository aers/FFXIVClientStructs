using FFXIVClientStructs.Havok.Common.Base.Math.Vector;

namespace FFXIVClientStructs.Havok.Common.Base.Math.Matrix;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct hkTransformf {
    [FieldOffset(0x00)] public hkRotationf Rotation;
    [FieldOffset(0x30)] public hkVector4f Translation;
}

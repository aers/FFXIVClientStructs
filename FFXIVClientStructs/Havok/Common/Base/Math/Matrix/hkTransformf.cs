namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct hkTransformf {
    [FieldOffset(0x00)] public hkRotationf Rotation;
    [FieldOffset(0x30)] public hkVector4f Translation;
}

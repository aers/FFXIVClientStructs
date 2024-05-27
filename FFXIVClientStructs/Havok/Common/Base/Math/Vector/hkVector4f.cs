namespace FFXIVClientStructs.Havok.Common.Base.Math.Vector;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkVector4f {
    [FieldOffset(0x00)] public float X;
    [FieldOffset(0x04)] public float Y;
    [FieldOffset(0x08)] public float Z;
    [FieldOffset(0x0C)] public float W;
}

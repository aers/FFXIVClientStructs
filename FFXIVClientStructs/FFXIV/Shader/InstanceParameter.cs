using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Shader;

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public struct InstanceParameter {
    [FieldOffset(0x0)]
    public Vector4 MulColor;
    [FieldOffset(0x10)]
    public Vector4 EnvParameter;
    [FieldOffset(0x20)]
    public CameraLight CameraLight;
    [FieldOffset(0x40)]
    public Vector4 Wetness;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct CameraLight {
    [FieldOffset(0x0)]
    public Vector4 DiffuseSpecular;
    [FieldOffset(0x10)]
    public Vector4 Rim;
}

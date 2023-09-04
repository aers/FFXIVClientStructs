using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Shader;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct SceneParameter {
    [FieldOffset(0x0)]
    public Vector4 OcclusionIntensity;

    [FieldOffset(0x10)]
    public Vector4 Wetness;
}

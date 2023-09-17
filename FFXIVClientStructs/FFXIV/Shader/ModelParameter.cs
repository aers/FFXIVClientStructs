using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Shader;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct ModelParameter {
    [FieldOffset(0x0)]
    public Vector4 Params;
}

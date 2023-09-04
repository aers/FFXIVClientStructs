using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Shader;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct CommonParameter {
    [FieldOffset(0x0)]
    public Vector4 RenderTarget;

    [FieldOffset(0x10)]
    public Vector4 Viewport;

    [FieldOffset(0x20)]
    public Vector4 Misc;

    [FieldOffset(0x30)]
    public Vector4 Misc2;
}

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe struct PixelShader {
    [FieldOffset(0)] public PVShader Shader;
    [FieldOffset(0x60)] public void* DirectXObject;
}

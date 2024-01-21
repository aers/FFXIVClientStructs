namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct VertexShader {
    [Flags]
    public enum Input : uint {
        Position = 1 << 0,
        BlendWeight = 1 << 1,
        Normal = 1 << 2,
        Color0 = 1 << 3,
        Color1 = 1 << 4,
        Fog = 1 << 5,
        PSize = 1 << 6,
        BlendIndices = 1 << 7,
        TexCoord0 = 1 << 8,
        TexCoord1 = 1 << 9,
        TexCoord2 = 1 << 10,
        TexCoord3 = 1 << 11,
        TexCoord4 = 1 << 12,
        TexCoord5 = 1 << 13,
        Tangent = 1 << 14,
        Binormal = 1 << 15,
        Depth = 1 << 16,
    }

    [FieldOffset(0)] public PVShader Shader;
    [FieldOffset(0x60)] public Input DeclaredInputs;
    [FieldOffset(0x64)] public Input UsedInputs;
    [FieldOffset(0x68)] public byte* DxbcBlob;
    [FieldOffset(0x70)] public void* DirectXObject;

    public readonly Span<byte> DxbcBlobSpan
        => new(DxbcBlob, unchecked((int)Shader.DxbcBlobSize));
}

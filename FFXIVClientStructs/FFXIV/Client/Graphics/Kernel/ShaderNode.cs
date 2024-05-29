namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::ShaderNode
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
[GenerateInterop]
public unsafe partial struct ShaderNode {
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct ShaderPass {
        [FieldOffset(0x0)] public uint VertexShader;
        [FieldOffset(0x4)] public uint PixelShader;
    }

    [FieldOffset(0x08)] public ShaderPackage* OwnerPackage;
    [FieldOffset(0x10)] public uint PassNum;
    [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray16<byte> _passIndices;
    [FieldOffset(0x28)] public ShaderPass* Passes;
    [FieldOffset(0x30)] public uint* ShaderKeys;
}

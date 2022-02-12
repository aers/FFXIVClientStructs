namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
// Client::Graphics::Kernel::ShaderNode

// size = 0x38
// inlined ctor
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct ShaderNode
{
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct ShaderPass
    {
        [FieldOffset(0x0)] public uint VertexShader;
        [FieldOffset(0x4)] public uint PixelShader;
    }

    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public ShaderPackage* OwnerPackage;
    [FieldOffset(0x10)] public uint PassNum;
    [FieldOffset(0x14)] public fixed byte PassIndices[16];
    [FieldOffset(0x28)] public ShaderPass* Passes;
    [FieldOffset(0x30)] public uint* ShaderKeys;
}
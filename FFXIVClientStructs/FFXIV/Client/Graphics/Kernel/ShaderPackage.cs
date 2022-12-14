namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
// Client::Graphics::Kernel::ShaderPackage
//   Client::Graphics::ReferencedClassBase

// ctor E8 ?? ?? ?? ?? 8B 55 18 48 8B F0
// size = 0x408
[StructLayout(LayoutKind.Explicit, Size = 0x408)]
public unsafe struct ShaderPackage
{
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct MaterialElement
    {
        [FieldOffset(0x0)] public uint CRC;
        [FieldOffset(0x4)] public ushort Offset;
        [FieldOffset(0x6)] public ushort Size;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct ConstantSamplerUnknown
    {
    }

    [FieldOffset(0x00)] public ReferencedClassBase ReferencedClassBase;
    [FieldOffset(0x10)] public CVector<Pointer<VertexShader>> VertexShaders; // std::vector<VertexShader*>
    [FieldOffset(0x30)] public CVector<Pointer<PixelShader>> PixelShaders; // std::vector<PixelShader*>
    [FieldOffset(0x50)] public CVector<Pointer<ShaderNode>> ShaderNodes; // std::vector<ShaderNode*>

    [FieldOffset(0x70)] public ushort MaterialConstantBufferSize;

    // the following counts are totals shared by shaders in the shpk, they are not all used for all shaders
    [FieldOffset(0x74)]
    public ushort MaterialElementCount; // these are individual elements within the material constant buffer

    [FieldOffset(0x78)] public ushort ConstantCount;
    [FieldOffset(0x7C)] public ushort SamplerCount;
    [FieldOffset(0x80)] public ushort UnkCount;

    [FieldOffset(0x84)]
    public ushort SystemKeyCount; // keys are all CRC32 but no idea what bytes they are actually CRC32s of 

    [FieldOffset(0x88)] public ushort SceneKeyCount;

    [FieldOffset(0x8C)] public ushort MaterialKeyCount;

    // following are arrays
    // these are all pre-allocated with the ShaderPackage object in one block of memory
    [FieldOffset(0x90)] public MaterialElement* MaterialElements;
    [FieldOffset(0x98)] public ConstantSamplerUnknown* Constants;
    [FieldOffset(0xA0)] public ConstantSamplerUnknown* Samplers;

    [FieldOffset(0xA8)] public ConstantSamplerUnknown* Unknowns;

    // again these are all CRC32s
    [FieldOffset(0xB0)] public uint* SystemKeys;
    [FieldOffset(0xB8)] public uint* SceneKeys;
    [FieldOffset(0xC0)] public uint* MaterialKeys;
    [FieldOffset(0xC8)] public uint* SystemValues;
    [FieldOffset(0xD0)] public uint* SceneValues;
    [FieldOffset(0xD8)] public uint* MaterialValues;
    [FieldOffset(0xE0)] public uint SubviewValue1;
    [FieldOffset(0xE4)] public uint SubviewValue2;
    [FieldOffset(0xE8)] public void* ShaderNodeTreeVtbl; // class I haven't defined yet
}
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::ShaderPackage
//   Client::Graphics::ReferencedClassBase
[StructLayout(LayoutKind.Explicit, Size = 0x178)]
public unsafe struct ShaderPackage {
    public const ushort SamplerSlotMaterial = 2;

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct MaterialElement {
        [FieldOffset(0x0)] public uint CRC;
        [FieldOffset(0x4)] public ushort Offset;
        [FieldOffset(0x6)] public ushort Size;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct ConstantSamplerUnknown {
        [FieldOffset(0x0)] public uint CRC;
        /// <summary>
        /// Cross-reference this with <see cref="Material.TextureEntry.Id"/> and <see cref="PVShader.ResourceEntry.Id"/>.
        /// </summary>
        [FieldOffset(0x4)] public uint Id;
        /// <summary>
        /// For constants : size, in 4-float registers.
        /// For others : seems unused.
        /// </summary>
        [FieldOffset(0x8)] public ushort Size;
        [FieldOffset(0xA)] public ushort Slot;
    }

    [FieldOffset(0x00)] public ReferencedClassBase ReferencedClassBase;
    [FieldOffset(0x10)] public CVector<Pointer<VertexShader>> VertexShaders; // std::vector<VertexShader*>
    [FieldOffset(0x30)] public CVector<Pointer<PixelShader>> PixelShaders; // std::vector<PixelShader*>
    [FieldOffset(0xB0)] public CVector<Pointer<ShaderNode>> ShaderNodes; // std::vector<ShaderNode*>

    [FieldOffset(0xD0)] public ushort MaterialConstantBufferSize;

    // the following counts are totals shared by shaders in the shpk, they are not all used for all shaders
    [FieldOffset(0xD4)]
    public ushort MaterialElementCount; // these are individual elements within the material constant buffer

    [FieldOffset(0xD8)] public ushort ConstantCount;
    [FieldOffset(0xDC)] public ushort SamplerCount;
    [FieldOffset(0xE0), Obsolete($"Use {nameof(TextureCount)} instead", true)] public ushort UnkCount;
    [FieldOffset(0xE0)] public ushort TextureCount;
    [FieldOffset(0xE4)] public ushort Unk2Count;

    [FieldOffset(0xE8)]
    public ushort SystemKeyCount; // keys are all CRC32 but no idea what bytes they are actually CRC32s of 

    [FieldOffset(0xEC)] public ushort SceneKeyCount;

    [FieldOffset(0xF0)] public ushort MaterialKeyCount;

    // following are arrays
    // these are all pre-allocated with the ShaderPackage object in one block of memory
    [FieldOffset(0xF8)] public MaterialElement* MaterialElements;
    [FieldOffset(0x100)] public ConstantSamplerUnknown* Constants;
    [FieldOffset(0x108)] public ConstantSamplerUnknown* Samplers;

    [FieldOffset(0x110), Obsolete($"Use {nameof(Textures)} instead", true)] public ConstantSamplerUnknown* Unknowns;
    [FieldOffset(0x110)] public ConstantSamplerUnknown* Textures;
    [FieldOffset(0x118)] public ConstantSamplerUnknown* Unknowns2;

    [FieldOffset(0x120)] public void* MaterialElementDefaults;

    // again these are all CRC32s
    [FieldOffset(0x128)] public uint* SystemKeys;
    [FieldOffset(0x130)] public uint* SceneKeys;
    [FieldOffset(0x138)] public uint* MaterialKeys;
    [FieldOffset(0x140)] public uint* SystemValues;
    [FieldOffset(0x148)] public uint* SceneValues;
    [FieldOffset(0x150)] public uint* MaterialValues;
    [FieldOffset(0x158)] public uint SubviewValue1;
    [FieldOffset(0x15C)] public uint SubviewValue2;

    public Span<MaterialElement> MaterialElementsSpan
        => new(MaterialElements, MaterialElementCount);

    public Span<ConstantSamplerUnknown> ConstantsSpan
        => new(Constants, ConstantCount);
    public Span<ConstantSamplerUnknown> SamplersSpan
        => new(Samplers, SamplerCount);
    [Obsolete($"Use {nameof(TexturesSpan)} instead", true)]
    public Span<ConstantSamplerUnknown> UnknownsSpan
        => new(Unknowns, UnkCount);
    public Span<ConstantSamplerUnknown> TexturesSpan
        => new(Textures, TextureCount);
    public Span<ConstantSamplerUnknown> Unknowns2Span
        => new(Unknowns2, Unk2Count);

    public Span<byte> MaterialElementDefaultsSpan
        => new(MaterialElementDefaults, MaterialConstantBufferSize);

    public Span<uint> SystemKeysSpan
        => new(SystemKeys, SystemKeyCount);
    public Span<uint> SceneKeysSpan
        => new(SceneKeys, SceneKeyCount);
    public Span<uint> MaterialKeysSpan
        => new(MaterialKeys, MaterialKeyCount);
    public Span<uint> SystemValuesSpan
        => new(SystemValues, SystemKeyCount);
    public Span<uint> SceneValuesSpan
        => new(SceneValues, SceneKeyCount);
    public Span<uint> MaterialValuesSpan
        => new(MaterialValues, MaterialKeyCount);
}

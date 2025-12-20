namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// unsure about the name, seems to be an intermediate superclass
[GenerateInterop(isInherited: true)]
[Inherits<Shader>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct PVShader {
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct ResourceEntry {
        [FieldOffset(0x0)] public ushort Slot;
        /// <summary>
        /// For constants : size, in 4-float registers.
        /// For others : seems unused.
        /// </summary>
        [FieldOffset(0x2)] public ushort Size;
        /// <summary>
        /// Cross-reference this with <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/>.
        /// </summary>
        [FieldOffset(0x4)] public uint Id;
    }

    // number at 0x20 has been observed to be ConstantBufferCount * 16 + (SamplerCount + Unk2Count) * 24
    [FieldOffset(0x28)] public ResourceEntry* ConstantBuffers;
    [FieldOffset(0x30)] public ResourceEntry* Samplers;
    [FieldOffset(0x38)] private ResourceEntry* Unknowns;
    [FieldOffset(0x40)] public ushort ConstantBufferCount;
    [FieldOffset(0x44)] public ushort SamplerCount;
    [FieldOffset(0x48)] private ushort UnkCount;
    [FieldOffset(0x4C)] private ushort Unk2Count;
    [FieldOffset(0x58)] public uint DxbcBlobSize;

    public Span<ResourceEntry> ConstantBuffersSpan => new(ConstantBuffers, ConstantBufferCount);

    public Span<ResourceEntry> SamplersSpan => new(Samplers, SamplerCount);
}

using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

/// <summary>
/// Represents a renderer material.
/// </summary>
/// <remarks>
/// This structure is the header of a memory block of size sizeof(Material) + sizeof(uint) * ShaderKeyCount + sizeof(Material.TextureEntry) * TextureCount.
/// On construction, ShaderKeyCount is determined by <see cref="ShaderPackage.MaterialKeyCount"/>, and TextureCount is the number of
/// <see cref="ShaderPackage.Samplers"/> with <see cref="ShaderPackage.ConstantSamplerUnknown.Slot"/> == <see cref="ShaderPackage.SamplerSlotMaterial"/>.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct Material {
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct TextureEntry {
        /// <summary>
        /// Cross-reference this with <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/>.
        /// </summary>
        [FieldOffset(0x0)]
        public uint Id;
        [FieldOffset(0x8)]
        public TextureResourceHandle* Texture;
        [FieldOffset(0x10)]
        public uint SamplerFlags;
    }

    [FieldOffset(0x00)] public ReferencedClassBase ReferencedClassBase;
    /// <summary>
    /// The resource handle this material was instantiated from. Its <see cref="MaterialResourceHandle.Material"/> will be the current structure.
    /// </summary>
    [FieldOffset(0x10)] public MaterialResourceHandle* MaterialResourceHandle;
    [FieldOffset(0x18)] public uint ShaderFlags;
    /// <summary>
    /// Each of these values corresponds to a key in <see cref="ShaderPackage.MaterialKeys"/>, in the same order.
    /// </summary>
    [FieldOffset(0x20)] public uint* ShaderKeyValues;
    [FieldOffset(0x28)] public ConstantBuffer* MaterialParameterCBuffer; // arbitrary size and contents, defined by the shader package
    [FieldOffset(0x30)] public TextureEntry* Textures;
    [FieldOffset(0x38)] public ushort TextureCount;

    public readonly int ShaderKeyCount
        => (int)((uint*)Textures - ShaderKeyValues);

    public readonly Span<uint> ShaderKeyValuesSpan
        => new(ShaderKeyValues, ShaderKeyCount);

    public readonly Span<TextureEntry> TexturesSpan
        => new(Textures, TextureCount);

    /// <summary>
    /// Adjusts sampler flags in the same way as the mtrl loader.
    /// </summary>
    public static uint AdjustSamplerFlags(uint samplerFlags)
        => (samplerFlags & 0xFFFFFDFFu) | 0x1C0;
}

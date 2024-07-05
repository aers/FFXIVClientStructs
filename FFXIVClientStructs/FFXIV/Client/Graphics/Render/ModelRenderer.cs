using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::ModelRenderer
//   Client::Graphics::Render::BaseRenderer
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct ModelRenderer {
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct Callback {
        [FieldOffset(0x0)] public void* Function;
        [FieldOffset(0x8)] public void* ThisArg;
        [FieldOffset(0x10)] public void* SubFunction;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct OnRenderModelParams {
        [FieldOffset(0x0)] public Model* Model;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct OnRenderMaterialParams {
        [FieldOffset(0x0)] public Model* Model;
        [FieldOffset(0x8)] public uint MaterialIndex;
        [FieldOffset(0x10)] public ushort* OutFlags;
    }

    /// <summary> Indices of <see cref="ConstantSamplerIds"/> for well-known constant buffers. </summary>
    public enum WellKnownConstant {
        /// <summary> The g_LightDirection constant buffer (CRC: 0xEF4E7491). </summary>
        LightDirection = 0,
        /// <summary> The g_WorldViewMatrix constant buffer (CRC: 0x76BB3DC0). </summary>
        WorldViewMatrix = 1,
        /// <summary> The g_JointMatrixArray constant buffer (CRC: 0x88AA546A). </summary>
        JointMatrixArray = 2,
        /// <summary> The g_JointMatrixArrayPrev constant buffer (CRC: 0xB531360D). </summary>
        JointMatrixArrayPrev = 3,
        /// <summary> The g_WrinklessWeightRate constant buffer (CRC: 0x17FB799E). </summary>
        WrinklessWeightRate = 5,
        /// <summary> The g_AuraParam constant buffer (CRC: 0x07EF6FA3). </summary>
        AuraParam = 6,
        /// <summary> The g_InstancingMatrix constant buffer (CRC: 0x8413183B). </summary>
        InstancingMatrix = 11,
        /// <summary> The g_PrevInstancingMatrix constant buffer (CRC: 0xC38E361C). </summary>
        PrevInstancingMatrix = 12,
        /// <summary> The g_SelectionModelParameter constant buffer (CRC: 0x04543FA3). </summary>
        SelectionModelParameter = 13,
    }

    /// <summary> Indices of <see cref="ConstantSamplerIds"/> for well-known samplers/textures. </summary>
    public enum WellKnownSampler {
        /// <summary> The g_SamplerFinalColor sampler/texture (CRC: 0x8EA9DF48). </summary>
        SamplerFinalColor = 4,
        /// <summary> The g_CompositeCommonSampler sampler (CRC: 0x7FE24A4B). </summary>
        CompositeCommonSampler = 7,
        /// <summary> The g_SamplerAuraTexture texture (CRC: 0x07A92F70). </summary>
        SamplerAuraTexture = 8,
        /// <summary> The g_SamplerAuraTexture1 texture (CRC: 0x01DCD829). </summary>
        SamplerAuraTexture1 = 9,
        /// <summary> The g_SamplerAuraTexture2 texture (CRC: 0x98D58993). </summary>
        SamplerAuraTexture2 = 10,
        /// <summary> The g_SamplerNormal sampler/texture (CRC: 0x0C5EC1F1). </summary>
        SamplerNormal = 14,
        /// <summary> The g_SamplerIndex sampler/texture (CRC: 0x565F8FD8). </summary>
        SamplerIndex = 15,
        /// <summary> The g_SamplerViewPosition sampler/texture (CRC: 0xBC615663). </summary>
        SamplerViewPosition = 16,
        /// <summary> The g_SamplerDepthWithWater sampler/texture (CRC: 0xE4B2A798). </summary>
        SamplerDepthWithWater = 17,
    }

    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_LightDirection constant buffer (CRC: 0xEF4E7491). </summary>
    [FieldOffset(0x8), Obsolete("Use ConstantSamplerIds[(int)WellKnownConstant.LightDirection]")] public uint LightDirectionId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_WorldViewMatrix constant buffer (CRC: 0x76BB3DC0). </summary>
    [FieldOffset(0xC), Obsolete("Use ConstantSamplerIds[(int)WellKnownConstant.WorldViewMatrix]")] public uint WorldViewMatrixId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_JointMatrixArray constant buffer (CRC: 0x88AA546A). </summary>
    [FieldOffset(0x10), Obsolete("Use ConstantSamplerIds[(int)WellKnownConstant.JointMatrixArray]")] public uint JointMatrixArrayId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SelectionModelParameter constant buffer (CRC: 0x04543FA3). </summary>
    [FieldOffset(0x3C), Obsolete("Use ConstantSamplerIds[(int)WellKnownConstant.SelectionModelParameter]")] public uint SelectionModelParameterId;

    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SamplerNormal sampler/texture (CRC: 0x0C5EC1F1). </summary>
    [FieldOffset(0x40), Obsolete("Use ConstantSamplerIds[(int)WellKnownSampler.SamplerNormal]")] public uint SamplerNormalId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SamplerIndex sampler/texture (CRC: 0x565F8FD8). </summary>
    [FieldOffset(0x44), Obsolete("Use ConstantSamplerIds[(int)WellKnownSampler.SamplerIndex]")] public uint SamplerIndexId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SamplerViewPosition sampler/texture (CRC: 0xBC615663). </summary>
    [FieldOffset(0x48), Obsolete("Use ConstantSamplerIds[(int)WellKnownSampler.SamplerViewPosition]")] public uint SamplerViewPositionId;

    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray18<uint> _constantSamplerIds;

    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray18<ShaderSceneKey> _sceneKeys;

    [FieldOffset(0x170), FixedSizeArray] internal FixedSizeArray5<ShaderSubViewKey> _subViewKeys;

    [FieldOffset(0x1C0)] public ShaderCodeResourceHandle* CharacterSelectionModelVS;
    [FieldOffset(0x1C8)] public ShaderCodeResourceHandle* CharacterSelectionModelPS;
    [FieldOffset(0x1D0)] public TextureResourceHandle* DitherTexture;
    [FieldOffset(0x1D8)] public ShaderPackageResourceHandle* IrisShaderPackage;
    [FieldOffset(0x1E0)] public ShaderPackageResourceHandle* CharacterGlassShaderPackage;
    [FieldOffset(0x1E8)] public ShaderPackageResourceHandle* CharacterTransparencyShaderPackage;
    [FieldOffset(0x1F0)] public ShaderPackageResourceHandle* CharacterTattooShaderPackage;
    [FieldOffset(0x1F8)] public ShaderPackageResourceHandle* CharacterOcclusionShaderPackage;
    [FieldOffset(0x200)] public ShaderPackageResourceHandle* HairMaskShaderPackage;

    // At 0x238: pointer to an unknown ConstantBuffer of size 1 vector (0x10 bytes).
    // At 0x240, ..., 0x2B8: pointers to 16 unknown ConstantBuffers of size 4 vectors (0x40 bytes) each.

    [FieldOffset(0x2C0)] public JobSystem JobSystem; // Client::Graphics::JobSystem<Client::Graphics::Render::ModelRenderer>

    // This function, among other things, constructs an OnRenderMaterialParams struct with its params and calls CharacterBase.OnRenderMaterial with it (through some indirections - see Model.RenderMaterialCallback).
    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B7 20")]
    public partial ushort* OnRenderMaterial(ushort* outFlags, OnRenderModelParams* param, Material* material, uint materialIndex);
}

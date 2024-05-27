using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

[StructLayout(LayoutKind.Explicit, Size = 0x228)]
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

    [FieldOffset(0)] public void* Vtbl;

    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_LightDirection constant buffer (CRC: 0xEF4E7491). </summary>
    [FieldOffset(0x8)] public uint LightDirectionId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_WorldViewMatrix constant buffer (CRC: 0x76BB3DC0). </summary>
    [FieldOffset(0xC)] public uint WorldViewMatrixId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_JointMatrixArray constant buffer (CRC: 0x88AA546A). </summary>
    [FieldOffset(0x10)] public uint JointMatrixArrayId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SelectionModelParameter constant buffer (CRC: 0x04543FA3). </summary>
    [FieldOffset(0x14)] public uint SelectionModelParameterId;

    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SamplerNormal sampler/texture (CRC: 0x0C5EC1F1). </summary>
    [FieldOffset(0x18)] public uint SamplerNormalId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SamplerIndex sampler/texture (CRC: 0x565F8FD8). </summary>
    [FieldOffset(0x1C)] public uint SamplerIndexId;
    /// <summary> <see cref="ShaderPackage.ConstantSamplerUnknown.Id"/> of the g_SamplerViewPosition sampler/texture (CRC: 0xBC615663). </summary>
    [FieldOffset(0x20)] public uint SamplerViewPositionId;

    [FixedSizeArray<ShaderSceneKey>(6)]
    [FieldOffset(0x28)] public fixed byte SceneKeys[6 * ShaderSceneKey.Size];

    [FixedSizeArray<ShaderSubViewKey>(3)]
    [FieldOffset(0x88)] public fixed byte SubViewKeys[3 * ShaderSubViewKey.Size];

    [FieldOffset(0xB8)] public ShaderCodeResourceHandle* CharacterSelectionModelVS;
    [FieldOffset(0xC0)] public ShaderCodeResourceHandle* CharacterSelectionModelPS;
    [FieldOffset(0xC8)] public TextureResourceHandle* DitherTexture;
    [FieldOffset(0xD0)] public ShaderPackageResourceHandle* CharacterGlassShaderPackage;
    [FieldOffset(0xD8)] public ShaderCodeResourceHandle* CharacterMultiViewportGS;

    // At 0xE0: pointer to an unknown ConstantBuffer of size 1 vector (0x10 bytes).
    // At 0xE8, ..., 0x160: pointers to 16 unknown ConstantBuffers of size 4 vectors (0x40 bytes) each.

    [FieldOffset(0x168)] public JobSystem JobSystem; // Client::Graphics::JobSystem<Client::Graphics::Render::ModelRenderer>

    // This function, among other things, constructs an OnRenderMaterialParams struct with its params and calls CharacterBase.OnRenderMaterial with it (through some indirections - see Model.RenderMaterialCallback).
    [MemberFunction("E8 ?? ?? ?? ?? 80 7D ?? ?? 0F B7 08")]
    public partial ushort* OnRenderMaterial(ushort* outFlags, OnRenderModelParams* param, Material* material, uint materialIndex);
}

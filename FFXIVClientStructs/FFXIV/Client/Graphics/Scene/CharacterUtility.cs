using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::CharacterUtility
//   Client::Graphics::Singleton
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x590)]
public unsafe partial struct CharacterUtility {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 83 B9", 3, isPointer: true)]
    public static partial CharacterUtility* Instance();

    [FieldOffset(0x8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray115<Pointer<ResourceHandle>> _resourceHandles;
    [FieldOffset(0x08)] public EquipmentParameterResourceHandle* EquipmentParameterResourceHandle;
    [FieldOffset(0x10)] public EquipmentVfxParameterResourceHandle* EquipmentVfxParameterResourceHandle;
    [FieldOffset(0x18)] public GimmickParameterResourceHandle* GimmickParameterResourceHandle;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray28<Pointer<EquipmentDeformerParameterResourceHandle>> _equipmentDeformerParameterResourceHandles;
    [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray28<Pointer<EquipmentDeformerParameterResourceHandle>> _accessoryDeformerParameterResourceHandles;
    [FieldOffset(0x1E0)] public WeaponAttachOffsetExistResourceHandle* AttachOffsetExistResourceHandle;
    [FieldOffset(0x1E8)] public WeaponTypeDataResourceHandle* WeaponTypeAttachResourceHandle;
    [FieldOffset(0x1F0)] public WeaponTypeDataResourceHandle* WeaponTypeMotionResourceHandle;
    [FieldOffset(0x1F8)] public WeaponTypeDataResourceHandle* WeaponTypeSeResourceHandle; // Sound effects?
    [FieldOffset(0x200)] public PreBoneDeformerResourceHandle* HumanBoneDeformerResourceHandle;
    [FieldOffset(0x208), FixedSizeArray] internal FixedSizeArray7<Pointer<SkeletonResourceHandle>> _retargetSkeletonResourceHandles; // human base skeletons 0101, 0104, 0201, 0501, 0601, 0901, 1101
    [FieldOffset(0x240)] public CharaMakeParameterResourceHandle* HumanParameterResourceHandle;
    [FieldOffset(0x248)] public ExSkeletonTableResourceHandle* FaceSkeletonTemplateResourceHandle;
    [FieldOffset(0x250)] public ExSkeletonTableResourceHandle* HairSkeletonTemplateResourceHandle;
    [FieldOffset(0x258)] public ExSkeletonTableResourceHandle* HeadSkeletonTemplateResourceHandle;
    [FieldOffset(0x260)] public ExSkeletonTableResourceHandle* BodySkeletonTemplateResourceHandle;
    [FieldOffset(0x268)] public TextureResourceHandle* DummyTextureResourceHandle;
    [FieldOffset(0x270)] public TextureResourceHandle* BlackTextureResourceHandle;
    [FieldOffset(0x278)] public TextureResourceHandle* WhiteTextureResourceHandle;
    [FieldOffset(0x280)] public TextureResourceHandle* TransparentTextureResourceHandle;
    [FieldOffset(0x288)] public TextureResourceHandle* LegacyTattooTextureResourceHandle;
    [FieldOffset(0x290)] public TextureResourceHandle* TileOrbArrayTextureResourceHandle;
    [FieldOffset(0x298)] public TextureResourceHandle* TileNormArrayTextureResourceHandle;
    [FieldOffset(0x2A0)] public ShaderPackageResourceHandle* IrisShaderPackageResourceHandle;
    [FieldOffset(0x2A8)] public ShaderPackageResourceHandle* SkinShaderPackageResourceHandle;
    [FieldOffset(0x2B0)] public ShaderPackageResourceHandle* StockingsShaderPackageResourceHandle;
    [FieldOffset(0x2B8)] public ShaderPackageResourceHandle* LegacyCharacterShaderPackageResourceHandle;
    [FieldOffset(0x2C0)] public PapLoadTableResourceHandle* PapLoadTableResourceHandle;
    [FieldOffset(0x2C8)] public AnimationExchangeTableResourceHandle* AnimationExchangeTableResourceHandle;
    [FieldOffset(0x2D0)] public MotionLineTableResourceHandle* MotionLineTableResourceHandle;
    [FieldOffset(0x2D8)] public SkeletonResourceHandle* MaterialAnimationSkeletonResourceHandle;
    [FieldOffset(0x2E0), FixedSizeArray] internal FixedSizeArray4<Pointer<AnimationWorkTableResourceHandle>> _animationWorkTables; // Human, monster, demihuman, weapon
    [FieldOffset(0x300)] public StainingTemplateResourceHandle* StainingTemplateGudResourceHandle;
    [FieldOffset(0x308)] public StainingTemplateResourceHandle* StainingTemplateResourceHandle;
    [FieldOffset(0x310)] public TextureResourceHandle* SphereMapArrayTextureResourceHandle;
    [FieldOffset(0x318), FixedSizeArray] internal FixedSizeArray1<Pointer<ExtraSkeletonLoadResourceHandle>> _extraSkeletonLoadResourceHandles; // Just one element for weapons
    [FieldOffset(0x320)] public FacialParameterEditResourceHandle* FacialParameterEditResourceHandle;
    [FieldOffset(0x328)] public EyeAnimationResourceHandle* EyeAnimationResourceHandle;
    [FieldOffset(0x330), FixedSizeArray] internal FixedSizeArray7<Pointer<KineDriverLoadResourceHandle>> _kineDriverLoadResourceHandles; // human base, human equipment, human face, human hair, demihuman, monster, weapon
    [FieldOffset(0x368), FixedSizeArray] internal FixedSizeArray7<Pointer<BonamikLoadResourceHandle>> _bonamikLoadResourceHandles; // human base, human equipment, human face, human hair, demihuman, monster, weapon

    [FieldOffset(0x3E0)] public MaterialResourceHandle* ReaperEyeMaterialResourceHandle;
    [FieldOffset(0x3E8)] public Material* ReaperEyeMaterial;
    [FieldOffset(0x3F8)] public ConstantBuffer* LegacyBodyDecalColorCBuffer;
    [FieldOffset(0x400)] public ConstantBuffer* FreeCompanyCrestColorCBuffer;

    public ConstantBufferPointer<Vector4> LegacyBodyDecalColorTypedCBuffer => new(LegacyBodyDecalColorCBuffer);
    public ConstantBufferPointer<Vector4> FreeCompanyCrestColorTypedCBuffer => new(FreeCompanyCrestColorCBuffer);
}

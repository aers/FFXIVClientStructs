using System.Text;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.Graphics.Physics;
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::CharacterBase
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
// base class for graphics objects representing characters (human, demihuman, monster, and weapons)
[GenerateInterop(isInherited: true)]
[Inherits<DrawObject>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 89 AF ?? ?? ?? ?? 48 89 07 48 8D 9F ?? ?? ?? ?? B8 ?? ?? ?? ?? 89 AF ?? ?? ?? ?? 66 89 87 ?? ?? ?? ?? 48 8B CB", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xA20)]
public unsafe partial struct CharacterBase {
    public const int PathBufferSize = 260;
    public const int MaterialsPerSlot = 10;

    [FieldOffset(0x90)] public byte UnkFlags_01;
    [FieldOffset(0x91)] public byte UnkFlags_02;
    [FieldOffset(0x92)] public byte UnkFlags_03;
    [FieldOffset(0x98)] public int SlotCount; // model slots
    [FieldOffset(0xA0)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton

    [FieldOffset(0xA8)] public Model** Models; // size = SlotCount

    [FieldOffset(0xD0)] public Attach Attach;
    [FieldOffset(0x148)] public void* PostBoneDeformer; // Client::Graphics::Scene::PostBoneDeformer ptr

    public bool IsChangingVisor {
        get => (UnkFlags_01 & 0x80) == 0x80;
        set => UnkFlags_01 = (byte)(value ? UnkFlags_01 | 0x80 : UnkFlags_01 & ~0x80);
    }

    public bool VisorToggled {
        get => (UnkFlags_01 & 0x40) == 0x40;
        set => UnkFlags_01 = (byte)(value ? UnkFlags_01 | 0x40 : UnkFlags_01 & ~0x40);
    }

    public bool HasUmbrella {
        get => (UnkFlags_03 & 0x01) == 0x01;
        set => UnkFlags_03 = (byte)(value ? UnkFlags_03 | 0x01 : UnkFlags_03 & ~0x01);
    }


    [FieldOffset(0x150)]
    public BonePhysicsModule* BonePhysicsModule; // Client::Graphics::Physics::BonePhysicsModule ptr

    [FieldOffset(0x170)] public ModelRenderer.Callback RenderModelCallback;
    [FieldOffset(0x190)] public ModelRenderer.Callback RenderMaterialCallback;
    [FieldOffset(0x1B0)] public ModelRenderer.Callback UnkCallback3;

    [FieldOffset(0x224)] public float VfxScale;
    [FieldOffset(0x270)] public ConstantBuffer* CharacterDataCBuffer; // Size has been observed to be 0xB0, contents may be InstanceParameter
    [FieldOffset(0x278)] public ConstantBuffer* UnkCBuffer; // Size is also 0xB0

    [FieldOffset(0x288)] public Texture** ColorTableTextures; // each one corresponds to a material, size = SlotCount * MaterialsPerSlot

    [FieldOffset(0x290)] public Vector4 Tint;

    [FieldOffset(0x2E0)] public float WeatherWetness;  // Set to 1.0f when raining and not covered or umbrella'd
    [FieldOffset(0x2E4)] public float SwimmingWetness; // Set to 1.0f when in water
    [FieldOffset(0x2E8)] public float WetnessDepth;    // Set to ~character height in GPose and higher values when swimming or diving.
    [FieldOffset(0x2EC)] public float ForcedWetness;   // Set by vfunc 51 when using GPose, gets set to 0 in UpdateWetness every frame.

    // next few fields are used temporarily when loading the render object and cleared after load
    [FieldOffset(0x2F8)] public uint HasModelInSlotLoaded; // tracks which slots have loaded models into staging

    [FieldOffset(0x2FC)] public uint HasModelFilesInSlotLoaded; // tracks which slots have loaded materials, etc into staging

    [FieldOffset(0x300)] public void* TempData; // struct with temporary data (size = 0x88)

    [FieldOffset(0x308)] public void* TempSlotData; // struct with temporary data for each slot (size = 0x88 * slot count)

    [FieldOffset(0x350)] public Material** Materials; // size = SlotCount * MaterialsPerSlot

    [FieldOffset(0x358)] public void* EID; // Client::System::Resource::Handle::ElementIdResourceHandle - EID file for base skeleton

    [FieldOffset(0x360)] public void** IMCArray; // array of Client::System::Resource::Handle::ImageChangeDataResourceHandle ptrs size = SlotCount - IMC file for model in slot

    [FieldOffset(0x3D8)] internal FixedSizeArray5<SkeletonAnimationContainer> _skeletonAnimationContainers; // tentative name

    [FieldOffset(0x940)] public SkeletonResourceHandle* MaterialAnimationSkeleton;

    [FieldOffset(0x948)] public ResourceHandle** MaterialAnimationPacks;

    [FieldOffset(0x958)] public byte AnimationVariant; // the "a%04d" part in "%s/animation/a%04d/%s/%s.pap" in LoadAnimation

    public Span<Pointer<Model>> ModelsSpan => new(Models, SlotCount);
    public Span<Pointer<Texture>> ColorTableTexturesSpan => new(ColorTableTextures, SlotCount * MaterialsPerSlot);
    public Span<Pointer<Material>> MaterialsSpan => new(Materials, SlotCount * MaterialsPerSlot);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F 08 48 8B D0 4C 8B 01")]
    public static partial CharacterBase* Create(uint modelId, CustomizeData* customize, EquipmentModelId* equipData /* 10 times, 80 byte */, byte unk);

    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 01 74 3A 40 F6 C7 04 75 27 48 85 DB 74 2F 48 8B 05 ?? ?? ?? ?? 48 8B D3 48 8B 48 30")]
    public partial void Destroy();

    [VirtualFunction(50)]
    public partial ModelType GetModelType();

    public enum ModelType : byte {
        Human = 1,
        DemiHuman = 2,
        Monster = 3,
        Weapon = 4,
    }

    [VirtualFunction(63)]
    public partial nint OnRenderModel(Model* model);

    [VirtualFunction(64)]
    public partial nint OnRenderMaterial(ModelRenderer.OnRenderMaterialParams* param);

    [VirtualFunction(69)]
    public partial ulong FlagSlotForUpdate(uint slot, EquipmentModelId* slotBytes);

    [VirtualFunction(75)]
    public partial CStringPointer ResolveRootPath(byte* pathBuffer, nuint pathBufferSize);

    [VirtualFunction(76)]
    public partial CStringPointer ResolveSklbPath(byte* pathBuffer, nuint pathBufferSize, uint partialSkeletonIndex);

    [VirtualFunction(77)]
    public partial CStringPointer ResolveMdlPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex);

    [VirtualFunction(78)]
    public partial CStringPointer ResolveSkpPath(byte* pathBuffer, nuint pathBufferSize, uint partialSkeletonIndex);

    [VirtualFunction(79)]
    public partial CStringPointer ResolvePhybPath(byte* pathBuffer, nuint pathBufferSize, uint partialSkeletonIndex);

    [VirtualFunction(84)]
    public partial CStringPointer ResolvePapPath(byte* pathBuffer, nuint pathBufferSize, uint unkAnimationIndex, byte* animationName);

    [VirtualFunction(85)]
    public partial CStringPointer ResolveTmbPath(byte* pathBuffer, nuint pathBufferSize, byte* timelineName);

    [VirtualFunction(87)]
    public partial CStringPointer ResolveMaterialPapPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex, uint unkSId);

    [VirtualFunction(89)]
    public partial CStringPointer ResolveImcPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex);

    /// <remarks>
    /// Caveat: this method will dereference a null pointer if determining the MTRL file path involves an IMC lookup and it is not called at the "right" moment.
    /// </remarks>
    [VirtualFunction(90)]
    public partial CStringPointer ResolveMtrlPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex, byte* mtrlFileName);

    [VirtualFunction(91)]
    public partial CStringPointer ResolveSkinMtrlPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex);

    [VirtualFunction(92)]
    public partial CStringPointer ResolveDecalPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex);

    [VirtualFunction(93)]
    public partial CStringPointer ResolveVfxPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex, uint* unkOutParam);

    [VirtualFunction(94)]
    public partial CStringPointer ResolveEidPath(byte* pathBuffer, nuint pathBufferSize);

    #region Resolve*Path(Span<byte>) overloads
    public ReadOnlySpan<byte> ResolveRootPath(Span<byte> pathBuffer) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveRootPath(pBuffer, (nuint)pathBuffer.Length);
    }

    public ReadOnlySpan<byte> ResolveSklbPath(Span<byte> pathBuffer, uint partialSkeletonIndex) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveSklbPath(pBuffer, (nuint)pathBuffer.Length, partialSkeletonIndex);
    }

    public ReadOnlySpan<byte> ResolveMdlPath(Span<byte> pathBuffer, uint slotIndex) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveMdlPath(pBuffer, (nuint)pathBuffer.Length, slotIndex);
    }

    public ReadOnlySpan<byte> ResolveSkpPath(Span<byte> pathBuffer, uint partialSkeletonIndex) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveSkpPath(pBuffer, (nuint)pathBuffer.Length, partialSkeletonIndex);
    }

    public ReadOnlySpan<byte> ResolvePhybPath(Span<byte> pathBuffer, uint partialSkeletonIndex) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolvePhybPath(pBuffer, (nuint)pathBuffer.Length, partialSkeletonIndex);
    }

    public ReadOnlySpan<byte> ResolvePapPath(Span<byte> pathBuffer, uint unkAnimationIndex, ReadOnlySpan<byte> animationName) {
        fixed (byte* pAnimationName = animationName)
        fixed (byte* pBuffer = pathBuffer)
            return ResolvePapPath(pBuffer, (nuint)pathBuffer.Length, unkAnimationIndex, pAnimationName);
    }

    public ReadOnlySpan<byte> ResolveTmbPath(Span<byte> pathBuffer, ReadOnlySpan<byte> timelineName) {
        fixed (byte* pTimelineName = timelineName)
        fixed (byte* pBuffer = pathBuffer)
            return ResolveTmbPath(pBuffer, (nuint)pathBuffer.Length, pTimelineName);
    }

    public ReadOnlySpan<byte> ResolveMaterialPapPath(Span<byte> pathBuffer, uint slotIndex, uint unkSId) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveMaterialPapPath(pBuffer, (nuint)pathBuffer.Length, slotIndex, unkSId);
    }

    public ReadOnlySpan<byte> ResolveImcPath(Span<byte> pathBuffer, uint slotIndex) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveImcPath(pBuffer, (nuint)pathBuffer.Length, slotIndex);
    }

    /// <remarks>
    /// Caveat: this method will dereference a null pointer if determining the MTRL file path involves an IMC lookup and it is not called at the "right" moment.
    /// </remarks>
    public ReadOnlySpan<byte> ResolveMtrlPath(Span<byte> pathBuffer, uint slotIndex, ReadOnlySpan<byte> mtrlFileName) {
        fixed (byte* pMtrlFileName = mtrlFileName)
        fixed (byte* pBuffer = pathBuffer)
            return ResolveMtrlPath(pBuffer, (nuint)pathBuffer.Length, slotIndex, pMtrlFileName);
    }

    public ReadOnlySpan<byte> ResolveSkinMtrlPath(Span<byte> pathBuffer, uint slotIndex) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveSkinMtrlPath(pBuffer, (nuint)pathBuffer.Length, slotIndex);
    }

    public ReadOnlySpan<byte> ResolveDecalPath(Span<byte> pathBuffer, uint slotIndex) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveDecalPath(pBuffer, (nuint)pathBuffer.Length, slotIndex);
    }

    public ReadOnlySpan<byte> ResolveVfxPath(Span<byte> pathBuffer, uint slotIndex, out uint unkOutParam) {
        fixed (uint* pUnkOutParam = &unkOutParam)
        fixed (byte* pBuffer = pathBuffer)
            return ResolveVfxPath(pBuffer, (nuint)pathBuffer.Length, slotIndex, pUnkOutParam);
    }

    public ReadOnlySpan<byte> ResolveEidPath(Span<byte> pathBuffer) {
        fixed (byte* pBuffer = pathBuffer)
            return ResolveEidPath(pBuffer, (nuint)pathBuffer.Length);
    }
    #endregion

    #region Resolve*Path(string) overloads
    public string ResolveRootPath() {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveRootPath(pathBuffer));
    }

    public string ResolveSklbPath(uint partialSkeletonIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveSklbPath(pathBuffer, partialSkeletonIndex));
    }

    public string ResolveMdlPath(uint slotIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveMdlPath(pathBuffer, slotIndex));
    }

    public string ResolveSkpPath(uint partialSkeletonIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveSkpPath(pathBuffer, partialSkeletonIndex));
    }

    public string ResolvePhybPath(uint partialSkeletonIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolvePhybPath(pathBuffer, partialSkeletonIndex));
    }

    public string ResolvePapPath(uint unkAnimationIndex, string animationName) {
        var animationNameByteCount = Encoding.UTF8.GetByteCount(animationName);
        Span<byte> animationNameBytes = animationNameByteCount <= 511 ? stackalloc byte[512] : new byte[animationNameByteCount + 1];
        Encoding.UTF8.GetBytes(animationName, animationNameBytes);
        animationNameBytes[animationNameByteCount] = 0;

        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolvePapPath(pathBuffer, unkAnimationIndex, animationNameBytes));
    }

    public string ResolveTmbPath(string timelineName) {
        var timelineNameByteCount = Encoding.UTF8.GetByteCount(timelineName);
        Span<byte> timelineNameBytes = timelineNameByteCount <= 511 ? stackalloc byte[512] : new byte[timelineNameByteCount + 1];
        Encoding.UTF8.GetBytes(timelineName, timelineNameBytes);
        timelineNameBytes[timelineNameByteCount] = 0;

        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveTmbPath(pathBuffer, timelineNameBytes));
    }

    public string ResolveMaterialPapPath(uint slotIndex, uint unkSId) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveMaterialPapPath(pathBuffer, slotIndex, unkSId));
    }

    public string ResolveImcPath(uint slotIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveImcPath(pathBuffer, slotIndex));
    }

    /// <remarks>
    /// Caveat: this method will dereference a null pointer if determining the MTRL file path involves an IMC lookup and it is not called at the "right" moment.
    /// </remarks>
    public string ResolveMtrlPath(uint slotIndex, string mtrlFileName) {
        var mtrlFileNameByteCount = Encoding.UTF8.GetByteCount(mtrlFileName);
        Span<byte> mtrlFileNameBytes = mtrlFileNameByteCount <= 511 ? stackalloc byte[512] : new byte[mtrlFileNameByteCount + 1];
        Encoding.UTF8.GetBytes(mtrlFileName, mtrlFileNameBytes);
        mtrlFileNameBytes[mtrlFileNameByteCount] = 0;

        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveMtrlPath(pathBuffer, slotIndex, mtrlFileNameBytes));
    }

    public string ResolveSkinMtrlPath(uint slotIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveSkinMtrlPath(pathBuffer, slotIndex));
    }

    public string ResolveDecalPath(uint slotIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveDecalPath(pathBuffer, slotIndex));
    }

    public string ResolveVfxPath(uint slotIndex, out uint unkOutParam) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveVfxPath(pathBuffer, slotIndex, out unkOutParam));
    }

    public string ResolveEidPath() {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveEidPath(pathBuffer));
    }
    #endregion

    [VirtualFunction(108)]
    public partial byte IsFreeCompanyCrestVisibleOnSlot(byte slot);

    [VirtualFunction(109)]
    public partial void SetFreeCompanyCrestVisibleOnSlot(byte slot, byte isVisible);

    [VirtualFunction(110)]
    public partial void SetFreeCompanyCrest(Texture* freeCompanyCrest);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct SkeletonAnimationContainer { // tentative name
        [FieldOffset(0)] public SkeletonResourceHandle* PartialSkeleton;
        [FieldOffset(0x8)] public StdVector<Pointer<ResourceHandle>> PapVector1; // not well-understood yet
        [FieldOffset(0x20)] public StdVector<Pointer<ResourceHandle>> PapVector2;
        [FieldOffset(0x38)] public StdVector<Pointer<ResourceHandle>> PapVector3;

        [FieldOffset(0xF8)] public ResourceHandle* AnimationExchangeTable;
    }
}

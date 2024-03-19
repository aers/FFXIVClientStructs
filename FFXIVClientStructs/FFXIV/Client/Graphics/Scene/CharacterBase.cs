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
// ctor "E8 ?? ?? ?? ?? 33 C9 48 8D 05 ?? ?? ?? ?? 48 89 03 48 B8"
// base class for graphics objects representing characters (human, demihuman, monster, and weapons)
[StructLayout(LayoutKind.Explicit, Size = 0x8F0)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 07 48 8d 9f d0 00 00 00", 3)]
public unsafe partial struct CharacterBase {
    public const int PathBufferSize = 260;

    [FieldOffset(0x0)] public DrawObject DrawObject;
    [FieldOffset(0x90)] public byte UnkFlags_01;
    [FieldOffset(0x91)] public byte UnkFlags_02;
    [FieldOffset(0x92)] public byte UnkFlags_03;
    [FieldOffset(0x98)] public int SlotCount; // model slots
    [FieldOffset(0xA0)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton

    [FieldOffset(0xA8)] public Model** Models; // size = SlotCount
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

    [FieldOffset(0x158)] public ModelRenderer.Callback RenderModelCallback;
    [FieldOffset(0x178)] public ModelRenderer.Callback RenderMaterialCallback;
    [FieldOffset(0x198)] public ModelRenderer.Callback UnkCallback3;

    [FieldOffset(0x224)] public float VfxScale;
    [FieldOffset(0x240)] public ConstantBuffer* CharacterDataCBuffer; // Size has been observed to be 0x50, contents may be InstanceParameter

    [FieldOffset(0x258)] public Texture** ColorTableTextures; // each one corresponds to a material, size = SlotCount * 4

    [FieldOffset(0x260)] public Vector3 Tint; // TODO: Should be a Vector4 with next API bump - color tint for the chara base

    [FieldOffset(0x2B0)] public float WeatherWetness;  // Set to 1.0f when raining and not covered or umbrella'd
    [FieldOffset(0x2B4)] public float SwimmingWetness; // Set to 1.0f when in water
    [FieldOffset(0x2B8)] public float WetnessDepth;    // Set to ~character height in GPose and higher values when swimming or diving.
    [FieldOffset(0x2BC)] public float ForcedWetness;   // Set by vfunc 51 when using GPose, gets set to 0 in UpdateWetness every frame.

    // next few fields are used temporarily when loading the render object and cleared after load
    [FieldOffset(0x2C8)] public uint HasModelInSlotLoaded; // tracks which slots have loaded models into staging

    [FieldOffset(0x2CC)] public uint HasModelFilesInSlotLoaded; // tracks which slots have loaded materials, etc into staging

    [FieldOffset(0x2D0)] public void* TempData; // struct with temporary data (size = 0x88)

    [FieldOffset(0x2D8)] public void* TempSlotData; // struct with temporary data for each slot (size = 0x88 * slot count)

    [FieldOffset(0x2E8)] public Material** Materials; // size = SlotCount * 4 (4 material per model max)

    [FieldOffset(0x2F0)] public void* EID; // Client::System::Resource::Handle::ElementIdResourceHandle - EID file for base skeleton

    [FieldOffset(0x2F8)] public void** IMCArray; // array of Client::System::Resource::Handle::ImageChangeDataResourceHandle ptrs size = SlotCount - IMC file for model in slot

    [FieldOffset(0x8E8)] public byte AnimationVariant; // the "a%04d" part in "%s/animation/a%04d/%s/%s.pap"

    public readonly Span<Pointer<Model>> ModelsSpan
        => new(Models, SlotCount);

    public readonly Span<Pointer<Texture>> ColorTableTexturesSpan
        => new(ColorTableTextures, SlotCount * 4);

    public readonly Span<Pointer<Material>> MaterialsSpan
        => new(Materials, SlotCount * 4);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4E 08 48 8B D0 4C 8B 01")]
    public static partial CharacterBase* Create(uint modelId, CustomizeData* customize, EquipmentModelId* equipData /* 10 times, 40 byte */, byte unk);

    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 01 74 3A 40 F6 C7 04 75 27 48 85 DB 74 2F 48 8B 05 ?? ?? ?? ?? 48 8B D3 48 8B 48 30")]
    public partial void Destroy();

    [MemberFunction("40 55 56 41 56 48 83 EC ?? 80 BA")]
    public partial Texture* PrepareColorTable(MaterialResourceHandle* material, byte stainId); // aka PrepareColorSet

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B DF 48 8B 0D")]
    public partial void ReadStainingTemplate(MaterialResourceHandle* material, byte stainId, Half* colorTable);

    [VirtualFunction(50)]
    public partial ModelType GetModelType();

    public enum ModelType : byte {
        Human = 1,
        DemiHuman = 2,
        Monster = 3,
        Weapon = 4,
    }

    [VirtualFunction(61)]
    public partial nint OnRenderModel(Model* model);

    [VirtualFunction(62)]
    public partial nint OnRenderMaterial(ModelRenderer.OnRenderMaterialParams* param);

    [VirtualFunction(67)]
    public partial ulong FlagSlotForUpdate(uint slot, EquipmentModelId* slotBytes);

    [VirtualFunction(71)]
    public readonly partial byte* ResolveRootPath(byte* pathBuffer, nuint pathBufferSize);

    [VirtualFunction(72)]
    public readonly partial byte* ResolveSklbPath(byte* pathBuffer, nuint pathBufferSize, uint partialSkeletonIndex);

    [VirtualFunction(73)]
    public readonly partial byte* ResolveMdlPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex);

    [VirtualFunction(74)]
    public readonly partial byte* ResolveSkpPath(byte* pathBuffer, nuint pathBufferSize, uint partialSkeletonIndex);

    [VirtualFunction(75)]
    public readonly partial byte* ResolvePhybPath(byte* pathBuffer, nuint pathBufferSize, uint partialSkeletonIndex);

    [VirtualFunction(76)]
    public readonly partial byte* ResolvePapPath(byte* pathBuffer, nuint pathBufferSize, uint unkAnimationIndex, byte* animationName);

    [VirtualFunction(77)]
    public readonly partial byte* ResolveTmbPath(byte* pathBuffer, nuint pathBufferSize, byte* timelineName);

    [VirtualFunction(79)]
    public readonly partial byte* ResolveMaterialPapPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex, uint unkSId);

    [VirtualFunction(81)]
    public readonly partial byte* ResolveImcPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex);

    /// <remarks>
    /// Caveat: this method will dereference a null pointer if determining the MTRL file path involves an IMC lookup and it is not called at the "right" moment.
    /// </remarks>
    [VirtualFunction(82)]
    public readonly partial byte* ResolveMtrlPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex, byte* mtrlFileName);

    [VirtualFunction(83)]
    public readonly partial byte* ResolveDecalPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex);

    [VirtualFunction(84)]
    public readonly partial byte* ResolveVfxPath(byte* pathBuffer, nuint pathBufferSize, uint slotIndex, uint* unkOutParam);

    [VirtualFunction(85)]
    public readonly partial byte* ResolveEidPath(byte* pathBuffer, nuint pathBufferSize);

    #region Resolve*Path(Span<byte>) overloads
    public readonly ReadOnlySpan<byte> ResolveRootPath(Span<byte> pathBuffer) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveRootPath(pBuffer, (nuint)pathBuffer.Length);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveSklbPath(Span<byte> pathBuffer, uint partialSkeletonIndex) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveSklbPath(pBuffer, (nuint)pathBuffer.Length, partialSkeletonIndex);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveMdlPath(Span<byte> pathBuffer, uint slotIndex) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveMdlPath(pBuffer, (nuint)pathBuffer.Length, slotIndex);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveSkpPath(Span<byte> pathBuffer, uint partialSkeletonIndex) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveSkpPath(pBuffer, (nuint)pathBuffer.Length, partialSkeletonIndex);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolvePhybPath(Span<byte> pathBuffer, uint partialSkeletonIndex) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolvePhybPath(pBuffer, (nuint)pathBuffer.Length, partialSkeletonIndex);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolvePapPath(Span<byte> pathBuffer, uint unkAnimationIndex, ReadOnlySpan<byte> animationName) {
        byte* result;
        fixed (byte* pAnimationName = animationName)
        fixed (byte* pBuffer = pathBuffer)
            result = ResolvePapPath(pBuffer, (nuint)pathBuffer.Length, unkAnimationIndex, pAnimationName);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveTmbPath(Span<byte> pathBuffer, ReadOnlySpan<byte> timelineName) {
        byte* result;
        fixed (byte* pTimelineName = timelineName)
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveTmbPath(pBuffer, (nuint)pathBuffer.Length, pTimelineName);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveMaterialPapPath(Span<byte> pathBuffer, uint slotIndex, uint unkSId) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveMaterialPapPath(pBuffer, (nuint)pathBuffer.Length, slotIndex, unkSId);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveImcPath(Span<byte> pathBuffer, uint slotIndex) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveImcPath(pBuffer, (nuint)pathBuffer.Length, slotIndex);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    /// <remarks>
    /// Caveat: this method will dereference a null pointer if determining the MTRL file path involves an IMC lookup and it is not called at the "right" moment.
    /// </remarks>
    public readonly ReadOnlySpan<byte> ResolveMtrlPath(Span<byte> pathBuffer, uint slotIndex, ReadOnlySpan<byte> mtrlFileName) {
        byte* result;
        fixed (byte* pMtrlFileName = mtrlFileName)
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveMtrlPath(pBuffer, (nuint)pathBuffer.Length, slotIndex, pMtrlFileName);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveDecalPath(Span<byte> pathBuffer, uint slotIndex) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveDecalPath(pBuffer, (nuint)pathBuffer.Length, slotIndex);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveVfxPath(Span<byte> pathBuffer, uint slotIndex, out uint unkOutParam) {
        byte* result;
        fixed (uint* pUnkOutParam = &unkOutParam)
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveVfxPath(pBuffer, (nuint)pathBuffer.Length, slotIndex, pUnkOutParam);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }

    public readonly ReadOnlySpan<byte> ResolveEidPath(Span<byte> pathBuffer) {
        byte* result;
        fixed (byte* pBuffer = pathBuffer)
            result = ResolveEidPath(pBuffer, (nuint)pathBuffer.Length);
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(result);
    }
    #endregion

    #region Resolve*Path(string) overloads
    public readonly string ResolveRootPath() {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveRootPath(pathBuffer));
    }

    public readonly string ResolveSklbPath(uint partialSkeletonIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveSklbPath(pathBuffer, partialSkeletonIndex));
    }

    public readonly string ResolveMdlPath(uint slotIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveMdlPath(pathBuffer, slotIndex));
    }

    public readonly string ResolveSkpPath(uint partialSkeletonIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveSkpPath(pathBuffer, partialSkeletonIndex));
    }

    public readonly string ResolvePhybPath(uint partialSkeletonIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolvePhybPath(pathBuffer, partialSkeletonIndex));
    }

    public readonly string ResolvePapPath(uint unkAnimationIndex, string animationName) {
        var animationNameByteCount = Encoding.UTF8.GetByteCount(animationName);
        Span<byte> animationNameBytes = animationNameByteCount <= 512 ? stackalloc byte[animationNameByteCount + 1] : new byte[animationNameByteCount + 1];
        Encoding.UTF8.GetBytes(animationName, animationNameBytes);
        animationNameBytes[animationNameByteCount] = 0;

        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolvePapPath(pathBuffer, unkAnimationIndex, animationNameBytes));
    }

    public readonly string ResolveTmbPath(string timelineName) {
        var timelineNameByteCount = Encoding.UTF8.GetByteCount(timelineName);
        Span<byte> timelineNameBytes = timelineNameByteCount <= 512 ? stackalloc byte[timelineNameByteCount + 1] : new byte[timelineNameByteCount + 1];
        Encoding.UTF8.GetBytes(timelineName, timelineNameBytes);
        timelineNameBytes[timelineNameByteCount] = 0;

        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveTmbPath(pathBuffer, timelineNameBytes));
    }

    public readonly string ResolveMaterialPapPath(uint slotIndex, uint unkSId) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveMaterialPapPath(pathBuffer, slotIndex, unkSId));
    }

    public readonly string ResolveImcPath(uint slotIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveImcPath(pathBuffer, slotIndex));
    }

    /// <remarks>
    /// Caveat: this method will dereference a null pointer if determining the MTRL file path involves an IMC lookup and it is not called at the "right" moment.
    /// </remarks>
    public readonly string ResolveMtrlPath(uint slotIndex, string mtrlFileName) {
        var mtrlFileNameByteCount = Encoding.UTF8.GetByteCount(mtrlFileName);
        Span<byte> mtrlFileNameBytes = mtrlFileNameByteCount <= 512 ? stackalloc byte[mtrlFileNameByteCount + 1] : new byte[mtrlFileNameByteCount + 1];
        Encoding.UTF8.GetBytes(mtrlFileName, mtrlFileNameBytes);
        mtrlFileNameBytes[mtrlFileNameByteCount] = 0;

        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveMtrlPath(pathBuffer, slotIndex, mtrlFileNameBytes));
    }

    public readonly string ResolveDecalPath(uint slotIndex) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveDecalPath(pathBuffer, slotIndex));
    }

    public readonly string ResolveVfxPath(uint slotIndex, out uint unkOutParam) {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveVfxPath(pathBuffer, slotIndex, out unkOutParam));
    }

    public readonly string ResolveEidPath() {
        Span<byte> pathBuffer = stackalloc byte[PathBufferSize];
        return Encoding.UTF8.GetString(ResolveEidPath(pathBuffer));
    }
    #endregion

    [VirtualFunction(95)]
    public readonly partial byte IsFreeCompanyCrestVisibleOnSlot(byte slot);

    [VirtualFunction(96)]
    public partial void SetFreeCompanyCrestVisibleOnSlot(byte slot, byte isVisible);

    [VirtualFunction(97)]
    public partial void SetFreeCompanyCrest(Texture* freeCompanyCrest);
}

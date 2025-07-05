using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Shader;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Human
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<CharacterBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xCD0)]
public unsafe partial struct Human {
    [FieldOffset(0xA20)] public CustomizeData Customize;
    [FieldOffset(0xA3C)] public uint SlotNeedsUpdateBitfield;
    [FieldOffset(0xA40)] public EquipmentModelId Head;
    [FieldOffset(0xA48)] public EquipmentModelId Top;
    [FieldOffset(0xA50)] public EquipmentModelId Arms;
    [FieldOffset(0xA58)] public EquipmentModelId Legs;
    [FieldOffset(0xA60)] public EquipmentModelId Feet;
    [FieldOffset(0xA68)] public EquipmentModelId Ear;
    [FieldOffset(0xA70)] public EquipmentModelId Neck;
    [FieldOffset(0xA78)] public EquipmentModelId Wrist;
    [FieldOffset(0xA80)] public EquipmentModelId RFinger;
    [FieldOffset(0xA88)] public EquipmentModelId LFinger;
    [FieldOffset(0xA90)] public EquipmentModelId Glasses0;
    [FieldOffset(0xA98)] public EquipmentModelId Glasses1;
    [FieldOffset(0xAA0)] public ushort RaceSexId; // cXXXX ID (0101, 0201, etc)
    [FieldOffset(0xAA2)] public ushort HairId; // hXXXX
    [FieldOffset(0xAA4)] public ushort FaceId; // fXXXX ID
    [FieldOffset(0xAA6)] public ushort TailEarId; // tXXXX/zXXXX(viera)
    [FieldOffset(0xAA8)] public ushort FurId;

    [FieldOffset(0xAF8), CExportIgnore] private nint _slotDecalBase;
    [FieldOffset(0xAF8)] public TextureResourceHandle* HeadDecal;
    [FieldOffset(0xB00)] public TextureResourceHandle* TopDecal;
    [FieldOffset(0xB08)] public TextureResourceHandle* ArmsDecal;
    [FieldOffset(0xB10)] public TextureResourceHandle* LegsDecal;
    [FieldOffset(0xB18)] public TextureResourceHandle* FeetDecal;
    [FieldOffset(0xB20)] public TextureResourceHandle* EarDecal;
    [FieldOffset(0xB28)] public TextureResourceHandle* NeckDecal;
    [FieldOffset(0xB30)] public TextureResourceHandle* WristDecal;
    [FieldOffset(0xB38)] public TextureResourceHandle* RFingerDecal;
    [FieldOffset(0xB40)] public TextureResourceHandle* LFingerDecal;

    /// <remarks>
    /// | Type | Index |
    /// | ---- | ----- |
    /// | Head | 0     |
    /// | Top  | 1     |
    /// | Arms | 2     |
    /// | Legs | 3     |
    /// | Feet | 4     |
    /// </remarks>
    [FieldOffset(0xB48), FixedSizeArray] internal FixedSizeArray5<Pointer<MaterialResourceHandle>> _slotSkinMaterials;


    public ref TextureResourceHandle* SlotDecal(int slot) {
        if (slot is < 0 or > 9)
            throw new ArgumentOutOfRangeException(nameof(slot));
        return ref ((TextureResourceHandle**)Unsafe.AsPointer(ref _slotDecalBase))[slot];
    }

    public Span<Pointer<TextureResourceHandle>> SlotDecalsSpan
        => new(Unsafe.AsPointer(ref _slotDecalBase), 10);

    [FieldOffset(0xBF0)] public ConstantBuffer* CustomizeParameterCBuffer;
    [FieldOffset(0xBF8)] public ConstantBuffer* DecalColorCBuffer;

    public ConstantBufferPointer<CustomizeParameter> CustomizeParameterTypedCBuffer
        => new(CustomizeParameterCBuffer);
    public ConstantBufferPointer<Vector4> DecalColorTypedCBuffer
        => new(DecalColorCBuffer);

    [FieldOffset(0xC00)] public TextureResourceHandle* Decal;
    [FieldOffset(0xC08)] public TextureResourceHandle* LegacyBodyDecal;
    [FieldOffset(0xC10)] public Texture* FreeCompanyCrest;
    [FieldOffset(0xC18)] public uint SlotFreeCompanyCrestBitfield; // & 0x001 for slot 0, up to & 0x200 for slot 9

    [FieldOffset(0xC50)] public byte* ChangedEquipData;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 0F 57 FF")]
    public partial byte SetupVisor(ushort modelId, bool visorState);

    // Updates the customize array and, if not skipEquipment the equip array.
    // data needs to be 26 bytes if not skipEquipment and 66 bytes otherwise.
    // Returns false and does nothing if the given race, sex or body type is not equal to the current one, 
    // or if the race is Hyur and one tribe is Highlander and the other Midlander.
    [MemberFunction("E8 ?? ?? ?? ?? 83 BF ?? ?? ?? ?? ?? 75 34")]
    public partial bool UpdateDrawData(byte* data, bool skipEquipment);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 48 8B EA 48 81 C1")]
    public partial bool SetupFromCharacterData(byte* data);
}

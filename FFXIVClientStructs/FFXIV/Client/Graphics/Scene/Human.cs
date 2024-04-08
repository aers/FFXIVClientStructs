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
// ctor "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 28 48 8D 55 D7"
[StructLayout(LayoutKind.Explicit, Size = 0xA80)]
public unsafe partial struct Human {
    [FieldOffset(0x0)] public CharacterBase CharacterBase;
    [FieldOffset(0x8F0)] public CustomizeData Customize;
    [FieldOffset(0x90C)] public uint SlotNeedsUpdateBitfield;
    [FieldOffset(0x910)] public EquipmentModelId Head;
    [FieldOffset(0x914)] public EquipmentModelId Top;
    [FieldOffset(0x918)] public EquipmentModelId Arms;
    [FieldOffset(0x91C)] public EquipmentModelId Legs;
    [FieldOffset(0x920)] public EquipmentModelId Feet;
    [FieldOffset(0x924)] public EquipmentModelId Ear;
    [FieldOffset(0x928)] public EquipmentModelId Neck;
    [FieldOffset(0x92C)] public EquipmentModelId Wrist;
    [FieldOffset(0x930)] public EquipmentModelId RFinger;
    [FieldOffset(0x934)] public EquipmentModelId LFinger;
    [FieldOffset(0x938)] public ushort RaceSexId; // cXXXX ID (0101, 0201, etc)
    [FieldOffset(0x93A)] public ushort HairId; // hXXXX 
    [FieldOffset(0x93C)] public ushort FaceId; // fXXXX ID
    [FieldOffset(0x93E)] public ushort TailEarId; // tXXXX/zXXXX(viera)
    [FieldOffset(0x940)] public ushort FurId;

    [FieldOffset(0x980), CExportIgnore] private nint _slotDecalBase;
    [FieldOffset(0x980)] public TextureResourceHandle* HeadDecal;
    [FieldOffset(0x988)] public TextureResourceHandle* TopDecal;
    [FieldOffset(0x990)] public TextureResourceHandle* ArmsDecal;
    [FieldOffset(0x998)] public TextureResourceHandle* LegsDecal;
    [FieldOffset(0x9A0)] public TextureResourceHandle* FeetDecal;
    [FieldOffset(0x9A8)] public TextureResourceHandle* EarDecal;
    [FieldOffset(0x9B0)] public TextureResourceHandle* NeckDecal;
    [FieldOffset(0x9B8)] public TextureResourceHandle* WristDecal;
    [FieldOffset(0x9C0)] public TextureResourceHandle* RFingerDecal;
    [FieldOffset(0x9C8)] public TextureResourceHandle* LFingerDecal;

    public ref TextureResourceHandle* SlotDecal(int slot) {
        if (slot < 0 || slot > 9)
            throw new ArgumentOutOfRangeException(nameof(slot));
        return ref ((TextureResourceHandle**)Unsafe.AsPointer(ref _slotDecalBase))[slot];
    }

    public Span<Pointer<TextureResourceHandle>> SlotDecalsSpan
        => new(Unsafe.AsPointer(ref _slotDecalBase), 10);

    [FieldOffset(0x9D8)] public ConstantBuffer* CustomizeParameterCBuffer;
    [FieldOffset(0x9E0)] public ConstantBuffer* DecalColorCBuffer;

    public readonly ConstantBufferPointer<CustomizeParameter> CustomizeParameterTypedCBuffer
        => new(CustomizeParameterCBuffer);
    public readonly ConstantBufferPointer<Vector4> DecalColorTypedCBuffer
        => new(DecalColorCBuffer);

    [FieldOffset(0x9E8)] public TextureResourceHandle* Decal;
    [FieldOffset(0x9F0)] public TextureResourceHandle* LegacyBodyDecal;
    [FieldOffset(0x9F8)] public Texture* FreeCompanyCrest;
    [FieldOffset(0xA00)] public uint SlotFreeCompanyCrestBitfield; // & 0x001 for slot 0, up to & 0x200 for slot 9

    [FieldOffset(0xA38)] public byte* ChangedEquipData;

    [MemberFunction("48 8B ?? 53 55 57 48 83 ?? ?? 48 8B")]
    public partial byte SetupVisor(ushort modelId, byte visorState);

    // Updates the customize array and, if not skipEquipment the equip array.
    // data needs to be 26 bytes if not skipEquipment and 66 bytes otherwise.
    // Returns false and does nothing if the given race, sex or body type is not equal to the current one, 
    // or if the race is Hyur and one tribe is Highlander and the other Midlander.
    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 C5 66 41 89 86")]
    public partial bool UpdateDrawData(byte* data, bool skipEquipment);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 48 8B EA 48 81 C1")]
    public partial bool SetupFromCharacterData(byte* data);
}

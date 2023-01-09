using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
// Client::Graphics::Scene::Human
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object

// size = 0xA80
// ctor E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 28 48 8D 55 D7
[StructLayout(LayoutKind.Explicit, Size = 0xA80)]
public unsafe partial struct Human
{
    [FieldOffset(0x0)] public CharacterBase CharacterBase;
    [FieldOffset(0x8F0)] public fixed byte CustomizeData[0x1A];
    [FieldOffset(0x8F0)] public CustomizeData Customize;
    [FieldOffset(0x8F0)] public byte Race;
    [FieldOffset(0x8F1)] public byte Sex;
    [FieldOffset(0x8F2)] public byte BodyType;
    [FieldOffset(0x8F4)] public byte Clan;
    [FieldOffset(0x904)] public byte LipColorFurPattern;
    [FieldOffset(0x90C)] public uint SlotNeedsUpdateBitfield;
    [FieldOffset(0x910)] public fixed byte EquipSlotData[4 * 0xA];
    [FieldOffset(0x910)] public EquipmentModelId Head;
    [FieldOffset(0x910)] public short HeadSetID;
    [FieldOffset(0x912)] public byte HeadVariantID;
    [FieldOffset(0x913)] public byte HeadDyeID;
    [FieldOffset(0x914)] public EquipmentModelId Top;
    [FieldOffset(0x914)] public short TopSetID;
    [FieldOffset(0x916)] public byte TopVariantID;
    [FieldOffset(0x917)] public byte TopDyeID;
    [FieldOffset(0x918)] public EquipmentModelId Arms;
    [FieldOffset(0x918)] public short ArmsSetID;
    [FieldOffset(0x91A)] public byte ArmsVariantID;
    [FieldOffset(0x91B)] public byte ArmsDyeID;
    [FieldOffset(0x91C)] public EquipmentModelId Legs;
    [FieldOffset(0x91C)] public short LegsSetID;
    [FieldOffset(0x91E)] public byte LegsVariantID;
    [FieldOffset(0x91F)] public byte LegsDyeID;
    [FieldOffset(0x920)] public EquipmentModelId Feet;
    [FieldOffset(0x920)] public short FeetSetID;
    [FieldOffset(0x922)] public byte FeetVariantID;
    [FieldOffset(0x923)] public byte FeetDyeID;
    [FieldOffset(0x924)] public EquipmentModelId Ear;
    [FieldOffset(0x924)] public short EarSetID;
    [FieldOffset(0x926)] public byte EarVariantID;
    [FieldOffset(0x928)] public EquipmentModelId Neck;
    [FieldOffset(0x928)] public short NeckSetID;
    [FieldOffset(0x92A)] public byte NeckVariantID;
    [FieldOffset(0x92C)] public EquipmentModelId Wrist;
    [FieldOffset(0x92C)] public short WristSetID;
    [FieldOffset(0x92E)] public byte WristVariantID;
    [FieldOffset(0x930)] public EquipmentModelId RFinger;
    [FieldOffset(0x930)] public short RFingerSetID;
    [FieldOffset(0x932)] public byte RFingerVariantID;
    [FieldOffset(0x934)] public EquipmentModelId LFinger;
    [FieldOffset(0x934)] public short LFingerSetID;
    [FieldOffset(0x936)] public byte LFingerVariantID;
    [FieldOffset(0x938)] public ushort RaceSexId; // cXXXX ID (0101, 0201, etc)
    [FieldOffset(0x93A)] public ushort HairId; // hXXXX 
    [FieldOffset(0x93C)] public ushort FaceId; // fXXXX ID
    [FieldOffset(0x93E)] public ushort TailEarId; // tXXXX/zXXXX(viera)
    [FieldOffset(0x940)] public ushort FurId;

    [FieldOffset(0xA38)] public byte* ChangedEquipData;

    [MemberFunction("48 8B ?? 53 55 57 48 83 ?? ?? 48 8B")]
    public partial byte SetupVisor(ushort modelId, byte visorState);

    // Updates the customize array and, if not skipEquipment the equip array.
    // data needs to be 26 bytes if not skipEquipment and 66 bytes otherwise.
    // Returns false and does nothing if the given race, gender or body type is not equal to the current one, 
    // or if the race is Hyur and one clan is Highlander and the other Midlander.
    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 C5 66 41 89 86")]
    public partial bool UpdateDrawData(byte* data, bool skipEquipment);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 48 8B EA 48 81 C1")]
    public partial bool SetupFromCharacterData(byte* data);
}
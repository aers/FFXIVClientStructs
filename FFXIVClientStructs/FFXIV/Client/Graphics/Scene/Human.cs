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
    [FieldOffset(0x8F0), Obsolete("Use Customize.Data")] public fixed byte CustomizeData[0x1A];
    [FieldOffset(0x8F0)] public CustomizeData Customize;
    [FieldOffset(0x8F0), Obsolete("Use Customize.Race")] public byte Race;
    [FieldOffset(0x8F1), Obsolete("Use Customize.Sex")] public byte Sex;
    [FieldOffset(0x8F2), Obsolete("Use Customize.BodyType")] public byte BodyType;
    [FieldOffset(0x8F4), Obsolete("Use Customize.Clan")] public byte Clan;
    [FieldOffset(0x904), Obsolete("Use Customize.LupColorFurPattern")] public byte LipColorFurPattern;
    [FieldOffset(0x90C)] public uint SlotNeedsUpdateBitfield;
    [FieldOffset(0x910), Obsolete("Use specific equipment slot variables")] public fixed byte EquipSlotData[4 * 0xA];
    [FieldOffset(0x910)] public EquipmentModelId Head;
    [FieldOffset(0x910), Obsolete("Use Head.Id")] public short HeadSetID;
    [FieldOffset(0x912), Obsolete("Use Head.Variant")] public byte HeadVariantID;
    [FieldOffset(0x913), Obsolete("Use Head.Stain")] public byte HeadDyeID;
    [FieldOffset(0x914)] public EquipmentModelId Top;
    [FieldOffset(0x914), Obsolete("Use Top.Id")] public short TopSetID;
    [FieldOffset(0x916), Obsolete("Use Top.Variant")] public byte TopVariantID;
    [FieldOffset(0x917), Obsolete("Use Top.Stain")] public byte TopDyeID;
    [FieldOffset(0x918)] public EquipmentModelId Arms;
    [FieldOffset(0x918), Obsolete("Use Arms.Id")] public short ArmsSetID;
    [FieldOffset(0x91A), Obsolete("Use Arms.Variant")] public byte ArmsVariantID;
    [FieldOffset(0x91B), Obsolete("Use Arms.Stain")] public byte ArmsDyeID;
    [FieldOffset(0x91C)] public EquipmentModelId Legs;
    [FieldOffset(0x91C), Obsolete("Use Legs.Id")] public short LegsSetID;
    [FieldOffset(0x91E), Obsolete("Use Legs.Variant")] public byte LegsVariantID;
    [FieldOffset(0x91F), Obsolete("Use Legs.Stain")] public byte LegsDyeID;
    [FieldOffset(0x920)] public EquipmentModelId Feet;
    [FieldOffset(0x920), Obsolete("Use Feet.Id")] public short FeetSetID;
    [FieldOffset(0x922), Obsolete("Use Feet.Variant")] public byte FeetVariantID;
    [FieldOffset(0x923), Obsolete("Use Feet.Stain")] public byte FeetDyeID;
    [FieldOffset(0x924)] public EquipmentModelId Ear;
    [FieldOffset(0x924), Obsolete("Use Ear.Id")] public short EarSetID;
    [FieldOffset(0x926), Obsolete("Use Ear.Variant")] public byte EarVariantID;
    [FieldOffset(0x928)] public EquipmentModelId Neck;
    [FieldOffset(0x928), Obsolete("Use Neck.Id")] public short NeckSetID;
    [FieldOffset(0x92A), Obsolete("Use Neck.Variant")] public byte NeckVariantID;
    [FieldOffset(0x92C)] public EquipmentModelId Wrist;
    [FieldOffset(0x92C), Obsolete("Use Wrist.Id")] public short WristSetID;
    [FieldOffset(0x92E), Obsolete("Use Wrist.Variant")] public byte WristVariantID;
    [FieldOffset(0x930)] public EquipmentModelId RFinger;
    [FieldOffset(0x930), Obsolete("Use RFinger.Id")] public short RFingerSetID;
    [FieldOffset(0x932), Obsolete("Use RFinger.Variant")] public byte RFingerVariantID;
    [FieldOffset(0x934)] public EquipmentModelId LFinger;
    [FieldOffset(0x934), Obsolete("Use LFinger.Id")] public short LFingerSetID;
    [FieldOffset(0x936), Obsolete("Use LFinger.Variant")] public byte LFingerVariantID;
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
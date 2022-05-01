namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
// Client::Graphics::Scene::Human
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object

// size = 0xA80
// ctor E8 ? ? ? ? 48 8B F8 48 85 C0 74 28 48 8D 55 D7
[StructLayout(LayoutKind.Explicit, Size = 0xA80)]
public unsafe struct Human
{
	[StructLayout(LayoutKind.Explicit, Size = 0x1A)]
	public unsafe struct CustomizeInfoStruct
	{
		[FieldOffset(0x00)] public byte Race;
		[FieldOffset(0x01)] public byte Sex;
		[FieldOffset(0x02)] public byte BodyType;
		[FieldOffset(0x04)] public byte Clan;
		[FieldOffset(0x14)] public byte LipColorFurPattern;		
	}
	
	[StructLayout(LayoutKind.Explicit, Size = 0x27)]
	public unsafe struct EquipSlotInfoStruct
	{
		[FieldOffset(0x00)] public short HeadSetID;
		[FieldOffset(0x02)] public byte HeadVariantID;
		[FieldOffset(0x03)] public byte HeadDyeID;
		[FieldOffset(0x04)] public short TopSetID;
		[FieldOffset(0x06)] public byte TopVariantID;
		[FieldOffset(0x07)] public byte TopDyeID;
		[FieldOffset(0x08)] public short ArmsSetID;
		[FieldOffset(0x0A)] public byte ArmsVariantID;
		[FieldOffset(0x0B)] public byte ArmsDyeID;
		[FieldOffset(0x0C)] public short LegsSetID;
		[FieldOffset(0x0E)] public byte LegsVariantID;
		[FieldOffset(0x0F)] public byte LegsDyeID;
		[FieldOffset(0x10)] public short FeetSetID;
		[FieldOffset(0x12)] public byte FeetVariantID;
		[FieldOffset(0x13)] public byte FeetDyeID;
		[FieldOffset(0x14)] public short EarSetID;
		[FieldOffset(0x16)] public byte EarVariantID;
		[FieldOffset(0x18)] public short NeckSetID;
		[FieldOffset(0x1A)] public byte NeckVariantID;
		[FieldOffset(0x1C)] public short WristSetID;
		[FieldOffset(0x1E)] public byte WristVariantID;
		[FieldOffset(0x20)] public short RFingerSetID;
		[FieldOffset(0x22)] public byte RFingerVariantID;
		[FieldOffset(0x24)] public short LFingerSetID;
		[FieldOffset(0x26)] public byte LFingerVariantID;
	}
	
    [FieldOffset(0x0)] public CharacterBase CharacterBase;
	
    [FieldOffset(0x8F0)] public fixed byte CustomizeData[0x1A];
    [FieldOffset(0x8F0)] public CustomizeInfoStruct CustomizeInfo;
	
    [FieldOffset(0x90C)] public uint SlotNeedsUpdateBitfield;
	
    [FieldOffset(0x910)] public fixed byte EquipSlotData[4 * 0xA];
    [FieldOffset(0x910)] public EquipSlotInfoStruct EquipSlotInfo;
	
    [FieldOffset(0x938)] public ushort RaceSexId; // cXXXX ID (0101, 0201, etc)
    [FieldOffset(0x93A)] public ushort HairId; // hXXXX 
    [FieldOffset(0x93C)] public ushort FaceId; // fXXXX ID

    [FieldOffset(0x93E)] public ushort TailEarId; // tXXXX/zXXXX(viera)

    // see Client::Graphics::Scene::Human_FlagSlotForUpdate(thisPtr, uint slot, EquipSlotData* slotBytes) -> 48 89 5C 24 ? 48 89 74 24 ? 57 48 83 EC 20 8B DA 49 8B F0 48 8B F9 83 FA 0A 
    // array of 10*12 byte storage for changing equipment models
    [FieldOffset(0xA38)] public byte* ChangedEquipData;
}
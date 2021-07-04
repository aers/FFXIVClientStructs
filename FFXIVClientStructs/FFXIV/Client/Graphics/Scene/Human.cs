using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene
{
    // Client::Graphics::Scene::Human
    //   Client::Graphics::Scene::CharacterBase
    //     Client::Graphics::Scene::DrawObject
    //       Client::Graphics::Scene::Object

    // size = 0xA80
    // ctor E8 ? ? ? ? 48 8B F8 48 85 C0 74 28 48 8D 55 D7
    [StructLayout(LayoutKind.Explicit, Size = 0xA80)]
    public unsafe struct Human
    {
        [FieldOffset(0x0)] public CharacterBase CharacterBase;
        [FieldOffset(0x8F0)] public fixed byte CustomizeData[0x1A];
        [FieldOffset(0x8F0)] public byte Race;
        [FieldOffset(0x8F1)] public byte Sex;
        [FieldOffset(0x8F2)] public byte BodyType;
        [FieldOffset(0x8F4)] public byte Clan;
        [FieldOffset(0x904)] public byte LipColorFurPattern;
        [FieldOffset(0x90C)] public uint SlotNeedsUpdateBitfield;
        [FieldOffset(0x910)] public fixed byte EquipSlotData[4 * 0xA];
        [FieldOffset(0x910)] public short HeadSetID;
        [FieldOffset(0x912)] public byte HeadVariantID;
        [FieldOffset(0x913)] public byte HeadDyeID;
        [FieldOffset(0x914)] public short TopSetID;
        [FieldOffset(0x916)] public byte TopVariantID;
        [FieldOffset(0x917)] public byte TopDyeID;
        [FieldOffset(0x918)] public short ArmsSetID;
        [FieldOffset(0x91A)] public byte ArmsVariantID;
        [FieldOffset(0x91B)] public byte ArmsDyeID;
        [FieldOffset(0x91C)] public short LegsSetID;
        [FieldOffset(0x91E)] public byte LegsVariantID;
        [FieldOffset(0x91F)] public byte LegsDyeID;
        [FieldOffset(0x920)] public short FeetSetID;
        [FieldOffset(0x922)] public byte FeetVariantID;
        [FieldOffset(0x923)] public byte FeetDyeID;
        [FieldOffset(0x924)] public short EarSetID;
        [FieldOffset(0x926)] public byte EarVariantID;
        [FieldOffset(0x928)] public short NeckSetID;
        [FieldOffset(0x92A)] public byte NeckVariantID;
        [FieldOffset(0x92C)] public short WristSetID;
        [FieldOffset(0x92E)] public byte WristVariantID;
        [FieldOffset(0x930)] public short RFingerSetID;
        [FieldOffset(0x932)] public byte RFingerVariantID;
        [FieldOffset(0x934)] public short LFingerSetID;
        [FieldOffset(0x936)] public byte LFingerVariantID;
        [FieldOffset(0x938)] public ushort RaceSexId; // cXXXX ID (0101, 0201, etc)
        [FieldOffset(0x93A)] public ushort HairId; // hXXXX 
        [FieldOffset(0x93C)] public ushort FaceId; // fXXXX ID

        [FieldOffset(0x93E)] public ushort TailEarId; // tXXXX/zXXXX(viera)

        // see Client::Graphics::Scene::Human_FlagSlotForUpdate(thisPtr, uint slot, EquipSlotData* slotBytes) -> 48 89 5C 24 ? 48 89 74 24 ? 57 48 83 EC 20 8B DA 49 8B F0 48 8B F9 83 FA 0A 
        // array of 10*12 byte storage for changing equipment models
        [FieldOffset(0xA38)] public byte* ChangedEquipData;
    }
}
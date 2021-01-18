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
        [FieldOffset(0x90C)] public uint SlotNeedsUpdateBitfield;
        [FieldOffset(0x910)] public fixed byte EquipSlotData[4 * 0xA];
        [FieldOffset(0x938)] public ushort RaceSexId; // cXXXX ID (0101, 0201, etc)
        [FieldOffset(0x93A)] public ushort HairId; // hXXXX 
        [FieldOffset(0x93C)] public ushort FaceId; // fXXXX ID
        [FieldOffset(0x93E)] public ushort TailEarId; // tXXXX/zXXXX(viera)
        // see Client::Graphics::Scene::Human_FlagSlotForUpdate(thisPtr, uint slot, EquipSlotData* slotBytes) -> 48 89 5C 24 ? 48 89 74 24 ? 57 48 83 EC 20 8B DA 49 8B F0 48 8B F9 83 FA 0A 
        // array of 10*12 byte storage for changing equipment models
        [FieldOffset(0xA38)] public byte* ChangedEquipData;
    }
}

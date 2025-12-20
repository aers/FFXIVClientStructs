using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Housing;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HousingTemporaryObject
//   Client::LayoutEngine::Housing::HousingEventListener
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<HousingEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct HousingTemporaryObject {
    [FieldOffset(0x08)] public HousingTemporaryObjectData Data;
    [FieldOffset(0x28)] public InventoryItem* InventoryItem;
    // [FieldOffset(0x30)] public uint (HousingEmploymentNpcRace | (? << 8));

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 8B 4B")]
    public partial bool SetData(byte kind, ushort modelKey, byte housingItemCategory, byte stainId, bool isPadModeEnabled);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe partial struct HousingTemporaryObjectData {
        [FieldOffset(0x00), Obsolete($"Renamed to {nameof(Kind)}", true)] public byte Unk0;
        /// <remarks>
        /// 76 for HousingFurniture<br/>
        /// 77 for HousingYardObject
        /// </remarks>
        [FieldOffset(0x00)] public byte Kind;
        [FieldOffset(0x01)] public byte Stain;
        [FieldOffset(0x02)] public short ModelKey;
        [FieldOffset(0x04)] public byte HousingItemCategory;
        [FieldOffset(0x05), Obsolete($"Renamed to {nameof(IsPadModeEnabled)}", true)] public byte Unk5;
        [FieldOffset(0x05)] public bool IsPadModeEnabled;
        [FieldOffset(0x06)] private byte Unk6;
        [FieldOffset(0x07)] private byte Unk7;
        [FieldOffset(0x08)] private byte Unk8;

        [FieldOffset(0x10)] public HousingTemporaryObject* OwnerTemporaryObject;
    }
}

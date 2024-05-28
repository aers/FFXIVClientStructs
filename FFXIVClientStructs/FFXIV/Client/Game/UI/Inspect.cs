using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x278)]
[GenerateInterop]
public unsafe partial struct Inspect {
    [FieldOffset(0xC)] public uint ObjectId;
    [FieldOffset(0x10)] public byte Type;
    [FieldOffset(0x12)] public short WorldId;
    [FieldOffset(0x14)][FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;

    [FieldOffset(0x54)] public fixed byte PSNOnlineId[17]; // this got bigger for the Gamertag, unsure about its size yet

    [FieldOffset(0x75)] public byte ClassJobId;
    [FieldOffset(0x76)] public byte Level;
    [FieldOffset(0x77)] public byte SyncedLevel;

    [FieldOffset(0x79)] public ushort AverageItemLevel;
    [FieldOffset(0x7B)] public ushort TitleId;
    [FieldOffset(0x7D)] public byte GrandCompanyIndex;
    [FieldOffset(0x7E)] public byte GrandCompanyRank;
    [FieldOffset(0x7F)] public CustomizeData CustomizeData;
    [FieldOffset(0x99)] public byte BuddyEquipTop; // only if Type == 3
    [FieldOffset(0x9A)] public byte BuddyEquipBody; // only if Type == 3
    [FieldOffset(0x9B)] public byte BuddyEquipLegs; // only if Type == 3

    [FieldOffset(0xD7)] public fixed uint BaseParams[74];

    [FieldOffset(0x201)] public byte GearVisibilityFlag;

    [FieldOffset(0x210)][FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _buddyOwnerName;
    [FieldOffset(0x250)] public byte BuddyRank;
    [FieldOffset(0x251)] public byte BuddyStain;
    [FieldOffset(0x252)] public byte BuddyDefenderLevel;
    [FieldOffset(0x253)] public byte BuddyAttackerLevel;
    [FieldOffset(0x254)] public byte BuddyHealerLevel;

    /// <remarks> For easier access, use <see cref="GetContentValue"/>. </remarks>
    [FieldOffset(0x25B)][FixedSizeArray] internal FixedSizeArray3<StdPair<uint, uint>> _contentKeyValueData;

    /// <summary>
    /// Retrieves the value associated with the given key from ContentKeyValueData.<br/>
    /// Only loaded inside the relevant content.<br/>
    /// <br/>
    /// <code>
    /// |-----|-------------|---------------------------|
    /// | Key | Content     | Usage                     |
    /// |-----|-------------|---------------------------|
    /// |   1 | Eureka      | Elemental Level           |
    /// |   2 | Eureka      | Is Elemental Level Synced |
    /// |   3 | Eureka      | Time Remaining            |
    /// |   4 | Bozja       | Resistance Rank           |
    /// |   5 | Bozja       | Time Remaining            |
    /// |-----|-------------|---------------------------|
    /// </code>
    /// </summary>
    public uint GetContentValue(uint key) {
        for (var i = 0; i < 3; i++) {
            var entry = ContentKeyValueData.GetPointer(i);
            if (entry->Item1 == key) {
                return entry->Item2;
            }
        }
        return 0;
    }
}

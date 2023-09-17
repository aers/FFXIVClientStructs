using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe struct Inspect {
    [FieldOffset(0xC), Obsolete("Improperly mapped use outside variables", true)] public GameObjectID ObjectId;

    [FieldOffset(0xC)] public uint ObjectID;
    [FieldOffset(0x10)] public byte Type;
    [FieldOffset(0x10), Obsolete("Not valid. Use CustomizeData.Sex", true)] public byte Sex;
    [FieldOffset(0x12)] public short WorldId;
    [FieldOffset(0x14)] public fixed byte Name[64];

    [FieldOffset(0x54)] public fixed byte PSNOnlineID[17];
    [FieldOffset(0x66)] public byte ClassJobId;
    [FieldOffset(0x67)] public byte Level;
    [FieldOffset(0x68)] public byte SyncedLevel;

    [FieldOffset(0x6A)] public ushort AverageItemLevel;
    [FieldOffset(0x6C)] public ushort TitleId;
    [FieldOffset(0x6E)] public byte GrandCompanyIndex;
    [FieldOffset(0x6F)] public byte GrandCompanyRank;
    [FieldOffset(0x70)] public CustomizeData CustomizeData;
    [FieldOffset(0x8A)] public byte BuddyEquipTop;
    [FieldOffset(0x8B)] public byte BuddyEquipBody;
    [FieldOffset(0x8C)] public byte BuddyEquipLegs;

    [FieldOffset(0xC8)] public fixed uint BaseParams[74];

    [FieldOffset(0x1F2)] public byte GearVisibilityFlag;

    [FieldOffset(0x201)] public fixed byte BuddyOwnerName[64];
    [FieldOffset(0x241)] public byte BuddyRank;
    [FieldOffset(0x242)] public byte BuddyStain;
    [FieldOffset(0x243)] public byte BuddyDefenderLevel;
    [FieldOffset(0x244)] public byte BuddyAttackerLevel;
    [FieldOffset(0x245)] public byte BuddyHealerLevel;

    /// <remarks>
    /// 1 = Eureka: Elemental Level<br/>
    /// 2 = Eureka: Is Elemental Level Synced<br/>
    /// 3 = Eureka: Time Remaining<br/>
    /// 4 = Bozja: Resistance Rank<br/>
    /// 5 = Bozja: Time Remaining
    /// </remarks>
    [FixedArray(typeof(ExtraInspectDataEntry), 3)]
    [FieldOffset(0x24C)] public fixed byte ExtraInspectData[8 * 3];
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct ExtraInspectDataEntry {
    [FieldOffset(0x00)] public int Key;
    [FieldOffset(0x04)] public int Value;
}

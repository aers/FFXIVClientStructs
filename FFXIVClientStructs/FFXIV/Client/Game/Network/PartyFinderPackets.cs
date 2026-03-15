using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

/// <summary>
/// Packet for Party Finder listings.
/// </summary>
/// <remarks>
/// Received by <see cref="InfoProxyCrossRealm.ReceiveListing"/>.<br/>
/// Entries passed to <see cref="AgentLookingForGroup"/>.
/// </remarks>
[GenerateInterop]
[Inherits<ServerIpcSegmentHeader>]
[StructLayout(LayoutKind.Explicit, Size = 0x660)]
public partial struct CrossRealmListingSegmentPacket {
    [FieldOffset(0x10)] private uint Unk10;

    [FieldOffset(0x1C)] public ushort SegmentIndex; // starts at 1, counts up, ends with 0

    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray4<CrossRealmListing> _entries;

    // this struct differs slightly from AgentLookingForGroup.Detailed!
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x190)]
    public partial struct CrossRealmListing {
        [FieldOffset(0x00)] public ulong ListingId;
        [FieldOffset(0x08)] public ulong AccountId;
        [FieldOffset(0x10)] public ulong ContentId;

        [FieldOffset(0x1C)] public uint Category;

        [FieldOffset(0x20)] public ushort ContentFinderConditionId; // dword with extra info?

        [FieldOffset(0x2E)] public ushort WorldId;

        [FieldOffset(0x38)] public byte Objective;
        [FieldOffset(0x39)] public byte BeginnersWelcome;
        [FieldOffset(0x3A)] public byte CompletionStatus;
        [FieldOffset(0x3B)] public byte DutyFinderSettings;
        [FieldOffset(0x3C)] public byte LootRule;

        [FieldOffset(0x40)] public int LastPatchHotfixTimestamp;
        [FieldOffset(0x44)] public ushort TimeLeft; // maybe uint?

        [FieldOffset(0x4C)] public ushort AvgItemLv;
        [FieldOffset(0x4E)] public ushort HomeWorldId;
        [FieldOffset(0x50)] public ushort CurrentWorldId;
        [FieldOffset(0x52)] public byte ClientLanguage;
        [FieldOffset(0x53)] public byte TotalSlots;
        [FieldOffset(0x54)] public byte SlotsFilled;

        [FieldOffset(0x56)] public byte JoinConditionFlags;
        [FieldOffset(0x57)] public bool IsAlliance;
        [FieldOffset(0x58)] public byte NumberOfParties;

        [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray8<ulong> _slotFlags;
        [FieldOffset(0xA0), FixedSizeArray] internal FixedSizeArray8<byte> _jobsPresent;
        [FieldOffset(0xA8), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
        [FieldOffset(0xC8), FixedSizeArray(isString: true)] internal FixedSizeArray192<byte> _description;
    }
}

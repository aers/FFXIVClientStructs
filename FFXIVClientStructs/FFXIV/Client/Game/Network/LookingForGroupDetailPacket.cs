namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1C9)]
public partial struct LookingForGroupDetailPacket {
    /// <summary> Packet information when selecting a Party Finder Listing (Non-Alliance) </summary>
    [FieldOffset(0x0)] public uint ListingId;
    [FieldOffset(0x8)] public ulong LeaderAccountId;
    [FieldOffset(0x10)] public ulong LeaderContentId;
    [FieldOffset(0x18)] private ulong Unk18;
    [FieldOffset(0x24)] public DutyCategory DutyCategory;
    [FieldOffset(0x28)] public ushort DutyId;
    [FieldOffset(0x32)] private uint Unk32; // Seems to be a uint, not unique to listing
    [FieldOffset(0x36)] public ushort World;
    [FieldOffset(0x38)] public Objective Objective;
    [FieldOffset(0x39)] public byte BeginnerFriendly;
    [FieldOffset(0x3A)] public CompletionStatus CompletionStatus;
    [FieldOffset(0x3B)] public DutyFinderSetting DutyFinderSetting;
    [FieldOffset(0x3C)] public LootRule LootRule;
    [FieldOffset(0x40)] private uint LastPatchHotfixTimestamp; // Copying from AgentLookingForGroup
    [FieldOffset(0x44)] private uint Unk44; // Always 0
    [FieldOffset(0x48)] public uint TimeLeftInSeconds;
    [FieldOffset(0x4C)] private uint Unk4C; // Always 1
    [FieldOffset(0x50)] public ushort AvgItemLv;
    [FieldOffset(0x52)] public ushort HostHomeWorld;
    [FieldOffset(0x54)] public ushort HostCurrentWorld;
    [FieldOffset(0x56)] public Language LeaderClientLanguage; // Mostly 2 (definitely language then), sometimes 1, 3, 10 or 15. This is a bit of a guess from AgentLookingForGroup
    [FieldOffset(0x57)] public Language Language;
    [FieldOffset(0x58)] public byte TotalSlots;
    [FieldOffset(0x59)] public byte SlotsFilled;
    [FieldOffset(0x5B)] public JoinCondition JoinConditionFlags;
    [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray8<ulong> _memberContentIds;
    [FieldOffset(0xA0), FixedSizeArray] internal FixedSizeArray8<ulong> _slotFlags; 
    [FieldOffset(0xE0), FixedSizeArray] internal FixedSizeArray8<byte> _memberJobIds; 
    [FieldOffset(0xE8), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _hostName;
    [FieldOffset(0x108), FixedSizeArray(isString: true)] internal FixedSizeArray192<byte> _comment;
}

public enum Objective : byte {
    None = 0,
    DutyCompletion = 1,
    Practice = 2,
    Loot = 4,
}

public enum CompletionStatus : byte {
    None = 0,
    DutyComplete = 2,
    DutyIncomplete = 4,
    DutyCompleteWeeklyUnclaimed = 8,
}

public enum DutyCategory : ushort {
    None = 0,
    Roulette = 2,
    Dungeons = 4,
    GuildQuests = 8,
    Trials = 16,
    Raids = 32,
    HighEndDuty = 64,
    PvP = 128,
    GoldSaucer = 256,
    FATEs = 512,
    TreasureHunts = 1024,
    TheHunt = 2048,
    GatheringForays = 4096,
    DeepDungeons = 8192,
    FieldOperations = 16384,
    VCDungeonFinder = 32768
}

[Flags]
public enum DutyFinderSetting : byte {
    None = 0,
    UnrestrictedParty = 1,
    MinimumIL = 2,
    SilenceEcho = 4,
}

public enum LootRule : byte {
    Normal = 0,
    GreedOnly = 1,
    Lootmaster = 2,
}

[Flags]
public enum Language : byte {
    Japanese = 1,
    English = 2,
    German = 4,
    French = 8,
}

[Flags]
public enum JoinCondition : byte {
    Free = 1,
    PrivateParty = 3,
    LimitedRecruitingWorld = 8,
    OnePlayerPerJob = 33,
}
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentLookingForGroup
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.LookingForGroup)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3198)]
public unsafe partial struct AgentLookingForGroup {
    [FieldOffset(0xE0)] public InfoProxyCrossRealm* InfoProxyCrossRealm;

    [FieldOffset(0x1098)] public ListingsSub Listings;
    [FieldOffset(0x13B8)] public GroupsSub Groups;

    [FieldOffset(0x14E4)] public ushort AvgItemLv;
    [FieldOffset(0x14E6)] public byte AvgItemLvEnabled;

    [FieldOffset(0x14F0), FixedSizeArray] internal FixedSizeArray29<TreasureMapDetail> _treasureMaps;

    // 7.1 - 0x78 more bytes here

    [FieldOffset(0x2318)] public RecruitmentSub StoredRecruitmentInfo; // Holds infos for LookingForGroupCondition

    [FieldOffset(0x2760)] public Detailed LastViewedListing; // Holds infos about the last viewed LookingForGroupDetailed

    [FieldOffset(0x2BD8)] public Utf8String LastLeader;
    [FieldOffset(0x2C40)] public Utf8String LastComment;
    [FieldOffset(0x2CB8)] public Utf8String UnkString;

    [FieldOffset(0x30B0)] public uint OwnListingId;

    [FieldOffset(0x30E0)] public ulong ListingContentId; // Only populated while a Detailed listing is opened
    [FieldOffset(0x30E8)] public uint ListingAccountId; // Only populated while a Detailed listing is opened

    [FieldOffset(0x3172)] public ushort NumberOfListingsDisplayed;

    [FieldOffset(0x3179)] public byte SearchAreaTab; // 0 Data Center, 1 World, 2 Private
    [FieldOffset(0x317B)] public byte CategoryTab; // 0 All - 16 Other
    [FieldOffset(0x317C)] public byte GroupTypeTab; // Normal, Alliance, Custom Match

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B FA 48 8B D9 E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 85 C9")]
    public partial bool OpenListing(ulong listingId);

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 84 C0 74 07 C6 83 90 31 00 00 01")]
    public partial bool OpenListingByContentId(ulong contentId); // Actual call inlined

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public unsafe partial struct TreasureMapDetail {
        [FieldOffset(0x00)] public Utf8String String;
        [FieldOffset(0x68)] public uint DisplayOrder;
        [FieldOffset(0x6C)] public uint EventItemId;
        [FieldOffset(0x70)] public byte TreasureHuntRank; // unk
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x320)]
    public unsafe partial struct ListingsSub {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray50<ulong> _listingIds;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x126)]
    public unsafe partial struct GroupsSub {
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x448)]
    public unsafe partial struct RecruitmentSub {
        [FieldOffset(0x0C)] public ushort SelectedCategory;
        [FieldOffset(0x10)] public ushort SelectedDutyId;

        [FieldOffset(0x18)] public Objective Objective;
        [FieldOffset(0x19)] public byte BeginnerFriendly;
        [FieldOffset(0x1A)] public CompletionStatus CompletionStatus;
        [FieldOffset(0x1B)] public DutyFinderSetting DutyFinderSettingFlags;
        [FieldOffset(0x1C)] public LootRule LootRule;

        [FieldOffset(0x22)] public ushort Password; // Not enabled is 10000, no password set is 0

        [FieldOffset(0x24)] public Language LanguageFlags;

        [FieldOffset(0x25)] public byte NumberOfSlotsInMainParty;

        [FieldOffset(0x26)] public byte LimitRecruitingToWorld; // 0 is enabled, 1 is disabled

        [FieldOffset(0x27)] public byte OnePlayerPerJob;
        [FieldOffset(0x28)] public byte NumberOfGroups; // 1 Normal, 3 Alliances, 6 Field Operations

        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray48<ulong> _memberContentIds;
        [FieldOffset(0x1B0), FixedSizeArray] internal FixedSizeArray48<ulong> _slotFlags;
        [FieldOffset(0x330), FixedSizeArray(isString: true)] internal FixedSizeArray192<byte> _comment;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x478)]
    public unsafe partial struct Detailed {
        [FieldOffset(0x00)] public uint ListingId;

        [FieldOffset(0x08)] public uint LeaderAccountId;
        [FieldOffset(0x10)] public ulong LeaderContentId;

        [FieldOffset(0x24)] public ushort Category;
        [FieldOffset(0x28)] public ushort DutyId;

        [FieldOffset(0x36)] public ushort World;

        [FieldOffset(0x38)] public Objective Objective;
        [FieldOffset(0x39)] public byte BeginnerFriendly;
        [FieldOffset(0x3A)] public CompletionStatus CompletionStatus;
        [FieldOffset(0x3B)] public DutyFinderSetting DutyFinderSettingFlags;
        [FieldOffset(0x3C)] public LootRule LootRule;

        [FieldOffset(0x40)] public uint LastPatchHotfixTimestamp;
        [FieldOffset(0x48)] public uint TimeLeft;

        [FieldOffset(0x50)] public ushort AvgItemLv;

        [FieldOffset(0x52)] public ushort HomeWorld;
        [FieldOffset(0x54)] public ushort CurrentWorld;

        [FieldOffset(0x56)] public Language LeaderClientLanguage;
        [FieldOffset(0x57)] public Language LanguageFlags;

        [FieldOffset(0x58)] public byte TotalSlots;
        [FieldOffset(0x59)] public byte SlotsFilled;

        [FieldOffset(0x5B)] public JoinCondition JoinConditionFlags;
        [FieldOffset(0x5D)] public byte IsAlliance;
        [FieldOffset(0x5E)] public byte NumberOfParties;

        [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray48<ulong> _memberContentIds;
        [FieldOffset(0x1E0), FixedSizeArray] internal FixedSizeArray48<ulong> _slotFlags;
        [FieldOffset(0x360), FixedSizeArray] internal FixedSizeArray48<byte> _jobs;

        [FieldOffset(0x390), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _leader;
        [FieldOffset(0x3B0), FixedSizeArray(isString: true)] internal FixedSizeArray192<byte> _comment;
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
}

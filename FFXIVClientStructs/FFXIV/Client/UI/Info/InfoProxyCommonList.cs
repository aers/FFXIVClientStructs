using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyCommonList
//   Client::UI::Info::InfoProxyPageInterface
//     Client::UI::Info::InfoProxyInterface
[GenerateInterop(isInherited: true)]
[Inherits<InfoProxyPageInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct InfoProxyCommonList {
    [FieldOffset(0x38)] public Utf8String UnkString;
    [FieldOffset(0xA0)] public byte NumberArrayIndex;
    [FieldOffset(0xA1)] public byte StringArrayIndex;
    [FieldOffset(0xA2)] public ushort DataSize;
    [FieldOffset(0xA4)] public ushort DictSize;
    [FieldOffset(0xA6)] public ushort UnkA6; //10 * DataSize
    [FieldOffset(0xA8)] public ushort UnkA8; //10 * DataSize
    [FieldOffset(0xB0)] public CharacterData* CharData;
    [FieldOffset(0xB8)] public CharacterIndex* IndexData;
    [FieldOffset(0xC0)] public Sorting SortGroup;
    [FieldOffset(0xC1)] public DisplayGroup FilterGroup;
    [FieldOffset(0xC4)] public byte MoveSelector; // 0x9 Not Selected or 0xB Selected
    //[FieldOffset(0xAC)] public uint UnkAC; // Some kind of flag mask for OnlineStatus check InfoProxyCommonlist_vf14

    public ReadOnlySpan<CharacterData> CharDataSpan => new(CharData, (int)InfoProxyPageInterface.InfoProxyInterface.EntryCount); // It cant be higher than 200 at this time anyways so this is fine
    public ReadOnlySpan<CharacterIndex> CharIndexSpan => new(IndexData, (int)InfoProxyPageInterface.InfoProxyInterface.EntryCount); // It cant be higher than 200 at this time anyways so this is fine

    [MemberFunction("3B 51 10 73 12 8B C2 48 6B D0 70")]
    public partial ulong GetContentIdForEntry(uint idx);

    [MemberFunction("8B 41 10 48 3B D0 73 0C")]
    public partial CharacterData* GetEntry(uint idx);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 12 8B 40 20")]
    public partial CharacterData* GetEntryByContentId(ulong contentId, uint nameCrc32 = 0, byte a4 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? EB 44 41 8D 46 EF"), GenerateStringOverloads]
    public partial CharacterData* GetEntryByName(byte* characterName, ushort worldId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 13 45 33 C9")]
    public partial void ApplyFilters();

    /// <summary>
    /// Sets the value of <see cref="InfoProxyInterface.EntryCount"/> to 0 for this proxy. Does not actually delete any data from any arrays. 
    /// </summary>
    [VirtualFunction(20)]
    public partial void ClearData();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct CharacterData {
        [FieldOffset(0x00)] public ulong ContentId;
        [FieldOffset(0x08)] public OnlineStatus State;
        //12 bytes
        /// <summary>
        /// Extra flags for status:
        /// 0x10 = ? always set when accepted friend request
        /// 0x20 = WaitingForFriendListApproval
        /// 0x10000->0x70000 = DisplayGroup.Star -> DisplayGroup.Club
        /// 0x1000000 = OtherServer (FCTag not available)
        /// </summary>
        [FieldOffset(0x18)] public uint ExtraFlags;
        public DisplayGroup Group => (DisplayGroup)(ExtraFlags >> 16);
        public bool IsOtherServer => (ExtraFlags & 0x1000000) != 0;
        // 4 bytes empty
        // 4 bytes unknown
        [FieldOffset(0x24)] public byte Sort;
        // 1 byte
        [FieldOffset(0x26)] public ushort CurrentWorld;
        [FieldOffset(0x28)] public ushort HomeWorld;
        [FieldOffset(0x2A)] public ushort Location; //ZoneID
        [FieldOffset(0x2C)] public GrandCompany GrandCompany;
        [FieldOffset(0x2D)] public Language ClientLanguage;
        [FieldOffset(0x2E)] public LanguageMask Languages;
        // 1 byte
        [FieldOffset(0x30)] public byte Sex;
        [FieldOffset(0x31)] public byte Job;
        [FieldOffset(0x32), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
        [FieldOffset(0x52), FixedSizeArray(isString: true)] internal FixedSizeArray6<byte> _FCTag;
        // 8 bytes
        [FieldOffset(0x60)] public CharacterIndex* Index;

        [Flags]
        public enum OnlineStatus : ulong {
            Offline = 0,
            GameQA = 1ul << 1,
            GameMaster = 1ul << 2,
            GameMasterBlue = 1ul << 3,
            EventParticipant = 1ul << 4,
            Disconnected = 1ul << 5,
            WaitingForFriendListApproval = 1ul << 6,
            WaitingForLinkshellApproval = 1ul << 7,
            WaitingForFreeCompanyApproval = 1ul << 8,
            NotFound = 1ul << 9,
            OfflineExd = 1ul << 10,
            BattleMentor = 1ul << 11,
            Busy = 1ul << 12,
            PvP = 1ul << 13,
            PlayingTripleTriad = 1ul << 14,
            ViewingCutscene = 1ul << 15,
            UsingAChocoboPorter = 1ul << 16,
            AwayFromKeyboard = 1ul << 17,
            CameraMode = 1ul << 18,
            LookingForRepairs = 1ul << 19,
            LookingToRepair = 1ul << 20,
            LookingToMeldMateria = 1ul << 21,
            RolePlaying = 1ul << 22,
            LookingForParty = 1ul << 23,
            SwordForHire = 1ul << 24,
            WaitingForDutyFinder = 1ul << 25,
            RecruitingPartyMembers = 1ul << 26,
            Mentor = 1ul << 27,
            PvEMentor = 1ul << 28,
            TradeMentor = 1ul << 29,
            PvPMentor = 1ul << 30,
            Returner = 1ul << 31,
            NewAdventurer = 1ul << 32,
            AllianceLeader = 1ul << 33,
            AlliancePartyLeader = 1ul << 34,
            AlliancePartyMember = 1ul << 35,
            PartyLeader = 1ul << 36,
            PartyMember = 1ul << 37,
            PartyLeaderCrossWorld = 1ul << 38,
            PartyMemberCrossWorld = 1ul << 39,
            AnotherWorld = 1ul << 40,
            SharingDuty = 1ul << 41,
            SimilarDuty = 1ul << 42,
            InDuty = 1ul << 43,
            TrialAdventurer = 1ul << 44,
            FreeCompany = 1ul << 45,
            GrandCompany = 1ul << 46,
            Online = 1ul << 47,
        }

        public enum Language : byte {
            Jp = 0,
            En = 1,
            De = 2,
            Fr = 3,
            None = 0xFF
        }

        [Flags]
        public enum LanguageMask : byte {
            None = 0,
            Jp = 1,
            En = 2,
            De = 4,
            Fr = 8,
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CharacterIndex {
        [FieldOffset(0x0)] public ulong ContentId;

        [FieldOffset(0xA)] public ushort HomeWorld;
    }

    public enum DisplayGroup : sbyte {
        All = -1,
        None,
        Star,
        Circle,
        Triangle,
        Diamond,
        Heart,
        Spade,
        Club,
    }

    public enum Sorting : byte {
        FriendNumber,
        Oldest,
        Newest,
        Alphabetical,
        HomeWorld,
    }
}

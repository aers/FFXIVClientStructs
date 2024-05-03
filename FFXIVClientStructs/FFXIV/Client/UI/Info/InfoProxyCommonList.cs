using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct InfoProxyCommonList {
    [FieldOffset(0x0)] public InfoProxyPageInterface InfoProxyPageInterface;
    [FieldOffset(0x20)] public Utf8String Unk20;
    [FieldOffset(0x88)] public byte NumberArrayIndex;
    [Obsolete("Renamed to NumberArrayIndex")]
    [FieldOffset(0x88)] public byte Unk88; //Corresponding ATkModule NumberArrrayIndex
    [FieldOffset(0x89)] public byte StringArrayIndex;
    [Obsolete("Renamed to StringArrayIndex")]
    [FieldOffset(0x89)] public byte Unk89; //Corresponding ATkModule StringArrrayIndex
    [FieldOffset(0x8A)] public ushort DataSize;
    [FieldOffset(0x8C)] public ushort DictSize;
    [FieldOffset(0x8E)] public ushort Unk8E; //10 * DataSize
    [FieldOffset(0x90)] public ushort Unk90; //10 * DataSize
    [FieldOffset(0x98)] public CharacterData* CharData;
    [FieldOffset(0xA0)] public CharacterIndex* IndexData;
    [FieldOffset(0xA9)] public DisplayGroup FilterGroup;
    //[FieldOffset(0xAC)] public uint UnkAC; // Some kind of flag mask for OnlineStatus check InfoProxyCommonlist_vf14

    public readonly ReadOnlySpan<CharacterData> CharDataSpan => new(CharData, (int)InfoProxyPageInterface.InfoProxyInterface.EntryCount); // It cant be higher than 200 at this time anyways so this is fine
    public readonly ReadOnlySpan<CharacterIndex> CharIndexSpan => new(IndexData, (int)InfoProxyPageInterface.InfoProxyInterface.EntryCount); // It cant be higher than 200 at this time anyways so this is fine

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8B CB E8 ?? ?? ?? ?? 41 C6 46")]
    public partial ulong GetContentIDForEntry(uint idx);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 FF 74 55")]
    public partial CharacterData* GetEntry(uint idx);

    [MemberFunction("E9 ?? ?? ?? ?? 3B 5F 10")]
    public partial CharacterData* GetEntryByContentId(ulong contentId, uint nameCrc32 = 0, byte a4 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? EB 3C 8D 45 EF"), GenerateCStrOverloads]
    public partial CharacterData* GetEntryByName(byte* characterName, ushort worldId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 13 45 33 C9")]
    public partial void ApplyFilters();

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct CharacterData {
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
        [FieldOffset(0x1C)] public byte Sort;
        // 1ul byte
        [FieldOffset(0x1E)] public ushort CurrentWorld;
        [FieldOffset(0x20)] public ushort HomeWorld;
        [FieldOffset(0x22)] public ushort Location; //ZoneID
        [FieldOffset(0x24)] public GrandCompany GrandCompany;
        [FieldOffset(0x25)] public Language ClientLanguage;
        [FieldOffset(0x26)] public LanguageMask Languages;
        // 1 byte
        [FieldOffset(0x28)] public byte Sex;
        [FieldOffset(0x29)] public byte Job;
        [FieldOffset(0x2A)] public fixed byte Name[32];
        [FieldOffset(0x4A)] public fixed byte FCTag[6];
        // 8 bytes
        [FieldOffset(0x58)] public CharacterIndex* Index;

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
            [Obsolete("Typo fixed, use TrialAdventurer")]
            TrailAdventurer = 1ul << 44,
            FreeCompany = 1ul << 45,
            GrandCompany = 1ul << 46,
            Online = 1ul << 47,
        }

        public enum Language : byte {
            JP = 0,
            EN = 1,
            DE = 2,
            FR = 3,
            None = 0xFF
        }

        [Flags]
        public enum LanguageMask : byte {
            None = 0,
            JP = 1,
            EN = 2,
            DE = 4,
            FR = 8,
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CharacterIndex {
        [FieldOffset(0x0)] public ulong ContentID;

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
}

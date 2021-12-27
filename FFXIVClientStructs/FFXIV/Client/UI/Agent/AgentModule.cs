using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent
{
    // Client::UI::Agent::AgentModule

    // size = 0xC10
    // ctor E8 ? ? ? ? 48 8B 85 ? ? ? ? 49 8B CF 48 89 87
    [StructLayout(LayoutKind.Explicit, Size = 0xC28)]
    public unsafe partial struct AgentModule
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public UIModule* UIModule;
        [FieldOffset(0x10)] public byte Initialized;
        [FieldOffset(0x11)] public byte Unk_11;
        [FieldOffset(0x14)] public uint FrameCounter;
        [FieldOffset(0x18)] public float FrameDelta;

        [FieldOffset(0x20)] public AgentInterface* AgentArray; // 383 pointers patch 6.00
        
        [FieldOffset(0xC18)] public UIModule* UIModulePtr;
        [FieldOffset(0xC20)] public AgentModule* AgentModulePtr;
        [FieldOffset(0xC28)] public RaptureHotbarModule* RaptureHotbarModulePtr;

        [MemberFunction("E8 ?? ?? ?? ?? 83 FF 0D")]
        public partial AgentInterface* GetAgentByInternalID(uint agentID);

        public AgentInterface* GetAgentByInternalId(AgentId agentId) => GetAgentByInternalID((uint)agentId);

        public AgentHUD* GetAgentHUD() => (AgentHUD*)GetAgentByInternalId(AgentId.Hud);
        public AgentHudLayout* GetAgentHudLayout() => (AgentHudLayout*)GetAgentByInternalId(AgentId.HudLayout);
        public AgentTeleport* GetAgentTeleport() => (AgentTeleport*)GetAgentByInternalId(AgentId.Teleport);
        public AgentLobby* GetAgentLobby() => (AgentLobby*)GetAgentByInternalId(AgentId.Lobby);
    }

    public enum AgentId : uint {
        Lobby = 0,
        CharaMake = 1,
        // MovieStaffList = 2, // this is the addon name, no idea what the agent actually is, shows up when playing the EW cutscene in title
        Cursor = 3,
        Hud = 4,
        ChatLog = 5,
        Inventory = 6,
        ScenarioTree = 7,
        Context = 9,
        InventoryContext = 10,
        Config = 11,
        // Configlog,
        ConfigLogColor = 13,
        Configkey = 14,
        ConfigCharacter = 15,
        ConfigPadcustomize = 16,
        ChatConfig = 17,
        HudLayout = 18,
        Emote = 19,
        Macro = 20,
        // TargetCursor,
        TargetCircle = 21,
        GatheringNote = 22,
        RecipeNote = 23,
        FishingNote = 27,
        FishGuide = 28,
        FishRecord = 29,
        Journal = 31,
        ActionMenu = 32,
        Marker = 33,
        Trade = 34,
        ScreenLog = 35,
        // NPCTrade,
        Status = 37,
        Map = 38,
        Loot = 39, //NeedGreed
        Repair = 40,
        Materialize = 41,
        MateriaAttach = 42,
        MiragePrism = 43,
        Colorant = 44,
        Howto = 45,
        HowtoNotice = 46,
        Inspect = 48,
        Teleport = 49,
        TelepotTown = 50, // Aethernet
        ContentsFinder = 51,
        ContentsFinderSetting = 52,
        Social = 53,
        SocialBlacklist = 54,
        SocialFriendList = 55,
        Linkshell = 56,
        SocialPartyMember = 57,
        // PartyInvite,
        SocialSearch = 59,
        SocialDetail = 60,
        LetterList = 61,
        LetterView = 62,
        LetterEdit = 63,
        ItemDetail = 64,
        ActionDetail = 65,
        Retainer = 66,
        // Return,
        // Cutscene,
        CutsceneReplay = 69,
        MonsterNote = 70,
        ItemSearch = 71, //MarketBoard
        GoldSaucerReward = 72,
        FateProgress = 73, //Shared FATE
        Catch = 74,
        FreeCompany = 75,
        // FreeCompanyOrganizeSheet,
        FreeCompanyProfile = 77,
        // FreeCompanyProfileEdit,
        // FreeCompanyInvite,
        FreeCompanyInputString = 80,
        FreeCompanyChest = 81,
        FreeCompanyExchange = 82,
        FreeCompanyCrestEditor = 83,
        FreeCompanyCrestDecal = 84,
        // FreeCompanyPetition = 85,
        ArmouryBoard = 86,
        HowtoList = 87,
        Cabinet = 88,
        // LegacyItemStorage,
        GrandCompanyRank = 90,
        GrandCompanySupply = 91,
        GrandCompanyExchange = 92,
        Gearset = 93,
        SupportMain = 94,
        SupportList = 95,
        SupportView = 96,
        SupportEdit = 97,
        Achievement = 98,
        // CrossEditor,
        LicenseViewer = 100,
        ContentsTimer = 101,
        MovieSubtitle = 102,
        PadMouseMode = 103,
        RecommendList = 104,
        Buddy = 105,
        // ColosseumRecord,
        CloseMessage = 107,
        // CreditPlayer,
        // CreditScroll,
        CreditCast = 112,
        // CreditEnd,
        Shop = 113,
        Bait = 114,
        Housing = 115,
        // HousingHarvest,
        HousingSignboard = 117,
        HousingPortal = 118,
        // HousingTravellersNote,
        HousingPlant = 120,
        PersonalRoomPortal = 121,
        // HousingBuddyList,
        TreasureHunt = 122,
        // Salvage,
        LookingForGroup = 125,
        ContentsMvp = 126,
        VoteKick = 127,
        VoteGiveUp = 128,
        VoteTreasure = 129,
        PvpProfile = 130,
        ContentsNote = 131,
        // ReadyCheck,
        FieldMarker = 133,
        CursorLocation = 134,
        RetainerStatus = 136,
        RetainerTask = 137,
        RelicNotebook = 139,
        // RelicSphere,
        // TradeMultiple,
        // RelicSphereUpgrade,
        Minigame = 146,
        Tryon = 147,
        AdventureNotebook = 148,
        // ArmouryNotebook,
        MinionNotebook = 150,
        MountNotebook = 151,
        ItemCompare = 152,
        // DailyQuestSupply,
        MobHunt = 154,
        // PatchMark,
        // Max,
        WeatherReport = 157,
        Revive = 160,
        GoldSaucerMiniGame = 164,
        TrippleTriad = 165,
        LotteryDaily = 173,
        LotteryWeekly = 175,
        GoldSaucer = 176,
        JournalAccept = 179,
        JournalResult = 180,
        LeveQuest = 181,
        CompanyCraftRecipeNoteBook = 182,
        AirShipExploration = 184,
        AirShipExplorationDetail = 186,
        SubmersibleExplorationDetail = 190,
        CompanyCraftMaterial = 191,
        AetherCurrent = 192,
        FreeCompanyCreditShop = 193,
        Currency = 194,
        LovmParty = 197,
        LovmRanking = 198,
        LovmNamePlate = 199,
        LovmResult = 201,
        LovmPaletteEdit = 202,
        BeginnersMansionProblem = 208, //Hall of the Novice
        DpsChallenge = 209, //Stone, Sky, Sea
        PlayGuide = 210,
        WebLauncher = 211,
        WebGuidance = 212,
        Orchestrion = 213,
        OrchestrionInn = 218,
        YkwNote = 222, //yokai watch medallium
        ContentsFinderMenu = 223,
        RaidFinder = 224,
        GcArmyExpedition = 225,
        GcArmyMemberList = 226,
        DeepDungeonMap = 229,
        DeepDungeonStatus = 230,
        DeepDungeonSaveData = 231,
        DeepDungeonScore = 232,
        GcArmyMenberProfile = 234,
        OrchestrionPlayList = 239,
        CountDownSettingDialog = 240,
        WeeklyBingo = 241, //Wondrous Tails
        DeepDungeonMenu = 251,
        ItemAppraisal = 254, //DeepDungeon Appraisal
        ItemInspection = 255, //Lockbox
        ContactList = 257,
        Snipe = 262,
        MountSpeed = 263,
        PvpTeam = 279,
        TeleportHousingFriend = 287,
        InventoryBuddy = 289,
        ContentsReplayPlayer = 290,
        ContentsReplaySetting = 291,
        MiragePrismPrismBox = 292, //Glamour Dresser
        MiragePrismPrismItemDetail = 293,
        MiragePrismMiragePlate = 294, //Glamour Plates
        Fashion = 298,
        HousingGuestBook = 301,
        CrossWorldLinkShell = 306,
        //Description = 308, //Frontline Rules
        AozNotebook = 313, //Bluemage Spells
        Emj = 316,
        WorldTravel = 321,
        RideShooting = 322, //Airforce One
        Credit = 324,
        EmjSetting = 325,
        RetainerList = 326,
        Dawn = 331, //Trust
        QuestRedo = 335,
        QuestRedoHud = 336,
        CircleList = 338, //Fellowships
        CircleBook = 339,
        McGuffin = 359, //Collection
        CraftActionSimulator = 360,
        MycInfo = 368, //Bozja Info
        MycBattleAreaInfo = 372, //Bozja Recruitment
        OrnamentNoteBook = 374, //Accessories
    }
}

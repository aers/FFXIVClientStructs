using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;
// Client::UI::Agent::AgentModule

// size = 0xC10
// ctor E8 ? ? ? ? 48 8B 85 ? ? ? ? 49 8B CF 48 89 87
[StructLayout(LayoutKind.Explicit, Size = 0xCA0)]
public unsafe partial struct AgentModule
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public byte Initialized;
    [FieldOffset(0x11)] public byte Unk_11;
    [FieldOffset(0x14)] public uint FrameCounter;
    [FieldOffset(0x18)] public float FrameDelta;

    [FieldOffset(0x20)] public AgentInterface* AgentArray; // 398 pointers patch 6.10

    [FieldOffset(0xC90)] public UIModule* UIModulePtr;
    [FieldOffset(0xC98)] public AgentModule* AgentModulePtr;

    [MemberFunction("E8 ?? ?? ?? ?? 83 FF 0D")]
    public partial AgentInterface* GetAgentByInternalID(uint agentID);

    public AgentInterface* GetAgentByInternalId(AgentId agentId)
    {
        return GetAgentByInternalID((uint) agentId);
    }

    public AgentHUD* GetAgentHUD()
    {
        return (AgentHUD*) GetAgentByInternalId(AgentId.Hud);
    }

    public AgentHudLayout* GetAgentHudLayout()
    {
        return (AgentHudLayout*) GetAgentByInternalId(AgentId.HudLayout);
    }

    public AgentTeleport* GetAgentTeleport()
    {
        return (AgentTeleport*) GetAgentByInternalId(AgentId.Teleport);
    }

    public AgentLobby* GetAgentLobby()
    {
        return (AgentLobby*) GetAgentByInternalId(AgentId.Lobby);
    }

    public AgentMap* GetAgentMap()
    {
        return (AgentMap*) GetAgentByInternalId(AgentId.Map);
    }

    public AgentScreenLog* GetAgentScreenLog()
    {
        return (AgentScreenLog*) GetAgentByInternalId(AgentId.ScreenLog);
    }

    public AgentItemSearch* GetAgentItemSearch()
    {
        return (AgentItemSearch*) GetAgentByInternalId(AgentId.ItemSearch);
    }

    public AgentRetainerList* GetAgentRetainerList()
    {
        return (AgentRetainerList*) GetAgentByInternalId(AgentId.RetainerList);
    }

    public AgentRevive* GetAgentRevive()
    {
        return (AgentRevive*) GetAgentByInternalId(AgentId.Revive);
    }

    public AgentSalvage* GetAgentSalvage()
    {
        return (AgentSalvage*) GetAgentByInternalId(AgentId.Salvage);
    }
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
    Request = 36,
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
    MKSRecord = 106, // PVP Results
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
    HousingBuddyList = 122,
    TreasureHunt = 123,
    Salvage = 124,
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
    LovmResult = 202,
    LovmPaletteEdit = 203,
    BeginnersMansionProblem = 207, //Hall of the Novice
    DpsChallenge = 210, //Stone, Sky, Sea
    PlayGuide = 211,
    WebLauncher = 212,
    WebGuidance = 213,
    Orchestrion = 214,
    OrchestrionInn = 219,
    HousingEditContainer = 220,
    RecommendEquip = 222,
    YkwNote = 223, //yokai watch medallium
    ContentsFinderMenu = 224,
    RaidFinder = 225,
    GcArmyExpedition = 226,
    GcArmyMemberList = 227,
    DeepDungeonMap = 230,
    DeepDungeonStatus = 231,
    DeepDungeonSaveData = 232,
    DeepDungeonScore = 233,
    GcArmyTraining = 234,
    GcArmyMenberProfile = 235,

    //GcArmyExpeditionResult = 235,
    GcArmyCapture = 237,
    GcArmyOrder = 238,
    OrchestrionPlayList = 240,
    CountDownSettingDialog = 241,
    WeeklyBingo = 242, //Wondrous Tails
    PvPHeader = 246,
    AquariumSetting = 250,
    DeepDungeonMenu = 252,
    ItemAppraisal = 255, //DeepDungeon Appraisal
    ItemInspection = 256, //Lockbox
    ContactList = 258,
    Snipe = 263,
    MountSpeed = 264,
    PvpTeam = 280,
    EurekaElementalHud = 282,
    EurekaElementalEdit = 283,
    EurekaChainInfo = 284,
    TeleportHousingFriend = 288,
    InventoryBuddy = 290,
    ContentsReplayPlayer = 291,
    ContentsReplaySetting = 292,
    MiragePrismPrismBox = 293, //Glamour Dresser
    MiragePrismPrismItemDetail = 294,
    MiragePrismMiragePlate = 295, //Glamour Plates
    Fashion = 299,
    HousingGuestBook = 302,
    ReconstructionBox = 305,
    ReconstructionBuyback = 306,
    CrossWorldLinkShell = 307,
    Description = 309, //Frontline/Bozja Description
    AozNotebook = 314, //Bluemage Spells
    Emj = 317, //Mahjong
    WorldTravel = 322,
    RideShooting = 323, //Airforce One
    Credit = 325,
    EmjSetting = 326, //Mahjong Settings
    RetainerList = 327,
    Dawn = 332, //Trust
    HousingCatalogPreview = 334,
    QuestRedo = 337,
    QuestRedoHud = 338,
    CircleList = 340, //Fellowships
    CircleBook = 341,
    McGuffin = 361, //Collection
    CraftActionSimulator = 362,
    MycInfo = 370, //Bozja Info
    MycItemBox = 371, //Bozja Lost Finds Cache
    MycItemBag = 372, //Bozja Lost Finds Holster
    MycBattleAreaInfo = 375, //Bozja Recruitment
    OrnamentNoteBook = 376, //Accessories
    BannerList = 389, // Portraits
    BannerEditor = 390, // Portrait Editor
    PvPMap = 392,
    CharaCard = 393, // AdventurerPlate
    
    PvPMKSIntroduction = 397, // Final agent in Array
}

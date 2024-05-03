using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentModule
// ctor "E8 ?? ?? ?? ?? 48 8B 85 ?? ?? ?? ?? 49 8B CE 48 89 87"
[StructLayout(LayoutKind.Explicit, Size = 0xDF8)]
public unsafe partial struct AgentModule {
    public static AgentModule* Instance() => Framework.Instance()->GetUiModule()->GetAgentModule();

    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public byte Initialized;
    [FieldOffset(0x11)] public byte Unk_11;
    [FieldOffset(0x14)] public uint FrameCounter;
    [FieldOffset(0x18)] public float FrameDelta;

    [FixedSizeArray<Pointer<AgentInterface>>(441)]
    [FieldOffset(0x20)] public fixed byte Agents[441 * 8];

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 A8")]
    public partial AgentInterface* GetAgentByInternalId(AgentId agentID);

    [Obsolete("Use GetAgentByInternalId(AgentId)")]
    public AgentInterface* GetAgentByInternalID(uint agentId)
        => GetAgentByInternalId((AgentId)agentId);
}

public enum AgentId : uint {
    Lobby = 0,
    CharaMake = 1,
    MovieStaffList = 2, // this is the addon name, no idea what the agent actually is, shows up when playing the EW cutscene in title
    Cursor = 3,
    Hud = 4,
    ChatLog = 5,
    Inventory = 6,
    ScenarioTree = 7,
    EventFade = 8,
    Context = 9,
    InventoryContext = 10,
    Config = 11, // ConfigSystem
    ConfigLog = 12,
    ConfigLogColor = 13,
    Configkey = 14,
    ConfigCharacter = 15,
    ConfigPadcustomize = 16,
    ChatConfig = 17,
    ChatLogNameConfig = 18,
    HudLayout = 19,
    Emote = 20,
    Macro = 21,
    // TargetCursor,
    TargetCircle = 22,
    GatheringNote = 23,
    RecipeNote = 24,
    RecipeTree = 25,
    RecipeMaterialList = 26,
    RecipeProductList = 27,
    FishingNote = 28,
    FishGuide = 29,
    FishRecord = 30,

    [Obsolete("Renamed to QuestJournal")] Journal = 32,
    QuestJournal = 32,
    ActionMenu = 33,
    Marker = 34,
    Trade = 35,
    ScreenLog = 36,
    Request = 37, // NPCTrade
    Status = 38,
    Map = 39,
    Loot = 40, // NeedGreed
    Repair = 41,

    Materialize = 43,
    MateriaAttach = 44,
    MiragePrism = 45,
    Colorant = 46,
    Howto = 47,
    HowtoNotice = 48,
    ContentsTutorial = 49,
    Inspect = 50,
    Teleport = 51,
    TelepotTown = 52, // Aethernet
    ContentsFinder = 53,
    ContentsFinderSetting = 54,
    Social = 55,
    SocialBlacklist = 56,
    SocialFriendList = 57,
    Linkshell = 58,
    SocialPartyMember = 59,
    // PartyInvite,
    SocialSearch = 61,
    Detail = 62,
    [Obsolete("Renamed to Detail")]
    SocialDetail = 62,
    LetterList = 63,
    LetterView = 64,
    LetterEdit = 65,
    ItemDetail = 66,
    ActionDetail = 67,
    Retainer = 68,
    Return = 69,
    Cutscene = 70,
    CutsceneReplay = 71,
    MonsterNote = 72,
    ItemSearch = 73, // MarketBoard
    GoldSaucerReward = 74,
    FateProgress = 75, // Shared FATE
    Catch = 76,
    FreeCompany = 77,
    // FreeCompanyOrganizeSheet,
    FreeCompanyProfile = 79,
    FreeCompanyProfileEdit = 80,
    // FreeCompanyInvite,
    FreeCompanyInputString = 82,
    FreeCompanyChest = 83,
    FreeCompanyExchange = 84,
    FreeCompanyCrestEditor = 85,
    FreeCompanyCrestDecal = 86,

    // FreeCompanyPetition = ?,

    ArmouryBoard = 88,
    HowtoList = 89,
    Cabinet = 90,
    CabinetWithdraw = 91, // new in 6.50
    LegacyItemStorage = 92,
    GrandCompanyRank = 93,
    GrandCompanySupply = 94,
    GrandCompanyExchange = 95,
    [Obsolete("Renamed to GearSet")] Gearset = 96,
    GearSet = 96,
    SupportMain = 97,
    SupportList = 98,
    SupportView = 99,
    SupportEdit = 100,
    Achievement = 101,
    // CrossEditor,
    LicenseViewer = 103,
    ContentsTimer = 104,
    MovieSubtitle = 105,
    PadMouseMode = 106,
    RecommendList = 107,
    Buddy = 108,
    ColosseumRecord = 109, // PVP Results
    CloseMessage = 110,
    CreditPlayer = 111,
    CreditScroll = 112,
    CreditCast = 113,
    CreditEnd = 114,
    CreditCutCast = 115,
    Shop = 116,
    Bait = 117,
    Housing = 118,
    HousingHarvest = 119,
    HousingSignboard = 120,
    HousingPortal = 121,
    HousingTravellersNote = 122,
    HousingPlant = 123,
    PersonalRoomPortal = 124,
    HousingBuddyList = 125,
    TreasureHunt = 126,
    Salvage = 127,
    LookingForGroup = 128,
    ContentsMvp = 129,
    VoteKick = 130,
    VoteGiveUp = 131,
    VoteTreasure = 132,
    PvpProfile = 133,
    ContentsNote = 134,
    ReadyCheck = 135,
    FieldMarker = 136,
    CursorLocation = 137,
    CursorRect = 138,
    RetainerStatus = 139,
    RetainerTask = 140,
    RetainerTaskSupply = 141,

    RetainerItemTransfer = 143,

    RelicNotebook = 145,
    RelicSphere = 146,
    TradeMultiple = 147,
    RelicSphereUpgrade = 148,

    Relic2Glass = 151,
    Minigame = 152,
    Tryon = 153,
    TryonRetainer = 154,
    AdventureNotebook = 155,
    ArmouryNotebook = 156,
    MinionNotebook = 157,
    MountNotebook = 158,
    ItemCompare = 159,
    DailyQuestSupply = 160,
    MobHunt = 161,
    PatchMark = 162, // SelectOk?
    HousingWithdrawStorage = 163,
    WeatherReport = 164,

    LoadingTips = 166,
    Revive = 167,

    ChocoboRace = 169,

    GoldSaucerMiniGame = 171,
    TrippleTriad = 172,
    TripleTriadRuleAnnounce = 173,
    TripleTriadRuleSetting = 174,

    TripleTriadSchedule = 176,
    TripleTriadRanking = 177,
    TripleTriadTournamentResult = 178,
    TripleTriadTournamentMatchList = 179,
    LotteryDaily = 180,
    AetherialWheel = 181,
    LotteryWeekly = 182,
    GoldSaucer = 183,
    TripleTriadCoinExchange = 184,
    ShopExchangeCoin = 185, // MGP Exchange
    JournalAccept = 186,
    JournalResult = 187,
    LeveQuest = 188,
    CompanyCraftRecipeNoteBook = 189,
    AirShipParts = 190,
    AirShipExploration = 191,
    AirShipExplorationResult = 192,
    AirShipExplorationDetail = 193,
    SubmersibleParts = 194,
    SubmersibleExploration = 195,
    SubmersibleExplorationResult = 196,
    SubmersibleExplorationDetail = 197,
    CompanyCraftMaterial = 198,
    AetherCurrent = 199,
    FreeCompanyCreditShop = 200,
    Currency = 201,
    PuryfyItemSelector = 202, // Aetherial Reduction

    LovmParty = 204,
    LovmRanking = 205,
    LovmNamePlate = 206,
    CharacterTitle = 207,
    CharacterTitleSelect = 208,
    LovmResult = 209,
    LovmPaletteEdit = 210,
    SkyIslandFinder = 211, // Exploratory Missions
    SkyIslandFinderSetting = 212,
    SkyIslandResult = 213,
    SkyIsland2Result = 214,
    ItemContextCustomize = 215,
    BeginnersMansionProblem = 216, // Hall of the Novice
    DpsChallenge = 217, // Stone, Sky, Sea
    PlayGuide = 218,
    WebLauncher = 219,
    WebGuidance = 220,
    Orchestrion = 221,
    BeginnerChatList = 222, // Novice Network

    ReturnerDialog = 225,
    OrchestrionInn = 226,
    HousingEditContainer = 227,
    ConfigPartyListRoleSort = 228,
    RecommendEquip = 229,
    YkwNote = 230, // Yo-kai Watch Medallium
    ContentsFinderMenu = 231,
    RaidFinder = 232,
    GcArmyExpedition = 233,
    GcArmyMemberList = 234,

    DeepDungeonInspect = 236,
    DeepDungeonMap = 237,
    DeepDungeonStatus = 238,
    DeepDungeonSaveData = 239,
    DeepDungeonScore = 240,
    GcArmyTraining = 241,
    GcArmyMenberProfile = 242,
    GcArmyExpeditionResult = 243,
    GcArmyCapture = 244,
    GcArmyOrder = 245,
    MansionSelectRoom = 246,
    OrchestrionPlayList = 247,
    CountDownSettingDialog = 248,
    WeeklyBingo = 249, // Wondrous Tails
    WeeklyPuzzle = 250, // Faux Hollows
    CameraSetting = 251,
    PvPDuelRequest = 252,
    PvPHeader = 253,
    PvPGauge = 254, // PvPFrontlineGauge

    AquariumSetting = 257,

    DeepDungeonMenu = 259,

    DeepDungeonResult = 261,
    ItemAppraisal = 262, // DeepDungeon Appraisal
    ItemInspection = 263, // Lockbox
    RecipeItemContext = 264, // context menus for RecipeTree and RecipeList, constructor inlined
    ContactList = 265,

    SatisfactionSupply = 268,
    SatisfactionSupplyResult = 269,
    Snipe = 270,
    MountSpeed = 271,
    HarpoonTip = 272,
    PvpScreenInformationHotBar = 273,
    PvpWelcome = 274,
    JobHudNotice = 275,

    UserPolicyPerformance = 279,

    PvpTeamInputString = 281,

    PvpTeamCrestEditor = 286,
    PvpTeam = 287,

    EurekaElementalHud = 289,
    EurekaElementalEdit = 290,
    EurekaChainInfo = 291,

    TeleportHousingFriend = 295,
    ContentMemberList = 296,
    InventoryBuddy = 297,
    ContentsReplayPlayer = 298,
    ContentsReplaySetting = 299,
    MiragePrismPrismBox = 300, // Glamour Dresser
    MiragePrismPrismItemDetail = 301,
    MiragePrismMiragePlate = 302, // Glamour Plates
    PerformanceMode = 303,

    Fashion = 306,

    SelectYesno = 308,
    HousingGuestBook = 309,

    ReconstructionBox = 312,
    ReconstructionBuyback = 313,
    CrossWorldLinkShell = 314,
    MiragePrismENpcSatisfaction = 315,
    Description = 316, // Frontline/Bozja Description
    Alarm = 317,

    FreeShop = 320,
    AozNotebook = 321, // Bluemage Spells
    RhythmAction = 322,
    WeddingNotification = 323,
    Emj = 324, //Mahjong

    EmjIntro = 327,
    AozContentBriefing = 328, // Masked Carnivale
    AozContentResult = 329,
    WorldTravel = 330,
    RideShooting = 331, // Airforce One
    RideShootingResult = 332,
    Credit = 333,
    EmjSetting = 334, // Mahjong Settings
    RetainerList = 335,
    QIBCStatus = 336,

    Dawn = 340, // Trust
    DawnStory = 341, // Duty Support
    HousingCatalogPreview = 342,

    SubmersibleExplorationMapSelect = 344,
    QuestRedo = 345,
    QuestRedoHud = 346,

    CircleList = 348, // Fellowships
    CircleBook = 349,

    CircleFinder = 354,

    MentorCondition = 356,
    PerformanceMetronome = 357,
    PerformanceGamepadGuide = 358,

    PerformanceReadyCheck = 360,

    HwdAetherGauge = 364,
    HwdGathererInspection = 365,
    HwdScore = 366,

    HwdMonument = 368,
    McGuffin = 369, // Collection
    CraftActionSimulator = 370,
    IKDSchedule = 371, //Ocean Fishing
    IKDFishingLog = 372,
    IKDResult = 373,
    IKDMission = 374,
    InclusionShop = 375, // Item Exchange
    CollectablesShop = 376,
    MycWarResultNotebook = 377,
    MycInfo = 378, // Bozja Info
    MycItemBox = 379, // Bozja Lost Finds Cache
    MycItemBag = 380, // Bozja Lost Finds Holster
    MycDuelRequest = 381,
    MycBattleAreaInfo = 382, // Bozja Recruitment

    OrnamentNoteBook = 384, //Accessories

    TourismMenu = 386,
    GatheringMasterpiece = 387,
    StarlightGiftBox = 388,
    SpearFishing = 389,
    Omikuji = 390,
    FittingShop = 391,
    AkatsukiNote = 392, // Unending Codex
    ExHotbarEditor = 393,
    BannerList = 394, // Portraits
    BannerEditor = 395, // Portrait Editor
    BannerUpdateView = 396,

    PvPMap = 398,
    CharaCard = 399, // AdventurerPlate
    CharaCardDesignSetting = 400,
    CharaCardProfileSetting = 401,

    PvPMKSIntroduction = 403,
    MJIHud = 404, // Island Sanctuary
    MJIPouch = 405,
    MJIRecipeNoteBook = 406,
    MJICraftSchedule = 407,
    MJICraftSales = 408,
    MJIAnimalManagement = 409,
    MJIFarmManagement = 410,
    MJIGatheringHouse = 411,
    MJIBuilding = 412,
    MJIGatheringNoteBook = 413,
    MJIDisposeShop = 414,
    MJIMinionManagement = 415,
    MJIMinionNoteBook = 416,
    MJIBuildingMove = 417,
    MJIEntrance = 418,
    MJISettings = 419,
    MJIHousingMenu = 420, // new in 6.40

    MJINekomimiRequest = 422, // favors
    ArchiveItem = 423,

    VVDNotebook = 425,
    VVDFinder = 426,
    TofuList = 427,

    BannerParty = 430,
    BannerMIP = 431,
    TurnBreak = 432,

    SXTBattleLog = 434,
    MoogleCollection = 435,
    FGSEnterDialog = 436,
    FGSStageIntro = 437,
    FGSHud = 438,
    FGSWinner = 439,
    FGSResult = 440
}

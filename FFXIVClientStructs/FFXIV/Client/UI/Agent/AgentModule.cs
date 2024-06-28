using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentModule
// ctor "E8 ?? ?? ?? ?? 48 8B 85 ?? ?? ?? ?? 49 8B CE 48 89 87"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xDF8)]
public unsafe partial struct AgentModule {
    public static AgentModule* Instance() => Framework.Instance()->GetUIModule()->GetAgentModule();

    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public byte Initialized;
    [FieldOffset(0x14)] public uint FrameCounter;
    [FieldOffset(0x18)] public float FrameDelta;

    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray441<Pointer<AgentInterface>> _agents;

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 A8")]
    public partial AgentInterface* GetAgentByInternalId(AgentId agentId);
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
    // TODO new 7.00 agent = 11,
    Config = 12, // ConfigSystem
    ConfigLog = 13,
    ConfigLogColor = 14,
    Configkey = 15,
    ConfigCharacter = 16,
    ConfigPadcustomize = 17,
    ChatConfig = 18,
    ChatLogNameConfig = 19,
    HudLayout = 20,
    Emote = 21,
    Macro = 22,
    // TargetCursor,
    TargetCircle = 23,
    GatheringNote = 24,
    RecipeNote = 25,
    RecipeTree = 26,
    RecipeMaterialList = 27,
    RecipeProductList = 28,
    FishingNote = 29,
    FishGuide = 30,
    FishRecord = 31,

    QuestJournal = 33,
    ActionMenu = 34,
    Marker = 35,
    Trade = 36,
    ScreenLog = 37,
    Request = 38, // NPCTrade
    Status = 39,
    Map = 40,
    Loot = 41, // NeedGreed
    Repair = 42,

    Materialize = 44,
    MateriaAttach = 45,
    MiragePrism = 46,
    Colorant = 47,
    Howto = 48,
    HowtoNotice = 49,
    ContentsTutorial = 50,
    Inspect = 51,
    Teleport = 52,
    TelepotTown = 53, // Aethernet
    ContentsFinder = 54,
    ContentsFinderSetting = 55,
    Social = 56,
    Blacklist = 57,
    Mutelist = 58, // new in 7.00
    Friendlist = 59,
    Linkshell = 60,
    PartyMember = 61,
    // PartyInvite,
    Search = 63,
    Detail = 64,
    LetterList = 65,
    LetterView = 66,
    LetterEdit = 67,
    ItemDetail = 68,
    ActionDetail = 69,
    Retainer = 70,
    Return = 71,
    Cutscene = 72,
    CutsceneReplay = 73,
    MonsterNote = 74,
    ItemSearch = 75, // MarketBoard
    GoldSaucerReward = 76,
    FateProgress = 77, // Shared FATE
    Catch = 78,
    FreeCompany = 79,
    // FreeCompanyOrganizeSheet,
    FreeCompanyProfile = 81,
    FreeCompanyProfileEdit = 82,
    // FreeCompanyInvite,
    FreeCompanyInputString = 84,
    FreeCompanyChest = 85,
    FreeCompanyExchange = 86,
    FreeCompanyCrestEditor = 87,
    FreeCompanyCrestDecal = 88,

    // FreeCompanyPetition = ?,

    ArmouryBoard = 90,
    HowtoList = 91,
    Cabinet = 92,
    CabinetWithdraw = 93, // new in 6.50
    LegacyItemStorage = 94,
    GrandCompanyRank = 95,
    GrandCompanySupply = 96,
    GrandCompanyExchange = 97,
    GearSet = 98,
    SupportMain = 99,
    SupportList = 100,
    SupportView = 101,
    SupportEdit = 102,
    Achievement = 103,
    // CrossEditor,
    LicenseViewer = 105,
    ContentsTimer = 106,
    MovieSubtitle = 107,
    PadMouseMode = 108,
    RecommendList = 109,
    Buddy = 110,
    ColosseumRecord = 111, // PVP Results
    CloseMessage = 112,
    CreditPlayer = 113,
    CreditScroll = 114,
    CreditCast = 115,
    CreditEnd = 116,
    CreditCutCast = 117,
    Shop = 118,
    Bait = 119,
    Housing = 120,
    HousingHarvest = 121,
    HousingSignboard = 122,
    HousingPortal = 123,
    HousingTravellersNote = 124,
    HousingPlant = 125,
    PersonalRoomPortal = 126,
    HousingBuddyList = 127,
    TreasureHunt = 128,
    Salvage = 129,
    LookingForGroup = 130,
    ContentsMvp = 131,
    VoteKick = 132,
    VoteGiveUp = 133,
    VoteTreasure = 134,
    PvpProfile = 135,
    ContentsNote = 136,
    ReadyCheck = 137,
    FieldMarker = 138,
    CursorLocation = 139,
    CursorRect = 140,
    RetainerStatus = 141,
    RetainerTask = 142,
    RetainerTaskSupply = 143,

    RetainerItemTransfer = 145,

    RelicNotebook = 147,
    RelicSphere = 148,
    TradeMultiple = 149,
    RelicSphereUpgrade = 150,

    Relic2Glass = 153,
    Minigame = 154,
    Tryon = 155,
    TryonRetainer = 156,
    AdventureNotebook = 157,
    ArmouryNotebook = 158,
    MinionNotebook = 159,
    MountNotebook = 160,
    ItemComp = 161,
    DailyQuestSupply = 162,
    MobHunt = 163,
    PatchMark = 164, // SelectOk?
    HousingWithdrawStorage = 165,
    WeatherReport = 166,

    LoadingTips = 168,
    Revive = 169,

    ChocoboRace = 171,

    GoldSaucerMiniGame = 173,
    TrippleTriad = 174,
    TripleTriadRuleAnnounce = 175,
    TripleTriadRuleSetting = 176,

    TripleTriadSchedule = 178,
    TripleTriadRanking = 179,
    TripleTriadTournamentResult = 180,
    TripleTriadTournamentMatchList = 181,
    LotteryDaily = 182,
    AetherialWheel = 183,
    LotteryWeekly = 184,
    GoldSaucer = 185,
    TripleTriadCoinExchange = 186,
    ShopExchangeCoin = 187, // MGP Exchange
    JournalAccept = 188,
    JournalResult = 189,
    LeveQuest = 190,
    CompanyCraftRecipeNoteBook = 191,
    AirShipParts = 192,
    AirShipExploration = 193,
    AirShipExplorationResult = 194,
    AirShipExplorationDetail = 195,
    SubmersibleParts = 196,
    SubmersibleExploration = 197,
    SubmersibleExplorationResult = 198,
    SubmersibleExplorationDetail = 199,
    CompanyCraftMaterial = 200,
    AetherCurrent = 201,
    FreeCompanyCreditShop = 202,
    Currency = 203,
    PuryfyItemSelector = 204, // Aetherial Reduction

    LovmParty = 206,
    LovmRanking = 207,
    LovmNamePlate = 208,
    CharacterTitle = 209,
    CharacterTitleSelect = 210,
    LovmResult = 211,
    LovmPaletteEdit = 212,
    SkyIslandFinder = 213, // Exploratory Missions
    SkyIslandFinderSetting = 214,
    SkyIslandResult = 215,
    SkyIsland2Result = 216,
    ItemContextCustomize = 217,
    BeginnersMansionProblem = 218, // Hall of the Novice
    DpsChallenge = 219, // Stone, Sky, Sea
    PlayGuide = 220,
    WebLauncher = 221,
    WebGuidance = 222,
    Orchestrion = 223,
    BeginnerChatList = 224, // Novice Network

    ReturnerDialog = 227,
    OrchestrionInn = 228,
    HousingEditContainer = 229,
    ConfigPartyListRoleSort = 230,
    RecommendEquip = 231,
    YkwNote = 232, // Yo-kai Watch Medallium
    ContentsFinderMenu = 233,
    RaidFinder = 234,
    GcArmyExpedition = 235,
    GcArmyMemberList = 236,

    DeepDungeonInspect = 238,
    DeepDungeonMap = 239,
    DeepDungeonStatus = 240,
    DeepDungeonSaveData = 241,
    DeepDungeonScore = 242,
    GcArmyTraining = 243,
    GcArmyMenberProfile = 244,
    GcArmyExpeditionResult = 245,
    GcArmyCapture = 246,
    GcArmyOrder = 247,
    MansionSelectRoom = 248,
    OrchestrionPlayList = 249,
    CountDownSettingDialog = 250,
    WeeklyBingo = 251, // Wondrous Tails
    WeeklyPuzzle = 252, // Faux Hollows
    CameraSetting = 253,
    PvPDuelRequest = 254,
    PvPHeader = 255,
    PvPGauge = 256, // PvPFrontlineGauge

    AquariumSetting = 259,

    DeepDungeonMenu = 261,

    DeepDungeonResult = 263,
    ItemAppraisal = 264, // DeepDungeon Appraisal
    ItemInspection = 265, // Lockbox
    RecipeItemContext = 266, // context menus for RecipeTree and RecipeList, constructor inlined
    ContactList = 267,

    SatisfactionSupply = 270,
    SatisfactionSupplyResult = 271,
    Snipe = 272,
    MountSpeed = 273,
    HarpoonTip = 274,
    PvpScreenInformationHotBar = 275,
    PvpWelcome = 276,
    JobHudNotice = 277,

    UserPolicyPerformance = 281,

    PvpTeamInputString = 283,

    PvpTeamCrestEditor = 288,
    PvpTeam = 289,

    EurekaElementalHud = 291,
    EurekaElementalEdit = 292,
    EurekaChainInfo = 293,

    TeleportHousingFriend = 297,
    ContentMemberList = 298,
    InventoryBuddy = 299,
    ContentsReplayPlayer = 300,
    ContentsReplaySetting = 301,
    MiragePrismPrismBox = 302, // Glamour Dresser
    MiragePrismPrismItemDetail = 303,
    MiragePrismMiragePlate = 304, // Glamour Plates
    PerformanceMode = 305,

    Fashion = 308,

    SelectYesno = 310,
    HousingGuestBook = 311,

    ReconstructionBox = 314,
    ReconstructionBuyback = 315,
    CrossWorldLinkShell = 316,
    MiragePrismENpcSatisfaction = 317,
    Description = 318, // Frontline/Bozja Description
    Alarm = 319,

    FreeShop = 322,
    AozNotebook = 323, // Bluemage Spells
    RhythmAction = 324,
    WeddingNotification = 325,
    Emj = 326, //Mahjong

    EmjIntro = 329,
    AozContentBriefing = 330, // Masked Carnivale
    AozContentResult = 331,
    WorldTravel = 332,
    RideShooting = 333, // Airforce One
    RideShootingResult = 334,
    Credit = 335,
    EmjSetting = 336, // Mahjong Settings
    RetainerList = 337,
    QIBCStatus = 338,

    Dawn = 342, // Trust
    DawnStory = 343, // Duty Support
    HousingCatalogPreview = 344,

    SubmersibleExplorationMapSelect = 346,
    QuestRedo = 347,
    QuestRedoHud = 348,

    CircleList = 350, // Fellowships
    CircleBook = 351,

    CircleFinder = 356,

    MentorCondition = 358,
    PerformanceMetronome = 359,
    PerformanceGamepadGuide = 360,

    PerformanceReadyCheck = 362,

    HwdAetherGauge = 366,
    HwdGathererInspection = 367,
    HwdScore = 368,

    HwdMonument = 370,
    McGuffin = 371, // Collection
    CraftActionSimulator = 372,
    IKDSchedule = 373, //Ocean Fishing
    IKDFishingLog = 374,
    IKDResult = 375,
    IKDMission = 376,
    InclusionShop = 377, // Item Exchange
    CollectablesShop = 378,
    MycWarResultNotebook = 379,
    MycInfo = 380, // Bozja Info
    MycItemBox = 381, // Bozja Lost Finds Cache
    MycItemBag = 382, // Bozja Lost Finds Holster
    MycDuelRequest = 383,
    MycBattleAreaInfo = 384, // Bozja Recruitment

    OrnamentNoteBook = 386, //Accessories

    TourismMenu = 388,
    GatheringMasterpiece = 389,
    StarlightGiftBox = 390,
    SpearFishing = 391,
    Omikuji = 392,
    FittingShop = 393,
    AkatsukiNote = 394, // Unending Codex
    ExHotbarEditor = 395,
    BannerList = 396, // Portraits
    BannerEditor = 397, // Portrait Editor
    BannerUpdateView = 398,

    PvPMap = 400,
    CharaCard = 401, // AdventurerPlate
    CharaCardDesignSetting = 402,
    CharaCardProfileSetting = 403,

    PvPMKSIntroduction = 405,
    MJIHud = 406, // Island Sanctuary
    MJIPouch = 407,
    MJIRecipeNoteBook = 408,
    MJICraftSchedule = 409,
    MJICraftSales = 410,
    MJIAnimalManagement = 411,
    MJIFarmManagement = 412,
    MJIGatheringHouse = 413,
    MJIBuilding = 414,
    MJIGatheringNoteBook = 415,
    MJIDisposeShop = 416,
    MJIMinionManagement = 417,
    MJIMinionNoteBook = 418,
    MJIBuildingMove = 419,
    MJIEntrance = 420,
    MJISettings = 421,
    MJIHousingMenu = 422, // new in 6.40

    MJINekomimiRequest = 424, // favors
    ArchiveItem = 425,

    VVDNotebook = 427,
    VVDFinder = 428,
    TofuList = 429,

    BannerParty = 432,
    BannerMIP = 433,
    TurnBreak = 434,

    SXTBattleLog = 436,
    MoogleCollection = 437,
    FGSEnterDialog = 438,
    FGSStageIntro = 439,
    FGSHud = 440,
    FGSWinner = 441,
    FGSResult = 442
}

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE50)]
public unsafe partial struct AgentModule {
    public static AgentModule* Instance() {
        var uiModule = UI.UIModule.Instance();
        return uiModule == null ? null : uiModule->GetAgentModule();
    }

    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public byte Initialized;
    [FieldOffset(0x14)] public uint FrameCounter;
    [FieldOffset(0x18)] public float FrameDelta;

    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray452<Pointer<AgentInterface>> _agents;
    [FieldOffset(0xE40)] public UIModuleAgentModulePtrStruct UIModuleAgentModulePtr;

    [MemberFunction("E8 ?? ?? ?? ?? 83 7B 48 00")]
    public partial AgentInterface* GetAgentByInternalId(AgentId agentId);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct UIModuleAgentModulePtrStruct {
        [FieldOffset(0x0)] public UIModule* UIModule;
        [FieldOffset(0x8)] public AgentModule* AgentModule;
    }
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
    Purify = 204, // Aetherial Reduction

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
    // BeginnerChatSomething = 225,
    BeginnerChatInvite = 226,
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
    SatisfactionList = 272, // new in 7.1
    Snipe = 273,
    MountSpeed = 274,

    PvpScreenInformationHotBar = 275,
    PvpWelcome = 276,
    JobHudNotice = 277,
    // TreasureHunt = 278, // unsure
    // Maneuvers1 = 279, // Rival Wings
    // Maneuvers2 = 280, // Rival Wings
    UserPolicyPerformance = 281,
    PvpTeam = 282,
    PvpTeamInputString = 283,
    PvpTeamMember = 284,
    PvPTeamResult = 285,

    PvpTeamCrestEditor = 288,
    PvPTeamOrganization = 289,

    EurekaElementalHud = 291,
    EurekaElementalEdit = 292,
    EurekaChainInfo = 293,
    // EurekaLogos = 294,
    EurekaMagiaActionNotebook = 295, // unconfirmed
    EurekaWeaponAdjust = 296,
    TeleportHousingFriend = 297,
    ContentMemberList = 298,
    InventoryBuddy = 299,
    ContentsReplayPlayer = 300,
    ContentsReplaySetting = 301,
    MiragePrismPrismBox = 302, // Glamour Dresser
    MiragePrismPrismItemDetail = 303,
    MiragePrismPrismSetConvert = 304, // new in 7.1
    MiragePrismMiragePlate = 305, // Glamour Plates
    PerformanceMode = 306,
    PerformanceModeSettings = 307,
    RecordReadyCheck = 308,
    Fashion = 309,

    SelectYesno = 311,
    HousingGuestBook = 312,

    ReconstructionBox = 315,
    ReconstructionBuyback = 316,
    CrossWorldLinkShell = 317,
    MiragePrismENpcSatisfaction = 318,
    Description = 319, // Frontline/Bozja Description
    Alarm = 320,
    MerchantSetting = 322, // Mannequins
    FreeShop = 323,
    AozNotebook = 324, // Bluemage Spells
    RhythmAction = 325,
    WeddingNotification = 326,
    Emj = 327, // Mahjong

    EmjIntro = 330,
    EmjVoiceCharacter = 331, // new in 7.1
    AozContentBriefing = 332, // Masked Carnivale
    AozContentResult = 333,
    WorldTravel = 334,
    RideShooting = 335, // Airforce One
    RideShootingResult = 336,
    Credit = 337,
    EmjSetting = 338, // Mahjong Settings
    RetainerList = 339,
    QIBCStatus = 340,
    HugeCraftworksSupply = 341, // Crystarium Deliveries
    HugeCraftworksSupplyResult = 342,
    SharlayanCraftworksSupply = 343, // Studium Deliveries
    BankaCraftworksSupply = 344, // Wachumeqimeqi Deliveries
    Dawn = 345, // Trust
    DawnStory = 346, // Duty Support
    HousingCatalogPreview = 347,
    SubmersibleExplorationMapSelect = 349,
    QuestRedo = 350,
    QuestRedoHud = 351,
    CircleInvite = 352, // Fellowships
    CircleList = 353,
    CircleBook = 354,
    CircleBookSetting = 355,
    CircleBookBlackList = 356,
    CircleBookQuestion = 357,
    CircleBookGroupSetting = 358,
    CircleFinder = 359,
    CircleFinderSetting = 360,
    MentorCondition = 361,
    PerformanceMetronome = 362,
    PerformanceGamepadGuide = 363,
    PerformancePlayGuide = 364,
    PerformanceReadyCheck = 365,
    HwdInfoBoard = 366,
    HwdLottery = 367,
    HwdSupply = 368,
    HwdAetherGauge = 369,
    HwdGathererInspection = 370,
    HwdScore = 371,
    HwdGathererInspectionItemCount = 372,
    HwdMonument = 373,
    McGuffin = 374, // Collection
    CraftActionSimulator = 375,
    IKDSchedule = 376, // Ocean Fishing
    IKDFishingLog = 377,
    IKDResult = 378,
    IKDMission = 379,
    InclusionShop = 380, // Item Exchange
    CollectablesShop = 381,
    MycWarResultNotebook = 382,
    MycInfo = 383, // Bozja Info
    MycItemBox = 384, // Bozja Lost Finds Cache
    MycItemBag = 385, // Bozja Lost Finds Holster
    MycDuelRequest = 386,
    MycBattleAreaInfo = 387, // Bozja Recruitment
    MycWeaponAdjust = 388,
    OrnamentNoteBook = 389, // Accessories

    TourismMenu = 391,
    GatheringMasterpiece = 392,
    StarlightGiftBox = 393,
    SpearFishing = 394,
    Omikuji = 395,
    FittingShop = 396,
    AkatsukiNote = 397, // Unending Codex
    ExHotbarEditor = 398,
    BannerList = 399, // Portraits
    BannerEditor = 400, // Portrait Editor
    BannerUpdateView = 401,

    BannerPreview = 403, // new in 7.1
    PvPMap = 404,
    CharaCard = 405, // AdventurerPlate
    CharaCardDesignSetting = 406,
    CharaCardProfileSetting = 407,

    PvPMKSRankRating = 408,
    PvPMKSIntroduction = 409,
    MJIHud = 410, // Island Sanctuary
    MJIPouch = 411,
    MJIRecipeNoteBook = 412,
    MJICraftSchedule = 413,
    MJICraftSales = 414,
    MJIAnimalManagement = 415,
    MJIFarmManagement = 416,
    MJIGatheringHouse = 417,
    MJIBuilding = 418,
    MJIGatheringNoteBook = 419,
    MJIDisposeShop = 420,
    MJIMinionManagement = 421,
    MJIMinionNoteBook = 422,
    MJIBuildingMove = 423,
    MJIEntrance = 424,
    MJISettings = 425,
    MJIHousingMenu = 426, // new in 6.40

    MJINekomimiRequest = 428, // favors
    ArchiveItem = 429,
    Class2JobHotbar = 430,
    VVDNotebook = 431,
    VVDFinder = 432,
    TofuList = 433,
    TofuPreview = 434,
    TofuPreset = 435,
    BannerParty = 436,
    BannerMIP = 437,
    TurnBreak = 438,
    MandervilleWeapon = 439,
    SXTBattleLog = 440,
    MoogleCollection = 441,
    FGSEnterDialog = 442,
    FGSStageIntro = 443,
    FGSHud = 444,
    FGSWinner = 445,
    FGSResult = 446,
    PointMenu = 447,
    TradeScreenImage = 448,
    Glasses = 449,
    TermFilter = 450,
    HousingInteriorPattern = 451, // new in 7.1
}

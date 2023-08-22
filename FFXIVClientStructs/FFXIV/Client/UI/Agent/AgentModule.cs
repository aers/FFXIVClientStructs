using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;
// Client::UI::Agent::AgentModule

// size = 0xDB8
// ctor E8 ?? ?? ?? ?? 48 8B 85 ?? ?? ?? ?? 49 8B CF 48 89 87
[StructLayout(LayoutKind.Explicit, Size = 0xDB8)]
public unsafe partial struct AgentModule
{
    public static AgentModule* Instance() => Framework.Instance()->GetUiModule()->GetAgentModule();
    
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public byte Initialized;
    [FieldOffset(0x11)] public byte Unk_11;
    [FieldOffset(0x14)] public uint FrameCounter;
    [FieldOffset(0x18)] public float FrameDelta;

    [FixedSizeArray<Pointer<AgentInterface>>(432)]
    [FieldOffset(0x20)] public fixed byte Agents[432 * 8];

    [FieldOffset(0xDA8)] public UIModule* UIModulePtr;
    [FieldOffset(0xDB0)] public AgentModule* AgentModulePtr;

    [MemberFunction("E8 ?? ?? ?? ?? 83 FE 0D")]
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

    public AgentMonsterNote* GetAgentMonsterNote()
    {
        return (AgentMonsterNote*)GetAgentByInternalId(AgentId.MonsterNote);
    }

    public AgentMJIPouch* GetAgentMJIPouch()
    {
        return (AgentMJIPouch*)GetAgentByInternalId(AgentId.MJIPouch);
    }

    public AgentAozContentBriefing* GetAgentAozContentBriefing()
    {
        return (AgentAozContentBriefing*)GetAgentByInternalId(AgentId.AozContentBriefing);
    }

    public AgentAozContentResult* GetAgentAozContentResult()
    {
        return (AgentAozContentResult*)GetAgentByInternalId(AgentId.AozContentResult);
    }

    public AgentCraftActionSimulator* GetAgentCraftActionSimulator()
    {
        return (AgentCraftActionSimulator*)GetAgentByInternalId(AgentId.CraftActionSimulator);
    }
    
    public AgentDeepDungeonStatus* GetAgentDeepDungeonStatus()
    {
	    return (AgentDeepDungeonStatus*)GetAgentByInternalId(AgentId.DeepDungeonStatus);
    }

    public AgentDeepDungeonMap* GetAgentDeepDungeonMap()
    {
	    return (AgentDeepDungeonMap*)GetAgentByInternalId(AgentId.DeepDungeonMap);
    }

    public AgentMiragePrismMiragePlate* GetAgentMiragePrismMiragePlate()
    {
        return (AgentMiragePrismMiragePlate*)GetAgentByInternalId(AgentId.MiragePrismMiragePlate);
    }

    public AgentMiragePrismPrismBox* GetAgentMiragePrismPrismBox()
    {
        return (AgentMiragePrismPrismBox*)GetAgentByInternalId(AgentId.MiragePrismPrismBox);
    }

    public AgentTryon* GetAgentTryon()
    {
        return (AgentTryon*)GetAgentByInternalId(AgentId.Tryon);
    }

    public AgentIKDFishingLog* GetAgentIKDFishingLog() {
        return (AgentIKDFishingLog*)GetAgentByInternalId(AgentId.IKDFishingLog);
    }

    public AgentIKDResult* GetAgentIKDResult() {
        return (AgentIKDResult*)GetAgentByInternalId(AgentId.IKDResult);
    }

    public AgentBannerEditor* GetAgentBannerEditor() {
        return (AgentBannerEditor*)GetAgentByInternalId(AgentId.BannerEditor);
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
    Config = 11, //ConfigSystem
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
    Journal = 32,
    ActionMenu = 33,
    Marker = 34,
    Trade = 35,
    ScreenLog = 36,
    // NPCTrade,
    Request = 37,
    Status = 38,
    Map = 39,
    Loot = 40, //NeedGreed
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
    ItemSearch = 73, //MarketBoard
    GoldSaucerReward = 74,
    FateProgress = 75, //Shared FATE
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

    // FreeCompanyPetition = 85,
    ArmouryBoard = 88,
    HowtoList = 89,
    Cabinet = 90, 
    LegacyItemStorage = 91,
    GrandCompanyRank = 92,
    GrandCompanySupply = 93,
    GrandCompanyExchange = 94,
    Gearset = 95,
    SupportMain = 96,
    SupportList = 97,
    SupportView = 98,
    SupportEdit = 99,
    Achievement = 100,
    // CrossEditor,
    LicenseViewer = 102,
    ContentsTimer = 103,
    MovieSubtitle = 104,
    PadMouseMode = 105,
    RecommendList = 106,
    Buddy = 107,
    ColosseumRecord = 108, // PVP Results
    CloseMessage = 109,
    CreditPlayer = 110,
    CreditScroll = 111,
    CreditCast = 112,
    CreditEnd = 113,
    CreditCutCast = 114,
    Shop = 115,
    Bait = 116,
    Housing = 117,
    HousingHarvest = 118,
    HousingSignboard = 119,
    HousingPortal = 120,
    HousingTravellersNote = 121,
    HousingPlant = 122,
    PersonalRoomPortal = 123,
    HousingBuddyList = 124,
    TreasureHunt = 125,
    Salvage = 126,
    LookingForGroup = 127,
    ContentsMvp = 128,
    VoteKick = 129,
    VoteGiveUp = 130,
    VoteTreasure = 131,
    PvpProfile = 132,
    ContentsNote = 133,
    ReadyCheck = 134,
    FieldMarker = 135,
    CursorLocation = 136,
    CursorRect = 137,
    RetainerStatus = 138,
    RetainerTask = 139,
    
    RetainerItemTransfer = 142,

    RelicNotebook = 144,
    RelicSphere = 145,
    TradeMultiple = 146,
    RelicSphereUpgrade = 147,

    Relic2Glass = 150,
    Minigame = 151,
    Tryon = 152,
    TryonRetainer = 153,
    AdventureNotebook = 154,
    ArmouryNotebook = 155,
    MinionNotebook = 156,
    MountNotebook = 157,
    ItemCompare = 158, 
    DailyQuestSupply = 159,
    MobHunt = 160,
    PatchMark = 161, //SelectOk?
    HousingWithdrawStorage = 162,
    WeatherReport = 163,

    LoadingTips = 165,
    Revive = 166,

    ChocoboRace = 168,

    GoldSaucerMiniGame = 170,
    TrippleTriad = 171,

    LotteryDaily = 179,
    AetherialWheel = 180,
    LotteryWeekly = 181,
    GoldSaucer = 182,
    TripleTriadCoinExchange = 183,
    ShopExchangeCoin = 184, //MGP Exchange
    JournalAccept = 185,
    JournalResult = 186,
    LeveQuest = 187,
    CompanyCraftRecipeNoteBook = 188,
    AirShipParts = 189,
    AirShipExploration = 190,
    AirShipExplorationResult = 191,
    AirShipExplorationDetail = 192,
    SubmersibleParts = 193,
    SubmersibleExploration = 194,
    SubmersibleExplorationResult = 195,
    SubmersibleExplorationDetail = 196,
    CompanyCraftMaterial = 197,
    AetherCurrent = 198,
    FreeCompanyCreditShop = 199,
    Currency = 200,
    PuryfyItemSelector = 201, //Aetherial Reduction

    LovmParty = 203,
    LovmRanking = 204,
    LovmNamePlate = 205,
    CharacterTitle = 206,
    CharacterTitleSelect = 207,
    LovmResult = 208,
    LovmPaletteEdit = 209,
    SkyIslandFinder = 210, //Exploratory Missions
    SkyIslandFinderSetting = 211,
    SkyIslandResult = 212,
    SkyIsland2Result = 213,
    ItemContextCustomize = 214,
    BeginnersMansionProblem = 215, //Hall of the Novice
    DpsChallenge = 216, //Stone, Sky, Sea
    PlayGuide = 217,
    WebLauncher = 218,
    WebGuidance = 219,
    Orchestrion = 220,
    BeginnerChatList = 221, //Novice Network

    ReturnerDialog = 224,
    OrchestrionInn = 225,
    HousingEditContainer = 226,
    ConfigPartyListRoleSort = 227,
    RecommendEquip = 228,
    YkwNote = 229, //yokai watch medallium
    ContentsFinderMenu = 230,
    RaidFinder = 231,
    GcArmyExpedition = 232,
    GcArmyMemberList = 233,

    DeepDungeonInspect = 235,
    DeepDungeonMap = 236,
    DeepDungeonStatus = 237,
    DeepDungeonSaveData = 238,
    DeepDungeonScore = 239,
    GcArmyTraining = 240,
    GcArmyMenberProfile = 241,
    GcArmyExpeditionResult = 242,
    GcArmyCapture = 243,
    GcArmyOrder = 244,
    MansionSelectRoom = 245,
    OrchestrionPlayList = 246,
    CountDownSettingDialog = 247,
    WeeklyBingo = 248, //Wondrous Tails
    WeeklyPuzzle = 249, //Faux Hollows
    CameraSetting = 250,
    PvPDuelRequest = 251,
    PvPHeader = 252,

    AquariumSetting = 256,

    DeepDungeonMenu = 258,

    DeepDungeonResult = 260,
    ItemAppraisal = 261, //DeepDungeon Appraisal
    ItemInspection = 262, //Lockbox
    RecipeItemContext = 263, // context menus for RecipeTree and RecipeList, constructor inlined
    ContactList = 264,

    SatisfactionSupply = 267,
    SatisfactionSupplyResult = 268,
    Snipe = 269,
    MountSpeed = 270,
    HarpoonTip = 271,
    PvpScreenInformationHotBar = 272,
    PvpWelcome = 273,
    UserPolicyPerformance = 278,
    PvpTeamInputString = 280,
    PvpTeamCrestEditor = 285,
    PvpTeam = 286,

    EurekaElementalHud = 288,
    EurekaElementalEdit = 289,
    EurekaChainInfo = 290,

    TeleportHousingFriend = 294,
    ContentMemberList = 295,
    InventoryBuddy = 296,
    ContentsReplayPlayer = 297,
    ContentsReplaySetting = 298,
    MiragePrismPrismBox = 299, //Glamour Dresser
    MiragePrismPrismItemDetail = 300,
    MiragePrismMiragePlate = 301, //Glamour Plates
    PerformanceMode = 302,
    Fashion = 305,

    SelectYesno = 307,
    HousingGuestBook = 308,

    ReconstructionBox = 311,
    ReconstructionBuyback = 312,
    CrossWorldLinkShell = 313,
    MiragePrismENpcSatisfaction = 314,
    Description = 315, //Frontline/Bozja Description
    Alarm = 316,
    
    FreeShop = 319,
    AozNotebook = 320, //Bluemage Spells
    RhythmAction = 321,
    WeddingNotification = 322,

    Emj = 323, //Mahjong

    EmjIntro = 326,
    AozContentBriefing = 327, //Masked Carnivale
    AozContentResult = 328,
    WorldTravel = 329,
    RideShooting = 330, //Airforce One

    Credit = 332,
    EmjSetting = 333, //Mahjong Settings
    RetainerList = 334,
    QIBCStatus = 335,

    Dawn = 339, //Trust
    DawnStory = 340, //Duty Support
    HousingCatalogPreview = 341,

    SubmersibleExplorationMapSelect = 343,
    QuestRedo = 344,
    QuestRedoHud = 345,

    CircleList = 347, //Fellowships
    CircleBook = 348,

    CircleFinder = 353,

    MentorCondition = 355,
    PerformanceMetronome = 356,
    PerformanceGamepadGuide = 357,

    PerformanceReadyCheck = 359,

    HwdAetherGauge = 363,

    HwdScore = 365,

    HwdMonument = 367,
    McGuffin = 368, //Collection
    CraftActionSimulator = 369,

    //Ocean Fishing
    IKDSchedule = 370,
    IKDFishingLog = 371,
    IKDResult = 372,
    IKDMission = 373,

    InclusionShop = 374, //Item Exchange

    MycWarResultNotebook = 376,
    MycInfo = 377, //Bozja Info
    MycItemBox = 378, //Bozja Lost Finds Cache
    MycItemBag = 379, //Bozja Lost Finds Holster

    MycBattleAreaInfo = 381, //Bozja Recruitment

    OrnamentNoteBook = 383, //Accessories

    TourismMenu = 385,

    StarlightGiftBox = 387,
    SpearFishing = 388,
    Omikuji = 389,
    FittingShop = 390,
    AkatsukiNote = 391, //Unending Codex
    ExHotbarEditor = 392,
    BannerList = 393, // Portraits
    BannerEditor = 394, // Portrait Editor
    BannerUpdateView = 395,
    
    CharaCard = 398, // AdventurerPlate
    CharaCardDesignSetting = 399,
    CharaCardProfileSetting = 400,

    PvPMKSIntroduction = 402,
    MJIHud = 403,  // Island Sanctuary
    MJIPouch = 404,
    MJIRecipeNoteBook = 405,
    MJICraftSchedule = 406,
    MJICraftSales = 407,
    MJIAnimalManagement = 408,
    MJIFarmManagement = 409,
    MJIGatheringHouse = 410,
    MJIBuilding = 411,
    MJIGatheringNoteBook = 412,
    MJIDisposeShop = 413,
    MJIMinionManagement = 414,
    MJIMinionNoteBook = 415, 
    MJIBuildingMove = 416,
    MJIEntrance = 417,
    MJISettings = 418,

    ArchiveItem = 421,

    VVDNotebook = 423,
    VVDFinder = 424,
    TofuList = 425,
    
    BannerParty = 428,
    BannerMIP = 429,

    PvPMap = 432
}

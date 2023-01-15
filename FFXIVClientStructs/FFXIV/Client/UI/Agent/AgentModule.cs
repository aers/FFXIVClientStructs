using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;
// Client::UI::Agent::AgentModule

// size = 0xC10
// ctor E8 ?? ?? ?? ?? 48 8B 85 ?? ?? ?? ?? 49 8B CF 48 89 87
[StructLayout(LayoutKind.Explicit, Size = 0xD78)]
public unsafe partial struct AgentModule
{
    public static AgentModule* Instance() => Framework.Instance()->GetUiModule()->GetAgentModule();
    
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public byte Initialized;
    [FieldOffset(0x11)] public byte Unk_11;
    [FieldOffset(0x14)] public uint FrameCounter;
    [FieldOffset(0x18)] public float FrameDelta;

    [FixedSizeArray<Pointer<AgentInterface>>(425)]
    [FieldOffset(0x20)] public fixed byte Agents[425 * 8];

    [FieldOffset(0xD68)] public UIModule* UIModulePtr;
    [FieldOffset(0xD70)] public AgentModule* AgentModulePtr;

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
    HudLayout = 18,
    Emote = 19,
    Macro = 20,
    // TargetCursor,
    TargetCircle = 21,
    GatheringNote = 22,
    RecipeNote = 23,
    RecipeTree = 24,
    RecipeMaterialList = 25,
    RecipeProductList = 26,
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
    
    Materialize = 42,
    MateriaAttach = 43,
    MiragePrism = 44,
    Colorant = 45,
    Howto = 46,
    HowtoNotice = 47,
    ContentsTutorial = 48,
    Inspect = 49,
    Teleport = 50,
    TelepotTown = 51, // Aethernet
    ContentsFinder = 52,
    ContentsFinderSetting = 53,
    Social = 54,
    SocialBlacklist = 55,
    SocialFriendList = 56,
    Linkshell = 57,
    SocialPartyMember = 58,

    // PartyInvite,
    SocialSearch = 60,
    SocialDetail = 61,
    LetterList = 62,
    LetterView = 63,
    LetterEdit = 64,
    ItemDetail = 65,
    ActionDetail = 66,
    Retainer = 67,
    Return = 68,
    Cutscene = 69,
    CutsceneReplay = 70,
    MonsterNote = 71,
    ItemSearch = 72, //MarketBoard
    GoldSaucerReward = 73,
    FateProgress = 74, //Shared FATE
    Catch = 75,
    FreeCompany = 76,

    // FreeCompanyOrganizeSheet,
    FreeCompanyProfile = 78,

    FreeCompanyProfileEdit = 79,
    // FreeCompanyInvite,
    FreeCompanyInputString = 81,
    FreeCompanyChest = 82,
    FreeCompanyExchange = 83,
    FreeCompanyCrestEditor = 84,
    FreeCompanyCrestDecal = 85,

    // FreeCompanyPetition = 85,
    ArmouryBoard = 87,
    HowtoList = 88,
    Cabinet = 89, 
    LegacyItemStorage = 90,
    GrandCompanyRank = 91,
    GrandCompanySupply = 92,
    GrandCompanyExchange = 93,
    Gearset = 94,
    SupportMain = 95,
    SupportList = 96,
    SupportView = 97,
    SupportEdit = 98,
    Achievement = 99,
    // CrossEditor,
    LicenseViewer = 101,
    ContentsTimer = 102,
    MovieSubtitle = 103,
    PadMouseMode = 104,
    RecommendList = 105,
    Buddy = 106,
    ColosseumRecord = 107, // PVP Results
    CloseMessage = 108,
    CreditPlayer = 109,
    CreditScroll = 110,
    CreditCast = 111,
    CreditEnd = 112,
    CreditCutCast = 113,
    Shop = 114,
    Bait = 115,
    Housing = 116,
    HousingHarvest = 117,
    HousingSignboard = 118,
    HousingPortal = 119,
    HousingTravellersNote = 120,
    HousingPlant = 121,
    PersonalRoomPortal = 122,
    HousingBuddyList = 123,
    TreasureHunt = 124,
    Salvage = 125,
    LookingForGroup = 126,
    ContentsMvp = 127,
    VoteKick = 128,
    VoteGiveUp = 129,
    VoteTreasure = 130,
    PvpProfile = 131,
    ContentsNote = 132,
    ReadyCheck = 133,
    FieldMarker = 134,
    CursorLocation = 135,
    CursorRect = 136,
    RetainerStatus = 137,
    RetainerTask = 138,
    
    RelicNotebook = 143, //+2
    RelicSphere = 144,
    TradeMultiple = 145,
    RelicSphereUpgrade = 146,

    Relic2Glass = 149,
    Minigame = 150,
    Tryon = 151,
    TryonRetainer = 152,
    AdventureNotebook = 153,
    ArmouryNotebook = 154,
    MinionNotebook = 155,
    MountNotebook = 156,
    ItemCompare = 157, 
    DailyQuestSupply = 158,
    MobHunt = 159,
    PatchMark = 160, //SelectOk?
    HousingWithdrawStorage = 161,
    WeatherReport = 162,

    LoadingTips = 164,
    Revive = 165,

    ChocoboRace = 167,

    GoldSaucerMiniGame = 169,
    TrippleTriad = 170,

    LotteryDaily = 178, //+3
    AetherialWheel = 179,
    LotteryWeekly = 180,
    GoldSaucer = 181,
    TripleTriadCoinExchange = 182,
    ShopExchangeCoin = 183, //MGP Exchange
    JournalAccept = 184,
    JournalResult = 185,
    LeveQuest = 186,
    CompanyCraftRecipeNoteBook = 187,
    AirShipParts = 188,
    AirShipExploration = 189,
    AirShipExplorationResult = 190,
    AirShipExplorationDetail = 191,
    
    SubmersibleExplorationResult = 194,
    SubmersibleExplorationDetail = 195,
    CompanyCraftMaterial = 196,
    AetherCurrent = 197,
    FreeCompanyCreditShop = 198,
    Currency = 199,
    PuryfyItemSelector = 200, //Aetherial Reduction

    LovmParty = 202,
    LovmRanking = 203,
    LovmNamePlate = 204,
    CharacterTitle = 205,
    CharacterTitleSelect = 206,
    LovmResult = 207,
    LovmPaletteEdit = 208,
    SkyIslandFinder = 209, //Exploratory Missions
    SkyIslandFinderSetting = 210,

    ItemContextCustomize = 213,
    BeginnersMansionProblem = 214, //Hall of the Novice
    DpsChallenge = 215, //Stone, Sky, Sea
    PlayGuide = 216,
    WebLauncher = 217,
    WebGuidance = 218,
    Orchestrion = 219,
    BeginnerChatList = 220, //Novice Network

    ReturnerDialog = 223,
    OrchestrionInn = 224,
    HousingEditContainer = 225,
    ConfigPartyListRoleSort = 226,
    RecommendEquip = 227,
    YkwNote = 228, //yokai watch medallium
    ContentsFinderMenu = 229,
    RaidFinder = 230,
    GcArmyExpedition = 231,
    GcArmyMemberList = 232,

    DeepDungeonInspect = 234,
    DeepDungeonMap = 235,
    DeepDungeonStatus = 236,
    DeepDungeonSaveData = 237,
    DeepDungeonScore = 238,
    GcArmyTraining = 239,
    GcArmyMenberProfile = 240,
    GcArmyExpeditionResult = 241,
    GcArmyCapture = 242,
    GcArmyOrder = 243,
    MansionSelectRoom = 244,
    OrchestrionPlayList = 245,
    CountDownSettingDialog = 246,
    WeeklyBingo = 247, //Wondrous Tails
    WeeklyPuzzle = 248, //Faux Hollows
    CameraSetting = 249,
    PvPDuelRequest = 250,
    PvPHeader = 251,

    AquariumSetting = 255,

    DeepDungeonMenu = 257,

    ItemAppraisal = 260, //DeepDungeon Appraisal
    ItemInspection = 261, //Lockbox
    RecipeItemContext = 262, // context menus for RecipeTree and RecipeList, constructor inlined
    ContactList = 263,

    Snipe = 268,
    MountSpeed = 269,

    PvpTeam = 285,

    EurekaElementalHud = 287,
    EurekaElementalEdit = 288,
    EurekaChainInfo = 289,

    TeleportHousingFriend = 293,
    ContentMemberList = 294,
    InventoryBuddy = 295,
    ContentsReplayPlayer = 296,
    ContentsReplaySetting = 297,
    MiragePrismPrismBox = 298, //Glamour Dresser
    MiragePrismPrismItemDetail = 299,
    MiragePrismMiragePlate = 300, //Glamour Plates

    Fashion = 304,

    HousingGuestBook = 307,

    ReconstructionBox = 310,
    ReconstructionBuyback = 311,
    CrossWorldLinkShell = 312,

    Description = 314, //Frontline/Bozja Description
    AozNotebook = 319, //Bluemage Spells

    Emj = 322, //Mahjong

    EmjIntro = 325,
    AozContentBriefing = 326, //Masked Carnivale
    AozContentResult = 327,
    WorldTravel = 328,
    RideShooting = 329, //Airforce One

    Credit = 331,
    EmjSetting = 332, //Mahjong Settings
    RetainerList = 333,

    Dawn = 338, //Trust
    DawnStory = 339, //Duty Support
    HousingCatalogPreview = 340,

    QuestRedo = 343,
    QuestRedoHud = 344,

    CircleList = 346, //Fellowships
    CircleBook = 347,

    CircleFinder = 352,

    MentorCondition = 354,
    PerformanceMetronome = 355,
    PerformanceGamepadGuide = 356,

    PerformanceReadyCheck = 358,

    HwdAetherGauge = 362,

    HwdScore = 364,

    HwdMonument = 366,
    McGuffin = 367, //Collection
    CraftActionSimulator = 368,

    MycWarResultNotebook = 375,
    MycInfo = 376, //Bozja Info
    MycItemBox = 377, //Bozja Lost Finds Cache
    MycItemBag = 378, //Bozja Lost Finds Holster

    MycBattleAreaInfo = 380, //Bozja Recruitment

    OrnamentNoteBook = 382, //Accessories

    TourismMenu = 384,

    StarlightGiftBox = 386,
    SpearFishing = 387,
    Omikuji = 388,
    FittingShop = 389,
    AkatsukiNote = 390, //Unending Codex
    ExHotbarEditor = 391,
    BannerList = 392, // Portraits
    BannerEditor = 393, // Portrait Editor
    BannerUpdateView = 394,
    PvPMap = 395,

    CharaCard = 397, // AdventurerPlate
    CharaCardDesignSetting = 398,
    CharaCardProfileSetting = 399,

    PvPMKSIntroduction = 401,
    MJIHud = 402,  // Island Sanctuary
    MJIPouch = 403,
    MJIRecipeNoteBook = 404,
    MJICraftSchedule = 405,
    MJICraftSales = 406,
    MJIAnimalManagement = 407,
    MJIFarmManagement = 408,
    MJIGatheringHouse = 409,
    MJIBuilding = 410,
    MJIGatheringNoteBook = 411,
    MJIDisposeShop = 412,
    MJIMinionManagement = 413,
    MJIMinionNoteBook = 414, 
    MJIBuildingMove = 415,
    MJIEntrance = 416,
    MJISettings = 417,
    ArchiveItem = 418,
    VVDNotebook = 419,
    VVDFinder = 420,
    TofuList = 421,
    
    BannerParty = 423,
    BannerMIP = 424
}

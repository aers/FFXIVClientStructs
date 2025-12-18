namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AtkArrayData {
    [FieldOffset(0x8)] public int Size;
    [FieldOffset(0xC), FixedSizeArray] internal FixedSizeArray16<byte> _subscribedAddons;
    [FieldOffset(0x1C)] private byte Unk1C;
    [FieldOffset(0x1D)] private byte Unk1D;
    [FieldOffset(0x1E)] public byte SubscribedAddonsCount;
    /// <remarks>
    /// 0 = No update pending<br/>
    /// 1 = Update subscribed addons (specific flags are checked in AtkUnitManager.UpdateAddonByID)<br/>
    /// 2 = Force update subscribed addons
    /// </remarks>
    [FieldOffset(0x1F)] public byte UpdateState;
    [FieldOffset(0x20)] public sbyte RefCount; // initialized to -1, used by Agents
}

public enum NumberArrayType {
    ChatLog = 0,
    ChatLog2 = 1,
    CharaSelect = 2,
    Hud = 3, // ParameterWidget, Status, Exp
    PartyList = 4,
    NamePlate = 5,
    CastBarEnemy = 6,
    ActionBar = 7,
    Inventory = 8,
    BagWidget = 9,
    Hud2 = 10, // Notification, TargetInfo, ContentGauge, FocusTargetInfo, VoteKickDialogue, VoteTreasure
    Trade = 11,
    NeedGreed = 12,

    PartyMemberList = 14,

    LinkShell = 16,
    BlackList = 17,
    FriendList = 18,

    Letter = 20, // LetterList, LetterViewer
    SocialList = 21, // search results
    EnemyList = 22,
    CastBar = 23,
    TargetCursor = 24,
    AreaMap = 25,

    Journal = 27,
    ToDoList = 28,
    RecipeNote = 29,
    ItemDetail = 30,
    FlyText = 31,
    ActionDetail = 32,

    InventoryRetainer = 34,
    MiniTalk = 35,
    Talk = 36,
    ItemSearch = 37,
    BattleTalk = 38,
    ArmouryBoard = 39,
    FreeCompanyMember = 40,

    HousingBlackListSetting = 42,
    LimitBreak = 43,
    LegacyItemStorage = 44,
    FreeCompanyApplication = 45,
    GearSetList = 46,
    FreeCompanyRights = 47, // also MemberRankAssign, FreeCompanyRank
    CabinetStore = 48,
    CabinetWithdraw = 49,

    FreeCompanyActivity = 51,
    FreeCompanyExchange = 52,
    FreeCompanyStatus = 53,
    ConfigSystem = 54,

    NaviMap = 56,
    AreaMap2 = 57,
    ContentsFinderConfirm = 58,
    FreeCompanyChest = 59,
    Buddy = 60,
    //1 60,
    FreeCompanyAction = 62,
    RecommendList = 63,

    Character = 65,
    FishingNote = 66,
    FishGuide = 67,
    GearSetView = 68,
    HousingSignBoard = 69,
    Housing = 70, // HousingSelectDeed, HousingGardening, HousingGoods, HousingEditInterior, HousingEditExterior
    AllianceList = 71,
    LookingForGroup = 72,
    Credits = 73,
    HousingTravellersNote = 74,
    DTR = 75,
    RetainerCharacter = 76,
    AdventureNoteBook = 77,
    HousingChocoboList = 78,
    TripleTriad = 79,
    GSInfoGeneral = 80,
    RaceChocobo = 81,
    Currency = 82,
    BeginnerChannelMentorList = 83,
    BeginnerChannelBeginnerList = 84,

    PvPDuelRequest = 86,
    JobHud = 87,
    PvPTeam = 88,
    PvPTeamMember = 89,
    PvPTeamResult = 90,
    PvPTeamActivity = 91,

    ContentMemberList = 93,

    CrossWorldLinkShell = 95,

    Lovm = 98,

    LovmQueueList = 100,
    LovmNamePlate = 101,
    LovmMiniMap = 102,
    LovmActionDetail = 103,
    GoldSaucerArcadeMachine = 104, // PunchingMachine, BasketBall, Hammer, MogCatcher, MinerBotanistAim
    PvPProfile = 105,
    Orchestrion = 106,
    OrchestrionPlayListSelect = 107,
    RetainerTask = 108,
    YKWNote = 109,
    DeepDungeonNaviMap = 110,
    DeepDungeonStatus = 111,
    ProgressBar = 112,
    GcArmyExpedition = 113,
    GcArmyTraining = 114,
    GcArmyCapture = 115,
    PvPMKS = 117,
    PvPSpectatorCameraList = 118,
    PvPSpectatorList = 119,
    PvPFrontline = 120,
    LFGRecruiterNameSearch = 121,
    Snipe = 122,
    // 1 122, // unsure
    PVPSimulationHeader = 124,
    PVPSimulationAlliance = 125,
    PVPSimulationHeader2 = 126,
    PVPSimulationDisplay = 127,
    EurekaElementalHud = 128,
    Performance = 129,
    ContentsReplayPlayer = 130,
    SatisfactionSupplyChangeMiragePrism = 131,
    SatisfactionSupplyMiragePrism = 132,
    Description = 133, // DescriptionYTC, DescriptionDD
    Alarm = 134,
    Merchant = 135,
    MerchantEquipSelect = 136,
    EurekaLogosShardList = 137,
    EurekaLogosAetherList = 138,
    RhythmAction = 139,
    WorldTranslate = 140,
    Emj = 141,
    PerformanceGamepadGuide = 142,
    PerformanceMetronome = 143,
    PerformancePlayGuide = 144,
    CruisingInfo = 145,
    MYCInfo = 146,
    MYCItemBag = 147,
    WeeklyPuzzle = 148,
    TeleportTown = 149,
    PvPMKSNaviMap = 150,
    TurnBreak = 151,
    MJIHousingGoods = 152,
    FGSHud = 153,
    FGSResult = 154,
    MKDInfo = 155,
    MKDInfo2 = 156,
    QuickPanel = 157,
}

public enum StringArrayType {
    ChatLog = 0,
    CharaSelect = 1,
    Hud = 2, // ParameterWidget, Status, Exp
    PartyList = 3,
    NamePlate = 4,
    CastBarEnemy = 5,
    ActionBar = 6,
    Inventory = 7,
    CharacterItems = 8,
    Hud2 = 9, // Notification, TargetInfo, ContentGauge, FocusTargetInfo
    Trade = 10,

    PartyMemberList = 12,

    LinkShell = 14,
    BlackList = 15,
    FriendList = 16,

    Letter = 18, // LetterList, LetterViewer
    SocialList = 19, // search results
    EnemyList = 20,
    CastBar = 21,
    AreaMap = 22,

    Journal = 24,
    ToDoList = 25,
    RecipeNote = 26,
    ItemDetail = 27, // search results and RetainerHistory
    FlyText = 28,
    ActionDetail = 29,

    InventoryRetainer = 31,
    MiniTalk = 32,
    CommonCurrencies = 33, // holds Gil, Grand Company Seals, Dark Matter; used by Repair, MateriaAttachDialog, GrandCompanyExchange, GrandCompanySupplyList
    ItemSearch = 34,
    BattleTalk = 35,
    ArmouryBoard = 36,
    FreeCompanyMember = 37,

    HousingBlackListSetting = 39,
    LegacyItemStorage = 40,
    FreeCompanyApplication = 41,
    GearSetList = 42,
    FreeCompanyRights = 43,
    CabinetStore = 44,
    CabinetWithdraw = 45,

    FreeCompanyActivity = 47,
    FreeCompanyExchange = 48,
    FreeCompanyStatus = 49,
    ConfigSystem = 50,

    NaviMap = 52,
    AreaMap2 = 53,
    ContentsFinderConfirm = 54,
    FreeCompanyChest = 55,
    Buddy = 56,
    //FreeCompanyExchange = 57,
    FreeCompanyAction = 58,
    RecommendList = 59,
    Character = 60, // Character, CharacterProfile, CharacterClass, CharacterRepute
    FishingNote = 61,
    FishGuide = 62,
    GearSetView = 63,
    HousingSignBoard = 64,
    Housing = 65, // HousingSelectDeed, HousingGardening, HousingGoods, HousingEditInterior, HousingEditExterior
    AllianceList = 66,
    LookingForGroup = 67,
    HousingTravellersNote = 68,
    DTR = 69,
    //PadMouseMode = 70,
    RetainerCharacter = 71,
    AdventureNoteBook = 72,
    HousingChocoboList = 73,
    TripleTriad = 74,
    LimitBreak = 75,
    RaceChocobo = 76,
    Currency = 77,
    BeginnerChannelMentorList = 78,
    BeginnerChannelBeginnerList = 79,
    PvPDuelRequest = 80,
    JobHud = 81,
    PvPTeam = 82,
    PvPTeamMember = 83,
    PvPTeamResult = 84,
    PvPTeamActivity = 85,
    ContentMemberList = 86,

    CrossWorldLinkShell = 88,
    LovmNamePlate = 89,
    LovmActionDetail = 90,
    LovmResult = 91,
    Lovm = 92,

    PvPProfile = 94,
    Orchestrion = 95,
    OrchestrionPlayListSelect = 96,

    RetainerTask = 98,
    YKWNote = 99,
    DeepDungeonNaviMap = 100,
    DeepDungeonStatus = 101,
    GcArmyExpedition = 102,
    GcArmyTraining = 103,
    GcArmyCapture = 104,
    PvPMKS = 105,
    PvPSpectatorList = 106,
    LFGRecruiterNameSearch = 107,
    Snipe = 108,
    Performance = 109,
    ContentsReplayPlayer = 110,
    SatisfactionSupplyChangeMiragePrism = 111,
    SatisfactionSupplyMiragePrism = 112,
    Alarm = 113,
    Merchant = 114,
    MerchantEquipSelect = 115,
    EurekaLogosShardList = 116,
    RhythmAction = 117,
    WorldTranslate = 118,
    PVPSimulationHeader2 = 119,
    PVPSimulationDisplay = 120,
    Emj = 121,
    WeeklyPuzzle = 122,
    MYCInfo = 123,
    TeleportTown = 124,
    MJIHousingGoods = 125,
    QuickPanel = 126,
}

public enum ExtendArrayType {
    AreaMapSubZones = 1,
    NaviMapMapMarkers = 2, // Pointers to MapMarkerBase?
}

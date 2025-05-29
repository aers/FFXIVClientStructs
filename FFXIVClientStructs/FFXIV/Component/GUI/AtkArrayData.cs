namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AtkArrayData {
    [FieldOffset(0x8)] public int Size;
    [FieldOffset(0xC), FixedSizeArray] internal FixedSizeArray16<byte> _subscribedAddons;
    [FieldOffset(0x1C)] public byte Unk1C;
    [FieldOffset(0x1D)] public byte Unk1D;
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
    ActionBar = 6,
    Inventory = 7,
    BagWidget = 8,
    Hud2 = 9, // Notification, TargetInfo, ContentGauge, FocusTargetInfo, VoteKickDialogue, VoteTreasure
    Trade = 10,
    NeedGreed = 11,

    PartyMemberList = 13,

    LinkShell = 15,
    BlackList = 16,
    FriendList = 17,

    Letter = 19, // LetterList, LetterViewer
    SocialList = 20, // search results
    EnemyList = 21,
    CastBar = 22,
    TargetCursor = 23,
    AreaMap = 24,

    Journal = 26,
    ToDoList = 27,
    RecipeNote = 28,
    ItemDetail = 29,
    FlyText = 30,
    ActionDetail = 31,

    InventoryRetainer = 33,
    MiniTalk = 34,
    Talk = 35,
    ItemSearch = 36,
    BattleTalk = 37,
    ArmouryBoard = 38,
    FreeCompanyMember = 39,

    HousingBlackListSetting = 41,
    LimitBreak = 42,
    LegacyItemStorage = 43,
    FreeCompanyApplication = 44,
    GearSetList = 45,
    FreeCompanyRights = 46, // also MemberRankAssign, FreeCompanyRank
    CabinetStore = 47,
    CabinetWithdraw = 48,

    FreeCompanyActivity = 50,
    FreeCompanyExchange = 51,
    FreeCompanyStatus = 52,
    ConfigSystem = 53,

    NaviMap = 55,
    AreaMap2 = 56,
    ContentsFinderConfirm = 57,
    FreeCompanyChest = 58,
    Buddy = 59,
    //FreeCompanyExchange2 = 60,
    FreeCompanyAction = 61,
    RecommendList = 62,

    Character = 64,
    FishingNote = 65,
    FishGuide = 66,
    GearSetView = 67,
    HousingSignBoard = 68,
    Housing = 69, // HousingSelectDeed, HousingGardening, HousingGoods, HousingEditInterior, HousingEditExterior
    AllianceList = 70,
    LookingForGroup = 71,
    Credits = 72,
    HousingTravellersNote = 73,
    DTR = 74,
    RetainerCharacter = 75,
    AdventureNoteBook = 76,
    HousingChocoboList = 77,
    TripleTriad = 78,
    GSInfoGeneral = 79,
    RaceChocobo = 80,
    Currency = 81,
    BeginnerChannelMentorList = 82,
    BeginnerChannelBeginnerList = 83,

    PvPDuelRequest = 85,
    JobHud = 86,
    PvPTeam = 87,
    PvPTeamMember = 88,
    PvPTeamResult = 89,
    PvPTeamActivity = 90,

    ContentMemberList = 92,

    CrossWorldLinkShell = 94,

    Lovm = 97,

    LovmQueueList = 99,
    LovmNamePlate = 100,
    LovmMiniMap = 101,
    LovmActionDetail = 102,
    GoldSaucerArcadeMachine = 103, // PunchingMachine, BasketBall, Hammer, MogCatcher, MinerBotanistAim
    PvPProfile = 104,
    Orchestrion = 105,
    OrchestrionPlayListSelect = 106,
    RetainerTask = 107,
    YKWNote = 108,
    DeepDungeonNaviMap = 109,
    DeepDungeonStatus = 110,
    ProgressBar = 111,
    GcArmyExpedition = 112,
    GcArmyTraining = 113,
    GcArmyCapture = 114,
    PvPMKS = 116,
    PvPSpectatorCameraList = 117,
    PvPSpectatorList = 118,
    PvPFrontline = 119,
    LFGRecruiterNameSearch = 120,
    Snipe = 121,
    // TreasureHunt = 122, // unsure
    PVPSimulationHeader = 123,
    PVPSimulationAlliance = 124,
    PVPSimulationHeader2 = 125,
    PVPSimulationDisplay = 126,
    EurekaElementalHud = 127,
    Performance = 128,
    ContentsReplayPlayer = 129,
    SatisfactionSupplyChangeMiragePrism = 130,
    SatisfactionSupplyMiragePrism = 131,
    Description = 132, // DescriptionYTC, DescriptionDD
    Alarm = 133,
    Merchant = 134,
    MerchantEquipSelect = 135,
    EurekaLogosShardList = 136,
    EurekaLogosAetherList = 137,
    RhythmAction = 138,
    WorldTranslate = 139,
    Emj = 140,
    PerformanceGamepadGuide = 141,
    PerformanceMetronome = 142,
    PerformancePlayGuide = 143,
    CruisingInfo = 144,
    MYCInfo = 145,
    MYCItemBag = 146,
    WeeklyPuzzle = 147,
    TeleportTown = 148,
    PvPMKSNaviMap = 149,
    TurnBreak = 150,
    MJIHousingGoods = 151,
    FGSHud = 152,
    FGSResult = 153,
    MKDInfo = 154,
    MKDInfo2 = 155
}

public enum StringArrayType {
    ChatLog = 0,
    CharaSelect = 1,
    Hud = 2, // ParameterWidget, Status, Exp
    PartyList = 3,
    NamePlate = 4,
    ActionBar = 5,
    Inventory = 6,
    CharacterItems = 7,
    Hud2 = 8, // Notification, TargetInfo, ContentGauge, FocusTargetInfo
    Trade = 9,

    PartyMemberList = 11,

    LinkShell = 13,
    BlackList = 14,
    FriendList = 15,

    Letter = 17, // LetterList, LetterViewer
    SocialList = 18, // search results
    EnemyList = 19,
    CastBar = 20,
    AreaMap = 21,

    Journal = 23,
    ToDoList = 24,
    RecipeNote = 25,
    ItemDetail = 26, // search results and RetainerHistory
    FlyText = 27,
    ActionDetail = 28,

    InventoryRetainer = 30,
    MiniTalk = 31,
    CommonCurrencies = 32, // holds Gil, Grand Company Seals, Dark Matter; used by Repair, MateriaAttachDialog, GrandCompanyExchange, GrandCompanySupplyList
    ItemSearch = 33,
    BattleTalk = 34,
    ArmouryBoard = 35,
    FreeCompanyMember = 36,

    HousingBlackListSetting = 38,
    LegacyItemStorage = 39,
    FreeCompanyApplication = 40,
    GearSetList = 41,
    FreeCompanyRights = 42,
    CabinetStore = 43,
    CabinetWithdraw = 44,

    FreeCompanyActivity = 46,
    FreeCompanyExchange = 47,
    FreeCompanyStatus = 48,
    ConfigSystem = 49,

    NaviMap = 51,
    AreaMap2 = 52,
    ContentsFinderConfirm = 53,
    FreeCompanyChest = 54,
    Buddy = 55,
    //FreeCompanyExchange = 56,
    FreeCompanyAction = 57,
    RecommendList = 58,
    Character = 59, // Character, CharacterProfile, CharacterClass, CharacterRepute
    FishingNote = 60,
    FishGuide = 61,
    GearSetView = 62,
    HousingSignBoard = 63,
    Housing = 64, // HousingSelectDeed, HousingGardening, HousingGoods, HousingEditInterior, HousingEditExterior
    AllianceList = 65,
    LookingForGroup = 66,
    HousingTravellersNote = 67,
    DTR = 68,
    //PadMouseMode = 69,
    RetainerCharacter = 70,
    AdventureNoteBook = 71,
    HousingChocoboList = 72,
    TripleTriad = 73,
    LimitBreak = 74,
    RaceChocobo = 75,
    Currency = 76,
    BeginnerChannelMentorList = 77,
    BeginnerChannelBeginnerList = 78,
    PvPDuelRequest = 79,
    JobHud = 80,
    PvPTeam = 81,
    PvPTeamMember = 82,
    PvPTeamResult = 83,
    PvPTeamActivity = 84,
    ContentMemberList = 85,

    CrossWorldLinkShell = 87,
    LovmNamePlate = 88,
    LovmActionDetail = 89,
    LovmResult = 90,
    Lovm = 91,

    PvPProfile = 93,
    Orchestrion = 94,
    OrchestrionPlayListSelect = 95,

    RetainerTask = 97,
    YKWNote = 98,
    DeepDungeonNaviMap = 99,
    DeepDungeonStatus = 100,
    GcArmyExpedition = 101,
    GcArmyTraining = 102,
    GcArmyCapture = 103,
    PvPMKS = 104,
    PvPSpectatorList = 105,
    LFGRecruiterNameSearch = 106,
    Snipe = 107,
    Performance = 108,
    ContentsReplayPlayer = 109,
    SatisfactionSupplyChangeMiragePrism = 110,
    SatisfactionSupplyMiragePrism = 111,
    Alarm = 112,
    Merchant = 113,
    MerchantEquipSelect = 114,
    EurekaLogosShardList = 115,
    RhythmAction = 116,
    WorldTranslate = 117,
    PVPSimulationHeader2 = 118,
    PVPSimulationDisplay = 119,
    Emj = 120,
    WeeklyPuzzle = 121,
    MYCInfo = 122,
    TeleportTown = 123,
    MJIHousingGoods = 124,
}

public enum ExtendArrayType {
    AreaMapSubZones = 1,
    NaviMapMapMarkers = 2, // Pointers to MapMarkerBase?
}

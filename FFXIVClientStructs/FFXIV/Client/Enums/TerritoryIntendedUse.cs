namespace FFXIVClientStructs.FFXIV.Client.Enums;

public enum TerritoryIntendedUse : byte {
    Town = 0,
    Overworld = 1,
    Inn = 2,
    /// <summary> Dungeons, Guildhests, Mahjong </summary>
    Dungeon = 3,
    VariantDungeon = 4,
    MordionGaol = 5,
    OpeningArea = 6,
    BeforeTrialDung = 7,
    AllianceRaid = 8,
    PreEwOverworldQuestBattle = 9,
    Trial = 10,
    Unknown11 = 11, // unused
    WaitingRoom = 12,
    HousingOutdoor = 13,
    HousingIndoor = 14,
    SoloOverworldInstances = 15,
    /// <summary> Raids with trash mobs in the beginning. Can revive self, but won't be able to re-enter ongoing battles. </summary>
    Raid1 = 16,
    /// <summary> Raids with boss arena. Unable to self-revive. </summary>
    Raid2 = 17,
    Frontline = 18,
    ChocoboSquareOld = 19, // unused
    ChocoboRacing = 20,
    Firmament = 21,
    /// <summary> Wedding </summary>
    SanctumOfTheTwelve = 22,
    GoldSaucer = 23,
    OriginalStepsOfFaith = 24, // unused
    LordOfVerminion = 25,
    ExploratoryMissions = 26,
    HallOfTheNovice = 27,
    CrystallineConflict = 28,
    SoloDuty = 29,
    GrandCompanyBarracks = 30,
    DeepDungeon = 31,
    /// <summary> During the Starlight Celebration, the music in Lower Jeuno will change to a Christmas version. </summary>
    Seasonal = 32,
    TreasureMapInstance = 33,
    SeasonalInstancedArea = 34,
    TripleTriadBattlehall = 35,
    ChaoticRaid = 36,
    CrystallineConflictCustomMatch = 37,
    HuntingGrounds = 38, // Diadem
    RivalWings = 39,
    /// <summary> Mordion Gaol (The Rising 2017), Frondale's Home for Friendless Foundlings, Starlight Stalls </summary>
    Seasonal2 = 40,
    Eureka = 41,
    Unknown42 = 42, // unused, was Crystal Tower Training Grounds
    TheCalamityRetold = 43,
    LeapOfFaith = 44,
    MaskedCarnival = 45,
    OceanFishing = 46,
    Diadem = 47,
    Bozja = 48,
    IslandSanctuary = 49,
    TripleTriadOpenTournament = 50,
    TripleTriadInvitationalParlor = 51,
    DelubrumReginae = 52,
    DelubrumReginaeSavage = 53,
    /// <summary> Propylaion and Ultima Thule </summary>
    EndwalkerMsqSoloOverworld = 54,
    Unknown55 = 55, // unused
    Elysion = 56,
    CriterionDungeon = 57,
    CriterionDungeonSavage = 58,
    Blunderville = 59,
    CosmicExploration = 60,
    OccultCrescent = 61,
    Unknown62 = 62,
    /// <summary> Lilyswim (Hatching-tide 2026) </summary>
    Seasonal3 = 63,
    AirForceOne = 64,
    KeyboundBrawler = 65,
    Unknown66 = 66,
}

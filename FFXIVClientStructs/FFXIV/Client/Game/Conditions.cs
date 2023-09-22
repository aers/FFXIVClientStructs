namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Sequential, Size = 104)]
public unsafe partial struct Conditions {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8D 50 77 E8 ?? ?? ?? ?? 48 8B 5C 24", 3)]
    public static partial Conditions* Instance();

    public fixed bool Flags[104];
}

/// <summary>
/// This enum is used to generate static getters in <see cref="Conditions"/> via ConditionsGenerator, prefixed by "Is".<br/>
/// It is recommended to avoid using the enum. If possible, use the getters.
/// </summary>
/// <remarks>
/// Names are based on the LogMessage entry linked in the Condition sheet.
/// </remarks>
public enum ConditionFlag {
    /// <summary>
    /// Unused and excluded in ConditionsGenerator.
    /// </summary>
    None,

    /// <summary>
    /// Unable to execute command under normal conditions.
    /// </summary>
    NormalConditions,

    /// <summary>
    /// Unable to execute command while unconscious.
    /// </summary>
    Unconscious,

    /// <summary>
    /// Unable to execute command during an emote.
    /// </summary>
    Emoting,

    /// <summary>
    /// Unable to execute command while mounted.
    /// </summary>
    Mounted,

    /// <summary>
    /// Unable to execute command while crafting.
    /// </summary>
    Crafting,

    /// <summary>
    /// Unable to execute command while gathering.
    /// </summary>
    Gathering,

    /// <summary>
    /// Unable to execute command while melding materia.
    /// </summary>
    MeldingMateria,

    /// <summary>
    /// Unable to execute command while operating a siege machine.
    /// </summary>
    OperatingSiegeMachine,

    /// <summary>
    /// Unable to execute command while carrying an object.
    /// </summary>
    CarryingObject,

    /// <summary>
    /// Unable to execute command while mounted.
    /// </summary>
    Mounted2,

    /// <summary>
    /// Unable to execute command while in that position.
    /// </summary>
    InThatPosition,

    /// <summary>
    /// Unable to execute command while chocobo racing.
    /// </summary>
    ChocoboRacing,

    /// <summary>
    /// Unable to execute command while playing a mini-game.
    /// </summary>
    PlayingMiniGame,

    /// <summary>
    /// Unable to execute command while playing Lord of Verminion.
    /// </summary>
    PlayingLordOfVerminion,

    /// <summary>
    /// Unable to execute command while participating in a custom match.
    /// </summary>
    ParticipatingInCustomMatch,

    /// <summary>
    /// Unable to execute command while performing.
    /// </summary>
    Performing,

    Unknown17,
    Unknown18,
    Unknown19,
    Unknown20,
    Unknown21,
    Unknown22,
    Unknown23,
    Unknown24,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    Occupied,

    /// <summary>
    /// Unable to execute command during combat.
    /// </summary>
    InCombat,

    /// <summary>
    /// Unable to execute command while casting.
    /// </summary>
    Casting,

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    SufferingStatusAffliction,

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    SufferingStatusAffliction2,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    Occupied30,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    // todo: not sure if this is used for other event states/???
    OccupiedInEvent,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    OccupiedInQuestEvent,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    Occupied33,

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    BoundByDuty,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    OccupiedInCutSceneEvent,

    /// <summary>
    /// Unable to execute command while in a dueling area.
    /// </summary>
    InDuelingArea,

    /// <summary>
    /// Unable to execute command while a trade is open.
    /// </summary>
    TradeOpen,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    Occupied38,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    Occupied39,

    /// <summary>
    /// Unable to execute command while crafting.
    /// </summary>
    Crafting40,

    /// <summary>
    /// Unable to execute command while preparing to craft.
    /// </summary>
    PreparingToCraft,

    /// <summary>
    /// Unable to execute command while gathering.
    /// </summary>
    Gathering42,

    /// <summary>
    /// Unable to execute command while fishing.
    /// </summary>
    Fishing,

    Unknown44,

    /// <summary>
    /// Unable to execute command while between areas.
    /// </summary>
    InBetweenAreas,

    /// <summary>
    /// Unable to execute command while stealthed.
    /// </summary>
    Stealthed,

    Unknown47,

    /// <summary>
    /// Unable to execute command while jumping.
    /// </summary>
    Jumping,

    /// <summary>
    /// Unable to execute command while auto-run is active.
    /// </summary>
    AutorunActive,

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    // todo: used for other shits?
    OccupiedSummoningBell,

    /// <summary>
    /// Unable to execute command while between areas.
    /// </summary>
    InBetweenAreas51,

    /// <summary>
    /// Unable to execute command due to system error.
    /// </summary>
    SystemError,

    /// <summary>
    /// Unable to execute command while logging out.
    /// </summary>
    LoggingOut,

    /// <summary>
    /// Unable to execute command at this location.
    /// </summary>
    ConditionLocation,

    /// <summary>
    /// Unable to execute command while waiting for duty.
    /// </summary>
    WaitingForDuty,

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    BoundByDuty56,

    /// <summary>
    /// Unable to execute command at this time.
    /// </summary>
    Unknown57,

    /// <summary>
    /// Unable to execute command while watching a cutscene.
    /// </summary>
    WatchingCutscene,

    /// <summary>
    /// Unable to execute command while waiting for Duty Finder.
    /// </summary>
    WaitingForDutyFinder,

    /// <summary>
    /// Unable to execute command while creating a character.
    /// </summary>
    CreatingCharacter,

    /// <summary>
    /// Unable to execute command while jumping.
    /// </summary>
    Jumping61,

    /// <summary>
    /// Unable to execute command while the PvP display is active.
    /// </summary>
    PvPDisplayActive,

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    SufferingStatusAffliction63,

    /// <summary>
    /// Unable to execute command while mounting.
    /// </summary>
    Mounting,

    /// <summary>
    /// Unable to execute command while carrying an item.
    /// </summary>
    CarryingItem,

    /// <summary>
    /// Unable to execute command while using the Party Finder.
    /// </summary>
    UsingPartyFinder,

    /// <summary>
    /// Unable to execute command while using housing functions.
    /// </summary>
    UsingHousingFunctions,

    /// <summary>
    /// Unable to execute command while transformed.
    /// </summary>
    Transformed,

    /// <summary>
    /// Unable to execute command while on the free trial.
    /// </summary>
    OnFreeTrial,

    /// <summary>
    /// Unable to execute command while being moved.
    /// </summary>
    BeingMoved,

    /// <summary>
    /// Unable to execute command while mounting.
    /// </summary>
    Mounting71,

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    SufferingStatusAffliction72,

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    SufferingStatusAffliction73,

    /// <summary>
    /// Unable to execute command while registering for a race or match.
    /// </summary>
    RegisteringForRaceOrMatch,

    /// <summary>
    /// Unable to execute command while waiting for a race or match.
    /// </summary>
    WaitingForRaceOrMatch,

    /// <summary>
    /// Unable to execute command while waiting for a Triple Triad match.
    /// </summary>
    WaitingForTripleTriadMatch,

    /// <summary>
    /// Unable to execute command while in flight.
    /// </summary>
    InFlight,

    /// <summary>
    /// Unable to execute command while watching a cutscene.
    /// </summary>
    WatchingCutscene78,

    /// <summary>
    /// Unable to execute command while delving into a deep dungeon.
    /// </summary>
    InDeepDungeon,

    /// <summary>
    /// Unable to execute command while swimming.
    /// </summary>
    Swimming,

    /// <summary>
    /// Unable to execute command while diving.
    /// </summary>
    Diving,

    /// <summary>
    /// Unable to execute command while registering for a Triple Triad match.
    /// </summary>
    RegisteringForTripleTriadMatch,

    /// <summary>
    /// Unable to execute command while waiting for a Triple Triad match.
    /// </summary>
    WaitingForTripleTriadMatch83,

    /// <summary>
    /// Unable to execute command while participating in a cross-world party or alliance.
    /// </summary>
    ParticipatingInCrossWorldPartyOrAlliance,

    Unknown85,

    /// <summary>
    /// Unable to execute command while playing duty record.
    /// </summary>
    DutyRecorderPlayback,

    /// <summary>
    /// Unable to execute command while casting.
    /// </summary>
    Casting87,

    /// <summary>
    /// Unable to execute command in this state.
    /// </summary>
    InThisState88,

    /// <summary>
    /// Unable to execute command in this state.
    /// </summary>
    InThisState89,

    /// <summary>
    /// Unable to execute command while role-playing.
    /// </summary>
    RolePlaying,

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    BoundToDuty97,

    /// <summary>
    /// Unable to execute command while readying to visit another World.
    /// </summary>
    ReadyingVisitOtherWorld,

    /// <summary>
    /// Unable to execute command while waiting to visit another World.
    /// </summary>
    WaitingToVisitOtherWorld,

    /// <summary>
    /// Unable to execute command while using a parasol.
    /// </summary>
    UsingParasol,

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    BoundByDuty95,

    /// <summary>
    /// Cannot execute at this time.
    /// </summary>
    Unknown96,

    /// <summary>
    /// Unable to execute command while wearing a guise.
    /// </summary>
    Disguised,

    /// <summary>
    /// Unable to execute command while recruiting for a non-cross-world party.
    /// </summary>
    RecruitingWorldOnly,

    /// <summary>
    /// Command unavailable in this location.
    /// </summary>
    Unknown99,

    /// <summary>
    /// Unable to execute command while editing a portrait.
    /// </summary>
    EditingPortrait,

    Unknown101,
    Unknown102,
    Unknown103,
}

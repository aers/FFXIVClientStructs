namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::Condition
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 104 + 4)]
public unsafe partial struct Conditions {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 66 2B D8", 3)]
    public static partial Conditions* Instance();

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray104<bool> _flags;
    [FieldOffset(0)] public bool None;
    [FieldOffset(1)] public bool Normal;
    [FieldOffset(2)] public bool Dead;
    [FieldOffset(3)] public bool Emoting;
    [FieldOffset(4)] public bool Mounted;
    [FieldOffset(5)] public bool Crafting;
    [FieldOffset(6)] public bool Gathering;
    [FieldOffset(7)] public bool MeldingMateria;
    [FieldOffset(8)] public bool AnimLock;
    [FieldOffset(9)] public bool Carrying;
    [FieldOffset(10)] public bool RidingPillion;
    [FieldOffset(11)] public bool InThatPosition;
    [FieldOffset(12)] public bool ChocoboRacing;
    [FieldOffset(13)] public bool PlayingMiniGame; // TripleTriad?
    [FieldOffset(14)] public bool PlayingLordOfVerminion;
    [FieldOffset(15)] public bool ParticipatingInCustomMatch;
    [FieldOffset(16)] public bool Performing;
    [FieldOffset(17)] public bool Unknown17;
    [FieldOffset(18)] public bool Unknown18;
    [FieldOffset(19)] public bool Unknown19;
    [FieldOffset(20)] public bool Unknown20;
    [FieldOffset(21)] public bool Unknown21;
    [FieldOffset(22)] public bool Unknown22;
    [FieldOffset(23)] public bool Unknown23;
    [FieldOffset(24)] public bool Unknown24; // used as loop end? MAX_CHARACTER_MODE??
    [FieldOffset(25)] public bool Occupied;
    [FieldOffset(26)] public bool InCombat;
    [FieldOffset(27)] public bool Casting;
    [FieldOffset(28)] public bool SufferingStatusAffliction;
    [FieldOffset(29)] public bool SufferingStatusAffliction2;
    [FieldOffset(30)] public bool Occupied30;
    [FieldOffset(31)] public bool OccupiedInEvent;
    [FieldOffset(32)] public bool OccupiedInQuestEvent;
    [FieldOffset(33)] public bool Occupied33;
    [FieldOffset(34)] public bool BoundByDuty;
    [FieldOffset(35)] public bool OccupiedInCutSceneEvent;
    [FieldOffset(36)] public bool InDuelingArea;
    [FieldOffset(37)] public bool TradeOpen;
    [FieldOffset(38)] public bool Occupied38;
    /// <remarks> Observed during Materialize (Desynthesis, Materia Extraction, Aetherial Reduction) and Repair. </remarks>
    [FieldOffset(39)] public bool Occupied39;
    [FieldOffset(40)] public bool ExecutingCraftingAction;
    [FieldOffset(40), Obsolete("Renamed to ExecutingCraftingAction")] public bool Crafting40;
    [FieldOffset(41)] public bool PreparingToCraft;
    [FieldOffset(42)] public bool ExecutingGatheringAction; // includes Fishing
    [FieldOffset(42), Obsolete("Renamed to ExecutingGatheringAction")] public bool Gathering42;
    [FieldOffset(43)] public bool Fishing;
    [FieldOffset(44)] public bool Unknown44;
    [FieldOffset(45)] public bool BetweenAreas;
    [FieldOffset(46)] public bool Stealthed;
    [FieldOffset(47)] public bool Unknown47;
    [FieldOffset(48)] public bool Jumping;
    [FieldOffset(49)] public bool UsingChocoboTaxi;
    [FieldOffset(49), Obsolete("To avoid confusion, renamed to UsingChocoboTaxi.", true)] public bool AutorunActive;
    [FieldOffset(50)] public bool OccupiedSummoningBell;
    [FieldOffset(51)] public bool BetweenAreas51;
    [FieldOffset(52)] public bool SystemError;
    [FieldOffset(53)] public bool LoggingOut;
    [FieldOffset(54)] public bool ConditionLocation;
    [FieldOffset(55)] public bool WaitingForDuty;
    [FieldOffset(56)] public bool BoundByDuty56;
    [FieldOffset(57)] public bool MountOrOrnamentTransition;
    [FieldOffset(57), Obsolete("Renamed to MountOrOrnamentTransition.", true)] public bool Unknown57;
    [FieldOffset(58)] public bool WatchingCutscene;
    [FieldOffset(59)] public bool WaitingForDutyFinder;
    [FieldOffset(60)] public bool CreatingCharacter;
    [FieldOffset(61)] public bool Jumping61;
    [FieldOffset(62)] public bool PvPDisplayActive;
    [FieldOffset(63)] public bool SufferingStatusAffliction63;
    [FieldOffset(64)] public bool Mounting;
    [FieldOffset(65)] public bool CarryingItem;
    [FieldOffset(66)] public bool UsingPartyFinder;
    [FieldOffset(67)] public bool UsingHousingFunctions;
    [FieldOffset(68)] public bool Transformed;
    [FieldOffset(69)] public bool OnFreeTrial;
    [FieldOffset(70)] public bool BeingMoved;
    /// <remarks> Observed in Cosmic Exploration while using the actions Astrodrill (only briefly) and Solar Flarethrower. </remarks>
    [FieldOffset(71)] public bool Mounting71;
    [FieldOffset(72)] public bool SufferingStatusAffliction72;
    [FieldOffset(73)] public bool SufferingStatusAffliction73;
    [FieldOffset(74)] public bool RegisteringForRaceOrMatch;
    [FieldOffset(75)] public bool WaitingForRaceOrMatch;
    [FieldOffset(76)] public bool WaitingForTripleTriadMatch;
    [FieldOffset(77)] public bool InFlight;
    [FieldOffset(78)] public bool WatchingCutscene78;
    [FieldOffset(79)] public bool InDeepDungeon;
    [FieldOffset(80)] public bool Swimming;
    [FieldOffset(81)] public bool Diving;
    [FieldOffset(82)] public bool RegisteringForTripleTriadMatch;
    [FieldOffset(83)] public bool WaitingForTripleTriadMatch83;
    [FieldOffset(84)] public bool ParticipatingInCrossWorldPartyOrAlliance;
    /// <remarks> Observed in Cosmic Exploration while gathering during a stellar mission. </remarks>
    [FieldOffset(85)] public bool Unknown85;
    [FieldOffset(86)] public bool DutyRecorderPlayback;
    [FieldOffset(87)] public bool Casting87;
    [FieldOffset(88)] public bool MountImmobile;
    [FieldOffset(89)] public bool InThisState89;
    [FieldOffset(90)] public bool RolePlaying;
    [FieldOffset(91)] public bool InDutyQueue;
    [FieldOffset(92)] public bool ReadyingVisitOtherWorld;
    [FieldOffset(93)] public bool WaitingToVisitOtherWorld;
    [FieldOffset(94)] public bool UsingFashionAccessory;
    [FieldOffset(94), Obsolete("Renamed to UsingFashionAccessory.", true)] public bool UsingParasol;
    [FieldOffset(95)] public bool BoundByDuty95;
    /// <remarks> Observed in Cosmic Exploration while participating in MechaEvent. </remarks>
    [FieldOffset(96)] public bool Unknown96;
    [FieldOffset(97)] public bool Disguised;
    [FieldOffset(98)] public bool RecruitingWorldOnly;
    [FieldOffset(99)] public bool Unknown99;
    [FieldOffset(100)] public bool EditingPortrait;
    /// <remarks> Observed in Cosmic Exploration, in mech flying to FATE or during Cosmoliner use. Maybe ClientPath related? </remarks>
    [FieldOffset(101)] public bool Unknown101;
    /// <remarks> Used in Cosmic Exploration. </remarks>
    [FieldOffset(102)] public bool PilotingMech;
    [FieldOffset(102), Obsolete("Renamed to PilotingMech")] public bool Unknown102;
    [FieldOffset(103)] public bool Unknown103;
    /// <remarks> When this reaches <c>0</c>, <see cref="MountOrOrnamentTransition"/> is set to <c>false</c>. </remarks>
    [FieldOffset(104)] public float MountOrOrnamentTransitionResetTimer;
    [FieldOffset(104), Obsolete("Renamed to MountOrOrnamentTransitionResetTimer", true)] public float UnkTimer;
}

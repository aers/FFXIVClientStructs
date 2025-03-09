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
    [FieldOffset(39)] public bool Occupied39;
    [FieldOffset(40)] public bool Crafting40;
    [FieldOffset(41)] public bool PreparingToCraft;
    [FieldOffset(42)] public bool Gathering42;
    [FieldOffset(43)] public bool Fishing;
    [FieldOffset(44)] public bool Unknown44;
    [FieldOffset(45)] public bool BetweenAreas;
    [FieldOffset(46)] public bool Stealthed;
    [FieldOffset(47)] public bool Unknown47;
    [FieldOffset(48)] public bool Jumping;
    [FieldOffset(49)] public bool AutorunActive;
    [FieldOffset(50)] public bool OccupiedSummoningBell;
    [FieldOffset(51)] public bool BetweenAreas51;
    [FieldOffset(52)] public bool SystemError;
    [FieldOffset(53)] public bool LoggingOut;
    [FieldOffset(54)] public bool ConditionLocation;
    [FieldOffset(55)] public bool WaitingForDuty;
    [FieldOffset(56)] public bool BoundByDuty56;
    [FieldOffset(57)] public bool Unknown57;
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
    [FieldOffset(85)] public bool Unknown85;
    [FieldOffset(86)] public bool DutyRecorderPlayback;
    [FieldOffset(87)] public bool Casting87;
    [FieldOffset(88)] public bool MountImmobile;
    [FieldOffset(89)] public bool InThisState89;
    [FieldOffset(90)] public bool RolePlaying;
    [FieldOffset(91)] public bool InDutyQueue;
    [FieldOffset(92)] public bool ReadyingVisitOtherWorld;
    [FieldOffset(93)] public bool WaitingToVisitOtherWorld;
    [FieldOffset(94)] public bool UsingParasol;
    [FieldOffset(95)] public bool BoundByDuty95;
    [FieldOffset(96)] public bool Unknown96;
    [FieldOffset(97)] public bool Disguised;
    [FieldOffset(98)] public bool RecruitingWorldOnly;
    [FieldOffset(99)] public bool Unknown99;
    [FieldOffset(100)] public bool EditingPortrait;
    [FieldOffset(101)] public bool Unknown101;
    [FieldOffset(102)] public bool Unknown102;
    [FieldOffset(103)] public bool Unknown103;
    [FieldOffset(104)] public float UnkTimer; // used for Unknown57

    /// <summary>
    /// Unable to execute command under normal conditions.
    /// </summary>
    [Obsolete("Use field Normal", true)]
    public static bool IsNormalConditions => Instance()->Flags[1];

    /// <summary>
    /// Unable to execute command while unconscious.
    /// </summary>
    [Obsolete("Use field Dead", true)]
    public static bool IsUnconscious => Instance()->Flags[2];

    /// <summary>
    /// Unable to execute command during an emote.
    /// </summary>
    [Obsolete("Use field Emoting", true)]
    public static bool IsEmoting => Instance()->Flags[3];

    /// <summary>
    /// Unable to execute command while mounted.
    /// </summary>
    [Obsolete("Use field Mounted", true)]
    public static bool IsMounted => Instance()->Flags[4];

    /// <summary>
    /// Unable to execute command while crafting.
    /// </summary>
    [Obsolete("Use field Crafting", true)]
    public static bool IsCrafting => Instance()->Flags[5];

    /// <summary>
    /// Unable to execute command while gathering.
    /// </summary>
    [Obsolete("Use field Gathering", true)]
    public static bool IsGathering => Instance()->Flags[6];

    /// <summary>
    /// Unable to execute command while melding materia.
    /// </summary>
    [Obsolete("Use field MeldingMateria", true)]
    public static bool IsMeldingMateria => Instance()->Flags[7];

    /// <summary>
    /// Unable to execute command while operating a siege machine.
    /// </summary>
    [Obsolete("Use field AnimLock", true)]
    public static bool IsOperatingSiegeMachine => Instance()->Flags[8];

    /// <summary>
    /// Unable to execute command while carrying an object.
    /// </summary>
    [Obsolete("Use field Carrying", true)]
    public static bool IsCarryingObject => Instance()->Flags[9];

    /// <summary>
    /// Unable to execute command while mounted.
    /// </summary>
    [Obsolete("Use field RidingPillion", true)]
    public static bool IsMounted2 => Instance()->Flags[10];

    /// <summary>
    /// Unable to execute command while in that position.
    /// </summary>
    [Obsolete("Use field InThatPosition", true)]
    public static bool IsInThatPosition => Instance()->Flags[11];

    /// <summary>
    /// Unable to execute command while chocobo racing.
    /// </summary>
    [Obsolete("Use field ChocoboRacing", true)]
    public static bool IsChocoboRacing => Instance()->Flags[12];

    /// <summary>
    /// Unable to execute command while playing a mini-game.
    /// </summary>
    [Obsolete("Use field PlayingMiniGame", true)]
    public static bool IsPlayingMiniGame => Instance()->Flags[13];

    /// <summary>
    /// Unable to execute command while playing Lord of Verminion.
    /// </summary>
    [Obsolete("Use field PlayingLordOfVerminion", true)]
    public static bool IsPlayingLordOfVerminion => Instance()->Flags[14];

    /// <summary>
    /// Unable to execute command while participating in a custom match.
    /// </summary>
    [Obsolete("Use field ParticipatingInCustomMatch", true)]
    public static bool IsParticipatingInCustomMatch => Instance()->Flags[15];

    /// <summary>
    /// Unable to execute command while performing.
    /// </summary>
    [Obsolete("Use field Performing", true)]
    public static bool IsPerforming => Instance()->Flags[16];

    [Obsolete("Use field Unknown17", true)]
    public static bool IsUnknown17 => Instance()->Flags[17];

    [Obsolete("Use field Unknown18", true)]
    public static bool IsUnknown18 => Instance()->Flags[18];

    [Obsolete("Use field Unknown19", true)]
    public static bool IsUnknown19 => Instance()->Flags[19];

    [Obsolete("Use field Unknown20", true)]
    public static bool IsUnknown20 => Instance()->Flags[20];

    [Obsolete("Use field Unknown21", true)]
    public static bool IsUnknown21 => Instance()->Flags[21];

    [Obsolete("Use field Unknown22", true)]
    public static bool IsUnknown22 => Instance()->Flags[22];

    [Obsolete("Use field Unknown23", true)]
    public static bool IsUnknown23 => Instance()->Flags[23];

    [Obsolete("Use field Unknown24", true)]
    public static bool IsUnknown24 => Instance()->Flags[24];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field Occupied", true)]
    public static bool IsOccupied => Instance()->Flags[25];

    /// <summary>
    /// Unable to execute command during combat.
    /// </summary>
    [Obsolete("Use field InCombat", true)]
    public static bool IsInCombat => Instance()->Flags[26];

    /// <summary>
    /// Unable to execute command while casting.
    /// </summary>
    [Obsolete("Use field Casting", true)]
    public static bool IsCasting => Instance()->Flags[27];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    [Obsolete("Use field SufferingStatusAffliction", true)]
    public static bool IsSufferingStatusAffliction => Instance()->Flags[28];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    [Obsolete("Use field SufferingStatusAffliction2", true)]
    public static bool IsSufferingStatusAffliction2 => Instance()->Flags[29];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field Occupied30", true)]
    public static bool IsOccupied30 => Instance()->Flags[30];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field OccupiedInEvent", true)]
    public static bool IsOccupiedInEvent => Instance()->Flags[31];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field OccupiedInQuestEvent", true)]
    public static bool IsOccupiedInQuestEvent => Instance()->Flags[32];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field Occupied33", true)]
    public static bool IsOccupied33 => Instance()->Flags[33];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    [Obsolete("Use field BoundByDuty", true)]
    public static bool IsBoundByDuty => Instance()->Flags[34];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field OccupiedInCutSceneEvent", true)]
    public static bool IsOccupiedInCutSceneEvent => Instance()->Flags[35];

    /// <summary>
    /// Unable to execute command while in a dueling area.
    /// </summary>
    [Obsolete("Use field InDuelingArea", true)]
    public static bool IsInDuelingArea => Instance()->Flags[36];

    /// <summary>
    /// Unable to execute command while a trade is open.
    /// </summary>
    [Obsolete("Use field TradeOpen", true)]
    public static bool IsTradeOpen => Instance()->Flags[37];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field Occupied38", true)]
    public static bool IsOccupied38 => Instance()->Flags[38];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field Occupied39", true)]
    public static bool IsOccupied39 => Instance()->Flags[39];

    /// <summary>
    /// Unable to execute command while crafting.
    /// </summary>
    [Obsolete("Use field Crafting40", true)]
    public static bool IsCrafting40 => Instance()->Flags[40];

    /// <summary>
    /// Unable to execute command while preparing to craft.
    /// </summary>
    [Obsolete("Use field PreparingToCraft", true)]
    public static bool IsPreparingToCraft => Instance()->Flags[41];

    /// <summary>
    /// Unable to execute command while gathering.
    /// </summary>
    [Obsolete("Use field Gathering42", true)]
    public static bool IsGathering42 => Instance()->Flags[42];

    /// <summary>
    /// Unable to execute command while fishing.
    /// </summary>
    [Obsolete("Use field Fishing", true)]
    public static bool IsFishing => Instance()->Flags[43];

    [Obsolete("Use field Unknown44", true)]
    public static bool IsUnknown44 => Instance()->Flags[44];

    /// <summary>
    /// Unable to execute command while between areas.
    /// </summary>
    [Obsolete("Use field InBetweenAreas", true)]
    public static bool IsInBetweenAreas => Instance()->Flags[45];

    /// <summary>
    /// Unable to execute command while stealthed.
    /// </summary>
    [Obsolete("Use field Stealthed", true)]
    public static bool IsStealthed => Instance()->Flags[46];

    [Obsolete("Use field Unknown47", true)]
    public static bool IsUnknown47 => Instance()->Flags[47];

    /// <summary>
    /// Unable to execute command while jumping.
    /// </summary>
    [Obsolete("Use field Jumping", true)]
    public static bool IsJumping => Instance()->Flags[48];

    /// <summary>
    /// Unable to execute command while auto-run is active.
    /// </summary>
    [Obsolete("Use field AutorunActive", true)]
    public static bool IsAutorunActive => Instance()->Flags[49];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    [Obsolete("Use field OccupiedSummoningBell", true)]
    public static bool IsOccupiedSummoningBell => Instance()->Flags[50];

    /// <summary>
    /// Unable to execute command while between areas.
    /// </summary>
    [Obsolete("Use field InBetweenAreas51", true)]
    public static bool IsInBetweenAreas51 => Instance()->Flags[51];

    /// <summary>
    /// Unable to execute command due to system error.
    /// </summary>
    [Obsolete("Use field SystemError", true)]
    public static bool IsSystemError => Instance()->Flags[52];

    /// <summary>
    /// Unable to execute command while logging out.
    /// </summary>
    [Obsolete("Use field LoggingOut", true)]
    public static bool IsLoggingOut => Instance()->Flags[53];

    /// <summary>
    /// Unable to execute command at this location.
    /// </summary>
    [Obsolete("Use field ConditionLocation", true)]
    public static bool IsConditionLocation => Instance()->Flags[54];

    /// <summary>
    /// Unable to execute command while waiting for duty.
    /// </summary>
    [Obsolete("Use field WaitingForDuty", true)]
    public static bool IsWaitingForDuty => Instance()->Flags[55];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    [Obsolete("Use field BoundByDuty56", true)]
    public static bool IsBoundByDuty56 => Instance()->Flags[56];

    /// <summary>
    /// Unable to execute command at this time.
    /// </summary>
    [Obsolete("Use field Unknown57", true)]
    public static bool IsUnknown57 => Instance()->Flags[57];

    /// <summary>
    /// Unable to execute command while watching a cutscene.
    /// </summary>
    [Obsolete("Use field WatchingCutscene", true)]
    public static bool IsWatchingCutscene => Instance()->Flags[58];

    /// <summary>
    /// Unable to execute command while waiting for Duty Finder.
    /// </summary>
    [Obsolete("Use field WaitingForDutyFinder", true)]
    public static bool IsWaitingForDutyFinder => Instance()->Flags[59];

    /// <summary>
    /// Unable to execute command while creating a character.
    /// </summary>
    [Obsolete("Use field CreatingCharacter", true)]
    public static bool IsCreatingCharacter => Instance()->Flags[60];

    /// <summary>
    /// Unable to execute command while jumping.
    /// </summary>
    [Obsolete("Use field Jumping61", true)]
    public static bool IsJumping61 => Instance()->Flags[61];

    /// <summary>
    /// Unable to execute command while the PvP display is active.
    /// </summary>
    [Obsolete("Use field PvPDisplayActive", true)]
    public static bool IsPvPDisplayActive => Instance()->Flags[62];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    [Obsolete("Use field SufferingStatusAffliction63", true)]
    public static bool IsSufferingStatusAffliction63 => Instance()->Flags[63];

    /// <summary>
    /// Unable to execute command while mounting.
    /// </summary>
    [Obsolete("Use field Mounting", true)]
    public static bool IsMounting => Instance()->Flags[64];

    /// <summary>
    /// Unable to execute command while carrying an item.
    /// </summary>
    [Obsolete("Use field CarryingItem", true)]
    public static bool IsCarryingItem => Instance()->Flags[65];

    /// <summary>
    /// Unable to execute command while using the Party Finder.
    /// </summary>
    [Obsolete("Use field UsingPartyFinder", true)]
    public static bool IsUsingPartyFinder => Instance()->Flags[66];

    /// <summary>
    /// Unable to execute command while using housing functions.
    /// </summary>
    [Obsolete("Use field UsingHousingFunctions", true)]
    public static bool IsUsingHousingFunctions => Instance()->Flags[67];

    /// <summary>
    /// Unable to execute command while transformed.
    /// </summary>
    [Obsolete("Use field Transformed", true)]
    public static bool IsTransformed => Instance()->Flags[68];

    /// <summary>
    /// Unable to execute command while on the free trial.
    /// </summary>
    [Obsolete("Use field OnFreeTrial", true)]
    public static bool IsOnFreeTrial => Instance()->Flags[69];

    /// <summary>
    /// Unable to execute command while being moved.
    /// </summary>
    [Obsolete("Use field BeingMoved", true)]
    public static bool IsBeingMoved => Instance()->Flags[70];

    /// <summary>
    /// Unable to execute command while mounting.
    /// </summary>
    [Obsolete("Use field Mounting71", true)]
    public static bool IsMounting71 => Instance()->Flags[71];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    [Obsolete("Use field SufferingStatusAffliction72", true)]
    public static bool IsSufferingStatusAffliction72 => Instance()->Flags[72];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    [Obsolete("Use field SufferingStatusAffliction73", true)]
    public static bool IsSufferingStatusAffliction73 => Instance()->Flags[73];

    /// <summary>
    /// Unable to execute command while registering for a race or match.
    /// </summary>
    [Obsolete("Use field RegisteringForRaceOrMatch", true)]
    public static bool IsRegisteringForRaceOrMatch => Instance()->Flags[74];

    /// <summary>
    /// Unable to execute command while waiting for a race or match.
    /// </summary>
    [Obsolete("Use field WaitingForRaceOrMatch", true)]
    public static bool IsWaitingForRaceOrMatch => Instance()->Flags[75];

    /// <summary>
    /// Unable to execute command while waiting for a Triple Triad match.
    /// </summary>
    [Obsolete("Use field WaitingForTripleTriadMatch", true)]
    public static bool IsWaitingForTripleTriadMatch => Instance()->Flags[76];

    /// <summary>
    /// Unable to execute command while in flight.
    /// </summary>
    [Obsolete("Use field InFlight", true)]
    public static bool IsInFlight => Instance()->Flags[77];

    /// <summary>
    /// Unable to execute command while watching a cutscene.
    /// </summary>
    [Obsolete("Use field WatchingCutscene78", true)]
    public static bool IsWatchingCutscene78 => Instance()->Flags[78];

    /// <summary>
    /// Unable to execute command while delving into a deep dungeon.
    /// </summary>
    [Obsolete("Use field InDeepDungeon", true)]
    public static bool IsInDeepDungeon => Instance()->Flags[79];

    /// <summary>
    /// Unable to execute command while swimming.
    /// </summary>
    [Obsolete("Use field Swimming", true)]
    public static bool IsSwimming => Instance()->Flags[80];

    /// <summary>
    /// Unable to execute command while diving.
    /// </summary>
    [Obsolete("Use field Diving", true)]
    public static bool IsDiving => Instance()->Flags[81];

    /// <summary>
    /// Unable to execute command while registering for a Triple Triad match.
    /// </summary>
    [Obsolete("Use field RegisteringForTripleTriadMatch", true)]
    public static bool IsRegisteringForTripleTriadMatch => Instance()->Flags[82];

    /// <summary>
    /// Unable to execute command while waiting for a Triple Triad match.
    /// </summary>
    [Obsolete("Use field WaitingForTripleTriadMatch83", true)]
    public static bool IsWaitingForTripleTriadMatch83 => Instance()->Flags[83];

    /// <summary>
    /// Unable to execute command while participating in a cross-world party or alliance.
    /// </summary>
    [Obsolete("Use field ParticipatingInCrossWorldPartyOrAlliance", true)]
    public static bool IsParticipatingInCrossWorldPartyOrAlliance => Instance()->Flags[84];

    [Obsolete("Use field Unknown85", true)]
    public static bool IsUnknown85 => Instance()->Flags[85];

    /// <summary>
    /// Unable to execute command while playing duty record.
    /// </summary>
    [Obsolete("Use field DutyRecorderPlayback", true)]
    public static bool IsDutyRecorderPlayback => Instance()->Flags[86];

    /// <summary>
    /// Unable to execute command while casting.
    /// </summary>
    [Obsolete("Use field Casting87", true)]
    public static bool IsCasting87 => Instance()->Flags[87];

    /// <summary>
    /// Unable to execute command in this state.
    /// </summary>
    [Obsolete("Use field MountImmobile", true)]
    public static bool IsInThisState88 => Instance()->Flags[88];

    /// <summary>
    /// Unable to execute command in this state.
    /// </summary>
    [Obsolete("Use field MountImmobile", true)]
    public static bool IsMountImmobile => Instance()->Flags[88];

    /// <summary>
    /// Unable to execute command in this state.
    /// </summary>
    [Obsolete("Use field InThisState89", true)]
    public static bool IsInThisState89 => Instance()->Flags[89];

    /// <summary>
    /// Unable to execute command while role-playing.
    /// </summary>
    [Obsolete("Use field RolePlaying", true)]
    public static bool IsRolePlaying => Instance()->Flags[90];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    [Obsolete("Use field InDutyQueue", true)]
    public static bool IsBoundToDuty97 => Instance()->Flags[91];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    [Obsolete("Use field InDutyQueue", true)]
    public static bool IsInDutyQueue => Instance()->Flags[91];

    /// <summary>
    /// Unable to execute command while readying to visit another World.
    /// </summary>
    [Obsolete("Use field ReadyingVisitOtherWorld", true)]
    public static bool IsReadyingVisitOtherWorld => Instance()->Flags[92];

    /// <summary>
    /// Unable to execute command while waiting to visit another World.
    /// </summary>
    [Obsolete("Use field WaitingToVisitOtherWorld", true)]
    public static bool IsWaitingToVisitOtherWorld => Instance()->Flags[93];

    /// <summary>
    /// Unable to execute command while using a parasol.
    /// </summary>
    [Obsolete("Use field UsingParasol", true)]
    public static bool IsUsingParasol => Instance()->Flags[94];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    [Obsolete("Use field BoundByDuty95", true)]
    public static bool IsBoundByDuty95 => Instance()->Flags[95];

    /// <summary>
    /// Cannot execute at this time.
    /// </summary>
    [Obsolete("Use field Unknown96", true)]
    public static bool IsUnknown96 => Instance()->Flags[96];

    /// <summary>
    /// Unable to execute command while wearing a guise.
    /// </summary>
    [Obsolete("Use field Disguised", true)]
    public static bool IsDisguised => Instance()->Flags[97];

    /// <summary>
    /// Unable to execute command while recruiting for a non-cross-world party.
    /// </summary>
    [Obsolete("Use field RecruitingWorldOnly", true)]
    public static bool IsRecruitingWorldOnly => Instance()->Flags[98];

    /// <summary>
    /// Command unavailable in this location.
    /// </summary>
    [Obsolete("Use field Unknown99", true)]
    public static bool IsUnknown99 => Instance()->Flags[99];

    /// <summary>
    /// Unable to execute command while editing a portrait.
    /// </summary>
    [Obsolete("Use field EditingPortrait", true)]
    public static bool IsEditingPortrait => Instance()->Flags[100];

    [Obsolete("Use field Unknown101", true)]
    public static bool IsUnknown101 => Instance()->Flags[101];

    [Obsolete("Use field Unknown102", true)]
    public static bool IsUnknown102 => Instance()->Flags[102];

    [Obsolete("Use field Unknown103", true)]
    public static bool IsUnknown103 => Instance()->Flags[103];
}

namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Sequential, Size = 104)]
public unsafe partial struct Conditions {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8D 50 77 E8 ?? ?? ?? ?? 48 8B 5C 24", 3)]
    public static partial Conditions* Instance();

    public fixed bool Flags[104];

    /// <summary>
    /// Unable to execute command under normal conditions.
    /// </summary>
    public static bool IsNormalConditions => Instance()->Flags[1];

    /// <summary>
    /// Unable to execute command while unconscious.
    /// </summary>
    public static bool IsUnconscious => Instance()->Flags[2];

    /// <summary>
    /// Unable to execute command during an emote.
    /// </summary>
    public static bool IsEmoting => Instance()->Flags[3];

    /// <summary>
    /// Unable to execute command while mounted.
    /// </summary>
    public static bool IsMounted => Instance()->Flags[4];

    /// <summary>
    /// Unable to execute command while crafting.
    /// </summary>
    public static bool IsCrafting => Instance()->Flags[5];

    /// <summary>
    /// Unable to execute command while gathering.
    /// </summary>
    public static bool IsGathering => Instance()->Flags[6];

    /// <summary>
    /// Unable to execute command while melding materia.
    /// </summary>
    public static bool IsMeldingMateria => Instance()->Flags[7];

    /// <summary>
    /// Unable to execute command while operating a siege machine.
    /// </summary>
    public static bool IsOperatingSiegeMachine => Instance()->Flags[8];

    /// <summary>
    /// Unable to execute command while carrying an object.
    /// </summary>
    public static bool IsCarryingObject => Instance()->Flags[9];

    /// <summary>
    /// Unable to execute command while mounted.
    /// </summary>
    public static bool IsMounted2 => Instance()->Flags[10];

    /// <summary>
    /// Unable to execute command while in that position.
    /// </summary>
    public static bool IsInThatPosition => Instance()->Flags[11];

    /// <summary>
    /// Unable to execute command while chocobo racing.
    /// </summary>
    public static bool IsChocoboRacing => Instance()->Flags[12];

    /// <summary>
    /// Unable to execute command while playing a mini-game.
    /// </summary>
    public static bool IsPlayingMiniGame => Instance()->Flags[13];

    /// <summary>
    /// Unable to execute command while playing Lord of Verminion.
    /// </summary>
    public static bool IsPlayingLordOfVerminion => Instance()->Flags[14];

    /// <summary>
    /// Unable to execute command while participating in a custom match.
    /// </summary>
    public static bool IsParticipatingInCustomMatch => Instance()->Flags[15];

    /// <summary>
    /// Unable to execute command while performing.
    /// </summary>
    public static bool IsPerforming => Instance()->Flags[16];

    public static bool IsUnknown17 => Instance()->Flags[17];

    public static bool IsUnknown18 => Instance()->Flags[18];

    public static bool IsUnknown19 => Instance()->Flags[19];

    public static bool IsUnknown20 => Instance()->Flags[20];

    public static bool IsUnknown21 => Instance()->Flags[21];

    public static bool IsUnknown22 => Instance()->Flags[22];

    public static bool IsUnknown23 => Instance()->Flags[23];

    public static bool IsUnknown24 => Instance()->Flags[24];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupied => Instance()->Flags[25];

    /// <summary>
    /// Unable to execute command during combat.
    /// </summary>
    public static bool IsInCombat => Instance()->Flags[26];

    /// <summary>
    /// Unable to execute command while casting.
    /// </summary>
    public static bool IsCasting => Instance()->Flags[27];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    public static bool IsSufferingStatusAffliction => Instance()->Flags[28];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    public static bool IsSufferingStatusAffliction2 => Instance()->Flags[29];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupied30 => Instance()->Flags[30];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupiedInEvent => Instance()->Flags[31];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupiedInQuestEvent => Instance()->Flags[32];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupied33 => Instance()->Flags[33];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    public static bool IsBoundByDuty => Instance()->Flags[34];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupiedInCutSceneEvent => Instance()->Flags[35];

    /// <summary>
    /// Unable to execute command while in a dueling area.
    /// </summary>
    public static bool IsInDuelingArea => Instance()->Flags[36];

    /// <summary>
    /// Unable to execute command while a trade is open.
    /// </summary>
    public static bool IsTradeOpen => Instance()->Flags[37];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupied38 => Instance()->Flags[38];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupied39 => Instance()->Flags[39];

    /// <summary>
    /// Unable to execute command while crafting.
    /// </summary>
    public static bool IsCrafting40 => Instance()->Flags[40];

    /// <summary>
    /// Unable to execute command while preparing to craft.
    /// </summary>
    public static bool IsPreparingToCraft => Instance()->Flags[41];

    /// <summary>
    /// Unable to execute command while gathering.
    /// </summary>
    public static bool IsGathering42 => Instance()->Flags[42];

    /// <summary>
    /// Unable to execute command while fishing.
    /// </summary>
    public static bool IsFishing => Instance()->Flags[43];

    public static bool IsUnknown44 => Instance()->Flags[44];

    /// <summary>
    /// Unable to execute command while between areas.
    /// </summary>
    public static bool IsInBetweenAreas => Instance()->Flags[45];

    /// <summary>
    /// Unable to execute command while stealthed.
    /// </summary>
    public static bool IsStealthed => Instance()->Flags[46];

    public static bool IsUnknown47 => Instance()->Flags[47];

    /// <summary>
    /// Unable to execute command while jumping.
    /// </summary>
    public static bool IsJumping => Instance()->Flags[48];

    /// <summary>
    /// Unable to execute command while auto-run is active.
    /// </summary>
    public static bool IsAutorunActive => Instance()->Flags[49];

    /// <summary>
    /// Unable to execute command while occupied.
    /// </summary>
    public static bool IsOccupiedSummoningBell => Instance()->Flags[50];

    /// <summary>
    /// Unable to execute command while between areas.
    /// </summary>
    public static bool IsInBetweenAreas51 => Instance()->Flags[51];

    /// <summary>
    /// Unable to execute command due to system error.
    /// </summary>
    public static bool IsSystemError => Instance()->Flags[52];

    /// <summary>
    /// Unable to execute command while logging out.
    /// </summary>
    public static bool IsLoggingOut => Instance()->Flags[53];

    /// <summary>
    /// Unable to execute command at this location.
    /// </summary>
    public static bool IsConditionLocation => Instance()->Flags[54];

    /// <summary>
    /// Unable to execute command while waiting for duty.
    /// </summary>
    public static bool IsWaitingForDuty => Instance()->Flags[55];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    public static bool IsBoundByDuty56 => Instance()->Flags[56];

    /// <summary>
    /// Unable to execute command at this time.
    /// </summary>
    public static bool IsUnknown57 => Instance()->Flags[57];

    /// <summary>
    /// Unable to execute command while watching a cutscene.
    /// </summary>
    public static bool IsWatchingCutscene => Instance()->Flags[58];

    /// <summary>
    /// Unable to execute command while waiting for Duty Finder.
    /// </summary>
    public static bool IsWaitingForDutyFinder => Instance()->Flags[59];

    /// <summary>
    /// Unable to execute command while creating a character.
    /// </summary>
    public static bool IsCreatingCharacter => Instance()->Flags[60];

    /// <summary>
    /// Unable to execute command while jumping.
    /// </summary>
    public static bool IsJumping61 => Instance()->Flags[61];

    /// <summary>
    /// Unable to execute command while the PvP display is active.
    /// </summary>
    public static bool IsPvPDisplayActive => Instance()->Flags[62];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    public static bool IsSufferingStatusAffliction63 => Instance()->Flags[63];

    /// <summary>
    /// Unable to execute command while mounting.
    /// </summary>
    public static bool IsMounting => Instance()->Flags[64];

    /// <summary>
    /// Unable to execute command while carrying an item.
    /// </summary>
    public static bool IsCarryingItem => Instance()->Flags[65];

    /// <summary>
    /// Unable to execute command while using the Party Finder.
    /// </summary>
    public static bool IsUsingPartyFinder => Instance()->Flags[66];

    /// <summary>
    /// Unable to execute command while using housing functions.
    /// </summary>
    public static bool IsUsingHousingFunctions => Instance()->Flags[67];

    /// <summary>
    /// Unable to execute command while transformed.
    /// </summary>
    public static bool IsTransformed => Instance()->Flags[68];

    /// <summary>
    /// Unable to execute command while on the free trial.
    /// </summary>
    public static bool IsOnFreeTrial => Instance()->Flags[69];

    /// <summary>
    /// Unable to execute command while being moved.
    /// </summary>
    public static bool IsBeingMoved => Instance()->Flags[70];

    /// <summary>
    /// Unable to execute command while mounting.
    /// </summary>
    public static bool IsMounting71 => Instance()->Flags[71];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    public static bool IsSufferingStatusAffliction72 => Instance()->Flags[72];

    /// <summary>
    /// Unable to execute command while suffering status affliction.
    /// </summary>
    public static bool IsSufferingStatusAffliction73 => Instance()->Flags[73];

    /// <summary>
    /// Unable to execute command while registering for a race or match.
    /// </summary>
    public static bool IsRegisteringForRaceOrMatch => Instance()->Flags[74];

    /// <summary>
    /// Unable to execute command while waiting for a race or match.
    /// </summary>
    public static bool IsWaitingForRaceOrMatch => Instance()->Flags[75];

    /// <summary>
    /// Unable to execute command while waiting for a Triple Triad match.
    /// </summary>
    public static bool IsWaitingForTripleTriadMatch => Instance()->Flags[76];

    /// <summary>
    /// Unable to execute command while in flight.
    /// </summary>
    public static bool IsInFlight => Instance()->Flags[77];

    /// <summary>
    /// Unable to execute command while watching a cutscene.
    /// </summary>
    public static bool IsWatchingCutscene78 => Instance()->Flags[78];

    /// <summary>
    /// Unable to execute command while delving into a deep dungeon.
    /// </summary>
    public static bool IsInDeepDungeon => Instance()->Flags[79];

    /// <summary>
    /// Unable to execute command while swimming.
    /// </summary>
    public static bool IsSwimming => Instance()->Flags[80];

    /// <summary>
    /// Unable to execute command while diving.
    /// </summary>
    public static bool IsDiving => Instance()->Flags[81];

    /// <summary>
    /// Unable to execute command while registering for a Triple Triad match.
    /// </summary>
    public static bool IsRegisteringForTripleTriadMatch => Instance()->Flags[82];

    /// <summary>
    /// Unable to execute command while waiting for a Triple Triad match.
    /// </summary>
    public static bool IsWaitingForTripleTriadMatch83 => Instance()->Flags[83];

    /// <summary>
    /// Unable to execute command while participating in a cross-world party or alliance.
    /// </summary>
    public static bool IsParticipatingInCrossWorldPartyOrAlliance => Instance()->Flags[84];

    public static bool IsUnknown85 => Instance()->Flags[85];

    /// <summary>
    /// Unable to execute command while playing duty record.
    /// </summary>
    public static bool IsDutyRecorderPlayback => Instance()->Flags[86];

    /// <summary>
    /// Unable to execute command while casting.
    /// </summary>
    public static bool IsCasting87 => Instance()->Flags[87];

    /// <summary>
    /// Unable to execute command in this state.
    /// </summary>
    public static bool IsInThisState88 => Instance()->Flags[88];

    /// <summary>
    /// Unable to execute command in this state.
    /// </summary>
    public static bool IsInThisState89 => Instance()->Flags[89];

    /// <summary>
    /// Unable to execute command while role-playing.
    /// </summary>
    public static bool IsRolePlaying => Instance()->Flags[90];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    public static bool IsBoundToDuty97 => Instance()->Flags[91];

    /// <summary>
    /// Unable to execute command while readying to visit another World.
    /// </summary>
    public static bool IsReadyingVisitOtherWorld => Instance()->Flags[92];

    /// <summary>
    /// Unable to execute command while waiting to visit another World.
    /// </summary>
    public static bool IsWaitingToVisitOtherWorld => Instance()->Flags[93];

    /// <summary>
    /// Unable to execute command while using a parasol.
    /// </summary>
    public static bool IsUsingParasol => Instance()->Flags[94];

    /// <summary>
    /// Unable to execute command while bound by duty.
    /// </summary>
    public static bool IsBoundByDuty95 => Instance()->Flags[95];

    /// <summary>
    /// Cannot execute at this time.
    /// </summary>
    public static bool IsUnknown96 => Instance()->Flags[96];

    /// <summary>
    /// Unable to execute command while wearing a guise.
    /// </summary>
    public static bool IsDisguised => Instance()->Flags[97];

    /// <summary>
    /// Unable to execute command while recruiting for a non-cross-world party.
    /// </summary>
    public static bool IsRecruitingWorldOnly => Instance()->Flags[98];

    /// <summary>
    /// Command unavailable in this location.
    /// </summary>
    public static bool IsUnknown99 => Instance()->Flags[99];

    /// <summary>
    /// Unable to execute command while editing a portrait.
    /// </summary>
    public static bool IsEditingPortrait => Instance()->Flags[100];

    public static bool IsUnknown101 => Instance()->Flags[101];

    public static bool IsUnknown102 => Instance()->Flags[102];

    public static bool IsUnknown103 => Instance()->Flags[103];
}

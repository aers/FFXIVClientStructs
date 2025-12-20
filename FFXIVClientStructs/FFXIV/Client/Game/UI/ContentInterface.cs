namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::ContentInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public partial struct ContentInterface {
    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlag);

    [VirtualFunction(1)]
    public partial CStringPointer GetName();

    [VirtualFunction(2)]
    public partial CStringPointer GetNameShortOrCategory();

    // [VirtualFunction(3)]
    // public partial CStringPointer GetAlternativeName();

    [VirtualFunction(4)]
    public partial uint GetContentType();

    [VirtualFunction(5)]
    public partial bool IsPvP();

    [VirtualFunction(6)]
    public partial uint GetImage();

    [VirtualFunction(7)]
    public partial uint GetIcon();

    [VirtualFunction(8)]
    public partial uint GetContentTypeIcon();

    [VirtualFunction(9)]
    public partial ushort GetRequiredLevel();

    [VirtualFunction(10)]
    public partial ushort GetSyncedLevel();

    [VirtualFunction(11)]
    public partial ushort GetItemLevelRequired();

    [VirtualFunction(12)]
    public partial ushort GetItemLevelSync();

    [VirtualFunction(13)]
    public partial bool IsHighestAverageItemLevelApplied();

    [VirtualFunction(14)]
    public partial bool IsUnlocked();

    // [VirtualFunction(15)]
    // private partial bool Unknown15();

    [VirtualFunction(16)]
    public partial bool IsCompleted();

    [VirtualFunction(17)]
    public partial bool IsInDutyFinderAndIsUnlocked();

    [VirtualFunction(18)]
    public partial uint GetClassJobCategory();

    [VirtualFunction(19)]
    public partial bool HasOnePlayerPerJobDetails();

    [VirtualFunction(20)]
    public partial bool IsSeparatedDpsRoles();

    [VirtualFunction(21)]
    public partial bool IsSeparatedHealerRoles();

    [VirtualFunction(22)]
    public partial bool IsCrystallineConflict();

    [VirtualFunction(23)]
    public partial bool IsLimitedJobAllowed();

    [VirtualFunction(24)]
    public partial byte GetNumParties();

    [VirtualFunction(25)]
    public partial byte GetQueueMaxPlayers();

    [VirtualFunction(26)]
    public partial byte GetTanksPerParty();

    [VirtualFunction(27)]
    public partial byte GetHealersPerParty();

    [VirtualFunction(28)]
    public partial byte GetTotalDpsPerParty();

    [VirtualFunction(29)]
    public partial byte GetMeleesPerParty();

    [VirtualFunction(30)]
    public partial byte GetRangedPerParty();

    [VirtualFunction(31)]
    public partial byte GetPartyCount();

    [VirtualFunction(32)]
    public partial byte GetAlliancePartyCount();

    [VirtualFunction(33)]
    public partial byte GetQueueMinPlayers();

    [VirtualFunction(34)]
    public partial bool IsRoleIndependent();

    [VirtualFunction(35)]
    public partial bool IsFixedItemLevelSync();

    [VirtualFunction(36)]
    public partial bool IsUnrestrictedPartyAllowed();

    [VirtualFunction(37)]
    public partial bool IsMatchingForAlliancesUnavailable();

    [VirtualFunction(38)]
    public partial bool IsMemberRequiredInEveryParty();

    [VirtualFunction(39)]
    public partial int GetLootModeType();

    [VirtualFunction(40)]
    public partial bool IsAdditionalLootRulesAvailable();

    [VirtualFunction(41)]
    public partial bool IsMinimumILAllowed();

    // [VirtualFunction(42)]
    // private partial bool Unknown42();

    [VirtualFunction(43)]
    public partial bool IsAllianceRegistrationAllowed();

    // [VirtualFunction(44)]
    // private partial bool Unknown44();

    [VirtualFunction(45)]
    public partial uint GetAllianceRegistrationMinPlayers();

    // [VirtualFunction(46)]
    // private partial bool Unknown46();

    [VirtualFunction(47)]
    public partial bool IsGrandCompanyRequired();

    [VirtualFunction(48)]
    public partial bool IsBattleMentorWithCurrentCertificationOnly();

    // [VirtualFunction(49)]
    // private partial bool Unknown49();

    // [VirtualFunction(50)]
    // private partial bool Unknown50();

    [VirtualFunction(51)]
    public partial bool IsRegistrationDataCenterLimited();

    [VirtualFunction(52)]
    public partial bool IsExplorerModeAllowed();

    /// <return> 1 = Daily, 2 = Weekly </return>
    [VirtualFunction(53)]
    public partial byte GetRewardResetType();

    /// <return> 1 = On Death, 2 = On Start </return>
    [VirtualFunction(54)]
    public partial byte GetEchoSetting();

    [VirtualFunction(55)]
    public partial byte GetRequiredExVersion();

    [VirtualFunction(56)]
    public partial ushort GetTimeLimit();

    [VirtualFunction(57)]
    public partial ushort GetTimeLimitMax();

    // [VirtualFunction(58)]
    // private partial byte Unknown58(); // PartyCount

    [VirtualFunction(59)]
    public partial byte GetContentUICategory();

    [VirtualFunction(60)]
    public partial uint GetJournalGenre();

    [VirtualFunction(61)]
    public partial bool IsReplacementAllowed();

    [VirtualFunction(62)]
    public partial ushort GetTerritoryType();

    [VirtualFunction(63)]
    private partial bool Unknown63();

    [VirtualFunction(64)]
    public partial bool IsInDutyFinder();

    [VirtualFunction(65)]
    public partial bool IsHighEndDuty();

    [VirtualFunction(66)]
    public partial bool IsConsumableItemAllowed();

    [VirtualFunction(67)]
    public partial ushort GetSortKey();

    [VirtualFunction(68)]
    public partial uint GetGoldSaucerRegisterConditionCount();

    [VirtualFunction(69)]
    public partial uint GetGoldSaucerRegisterConditionAddonId(int index);

    // [VirtualFunction(70)]
    // private partial bool Unknown70();

    // [VirtualFunction(71)]
    // private partial bool Unknown71();

    // [VirtualFunction(72)]
    // private partial bool Unknown72();

    [VirtualFunction(73)]
    public partial bool IsOnlyPvPTeamMembers();

    // [VirtualFunction(74)]
    // private partial bool Unknown74();

    [VirtualFunction(75)]
    public partial uint GetContentCloseCycle();

    [VirtualFunction(76)]
    public partial bool IsDutyRecorderAllowed();

    [VirtualFunction(77)]
    public partial bool IsRegistrationHomeWorldLimited();

    // [VirtualFunction(78)]
    // private partial bool Unknown78();

    // [VirtualFunction(79)]
    // private partial bool Unknown79();

    // [VirtualFunction(80)]
    // private partial bool Unknown80();

    [VirtualFunction(81)]
    public partial bool IsCurrentUnreal();

    [VirtualFunction(82)]
    public partial bool IsRegistrationAllowedFromAnyDataCenter();

    [VirtualFunction(83)]
    public partial uint GetCrystallineConflictGameplayFeatureCount();

    [VirtualFunction(84)]
    public partial uint GetCrystallineConflictGameplayFeatureAddonId(int index);

    [VirtualFunction(85)]
    public partial byte GetUnlockType();

    [VirtualFunction(86)]
    public partial uint GetUnlockCriteria();

    // [VirtualFunction(87)]
    // private partial bool Unknown87();

    [VirtualFunction(88)]
    public partial byte GetPenaltyTimestampArrayIndex();

    [VirtualFunction(89)]
    public partial bool IsLimitedTimeBonus();

    [VirtualFunction(90)]
    public partial bool IsPhoenixDownAllowed();
}

using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.Control;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PlayerState
// ctor "E8 ?? ?? ?? ?? 33 D2 45 33 E4"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x818)] // TODO: update size
public unsafe partial struct PlayerState {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 06 F6 43 18 02", 3)]
    public static partial PlayerState* Instance();

    [FieldOffset(0x00)] public byte IsLoaded;
    [FieldOffset(0x01), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _characterName;
    /// <remarks> PSN-Online-ID or Xbox-Gamertag </remarks>
    [FieldOffset(0x41), FixedSizeArray(isString: true)] internal FixedSizeArray17<byte> _onlineId;
    [FieldOffset(0x64)] public uint EntityId;
    [FieldOffset(0x68)] public ulong ContentId;
    /// <remarks>
    /// 0 = Duty penalty<br/>
    /// 1 = Unknown<br/>
    /// See also: <see cref="InstanceContent.GetPenaltyRemainingInMinutes" />
    /// </remarks>
    [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray2<int> _penaltyTimestamps;

    [FieldOffset(0x79)] public byte MaxLevel;
    [FieldOffset(0x7A)] public byte MaxExpansion;
    [FieldOffset(0x7B)] public byte Sex;
    [FieldOffset(0x7C)] public byte Race;
    [FieldOffset(0x7D)] public byte Tribe;
    [FieldOffset(0x7E)] public byte CurrentClassJobId;

    [FieldOffset(0x80)] public nint CurrentClassJobRow;
    [FieldOffset(0x88)] public short CurrentLevel;
    [FieldOffset(0x8A), FixedSizeArray] internal FixedSizeArray32<short> _classJobLevels;

    [FieldOffset(0xCC), FixedSizeArray] internal FixedSizeArray32<int> _classJobExperience;
    [FieldOffset(0x14C)] public short SyncedLevel;
    [FieldOffset(0x14E)] public byte IsLevelSynced;
    [FieldOffset(0x14F)] public bool HasPremiumSaddlebag;

    [FieldOffset(0x152)] public byte GuardianDeity;
    [FieldOffset(0x153)] public byte BirthMonth;
    [FieldOffset(0x154)] public byte BirthDay;
    [FieldOffset(0x155)] public byte FirstClass;
    [FieldOffset(0x156)] public byte StartTown;
    [FieldOffset(0x157)] public byte QuestSpecialFlags;
    [FieldOffset(0x158), FixedSizeArray] internal FixedSizeArray4<ushort> _activeFestivalIds;
    [FieldOffset(0x160), FixedSizeArray] internal FixedSizeArray4<ushort> _activeFestivalPhases;

    [FieldOffset(0x170)] public int BaseStrength;
    [FieldOffset(0x174)] public int BaseDexterity;
    [FieldOffset(0x178)] public int BaseVitality;
    [FieldOffset(0x17C)] public int BaseIntelligence;
    [FieldOffset(0x180)] public int BaseMind;
    [FieldOffset(0x184)] public int BasePiety;
    [FieldOffset(0x188), FixedSizeArray] internal FixedSizeArray74<int> _attributes;
    [FieldOffset(0x2B0)] public byte GrandCompany;
    [FieldOffset(0x2B1)] public byte GCRankMaelstrom;
    [FieldOffset(0x2B2)] public byte GCRankTwinAdders;
    [FieldOffset(0x2B3)] public byte GCRankImmortalFlames;
    [FieldOffset(0x2B4)] public ushort HomeAetheryteId;
    [FieldOffset(0x2B6)] public byte FavouriteAetheryteCount;
    [FieldOffset(0x2B8), FixedSizeArray] internal FixedSizeArray4<ushort> _favouriteAetherytes;
    [FieldOffset(0x2C0)] public ushort FreeAetheryteId;
    [FieldOffset(0x2C2)] public ushort FreeAetherytePlayStationPlus;
    [FieldOffset(0x2C4)] public uint BaseRestedExperience;

    // Size: (MountSheet.Max(row => row.Order) + 7) / 8
    /// <remarks> Use <see cref="IsMountUnlocked"/> </remarks>
    [FieldOffset(0x2DD), FixedSizeArray] internal FixedSizeArray35<byte> _unlockedMountsBitmask; // TODO: offset is still correct, update count
    // Size: (OrnamentSheet.RowCount + 7) / 8
    /// <remarks> Use <see cref="IsOrnamentUnlocked"/> </remarks>
    [FieldOffset(0x303), FixedSizeArray] internal FixedSizeArray7<byte> _unlockedOrnamentsBitmask;
    [FieldOffset(0x30E)] public ushort NumOwnedMounts;
    // Size: (GlassesSheet.RowCount + 7) / 8
    /// <remarks> Use <see cref="IsGlassesUnlocked"/> </remarks>
    [FieldOffset(0x30A), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedGlassesBitmask;

    // Ref: "48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 83 EC 50 48 8B 81"
    // Size: (FishParameterSheet.Count(row => row.IsInLog) + 7) / 8
    [FieldOffset(0x3EA), FixedSizeArray] internal FixedSizeArray159<byte> _caughtFishBitmask; // TODO: update size

    [FieldOffset(0x4A0)] public uint NumFishCaught;
    [FieldOffset(0x4A4)] public uint FishingBait;
    // Ref: "48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 30 48 8B 81 ?? ?? ?? ?? 49 8B D8"
    // Size: (SpearfishingNotebookSheet.RowCount + 7) / 8
    [FieldOffset(0x3C0), FixedSizeArray] internal FixedSizeArray7<byte> _unlockedSpearfishingNotebookBitmask; // TODO: update size
    // Ref: "40 53 55 57 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 4C 8B 12"
    // Size: (SpearfishingItemSheet.RowCount + 7) / 8
    [FieldOffset(0x4B0), FixedSizeArray] internal FixedSizeArray36<byte> _caughtSpearfishBitmask; // TODO: update size

    [FieldOffset(0x4D8)] public uint NumSpearfishCaught;

    /// <remarks>
    /// Index is column 27 of ContentRoulette sheet.<br/>
    /// See also: <see cref="InstanceContent.IsRouletteComplete" />
    /// </remarks>
    [FieldOffset(0x4E0), FixedSizeArray] internal FixedSizeArray12<byte> _contentRouletteCompletion;
    [FieldOffset(0x4EC)] public short PlayerCommendations;

    [FieldOffset(0x4EE), FixedSizeArray] internal FixedSizeArray7<byte> _selectedPoses;
    [FieldOffset(0x4F5)] public byte PlayerStateFlags1;
    [FieldOffset(0x4F6)] public byte PlayerStateFlags2;
    [FieldOffset(0x4F7)] public byte PlayerStateFlags3;

    [FieldOffset(0x522)] public byte SightseeingLogUnlockState; // 0 = Not Unlocked, 1 = ARR Part 1, 2 = ARR Part 2
    [FieldOffset(0x523)] public byte SightseeingLogUnlockStateEx; // 3 = Quest "Sights of the North" completed (= AdventureExPhase unlocked?)
    // Ref: PlayerState.IsAdventureExPhaseComplete
    // Size: (AdventureExPhaseSheet.RowCount + 7) / 8
    /// <remarks> Use <see cref="IsAdventureExPhaseComplete"/> </remarks>
    [FieldOffset(0x524), FixedSizeArray] internal FixedSizeArray1<byte> _unlockedAdventureExPhaseBitmask; // TODO: update size

    // Ref: PlayerState.IsAdventureComplete
    // Size: (AdventureSheet.RowCount + 7) / 8
    /// <remarks> Use <see cref="IsAdventureComplete"/> </remarks>
    [FieldOffset(0x550), FixedSizeArray] internal FixedSizeArray43<byte> _unlockedAdventureBitmask;

    [FieldOffset(0x581), FixedSizeArray] internal FixedSizeArray44<byte> _unlockFlags; // TODO: update size

    /// <summary>Carrier Level of Delivery Moogle Quests</summary>
    [FieldOffset(0x5BD)] public byte DeliveryLevel;
    // [FieldOffset(0x5BE)] public byte UnkWeddingPlanFlag; // see lua function "GetWeddingPlan"
    /// <summary>
    /// Flag containing information about which DoH job the player is specialized in.
    /// </summary>
    /// <remarks>
    /// Use these instead:<br/>
    /// <see cref="IsMeisterFlag" /><br/>
    /// <see cref="IsMeisterFlagMaxCount" /><br/>
    /// <see cref="IsMeisterFlagAndHasSoulStoneEquipped" />
    /// </remarks>
    [FieldOffset(0x5BF)] public byte MeisterFlag;

    [FieldOffset(0x5C4)] public int SquadronMissionCompletionTimestamp;
    [FieldOffset(0x5C8)] public int SquadronTrainingCompletionTimestamp;
    [FieldOffset(0x5CC)] public ushort ActiveGcArmyExpedition;
    [FieldOffset(0x5CE)] public ushort ActiveGcArmyTraining;
    [FieldOffset(0x5D0)] public bool HasNewGcArmyCandidate; // see lua function "GcArmyIsNewCandidate"
    // [FieldOffset(0x5D1)] public bool UnkGcPvpMountActionCheck; // see "80 3D ?? ?? ?? ?? ?? 75 3C"

    [FieldOffset(0x5D2), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedMinerFolkloreTomeBitmask;
    [FieldOffset(0x5D4), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedBotanistFolkloreTomeBitmask;
    [FieldOffset(0x5D6), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedFishingFolkloreTomeBitmask;

    #region Weekly Bonus/Weekly Bingo/Wondrous Tails Fields (packet reader in "48 83 EC 28 48 8B D1 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ??")

    /// <summary>RowIds of WeeklyBingoOrderData sheet</summary>
    [FieldOffset(0x6E0), FixedSizeArray] internal FixedSizeArray16<byte> _weeklyBingoOrderData;
    /// <summary>RowIds of WeeklyBingoRewardData sheet</summary>
    [FieldOffset(0x6F0), FixedSizeArray] internal FixedSizeArray4<byte> _weeklyBingoRewardData;
    /// <summary>Bitflags of placed stickers.</summary>
    /// <remarks>Use IsWeeklyBingoStickerPlaced(index) and WeeklyBingoNumPlacedStickers instead.</remarks>
    [FieldOffset(0x6F4)] private ushort _weeklyBingoStickers;

    /// <remarks>Use GetWeeklyBingoExpireUnixTimestamp(), WeeklyBingoNumSecondChancePoints and HasWeeklyBingoJournal instead</remarks>
    [FieldOffset(0x6F8)] private uint _weeklyBingoFlags;
    [FieldOffset(0x6FC), FixedSizeArray] internal FixedSizeArray4<byte> __weeklyBingoTaskStatus;
    [FieldOffset(0x700)] public byte WeeklyBingoRequestOpenBingoNo;

    [FieldOffset(0x73C)] public byte WeeklyBingoExpMultiplier;
    [FieldOffset(0x73D)] public bool WeeklyBingoUnk63;

    #endregion

    /// <remarks> For easier access, use <see cref="GetContentValue"/>. </remarks>
    [FieldOffset(0x744), FixedSizeArray] internal FixedSizeArray3<StdPair<uint, uint>> _contentKeyValueData;

    /// <remarks>
    /// 1 = Shadowbringers
    /// 2 = Endwalker
    /// 3 = Dawntrail
    /// </remarks>
    [FieldOffset(0x7D4)] public byte MentorVersion;

    [FieldOffset(0x7D8), FixedSizeArray] internal FixedSizeArray8<uint> _desynthesisLevels;

    public bool IsLegacy => (QuestSpecialFlags & 1) != 0;
    public bool IsWarriorOfLight => (QuestSpecialFlags & 2) != 0;

    public float GetDesynthesisLevel(uint classJobId)
        => classJobId is < 8 or > 15 ? 0 : DesynthesisLevels[(int)classJobId - 8] / 100f;

    /// <summary>
    /// Retrieves the value associated with the given key from ContentKeyValueData.<br/>
    /// Only loaded inside the relevant content.<br/>
    /// <br/>
    /// <code>
    /// |-----|-------------|------------------------------|
    /// | Key | Content     | Usage                        |
    /// |-----|-------------|------------------------------|
    /// |   1 | Rival Wings | ManeuversArmor RowId         |
    /// |   2 | Eureka      | Effective Elemental Level    |
    /// |   3 | Eureka      | Is Elemental Level Synced    |
    /// |   4 | Eureka      | Current Elemental Level      |
    /// |   5 | Bozja       | Current Resistance Rank      |
    /// |-----|-------------|------------------------------|
    /// </code>
    /// </summary>
    public uint GetContentValue(uint key) {
        for (var i = 0; i < 3; i++) {
            var entry = ContentKeyValueData.GetPointer(i);
            if (entry->Item1 == key) {
                return entry->Item2;
            }
        }
        return 0;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 3A 43 01")]
    public partial byte GetGrandCompanyRank();

    [MemberFunction("E8 ?? ?? ?? ?? BE ?? ?? ?? ?? 84 C0 75 0C")]
    public partial byte GetBeastTribeRank(byte beastTribeIndex);

    /// <summary>
    /// Returns whether the player is possessing the maximum amount of specialized souls.
    /// </summary>
    [MemberFunction("0F B6 81 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ?? 89 44 24 08")]
    public partial bool IsMeisterFlagMaxCount();

    /// <summary>
    /// Returns whether the player is specialized in the given DoH ClassJob.
    /// </summary>
    /// <param name="classJobId">The ClassJob row id of the DoH job to check.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 04 41 0F AB F6")]
    public partial bool IsMeisterFlag(uint classJobId);

    /// <summary>
    /// Returns whether the player is specialized in the given DoH ClassJob and has the specialization stone equipped.
    /// </summary>
    /// <param name="classJobId">The ClassJob row id of the DoH job to check.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 38 43 45")]
    public partial bool IsMeisterFlagAndHasSoulStoneEquipped(uint classJobId);

    /// <summary> Get the current state of a specific type of pose. </summary>
    /// <param name="pose"> The type of pose. </param>
    /// <returns> The 0-based value of the pose. </returns>
    public byte CurrentPose(EmoteController.PoseType pose) => !Enum.IsDefined(pose) ? (byte)0 : SelectedPoses[(int)pose];

    #region Unlocks

    /// <summary>
    /// Check if a specific mount has been unlocked by the player.
    /// </summary>
    /// <param name="mountId">The ID of the mount to look up.</param>
    /// <returns>Returns true if the mount has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 57 41 8B CF")]
    public partial bool IsMountUnlocked(uint mountId);

    /// <summary>
    /// Check if a specific ornament (fashion accessory) has been unlocked by the player.
    /// </summary>
    /// <param name="ornamentId">The ID of the ornament to look up.</param>
    /// <returns>Returns true if the ornament has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 41 0F B6 CE")]
    public partial bool IsOrnamentUnlocked(uint ornamentId);

    /// <summary>
    /// Check if a specific orchestrion roll has been unlocked by the player.
    /// </summary>
    /// <param name="rollId">The ID of the roll to look up.</param>
    /// <returns>Returns true if the roll has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 44 1F 08")]
    public partial bool IsOrchestrionRollUnlocked(uint rollId);

    /// <summary>
    /// Check if a Secret Recipe Book (DoH Master Tome) is unlocked and (indirectly) if the player can craft recipes
    /// from that specific book.
    /// </summary>
    /// <param name="tomeId">The ID of the book to check for. Can be retrieved from the SecretRecipeBook sheet.</param>
    /// <returns>Returns true if the book is unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 4D 9A")]
    public partial bool IsSecretRecipeBookUnlocked(uint tomeId);

    /// <summary>
    /// Check if a Folklore Book (DoL Master Tome) is unlocked and (indirectly) if the player can find legendary nodes
    /// revealed by that book.
    /// </summary>
    /// <param name="tomeId">The ID of the book to check for. Can be retrieved from GatheringSubCategory.Division</param>
    /// <returns>Returns true if the book is unlocked.</returns>
    [MemberFunction("E9 ?? ?? ?? ?? 0F B7 57 70")]
    public partial bool IsFolkloreBookUnlocked(uint tomeId);

    /// <summary>
    /// Check if a specific McGuffin (Collectible/Curiosity) has been unlocked by the player.
    /// </summary>
    /// <param name="mcGuffinId">The ID of the McGuffin to look up, generally from the McGuffin sheet.</param>
    /// <returns>Returns true if the McGuffin has been unlocked.</returns>
    [MemberFunction("8D 42 ?? 3C ?? 77 ?? 4C 8B 89")]
    public partial bool IsMcGuffinUnlocked(uint mcGuffinId);

    /// <summary>
    /// Check if a particular Framer's Kit is unlocked and can be used.
    /// </summary>
    /// <remarks>
    /// How IDs are located is a bit weird and not necessarily fully understood at time of writing. They appear on Framer
    /// Kit items in the AdditionalData field, and at +0 in BannerCondition EXDs when +0xE == 9.
    /// </remarks>
    /// <param name="kitId">The kit ID to check for.</param>
    /// <returns>Returns true if the framer's kit is unlocked.</returns>
    [MemberFunction("E9 ?? ?? ?? ?? 33 FF 90")]
    public partial bool IsFramersKitUnlocked(uint kitId);

    public bool IsAetherCurrentUnlocked(uint aetherCurrentId) {
        if (aetherCurrentId < 0x2B0000)
            return false;
        var id = aetherCurrentId - 0x2B0000;
        var idx = id / 8;
        var flag = 1 << (byte)(id + idx * -8 & 0x1F);
        return (UnlockFlags[(int)idx] & flag) != 0;
    }

    /// <summary>
    /// Returns whether all aether currents of a zone were discovered.
    /// </summary>
    /// <param name="territoryTypeColumn32">Column 32 of TerritoryType</param>
    [MemberFunction("4C 8B C9 85 D2 74 1D")]
    public partial bool IsAetherCurrentZoneComplete(uint territoryTypeColumn32);

    /// <summary>
    /// Check if all vistas of an expansion in the Sightseeing Log have been discovered.
    /// </summary>
    /// <param name="adventureExPhaseId">AdventureExPhase RowId</param>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 90")]
    public partial bool IsAdventureExPhaseComplete(uint adventureExPhaseId);

    /// <summary>
    /// Check if a Sightseeing Log vista has been discovered.
    /// </summary>
    /// <param name="adventureId">Index of Row (= RowId - 2162688)</param>
    [MemberFunction("81 FA ?? ?? ?? ?? 73 1F 0F B6 C2")]
    public partial bool IsAdventureComplete(uint adventureId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 0B 66 FF C3")]
    public partial bool IsGlassesUnlocked(ushort glassesId);

    #endregion

    #region Weekly Bonus/Weekly Bingo/Wondrous Tails

    public enum WeeklyBingoTaskStatus {
        /// <summary>Incomplete task.</summary>
        Open,
        /// <summary>Completed task, but sticker not placed.</summary>
        Claimable,
        /// <summary>Completed task and sticker placed.</summary>
        Claimed,
    }

    /// <summary>Returns the value of the requested flag.</summary>
    /// <param name="mode">
    /// The following modes have been found:<br/>
    /// 3 = second chance points<br/>
    /// 5 = whether player is in possession of the journal
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? 3B C3 0F 93 C0")]
    private partial uint GetWeeklyBingoFlagsValue(uint mode);

    /// <summary>Returns whether the Wondrous Tails Journal has expired or not.</summary>
    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 8D 90 ?? ?? ?? ??")]
    public partial bool IsWeeklyBingoExpired();

    /// <summary>Returns the expiration of the players Wondrous Tails Journal as a unix timestamp.</summary>
    [MemberFunction("8B 81 ?? ?? ?? ?? C1 E8 04 25")]
    public partial int GetWeeklyBingoExpireUnixTimestamp();

    /// <summary>Returns whether the task is complete or not.</summary>
    /// <param name="index">Task index, starting at 1.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D3 41 88 06")]
    public partial bool IsWeeklyBingoStickerPlaced(int index);

    /// <summary>Returns the stored state of the indexed task.</summary>
    /// <param name="index">Task index, starting at 0.</param>
    [MemberFunction("48 8B C1 83 FA 10")]
    public partial WeeklyBingoTaskStatus GetWeeklyBingoTaskStatus(int index);

    /// <summary>Returns the experience multiplier.</summary>
    /// <remarks>The experience reward is being calculated as: Current Job Experience / 100 * WeeklyBingoExpMultiplier</remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 0F AF C3")]
    public partial uint GetWeeklyBingoExpMultiplier();

    /// <summary>Returns the expiration of the players Wondrous Tails Journal as UTC DateTime.</summary>
    public DateTime WeeklyBingoExpireDateTime => DateTime.UnixEpoch.AddSeconds(GetWeeklyBingoExpireUnixTimestamp());

    /// <summary>Returns the current number of second chance points.</summary>
    public uint WeeklyBingoNumSecondChancePoints => GetWeeklyBingoFlagsValue(3);

    /// <summary>Returns whether the player is in possession of the journal or not.</summary>
    public bool HasWeeklyBingoJournal => GetWeeklyBingoFlagsValue(5) != 0;

    /// <summary>Returns the number of placed stickers.</summary>
    public int WeeklyBingoNumPlacedStickers => BitOperations.PopCount(_weeklyBingoStickers);

    #endregion

    #region Novice Network

    /// <summary>
    /// Returns whether the player is any kind of Mentor (Battle or Trade Mentor).
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 0D B0 02")]
    public partial bool IsMentor();

    /// <summary>
    /// Returns whether the player is a Battle Mentor.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 04 C6 46 41 01")]
    public partial bool IsBattleMentor();

    /// <summary>
    /// Returns whether the player is a Trade Mentor.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 53 28 F6 D8")]
    public partial bool IsTradeMentor();

    /// <summary>
    /// Returns whether the player is a novice (aka. Sprout or New Adventurer).<br/>
    /// Can be false if /nastatus was used to deactivate it.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 88 05 ?? ?? ?? ?? 66 C7 43 ?? ?? ??")]
    public partial bool IsNovice();

    /// <summary>
    /// Returns whether the player is a returner.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 88 46 43")]
    public partial bool IsReturner();

    /// <summary>
    /// Returns whether the specified PlayerStateFlag is set.
    /// </summary>
    /// <param name="flag">The PlayerStateFlag to check.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 3A D8 75 2E")]
    public partial bool IsPlayerStateFlagSet(PlayerStateFlag flag);

    #endregion
}

public enum PlayerStateFlag : uint {
    IsLoginSecurityToken = 1,
    IsBuddyInStable = 2,
    IsMentorStatusActive = 7,
    IsNoviceNetworkAutoJoinEnabled = 8,
    IsBattleMentorStatusActive = 9,
    IsTradeMentorStatusActive = 10,
    IsPvPMentorStatusActive = 11,
    Unknown14 = 14,
}

using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PlayerState
// ctor "48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C6 83"
[StructLayout(LayoutKind.Explicit, Size = 0x818)]
public unsafe partial struct PlayerState {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 4D 8B F9", 3)]
    public static partial PlayerState* Instance();

    [FieldOffset(0x00)] public byte IsLoaded;
    [FieldOffset(0x01)] public fixed byte CharacterName[64];
    [FieldOffset(0x41)] public fixed byte PSNOnlineID[17];
    [FieldOffset(0x64)] public uint ObjectId;
    [FieldOffset(0x68)] public ulong ContentId;
    /// <remarks>
    /// 0 = Duty penalty<br/>
    /// 1 = Unknown<br/>
    /// See also: <see cref="RouletteController.GetPenaltyRemainingInMinutes" />
    /// </remarks>
    [FieldOffset(0x70)] public fixed uint PenaltyTimestamps[2];

    [FieldOffset(0x79)] public byte MaxLevel;
    [FieldOffset(0x7A)] public byte MaxExpansion;
    [FieldOffset(0x7B)] public byte Sex;
    [FieldOffset(0x7C)] public byte Race;
    [FieldOffset(0x7D)] public byte Tribe;
    [FieldOffset(0x7E)] public byte CurrentClassJobId;

    [FieldOffset(0x80)] public nint CurrentClassJobRow;
    [FieldOffset(0x88)] public short CurrentLevel;
    [FieldOffset(0x8A)] public fixed short ClassJobLevelArray[32];

    [FieldOffset(0xCC)] public fixed int ClassJobExpArray[32];
    [FieldOffset(0x14C)] public short SyncedLevel;
    [FieldOffset(0x14E)] public byte IsLevelSynced;
    [FieldOffset(0x14F)] public bool HasPremiumSaddlebag;

    [FieldOffset(0x152)] public byte GuardianDeity;
    [FieldOffset(0x153)] public byte BirthMonth;
    [FieldOffset(0x154)] public byte BirthDay;
    [FieldOffset(0x155)] public byte FirstClass;
    [FieldOffset(0x156)] public byte StartTown;
    [FieldOffset(0x157)] public byte QuestSpecialFlags;
    [FieldOffset(0x158)] public fixed ushort ActiveFestivalIds[4];
    [FieldOffset(0x160)] public fixed ushort ActiveFestivalPhases[4];

    [FieldOffset(0x170)] public int BaseStrength;
    [FieldOffset(0x174)] public int BaseDexterity;
    [FieldOffset(0x178)] public int BaseVitality;
    [FieldOffset(0x17C)] public int BaseIntelligence;
    [FieldOffset(0x180)] public int BaseMind;
    [FieldOffset(0x184)] public int BasePiety;
    [FieldOffset(0x188)] public fixed int Attributes[74];
    [FieldOffset(0x2B0)] public byte GrandCompany;
    [FieldOffset(0x2B1)] public byte GCRankMaelstrom;
    [FieldOffset(0x2B2)] public byte GCRankTwinAdders;
    [FieldOffset(0x2B3)] public byte GCRankImmortalFlames;
    [FieldOffset(0x2B4)] public ushort HomeAetheryteId;
    [FieldOffset(0x2B6)] public byte FavouriteAetheryteCount;
    [FieldOffset(0x2B8)] public fixed ushort FavouriteAetheryteArray[4];
    [FieldOffset(0x2C0)] public ushort FreeAetheryteId;
    [FieldOffset(0x2C2)] public ushort FreeAetherytePlayStationPlus;
    [FieldOffset(0x2C4)] public uint BaseRestedExperience;

    // Size: (MountSheet.Max(row => row.Order) + 7) >> 3
    /// <remarks> Use <see cref="IsMountUnlocked"/> </remarks>
    [FieldOffset(0x2DD)] public fixed byte OwnedMountsBitmask[(280 + 7) >> 3];
    // Size: (OrnamentSheet.RowCount + 7) >> 3
    /// <remarks> Use <see cref="IsOrnamentUnlocked"/> </remarks>
    [FieldOffset(0x300)] public fixed byte UnlockedOrnamentsBitmask[(41 + 7) >> 3];
    [FieldOffset(0x306)] public byte NumOwnedMounts;

    // Ref: "48 8D 0D ?? ?? ?? ?? 41 0F B6 0C 08 41 B0 01 84 D1 0F 95 C1 24 01 02 C0 0A C8 41 0F B6 C4"
    // Size: (FishParameterSheet.Count(row => row.IsInLog) + 7) >> 3
    [FieldOffset(0x3B4)] public fixed byte CaughtFishBitmask[(1272 + 7) >> 3];

    [FieldOffset(0x458)] public uint NumFishCaught;
    [FieldOffset(0x45C)] public uint FishingBait;
    // Ref: "41 0F B6 04 00 D3 E2 84 D0 0F 95 85"
    // Size: (SpearfishingNotebookSheet.RowCount + 7) >> 3
    [FieldOffset(0x460)] public fixed byte UnlockedSpearfishingNotebookBitmask[(56 + 7) >> 3];
    // Ref: "48 8D 0D ?? ?? ?? ?? 41 0F B6 0C 08 84 D1 40 0F"
    // Size: (SpearfishingItemSheet.RowCount + 7) >> 3
    [FieldOffset(0x467)] public fixed byte CaughtSpearfishBitmask[(287 + 7) >> 3];

    [FieldOffset(0x48C)] public uint NumSpearfishCaught;

    /// <remarks>
    /// Index is column 27 of ContentRoulette sheet.<br/>
    /// See also: <see cref="RouletteController.IsRouletteComplete" />
    /// </remarks>
    [FieldOffset(0x494)] public fixed byte ContentRouletteCompletion[12];
    [FieldOffset(0x4A0)] public short PlayerCommendations;

    [FieldOffset(0x4A2)] public fixed byte SelectedPoses[7];
    [FieldOffset(0x4A9)] public byte PlayerStateFlags1;
    [FieldOffset(0x4AA)] public byte PlayerStateFlags2;
    [FieldOffset(0x4AB)] public byte PlayerStateFlags3;

    [FieldOffset(0x4D4)] public byte SightseeingLogUnlockState; // 0 = Not Unlocked, 1 = ARR Part 1, 2 = ARR Part 2
    [FieldOffset(0x4D5)] public byte SightseeingLogUnlockStateEx; // 3 = Quest "Sights of the North" completed (= AdventureExPhase unlocked?)
    // Ref: PlayerState.IsAdventureExPhaseComplete
    // Size: (AdventureExPhaseSheet.RowCount + 7) >> 3
    /// <remarks> Use <see cref="IsAdventureExPhaseComplete"/> </remarks>
    [FieldOffset(0x4D6)] public fixed byte UnlockedAdventureExPhaseBitmask[(3 + 7) >> 3];

    // Ref: PlayerState.IsAdventureComplete
    // Size: (AdventureSheet.RowCount + 7) >> 3
    /// <remarks> Use <see cref="IsAdventureComplete"/> </remarks>
    [FieldOffset(0x500)] public fixed byte UnlockedAdventureBitmask[(295 + 7) >> 3];

    [FieldOffset(0x529)] public fixed byte UnlockFlags[44];

    /// <summary>Carrier Level of Delivery Moogle Quests</summary>
    [FieldOffset(0x559)] public byte DeliveryLevel;
    // [FieldOffset(0x560)] public byte UnkWeddingPlanFlag; // see lua function "GetWeddingPlan"
    /// <summary>
    /// Flag containing information about which DoH job the player is specialized in.
    /// </summary>
    /// <remarks>
    /// Use these instead:<br/>
    /// <see cref="IsMeisterFlag" /><br/>
    /// <see cref="IsMeisterFlagMaxCount" /><br/>
    /// <see cref="IsMeisterFlagAndHasSoulStoneEquipped" />
    /// </remarks>
    [FieldOffset(0x55B)] public byte MeisterFlag;

    [FieldOffset(0x560)] public uint SquadronMissionCompletionTimestamp;
    [FieldOffset(0x564)] public uint SquadronTrainingCompletionTimestamp;
    [FieldOffset(0x568)] public ushort ActiveGcArmyExpedition;
    [FieldOffset(0x56A)] public ushort ActiveGcArmyTraining;
    [FieldOffset(0x56C)] public bool HasNewGcArmyCandidate; // see lua function "GcArmyIsNewCandidate"
    // [FieldOffset(0x56D)] public bool UnkGcPvpMountActionCheck; // see "80 3D ?? ?? ?? ?? ?? 75 3C"

    [FieldOffset(0x56E)] public fixed byte UnlockedMinerFolkloreTomeBitmask[2];
    [FieldOffset(0x570)] public fixed byte UnlockedBotanistFolkloreTomeBitmask[2];
    [FieldOffset(0x572)] public fixed byte UnlockedFishingFolkloreTomeBitmask[2];

    #region Weekly Bonus/Weekly Bingo/Wondrous Tails Fields (packet reader: "4C 8B D2 48 8D 81")

    /// <summary>RowIds of WeeklyBingoOrderData sheet</summary>
    [FieldOffset(0x67C)] public fixed byte WeeklyBingoOrderData[16];
    /// <summary>RowIds of WeeklyBingoRewardData sheet</summary>
    [FieldOffset(0x68C)] public fixed byte WeeklyBingoRewardData[4];
    /// <summary>Bitflags of placed stickers.</summary>
    /// <remarks>Use IsWeeklyBingoStickerPlaced(index) and WeeklyBingoNumPlacedStickers instead.</remarks>
    [FieldOffset(0x690)] private readonly ushort _weeklyBingoStickers;

    /// <remarks>Use GetWeeklyBingoExpireUnixTimestamp(), WeeklyBingoNumSecondChancePoints and HasWeeklyBingoJournal instead</remarks>
    [FieldOffset(0x694)] private readonly uint _weeklyBingoFlags;
    [FieldOffset(0x698)] private fixed byte _weeklyBingoTaskStatus[4];
    [FieldOffset(0x69C)] public byte WeeklyBingoRequestOpenBingoNo;

    [FieldOffset(0x6D8)] public byte WeeklyBingoExpMultiplier;
    [FieldOffset(0x6D9)] public bool WeeklyBingoUnk63;

    #endregion

    /// <remarks> For easier access, use <see cref="GetContentValue"/>. </remarks>
    [FixedSizeArray<StdPair<uint, uint>>(3)]
    [FieldOffset(0x6E0)] public fixed byte ContentKeyValueData[0x8 * 3];

    [FieldOffset(0x770)] public byte MentorVersion; // latest is 2

    [FieldOffset(0x774)] public fixed uint DesynthesisLevels[8];

    public bool IsLegacy => (QuestSpecialFlags & 1) != 0;
    public bool IsWarriorOfLight => (QuestSpecialFlags & 2) != 0;

    public float GetDesynthesisLevel(uint classJobId)
        => classJobId is < 8 or > 15 ? 0 : DesynthesisLevels[classJobId - 8] / 100f;

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
            var entry = ContentKeyValueDataSpan.GetPointer(i);
            if (entry->Item1 == key) {
                return entry->Item2;
            }
        }
        return 0;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A 86")]
    public partial byte GetGrandCompanyRank();

    [MemberFunction("E8 ?? ?? ?? ?? BE ?? ?? ?? ?? 84 C0 75 0C")]
    public partial byte GetBeastTribeRank(byte beastTribeIndex);

    /// <summary>
    /// Returns whether the player is possessing the maximum amount of specialized souls.
    /// </summary>
    [MemberFunction("0F B6 81 ?? ?? ?? ?? 4C 8D 4C 24 ??")]
    public partial bool IsMeisterFlagMaxCount();

    /// <summary>
    /// Returns whether the player is specialized in the given DoH ClassJob.
    /// </summary>
    /// <param name="classJobId">The ClassJob row id of the DoH job to check.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 04 41 0F AB F4")]
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
    public byte CurrentPose(PoseType pose)
        => !Enum.IsDefined(pose) ? (byte)0 : SelectedPoses[(int)pose];

    /// <summary> Get the last valid value for a specific type of pose. </summary>
    /// <param name="pose"> The type of pose. </param>
    /// <remarks> The returned value represents the count of the type of pose - 1. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? FE C3 44 8B F0")]
    public static partial byte AvailablePoses(PoseType pose);

    #region Unlocks

    /// <summary>
    /// Check if a specific mount has been unlocked by the player.
    /// </summary>
    /// <param name="mountId">The ID of the mount to look up.</param>
    /// <returns>Returns true if the mount has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 5D 8B CB")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 88 44 3B 08")]
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
    [MemberFunction("E9 ?? ?? ?? ?? 33 FF 0F 1F 40 00")]
    public partial bool IsFramersKitUnlocked(uint kitId);

    public bool IsAetherCurrentUnlocked(uint aetherCurrentId) {
        if (aetherCurrentId < 0x2B0000)
            return false;
        var id = aetherCurrentId - 0x2B0000;
        var idx = id >> 3;
        var flag = 1 << (byte)(id + idx * -8 & 0x1F);
        return (UnlockFlags[idx] & flag) != 0;
    }

    /// <summary>
    /// Returns whether all aether currents of a zone were discovered.
    /// </summary>
    /// <param name="territoryTypeColumn32">Column 32 of TerritoryType</param>
    [MemberFunction("4C 8B C9 85 D2 74 48")]
    public partial bool IsAetherCurrentZoneComplete(uint territoryTypeColumn32);

    /// <summary>
    /// Check if all vistas of an expansion in the Sightseeing Log have been discovered.
    /// </summary>
    /// <param name="adventureExPhaseId">AdventureExPhase RowId</param>
    [MemberFunction("E8 ?? ?? ?? ?? 88 84 24 ?? ?? ?? ?? 4D 85 F6")]
    public partial bool IsAdventureExPhaseComplete(uint adventureExPhaseId);

    /// <summary>
    /// Check if a Sightseeing Log vista has been discovered.
    /// </summary>
    /// <param name="adventureId">Index of Row (= RowId - 2162688)</param>
    [MemberFunction("81 FA ?? ?? ?? ?? 73 1F 0F B6 C2")]
    public partial bool IsAdventureComplete(uint adventureId);

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
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1D 48 8B 4B 10")]
    public partial bool IsWeeklyBingoExpired();

    /// <summary>Returns the expiration of the players Wondrous Tails Journal as a unix timestamp.</summary>
    [MemberFunction("8B 81 ?? ?? ?? ?? C1 E8 04 25")]
    public partial uint GetWeeklyBingoExpireUnixTimestamp();

    /// <summary>Returns whether the task is complete or not.</summary>
    /// <param name="index">Task index, starting at 1.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 41 8B D7 88 06")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 7C 24 ?? 84 C0")]
    public partial bool IsBattleMentor();

    /// <summary>
    /// Returns whether the player is a Trade Mentor.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 8D 73 1A")]
    public partial bool IsTradeMentor();

    /// <summary>
    /// Returns whether the player is a novice (aka. Sprout or New Adventurer).<br/>
    /// Can be false if /nastatus was used to deactivate it.
    /// </summary>
    [MemberFunction("0F B6 81 ?? ?? ?? ?? F6 D0 0F B6 C0")]
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

public enum PoseType : byte {
    Idle = 0,
    WeaponDrawn = 1,
    Sit = 2,
    GroundSit = 3,
    Doze = 4,
    Umbrella = 5,
    Accessory = 6,
}

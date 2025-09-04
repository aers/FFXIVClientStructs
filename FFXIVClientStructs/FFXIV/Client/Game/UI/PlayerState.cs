using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.Control;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PlayerState
// ctor "E8 ?? ?? ?? ?? 33 D2 45 33 E4"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8D8)]
public unsafe partial struct PlayerState {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 06 F6 43 18 02", 3)]
    public static partial PlayerState* Instance();

    [FieldOffset(0x00)] public bool IsLoaded;
    [FieldOffset(0x01), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _characterName;
    /// <remarks> PSN-Online-ID or Xbox-Gamertag </remarks>
    [FieldOffset(0x41), FixedSizeArray(isString: true)] internal FixedSizeArray17<byte> _onlineId;
    [FieldOffset(0x64)] public uint EntityId;
    [FieldOffset(0x68)] public ulong ContentId;
    /// <remarks>
    /// 0 = Duty Finder penalty<br/>
    /// 1 = Inactivity penalty, presumably (e.g. for Crystalline Conflict Ranked Match)<br/>
    /// See also: <see cref="InstanceContent.GetPenaltyRemainingInMinutes" />
    /// </remarks>
    [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray2<int> _penaltyTimestamps;

    /// <remarks> Causes LogMessage 906 when queueing into content. Seems to be unused. </remarks>
    [FieldOffset(0x78)] public bool HasAddictionRestrictions;

    [FieldOffset(0x79)] public byte MaxLevel;
    /// <remarks> Row Id of ExVersion sheet </remarks>
    [FieldOffset(0x7A)] public byte MaxExpansion;
    /// <remarks> 0 = Male, 1 = Female </remarks>
    [FieldOffset(0x7B)] public byte Sex;
    /// <remarks> Row Id of Race sheet </remarks>
    [FieldOffset(0x7C)] public byte Race;
    /// <remarks> Row Id of Tribe sheet </remarks>
    [FieldOffset(0x7D)] public byte Tribe;
    /// <remarks> Row Id of ClassJob sheet </remarks>
    [FieldOffset(0x7E)] public byte CurrentClassJobId;

    [FieldOffset(0x80), CExporterExcel("ClassJob")] public nint CurrentClassJobRow;
    [FieldOffset(0x88)] public short CurrentLevel;
    /// <remarks> Index is ExpArrayIndex from the ClassJob sheet. </remarks>
    [FieldOffset(0x8A), FixedSizeArray] internal FixedSizeArray35<short> _classJobLevels;

    /// <remarks> Index is ExpArrayIndex from the ClassJob sheet. </remarks>
    [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray35<int> _classJobExperience;
    [FieldOffset(0x15C)] public short SyncedLevel;
    [FieldOffset(0x15E)] public bool IsLevelSynced;
    [FieldOffset(0x15F)] public bool HasPremiumSaddlebag;

    [FieldOffset(0x162)] public byte GuardianDeity;
    [FieldOffset(0x163)] public byte BirthMonth;
    [FieldOffset(0x164)] public byte BirthDay;
    [FieldOffset(0x165)] public byte FirstClass;
    [FieldOffset(0x166)] public byte StartTown;
    [FieldOffset(0x167)] public byte QuestSpecialFlags;
    [FieldOffset(0x168), FixedSizeArray] internal FixedSizeArray4<ushort> _activeFestivalIds;
    [FieldOffset(0x170), FixedSizeArray] internal FixedSizeArray4<ushort> _activeFestivalPhases;

    [FieldOffset(0x180)] public int BaseStrength;
    [FieldOffset(0x184)] public int BaseDexterity;
    [FieldOffset(0x188)] public int BaseVitality;
    [FieldOffset(0x18C)] public int BaseIntelligence;
    [FieldOffset(0x190)] public int BaseMind;
    [FieldOffset(0x194)] public int BasePiety;
    [FieldOffset(0x198), FixedSizeArray] internal FixedSizeArray74<int> _attributes;
    [FieldOffset(0x2C0)] public byte GrandCompany;
    [FieldOffset(0x2C1)] public byte GCRankMaelstrom;
    [FieldOffset(0x2C2)] public byte GCRankTwinAdders;
    [FieldOffset(0x2C3)] public byte GCRankImmortalFlames;
    [FieldOffset(0x2C4)] public ushort HomeAetheryteId;
    [FieldOffset(0x2C6)] public byte FavouriteAetheryteCount;
    [FieldOffset(0x2C8), FixedSizeArray] internal FixedSizeArray4<ushort> _favouriteAetherytes;
    [FieldOffset(0x2D0)] public ushort FreeAetheryteId;
    [FieldOffset(0x2D2)] public ushort FreeAetherytePlayStationPlus;
    [FieldOffset(0x2D4)] public uint BaseRestedExperience;
    // [FieldOffset(0x2D8), FixedSizeArray] internal FixedSizeArray4<byte> _unk2C8; // GCSupply stuff
    // [FieldOffset(0x2DC), FixedSizeArray] internal FixedSizeArray16<byte> _unk2CC; // GCSupply stuff
    [FieldOffset(0x2EC)] private sbyte Unk2DC; // GCSupply stuff
    // Size: (MountSheet.Max(row => row.Order) + 7) / 8
    /// <remarks> Use <see cref="IsMountUnlocked"/> </remarks>
    [FieldOffset(0x2ED), FixedSizeArray] internal FixedSizeArray41<byte> _unlockedMountsBitmask;
    // Size: (OrnamentSheet.RowCount + 7) / 8
    /// <remarks> Use <see cref="IsOrnamentUnlocked"/> </remarks>
    [FieldOffset(0x316), FixedSizeArray] internal FixedSizeArray7<byte> _unlockedOrnamentsBitmask;
    // Size: (GlassesStylesSheet.RowCount + 7) / 8
    /// <remarks> Use <see cref="IsGlassesUnlocked"/> </remarks>
    [FieldOffset(0x31E), FixedSizeArray] internal FixedSizeArray5<byte> _unlockedGlassesStylesBitmask;
    [FieldOffset(0x324)] public ushort NumOwnedMounts;
    [FieldOffset(0x326)] private ushort NumOwnedMountsMinus1; // ???
    // [FieldOffset(0x328), FixedSizeArray] internal FixedSizeArray44<ushort> _unk316; // something FishParameter?
    // [FieldOffset(0x380), FixedSizeArray] internal FixedSizeArray44<ushort> _unk36E; // something FishingRecordType?
    // Ref: "49 83 F8 ?? 73 ?? 41 0F B6 C0 BA ?? ?? ?? ?? C0 E0 ?? 2A C8 48 8D 05 ?? ?? ?? ?? ?? ?? ?? ?? ?? D3 E2 84 D0 0F 95 C0 EB ?? 32 C0"
    // Size: i have no idea, grab it from the sig
    [FieldOffset(0x3D8), FixedSizeArray] internal FixedSizeArray42<byte> _unlockedFishingSpotBitmask;
    // Size: (FishParameterSheet.Count(row => row.IsInLog) + 7) / 8
    /// <remarks> Use <see cref="IsFishCaught(uint)"/> </remarks>
    [FieldOffset(0x402), FixedSizeArray] internal FixedSizeArray182<byte> _caughtFishBitmask;
    [FieldOffset(0x4B8)] public uint NumFishCaught;
    [FieldOffset(0x4BC)] public uint FishingBait;
    // Ref: "48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 30 48 8B 81 ?? ?? ?? ?? 48 8B F2"
    // Size: (SpearfishingNotebookSheet.RowCount + 7) / 8
    [FieldOffset(0x4C0), FixedSizeArray] internal FixedSizeArray8<byte> _unlockedSpearfishingNotebookBitmask;
    // Ref: "42 8D 04 C5 ?? ?? ?? ?? 2B C8 48 8D 05 ?? ?? ?? ?? ?? ?? ?? ?? ?? D3 E2 84 D0 0F B6 47"
    // Size: Highest SpearfishingItemSheet row under 30000, subtract 20000 then right shift 3 to get highest array index
    /// <remarks> Use <see cref="IsSpearfishCaught(uint)"/> </remarks>
    [FieldOffset(0x4C9), FixedSizeArray] internal FixedSizeArray39<byte> _caughtSpearfishBitmask;
    [FieldOffset(0x4F0)] public uint NumSpearfishCaught;
    [FieldOffset(0x4F4)] internal int UnknownUnixTimestamp; // could be an array of size 1?!
    /// <remarks>
    /// Index is column 27 of ContentRoulette sheet.<br/>
    /// Use <see cref="InstanceContent.IsRouletteComplete" />
    /// </remarks>
    [FieldOffset(0x4F8), FixedSizeArray] internal FixedSizeArray12<byte> _contentRouletteCompletion;
    [FieldOffset(0x504)] public short PlayerCommendations;

    [FieldOffset(0x506), FixedSizeArray] internal FixedSizeArray7<byte> _selectedPoses;
    [FieldOffset(0x50D), FixedSizeArray] internal FixedSizeArray3<byte> _playerStateFlags;
    // Size: (SecretRecipeBookSheet.RowCount + 7) / 8
    [FieldOffset(0x510), FixedSizeArray] internal FixedSizeArray14<byte> _unlockedSecretRecipeBooksBitmask;

    [FieldOffset(0x53A)] public byte SightseeingLogUnlockState; // 0 = Not Unlocked, 1 = ARR Part 1, 2 = ARR Part 2
    [FieldOffset(0x53B)] public byte SightseeingLogUnlockStateEx; // 3 = Quest "Sights of the North" completed (= AdventureExPhase unlocked?)
    // Size: (AdventureSheet.RowCount + 7) / 8
    [FieldOffset(0x53C), FixedSizeArray] internal FixedSizeArray43<byte> _unlockedAdventureBitmask; // maybe?
    // Ref: PlayerState.IsAdventureComplete
    /// <remarks> Use <see cref="IsAdventureComplete"/> </remarks>
    [FieldOffset(0x568), FixedSizeArray] internal FixedSizeArray43<byte> _completedAdventureBitmask;

    [FieldOffset(0x599), FixedSizeArray] internal FixedSizeArray56<byte> _unlockFlags;
    // Size: (AetherCurrentCompFlgSetSheet.RowCount + 7) / 8 - 1???
    /// <remarks> Use <see cref="IsAetherCurrentZoneComplete"/> </remarks>
    [FieldOffset(0x5D1), FixedSizeArray] internal FixedSizeArray4<byte> _unlockedAetherCurrentCompFlgSetBitmask;
    /// <summary>Carrier Level of Delivery Moogle Quests</summary>
    [FieldOffset(0x5D5)] public byte DeliveryLevel;
    // [FieldOffset(0x5CE)] public byte UnkWeddingPlanFlag; // see lua function "GetWeddingPlan"
    /// <summary>
    /// Flag containing information about which DoH job the player is specialized in.
    /// </summary>
    /// <remarks>
    /// Use these instead:<br/>
    /// <see cref="IsMeisterFlag" /><br/>
    /// <see cref="IsMeisterFlagMaxCount" /><br/>
    /// <see cref="IsMeisterFlagAndHasSoulStoneEquipped" />
    /// </remarks>
    [FieldOffset(0x5D7)] public byte MeisterFlag;
    [FieldOffset(0x5D8)] internal byte WeeklyLockoutInfo; // unsure how exactly it's processed

    [FieldOffset(0x5DC)] public int SquadronMissionCompletionTimestamp;
    [FieldOffset(0x5E0)] public int SquadronTrainingCompletionTimestamp;
    [FieldOffset(0x5E4)] public ushort ActiveGcArmyExpedition;
    [FieldOffset(0x5E6)] public ushort ActiveGcArmyTraining;
    [FieldOffset(0x5E8)] public bool HasNewGcArmyCandidate; // see lua function "GcArmyIsNewCandidate"
    // [FieldOffset(0x5E9)] public bool UnkGcPvpMountActionCheck; // see "80 3D ?? ?? ?? ?? ?? 75 3C"

    [FieldOffset(0x5EA), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedMinerFolkloreTomeBitmask;
    [FieldOffset(0x5EC), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedBotanistFolkloreTomeBitmask;
    [FieldOffset(0x5EE), FixedSizeArray] internal FixedSizeArray2<byte> _unlockedFishingFolkloreTomeBitmask;
    // Size: (OrchestrionSheet.RowCount + 7) / 8
    /// <remarks> Use <see cref="IsOrchestrionRollUnlocked(uint)"/> </remarks>
    [FieldOffset(0x5F0), FixedSizeArray] internal FixedSizeArray99<byte> _unlockedOrchestrionRollBitmask;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B C8 44 0F B7 C3")]
    public partial int GetAttributeByIndex(PlayerAttribute attribute);
    #region Weekly Bonus/Weekly Bingo/Wondrous Tails Fields (packet reader in "48 83 EC 28 48 8B D1 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ??")

    /// <summary>RowIds of WeeklyBingoOrderData sheet</summary>
    [FieldOffset(0x708), FixedSizeArray] internal FixedSizeArray16<byte> _weeklyBingoOrderData;
    /// <summary>RowIds of WeeklyBingoRewardData sheet</summary>
    [FieldOffset(0x718), FixedSizeArray] internal FixedSizeArray4<byte> _weeklyBingoRewardData;
    /// <summary>Bitflags of placed stickers.</summary>
    /// <remarks>Use IsWeeklyBingoStickerPlaced(index) and WeeklyBingoNumPlacedStickers instead.</remarks>
    [FieldOffset(0x71C)] private ushort _weeklyBingoStickers;

    /// <remarks>Use GetWeeklyBingoExpireUnixTimestamp(), WeeklyBingoNumSecondChancePoints and HasWeeklyBingoJournal instead</remarks>
    [FieldOffset(0x720)] private uint _weeklyBingoFlags;
    [FieldOffset(0x724), FixedSizeArray] internal FixedSizeArray4<byte> __weeklyBingoTaskStatus;
    [FieldOffset(0x728)] public byte WeeklyBingoRequestOpenBingoNo;

    [FieldOffset(0x764)] public byte WeeklyBingoExpMultiplier;
    [FieldOffset(0x765)] public bool WeeklyBingoUnk63;

    #endregion

    /// <remarks> For easier access, use <see cref="GetContentValue"/>. </remarks>
    [FieldOffset(0x76C), FixedSizeArray] internal FixedSizeArray3<StdPair<uint, uint>> _contentKeyValueData;

    /// <remarks>
    /// 1 = Shadowbringers
    /// 2 = Endwalker
    /// 3 = Dawntrail
    /// </remarks>
    [FieldOffset(0x7FC)] public byte MentorVersion;

    /// <remarks> Index is DohDolJobIndex from the ClassJob sheet. </remarks>
    [FieldOffset(0x800), FixedSizeArray] internal FixedSizeArray8<uint> _desynthesisLevels;
    [FieldOffset(0x820)] public int FauxHollowsTimestamp;
    [FieldOffset(0x824)] public int FauxHollowsState;

    [FieldOffset(0x82C)] public StdVector<ushort> CompletedCrystariumDeliveryQuests;
    [FieldOffset(0x844)] public StdSet<byte> UnlockedMcGuffins;
    [FieldOffset(0x854), FixedSizeArray] internal FixedSizeArray33<byte> _unlockedFramersKitsBitmask;

    [FieldOffset(0x890)] public StdMap<uint, bool> TrackedStatuses;
    [FieldOffset(0x8A0)] public StdMap<uint, bool> TrackedActionUnlocks;
    [FieldOffset(0x8B0)] public StdMap<uint, bool> TrackedTraitUnlocks;
    [FieldOffset(0x8C0)] public bool TrackedTraitUnlocksDirty;
    [FieldOffset(0x8C1)] public bool TrackedActionUnlocksDirty;

    public bool IsLegacy => (QuestSpecialFlags & 1) != 0;
    public bool IsWarriorOfLight => (QuestSpecialFlags & 2) != 0;

    public float GetDesynthesisLevel(uint classJobId)
        => classJobId is < 8 or > 15 ? 0 : DesynthesisLevels[(int)classJobId - 8] / 100f;

    /// <summary>
    /// Retrieves the value associated with the given key from ContentKeyValueData.<br/>
    /// Only loaded inside the relevant content.<br/>
    /// <br/>
    /// <code>
    /// |-----|-----------------|------------------------------|
    /// | Key | Content         | Usage                        |
    /// |-----|-----------------|------------------------------|
    /// |   1 | Rival Wings     | ManeuversArmor RowId         |
    /// |   2 | Eureka          | Effective Elemental Level    |
    /// |   3 | Eureka          | Is Elemental Level Synced    |
    /// |   4 | Eureka          | Current Elemental Level      |
    /// |   5 | Bozja           | Current Resistance Rank      |
    /// |   6 | Occult Crescent | Effective Knowledge Level    |
    /// |   7 | Occult Crescent | Current Knowledge Level      |
    /// |-----|-----------------|------------------------------|
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

    #region Beast Tribes (Allied Societies)
    // For allowance use QuestManager.GetBeastTribeAllowance

    [MemberFunction("E8 ?? ?? ?? ?? 3A 43 29 72 08")]
    public partial byte GetBeastTribeRank(byte beastTribeId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A DE")]
    public partial ushort GetBeastTribeCurrentReputation(byte beastTribeId);

    [MemberFunction("E8 ?? ?? ?? ?? 66 3B D8 8B CE")]
    public partial ushort GetBeastTribeNeededReputation(byte beastTribeId);

    #endregion

    /// <summary>
    /// Returns whether the player is possessing the maximum amount of specialized souls.
    /// </summary>
    [MemberFunction("0F B6 81 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ?? 89 44 24 08")]
    public partial bool IsMeisterFlagMaxCount();

    /// <summary>
    /// Returns whether the player is specialized in the given DoH ClassJob.
    /// </summary>
    /// <param name="classJobId">The ClassJob row id of the DoH job to check.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 0F AB F5")]
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

    /// <summary> Get the level of a specific job. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 0D ?? ?? ?? ?? 4C 8D 3D")]
    public partial short GetClassJobLevel(uint classJobId, bool shouldGetSynced);

    #region Unlocks

    /// <summary>
    /// Check if a specific mount has been unlocked by the player.
    /// </summary>
    /// <param name="mountId">The ID of the mount to look up.</param>
    /// <returns>Returns true if the mount has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 83 FB 01")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D8 0F B6 87")]
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

    /// <remarks>Only call this for FishParameter rows where IsInLog is true.</remarks>
    public bool IsFishCaught(uint fishParameterId) {
        return ((CaughtFishBitmask[(int)fishParameterId / 8] >> (byte)(fishParameterId % 8)) & 1) == 1;
    }

    public bool IsSpearfishCaught(uint spearfishingItemId) {
        var id = spearfishingItemId - 20000;
        return ((CaughtSpearfishBitmask[(int)id / 8] >> (byte)(id % 8)) & 1) == 1;
    }

    /// <summary>
    /// Check if a specific McGuffin (Collectible/Curiosity) has been unlocked by the player.
    /// </summary>
    /// <param name="mcGuffinId">The ID of the McGuffin to look up, generally from the McGuffin sheet.</param>
    /// <returns>Returns true if the McGuffin has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 48 8D 76")]
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
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 33 ED 66 0F 1F 44 00")]
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
    /// <param name="aetherCurrentCompFlgSetId">RowId of AetherCurrentCompFlgSet</param>
    [MemberFunction("4C 8B C9 85 D2 74 1D")]
    public partial bool IsAetherCurrentZoneComplete(uint aetherCurrentCompFlgSetId);

    /// <summary>
    /// Check if a Sightseeing Log vista has been discovered.
    /// </summary>
    /// <param name="adventureIndex">Index of the Adventure Row</param>
    [MemberFunction("E8 ?? ?? ?? ?? 88 84 24 ?? ?? ?? ?? 48 85 FF")]
    public partial bool IsAdventureComplete(uint adventureIndex);

    /// <summary>
    /// Check if a specific set of Glasses are unlocked. Internally, this will look up the associated GlassesStyle
    /// for the specified pair and check that it's valid and marked as unlocked in
    /// <see cref="UnlockedGlassesStylesBitmask"/>.
    /// </summary>
    /// <param name="glassesId">The RowID of a set of glasses to check.</param>
    /// <returns>Returns true if the specified glasses are unlocked, false otherwise.</returns>
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
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 41 81 FD")]
    public partial bool IsBattleMentor();

    /// <summary>
    /// Returns whether the player is a Trade Mentor.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 43 ?? F6 D8")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 41 88 46 ?? 41 38 76")]
    public partial bool IsReturner();

    /// <summary>
    /// Returns whether the specified PlayerStateFlag is set.
    /// </summary>
    /// <param name="flag">The PlayerStateFlag to check.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 3A C3 74 ?? EB")]
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

/// <remarks>
/// Mirrors BaseParam sheet values for ease of lookup
/// </remarks>
public enum PlayerAttribute : uint {
    Strength = 1,
    Dexterity = 2,
    Vitality = 3,
    Intelligence = 4,
    Mind = 5,
    Piety = 6,
    Health = 7,
    MagicPoints = 8,
    TacticalPoints = 9, // Yes TP is still in the game
    GatheringPoint = 10, // will be 10000 if current job is not a gathering job
    CraftingPoint = 11,
    PhysicalDamage = 12,
    MagicDamage = 13,
    Delay = 14,
    AdditionalEffect = 15, // Honestly not sure what this one is
    AttackSpeed = 16,
    BlockRate = 17,
    BlockStrength = 18,
    Tenacity = 19,
    AttackPower = 20,
    Defense = 21,
    DirectHitRate = 22,
    MagicDefense = 24,
    CriticalHitPower = 25,
    CriticalHitResilience = 26,
    CriticalHit = 27,
    CriticalHitEvasion = 28,
    SlashingResistance = 29,
    PiercingResistance = 30,
    BluntResistance = 31,
    ProjectileResistance = 32,
    AttackMagicPotency = 33,
    HealingMagicPotency = 34,
    Determination = 44,
    SkillSpeed = 45,
    SpellSpeed = 46,
    Craftsmanship = 70,
    Control = 71,
    Gathering = 72,
    Perception = 73
}

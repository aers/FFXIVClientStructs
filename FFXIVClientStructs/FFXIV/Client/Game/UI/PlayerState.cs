using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PlayerState
// ctor "48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ??"
[StructLayout(LayoutKind.Explicit, Size = 0x7D0)]
public unsafe partial struct PlayerState
{
    [FieldOffset(0x00)] public byte IsLoaded;
    [FieldOffset(0x01)] public fixed byte CharacterName[64];
    [FieldOffset(0x41)] public fixed byte PSNOnlineID[17];
    [FieldOffset(0x54)] public uint ObjectId;
    [FieldOffset(0x58)] public ulong ContentId;
    /// <remarks>
    /// 0 = Duty penalty<br/>
    /// 1 = Unknown<br/>
    /// See also: <see cref="RouletteController.GetPenaltyRemainingInMinutes" />
    /// </remarks>
    [FieldOffset(0x60)] public fixed uint PenaltyTimestamps[2];

    [FieldOffset(0x69)] public byte MaxLevel;
    [FieldOffset(0x6A)] public byte MaxExpansion;
    [FieldOffset(0x6B)] public byte Sex;
    [FieldOffset(0x6C)] public byte Race;
    [FieldOffset(0x6D)] public byte Tribe;
    [FieldOffset(0x6E)] public byte CurrentClassJobId;
    [FieldOffset(0x78)] public short CurrentLevel;

    [FieldOffset(0x7A)] public fixed short ClassJobLevelArray[30];
    [FieldOffset(0xB8)] public fixed int ClassJobExpArray[30];

    [FieldOffset(0x130)] public short SyncedLevel;
    [FieldOffset(0x132)] public byte IsLevelSynced;
    [FieldOffset(0x133)] public bool HasPremiumSaddlebag;

    [FieldOffset(0x136)] public byte GuardianDeity;
    [FieldOffset(0x137)] public byte BirthMonth;
    [FieldOffset(0x138)] public byte BirthDay;
    [FieldOffset(0x139)] public byte FirstClass;
    [FieldOffset(0x13A)] public byte StartTown;
    [FieldOffset(0x13B)] public byte QuestSpecialFlags;
    
    [FieldOffset(0x154)] public int BaseStrength;
    [FieldOffset(0x158)] public int BaseDexterity;
    [FieldOffset(0x15C)] public int BaseVitality;
    [FieldOffset(0x160)] public int BaseIntelligence;
    [FieldOffset(0x164)] public int BaseMind;
    [FieldOffset(0x168)] public int BasePiety;
    [FieldOffset(0x16C)] public fixed int Attributes[74];

    [FieldOffset(0x2E1)] public byte NumOwnedMounts;

    [FieldOffset(0x294)] public byte GrandCompany;
    [FieldOffset(0x295)] public byte GCRankMaelstrom;
    [FieldOffset(0x296)] public byte GCRankTwinAdders;
    [FieldOffset(0x297)] public byte GCRankImmortalFlames;
    [FieldOffset(0x298)] public byte HomeAetheryteId;
    [FieldOffset(0x299)] public byte FavouriteAetheryteCount;
    [FieldOffset(0x29A)] public fixed byte FavouriteAetheryteArray[4];
    [FieldOffset(0x29E)] public byte FreeAetheryteId;

    [FieldOffset(0x2A0)] public uint BaseRestedExperience;

    [FieldOffset(0x430)] public uint NumFishCaught;
    [FieldOffset(0x434)] public uint FishingBait;

    [FieldOffset(0x464)] public uint NumSpearfishCaught;

    /// <remarks>
    /// Index is column 27 of ContentRoulette sheet.<br/>
    /// See also: <see cref="RouletteController.IsRouletteComplete" />
    /// </remarks>
    [FieldOffset(0x46C)] public fixed byte ContentRouletteCompletion[12];
    [FieldOffset(0x478)] public short PlayerCommendations;
    /// <remarks>
    /// 0 = Idle Pose<br/>
    /// 1 = Unknown<br/>
    /// 2 = Sit Pose<br/>
    /// 3 = Ground Sit Pose<br/>
    /// 4 = Bed Pose<br/>
    /// 5 = Accessorie Pose: Umbrellas<br/>
    /// 6 = Accessorie Pose: Glasses, Wings
    /// </remarks>
    [FieldOffset(0x47A)] public fixed byte SelectedPoses[7];
    [FieldOffset(0x481)] public byte PlayerStateFlags1;
    [FieldOffset(0x482)] public byte PlayerStateFlags2;
    [FieldOffset(0x483)] public byte PlayerStateFlags3;

    [FieldOffset(0x501)] public fixed byte UnlockFlags[44];

    /// <summary>Carrier Level of Delivery Moogle Quests</summary>
    [FieldOffset(0x531)] public byte DeliveryLevel;

    /// <summary>
    /// Flag containing information about which DoH job the player is specialized in.
    /// </summary>
    /// <remarks>
    /// Use these instead:<br/>
    /// <see cref="IsMeisterFlag" /><br/>
    /// <see cref="IsMeisterFlagMaxCount" /><br/>
    /// <see cref="IsMeisterFlagAndHasSoulStoneEquipped" />
    /// </remarks>
    [FieldOffset(0x533)] public byte MeisterFlag;

    [FieldOffset(0x538)] public uint SquadronMissionCompletionTimestamp;
    [FieldOffset(0x53C)] public uint SquadronTrainingCompletionTimestamp;
    [FieldOffset(0x540)] public ushort ActiveGcArmyExpedition;
    [FieldOffset(0x542)] public ushort ActiveGcArmyTraining;

    #region Weekly Bonus/Weekly Bingo/Wondrous Tails Fields (packet reader: "4C 8B D2 48 8D 81")

    /// <summary>RowIds of WeeklyBingoOrderData sheet</summary>
    [FieldOffset(0x640)] public fixed byte WeeklyBingoOrderData[16];
    /// <summary>RowIds of WeeklyBingoRewardData sheet</summary>
    [FieldOffset(0x650)] public fixed byte WeeklyBingoRewardData[4];
    /// <summary>Bitflags of placed stickers.</summary>
    /// <remarks>Use IsWeeklyBingoStickerPlaced(index) and WeeklyBingoNumPlacedStickers instead.</remarks>
    [FieldOffset(0x654)] private readonly ushort _weeklyBingoStickers;

    /// <remarks>Use GetWeeklyBingoExpireUnixTimestamp(), WeeklyBingoNumSecondChancePoints and HasWeeklyBingoJournal instead</remarks>
    [FieldOffset(0x658)] private readonly uint _weeklyBingoFlags;
    [FieldOffset(0x65C)] private fixed byte _weeklyBingoTaskStatus[4];
    [FieldOffset(0x660)] public byte WeeklyBingoRequestOpenBingoNo;

    [FieldOffset(0x69C)] public byte WeeklyBingoExpMultiplier;
    [FieldOffset(0x69D)] public bool WeeklyBingoUnk63;

    #endregion

    [FieldOffset(0x734)] public byte MentorVersion; // latest is 2

    [FieldOffset(0x738)] public fixed uint DesynthesisLevels[8];
    
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 4D 8B F9", 3)]
    public static partial PlayerState* Instance();

    public bool IsLegacy => (QuestSpecialFlags & 1) != 0;
    public bool IsWarriorOfLight => (QuestSpecialFlags & 2) != 0;

    public float GetDesynthesisLevel(uint classJobId)
        => classJobId is < 8 or > 15 ? 0 : DesynthesisLevels[classJobId - 8] / 100f;

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A 86")]
    public partial byte GetGrandCompanyRank();

    [MemberFunction("E8 ?? ?? ?? ?? BE ?? ?? ?? ?? 84 C0 75 0C")]
    public partial byte GetBeastTribeRank(byte beastTribeIndex);

    [Obsolete("Use QuestManager.Instance()->GetBeastTribeAllowance() instead.", true)]
    public static ulong GetBeastTribeAllowance() => QuestManager.Instance()->GetBeastTribeAllowance();

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
    [MemberFunction("4C 8B C9 66 83 FA ?? 73")]
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

    #endregion

    #region Weekly Bonus/Weekly Bingo/Wondrous Tails

    public enum WeeklyBingoTaskStatus
    {
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
    private partial uint _getWeeklyBingoFlagsValue(uint mode);

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
    public uint WeeklyBingoNumSecondChancePoints => _getWeeklyBingoFlagsValue(3);

    /// <summary>Returns whether the player is in possession of the journal or not.</summary>
    public bool HasWeeklyBingoJournal => _getWeeklyBingoFlagsValue(5) != 0;

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

public enum PlayerStateFlag : uint
{
    IsLoginSecurityToken = 1,
    IsBuddyInStable = 2,
    IsMentorStatusActive = 7,
    IsNoviceNetworkAutoJoinEnabled = 8,
    IsBattleMentorStatusActive = 9,
    IsTradeMentorStatusActive = 10,
    IsPvPMentorStatusActive = 11,
    Unknown14 = 14,
}

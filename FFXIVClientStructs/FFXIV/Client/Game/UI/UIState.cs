using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::UIState
// this is a large object holding most of the other objects in the Client::Game::UI namespace
// all data in here is used for UI display
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1A400)]
public unsafe partial struct UIState {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 45 33 C0 BA ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? BA", 3)]
    public static partial UIState* Instance();

    [FieldOffset(0x00)] public Hotbar Hotbar;
    [FieldOffset(0x08)] public Hate Hate;
    [FieldOffset(0x110)] public Hater Hater;
    [FieldOffset(0xA18)] public Chain Chain;
    [FieldOffset(0xA20)] public WeaponState WeaponState;
    [FieldOffset(0xA38)] public PlayerState PlayerState;
    [FieldOffset(0x1360)] public Revive Revive;
    [FieldOffset(0x1390)] public Inspect Inspect;
    [FieldOffset(0x1630)] public Telepo Telepo;
    [FieldOffset(0x1688)] public Cabinet Cabinet;
    [FieldOffset(0x16A8)] public Achievement Achievement;
    [FieldOffset(0x1EF0)] public Buddy Buddy;
    [FieldOffset(0x42EC)] public PvPProfile PvPProfile;
    [FieldOffset(0x4378)] internal void* Unk4378; // queue for PvP ScreenImages and LogMessages, processed at the end of UIState.Update
    [FieldOffset(0x4380)] public ContentsNote ContentsNote;
    [FieldOffset(0x4438)] public RelicNote RelicNote;
    [FieldOffset(0x4450)] public MateriaTrade MateriaTrade;
    [FieldOffset(0x4498)] public PublicInstance PublicInstance;
    [FieldOffset(0x44C0)] public RelicSphereUpgrade RelicSphereUpgrade;
    [FieldOffset(0x4538)] public DailyQuestSupply DailyQuestSupply;
    [FieldOffset(0x4920)] public RidePillon RidePillon;
    [FieldOffset(0x4960)] public Loot Loot;
    [FieldOffset(0x5040)] public GatheringNote GatheringNote;
    [FieldOffset(0x5768)] public RecipeNote RecipeNote;
    [FieldOffset(0x62A8)] public FishingNote FishingNote;
    [FieldOffset(0x6388)] public FishRecord FishRecord;
    [FieldOffset(0x66C0)] public Journal Journal;
    [FieldOffset(0xAE28)] public QuestUI QuestUI;
    [FieldOffset(0xBE28)] public QuestTodoList QuestTodoList;
    [FieldOffset(0xC268)] public NpcTrade NpcTrade;
    [FieldOffset(0xC590)] public DirectorTodo DirectorTodo;
    [FieldOffset(0xC6D8)] public DirectorTodo FateDirectorTodo;
    [FieldOffset(0xC820)] public MassivePcContentTodo MassivePcContentTodo;
    [FieldOffset(0xC970)] public Map Map;
    [FieldOffset(0x10990)] public MarkingController MarkingController;
    [FieldOffset(0x10C70)] public LimitBreakController LimitBreakController;
    [FieldOffset(0x10C80)] public TitleController TitleController;
    [FieldOffset(0x10C88)] public TitleList TitleList;
    // some GM Call stuff
    [FieldOffset(0x10D28)] public GCSupply GCSupply;
    [FieldOffset(0x13950)] public InstanceContent InstanceContent;
    [FieldOffset(0x139C8)] public GuildOrderReward GuildOrderReward;
    [FieldOffset(0x13A28)] public ContentsFinder ContentsFinder;
    [FieldOffset(0x13AD8)] public Wedding Wedding;
    [FieldOffset(0x13B40)] public MobHunt MobHunt;
    [FieldOffset(0x13D30)] public WeatherForecast WeatherForecast;
    // an int to control AgentRecommendList
    [FieldOffset(0x13D58)] public TripleTriad TripleTriad;
    [FieldOffset(0x15588)] public EurekaElementalEdit EurekaElementalEdit;
    [FieldOffset(0x155A0)] public LovmRanking LovmRanking;
    [FieldOffset(0x171E0)] public CollectablesShop CollectablesShop;
    [FieldOffset(0x174D8)] public QTE QTE;
    [FieldOffset(0x17500)] public Emj Emj;
    [FieldOffset(0x17538)] public NpcYell NpcYell;
    [FieldOffset(0x19D88)] public CharaCard CharaCard;
    // 0x19E40: ItemAction Unlocks
    [FieldOffset(0x19FD0)] public ClientSelectDataConfigFlags ClientSelectDataConfigFlags;
    [FieldOffset(0x19FD2)] public ushort CurrentGlamourErrorsBitmask;
    [FieldOffset(0x19FD4)] public ushort CurrentItemLevel; // as shown in the Character window

    // [FieldOffset(0x19FD8)] public long ?; // something regarding FreeCompanyCrest?
    [FieldOffset(0x19FE0)] public long NextMapAllowanceTimestamp;
    [FieldOffset(0x19FE8)] public long NextChallengeLogResetTimestamp;

    // BitCount: See `Client::Game::UI::UIState.SetUnlockLinkValue`
    /// <remarks> Use <see cref="IsUnlockLinkUnlocked"/>. </remarks>
    [FieldOffset(0x19FF4), FixedSizeArray(isBitArray: true, bitCount: 736)] internal FixedSizeArray92<byte> _unlockLinks;

    // Ref: Telepo#UpdateAetheryteList (in the Aetheryte sheet loop)
    // BitCount: AetheryteSheet.RowCount
    /// <remarks> Use <see cref="IsAetheryteUnlocked"/>. </remarks>
    [FieldOffset(0x1A050), FixedSizeArray(isBitArray: true, bitCount: 240)] internal FixedSizeArray30<byte> _unlockedAetherytes;

    // Ref: "85 D2 0F 84 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F9"
    // BitCount: HowToSheet.RowCount
    /// <remarks> Use <see cref="IsHowToUnlocked"/>. </remarks>
    [FieldOffset(0x1A06E), FixedSizeArray(isBitArray: true, bitCount: 304)] internal FixedSizeArray38<byte> _unlockedHowTos;

    // Ref: "48 8D 0D ?? ?? ?? ?? 0F B6 04 08 84 D0 75 10 B8 ?? ?? ?? ?? 48 8B 5C 24"
    // BitCount: CompanionSheet.RowCount
    /// <remarks> Use <see cref="IsCompanionUnlocked"/>. </remarks>
    [FieldOffset(0x1A094), FixedSizeArray(isBitArray: true, bitCount: 600)] internal FixedSizeArray75<byte> _unlockedCompanions;

    // BitCount: ChocoboTaxiStandSheet.RowCount
    /// <remarks> Use <see cref="IsChocoboTaxiStandUnlocked"/>. </remarks>
    [FieldOffset(0x1A0DF), FixedSizeArray(isBitArray: true, bitCount: 93)] internal FixedSizeArray12<byte> _unlockedChocoboTaxiStands;

    // BitCount: CutsceneWorkIndexSheet.Max(row => row.WorkIndex)
    /// <remarks> Use <see cref="IsCutsceneSeen"/>. </remarks>
    [FieldOffset(0x1A0EB), FixedSizeArray(isBitArray: true, bitCount: 1432)] internal FixedSizeArray179<byte> _seenCutscenes;

    // BitCount: TripleTriadCardSheet.RowCount
    /// <remarks> Use <see cref="IsTripleTriadCardUnlocked"/>. </remarks>
    [FieldOffset(0x1A1A3), FixedSizeArray(isBitArray: true, bitCount: 476)] internal FixedSizeArray60<byte> _unlockedTripleTriadCards;
    [FieldOffset(0x1A1E0)] public ulong UnlockedTripleTriadCardsCount;

    // BitCount: TripleTriadResident.RowCount
    /// <remarks> Use <see cref="IsTripleTriadNpcBeaten"/>. </remarks>
    [FieldOffset(0x1A1E8), FixedSizeArray(isBitArray: true, bitCount: 131)] internal FixedSizeArray17<byte> _beatenTripleTriadResidents;

    // unk byte

    [FieldOffset(0x1A1FA)] public int TerritoryTypeTransientOffsetZ; // this is a short in the sheet and copied with a 4 byte register causing it to be an int
    [FieldOffset(0x1A1FE)] public byte BeginnerGuideFlags;
    [FieldOffset(0x1A1FF)] public byte BattleEffectSelf;
    [FieldOffset(0x1A200)] public byte BattleEffectParty;
    [FieldOffset(0x1A201)] public byte BattleEffectOther;

    [FieldOffset(0x1A203)] public byte BattleEffectPvPEnemyPc;

    [FieldOffset(0x1A208)] public uint UnlockedCompanionsCount;

    [FieldOffset(0x1A3F9)] public bool TerritoryTypeTransientRowLoaded;

    [FieldOffset(0x1A3FB)] public byte GMRank;

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 23")]
    public partial bool IsUnlockLinkUnlocked(uint unlockLink);

    /// <summary>
    /// Checks to see if an unlock link is unlocked, or if the passed value is greater than 0x10000, checks if the quest
    /// is completed.
    /// </summary>
    /// <param name="unlockLinkOrQuestId">The unlock link or quest ID to check.</param>
    /// <param name="minQuestProgression">If the quest is not complete, check for <em>at least</em> this level of
    /// progress in the quest (using <see cref="QuestManager.GetQuestSequence(ushort)"/>. If this parameter is <c>0</c>,
    /// the quest must have been completed.</param>
    /// <param name="a4">Exact purpose unknown, but appears to be a flag to respect Unlock Flag 245 (ignore quest
    /// progression?) for quest-based checks. Virtually always <c>true</c> in game code.</param>
    /// <returns>Returns true if the unlock link is unlocked or if the quest is completed.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 44 22 F0")]
    public partial bool IsUnlockLinkUnlockedOrQuestCompleted(uint unlockLinkOrQuestId, byte minQuestProgression = 0, bool a4 = true);

    /// <summary>
    /// Check an item (by EXD row) to see if the action associated with the item is unlocked or "obtained/registered."
    /// </summary>
    /// <remarks>
    /// This method <b>will</b> call EXD, so the usual caveats there apply. Where possible, use a by-ID check as
    /// they're generally faster and/or rely less on EXD.
    /// </remarks>
    /// <param name="itemExdPtr">A pointer to an EXD row for an item, generally retrieved from <see cref="ExdModule.GetItemRowById"/>.</param>
    /// <returns>Returns a value denoting this item's unlock status from the below table:
    /// <list type="table">
    /// <listheader><term>Value</term><description>Meaning</description></listheader>
    /// <item><term>1</term><description>The item is unlocked/registered.</description></item>
    /// <item><term>2</term><description>The item is not unlocked/registered, but can be.</description></item>
    /// <item><term>3</term><description>Unknown, possibly "information not loaded yet."</description></item>
    /// <item><term>4</term><description>The item does not have an unlock status.</description></item>
    /// </list>
    /// </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CD 89 87")]
    public partial long IsItemActionUnlocked([CExporterExcel("Item")] void* itemExdPtr);

    /// <summary>
    /// Check if a Triple Triad card is obtained by the character.
    /// </summary>
    /// <param name="cardId">The ID of the card (technically, of TripleTriadCardResident) to check against.</param>
    /// <returns>Returns true if the card is unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 66 0F 44 FD")]
    public partial bool IsTripleTriadCardUnlocked(ushort cardId);

    /// <summary>
    /// Check if a Triple Triad Npc has been beaten once.
    /// </summary>
    /// <param name="tripleTriadResidentId">TripleTriadResident row id</param>
    [MemberFunction("40 53 48 83 EC 20 8D 82 FE FF DC FF")]
    public partial bool IsTripleTriadNpcBeaten(uint tripleTriadResidentId);

    /// <summary>
    /// Check if an emote (by ID) is unlocked.
    /// </summary>
    /// <remarks>
    /// This method *will* perform an EXD get. If the unlock link is known it is better to call
    /// <see cref="IsUnlockLinkUnlockedOrQuestCompleted"/> in order to prevent the extra call, as it performs
    /// functionally the same checks.
    /// </remarks>
    /// <param name="emoteId">The ID of the emote to check for.</param>
    /// <returns>Returns true if the emote is unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? ?? ?? 41 B8")]
    public partial bool IsEmoteUnlocked(ushort emoteId);

    /// <summary>
    /// Check if a aetheryte is unlocked for the current character.
    /// </summary>
    /// <param name="aetheryteId">The ID of the aetheryte to check for.</param>
    /// <returns>Returns true if the specified aetheryte is unlocked.</returns>
    public bool IsAetheryteUnlocked(uint aetheryteId)
        => UnlockedAetherytesBitArray.Get((int)aetheryteId);

    /// <summary>
    /// Check if a HowTo is unlocked for the current character.
    /// </summary>
    /// <param name="howtoId">The ID of the HowTo to check for.</param>
    /// <returns>Returns true if the specified HowTo is unlocked.</returns>
    public bool IsHowToUnlocked(uint howtoId)
        => UnlockedHowTosBitArray.Get((int)howtoId);

    /// <summary>
    /// Check if a companion (minion) is unlocked for the current character.
    /// </summary>
    /// <param name="companionId">The ID of the companion/minion to check for.</param>
    /// <returns>Returns true if the specified minion is unlocked.</returns>
    public bool IsCompanionUnlocked(uint companionId)
        => UnlockedCompanionsBitArray.Get((int)companionId);

    public bool IsChocoboTaxiStandUnlocked(uint chocoboTaxiStandId)
        => UnlockedChocoboTaxiStandsBitArray.Get((int)chocoboTaxiStandId - 0x120000);

    [MemberFunction("E8 ?? ?? ?? ?? 88 43 ?? B0")]
    public static partial bool IsInstanceContentCompleted(uint instanceContentId);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 44")]
    public static partial bool IsInstanceContentUnlocked(uint instanceContentId);

    [MemberFunction("48 83 EC 28 E8 ?? ?? ?? ?? 48 85 C0 74 14 0F B7 40 2A")]
    public static partial bool IsPublicContentCompleted(uint publicContentId);

    [MemberFunction("E9 ?? ?? ?? ?? 0F B6 05 ?? ?? ?? ?? 24 01")]
    public static partial bool IsPublicContentUnlocked(uint publicContentId);

    /// <summary> Check if the player has seen the cutscene before. </summary>
    /// <remarks>
    /// Only tracks skippable cutscenes (for that, check if WorkIndex is not 0 in CutsceneWorkIndex sheet).
    /// </remarks>
    /// <param name="cutsceneId"> RowId of the Cutscene </param>
    /// <returns> Returns <c>true</c> if the player has seen the cutscene before, otherwise <c>false</c>. </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 0F B6 CB 3A C3")]
    public partial bool IsCutsceneSeen(uint cutsceneId);

    /// <remarks>Requests timestamps for <see cref="NextMapAllowanceTimestamp"/> and <see cref="NextChallengeLogResetTimestamp"/>.</remarks>
    [MemberFunction("48 83 EC 38 48 C7 81")]
    public partial bool RequestResetTimestamps();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 E8 ?? ?? ?? ?? 8D 48 05")]
    public partial long GetNextMapAllowanceTimestamp();

    public DateTime GetNextMapAllowanceDateTime() {
        var timeStamp = GetNextMapAllowanceTimestamp();
        return timeStamp > 0 ? DateTime.UnixEpoch.AddSeconds(timeStamp) : DateTime.MinValue;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 E8 ?? ?? ?? ?? 44 8B C8")]
    public partial long GetNextChallengeLogResetTimestamp();

    public DateTime GetNextChallengeLogResetDateTime() {
        var timeStamp = GetNextChallengeLogResetTimestamp();
        return timeStamp > 0 ? DateTime.UnixEpoch.AddSeconds(timeStamp) : DateTime.MinValue;
    }

    /// <summary> Checks if the local player can dismount in the air. </summary>
    /// <param name="outPosition"> The position on the ground below the player. </param>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 24 4D 85 F6")]
    public partial bool GetIsAirDismountable(Vector3* outPosition);
}

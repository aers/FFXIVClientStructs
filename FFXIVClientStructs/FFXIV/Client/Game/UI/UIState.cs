using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::UIState
// this is a large object holding most of the other objects in the Client::Game::UI namespace
// all data in here is used for UI display
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1A230)]
public unsafe partial struct UIState {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 8B 01", 3)]
    public static partial UIState* Instance();

    [FieldOffset(0x00)] public Hotbar Hotbar;
    [FieldOffset(0x08)] public Hate Hate;
    [FieldOffset(0x110)] public Hater Hater;
    [FieldOffset(0xA18)] public Chain Chain;
    [FieldOffset(0xA20)] public WeaponState WeaponState;
    [FieldOffset(0xA38)] public PlayerState PlayerState; // 7.3: size +0x18
    [FieldOffset(0x1310)] public Revive Revive;
    [FieldOffset(0x1340)] public Inspect Inspect;
    [FieldOffset(0x15E0)] public Telepo Telepo;
    [FieldOffset(0x1638)] public Cabinet Cabinet;
    [FieldOffset(0x16C0)] public Achievement Achievement; // 7.2: size +0x1E8
    [FieldOffset(0x1EA8)] public Buddy Buddy; // 7.2: size +0x870
    [FieldOffset(0x42A4)] public PvPProfile PvPProfile;
    [FieldOffset(0x4330)] internal void* Unk4330; // some UI timer for PvP Results?!
    [FieldOffset(0x4338)] public ContentsNote ContentsNote;
    [FieldOffset(0x43F0)] public RelicNote RelicNote;
    [FieldOffset(0x4408)] public MateriaTrade MateriaTrade;
    [FieldOffset(0x4450)] public PublicInstance PublicInstance;
    [FieldOffset(0x4478)] public RelicSphereUpgrade RelicSphereUpgrade;
    [FieldOffset(0x44F0)] public DailyQuestSupply DailyQuestSupply;
    [FieldOffset(0x48D8)] public RidePillon RidePillon;
    [FieldOffset(0x4918)] public Loot Loot;
    [FieldOffset(0x4FB8)] public GatheringNote GatheringNote; // 7.2: size +0x38
    [FieldOffset(0x56B8)] public RecipeNote RecipeNote; // 7.2: size +0x28
    [FieldOffset(0x61F8)] public FishingNote FishingNote;
    [FieldOffset(0x62D8)] public FishRecord FishRecord;
    [FieldOffset(0x6610)] public Journal Journal;
    [FieldOffset(0xAD78)] public QuestUI QuestUI; // 7.2: size +0x10
    [FieldOffset(0xBD78)] public QuestTodoList QuestTodoList;
    [FieldOffset(0xC1B8)] public NpcTrade NpcTrade;
    [FieldOffset(0xC4E0)] public DirectorTodo DirectorTodo;
    [FieldOffset(0xC628)] public DirectorTodo FateDirectorTodo;
    // [FieldOffset(0xC770)] public MassivePcContentTodo MassivePcContentTodo;
    [FieldOffset(0xC770)] internal void* UnkC728; // TODO: remove for MassivePcContentTodo struct above
    [FieldOffset(0xC778)] public DirectorTodo MassivePcContentTodo; // TODO: remove for MassivePcContentTodo struct above
    [FieldOffset(0xC8C0)] public Map Map; // 7.2: size +0x08
    [FieldOffset(0x108D0)] public MarkingController MarkingController;
    [FieldOffset(0x10BB0)] public LimitBreakController LimitBreakController;
    [FieldOffset(0x10BC0)] public TitleController TitleController;
    [FieldOffset(0x10BC8)] public TitleList TitleList;
    // some GM Call stuff
    [FieldOffset(0x10C60)] public GCSupply GCSupply;
    [FieldOffset(0x13888)] public InstanceContent InstanceContent;
    [FieldOffset(0x13900)] public GuildOrderReward GuildOrderReward;
    [FieldOffset(0x13960)] public ContentsFinder ContentsFinder;
    [FieldOffset(0x13A10)] public Wedding Wedding;
    [FieldOffset(0x13A78)] public MobHunt MobHunt;
    [FieldOffset(0x13C68)] public WeatherForecast WeatherForecast;
    // an int to control AgentRecommendList
    [FieldOffset(0x13C90)] public TripleTriad TripleTriad; // 7.2: size+0x70
    // TODO: 7.3 - unsure from here on
    [FieldOffset(0x153C8)] public EurekaElementalEdit EurekaElementalEdit; // 7.2: size +0x04?
    [FieldOffset(0x153E0)] public LovmRanking LovmRanking; // 7.2: size -0x04?
    [FieldOffset(0x17020)] public CollectablesShop CollectablesShop; // 7.2: size +0x20
    // TODO: 7.3 - sure from here on
    [FieldOffset(0x17318)] public QTE QTE;
    [FieldOffset(0x17340)] public Emj Emj;
    [FieldOffset(0x17378)] public NpcYell NpcYell;
    // 7.3: huge space between these two
    [FieldOffset(0x19BC8)] public CharaCard CharaCard;
    // 0x19DB0: ItemAction Unlocks
    [FieldOffset(0x19E08)] public ClientSelectDataConfigFlags ClientSelectDataConfigFlags;
    [FieldOffset(0x19E0A)] public ushort CurrentGlamourErrorsBitmask;
    [FieldOffset(0x19E0C)] public ushort CurrentItemLevel; // as shown in the Character window
    // [FieldOffset(0x19E10)] public long ?; // something regarding FreeCompanyCrest?
    [FieldOffset(0x19E18)] public long NextMapAllowanceTimestamp;
    [FieldOffset(0x19E20)] public long NextChallengeLogResetTimestamp;

    [FieldOffset(0x19E2C), FixedSizeArray, Obsolete("Use UnlockLinksBitArray")] internal FixedSizeArray92<byte> _unlockLinkBitmask;
    // BitCount: See `Client::Game::UI::UIState.SetUnlockLinkValue`
    /// <remarks> Use <see cref="IsUnlockLinkUnlocked"/>. </remarks>
    [FieldOffset(0x19E2C), FixedSizeArray(isBitArray: true, bitCount: 736)] internal FixedSizeArray92<byte> _unlockLinks;

    [FieldOffset(0x19E88), FixedSizeArray, Obsolete("Use UnlockedAetherytesBitArray")] internal FixedSizeArray30<byte> _unlockedAetherytesBitmask;
    // Ref: Telepo#UpdateAetheryteList (in the Aetheryte sheet loop)
    // BitCount: AetheryteSheet.RowCount
    /// <remarks> Use <see cref="IsAetheryteUnlocked"/>. </remarks>
    [FieldOffset(0x19E88), FixedSizeArray(isBitArray: true, bitCount: 239)] internal FixedSizeArray30<byte> _unlockedAetherytes;

    [FieldOffset(0x19EA6), FixedSizeArray, Obsolete("Use UnlockedHowTosBitArray")] internal FixedSizeArray37<byte> _unlockedHowtoBitmask;
    // Ref: "85 D2 0F 84 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F9"
    // BitCount: HowToSheet.RowCount
    /// <remarks> Use <see cref="IsHowToUnlocked"/>. </remarks>
    [FieldOffset(0x19EA6), FixedSizeArray(isBitArray: true, bitCount: 296)] internal FixedSizeArray37<byte> _unlockedHowTos;

    [FieldOffset(0x19ECB), FixedSizeArray, Obsolete("Use UnlockedCompanionsBitArray")] internal FixedSizeArray71<byte> _unlockedCompanionsBitmask;
    // Ref: "48 8D 0D ?? ?? ?? ?? 0F B6 04 08 84 D0 75 10 B8 ?? ?? ?? ?? 48 8B 5C 24"
    // BitCount: CompanionSheet.RowCount
    /// <remarks> Use <see cref="IsCompanionUnlocked"/>. </remarks>
    [FieldOffset(0x19ECB), FixedSizeArray(isBitArray: true, bitCount: 568)] internal FixedSizeArray71<byte> _unlockedCompanions;

    [FieldOffset(0x19F12), FixedSizeArray, Obsolete("Use UnlockedChocoboTaxiStandsBitArray")] internal FixedSizeArray12<byte> _chocoboTaxiStandsBitmask;
    [FieldOffset(0x19F12), FixedSizeArray, Obsolete("Use UnlockedChocoboTaxiStandsBitArray")] internal FixedSizeArray12<byte> _unlockedChocoboTaxiStandsBitmask;
    // BitCount: ChocoboTaxiStandSheet.RowCount
    /// <remarks> Use <see cref="IsChocoboTaxiStandUnlocked"/>. </remarks>
    [FieldOffset(0x19F12), FixedSizeArray(isBitArray: true, bitCount: 93)] internal FixedSizeArray12<byte> _unlockedChocoboTaxiStands;

    [FieldOffset(0x19F1E), FixedSizeArray, Obsolete("Use SeenCutscenesBitArray")] internal FixedSizeArray173<byte> _cutsceneSeenBitmask;
    // BitCount: CutsceneWorkIndexSheet.Max(row => row.WorkIndex)
    /// <remarks> Use <see cref="IsCutsceneSeen"/>. </remarks>
    [FieldOffset(0x19F1E), FixedSizeArray(isBitArray: true, bitCount: 1384)] internal FixedSizeArray173<byte> _seenCutscenes;

    // unk bitmasks

    [FieldOffset(0x19FCC), FixedSizeArray, Obsolete("Use UnlockedTripleTriadCardsBitArray")] internal FixedSizeArray57<byte> _unlockedTripleTriadCardsBitmask;
    // BitCount: TripleTriadCardSheet.RowCount
    /// <remarks> Use <see cref="IsTripleTriadCardUnlocked"/>. </remarks>
    [FieldOffset(0x19FCC), FixedSizeArray(isBitArray: true, bitCount: 455)] internal FixedSizeArray57<byte> _unlockedTripleTriadCards;
    [FieldOffset(0x1A008)] public ulong UnlockedTripleTriadCardsCount;

    [FieldOffset(0x1A022)] public int TerritoryTypeTransientOffsetZ; // this is a short in the sheet and copied with a 4 byte register causing it to be an int
    [FieldOffset(0x1A026)] public byte BeginnerGuideFlags;
    [FieldOffset(0x1A027)] public byte BattleEffectSelf;
    [FieldOffset(0x1A028)] public byte BattleEffectParty;
    [FieldOffset(0x1A029)] public byte BattleEffectOther;

    [FieldOffset(0x1A02B)] public byte BattleEffectPvPEnemyPc;

    [FieldOffset(0x1A030)] public uint UnlockedCompanionsCount;

    [FieldOffset(0x1A221)] public bool TerritoryTypeTransientRowLoaded;

    [FieldOffset(0x1A223)] public byte GMRank;

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
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 A2")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B CD 89 87")]
    public partial long IsItemActionUnlocked([CExporterExcel("Item")] void* itemExdPtr);

    /// <summary>
    /// Check if a Triple Triad card is obtained by the character.
    /// </summary>
    /// <param name="cardId">The ID of the card (technically, of TripleTriadCardResident) to check against.</param>
    /// <returns>Returns true if the card is unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 66 89 8C")]
    public partial bool IsTripleTriadCardUnlocked(ushort cardId);

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

    [MemberFunction("E8 ?? ?? ?? ?? 88 46 02 B0 01")]
    public static partial bool IsInstanceContentCompleted(uint instanceContentId);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 75 38")]
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
}

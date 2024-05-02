using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Game.Fate;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::UIState
// ctor "E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 48 83 C4 28 E9 ?? ?? ?? ?? 48 83 EC 28 33 D2"
// this is a large object holding most of the other objects in the Client::Game::UI namespace
// all data in here is used for UI display
[StructLayout(LayoutKind.Explicit, Size = 0x17D10)] // its at least this big, may be a few bytes bigger
public unsafe partial struct UIState {
    [FieldOffset(0x00)] public Hotbar Hotbar;
    [FieldOffset(0x08)] public Hate Hate;
    [FieldOffset(0x110)] public Hater Hater;
    [FieldOffset(0xA18)] public Chain Chain;
    [FieldOffset(0xA20)] public WeaponState WeaponState;
    [FieldOffset(0xA38)] public PlayerState PlayerState;
    [FieldOffset(0x1250)] public Revive Revive;
    [FieldOffset(0x1280)] public Inspect Inspect;
    [FieldOffset(0x14F8)] public Telepo Telepo;
    [FieldOffset(0x1550)] public Cabinet Cabinet;
    [FieldOffset(0x15D8)] public Achievement Achievement;
    [FieldOffset(0x1B30)] public Buddy Buddy;
    [FieldOffset(0x36B4)] public PvPProfile PvPProfile;
    [FieldOffset(0x3730)] internal void* Unk3730; // some UI timer for PvP Results?!
    [FieldOffset(0x3738)] public ContentsNote ContentsNote;
    [FieldOffset(0x37F0)] public RelicNote RelicNote;
    [FieldOffset(0x3808)] public TradeMultiple TradeMultiple;
    [FieldOffset(0x3850)] public AreaInstance AreaInstance; // at vtbl - 0x10
    [FieldOffset(0x3878)] public RelicSphereUpgrade RelicSphereUpgrade;
    [FieldOffset(0x38F0)] public DailyQuestSupply DailyQuestSupply;
    [FieldOffset(0x3CD8)] public RidePillon RidePillon;
    [FieldOffset(0x3D18)] public Loot Loot;
    [FieldOffset(0x43B8)] public GatheringNote GatheringNote;
    [FieldOffset(0x49E0)] public RecipeNote RecipeNote;
    [FieldOffset(0x5500)] public FishingNote FishingNote;
    [FieldOffset(0x5550)] public FishRecord FishRecord;
    [FieldOffset(0x5830)] public Journal Journal;
    [FieldOffset(0x9F78)] public QuestUI QuestUI;
    [FieldOffset(0xAF48)] public QuestTodoList QuestTodoList;
    [FieldOffset(0xB238)] public NpcTrade NpcTrade;
    [FieldOffset(0xB560)] public Director* ActiveDirector;

    [FieldOffset(0xB6A8)] public FateDirector* FateDirector;

    [FieldOffset(0xB7F0)] public Map Map;
    [FieldOffset(0xF7F0)] public MarkingController MarkingController;
    [FieldOffset(0xFAD0)] public LimitBreakController LimitBreakController;
    [FieldOffset(0xFAE0)] public void* TitleController;
    [FieldOffset(0xFAE8)] public TitleList TitleList;

    [FieldOffset(0xFB70)] public GCSupply GCSupply;
    [FieldOffset(0x12798)] public RouletteController RouletteController;
    [FieldOffset(0x12808)] public GuildOrderReward GuildOrderReward;
    [FieldOffset(0x12868)] public ContentsFinder ContentsFinder;
    [FieldOffset(0x12918)] public Wedding Wedding;
    [FieldOffset(0x12980)] public MobHunt MobHunt;
    [FieldOffset(0x12B18)] public WeatherForecast WeatherForecast;
    [FieldOffset(0x12B40)] public TripleTriad TripleTriad;
    [FieldOffset(0x14050)] public EurekaElementalEdit EurekaElementalEdit;
    [FieldOffset(0x14068)] public LovmRanking LovmRanking;
    [FieldOffset(0x15CA8)] public CollectablesShop CollectablesShop;
    [FieldOffset(0x15F60)] public QTE QTE;
    [FieldOffset(0x15F88)] public Emj Emj;
    [FieldOffset(0x15FC0)] public GoldSaucerYell GoldSaucerYell;
    [FieldOffset(0x17710)] public CharaCard CharaCard;
    // 0x178C8: unknown struct, size 0x58

    // Ref: UIState#IsUnlockLinkUnlocked (relative to uistate)
    // Size: Offset of UnlockedAetherytesBitmask - Offset of UnlockLinkBitmask
    [FieldOffset(0x17954)] public fixed byte UnlockLinkBitmask[0x40];

    // Ref: Telepo#UpdateAetheryteList (in the Aetheryte sheet loop)
    // Size: (AetheryteSheet.RowCount + 7) >> 3
    [FieldOffset(0x17994)] public fixed byte UnlockedAetherytesBitmask[(201 + 7) >> 3];

    // Ref: "E8 ?? ?? ?? ?? 48 83 6F ?? ?? 75 06 48 89 77 68"
    // Size: (HowToSheet.RowCount + 7) >> 3
    [FieldOffset(0x179AE)] public fixed byte UnlockedHowtoBitmask[(288 + 7) >> 3];

    // Ref: g_Client::Game::UI::UnlockedCompanionsMask
    //      direct ref: "48 8D 0D ?? ?? ?? ?? 0F B6 04 08 84 D0 75 10 B8 ?? ?? ?? ?? 48 8B 5C 24"
    //      relative to uistate: "E8 ?? ?? ?? ?? 84 C0 75 A6 32 C0" (case for 0x355)
    // Size: (CompanionSheet.RowCount + 7) >> 3
    [FieldOffset(0x179D2)] public fixed byte UnlockedCompanionsBitmask[(512 + 7) >> 3];

    // Ref: "42 0F B6 04 30 44 84 C0"
    // Size: (ChocoboTaxiStandSheet.RowCount + 7) >> 3
    [FieldOffset(0x17A12)] public fixed byte ChocoboTaxiStandsBitmask[(87 + 7) >> 3];

    // Ref: UIState#IsCutsceneSeen
    // Size: (CutsceneWorkIndexSheet.Max(row => row.WorkIndex) + 7) >> 3
    [FieldOffset(0x17A1E)] public fixed byte CutsceneSeenBitmask[(1272 + 7) >> 3];

    // Ref: UIState#IsTripleTriadCardUnlocked
    // Size: TripleTriadCard.RowCount >> 3
    [FieldOffset(0x17ABD)] public fixed byte UnlockedTripleTriadCardsBitmask[409 >> 3];
    [FieldOffset(0x17AF0)] public ulong UnlockedTripleTriadCardsCount;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 8B 01", 3)]
    public static partial UIState* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 88 45 80")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 CE")]
    public partial bool IsUnlockLinkUnlockedOrQuestCompleted(uint unlockLinkOrQuestId, byte minQuestProgression = 0,
        bool a4 = true);

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
    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 01 75 03")]
    public partial long IsItemActionUnlocked(void* itemExdPtr);

    /// <summary>
    /// Check if a Triple Triad card is obtained by the character.
    /// </summary>
    /// <param name="cardId">The ID of the card (technically, of TripleTriadCardResident) to check against.</param>
    /// <returns>Returns true if the card is unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8D 7B 78")]
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
    [MemberFunction("E9 ?? ?? ?? ?? 8B 13 41 B8 ?? ?? ?? ?? 8B CA")]
    public partial bool IsEmoteUnlocked(ushort emoteId);

    /// <summary>
    /// Check if a aetheryte is unlocked for the current character.
    /// </summary>
    /// <param name="aetheryteId">The ID of the aetheryte to check for.</param>
    /// <returns>Returns true if the specified aetheryte is unlocked.</returns>
    public bool IsAetheryteUnlocked(uint aetheryteId) {
        return ((1 << ((int)aetheryteId & 7)) & UnlockedAetherytesBitmask[aetheryteId >> 3]) > 0;
    }

    /// <summary>
    /// Check if a HowTo is unlocked for the current character.
    /// </summary>
    /// <param name="howtoId">The ID of the HowTo to check for.</param>
    /// <returns>Returns true if the specified HowTo is unlocked.</returns>
    public bool IsHowToUnlocked(uint howtoId) {
        return ((1 << ((int)howtoId & 7)) & UnlockedHowtoBitmask[howtoId >> 3]) > 0;
    }

    /// <summary>
    /// Check if a companion (minion) is unlocked for the current character.
    /// </summary>
    /// <remarks>
    /// WARNING: This method is NOT BOUNDED on IDs. While *one* function seems to set an upper bound on this, this
    /// method is a pain in the neck to find *and*, frustratingly, cannot be sigged. 
    /// </remarks>
    /// <param name="companionId">The ID of the companion/minion to check for.</param>
    /// <returns>Returns true if the specified minion is unlocked.</returns>
    public bool IsCompanionUnlocked(uint companionId) {
        // Logic borrowed from "E8 ?? ?? ?? ?? 84 C0 75 A6 32 C0" and others.

        // This, for some reason, does not exist as a siggable method in the game code normally. Virtually everyone and
        // everything that does minion checks will have this snippet (or one like it) in place. One does exist in the
        // crossref for the bitmask, but it's over in what I suspect is in the UI module and is bounded. I don't want to
        // replicate this upper bound here as that'll just be something we need to change with alarming regularity.

        return ((1 << ((int)companionId & 7)) & UnlockedCompanionsBitmask[companionId >> 3]) > 0;
    }

    public bool IsChocoboTaxiStandUnlocked(uint chocoboTaxiStandId) {
        return ((1 << ((ushort)chocoboTaxiStandId & 7)) & ChocoboTaxiStandsBitmask[(ushort)chocoboTaxiStandId >> 3]) > 0;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 44 22 F0")]
    public static partial bool IsInstanceContentCompleted(uint instanceContentId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7C 24 ?? 3C")]
    public static partial bool IsInstanceContentUnlocked(uint instanceContentId);

    [MemberFunction("48 83 EC 28 E8 ?? ?? ?? ?? 48 85 C0 74 15 0F B7 40 2A")]
    public static partial bool IsPublicContentCompleted(uint publicContentId);

    [MemberFunction("E8 ?? ?? ?? ?? 80 BF ?? ?? ?? ?? ?? 74 1E")]
    public static partial bool IsPublicContentUnlocked(uint publicContentId);

    /// <summary> Check if the player has seen the cutscene before. </summary>
    /// <remarks>
    /// Only tracks skippable cutscenes (for that, check if WorkIndex is not 0 in CutsceneWorkIndex sheet).
    /// </remarks>
    /// <param name="cutsceneId"> RowId of the Cutscene </param>
    /// <returns> Returns <c>true</c> if the player has seen the cutscene before, otherwise <c>false</c>. </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 0F B6 CE")]
    public partial bool IsCutsceneSeen(uint cutsceneId);

    // Only valid after the timers window has been opened, returns -1 otherwise.
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 E8 ?? ?? ?? ?? 49 8D 9F")]
    public partial int GetNextMapAllowanceTimestamp();

    // Only valid after the timers window has been opened, returns DateTime.MinValue otherwise.
    public DateTime GetNextMapAllowanceDateTime() {
        var timeStamp = GetNextMapAllowanceTimestamp();
        return timeStamp > 0 ? DateTime.UnixEpoch.AddSeconds(timeStamp) : DateTime.MinValue;
    }
}

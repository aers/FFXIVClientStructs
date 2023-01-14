using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Game.Fate;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;
// this is a large object holding most of the other objects in the Client::Game::UI namespace
// all data in here is used for UI display

// ctor E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 48 83 C4 28 E9 ?? ?? ?? ?? 48 83 EC 28 33 D2 
[StructLayout(LayoutKind.Explicit, Size = 0x16BAC)] // its at least this big, may be a few bytes bigger
public unsafe partial struct UIState
{
    [FieldOffset(0x00)] public Hotbar Hotbar;
    [FieldOffset(0x08)] public Hate Hate;
    [FieldOffset(0x110)] public Hater Hater;
    [FieldOffset(0xA18)] public WeaponState WeaponState;
    [FieldOffset(0xA38)] public PlayerState PlayerState;
    [FieldOffset(0x1208)] public Revive Revive;
    [FieldOffset(0x14A0)] public Telepo Telepo;
    [FieldOffset(0x14F8)] public Cabinet Cabinet;
    [FieldOffset(0x1A90)] public Buddy Buddy;
    [FieldOffset(0x2A98)] public RelicNote RelicNote;
    [FieldOffset(0x2AF8)] public AreaInstance AreaInstance;
    
    [FieldOffset(0x3C60)] public RecipeNote RecipeNote;

    [FieldOffset(0xA7C8)] public Director* ActiveDirector;
    [FieldOffset(0xA910)] public FateDirector* FateDirector;

    [FieldOffset(0xAA58)] public Map Map;

    [FieldOffset(0xEA40)] public MarkingController MarkingController;

    [FieldOffset(0x11A88)] public ContentsFinder ContentsFinder;

    // Ref: UIState#IsUnlockLinkUnlocked (relative to uistate)
    [FieldOffset(0x169FC)] public fixed byte UnlockLinkBitmask[0x7E];
    
    // Ref: g_Client::Game::UI::UnlockedCompanionsMask
    //      direct ref: 48 8D 0D ?? ?? ?? ?? 0F B6 04 08 84 D0 75 10 B8 ?? ?? ?? ?? 48 8B 5C 24
    //      relative to uistate: E8 ?? ?? ?? ?? 84 C0 75 A6 32 C0 (case for 0x355)
    [FieldOffset(0x16A7A)] public fixed byte UnlockedCompanionsBitmask[0x3A];
    
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
    /// This method populates offset 324 of *something*, which is then used in turn to display the "checked" flag on
    /// unlockable items. It's used in a few other places, but this appears to be the primary use.
    /// <br /><br />
    /// This method **will** call EXD, so the usual caveats there apply. Where possible, use a by-ID check as they're
    /// generally faster or rely less on EXD.
    /// </remarks>
    /// <param name="itemExdPtr">A pointer to an EXD row for an item, generally retrieved from <see cref="ExdModule.GetItemRowById"/>.</param>
    /// <returns>Returns a number (byte?) based on the item's unlock status. For reasons unknown, this is a long but
    /// no value above 4 has ever been noted.
    /// <list type="table">
    /// <listheader><term>Value</term><description>Meaning</description></listheader>
    /// <item><term>1</term><description>The item is unlocked/registered.</description></item>
    /// <item><term>2</term><description>The item is not unlocked/registered, but can be.</description></item>
    /// <item><term>3</term><description>Can be returned, but not clear as to when.</description></item>
    /// <item><term>4</term><description>The item has no unlock action, or an unlock action was not found.</description></item>
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
    /// Check if a companion (minion) is unlocked for the current character.
    /// </summary>
    /// <remarks>
    /// WARNING: This method is NOT BOUNDED on IDs. While *one* function seems to set an upper bound on this, this
    /// method is a pain in the neck to find *and*, frustratingly, cannot be sigged. 
    /// </remarks>
    /// <param name="companionId">The ID of the companion/minion to check for.</param>
    /// <returns>Returns true if the specified minion is unlocked.</returns>
    public bool IsCompanionUnlocked(uint companionId) {
        // Logic borrowed from E8 ?? ?? ?? ?? 84 C0 75 A6 32 C0 and others.
        
        // This, for some reason, does not exist as a siggable method in the game code normally. Virtually everyone and
        // everything that does minion checks will have this snippet (or one like it) in place. One does exist in the
        // crossref for the bitmask, but it's over in what I suspect is in the UI module and is bounded. I don't want to
        // replicate this upper bound here as that'll just be something we need to change with alarming regularity.
        
        return ((1 << ((int) companionId & 7)) & this.UnlockedCompanionsBitmask[companionId >> 3]) > 0;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 44 22 F0")]
    public static partial bool IsInstanceContentCompleted(uint instanceContentId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7C 24 ?? 3C")]
    public static partial bool IsInstanceContentUnlocked(uint instanceContentId);
}
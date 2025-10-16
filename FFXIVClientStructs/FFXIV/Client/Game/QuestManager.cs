using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::QuestManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1092)]
public unsafe partial struct QuestManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? C6 84 24", 3)]
    public static partial QuestManager* Instance();

    [FieldOffset(0x00)] private ushort Unk0;
    [FieldOffset(0x02)] private ushort Unk2;
    [FieldOffset(0x04)] private ushort Unk4;
    [FieldOffset(0x06)] private ushort Unk6;
    [FieldOffset(0x08)] private ushort Unk8;
    // [FieldOffset(0x0A)] array of 6 bytes?
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray30<QuestWork> _normalQuests;
    [FieldOffset(0x2E0), FixedSizeArray, Obsolete("Use CompletedQuestsBitArray")] internal FixedSizeArray751<byte> _completedQuestsBitmask;
    [FieldOffset(0x2E0), FixedSizeArray(isBitArray: true, bitCount: 751 * 8)] internal FixedSizeArray751<byte> _completedQuests; // BitCount: unknown, but we know the array is 751 bytes long
    [FieldOffset(0x5CF), FixedSizeArray, Obsolete("Use UnlockedMapMarkersBitArray")] internal FixedSizeArray64<byte> _unlockedMapMarkersBitmask;
    [FieldOffset(0x5CF), FixedSizeArray(isBitArray: true, bitCount: 64 * 8)] internal FixedSizeArray64<byte> _unlockedMapMarkers; // BitCount: unknown, but we know the array is 64 bytes long
    [FieldOffset(0x60F), FixedSizeArray, Obsolete("Use QuestRepeatFlags")] internal FixedSizeArray2<byte> _questRepeatFlagsBitmask;
    [FieldOffset(0x60F), FixedSizeArray(isBitArray: true, bitCount: 16)] internal FixedSizeArray2<byte> _questRepeatFlags; // BitCount: QuestRepeatFlagSheet.Count

    [FieldOffset(0x618), FixedSizeArray] internal FixedSizeArray12<DailyQuestWork> _dailyQuests;
    [FieldOffset(0x6D8)] public byte DailyQuestSeed;

    [FieldOffset(0x6DC), FixedSizeArray, Obsolete("Use CompletedLegacyQuestsBitArray")] internal FixedSizeArray40<byte> _unkBitmask1;
    [FieldOffset(0x6DC), FixedSizeArray(isBitArray: true, bitCount: 296 + 3 * 8)] internal FixedSizeArray40<byte> _completedLegacyQuests; // BitCount: at least LegacyQuestSheet.Count, might contain some relic stuff at the end?

    [FieldOffset(0x708), FixedSizeArray] internal FixedSizeArray10<TrackingWork> _trackedQuests;
    [FieldOffset(0x7A8)] private byte UnkJournalByte;
    [FieldOffset(0x7A9)] private byte UnkJournalWord; // QuestId?!

    // UnkArray2 and 3 are connected somehow. GatheringPoint related, or at least Spearfishing.
    // The setter split in 2 arrays, but a getter was found that contains the full size (255 bytes)... hmm
    [FieldOffset(0x7AC), FixedSizeArray, Obsolete("Use UnkArray2")] internal FixedSizeArray158<byte> _unkBitmask2;
    [FieldOffset(0x7AC), FixedSizeArray] internal FixedSizeArray158<byte> _unkArray2;

    [FieldOffset(0x84C), FixedSizeArray, Obsolete("Use UnkArray3")] internal FixedSizeArray94<byte> _unkBitmask3;
    [FieldOffset(0x84C), FixedSizeArray] internal FixedSizeArray94<byte> _unkArray3;

    [FieldOffset(0x8AC), FixedSizeArray, Obsolete("Use SeenGatheringNotebookDivisionLevelRangesBitArray")] internal FixedSizeArray40<byte> _seenGatheringNotebookDivisionLevelRangesBitmask;
    [FieldOffset(0x8AC), FixedSizeArray(isBitArray: true, bitCount: 40 * 8)] internal FixedSizeArray40<byte> _seenGatheringNotebookDivisionLevelRanges; // BitCount: unknown, but we know the array is 40 bytes long
    [FieldOffset(0x8D4), FixedSizeArray, Obsolete("Use GatheredGatheringItemsBitArray")] internal FixedSizeArray102<byte> _gatheredGatheringItemsBitmask;
    [FieldOffset(0x8D4), FixedSizeArray(isBitArray: true, bitCount: 102 * 8)] internal FixedSizeArray102<byte> _gatheredGatheringItems; // BitCount: unknown, but we know the array is 102 bytes long
    /// <remarks>Used for Actions with SecondaryCostType 9 (Brunt Force and Deep Vigor).</remarks>
    [FieldOffset(0x93A)] public byte SuccessfulGatheringChainCount;

    [FieldOffset(0x93C), FixedSizeArray, Obsolete("Use SeenCraftingNotebookDivisionLevelRangesBitArray")] internal FixedSizeArray72<byte> _seenCraftingNotebookDivisionLevelRangesBitmask;
    [FieldOffset(0x93C), FixedSizeArray(isBitArray: true, bitCount: 72 * 8)] internal FixedSizeArray72<byte> _seenCraftingNotebookDivisionLevelRanges; // BitCount: unknown, but we know the array is 72 bytes long
    [FieldOffset(0x98C), FixedSizeArray, Obsolete("Use CompletedRecipesBitArray")] internal FixedSizeArray801<byte> _completedRecipesBitmask;
    [FieldOffset(0x98C), FixedSizeArray(isBitArray: true, bitCount: 6407)] internal FixedSizeArray801<byte> _completedRecipes; // BitCount: RecipeSheet.Where(row => row.RowId < 30000).Max(row => row.RowId)

    [FieldOffset(0xCB0)] private uint UnkCB0;
    [FieldOffset(0xCB4)] private uint UnkCB4;
    [FieldOffset(0xCB8)] private uint UnkCB8;

    [FieldOffset(0xCE8), FixedSizeArray] internal FixedSizeArray20<BeastReputationWork> _beastReputation;
    [FieldOffset(0xE28), FixedSizeArray] internal FixedSizeArray16<LeveWork> _leveQuests;

    [FieldOffset(0xFA8)] public byte NumLeveAllowances;
    [FieldOffset(0xFA9)] private ushort UnkFA9;
    [FieldOffset(0xFAB)] private uint UnkFAB;
    [FieldOffset(0xFB0), FixedSizeArray, Obsolete("Use CompletedLeveQuestsBitArray")] internal FixedSizeArray226<byte> _completedLeveQuestsBitmask;
    [FieldOffset(0xFB0), FixedSizeArray(isBitArray: true, bitCount: 1808)] internal FixedSizeArray226<byte> _completedLeveQuests; // BitCount: LeveSheet.Count

    public byte NumAcceptedQuests {
        get {
            byte count = 0;
            foreach (ref var entry in NormalQuests)
                if (entry.QuestId != 0)
                    count++;
            return count;
        }
    }

    public byte NumAcceptedDailyQuests {
        get {
            byte count = 0;
            foreach (ref var entry in DailyQuests)
                if (entry.QuestId != 0)
                    count++;
            return count;
        }
    }

    public byte NumAcceptedLeveQuests {
        get {
            byte count = 0;
            foreach (ref var entry in LeveQuests)
                if (entry.LeveId != 0)
                    count++;
            return count;
        }
    }

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 84 2E")]
    public static partial bool IsQuestComplete(ushort questId);
    public static bool IsQuestComplete(uint questId) => IsQuestComplete((ushort)(questId & 0xFFFF));

    /**
     * Get the current step in a specific quest. Will return 0 if the quest is not active (even if the quest has been
     * completed prior).
     * <param name="questId">The quest ID to check.</param>
     * <returns>Returns a byte representing the current progression of the specified quest.</returns>
     */
    [MemberFunction("E8 ?? ?? ?? ?? 3A 43 06")]
    public static partial byte GetQuestSequence(ushort questId);

    /**
     * <inheritdoc cref="GetQuestSequence(ushort)"/>
     * <remarks>This is a helper method to handle trimming uints down to the game-requested ushort.</remarks>
     */
    public static byte GetQuestSequence(uint questId) => GetQuestSequence((ushort)(questId & 0xFFFF));

    /**
     * Checks if a specified quest has been accepted (and is active). This method does not check if the quest has been
     * completed or not.
     * <param name="questId">The quest ID to check.</param>
     * <returns>Returns <c>true</c> if the quest has been accepted, <c>false</c> otherwise.</returns>
     */
    [MemberFunction("45 33 C0 48 8D 41 18 66 39 10")]
    public partial bool IsQuestAccepted(ushort questId);

    /**
     * <inheritdoc cref="IsQuestAccepted(ushort)"/>
     * <remarks>This is a helper method to handle trimming uints down to the game-requested ushort.</remarks>
     */
    public bool IsQuestAccepted(uint questId) => IsQuestAccepted((ushort)(questId & 0xFFFF));

    /// <param name="questRepeatFlag">QuestRepeatFlag RowId / field from Quest sheet.</param>
    [MemberFunction("0F B6 C2 4C 8B C9")]
    public partial bool IsQuestRepeatFlagSet(byte questRepeatFlag);

    /// <summary>
    /// Check if a recipe has been crafted (= completed) before.
    /// </summary>
    /// <param name="recipeId">The RowId of the Recipe Sheet.</param>
    /// <returns>Returns <c>true</c> if the recipe has been completed, <c>false</c> otherwise.</returns>
    [MemberFunction("40 53 48 83 EC 20 8B D9 81 F9")]
    public static partial bool IsRecipeComplete(uint recipeId);

    /// <summary>
    /// Check if a GatheringItem has been gathered before.
    /// </summary>
    /// <param name="gatheringItemId">The RowId of the GatheringItem sheet.</param>
    /// <returns>Returns <c>true</c> if the item has been gathered before, <c>false</c> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 85 ?? ?? ?? ?? 41 BC ?? ?? ?? ?? B8")]
    public static partial bool IsGatheringItemGathered(ushort gatheringItemId);

    /// <summary>
    /// Check if a specific levequest has been completed.
    /// </summary>
    /// <param name="levequestId">The RowId of the Leve Sheet.</param>
    /// <returns>Returns <c>true</c> if the levequest has been completed, <c>false</c> otherwise.</returns>
    [MemberFunction("44 0F B7 C2 4C 8B C9 49 C1 E8 03")]
    public partial bool IsLevequestComplete(ushort levequestId);

    /// <summary>
    /// Get the time when the player will receive new leve allowances.
    /// </summary>
    /// <remarks>
    /// Has to be multiplied by 60 for a unix timestamp.<br/>
    /// Use <see cref="GetNextLeveAllowancesUnixTimestamp"/> or <see cref="GetNextLeveAllowancesDateTime"/> instead.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 41 8D 44 24")]
    private static partial int GetNextLeveAllowancesTimestamp();

    /// <summary>
    /// Get the time when the player will receive new leve allowances.
    /// </summary>
    /// <returns>A unix timestamp as <see cref="int"/>.</returns>
    public static int GetNextLeveAllowancesUnixTimestamp() => GetNextLeveAllowancesTimestamp() * 60;

    /// <summary>
    /// Get the time when the player will receive new leve allowances.
    /// </summary>
    /// <returns>A <see cref="DateTime"/> in the local time zone.</returns>
    public static DateTime GetNextLeveAllowancesDateTime() => DateTime.UnixEpoch.AddSeconds(GetNextLeveAllowancesUnixTimestamp()).ToLocalTime();

    [MemberFunction("33 C0 4C 8B C1 66 39 81 ?? ?? ?? ?? 0F 94 C0")]
    public partial uint GetBeastTribeAllowance();

    public bool IsDailyQuestCompleted(ushort questId) {
        var quest = GetDailyQuestById(questId);
        return quest != null && (quest->Flags & 1) != 0;
    }

    public QuestWork* GetQuestById(ushort questId) {
        var span = NormalQuests;
        for (var i = 0; i < span.Length; i++) {
            if (span[i].QuestId == questId)
                return (QuestWork*)Unsafe.AsPointer(ref span[i]);
        }
        return null;
    }

    public DailyQuestWork* GetDailyQuestById(ushort questId) {
        var span = DailyQuests;
        for (var i = 0; i < span.Length; i++) {
            if (span[i].QuestId == questId)
                return (DailyQuestWork*)Unsafe.AsPointer(ref span[i]);
        }
        return null;
    }

    public LeveWork* GetLeveQuestById(ushort leveId) {
        var span = LeveQuests;
        for (var i = 0; i < span.Length; i++) {
            if (span[i].LeveId == leveId)
                return (LeveWork*)Unsafe.AsPointer(ref span[i]);
        }
        return null;
    }

    public BeastReputationWork* GetBeastReputationById(uint beastTribeId) {
        var index = beastTribeId - 1;
        var span = BeastReputation;
        if (index >= span.Length) return null;
        return (BeastReputationWork*)Unsafe.AsPointer(ref span[(int)index]);
    }
}

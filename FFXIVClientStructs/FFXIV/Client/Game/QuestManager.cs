using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::QuestManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1042)]
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
    [FieldOffset(0x2E0), FixedSizeArray] internal FixedSizeArray691<byte> _completedQuestsBitmask;
    [FieldOffset(0x593), FixedSizeArray] internal FixedSizeArray64<byte> _unlockedMapMarkersBitmask;
    [FieldOffset(0x5D3), FixedSizeArray] internal FixedSizeArray2<byte> _questRepeatFlagsBitmask;

    [FieldOffset(0x5D8), FixedSizeArray] internal FixedSizeArray12<DailyQuestWork> _dailyQuests;
    [FieldOffset(0x698)] public byte DailyQuestSeed;

    [FieldOffset(0x69C), FixedSizeArray] internal FixedSizeArray40<byte> _unkBitmask1;

    [FieldOffset(0x6C8), FixedSizeArray] internal FixedSizeArray10<TrackingWork> _trackedQuests;
    [FieldOffset(0x768)] private byte UnkJournalByte;
    [FieldOffset(0x76A)] private byte UnkJournalWord; // QuestId?!

    [FieldOffset(0x76C), FixedSizeArray] internal FixedSizeArray158<byte> _unkBitmask2;

    [FieldOffset(0x80C), FixedSizeArray] internal FixedSizeArray94<byte> _unkBitmask3;

    [FieldOffset(0x86C), FixedSizeArray] internal FixedSizeArray40<byte> _seenGatheringNotebookDivisionLevelRangesBitmask;
    [FieldOffset(0x894), FixedSizeArray] internal FixedSizeArray102<byte> _gatheredGatheringItemsBitmask;
    /// <remarks>Used for Actions with SecondaryCostType 9 (Brunt Force and Deep Vigor).</remarks>
    [FieldOffset(0x8FA)] public byte SuccessfulGatheringChainCount;

    [FieldOffset(0x8FC), FixedSizeArray] internal FixedSizeArray72<byte> _seenCraftingNotebookDivisionLevelRangesBitmask;
    [FieldOffset(0x94C), FixedSizeArray] internal FixedSizeArray800<byte> _completedRecipesBitmask;

    [FieldOffset(0xC70)] private uint UnkC70;
    [FieldOffset(0xC74)] private uint UnkC74;
    [FieldOffset(0xC78)] private uint UnkC78;

    [FieldOffset(0xCA8), FixedSizeArray] internal FixedSizeArray19<BeastReputationWork> _beastReputation;
    [FieldOffset(0xDD8), FixedSizeArray] internal FixedSizeArray16<LeveWork> _leveQuests;

    [FieldOffset(0xF58)] public byte NumLeveAllowances;
    [FieldOffset(0xF59)] private ushort UnkF49;
    [FieldOffset(0xF5B)] private uint UnkF4C;
    [FieldOffset(0xF60), FixedSizeArray] internal FixedSizeArray226<byte> _completedLeveQuestsBitmask;

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

    [MemberFunction("E8 ?? ?? ?? ?? 43 88 84 3E ?? ?? ?? ??")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 88 87 ?? ?? ?? ?? B8")]
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
    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 74 24 ?? 8B D8")]
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

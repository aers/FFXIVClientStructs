using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// idk if this is a manager, but I don't know what else to call it
[StructLayout(LayoutKind.Explicit, Size = 0xF40)]
public unsafe partial struct QuestManager {
    [Obsolete("Use NormalQuestsSpan")]
    [FieldOffset(0x10)] public QuestListArray Quest;

    [FixedSizeArray<QuestWork>(30)]
    [FieldOffset(0x10)] public fixed byte NormalQuests[0x18 * 30];
    [FixedSizeArray<DailyQuestWork>(12)]
    [FieldOffset(0x5B8)] public fixed byte DailyQuests[0x10 * 12];
    [FixedSizeArray<TrackingWork>(5)]
    [FieldOffset(0x6A8)] public fixed byte TrackedQuests[0x10 * 5];
    [FixedSizeArray<BeastReputationWork>(17)]
    [FieldOffset(0xBC8)] public fixed byte BeastReputation[0x10 * 17];
    [FixedSizeArray<LeveWork>(16)]
    [FieldOffset(0xCD8)] public fixed byte LeveQuests[0x18 * 16];
    [FieldOffset(0xE58)] public byte NumLeveAllowances;

    [FieldOffset(0xF40)] public byte NumAcceptedQuests;
    [FieldOffset(0xF50)] public byte NumAcceptedLeveQuests;

    [MemberFunction("E8 ?? ?? ?? ?? 66 BA 10 0C")]
    public static partial QuestManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 84 2C")]
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
     * <inheritdoc cref="QuestManager.GetQuestSequence(ushort)"/>
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
     * <inheritdoc cref="QuestManager.IsQuestAccepted(ushort)"/>
     * <remarks>This is a helper method to handle trimming uints down to the game-requested ushort.</remarks>
     */
    public bool IsQuestAccepted(uint questId) => this.IsQuestAccepted((ushort)(questId & 0xFFFF));

    /// <summary>
    /// Check if a specific levequest has been completed.
    /// </summary>
    /// <param name="levequestId">The RowId of the Leve Sheet.</param>
    /// <returns>Returns <c>true</c> if the levequest has been completed, <c>false</c> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 88 45 80")]
    public partial bool IsLevequestComplete(ushort levequestId);

    /// <summary>
    /// Get the time when the player will receive new leve allowances.
    /// </summary>
    /// <remarks>
    /// Has to be multiplied by 60 for a unix timestamp.<br/>
    /// Use <see cref="GetNextLeveAllowancesUnixTimestamp"/> or <see cref="GetNextLeveAllowancesDateTime"/> instead.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 75 01")]
    private static partial uint GetNextLeveAllowancesTimestamp();

    /// <summary>
    /// Get the time when the player will receive new leve allowances.
    /// </summary>
    /// <returns>A unix timestamp as <see cref="uint"/>.</returns>
    public static uint GetNextLeveAllowancesUnixTimestamp() => GetNextLeveAllowancesTimestamp() * 60;

    /// <summary>
    /// Get the time when the player will receive new leve allowances.
    /// </summary>
    /// <returns>A <see cref="DateTime"/> in the local time zone.</returns>
    public static DateTime GetNextLeveAllowancesDateTime() => DateTime.UnixEpoch.AddSeconds(GetNextLeveAllowancesUnixTimestamp()).ToLocalTime();

    [MemberFunction("45 33 C9 48 81 C1 ?? ?? ?? ?? 45 8D 51 02")]
    public partial uint GetBeastTribeAllowance();

    public bool IsDailyQuestCompleted(ushort questId) {
        var quest = GetDailyQuestById(questId);
        return quest != null && (quest->Flags & 1) != 0;
    }

    public QuestWork* GetQuestById(ushort questId) {
        var span = NormalQuestsSpan;
        for (var i = 0; i < span.Length; i++) {
            if (span[i].QuestId == questId)
                return (QuestWork*)Unsafe.AsPointer(ref span[i]);
        }
        return null;
    }

    public DailyQuestWork* GetDailyQuestById(ushort questId) {
        var span = DailyQuestsSpan;
        for (var i = 0; i < span.Length; i++) {
            if (span[i].QuestId == questId)
                return (DailyQuestWork*)Unsafe.AsPointer(ref span[i]);
        }
        return null;
    }

    public LeveWork* GetLeveQuestById(ushort leveId) {
        var span = LeveQuestsSpan;
        for (var i = 0; i < span.Length; i++) {
            if (span[i].LeveId == leveId)
                return (LeveWork*)Unsafe.AsPointer(ref span[i]);
        }
        return null;
    }

    public BeastReputationWork* GetBeastReputationById(uint beastTribeId) {
        var index = beastTribeId - 1;
        var span = BeastReputationSpan;
        if (index >= span.Length) return null;
        return (BeastReputationWork*)Unsafe.AsPointer(ref span[(int)index]);
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct QuestListArray {
        [FieldOffset(0x00)] private fixed byte data[0x18 * 30];

        public Quest* this[int index] {
            get {
                if (index < 0 || index > 30) return null;

                fixed (byte* pointer = data) {
                    return (Quest*)(pointer + sizeof(Quest) * index);
                }
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct Quest {
            [FieldOffset(0x08)] public ushort QuestID;
            [FieldOffset(0x0B)] public QuestFlags Flags; // 1 for Priority, 8 for Hidden

            public bool IsHidden => Flags.HasFlag(QuestFlags.Hidden);

            [Flags]
            public enum QuestFlags : byte {
                None,
                Priority,
                Hidden = 0x8
            }
        }
    }
}

using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct DailyQuestMap {
    [FieldOffset(0)]
    public StdMap<uint, Entry> Entries; // key = quest giver BaseId

    // both 'handlers' vectors are sorted by quest id
    // where the handler ends up depends on DailyQuestPool column - quests with value 3 are in 'exclusive' pool
    // if player outranks the rank requirements (rank > RankRequirementMax), these pools are effectively combined
    // however, otherwise exactly 1 quest is picked from 'exclusive' pool (assuming there's an eligible one), others are picked from normal pool
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct Entry {
        [FieldOffset(0x00)] public byte TribeId;
        [FieldOffset(0x01)] public byte RankRequirementMin;
        [FieldOffset(0x02)] public byte RankRequirementMax;
        [FieldOffset(0x08)] public StdVector<Pointer<QuestEventHandler>> HandlersExclusive;
        [FieldOffset(0x20)] public StdVector<Pointer<QuestEventHandler>> HandlersNormal;
        [FieldOffset(0x38)] public bool Dirty;
    }

    /// <summary>
    /// Calculate a set of daily quests offered by the specified questgiver.
    /// </summary>
    /// <param name="player">Player character, isn't actually used by the function.</param>
    /// <param name="iterator">Iterator (node pointer) to the questgiver entry.</param>
    /// <param name="seed">Pseudo-random seed.</param>
    /// <param name="rankInRange">Whether player's current rank is greater than largest min rank requirement (this determines how quests from exclusive pool are picked).</param>
    /// <param name="rank">Player's current rank.</param>
    /// <param name="rankExactMatch">True if it should only consider quests matching player's rank exactly (game uses this on the day player ranks up).</param>
    /// <param name="outResult">Storage for the results. Should have enough space for 3 pointers!</param>
    /// <returns>Number of found available quests.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 40 88 7D 90 48 8B D8")]
    public partial long CalculateAvailableQuests(Character.Character* player, RedBlackTree<StdPair<uint, Entry>, uint, PairKeyExtractor<uint, Entry>>.Node* iterator, byte seed, bool rankInRange, byte rank, bool rankExactMatch, QuestEventHandler** outResult);
}

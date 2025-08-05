namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PvPProfile
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8C)]
public unsafe partial struct PvPProfile {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 3C ?? 0F 84 ?? ?? ?? ?? 48 85 DB", 3)]
    public static partial PvPProfile* Instance();

    [FieldOffset(0x0)] public bool IsLoaded;

    [FieldOffset(0x4)] public uint ExperienceMaelstrom;
    [FieldOffset(0x8)] public uint ExperienceTwinAdder;
    [FieldOffset(0xC)] public uint ExperienceImmortalFlames;
    [FieldOffset(0x10)] public byte RankMaelstrom;
    [FieldOffset(0x11)] public byte RankTwinAdder;
    [FieldOffset(0x12)] public byte RankImmortalFlames;

    [FieldOffset(0x24)] public byte Series;
    [FieldOffset(0x25)] public byte SeriesCurrentRank;
    [FieldOffset(0x26)] public byte SeriesClaimedRank;

    [FieldOffset(0x28)] public ushort SeriesExperience;
    [FieldOffset(0x2A)] public byte PreviousSeriesClaimedRank;
    [FieldOffset(0x2B)] public byte PreviousSeriesRank;
    [FieldOffset(0x2C)] public uint FrontlineTotalMatches;
    [FieldOffset(0x30)] public uint FrontlineTotalFirstPlace;
    [FieldOffset(0x34)] public uint FrontlineTotalSecondPlace;
    [FieldOffset(0x38)] public uint FrontlineTotalThirdPlace;
    [FieldOffset(0x3C)] public ushort FrontlineWeeklyMatches;
    [FieldOffset(0x3E)] public ushort FrontlineWeeklyFirstPlace;
    [FieldOffset(0x40)] public ushort FrontlineWeeklySecondPlace;
    [FieldOffset(0x42)] public ushort FrontlineWeeklyThirdPlace;

    [FieldOffset(0x4D)] public byte CrystallineConflictSeason;
    [FieldOffset(0x4E)] public ushort CrystallineConflictCasualMatches;
    [FieldOffset(0x50)] public ushort CrystallineConflictCasualMatchesWon;
    [FieldOffset(0x52)] public ushort CrystallineConflictRankedMatches;
    [FieldOffset(0x54)] public ushort CrystallineConflictRankedMatchesWon;
    // TODO: 7.3 - these shifted somewhere. gotta play to find them
    [FieldOffset(0x52), Obsolete("Offset not updated for 7.3")] public ushort CrystallineConflictCurrentCrystalCredit;
    [FieldOffset(0x54), Obsolete("Offset not updated for 7.3")] public ushort CrystallineConflictHighestCrystalCredit;

    [FieldOffset(0x58), Obsolete("Offset not updated for 7.3")] public byte CrystallineConflictCurrentRank;
    [FieldOffset(0x59), Obsolete("Offset not updated for 7.3")] public byte CrystallineConflictHighestRank;
    [FieldOffset(0x5A), Obsolete("Offset not updated for 7.3")] public byte CrystallineConflictCurrentRiser;
    [FieldOffset(0x5B), Obsolete("Offset not updated for 7.3")] public byte CrystallineConflictHighestRiser;
    [FieldOffset(0x5C), Obsolete("Offset not updated for 7.3")] public byte CrystallineConflictCurrentRisingStars;
    [FieldOffset(0x5D), Obsolete("Offset not updated for 7.3")] public byte CrystallineConflictHighestRisingStars;
    // TODO: 7.3 - /these shifted somewhere. gotta play to find them

    [FieldOffset(0x7C)] public uint RivalWingsTotalMatches;
    [FieldOffset(0x80)] public uint RivalWingsTotalMatchesWon;
    [FieldOffset(0x84)] public uint RivalWingsWeeklyMatches;
    [FieldOffset(0x88)] public uint RivalWingsWeeklyMatchesWon;

    /// <summary>Gets the current PvP rank for the active Grand Company.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 3A 47 4F")]
    public partial byte GetPvPRank();

    /// <summary>Gets the total accumulated PvP experience for the active Grand Company.</summary>
    [MemberFunction("0F B6 05 ?? ?? ?? ?? FE C8 3C 02 77 08")]
    public partial uint GetPvPTotalExperience();

    /// <summary>Gets the experience for the current PvP rank for the active Grand Company.</summary>
    [MemberFunction("40 53 48 83 EC 20 0F B6 05 ?? ?? ?? ?? 48 8B D9 FE C8")]
    public partial uint GetPvPCurrentRankExperience();

    /// <summary>Gets the needed experience for the current PvP rank for the active Grand Company.</summary>
    [MemberFunction("48 83 EC 28 0F B6 05 ?? ?? ?? ?? FE C8")]
    public partial uint GetPvPCurrentRankNeededExperience();

    /// <summary>Gets the current PvP Series rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 8D ?? ?? ?? ?? 0F B6 D0")]
    public partial byte GetSeriesCurrentRank();

    /// <summary>Gets the claimed PvP Series rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 FF C0 3B D8")]
    public partial byte GetSeriesClaimedRank();

    /// <summary>Gets the current PvP Series rank experience.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 F8 BA ?? ?? ?? ?? 44 8B C7")]
    public partial ushort GetSeriesExperience();

    /// <summary>Returns whether the player had a rank last PvP Series.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 4F ?? 0F B6 F0 ?? ?? ?? 41 FF 52")]
    public partial bool HasPreviousSeriesRank();

    /// <summary>Gets the previous PvP Series achieved rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D8 EB ?? BA")]
    public partial byte GetPreviousSeriesRank();

    /// <summary>Gets the previous PvP Series claimed rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 54 24 ?? 0F B6 D8 49 8D 4E 50")]
    public partial byte GetPreviousSeriesClaimedRank();
}

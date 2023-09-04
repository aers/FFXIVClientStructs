namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x7C)]
public unsafe partial struct PvPProfile {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 43 08", 3)]
    public static partial PvPProfile* Instance();

    [FieldOffset(0x0)] public byte IsLoaded;

    [FieldOffset(0x4)] public uint ExperienceMaelstrom;
    [FieldOffset(0x8)] public uint ExperienceTwinAdder;
    [FieldOffset(0xC)] public uint ExperienceImmortalFlames;
    [FieldOffset(0x10)] public byte RankMaelstrom;
    [FieldOffset(0x11)] public byte RankTwinAdder;
    [FieldOffset(0x12)] public byte RankImmortalFlames;

    [FieldOffset(0x1E)] public byte Series;
    [FieldOffset(0x1F)] public byte SeriesCurrentRank;
    [FieldOffset(0x20)] public byte SeriesClaimedRank;

    [FieldOffset(0x22)] public ushort SeriesExperience;
    [FieldOffset(0x24)] public byte PreviousSeriesClaimedRank;
    [FieldOffset(0x25)] public byte PreviousSeriesRank;

    [FieldOffset(0x28)] public uint FrontlineTotalMatches;
    [FieldOffset(0x2C)] public uint FrontlineTotalFirstPlace;
    [FieldOffset(0x30)] public uint FrontlineTotalSecondPlace;
    [FieldOffset(0x34)] public uint FrontlineTotalThirdPlace;
    [FieldOffset(0x38)] public ushort FrontlineWeeklyMatches;
    [FieldOffset(0x3A)] public ushort FrontlineWeeklyFirstPlace;
    [FieldOffset(0x3C)] public ushort FrontlineWeeklySecondPlace;
    [FieldOffset(0x3E)] public ushort FrontlineWeeklyThirdPlace;

    [FieldOffset(0x41)] public byte CrystallineConflictSeason;
    [FieldOffset(0x42)] public ushort CrystallineConflictCasualMatches;
    [FieldOffset(0x44)] public ushort CrystallineConflictCasualMatchesWon;
    [FieldOffset(0x46)] public ushort CrystallineConflictRankedMatches;
    [FieldOffset(0x48)] public ushort CrystallineConflictRankedMatchesWon;

    [FieldOffset(0x4E)] public ushort CrystallineConflictCurrentCrystalCredit;
    [FieldOffset(0x50)] public ushort CrystallineConflictHighestCrystalCredit;

    [FieldOffset(0x54)] public byte CrystallineConflictCurrentRank;
    [FieldOffset(0x55)] public byte CrystallineConflictHighestRank;
    [FieldOffset(0x56)] public byte CrystallineConflictCurrentRiser;
    [FieldOffset(0x57)] public byte CrystallineConflictHighestRiser;
    [FieldOffset(0x58)] public byte CrystallineConflictCurrentRisingStars;
    [FieldOffset(0x59)] public byte CrystallineConflictHighestRisingStars;

    [FieldOffset(0x6C)] public uint RivalWingsTotalMatches;
    [FieldOffset(0x70)] public uint RivalWingsTotalMatchesWon;
    [FieldOffset(0x74)] public uint RivalWingsWeeklyMatches;
    [FieldOffset(0x78)] public uint RivalWingsWeeklyMatchesWon;

    /// <summary>Gets the current PvP rank for the active Grand Company.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 3A 46 4F")]
    public partial byte GetPvPRank();

    /// <summary>Gets the total accumulated PvP experience for the active Grand Company.</summary>
    [MemberFunction("0F B6 15 ?? ?? ?? ?? 8D 42 FF 3C 02 77 0F")]
    public partial uint GetPvPTotalExperience();

    /// <summary>Gets the experience for the current PvP rank for the active Grand Company.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B CC 8B F0")]
    public partial uint GetPvPCurrentRankExperience();

    /// <summary>Gets the needed experience for the current PvP rank for the active Grand Company.</summary>
    [MemberFunction("0F B6 15 ?? ?? ?? ?? 8D 42 FF 3C 02 77 07")]
    public partial uint GetPvPCurrentRankNeededExperience();

    /// <summary>Gets the current PvP Series rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 F0 8B FE")]
    public partial byte GetSeriesCurrentRank();

    /// <summary>Gets the claimed PvP Series rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 FF C0 3B D8")]
    public partial byte GetSeriesClaimedRank();

    /// <summary>Gets the current PvP Series rank experience.</summary>
    [MemberFunction("0F B7 41 22 C3 CC")]
    public partial ushort GetSeriesExperience();

    /// <summary>Returns whether the player had a rank last PvP Series.</summary>
    [MemberFunction("80 79 24 00 0F 95 C0")]
    public partial bool HasPreviousSeriesRank();

    /// <summary>Gets the previous PvP Series achieved rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB 05 E8 ?? ?? ?? ?? 0F B6 C0")]
    public partial byte GetPreviousSeriesRank();

    /// <summary>Gets the previous PvP Series claimed rank.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 F8 EB 02 33 FF BA ?? ?? ?? ?? 49 8D 4E 50")]
    public partial byte GetPreviousSeriesClaimedRank();
}

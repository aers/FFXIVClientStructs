namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::FashionCheckManager
// Fashion Report
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct FashionCheckManager {
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D3 48 8B C8 E8 ?? ?? ?? ?? 48 8B D7")]
    public static partial FashionCheckManager* Instance();

    [FieldOffset(0x00)] public PlayerInfoData PlayerInfo;
    [FieldOffset(0x08)] public ThemeData Theme;
    [FieldOffset(0x20)] public EquipEvaluationData EquipEvaluations;
    [FieldOffset(0x30)] public HighScoreData HighScore;
    [FieldOffset(0x80)] public PreviewData Preview;
    [FieldOffset(0xA0)] public bool IsCommandSent;
    [FieldOffset(0xA1)] public bool IsInfoRequested;
    [FieldOffset(0xA2)] public bool IsCustomTalkActive;

    [StructLayout(LayoutKind.Explicit, Size = 0x8, Pack = 8)]
    public struct PlayerInfoData {
        [FieldOffset(0x00)] public byte Score;
        [FieldOffset(0x01)] public byte Remaining;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x18, Pack = 8)]
    public partial struct ThemeData {
        /// <remarks> FashionCheckWeeklyTheme RowId </remarks>
        [FieldOffset(0x00)] public ushort WeeklyTheme;
        /// <remarks> FashionCheckThemeCategory RowIds </remarks>
        [FieldOffset(0x02), FixedSizeArray] internal FixedSizeArray11<ushort> _itemThemes;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10, Pack = 8)]
    public partial struct EquipEvaluationData {
        [FieldOffset(0x00)] public byte Score;
        [FieldOffset(0x01), FixedSizeArray] internal FixedSizeArray11<byte> _itemEvaluations;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x50, Pack = 8)]
    public partial struct HighScoreData {
        [FieldOffset(0x00)] public byte Score;
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray11<uint> _itemIds;
        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
        [FieldOffset(0x34), FixedSizeArray] internal FixedSizeArray6<byte> _stain0Ids;
        [FieldOffset(0x3A), FixedSizeArray] internal FixedSizeArray6<byte> _stain1Ids;
        [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray11<byte> _itemEvaluations;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x20, Pack = 8)]
    public partial struct PreviewData {
        [FieldOffset(0x00)] public byte Score;
        [FieldOffset(0x01)] public byte Remaining;
        /// <remarks> FashionCheckWeeklyTheme RowId </remarks>
        [FieldOffset(0x02)] public ushort WeeklyTheme;
        /// <remarks> FashionCheckThemeCategory RowIds </remarks>
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray11<ushort> _itemThemes;
    }
}

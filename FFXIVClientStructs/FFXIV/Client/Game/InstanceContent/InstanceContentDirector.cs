namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentDirector
//   Client::Game::InstanceContent::ContentDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<ContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F98)]
public unsafe partial struct InstanceContentDirector {
    [FieldOffset(0xD30 + 0x00), CExporterExcelBegin("InstanceContent")] public uint NewPlayerBonusGil;
    [FieldOffset(0xD30 + 0x04)] public uint NewPlayerBonusExp;
    [FieldOffset(0xD30 + 0x08)] public uint FinalBossExp;
    [FieldOffset(0xD30 + 0x0C)] private uint Unknown0;
    [FieldOffset(0xD30 + 0x10)] public uint BossExp0;
    [FieldOffset(0xD30 + 0x14)] public uint BossExp1;
    [FieldOffset(0xD30 + 0x18)] public uint BossExp2;
    [FieldOffset(0xD30 + 0x1C)] public uint BossExp3;
    [FieldOffset(0xD30 + 0x20)] public uint BossExp4;
    [FieldOffset(0xD30 + 0x24)] public uint InstanceClearExp;
    [FieldOffset(0xD30 + 0x28)] public uint InstanceClearGil;
    [FieldOffset(0xD30 + 0x2C)] public uint InstanceContentRewardItem;
    [FieldOffset(0xD30 + 0x30)] public ushort NewPlayerBonusA;
    [FieldOffset(0xD30 + 0x32)] public ushort NewPlayerBonusB;
    [FieldOffset(0xD30 + 0x34)] public ushort FinalBossCurrencyA;
    [FieldOffset(0xD30 + 0x36)] public ushort FinalBossCurrencyB;
    [FieldOffset(0xD30 + 0x38)] public ushort FinalBossCurrencyC;
    [FieldOffset(0xD30 + 0x3A)] public ushort BossCurrencyA0;
    [FieldOffset(0xD30 + 0x3C)] public ushort BossCurrencyA1;
    [FieldOffset(0xD30 + 0x3E)] public ushort BossCurrencyA2;
    [FieldOffset(0xD30 + 0x40)] public ushort BossCurrencyA3;
    [FieldOffset(0xD30 + 0x42)] public ushort BossCurrencyA4;
    [FieldOffset(0xD30 + 0x44)] public ushort BossCurrencyB0;
    [FieldOffset(0xD30 + 0x46)] public ushort BossCurrencyB1;
    [FieldOffset(0xD30 + 0x48)] public ushort BossCurrencyB2;
    [FieldOffset(0xD30 + 0x4A)] public ushort BossCurrencyB3;
    [FieldOffset(0xD30 + 0x4C)] public ushort BossCurrencyB4;
    [FieldOffset(0xD30 + 0x4E)] public ushort BossCurrencyC0;
    [FieldOffset(0xD30 + 0x50)] public ushort BossCurrencyC1;
    [FieldOffset(0xD30 + 0x52)] public ushort BossCurrencyC2;
    [FieldOffset(0xD30 + 0x54)] public ushort BossCurrencyC3;
    [FieldOffset(0xD30 + 0x56)] public ushort BossCurrencyC4;
    [FieldOffset(0xD30 + 0x58)] private ushort Unknown1;
    [FieldOffset(0xD30 + 0x5A)] private byte Unknown20;
    [FieldOffset(0xD30 + 0x5C)] public uint Cutscene;
    [FieldOffset(0xD30 + 0x60)] public uint LGBEventRange;
    [FieldOffset(0xD30 + 0x64)] public uint InstanceContentTextDataBossStart;
    [FieldOffset(0xD30 + 0x68)] public uint InstanceContentTextDataBossEnd;
    [FieldOffset(0xD30 + 0x6C)] public uint BNpcBaseBoss;
    [FieldOffset(0xD30 + 0x70)] public uint InstanceContentTextDataObjectiveStart;
    [FieldOffset(0xD30 + 0x74)] public uint InstanceContentTextDataObjectiveEnd;
    [FieldOffset(0xD30 + 0x78)] private uint Unknown2;
    [FieldOffset(0xD30 + 0x7C)] public uint ReqInstance;
    [FieldOffset(0xD30 + 0x80)] public int InstanceContentBuff;
    /// <summary>
    /// This field is stored in minutes
    /// </summary>
    [FieldOffset(0xD30 + 0x84)] public ushort ContentTimeMax; // TimeLimitmin
    [FieldOffset(0xD30 + 0x86)] public ushort BGM;
    [FieldOffset(0xD30 + 0x88)] public ushort WinBGM;
    [FieldOffset(0xD30 + 0x8A)] public ushort Order;
    [FieldOffset(0xD30 + 0x8C)] public ushort SortKey;
    [FieldOffset(0xD30 + 0x8E)] private ushort Unknown3;
    [FieldOffset(0xD30 + 0x90)] private ushort Unknown4;
    [FieldOffset(0xD30 + 0x92)] private ushort Unknown5;
    [FieldOffset(0xD30 + 0x94)] private ushort Unknown6;
    [FieldOffset(0xD30 + 0x96)] private ushort Unknown7;
    [FieldOffset(0xD30 + 0x98)] private ushort Unknown8;
    [FieldOffset(0xD30 + 0x9A)] private ushort Unknown_70;
    [FieldOffset(0xD30 + 0x9C)] public short PartyCondition;
    [FieldOffset(0xD30 + 0x9E), CExporterForce] public InstanceContentType InstanceContentType;
    [FieldOffset(0xD30 + 0x9F)] public byte WeekRestriction;
    [FieldOffset(0xD30 + 0xA0)] public byte Colosseum;
    [FieldOffset(0xD30 + 0xA1)] private byte Unknown9;
    [FieldOffset(0xD30 + 0xA2)] private byte Unknown10;
    [FieldOffset(0xD30 + 0xA3)] private byte Unknown11;
    [FieldOffset(0xD30 + 0xA4)] private byte Unknown12;
    [FieldOffset(0xD30 + 0xA5)] private byte Unknown19;
    [FieldOffset(0xD30 + 0xA6)] private byte Unknown13;
    [FieldOffset(0xD30 + 0xA7), CExporterExcelEnd] private byte Unknown14_Unknown15_Unknown16_Unknown17_Unknown18;

    [FieldOffset(0xDE0)] public ContentDirector.MapEffectList ManagedSharedGroups;
}

public enum InstanceContentType : byte {
    Raid = 1,
    Dungeon = 2,
    GuildOrder = 3, // Guildhests
    Trial = 4,
    CrystallineConflict = 5,
    Frontlines = 6,
    QuestBattle = 7,
    BeginnerTraining = 8,
    DeepDungeon = 9,
    TreasureHuntDungeon = 10,
    SeasonalDungeon = 11,
    RivalWing = 12,
    MaskedCarnivale = 13,
    Mahjong = 14,
    GoldSaucer = 15, // only used for Air Force One in Gold Saucer
    OceanFishing = 16,
    UnrealTrial = 17,
    TripleTriad = 18,
    VariantDungeon = 19,
    CriterionDungeon = 20
}

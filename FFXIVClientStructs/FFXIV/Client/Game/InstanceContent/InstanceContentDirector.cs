namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::InstanceContentDirector
//   Client::Game::InstanceContent::ContentDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<ContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x1FF0)]
public unsafe partial struct InstanceContentDirector {
    //[FieldOffset(0x738), FixedSizeArray] internal FixedSizeArray168<byte> _instanceContentExcelRow;

    [FieldOffset(0xD88 + 0x00), CExporterExcelBegin("InstanceContent")] public uint NewPlayerBonusGil;
    [FieldOffset(0xD88 + 0x04)] public uint NewPlayerBonusExp;
    [FieldOffset(0xD88 + 0x08)] public uint FinalBossExp;
    [FieldOffset(0xD88 + 0x0C)] public uint Unknown0;
    [FieldOffset(0xD88 + 0x10)] public uint BossExp0;
    [FieldOffset(0xD88 + 0x14)] public uint BossExp1;
    [FieldOffset(0xD88 + 0x18)] public uint BossExp2;
    [FieldOffset(0xD88 + 0x1C)] public uint BossExp3;
    [FieldOffset(0xD88 + 0x20)] public uint BossExp4;
    [FieldOffset(0xD88 + 0x24)] public uint InstanceClearExp;
    [FieldOffset(0xD88 + 0x28)] public uint InstanceClearGil;
    [FieldOffset(0xD88 + 0x2C)] public uint InstanceContentRewardItem;
    [FieldOffset(0xD88 + 0x30)] public ushort NewPlayerBonusA;
    [FieldOffset(0xD88 + 0x32)] public ushort NewPlayerBonusB;
    [FieldOffset(0xD88 + 0x34)] public ushort FinalBossCurrencyA;
    [FieldOffset(0xD88 + 0x36)] public ushort FinalBossCurrencyB;
    [FieldOffset(0xD88 + 0x38)] public ushort FinalBossCurrencyC;
    [FieldOffset(0xD88 + 0x3A)] public ushort BossCurrencyA0;
    [FieldOffset(0xD88 + 0x3C)] public ushort BossCurrencyA1;
    [FieldOffset(0xD88 + 0x3E)] public ushort BossCurrencyA2;
    [FieldOffset(0xD88 + 0x40)] public ushort BossCurrencyA3;
    [FieldOffset(0xD88 + 0x42)] public ushort BossCurrencyA4;
    [FieldOffset(0xD88 + 0x44)] public ushort BossCurrencyB0;
    [FieldOffset(0xD88 + 0x46)] public ushort BossCurrencyB1;
    [FieldOffset(0xD88 + 0x48)] public ushort BossCurrencyB2;
    [FieldOffset(0xD88 + 0x4A)] public ushort BossCurrencyB3;
    [FieldOffset(0xD88 + 0x4C)] public ushort BossCurrencyB4;
    [FieldOffset(0xD88 + 0x4E)] public ushort BossCurrencyC0;
    [FieldOffset(0xD88 + 0x50)] public ushort BossCurrencyC1;
    [FieldOffset(0xD88 + 0x52)] public ushort BossCurrencyC2;
    [FieldOffset(0xD88 + 0x54)] public ushort BossCurrencyC3;
    [FieldOffset(0xD88 + 0x56)] public ushort BossCurrencyC4;
    [FieldOffset(0xD88 + 0x58)] public ushort Unknown1;
    [FieldOffset(0xD88 + 0x5A)] public byte Unknown20;
    [FieldOffset(0xD88 + 0x5C)] public uint Cutscene;
    [FieldOffset(0xD88 + 0x60)] public uint LGBEventRange;
    [FieldOffset(0xD88 + 0x64)] public uint InstanceContentTextDataBossStart;
    [FieldOffset(0xD88 + 0x68)] public uint InstanceContentTextDataBossEnd;
    [FieldOffset(0xD88 + 0x6C)] public uint BNpcBaseBoss;
    [FieldOffset(0xD88 + 0x70)] public uint InstanceContentTextDataObjectiveStart;
    [FieldOffset(0xD88 + 0x74)] public uint InstanceContentTextDataObjectiveEnd;
    [FieldOffset(0xD88 + 0x78)] public uint Unknown2;
    [FieldOffset(0xD88 + 0x7C)] public uint ReqInstance;
    [FieldOffset(0xD88 + 0x80)] public int InstanceContentBuff;
    /// <summary>
    /// This field is stored in minutes
    /// </summary>
    [FieldOffset(0xD88 + 0x84)] public ushort ContentTimeMax; // TimeLimitmin
    [FieldOffset(0xD88 + 0x86)] public ushort BGM;
    [FieldOffset(0xD88 + 0x88)] public ushort WinBGM;
    [FieldOffset(0xD88 + 0x8A)] public ushort Order;
    [FieldOffset(0xD88 + 0x8C)] public ushort SortKey;
    [FieldOffset(0xD88 + 0x8E)] public ushort Unknown3;
    [FieldOffset(0xD88 + 0x90)] public ushort Unknown4;
    [FieldOffset(0xD88 + 0x92)] public ushort Unknown5;
    [FieldOffset(0xD88 + 0x94)] public ushort Unknown6;
    [FieldOffset(0xD88 + 0x96)] public ushort Unknown7;
    [FieldOffset(0xD88 + 0x98)] public ushort Unknown8;
    [FieldOffset(0xD88 + 0x9A)] public ushort Unknown_70;
    [FieldOffset(0xD88 + 0x9C)] public short PartyCondition;
    [FieldOffset(0xD88 + 0x9E), CExporterForce] public InstanceContentType InstanceContentType;
    [FieldOffset(0xD88 + 0x9F)] public byte WeekRestriction;
    [FieldOffset(0xD88 + 0xA0)] public byte Colosseum;
    [FieldOffset(0xD88 + 0xA1)] public byte Unknown9;
    [FieldOffset(0xD88 + 0xA2)] public byte Unknown10;
    [FieldOffset(0xD88 + 0xA3)] public byte Unknown11;
    [FieldOffset(0xD88 + 0xA4)] public byte Unknown12;
    [FieldOffset(0xD88 + 0xA5)] public byte Unknown19;
    [FieldOffset(0xD88 + 0xA6)] public byte Unknown13;
    [FieldOffset(0xD88 + 0xA7), CExporterExcelEnd] public byte Unknown14_Unknown15_Unknown16_Unknown17_Unknown18;
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

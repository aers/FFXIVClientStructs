using FFXIVClientStructs.FFXIV.Client.Game.Gauge;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::JobGaugeManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct JobGaugeManager {
    [StaticAddress("48 8B 3D ?? ?? ?? ?? 33 ED", 3)]
    public static partial JobGaugeManager* Instance();

    [FieldOffset(0x08)] public JobGauge* CurrentGauge;

    [FieldOffset(0x08), CExporterUnion("Gauge")] public JobGauge EmptyGauge;

    [FieldOffset(0x08), CExporterUnion("Gauge")] public WhiteMageGauge WhiteMage;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public ScholarGauge Scholar;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public AstrologianGauge Astrologian;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public SageGauge Sage;

    [FieldOffset(0x08), CExporterUnion("Gauge")] public BardGauge Bard;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public MachinistGauge Machinist;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public DancerGauge Dancer;

    [FieldOffset(0x08), CExporterUnion("Gauge")] public BlackMageGauge BlackMage;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public SummonerGauge Summoner;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public RedMageGauge RedMage;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public PictomancerGauge Pictomancer;

    [FieldOffset(0x08), CExporterUnion("Gauge")] public MonkGauge Monk;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public DragoonGauge Dragoon;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public NinjaGauge Ninja;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public SamuraiGauge Samurai;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public ReaperGauge Reaper;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public ViperGauge Viper;

    [FieldOffset(0x08), CExporterUnion("Gauge")] public DarkKnightGauge DarkKnight;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public PaladinGauge Paladin;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public WarriorGauge Warrior;
    [FieldOffset(0x08), CExporterUnion("Gauge")] public GunbreakerGauge Gunbreaker;

    [FieldOffset(0x58)] public byte ClassJobId;
}

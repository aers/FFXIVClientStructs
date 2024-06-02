using FFXIVClientStructs.FFXIV.Client.Game.Gauge;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::JobGaugeManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct JobGaugeManager {
    [StaticAddress("48 8B 3D ?? ?? ?? ?? 33 ED", 3)]
    public static partial JobGaugeManager* Instance();

    [FieldOffset(0x00)] public JobGauge* CurrentGauge;

    [FieldOffset(0x08), CExporterUnion("Guage")] public JobGauge EmptyGauge;

    [FieldOffset(0x08), CExporterUnion("Guage")] public WhiteMageGauge WhiteMage;
    [FieldOffset(0x08), CExporterUnion("Guage")] public ScholarGauge Scholar;
    [FieldOffset(0x08), CExporterUnion("Guage")] public AstrologianGauge Astrologian;
    [FieldOffset(0x08), CExporterUnion("Guage")] public SageGauge Sage;

    [FieldOffset(0x08), CExporterUnion("Guage")] public BardGauge Bard;
    [FieldOffset(0x08), CExporterUnion("Guage")] public MachinistGauge Machinist;
    [FieldOffset(0x08), CExporterUnion("Guage")] public DancerGauge Dancer;

    [FieldOffset(0x08), CExporterUnion("Guage")] public BlackMageGauge BlackMage;
    [FieldOffset(0x08), CExporterUnion("Guage")] public SummonerGauge Summoner;
    [FieldOffset(0x08), CExporterUnion("Guage")] public RedMageGauge RedMage;

    [FieldOffset(0x08), CExporterUnion("Guage")] public MonkGauge Monk;
    [FieldOffset(0x08), CExporterUnion("Guage")] public DragoonGauge Dragoon;
    [FieldOffset(0x08), CExporterUnion("Guage")] public NinjaGauge Ninja;
    [FieldOffset(0x08), CExporterUnion("Guage")] public SamuraiGauge Samurai;
    [FieldOffset(0x08), CExporterUnion("Guage")] public ReaperGauge Reaper;

    [FieldOffset(0x08), CExporterUnion("Guage")] public DarkKnightGauge DarkKnight;
    [FieldOffset(0x08), CExporterUnion("Guage")] public PaladinGauge Paladin;
    [FieldOffset(0x08), CExporterUnion("Guage")] public WarriorGauge Warrior;
    [FieldOffset(0x08), CExporterUnion("Guage")] public GunbreakerGauge Gunbreaker;

    [FieldOffset(0x58)] public byte ClassJobId;
}

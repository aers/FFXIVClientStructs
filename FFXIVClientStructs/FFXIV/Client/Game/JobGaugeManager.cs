using FFXIVClientStructs.FFXIV.Client.Game.Gauge;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct JobGaugeManager
{
    [FieldOffset(0x00)] public JobGauge* CurrentGauge;

    [FieldOffset(0x08)] public JobGauge EmptyGauge;

    [FieldOffset(0x08)] public WhiteMageGauge WhiteMage;
    [FieldOffset(0x08)] public ScholarGauge Scholar;
    [FieldOffset(0x08)] public AstrologianGauge Astrologian;
    [FieldOffset(0x08)] public SageGauge Sage;

    [FieldOffset(0x08)] public BardGauge Bard;
    [FieldOffset(0x08)] public MachinistGauge Machinist;
    [FieldOffset(0x08)] public DancerGauge Dancer;

    [FieldOffset(0x08)] public BlackMageGauge BlackMage;
    [FieldOffset(0x08)] public SummonerGauge Summoner;
    [FieldOffset(0x08)] public RedMageGauge RedMage;

    [FieldOffset(0x08)] public MonkGauge Monk;
    [FieldOffset(0x08)] public DragoonGauge Dragoon;
    [FieldOffset(0x08)] public NinjaGauge Ninja;
    [FieldOffset(0x08)] public SamuraiGauge Samurai;
    [FieldOffset(0x08)] public ReaperGauge Reaper;

    [FieldOffset(0x08)] public DarkKnightGauge DarkKnight;
    [FieldOffset(0x08)] public PaladinGauge Paladin;
    [FieldOffset(0x08)] public WarriorGauge Warrior;
    [FieldOffset(0x08)] public GunbreakerGauge Gunbreaker;

    [FieldOffset(0x58)] public byte ClassJobID;

    [StaticAddress("48 8B 3D ?? ?? ?? ?? 33 ED", 3)]
    public static partial JobGaugeManager* Instance();
}
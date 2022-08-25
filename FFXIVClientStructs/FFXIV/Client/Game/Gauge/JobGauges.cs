namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct JobGauge
{
    // empty base class for other gauges, this only has the vtable
}

#region Healer

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct WhiteMageGauge
{
    [FieldOffset(0x0A)] public short LilyTimer;
    [FieldOffset(0x0C)] public byte Lily;
    [FieldOffset(0x0D)] public byte BloodLily;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct ScholarGauge
{
    [FieldOffset(0x0A)] public byte Aetherflow;
    [FieldOffset(0x0B)] public byte FairyGauge;
    [FieldOffset(0x0C)] public short SeraphTimer;
    [FieldOffset(0x0E)] public byte DismissedFairy;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct AstrologianGauge
{
    [FieldOffset(0x08)] public short Timer;
    [FieldOffset(0x0D)] public byte Card;
    [FieldOffset(0x0E)] public byte Seals; // 6 bits, 0,1-3,1-3,1-3 depending on astrosign

    public AstrologianCard CurrentCard => (AstrologianCard) Card;

    public AstrologianSeal[] CurrentSeals => new[]
    {
        (AstrologianSeal)(3 & (this.Seals >> 0)),
        (AstrologianSeal)(3 & (this.Seals >> 2)),
        (AstrologianSeal)(3 & (this.Seals >> 4)),
    };
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct SageGauge
{
    [FieldOffset(0x08)] public short AddersgallTimer;
    [FieldOffset(0x0A)] public byte Addersgall;
    [FieldOffset(0x0B)] public byte Addersting;
    [FieldOffset(0x0C)] public byte Eukrasia;

    public bool EukrasiaActive => Eukrasia > 0;
}

#endregion

#region MagicDPS

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct BlackMageGauge
{
    [FieldOffset(0x08)] public short EnochianTimer;
    [FieldOffset(0x0A)] public short ElementTimeRemaining;
    [FieldOffset(0x0C)] public sbyte ElementStance;
    [FieldOffset(0x0D)] public byte UmbralHearts;
    [FieldOffset(0x0E)] public byte PolyglotStacks;
    [FieldOffset(0x0F)] public EnochianFlags EnochianFlags;

    public int UmbralStacks => ElementStance >= 0 ? 0 : ElementStance * -1;
    public int AstralStacks => ElementStance <= 0 ? 0 : ElementStance;
    public bool EnochianActive => EnochianFlags.HasFlag(EnochianFlags.Enochian);
    public bool ParadoxActive => EnochianFlags.HasFlag(EnochianFlags.Paradox);
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct SummonerGauge
{
    [FieldOffset(0x8)] public ushort SummonTimer; // millis counting down
    [FieldOffset(0xA)] public ushort AttunementTimer; // millis counting down
    [FieldOffset(0xC)] public byte ReturnSummon; // Pet sheet (23=Carbuncle, the only option now)
    [FieldOffset(0xD)] public byte ReturnSummonGlam; // PetMirage sheet
    [FieldOffset(0xE)] public byte Attunement; // Count of "Attunement cost" resource
    [FieldOffset(0xF)] public AetherFlags AetherFlags; // bitfield
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public struct RedMageGauge
{
    [FieldOffset(0x08)] public byte WhiteMana;
    [FieldOffset(0x09)] public byte BlackMana;
    [FieldOffset(0x0A)] public byte ManaStacks;
}

#endregion

#region RangeDPS

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct BardGauge
{
    [FieldOffset(0x08)] public ushort SongTimer;
    [FieldOffset(0x0C)] public byte Repertoire;
    [FieldOffset(0x0D)] public byte SoulVoice;
    [FieldOffset(0x0E)] public SongFlags SongFlags; // bitfield
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct MachinistGauge
{
    [FieldOffset(0x08)] public short OverheatTimeRemaining;
    [FieldOffset(0x0A)] public short SummonTimeRemaining;
    [FieldOffset(0x0C)] public byte Heat;
    [FieldOffset(0x0D)] public byte Battery;
    [FieldOffset(0x0E)] public byte LastSummonBatteryPower;
    [FieldOffset(0x0F)] public byte TimerActive;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct DancerGauge
{
    [FieldOffset(0x08)] public byte Feathers;
    [FieldOffset(0x09)] public byte Esprit;
    [FieldOffset(0x0A)] public fixed byte DanceSteps[4];
    [FieldOffset(0x0E)] public byte StepIndex;

    public DanceStep CurrentStep => (DanceStep) (StepIndex >= 4 ? 0 : DanceSteps[StepIndex]);
}

#endregion

#region MeleeDPS

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct MonkGauge
{
    [FieldOffset(0x08)] public byte Chakra; // Chakra count

    [FieldOffset(0x09)]
    public BeastChakraType BeastChakra1; // CoeurlChakra = 1, RaptorChakra = 2, OpoopoChakra = 3 (only one value)

    [FieldOffset(0x0A)]
    public BeastChakraType BeastChakra2; // CoeurlChakra = 1, RaptorChakra = 2, OpoopoChakra = 3 (only one value)

    [FieldOffset(0x0B)]
    public BeastChakraType BeastChakra3; // CoeurlChakra = 1, RaptorChakra = 2, OpoopoChakra = 3 (only one value)

    [FieldOffset(0x0C)] public NadiFlags Nadi; // LunarNadi = 2, SolarNadi = 4 (If both then 2+4=6)
    [FieldOffset(0x0E)] public ushort BlitzTimeRemaining; // 20 seconds

    public BeastChakraType[] BeastChakra => new[] {BeastChakra1, BeastChakra2, BeastChakra3};
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct DragoonGauge
{
    [FieldOffset(0x08)] public short LotdTimer;
    [FieldOffset(0x0A)] public byte LotdState; // This seems to only ever be 0 or 2 now
    [FieldOffset(0x0B)] public byte EyeCount;
    [FieldOffset(0x0C)] public byte FirstmindsFocusCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct NinjaGauge
{
    [FieldOffset(0x08)] public ushort HutonTimer;
    [FieldOffset(0x0A)] public byte Ninki;
    [FieldOffset(0x0B)] public byte HutonManualCasts;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct SamuraiGauge
{
    [FieldOffset(0x0A)] public KaeshiAction Kaeshi;
    [FieldOffset(0x0B)] public byte Kenki;
    [FieldOffset(0x0C)] public byte MeditationStacks;
    [FieldOffset(0x0D)] public SenFlags SenFlags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct ReaperGauge
{
    [FieldOffset(0x08)] public byte Soul;
    [FieldOffset(0x09)] public byte Shroud;
    [FieldOffset(0x0A)] public ushort EnshroudedTimeRemaining;
    [FieldOffset(0x0C)] public byte LemureShroud;
    [FieldOffset(0x0D)] public byte VoidShroud;
}

#endregion

#region Tanks

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct DarkKnightGauge
{
    [FieldOffset(0x08)] public byte Blood;
    [FieldOffset(0x0A)] public ushort DarksideTimer;
    [FieldOffset(0x0C)] public byte DarkArtsState;
    [FieldOffset(0x0E)] public ushort ShadowTimer;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct PaladinGauge
{
    [FieldOffset(0x08)] public byte OathGauge;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct WarriorGauge
{
    [FieldOffset(0x08)] public byte BeastGauge;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct GunbreakerGauge
{
    [FieldOffset(0x08)] public byte Ammo;
    [FieldOffset(0x0A)] public short MaxTimerDuration;
    [FieldOffset(0x0C)] public byte AmmoComboStep;
}

#endregion
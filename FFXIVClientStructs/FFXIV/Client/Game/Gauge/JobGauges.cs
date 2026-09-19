namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct JobGauge {
    [VirtualFunction(0)]
    public partial JobGauge* Dtor(byte freeFlags);
}

#region Healer

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct WhiteMageGauge {
    [FieldOffset(0x0A)] public short LilyTimer;
    [FieldOffset(0x0C)] public byte Lily;
    [FieldOffset(0x0D)] public byte BloodLily;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct ScholarGauge {
    [FieldOffset(0x08)] public byte Aetherflow;
    [FieldOffset(0x09)] public byte FairyGauge;
    [FieldOffset(0x0A)] public short SeraphTimer;
    [FieldOffset(0x0C)] public byte DismissedFairy;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public partial struct AstrologianGauge {
    [BitField<AstrologianCard>(nameof(Card1), 0, 4)]
    [BitField<AstrologianCard>(nameof(Card2), 4, 4)]
    [BitField<AstrologianCard>(nameof(Card3), 8, 4)]
    [BitField<AstrologianCard>(nameof(CurrentArcana), 12, 4)]
    [FieldOffset(0x08), CExporterIgnore] private ushort CardsBacking; // TODO: remove this line, so that the BitFields are on the Cards field below
    [FieldOffset(0x08)] public short Cards; // TODO: use ushort
    [FieldOffset(0x0A)] public AstrologianDraw CurrentDraw;

    [Obsolete("Use Card1, Card2, Card3")]
    public AstrologianCard[] CurrentCards =>
    [
        (AstrologianCard)(0xF & (Cards >> 0)),
        (AstrologianCard)(0xF & (Cards >> 4)),
        (AstrologianCard)(0xF & (Cards >> 8)),
    ];
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct SageGauge {
    [FieldOffset(0x08)] public short AddersgallTimer;
    [FieldOffset(0x0A)] public byte Addersgall;
    [FieldOffset(0x0B)] public byte Addersting;
    [FieldOffset(0x0C)] public byte Eukrasia;

    public bool EukrasiaActive => Eukrasia > 0;
}

#endregion

#region MagicDPS

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public partial struct BlackMageGauge {
    [FieldOffset(0x08)] public short EnochianTimer;
    [FieldOffset(0x0A)] public sbyte ElementStance;
    [FieldOffset(0x0B)] public byte UmbralHearts;
    [FieldOffset(0x0C)] public byte PolyglotStacks;
    [BitField<bool>(nameof(EnochianActive), 0, 1)]
    [BitField<bool>(nameof(ParadoxActive), 1, 1)]
    [BitField<int>(nameof(AstralSoulStacks), 2, 3)]
    [FieldOffset(0x0D)] private byte BitFieldD;
    [FieldOffset(0x0D), Obsolete("Use EnochianActive, ParadoxActive, AstralSoulStacks")] public EnochianFlags EnochianFlags;

    public int UmbralStacks => ElementStance >= 0 ? 0 : ElementStance * -1;
    public int AstralStacks => ElementStance <= 0 ? 0 : ElementStance;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct SummonerGauge {
    [FieldOffset(0x08)] public ushort SummonTimer; // millis counting down
    [FieldOffset(0x0A)] public ushort AttunementTimer; // millis counting down
    [FieldOffset(0x0C)] public byte ReturnSummon; // Pet sheet (23=Carbuncle, the only option now)
    [FieldOffset(0x0D)] public byte ReturnSummonGlam; // PetMirage sheet
    [BitField<byte>(nameof(AttunementType), 0, 2)]
    [BitField<byte>(nameof(AttunementCount), 2, 6)]
    [FieldOffset(0x0E)] private byte BitFieldE; // Count of "Attunement cost" resource
    [FieldOffset(0x0E), Obsolete("Use AttunementCount, AttunementType")] public byte Attunement;
    [FieldOffset(0x0F)] public AetherFlags AetherFlags; // bitfield
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public partial struct RedMageGauge {
    [FieldOffset(0x08)] public byte WhiteMana;
    [FieldOffset(0x09)] public byte BlackMana;
    [FieldOffset(0x0A)] public byte ManaStacks;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct PictomancerGauge {
    [FieldOffset(0x08)] public byte PalleteGauge;
    [FieldOffset(0x0A)] public byte Paint;
    [FieldOffset(0x0B)] public CanvasFlags CanvasFlags;
    [FieldOffset(0x0C)] public CreatureFlags CreatureFlags;

    public bool CreatureMotifDrawn => (CanvasFlags & CanvasFlags.Pom) != 0 || (CanvasFlags & CanvasFlags.Wing) != 0 || (CanvasFlags & CanvasFlags.Claw) != 0 || (CanvasFlags & CanvasFlags.Maw) != 0;
    public bool WeaponMotifDrawn => (CanvasFlags & CanvasFlags.Weapon) != 0;
    public bool LandscapeMotifDrawn => (CanvasFlags & CanvasFlags.Landscape) != 0;
    public bool MooglePortraitReady => (CreatureFlags & CreatureFlags.MooglePortait) != 0;
    public bool MadeenPortraitReady => (CreatureFlags & CreatureFlags.MadeenPortrait) != 0;
}

#endregion

#region RangeDPS

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct BardGauge {
    [FieldOffset(0x08)] public ushort SongTimer;
    [FieldOffset(0x0C)] public byte Repertoire;
    [FieldOffset(0x0D)] public byte SoulVoice;
    [FieldOffset(0x0E)] public byte RadiantFinaleCoda;
    [FieldOffset(0x0F)] public SongFlags SongFlags; // bitfield
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct MachinistGauge {
    [FieldOffset(0x08)] public short OverheatTimeRemaining;
    [FieldOffset(0x0A)] public short SummonTimeRemaining;
    [FieldOffset(0x0C)] public byte Heat;
    [FieldOffset(0x0D)] public byte Battery;
    [FieldOffset(0x0E)] public byte LastSummonBatteryPower;
    [FieldOffset(0x0F)] public byte TimerActive;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct DancerGauge {
    [FieldOffset(0x08)] public byte Feathers;
    [FieldOffset(0x09)] public byte Esprit;
    [FieldOffset(0x0A), FixedSizeArray] internal FixedSizeArray4<byte> _danceSteps;
    [FieldOffset(0x0E)] public byte StepIndex;

    public DanceStep CurrentStep => (DanceStep)(StepIndex >= 4 ? 0 : DanceSteps[StepIndex]);
}

#endregion

#region MeleeDPS

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct MonkGauge {
    [FieldOffset(0x08)] public byte Chakra; // Chakra count
    [FieldOffset(0x09)] public BeastChakraType BeastChakra1; // OpoOpoChakra = 1, RaptorChakra = 2, CoeurlChakra = 3 (only one value)
    [FieldOffset(0x0A)] public BeastChakraType BeastChakra2; // OpoOpoChakra = 1, RaptorChakra = 2, CoeurlChakra = 3 (only one value)
    [FieldOffset(0x0B)] public BeastChakraType BeastChakra3; // OpoOpoChakra = 1, RaptorChakra = 2, CoeurlChakra = 3 (only one value)
    [BitField<int>(nameof(OpoOpoStacks), 0, 2)]
    [BitField<int>(nameof(RaptorStacks), 2, 2)]
    [BitField<int>(nameof(CoeurlStacks), 4, 2)]
    [FieldOffset(0x0C)] public byte BeastChakraStacks;
    [FieldOffset(0x0D)] public NadiFlags Nadi; // LunarNadi = 1, SolarNadi = 2, Both = 3
    [FieldOffset(0x0E)] public ushort BlitzTimeRemaining; // 20 seconds

    [Obsolete("Use BeastChakra1, BeastChakra2, BeastChakra3")]
    public BeastChakraType[] BeastChakra => [BeastChakra1, BeastChakra2, BeastChakra3];
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct DragoonGauge {
    [FieldOffset(0x08)] public short LotdTimer;
    [FieldOffset(0x0A)] public byte LotdState; // This seems to only ever be 0 or 2 now
    [FieldOffset(0x0B)] public byte EyeCount;
    [FieldOffset(0x0C)] public byte FirstmindsFocusCount;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct NinjaGauge {
    [FieldOffset(0x08)] public byte Ninki;
    [FieldOffset(0x0A)] public byte Kazematoi;
    // checked in ProcessDeferredReplaceAction for the mudras
    // [FieldOffset(0x0C)] public byte NinjutsuStarted? FirstMudraUsed?;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct SamuraiGauge {
    [FieldOffset(0x0A)] public KaeshiAction Kaeshi;
    [FieldOffset(0x0B)] public byte Kenki;
    [FieldOffset(0x0C)] public byte MeditationStacks;
    [FieldOffset(0x0D)] public SenFlags SenFlags;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public partial struct ReaperGauge {
    [FieldOffset(0x08)] public byte Soul;
    [FieldOffset(0x09)] public byte Shroud;
    [FieldOffset(0x0A)] public ushort EnshroudedTimeRemaining;
    [FieldOffset(0x0C)] public byte LemureShroud;
    [FieldOffset(0x0D)] public byte VoidShroud;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct ViperGauge {
    [FieldOffset(0x08)] public byte RattlingCoilStacks;
    [FieldOffset(0x09)] public byte AnguineTribute;
    [FieldOffset(0x0A)] public byte SerpentOffering;
    [FieldOffset(0x0B)] public DreadCombo DreadCombo;
    [FieldOffset(0x0E)] public ushort ReawakenedTimer;
    [BitField<SerpentCombo>(nameof(SerpentCombo), 2, 6)]
    [FieldOffset(0x10)] public byte SerpentComboState;
}

#endregion

#region Tanks

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct DarkKnightGauge {
    [FieldOffset(0x08)] public byte Blood;
    [FieldOffset(0x09)] public byte DarkArtsState;
    [FieldOffset(0x0A)] public ushort DarksideTimer;
    [FieldOffset(0x0C)] public ushort ShadowTimer;
    [FieldOffset(0x10)] public ushort DeliriumStep;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct PaladinGauge {
    [FieldOffset(0x08)] public byte OathGauge;
    [FieldOffset(0x0A)] public ushort ConfiteorComboTimer; //that only updates when you generate/spend oath
    [FieldOffset(0x0C)] public byte ConfiteorComboStep;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct WarriorGauge {
    [FieldOffset(0x08)] public byte BeastGauge;
}

[GenerateInterop]
[Inherits<JobGauge>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct GunbreakerGauge {
    [FieldOffset(0x08)] public byte Ammo;
    [FieldOffset(0x0A)] public short MaxTimerDuration;
    [FieldOffset(0x0C)] public byte AmmoComboStep;
}

#endregion

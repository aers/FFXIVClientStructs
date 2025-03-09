namespace FFXIVClientStructs.FFXIV.Client.Game.Gauge;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct JobGauge {
    // empty base class for other gauges, this only has the vtable
}

#region Healer

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct WhiteMageGauge {
    [FieldOffset(0x0A)] public short LilyTimer;
    [FieldOffset(0x0C)] public byte Lily;
    [FieldOffset(0x0D)] public byte BloodLily;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct ScholarGauge {
    [FieldOffset(0x08)] public byte Aetherflow;
    [FieldOffset(0x09)] public byte FairyGauge;
    [FieldOffset(0x0A)] public short SeraphTimer;
    [FieldOffset(0x0C)] public byte DismissedFairy;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct AstrologianGauge {
    [FieldOffset(0x08)] public short Cards;
    [FieldOffset(0x0A)] public AstrologianDraw CurrentDraw;

    public AstrologianCard[] CurrentCards => new[]
    {
        (AstrologianCard)(0xF & (this.Cards >> 0)),
        (AstrologianCard)(0xF & (this.Cards >> 4)),
        (AstrologianCard)(0xF & (this.Cards >> 8)),
    };

    public AstrologianCard CurrentArcana => (AstrologianCard)(0xF & (this.Cards >> 12));
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct SageGauge {
    [FieldOffset(0x08)] public short AddersgallTimer;
    [FieldOffset(0x0A)] public byte Addersgall;
    [FieldOffset(0x0B)] public byte Addersting;
    [FieldOffset(0x0C)] public byte Eukrasia;

    public bool EukrasiaActive => Eukrasia > 0;
}

#endregion

#region MagicDPS

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct BlackMageGauge {
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
    public int AstralSoulStacks => ((int)EnochianFlags >> 2) & 7;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct SummonerGauge {
    [FieldOffset(0x8)] public ushort SummonTimer; // millis counting down
    [FieldOffset(0xA)] public ushort AttunementTimer; // millis counting down
    [FieldOffset(0xC)] public byte ReturnSummon; // Pet sheet (23=Carbuncle, the only option now)
    [FieldOffset(0xD)] public byte ReturnSummonGlam; // PetMirage sheet
    [FieldOffset(0xE)] public byte Attunement; // Count of "Attunement cost" resource
    [FieldOffset(0xF)] public AetherFlags AetherFlags; // bitfield
    public byte AttunementCount => (byte)(Attunement >> 2);//new in 7.01,Attunement may be Bit Field
    public byte AttunementType => (byte)(Attunement & 0x3);//new in 7.01
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public struct RedMageGauge {
    [FieldOffset(0x08)] public byte WhiteMana;
    [FieldOffset(0x09)] public byte BlackMana;
    [FieldOffset(0x0A)] public byte ManaStacks;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct PictomancerGauge {
    [FieldOffset(0x08)] public byte PalleteGauge;
    [FieldOffset(0x0A)] public byte Paint;
    [FieldOffset(0x0B)] public CanvasFlags CanvasFlags;
    [FieldOffset(0x0C)] public CreatureFlags CreatureFlags;

    public bool CreatureMotifDrawn => CanvasFlags.HasFlag(CanvasFlags.Pom) || CanvasFlags.HasFlag(CanvasFlags.Wing) || CanvasFlags.HasFlag(CanvasFlags.Claw) || CanvasFlags.HasFlag(CanvasFlags.Maw);
    public bool WeaponMotifDrawn => CanvasFlags.HasFlag(CanvasFlags.Weapon);
    public bool LandscapeMotifDrawn => CanvasFlags.HasFlag(CanvasFlags.Landscape);
    public bool MooglePortraitReady => CreatureFlags.HasFlag(CreatureFlags.MooglePortait);
    public bool MadeenPortraitReady => CreatureFlags.HasFlag(CreatureFlags.MadeenPortrait);
}

#endregion

#region RangeDPS

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct BardGauge {
    [FieldOffset(0x08)] public ushort SongTimer;
    [FieldOffset(0x0C)] public byte Repertoire;
    [FieldOffset(0x0D)] public byte SoulVoice;
    [FieldOffset(0x0E)] public byte RadiantFinaleCoda;
    [FieldOffset(0x0F)] public SongFlags SongFlags; // bitfield
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct MachinistGauge {
    [FieldOffset(0x08)] public short OverheatTimeRemaining;
    [FieldOffset(0x0A)] public short SummonTimeRemaining;
    [FieldOffset(0x0C)] public byte Heat;
    [FieldOffset(0x0D)] public byte Battery;
    [FieldOffset(0x0E)] public byte LastSummonBatteryPower;
    [FieldOffset(0x0F)] public byte TimerActive;
}

[GenerateInterop]
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

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct MonkGauge {
    [FieldOffset(0x08)] public byte Chakra; // Chakra count
    [FieldOffset(0x09)] public BeastChakraType BeastChakra1; // OpoOpoChakra = 1, RaptorChakra = 2, CoeurlChakra = 3 (only one value)
    [FieldOffset(0x0A)] public BeastChakraType BeastChakra2; // OpoOpoChakra = 1, RaptorChakra = 2, CoeurlChakra = 3 (only one value)
    [FieldOffset(0x0B)] public BeastChakraType BeastChakra3; // OpoOpoChakra = 1, RaptorChakra = 2, CoeurlChakra = 3 (only one value)
    [FieldOffset(0x0C)] public byte BeastChakraStacks;
    [FieldOffset(0x0D)] public NadiFlags Nadi; // LunarNadi = 1, SolarNadi = 2, Both = 3
    [FieldOffset(0x0E)] public ushort BlitzTimeRemaining; // 20 seconds

    public BeastChakraType[] BeastChakra => [BeastChakra1, BeastChakra2, BeastChakra3];

    public int OpoOpoStacks => BeastChakraStacks & 3;
    public int RaptorStacks => ((BeastChakraStacks >> 2) & 3);
    public int CoeurlStacks => ((BeastChakraStacks >> 4) & 3);
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct DragoonGauge {
    [FieldOffset(0x08)] public short LotdTimer;
    [FieldOffset(0x0A)] public byte LotdState; // This seems to only ever be 0 or 2 now
    [FieldOffset(0x0B)] public byte EyeCount;
    [FieldOffset(0x0C)] public byte FirstmindsFocusCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct NinjaGauge {
    [FieldOffset(0x08)] public byte Ninki;
    [FieldOffset(0x0A)] public byte Kazematoi;
    // checked in ProcessDeferredReplaceAction for the mudras
    // [FieldOffset(0x0C)] public byte NinjutsuStarted? FirstMudraUsed?;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct SamuraiGauge {
    [FieldOffset(0x0A)] public KaeshiAction Kaeshi;
    [FieldOffset(0x0B)] public byte Kenki;
    [FieldOffset(0x0C)] public byte MeditationStacks;
    [FieldOffset(0x0D)] public SenFlags SenFlags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct ReaperGauge {
    [FieldOffset(0x08)] public byte Soul;
    [FieldOffset(0x09)] public byte Shroud;
    [FieldOffset(0x0A)] public ushort EnshroudedTimeRemaining;
    [FieldOffset(0x0C)] public byte LemureShroud;
    [FieldOffset(0x0D)] public byte VoidShroud;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct ViperGauge {
    [FieldOffset(0x08)] public byte RattlingCoilStacks;
    [FieldOffset(0x09)] public byte AnguineTribute;
    [FieldOffset(0x0A)] public byte SerpentOffering;
    [FieldOffset(0x0B)] public DreadCombo DreadCombo;
    [FieldOffset(0x0E)] public ushort ReawakenedTimer;
    [FieldOffset(0x10)] public byte SerpentComboState;
    public SerpentCombo SerpentCombo => (SerpentCombo)(SerpentComboState >> 2);
}

#endregion

#region Tanks

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct DarkKnightGauge {
    [FieldOffset(0x08)] public byte Blood;
    [FieldOffset(0x09)] public byte DarkArtsState;
    [FieldOffset(0x0A)] public ushort DarksideTimer;
    [FieldOffset(0x0C)] public ushort ShadowTimer;
    [FieldOffset(0x10)] public ushort DeliriumStep;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct PaladinGauge {
    [FieldOffset(0x08)] public byte OathGauge;
    [FieldOffset(0x0A)] public ushort ConfiteorComboTimer; //that only updates when you generate/spend oath
    [FieldOffset(0x0C)] public ushort ConfiteorComboStep;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct WarriorGauge {
    [FieldOffset(0x08)] public byte BeastGauge;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct GunbreakerGauge {
    [FieldOffset(0x08)] public byte Ammo;
    [FieldOffset(0x0A)] public short MaxTimerDuration;
    [FieldOffset(0x0C)] public byte AmmoComboStep;
}

#endregion

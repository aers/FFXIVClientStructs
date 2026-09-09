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
    [FieldOffset(0x0A)] public sbyte ElementStance;
    [FieldOffset(0x0B)] public byte UmbralHearts;
    [FieldOffset(0x0C)] public byte PolyglotStacks;
    [FieldOffset(0x0D)] public EnochianFlags EnochianFlags;

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
    public int RaptorStacks => (BeastChakraStacks >> 2) & 3;
    public int CoeurlStacks => (BeastChakraStacks >> 4) & 3;
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

// Beastmaster is a limited job; its gauge drives the Inner Compass UI.
// Verified at runtime on patch 7.56 by observing JobGaugeManager while playing.
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct BeastmasterGauge {
    // Beastmaster's own TP, 0-250. This does NOT regenerate passively - it is granted by the
    // combo bonuses on the player's weaponskill chain (Axeblade Bite grants +13, Shieldsplitter
    // +15), and a broken combo grants nothing. Instinctual skills spend the entire pool.
    [FieldOffset(0x08)] public byte TPGauge;
    // Familiar TP, 0-250. A single pool shared across Battlehorn slots - it is NOT reset by
    // swapping familiars. Arrives in fixed +12 increments at irregular intervals (observed
    // 1.3s, 3.1s, 19.2s and 3.0s apart), so it is not a server tick either; it tracks the
    // familiar's auto-attacks. Familiar actions spend the entire pool.
    [FieldOffset(0x09)] public byte FamiliarTPGauge;
    // Familiar TP immediately before the most recent familiar action, which scales that
    // action's potency. A familiar action expends the ENTIRE familiar pool - FamiliarTPGauge
    // drops to 0 on the same frame - so "TP consumed" and "TP at time of use" are the same
    // number and this field is both. Seen taking 132 and 168 on actions that zeroed a gauge
    // holding exactly 132 and 168.
    [FieldOffset(0x0A)] public byte FamiliarTPAtLastUse;
    // Which Battlehorn slot's familiar is summoned; 0 when none. This is the SLOT, not the
    // creature - the summoned beast's identity is not exposed here.
    [FieldOffset(0x0B)] public byte ActiveBattlehorn;
    // Reads the active affinity, then 7 while an instinctual combo resolves, then - if the
    // pair was clockwise and so formed an intentional combo - the resulting Sunstrider or
    // Moonstalker affinity ~2.2s later. If the pair was not clockwise it returns to 0 from 7
    // instead. The 7 is not an affinity: it marks the "Wavering Heart" status (Status row
    // 4643, "Otherwise engaged. Unable to perform combos with your familiar."), which locks
    // out further combo advancement until it clears. That is why this stays a byte while
    // CurrentAffinity below is typed as the enum.
    [FieldOffset(0x0C)] public byte InstinctualComboState;
    // Affinity of the most recent instinctual skill, replaced by the resulting Sunstrider or
    // Moonstalker affinity once an intentional combo resolves. Cleared ~7s after the last
    // skill. Only ever observed holding 0-6.
    [FieldOffset(0x0D)] public BeastmasterAffinity CurrentAffinity;
    // Number of instinctual skills chained so far, shown beneath the Inner Compass.
    // Increments on any instinctual combo, not only intentional (clockwise) ones, and
    // increases the extra damage dealt.
    [FieldOffset(0x0E)] public byte ChainCount;
    // Identifies the familiar whose Kinship is currently active: high nibble is its kin type,
    // low nibble is the Battlehorn slot it was summoned from. Set when Borrow grants a Kinship
    // and cleared to 0 when that Kinship is lost. Latched at the moment Borrow is used, so the
    // low nibble is NOT a mirror of ActiveBattlehorn - swapping familiars afterwards moves
    // ActiveBattlehorn while this stays put.
    [FieldOffset(0x0F)] public byte KinshipState;

    public BeastmasterKinType KinshipKinType => (BeastmasterKinType)(KinshipState >> 4);
    public byte KinshipBattlehorn => (byte)(KinshipState & 0x0F);
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
    [FieldOffset(0x0C)] public byte ConfiteorComboStep;
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

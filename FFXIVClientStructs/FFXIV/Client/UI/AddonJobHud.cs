using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonJobHud {
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public byte Unk220;
    [FieldOffset(0x221)] public bool UseSimpleGauge;
    [FieldOffset(0x222)] public byte Unk222;

    // these 4 pointers get set in vf72, and point to varying offsets for each type of gauge
    [FieldOffset(0x228)] public AddonJobHudGauge* GaugeStandardPtr;
    [FieldOffset(0x230)] public AddonJobHudGauge* GaugeSimplePtr;
    [FieldOffset(0x238)] public AddonJobHudGaugeData* DataPreviousPtr;    
    [FieldOffset(0x240)] public AddonJobHudGaugeData* DataCurrentPtr; // Current is always used to apply updates, and then copied onto Previous

    [FieldOffset(0x248)] public AtkResNode* RootNode;

    [FieldOffset(0x250)] public int TimelineLabelStandard; // always set to 19 by vf75
    [FieldOffset(0x254)] public int TimelineLabelSimple; // always set to 101 by vf75

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public unsafe partial struct AddonJobHudGaugeData {
        [FieldOffset(0x0)] public void* vtbl;
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe partial struct AddonJobHudGauge {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public AddonJobHud* JobHud;
    }
}

#region Healer

#region AST
[Addon("JobHudAST0")]
[StructLayout(LayoutKind.Explicit, Size = 0x468)]
public unsafe partial struct AddonJobHudAST0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct ArcanaGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public partial struct ArcanaGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public partial struct ArcanaGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public ArcanaGaugeData DataPrevious;
    [FieldOffset(0x2A0)] public ArcanaGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public ArcanaGauge GaugeStandard;
    [FieldOffset(0x3A8)] public ArcanaGaugeSimple GaugeSimple;
}
#endregion

#region SGE
[Addon("JobHudGFF0")]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct AddonJobHudGFF0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct EukrasiaGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public EukrasiaGaugeData DataPrevious;
    [FieldOffset(0x270)] public EukrasiaGaugeData DataCurrent;
    [FieldOffset(0x280)] public EukrasiaGauge GaugeStandard;
    [FieldOffset(0x2A0)] public EukrasiaGaugeSimple GaugeSimple;
}

[Addon("JobHudGFF1")]
[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe partial struct AddonJobHudGFF1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct AddersgallGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct AddersgallGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AddersgallGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public AddersgallGaugeData DataPrevious;
    [FieldOffset(0x280)] public AddersgallGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public AddersgallGauge GaugeStandard;
    [FieldOffset(0x310)] public AddersgallGaugeSimple GaugeSimple;
}
#endregion

#region SCH
[Addon("JobHudACN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonJobHudACN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct AetherflowACNGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AetherflowACNGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AetherflowACNGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public AetherflowACNGaugeData DataPrevious;
    [FieldOffset(0x270)] public AetherflowACNGaugeData DataCurrent;
    [FieldOffset(0x280)] public AetherflowACNGauge GaugeStandard;
    [FieldOffset(0x2E0)] public AetherflowACNGaugeSimple GaugeSimple;
}

[Addon("JobHudSCH0")]
[StructLayout(LayoutKind.Explicit, Size = 0x388)]
public unsafe partial struct AddonJobHudSCH0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct FaerieGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct FaerieGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct FaerieGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public FaerieGaugeData DataPrevious;
    [FieldOffset(0x280)] public FaerieGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public FaerieGauge GaugeStandard;
    [FieldOffset(0x330)] public FaerieGaugeSimple GaugeSimple;
}
#endregion

#region WHM
[Addon("JobHudWHM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct AddonJobHudWHM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct HealingGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct HealingGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct HealingGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public HealingGaugeData DataPrevious;
    [FieldOffset(0x280)] public HealingGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public HealingGauge GaugeStandard;
    [FieldOffset(0x310)] public HealingGaugeSimple GaugeSimple;
}
#endregion

#endregion

#region Tank

#region DRK
[Addon("JobHudDRK0")]
[StructLayout(LayoutKind.Explicit, Size = 0x318)]
public unsafe partial struct AddonJobHudDRK0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct BloodGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct BloodGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct BloodGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public BloodGaugeData DataPrevious;
    [FieldOffset(0x278)] public BloodGaugeData DataCurrent;
    [FieldOffset(0x290)] public BloodGauge GaugeStandard;
    [FieldOffset(0x2D8)] public BloodGaugeSimple GaugeSimple;
}

[Addon("JobHudDRK1")]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct AddonJobHudDRK1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct DarksideGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct DarksideGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct DarksideGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public DarksideGaugeData DataPrevious;
    [FieldOffset(0x278)] public DarksideGaugeData DataCurrent;
    [FieldOffset(0x290)] public DarksideGauge GaugeStandard;
    [FieldOffset(0x2F0)] public DarksideGaugeSimple GaugeSimple;
}
#endregion

#region GNB
[Addon("JobHudGNB0")]
[StructLayout(LayoutKind.Explicit, Size = 0x358)]
public unsafe partial struct AddonJobHudGNB0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct PowderGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct PowderGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct PowderGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public PowderGaugeData DataPrevious;
    [FieldOffset(0x270)] public PowderGaugeData DataCurrent;
    [FieldOffset(0x280)] public PowderGauge GaugeStandard;
    [FieldOffset(0x2F0)] public PowderGaugeSimple GaugeSimple;
}
#endregion

#region PLD
[Addon("JobHudPLD0")]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe partial struct AddonJobHudPLD0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct OathGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct OathGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct OathGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public OathGaugeData DataPrevious;
    [FieldOffset(0x278)] public OathGaugeData DataCurrent;
    [FieldOffset(0x290)] public OathGauge GaugeStandard;
    [FieldOffset(0x2E8)] public OathGaugeSimple GaugeSimple;
}
#endregion

#region WAR
[Addon("JobHudWAR0")]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonJobHudWAR0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct BeastGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct BeastGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct BeastGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public BeastGaugeData DataPrevious;
    [FieldOffset(0x278)] public BeastGaugeData DataCurrent;
    [FieldOffset(0x290)] public BeastGauge GaugeStandard;
    [FieldOffset(0x2E8)] public BeastGaugeSimple GaugeSimple;
}
#endregion

#endregion

#region Melee DPS

#region DRG
[Addon("JobHudDRG0")]
[StructLayout(LayoutKind.Explicit, Size = 0x398)]
public unsafe partial struct AddonJobHudDRG0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct DragonGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct DragonGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct DragonGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public DragonGaugeData DataPrevious;
    [FieldOffset(0x288)] public DragonGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public DragonGauge GaugeStandard;
    [FieldOffset(0x308)] public DragonGaugeSimple GaugeSimple;
}
#endregion

#region MNK
[Addon("JobHudMNK0")]
[StructLayout(LayoutKind.Explicit, Size = 0x420)]
public unsafe partial struct AddonJobHudMNK0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct MastersGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public partial struct MastersGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public partial struct MastersGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public MastersGaugeData DataPrevious;
    [FieldOffset(0x288)] public MastersGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public MastersGauge GaugeStandard;
    [FieldOffset(0x360)] public MastersGaugeSimple GaugeSimple;
}

[Addon("JobHudMNK1")]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonJobHudMNK1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct ChakraGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct ChakraGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct ChakraGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public ChakraGaugeData DataPrevious;
    [FieldOffset(0x270)] public ChakraGaugeData DataCurrent;
    [FieldOffset(0x280)] public ChakraGauge GaugeStandard;
    [FieldOffset(0x2C0)] public ChakraGaugeSimple GaugeSimple;
}
#endregion

#region NIN
[Addon("JobHudNIN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonJobHudNIN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct NinkiGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct NinkiGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct NinkiGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public NinkiGaugeData DataPrevious;
    [FieldOffset(0x278)] public NinkiGaugeData DataCurrent;
    [FieldOffset(0x290)] public NinkiGauge GaugeStandard;
    [FieldOffset(0x2D0)] public NinkiGaugeSimple GaugeSimple;
}

[Addon("JobHudNIN1")]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public unsafe partial struct AddonJobHudNIN1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct HutonGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct HutonGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct HutonGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public HutonGaugeData DataPrevious;
    [FieldOffset(0x278)] public HutonGaugeData DataCurrent;
    [FieldOffset(0x290)] public HutonGauge GaugeStandard;
    [FieldOffset(0x2F8)] public HutonGaugeSimple GaugeSimple;
}
#endregion

#region RPR
[Addon("JobHudRPR0")]
[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
public unsafe partial struct AddonJobHudRPR0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct SoulGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xF8)]
    public partial struct SoulGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct SoulGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public SoulGaugeData DataPrevious;
    [FieldOffset(0x288)] public SoulGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public SoulGauge GaugeStandard;
    [FieldOffset(0x3A8)] public SoulGaugeSimple GaugeSimple;
}

[Addon("JobHudRPR1")]
[StructLayout(LayoutKind.Explicit, Size = 0x490)]
public unsafe partial struct AddonJobHudRPR1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct DeathGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x118)]
    public partial struct DeathGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct DeathGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public DeathGaugeData DataPrevious;
    [FieldOffset(0x280)] public DeathGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public DeathGauge GaugeStandard;
    [FieldOffset(0x3B8)] public DeathGaugeSimple GaugeSimple;
}
#endregion

#region SAM
[Addon("JobHudSAM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct AddonJobHudSAM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct KenkiGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct KenkiGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct KenkiGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public KenkiGaugeData DataPrevious;
    [FieldOffset(0x278)] public KenkiGaugeData DataCurrent;
    [FieldOffset(0x290)] public KenkiGauge GaugeStandard;
    [FieldOffset(0x320)] public KenkiGaugeSimple GaugeSimple;
}

[Addon("JobHudSAM1")]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonJobHudSAM1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct SenGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct SenGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct SenGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public SenGaugeData DataPrevious;
    [FieldOffset(0x270)] public SenGaugeData DataCurrent;
    [FieldOffset(0x280)] public SenGauge GaugeStandard;
    [FieldOffset(0x3D0)] public SenGaugeSimple GaugeSimple;
}
#endregion

#endregion

#region Phys Ranged  DPS

#region BRD
[Addon("JobHudBRD0")]
[StructLayout(LayoutKind.Explicit, Size = 0x4C0)]
public unsafe partial struct AddonJobHudBRD0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct SongGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct SongGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public partial struct SongGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public SongGaugeData DataPrevious;
    [FieldOffset(0x2A0)] public SongGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public SongGauge GaugeStandard;
    [FieldOffset(0x3E0)] public SongGaugeSimple GaugeSimple;
}
#endregion

#region DNC
[Addon("JobHudDNC0")]
[StructLayout(LayoutKind.Explicit, Size = 0x398)]
public unsafe partial struct AddonJobHudDNC0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct StepGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct StepGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct StepGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public StepGaugeData DataPrevious;
    [FieldOffset(0x290)] public StepGaugeData DataCurrent;
    [FieldOffset(0x2C0)] public StepGauge GaugeStandard;
    [FieldOffset(0x330)] public StepGaugeSimple GaugeSimple;
}

[Addon("JobHudDNC1")]
[StructLayout(LayoutKind.Explicit, Size = 0x3A8)]
public unsafe partial struct AddonJobHudDNC1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct FeatherGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public partial struct FeatherGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct FeatherGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public FeatherGaugeData DataPrevious;
    [FieldOffset(0x280)] public FeatherGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public FeatherGauge GaugeStandard;
    [FieldOffset(0x338)] public FeatherGaugeSimple GaugeSimple;
}
#endregion

#region MCH
[Addon("JobHudMCH0")]
[StructLayout(LayoutKind.Explicit, Size = 0x3B8)]
public unsafe partial struct AddonJobHudMCH0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct HeatGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public partial struct HeatGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct HeatGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public HeatGaugeData DataPrevious;
    [FieldOffset(0x298)] public HeatGaugeData DataCurrent;
    [FieldOffset(0x2D0)] public HeatGauge GaugeStandard;
    [FieldOffset(0x348)] public HeatGaugeSimple GaugeSimple;
}
#endregion

#endregion

#region Caster  DPS

#region BLM
[Addon("JobHudBLM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x4E0)]
public unsafe partial struct AddonJobHudBLM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct ElementalGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x168)]
    public partial struct ElementalGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public partial struct ElementalGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public ElementalGaugeData DataPrevious;
    [FieldOffset(0x298)] public ElementalGaugeData DataCurrent;
    [FieldOffset(0x2D0)] public ElementalGauge GaugeStandard;
    [FieldOffset(0x438)] public ElementalGaugeSimple GaugeSimple;
}
#endregion

#region RDM
[Addon("JobHudRDM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct AddonJobHudRDM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct BalanceGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct BalanceGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct BalanceGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public BalanceGaugeData DataPrevious;
    [FieldOffset(0x288)] public BalanceGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public BalanceGauge GaugeStandard;
    [FieldOffset(0x3B0)] public BalanceGaugeSimple GaugeSimple;
}
#endregion

#region SMN
[Addon("JobHudSMN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct AddonJobHudSMN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct AetherflowSMNGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct AetherflowSMNGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct AetherflowSMNGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public AetherflowSMNGaugeData DataPrevious;
    [FieldOffset(0x270)] public AetherflowSMNGaugeData DataCurrent;
    [FieldOffset(0x280)] public AetherflowSMNGauge GaugeStandard;
    [FieldOffset(0x3B8)] public AetherflowSMNGaugeSimple GaugeSimple;
}

[Addon("JobHudSMN1")]
[StructLayout(LayoutKind.Explicit, Size = 0x4B0)]
public unsafe partial struct AddonJobHudSMN1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct TranceGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x108)]
    public partial struct TranceGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct TranceGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public TranceGaugeData DataPrevious;
    [FieldOffset(0x298)] public TranceGaugeData DataCurrent;
    [FieldOffset(0x2D0)] public TranceGauge GaugeStandard;
    [FieldOffset(0x3D8)] public TranceGaugeSimple GaugeSimple;
}
#endregion

#endregion

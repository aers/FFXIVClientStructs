using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// ACN / SCH - Aetherflow Gauge<br/>
/// NOTE: this loads the UldResourceHandle "JobHudSCH0"
/// </summary>
[Addon("JobHudACN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonJobHudACN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct AetherflowACNGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public byte AetherflowStacks;
        [FieldOffset(0x09)] public fixed byte Prerequisites[1];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AetherflowACNGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;

        [StructLayout(LayoutKind.Explicit, Size = Size)]
        public partial struct AetherflowACNStack {
            public const int Size = 0x18;
            [FieldOffset(0x00)] public AtkComponentBase* StackContainer;
            [FieldOffset(0x08)] public AtkResNode* StackNode;
            [FieldOffset(0x10)] public bool StackReady;
        }

        [FixedSizeArray<AetherflowACNStack>(3)]
        [FieldOffset(0x10)] public fixed byte AetherflowStacks[3 * AetherflowACNStack.Size];

        [FieldOffset(0x58)] public int TimelineFrameId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AetherflowACNGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;

        [StructLayout(LayoutKind.Explicit, Size = Size)]
        public partial struct AetherflowACNStackSimple {
            public const int Size = 0x18;
            [FieldOffset(0x00)] public AtkComponentBase* StackContainer;
            [FieldOffset(0x08)] public AtkResNode* StackNode;
            [FieldOffset(0x10)] public bool StackReady;
        }

        [FixedSizeArray<AetherflowACNStackSimple>(3)]
        [FieldOffset(0x10)] public fixed byte AetherflowStacks[3 * AetherflowACNStackSimple.Size];

        [FieldOffset(0x58)] public int TimelineFrameId;
    }

    [FieldOffset(0x260)] public AetherflowACNGaugeData DataPrevious;
    [FieldOffset(0x270)] public AetherflowACNGaugeData DataCurrent;
    [FieldOffset(0x280)] public AetherflowACNGauge GaugeStandard;
    [FieldOffset(0x2E0)] public AetherflowACNGaugeSimple GaugeSimple;
}

/// <summary>
/// SCH - Faerie Gauge<br/>
/// NOTE: this loads the UldResourceHandle "JobHudSCH1"
/// </summary>
[Addon("JobHudSCH0")]
[StructLayout(LayoutKind.Explicit, Size = 0x388)]
public unsafe partial struct AddonJobHudSCH0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct FaerieGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public int FaeValue;
        [FieldOffset(0x0C)] public int FaeMax;
        [FieldOffset(0x10)] public fixed byte Prerequisites[3];
        [FieldOffset(0x18)] public int SeraphTimeLeft;
        [FieldOffset(0x1C)] public int SeraphMaxTime;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct FaerieGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* FaeriePlateContainer;
        [FieldOffset(0x20)] public AtkTextNode* SeraphTimerText;
        [FieldOffset(0x30)] public AtkResNode* FaeGaugeTextContainer;
        [FieldOffset(0x38)] public AtkTextNode* FaeGaugeText;
        [FieldOffset(0x40)] public AtkImageNode* FaeBarFillAbsent;
        [FieldOffset(0x48)] public AtkImageNode* FaeBarFillSeraph;
        [FieldOffset(0x50)] public AtkImageNode* FaeBarFillStandard;
        [FieldOffset(0x58)] public AtkResNode* FaeBarGain;
        [FieldOffset(0x60)] public AtkResNode* FaeBarLoss;
        [FieldOffset(0x68)] public AtkResNode* FaeriePlate;
        [FieldOffset(0x70)] public int FaeBarMaxWidth;
        [FieldOffset(0x74)] public int FaeBarWidth;
        [FieldOffset(0x78)] public int FaeBarTargetWidth;
        [FieldOffset(0x7C)] public int FaeBarWidthChange;
        [FieldOffset(0x84)] public bool FaeBarAnimating;
        [FieldOffset(0x87)] public bool HasFaerie;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct FaerieGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* FaeGaugeBar;
        [FieldOffset(0x28)] public AtkResNode* FaeGaugeBarFill;
        [FieldOffset(0x30)] public AtkComponentTextNineGrid* FaeValueDisplay;
        [FieldOffset(0x38)] public int FaeBarState;
        [FieldOffset(0x40)] public AtkResNode* SeraphContainer;
        [FieldOffset(0x48)] public AtkComponentTextNineGrid* SeraphTimerDisplay;
    }

    [FieldOffset(0x260)] public FaerieGaugeData DataPrevious;
    [FieldOffset(0x280)] public FaerieGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public FaerieGauge GaugeStandard;
    [FieldOffset(0x330)] public FaerieGaugeSimple GaugeSimple;
}

/// <summary>
/// SMN - Aetherflow Gauge
/// </summary>
[Addon("JobHudSMN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct AddonJobHudSMN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct AetherflowSMNGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public int AetherflowStacks;
        [FieldOffset(0x0C)] public fixed byte Prerequisites[1];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct AetherflowSMNGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkComponentBase* StackContainer1;
        [FieldOffset(0x18)] public AtkComponentBase* StackContainer2;
        [FieldOffset(0x20)] public AtkResNode* Stack1;
        [FieldOffset(0x28)] public AtkResNode* Stack2;
        [FieldOffset(0x30)] public bool Stack1Ready;
        [FieldOffset(0x31)] public bool Stack2Ready;
        [FieldOffset(0x34)] public int TimelineFrameId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct AetherflowSMNGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkComponentBase* StackContainer1;
        [FieldOffset(0x18)] public AtkComponentBase* StackContainer2;
        [FieldOffset(0x20)] public AtkResNode* Stack1;
        [FieldOffset(0x28)] public AtkResNode* Stack2;
        [FieldOffset(0x30)] public bool Stack1Ready;
        [FieldOffset(0x31)] public bool Stack2Ready;
        [FieldOffset(0x34)] public int TimelineFrameId;
    }

    [FieldOffset(0x260)] public AetherflowSMNGaugeData DataPrevious;
    [FieldOffset(0x270)] public AetherflowSMNGaugeData DataCurrent;
    [FieldOffset(0x280)] public AetherflowSMNGauge GaugeStandard;
    [FieldOffset(0x2B8)] public AetherflowSMNGaugeSimple GaugeSimple;
}

/// <summary>
/// SMN - Trance Gauge
/// </summary>
[Addon("JobHudSMN1")]
[StructLayout(LayoutKind.Explicit, Size = 0x4B0)]
public unsafe partial struct AddonJobHudSMN1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct TranceGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[2];
        [FieldOffset(0x0C)] public int Phase;
        [FieldOffset(0x10)] public int SummonTimeLeft;
        [FieldOffset(0x14)] public int SummonTimeMax;
        [FieldOffset(0x1C)] public byte IfritReady;
        [FieldOffset(0x1D)] public byte TitanReady;
        [FieldOffset(0x1E)] public byte GarudaReady;
        [FieldOffset(0x20)] public fixed int Prerequisites2[3];
        [FieldOffset(0x2C)] public int CurrentEgi;
        [FieldOffset(0x30)] public int Attunement;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x108)]
    public partial struct TranceGauge {
        [FieldOffset(0x000)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x010)] public AtkResNode* Container;
        [FieldOffset(0x018)] public AtkResNode* CarbunclePlate;
        [FieldOffset(0x020)] public AtkImageNode* CarbuncleBar;
        [FieldOffset(0x028)] public AtkTextNode* CarbuncleGaugeValue;
        [FieldOffset(0x038)] public AtkResNode* SummonPlate;
        [FieldOffset(0x040)] public AtkResNode* SummonHead;
        [FieldOffset(0x048)] public AtkTextNode* TranceGaugeValue;
        [FieldOffset(0x058)] public AtkImageNode* TranceBar;
        [FieldOffset(0x068)] public AtkResNode* SummonWing;
        [FieldOffset(0x070)] public AtkResNode* SummonBarMask;
        [FieldOffset(0x078)] public AtkResNode* EgiGems;
        [FieldOffset(0x080)] public AtkComponentTextNineGrid* EgiTimerDisplay;

        [StructLayout(LayoutKind.Explicit, Size = 0x28)]
        public partial struct EgiGauge {
            [FieldOffset(0x00)] public AtkComponentBase* Container;
            [FieldOffset(0x08)] public AtkTextNode* AttunementStackText;
            [FieldOffset(0x10)] public AtkResNode* Gem;
            [FieldOffset(0x18)] public AtkResNode* Silhouette;
            [FieldOffset(0x20)] public int Status; // 0 = Spent, 1 = Available, 2 = Active, 3 = Locked
        }

        [FieldOffset(0x088)] public EgiGauge IfritGauge;
        [FieldOffset(0x0B0)] public EgiGauge TitanGauge;
        [FieldOffset(0x0D8)] public EgiGauge GarudaGauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct TranceGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkComponentGaugeBar* TranceGaugeBar;
        [FieldOffset(0x18)] public AtkResNode* SummonIcon;
        [FieldOffset(0x20)] public AtkComponentTextNineGrid* TranceTimerDisplay;
        [FieldOffset(0x30)] public AtkResNode* EgiContainer;
        [FieldOffset(0x38)] public AtkComponentTextNineGrid* EgiTimerDisplay;

        [StructLayout(LayoutKind.Explicit, Size = 0x20)]
        public partial struct EgiGaugeSimple {
            [FieldOffset(0x00)] public AtkComponentBase* Gem;
            [FieldOffset(0x08)] public AtkTextNode* AttunementStackText;
            [FieldOffset(0x10)] public AtkResNode* GemGlow;
            [FieldOffset(0x18)] public int Status;
        }

        [FieldOffset(0x40)] public EgiGaugeSimple IfritGauge;
        [FieldOffset(0x60)] public EgiGaugeSimple TitanGauge;
        [FieldOffset(0x80)] public EgiGaugeSimple GarudaGauge;
        [FieldOffset(0xA0)] public AtkComponentBase* EgiIconContainer;
        [FieldOffset(0xA8)] public AtkResNode* EgiIcons;
        [FieldOffset(0xB0)] public AtkResNode* IfritIcon;
        [FieldOffset(0xB8)] public AtkResNode* TitanIcon;
        [FieldOffset(0xC0)] public AtkResNode* GarudaIcon;
        [FieldOffset(0xC8)] public bool EgiActive;
        [FieldOffset(0xD0)] public AtkResNode* TimelineFrameId;
    }

    [FieldOffset(0x260)] public TranceGaugeData DataPrevious;
    [FieldOffset(0x298)] public TranceGaugeData DataCurrent;
    [FieldOffset(0x2D0)] public TranceGauge GaugeStandard;
    [FieldOffset(0x3D8)] public TranceGaugeSimple GaugeSimple;
}

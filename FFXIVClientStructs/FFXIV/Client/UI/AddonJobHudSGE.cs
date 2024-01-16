using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// SGE - Eukrasia Gauge
/// </summary>
[Addon("JobHudGFF0")]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct AddonJobHudGFF0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct EukrasiaGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[1];
        [FieldOffset(0x09)] public bool EukrasiaActive;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public bool EukrasiaActive;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public bool EukrasiaActive;
    }

    [FieldOffset(0x260)] public EukrasiaGaugeData DataPrevious;
    [FieldOffset(0x270)] public EukrasiaGaugeData DataCurrent;
    [FieldOffset(0x280)] public EukrasiaGauge GaugeStandard;
    [FieldOffset(0x2A0)] public EukrasiaGaugeSimple GaugeSimple;
}

/// <summary>
/// SGE - Addersgall Gauge
/// </summary>
[Addon("JobHudGFF1")]
[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe partial struct AddonJobHudGFF1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct AddersgallGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[2];
        [FieldOffset(0x0C)] public int Addersgall;
        [FieldOffset(0x10)] public int Addersting;
        [FieldOffset(0x14)] public int AddersgallTimer;
        [FieldOffset(0x18)] public int AddersgallTimerMax;
        [FieldOffset(0x1C)] public bool InCombat;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct AddersgallGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* AdderstingContainer;

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x18)] public fixed byte AddersgallGem[3 * 0x08];

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x30)] public fixed byte AdderstingGem[3 * 0x08];

        [FieldOffset(0x48)] public AtkResNode* TimerBar;
        [FieldOffset(0x50)] public AtkResNode* TimerFill;
        [FieldOffset(0x58)] public AtkResNode* Container;
        [FieldOffset(0x60)] public int Addersgall;
        [FieldOffset(0x64)] public int Addersting;
        [FieldOffset(0x68)] public int TimelineFrameId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AddersgallGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* AdderstingContainer;

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x18)] public fixed byte AddersgallGem[3 * 0x08];

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x30)] public fixed byte AdderstingGem[3 * 0x08];

        [FieldOffset(0x48)] public AtkComponentGaugeBar* TimerGaugeBar;
        [FieldOffset(0x50)] public int Addersgall;
        [FieldOffset(0x54)] public int Addersting;
        [FieldOffset(0x58)] public int AddersgallTimelineFrameId;
        [FieldOffset(0x5C)] public int AdderstingTimelineFrameId;
    }

    [FieldOffset(0x260)] public AddersgallGaugeData DataPrevious;
    [FieldOffset(0x280)] public AddersgallGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public AddersgallGauge GaugeStandard;
    [FieldOffset(0x310)] public AddersgallGaugeSimple GaugeSimple;
}

using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// NIN - Ninki Gauge
/// </summary>
[Addon("JobHudNIN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonJobHudNIN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct NinkiGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[1];
        [FieldOffset(0x0C)] public int NinkiValue;
        [FieldOffset(0x10)] public int Max;
        [FieldOffset(0x14)] public int Mid;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct NinkiGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Scroll;
        [FieldOffset(0x20)] public AtkTextNode* ValueText;
        [FieldOffset(0x28)] public AtkComponentGaugeBar* GaugeBar0; // bar for 0-50
        [FieldOffset(0x30)] public AtkComponentGaugeBar* GaugeBar1; // bar for 50-100
        [FieldOffset(0x38)] public bool CanSpend;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct NinkiGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* BarTextNode;
        [FieldOffset(0x20)] public AtkComponentTextNineGrid* ValueDisplay;
        [FieldOffset(0x28)] public AtkComponentGaugeBar* GaugeBar;
    }

    [FieldOffset(0x260)] public NinkiGaugeData DataPrevious;
    [FieldOffset(0x278)] public NinkiGaugeData DataCurrent;
    [FieldOffset(0x290)] public NinkiGauge GaugeStandard;
    [FieldOffset(0x2D0)] public NinkiGaugeSimple GaugeSimple;
}

/// <summary>
/// NIN - Huton Gauge
/// </summary>
[Addon("JobHudNIN1")]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public unsafe partial struct AddonJobHudNIN1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct HutonGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[2];
        [FieldOffset(0x0C)] public int TimeLeft; // in ms
        [FieldOffset(0x10)] public int MaxTime;  // in ms
        [FieldOffset(0x14)] public int ManualCasts;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct HutonGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Pinwheel;
        [FieldOffset(0x20)] public AtkTextNode* ValueText;

        [FixedSizeArray<Pointer<AtkComponentBase>>(6)]
        [FieldOffset(0x28)] public fixed byte Blade[6 * 0x8];

        [FieldOffset(0x5C)] public int BladesFallen;
        [FieldOffset(0x58)] public int TimePerBlade; // in seconds
        [FieldOffset(0x60)] public bool IsActive;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct HutonGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkComponentTextNineGrid* ValueDisplay;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* GaugeBar;
    }

    [FieldOffset(0x260)] public HutonGaugeData DataPrevious;
    [FieldOffset(0x278)] public HutonGaugeData DataCurrent;
    [FieldOffset(0x290)] public HutonGauge GaugeStandard;
    [FieldOffset(0x2F8)] public HutonGaugeSimple GaugeSimple;
}

using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// DRK - Blood Gauge
/// </summary>
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

/// <summary>
/// DRK - Darkside Gauge
/// </summary>
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

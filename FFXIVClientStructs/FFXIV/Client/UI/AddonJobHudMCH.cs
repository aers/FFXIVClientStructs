using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// MCH - Heat Gauge
/// </summary>
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

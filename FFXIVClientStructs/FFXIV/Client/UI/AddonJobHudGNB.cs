using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// GNB - Powder Gauge
/// </summary>
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

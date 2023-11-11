using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// WHM - Healing Gauge
/// </summary>
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

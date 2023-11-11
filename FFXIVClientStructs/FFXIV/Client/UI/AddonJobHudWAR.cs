using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// WAR - Beast Gauge
/// </summary>
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

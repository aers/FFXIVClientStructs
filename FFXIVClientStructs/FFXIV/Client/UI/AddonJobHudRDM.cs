using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// RDM - Balance Gauge
/// </summary>
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

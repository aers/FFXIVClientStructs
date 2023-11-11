using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// DNC - Step Gauge
/// </summary>
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

/// <summary>
/// DNC - Fourfold Feathers
/// </summary>
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

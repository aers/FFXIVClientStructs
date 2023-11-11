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
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
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
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct AddersgallGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AddersgallGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public AddersgallGaugeData DataPrevious;
    [FieldOffset(0x280)] public AddersgallGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public AddersgallGauge GaugeStandard;
    [FieldOffset(0x310)] public AddersgallGaugeSimple GaugeSimple;
}

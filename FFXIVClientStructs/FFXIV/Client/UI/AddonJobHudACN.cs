namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// ACN / SCH - Aetherflow Gauge
/// </summary>
[Addon("JobHudACN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonJobHudACN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct AetherflowACNGaugeData {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AetherflowACNGauge {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AetherflowACNGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public AetherflowACNGaugeData DataPrevious;
    [FieldOffset(0x270)] public AetherflowACNGaugeData DataCurrent;
    [FieldOffset(0x280)] public AetherflowACNGauge GaugeStandard;
    [FieldOffset(0x2E0)] public AetherflowACNGaugeSimple GaugeSimple;
}

/// <summary>
/// SCH - Faerie Gauge
/// </summary>
[Addon("JobHudSCH0")]
[StructLayout(LayoutKind.Explicit, Size = 0x388)]
public unsafe partial struct AddonJobHudSCH0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct FaerieGaugeData {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct FaerieGauge {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct FaerieGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public FaerieGaugeData DataPrevious;
    [FieldOffset(0x280)] public FaerieGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public FaerieGauge GaugeStandard;
    [FieldOffset(0x330)] public FaerieGaugeSimple GaugeSimple;
}

/// <summary>
/// SMN - Aetherflow Gauge
/// </summary>
[Addon("JobHudSMN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct AddonJobHudSMN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct AetherflowSMNGaugeData {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct AetherflowSMNGauge {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct AetherflowSMNGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public AetherflowSMNGaugeData DataPrevious;
    [FieldOffset(0x270)] public AetherflowSMNGaugeData DataCurrent;
    [FieldOffset(0x280)] public AetherflowSMNGauge GaugeStandard;
    [FieldOffset(0x3B8)] public AetherflowSMNGaugeSimple GaugeSimple;
}

/// <summary>
/// SMN - Trance Gauge
/// </summary>
[Addon("JobHudSMN1")]
[StructLayout(LayoutKind.Explicit, Size = 0x4B0)]
public unsafe partial struct AddonJobHudSMN1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct TranceGaugeData {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x108)]
    public partial struct TranceGauge {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct TranceGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHud.AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public TranceGaugeData DataPrevious;
    [FieldOffset(0x298)] public TranceGaugeData DataCurrent;
    [FieldOffset(0x2D0)] public TranceGauge GaugeStandard;
    [FieldOffset(0x3D8)] public TranceGaugeSimple GaugeSimple;
}

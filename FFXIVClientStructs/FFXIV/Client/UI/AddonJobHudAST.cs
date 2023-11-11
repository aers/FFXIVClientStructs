using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// AST - Arcana Gauge
/// </summary>
[Addon("JobHudAST0")]
[StructLayout(LayoutKind.Explicit, Size = 0x468)]
public unsafe partial struct AddonJobHudAST0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct ArcanaGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public partial struct ArcanaGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public partial struct ArcanaGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public ArcanaGaugeData DataPrevious;
    [FieldOffset(0x2A0)] public ArcanaGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public ArcanaGauge GaugeStandard;
    [FieldOffset(0x3A8)] public ArcanaGaugeSimple GaugeSimple;
}

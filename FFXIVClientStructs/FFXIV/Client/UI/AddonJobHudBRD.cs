using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// BRD - Song Gauge
/// </summary>
[Addon("JobHudBRD0")]
[StructLayout(LayoutKind.Explicit, Size = 0x4C0)]
public unsafe partial struct AddonJobHudBRD0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct SongGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct SongGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public partial struct SongGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public SongGaugeData DataPrevious;
    [FieldOffset(0x2A0)] public SongGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public SongGauge GaugeStandard;
    [FieldOffset(0x3E0)] public SongGaugeSimple GaugeSimple;
}

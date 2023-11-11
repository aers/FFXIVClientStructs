using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// PLD - Oath Gauge
/// </summary>
[Addon("JobHudPLD0")]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe partial struct AddonJobHudPLD0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct OathGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct OathGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct OathGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public OathGaugeData DataPrevious;
    [FieldOffset(0x278)] public OathGaugeData DataCurrent;
    [FieldOffset(0x290)] public OathGauge GaugeStandard;
    [FieldOffset(0x2E8)] public OathGaugeSimple GaugeSimple;
}

using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// BLM - Elemental Gauge
/// </summary>
[Addon("JobHudBLM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x4E0)]
public unsafe partial struct AddonJobHudBLM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct ElementalGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x168)]
    public partial struct ElementalGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public partial struct ElementalGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public ElementalGaugeData DataPrevious;
    [FieldOffset(0x298)] public ElementalGaugeData DataCurrent;
    [FieldOffset(0x2D0)] public ElementalGauge GaugeStandard;
    [FieldOffset(0x438)] public ElementalGaugeSimple GaugeSimple;
}

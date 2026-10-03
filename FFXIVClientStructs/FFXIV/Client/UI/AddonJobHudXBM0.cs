using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// XBM - Beastmaster TP Gauge
/// </summary>
[Addon("JobHudXBM0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe partial struct AddonJobHudXBM0 {
    [FieldOffset(0x278)] public TPGaugeData DataPrevious;
    [FieldOffset(0x298)] public TPGaugeData DataCurrent;
    [FieldOffset(0x2B8)] public TPGauge GaugeStandard;
    [FieldOffset(0x328)] public TPGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct TPGaugeData;

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct TPGauge {
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray2<Gauge> _gauges;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x68)]
        public partial struct Gauge {
            [FieldOffset(0x0)] public TPGauge* Parrent;
        }
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct TPGaugeSimple {
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray2<Gauge> _gauges;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x58)]
        public partial struct Gauge {
            [FieldOffset(0x0)] public TPGaugeSimple* Parrent;
        }
    }
}

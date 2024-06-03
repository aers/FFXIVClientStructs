using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// SGE - Eukrasia Gauge
/// </summary>
[Addon("JobHudGFF0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct AddonJobHudGFF0 {
    [FieldOffset(0x260)] public EukrasiaGaugeData DataPrevious;
    [FieldOffset(0x270)] public EukrasiaGaugeData DataCurrent;
    [FieldOffset(0x280)] public EukrasiaGauge GaugeStandard;
    [FieldOffset(0x2A0)] public EukrasiaGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct EukrasiaGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray1<byte> _prerequisites;
        [FieldOffset(0x09)] public bool EukrasiaActive;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public bool EukrasiaActive;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct EukrasiaGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public bool EukrasiaActive;
    }
}

/// <summary>
/// SGE - Addersgall Gauge
/// </summary>
[Addon("JobHudGFF1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe partial struct AddonJobHudGFF1 {
    [FieldOffset(0x260)] public AddersgallGaugeData DataPrevious;
    [FieldOffset(0x280)] public AddersgallGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public AddersgallGauge GaugeStandard;
    [FieldOffset(0x310)] public AddersgallGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct AddersgallGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<byte> _prerequisites;
        [FieldOffset(0x0C)] public int Addersgall;
        [FieldOffset(0x10)] public int Addersting;
        [FieldOffset(0x14)] public int AddersgallTimer;
        [FieldOffset(0x18)] public int AddersgallTimerMax;
        [FieldOffset(0x1C)] public bool InCombat;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct AddersgallGauge {
        [FieldOffset(0x10)] public AtkResNode* AdderstingContainer;

        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _addersgallGem;

        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _adderstingGem;

        [FieldOffset(0x48)] public AtkResNode* TimerBar;
        [FieldOffset(0x50)] public AtkResNode* TimerFill;
        [FieldOffset(0x58)] public AtkResNode* Container;
        [FieldOffset(0x60)] public int Addersgall;
        [FieldOffset(0x64)] public int Addersting;
        [FieldOffset(0x68)] public int TimelineFrameId;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct AddersgallGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* AdderstingContainer;

        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _addersgallGem;

        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _adderstingGem;

        [FieldOffset(0x48)] public AtkComponentGaugeBar* TimerGaugeBar;
        [FieldOffset(0x50)] public int Addersgall;
        [FieldOffset(0x54)] public int Addersting;
        [FieldOffset(0x58)] public int AddersgallTimelineFrameId;
        [FieldOffset(0x5C)] public int AdderstingTimelineFrameId;
    }
}

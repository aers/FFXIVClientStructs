using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// DNC - Step Gauge
/// </summary>
[Addon("JobHudDNC0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3A8)]
public unsafe partial struct AddonJobHudDNC0 {
    [FieldOffset(0x270)] public StepGaugeData DataPrevious;
    [FieldOffset(0x2A0)] public StepGaugeData DataCurrent;
    [FieldOffset(0x2D0)] public StepGauge GaugeStandard;
    [FieldOffset(0x340)] public StepGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct StepGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<byte> _prerequisites;
        [FieldOffset(0x0C)] public int DanceStatus;
        [FieldOffset(0x10)] public int CompletedSteps;
        [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray4<int> _steps;
        [FieldOffset(0x24)] public int StandardFinishActive;
        [FieldOffset(0x28)] public int StandardFinishTimeLeft;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct StepGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public int DanceStatus;

        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentBase>> _stepIcons;

        [FieldOffset(0x40)] public int CompletedSteps;
        [FieldOffset(0x48)] public AtkResNode* StandardFinishTimerContainer;
        [FieldOffset(0x50)] public AtkResNode* StandardFinishTimerIcon;
        [FieldOffset(0x58)] public AtkTextNode* StandardFinishTimerText;
        [FieldOffset(0x60)] public int StandardFinishActive;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct StepGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public int DanceStatus;

        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentBase>> _stepIcons;

        [FieldOffset(0x40)] public int CompletedSteps;
        [FieldOffset(0x48)] public AtkResNode* StandardFinishTimerContainer;
        [FieldOffset(0x50)] public AtkResNode* StandardFinishTimerIcon;
        [FieldOffset(0x58)] public AtkTextNode* StandardFinishTimerText;
        [FieldOffset(0x60)] public int StandardFinishActive;
    }
}

/// <summary>
/// DNC - Fourfold Feathers
/// </summary>
[Addon("JobHudDNC1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3B8)]
public unsafe partial struct AddonJobHudDNC1 {
    [FieldOffset(0x270)] public FeatherGaugeData DataPrevious;
    [FieldOffset(0x290)] public FeatherGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public FeatherGauge GaugeStandard;
    [FieldOffset(0x348)] public FeatherGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct FeatherGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<byte> _prerequisites;
        [FieldOffset(0x0C)] public int FeatherCount;
        [FieldOffset(0x10)] public int EspritValue;
        [FieldOffset(0x14)] public int EspritMax;
        [FieldOffset(0x18)] public int EspritMid;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public partial struct FeatherGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* FeatherContainer;

        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentBase>> _feathers;

        [FieldOffset(0x40)] public int FeatherCount;
        [FieldOffset(0x48)] public AtkResNode* EspritBar;
        [FieldOffset(0x50)] public AtkResNode* EspritValueContainer;
        [FieldOffset(0x58)] public AtkTextNode* EspritValueText;
        [FieldOffset(0x60)] public AtkImageNode* EspritBarFill;
        [FieldOffset(0x68)] public AtkImageNode* EspritBarGain;
        [FieldOffset(0x70)] public AtkImageNode* EspritBarLoss;
        [FieldOffset(0x78)] public bool SaberDanceState;
        [FieldOffset(0x80)] public int EspritBarTargetValue;
        [FieldOffset(0x88)] public int EspritBarValue;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct FeatherGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* FeatherContainer;

        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentBase>> _feathers;

        [FieldOffset(0x40)] public int FeatherCount;
        [FieldOffset(0x48)] public AtkResNode* EspritBarContainer;
        [FieldOffset(0x50)] public AtkComponentGaugeBar* EspritGaugeBar;
        [FieldOffset(0x58)] public AtkResNode* EspritBarFill;
        [FieldOffset(0x60)] public AtkComponentTextNineGrid* EspritValueDisplay;
    }
}

using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// VPR - Vipersight
/// </summary>
[Addon("JobHudRDB0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe partial struct AddonJobHudRDB0 {

    [FieldOffset(0x278)] public VipersightGaugeData DataPrevious;
    [FieldOffset(0x290)] public VipersightGaugeData DataCurrent;
    [FieldOffset(0x2A8)] public VipersightGauge GaugeStandard;
    [FieldOffset(0x2C8)] public VipersightGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct VipersightGaugeData {
        [FieldOffset(0x08)] public bool Enabled;
        [FieldOffset(0x09)] public bool RattlingCoilsEnabled;
        [FieldOffset(0x0A)] public bool LeftGlow;
        [FieldOffset(0x0B)] public bool RightGlow;
        [FieldOffset(0x0C)] public int ComboStep;
        [FieldOffset(0x10)] public int CoilStacks;
        [FieldOffset(0x14)] public int CoilMax;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct VipersightGauge {
        [FieldOffset(0x10)] public ViperBladesStandard* ViperBlades;
        [FieldOffset(0x18)] public RattlingCoilStandard* RattlingCoil;

        [StructLayout(LayoutKind.Explicit, Size = 0x28)]
        public partial struct ViperBladesStandard {
            [FieldOffset(0x08)] public AtkComponentBase* LeftBlade;
            [FieldOffset(0x10)] public AtkComponentBase* RightBlade;
            [FieldOffset(0x18)] public bool LeftGlow;
            [FieldOffset(0x19)] public bool RightGlow;
            [FieldOffset(0x1c)] public int LeftTimelineFrameId;
            [FieldOffset(0x20)] public int RightTimelineFrameId;
            [FieldOffset(0x24)] public int ComboStep;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x48)]
        public partial struct RattlingCoilStandard {
            [FieldOffset(0x10)] public AtkResNode* VipersightContainer;
            [FieldOffset(0x18)] public AtkResNode* RattlingCoilContainer;
            [FieldOffset(0x20)] public AtkComponentBase* CoilStack1;
            [FieldOffset(0x28)] public AtkComponentBase* CoilStack2;
            [FieldOffset(0x30)] public AtkComponentBase* CoilStack3;
            [FieldOffset(0x38)] public bool Enabled;
            [FieldOffset(0x3C)] public int CoilStacks;
            [FieldOffset(0x40)] public int CoilMax;
        }
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct VipersightGaugeSimple {
        [FieldOffset(0x10)] public ViperBladesSimple* ViperBlades;
        [FieldOffset(0x18)] public RattlingCoilSimple* RattlingCoil;

        [StructLayout(LayoutKind.Explicit, Size = 0x40)]
        public partial struct ViperBladesSimple {
            [FieldOffset(0x08)] public AtkComponentBase* LeftBar;
            [FieldOffset(0x10)] public AtkComponentBase* RightBar;
            [FieldOffset(0x18)] public AtkResNode* LeftContainer;
            [FieldOffset(0x20)] public AtkResNode* RightContainer;
            [FieldOffset(0x30)] public bool LeftGlow;
            [FieldOffset(0x31)] public bool RightGlow;
            [FieldOffset(0x34)] public int LeftTimelineFrameId;
            [FieldOffset(0x38)] public int RightTimelineFrameId;
            [FieldOffset(0x3C)] public int ComboStep;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x40)]
        public partial struct RattlingCoilSimple {
            [FieldOffset(0x10)] public AtkResNode* VipersightContainer;
            [FieldOffset(0x18)] public AtkComponentBase* CoilStack1;
            [FieldOffset(0x20)] public AtkComponentBase* CoilStack2;
            [FieldOffset(0x28)] public AtkComponentBase* CoilStack3;
            [FieldOffset(0x30)] public bool Enabled;
            [FieldOffset(0x34)] public int CoilStacks;
            [FieldOffset(0x38)] public int CoilMax;
        }
    }
}

/// <summary>
/// VPR - Serpent Offerings Gauge
/// </summary>
[Addon("JobHudRDB1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x318)]
public unsafe partial struct AddonJobHudRDB1 {

    [FieldOffset(0x278)] public SerpentOfferingsGaugeData DataPrevious;
    [FieldOffset(0x2A8)] public SerpentOfferingsGaugeData DataCurrent;
    [FieldOffset(0x2D8)] public SerpentOfferingsGauge GaugeStandard;
    [FieldOffset(0x2F8)] public SerpentOfferingsGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct SerpentOfferingsGaugeData {
        [FieldOffset(0x08)] public bool Enabled;
        [FieldOffset(0x0C)] public int GaugeValue;
        [FieldOffset(0x10)] public int GaugeMid;
        [FieldOffset(0x14)] public int GaugeMax;
        [FieldOffset(0x18)] public bool TributesUnlocked;
        [FieldOffset(0x1C)] public int TributeStacks;
        [FieldOffset(0x20)] public int TributeMax;
        [FieldOffset(0x24)] public int TributeTimeLeft;
        [FieldOffset(0x28)] public int TributeMaxTime;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct SerpentOfferingsGauge {
        [FieldOffset(0x10)] public OfferingsBar* _offeringsBar;
        [FieldOffset(0x18)] public TributeCounter* _tributeCounter;

        [StructLayout(LayoutKind.Explicit, Size = 0x80)]
        public partial struct OfferingsBar {
            [FieldOffset(0x18)] public AtkResNode* SOContainer;
            [FieldOffset(0x20)] public AtkResNode* GaugeMarker;
            [FieldOffset(0x28)] public AtkResNode* GaugeFill;

            [FieldOffset(0x38)] public AtkTextNode* GaugeValueText;
            [FieldOffset(0x48)] public AtkResNode* GaugeFillContainer;

            [FieldOffset(0x58)] public AtkImageNode* MainFillNode;
            [FieldOffset(0x60)] public AtkImageNode* IncreaseFillNode;
            [FieldOffset(0x68)] public AtkImageNode* DecreaseFillNode;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x50)]
        public partial struct TributeCounter {
            [FieldOffset(0x10)] public int GlowTimelineFrameId;
            [FieldOffset(0x20)] public AtkTextNode* TributeTimerText;
            [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentBase>> _stacks;
        }
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct SerpentOfferingsGaugeSimple {
        [FieldOffset(0x10)] public OfferingsBarSimple* _offeringsBar;
        [FieldOffset(0x18)] public TributeCounterSimple* _tributeCounter;

        [StructLayout(LayoutKind.Explicit, Size = 0x40)]
        public partial struct OfferingsBarSimple {

            [FieldOffset(0x10)] public AtkComponentGaugeBar* GaugeBar;
            [FieldOffset(0x18)] public AtkComponentTextNineGrid* ValueDisplay;
            [FieldOffset(0x28)] public AtkResNode* BarContainer;
            [FieldOffset(0x30)] public AtkResNode* GaugeFill;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x48)]
        public partial struct TributeCounterSimple {
            [FieldOffset(0x10)] public int GlowTimelineFrameId;
            [FieldOffset(0x18)] public AtkComponentTextNineGrid* TimerDisplay;
            [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentBase>> _stacks;
        }
    }
}

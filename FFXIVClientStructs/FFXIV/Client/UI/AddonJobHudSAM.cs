using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// SAM - Kenki Gauge
/// </summary>
[Addon("JobHudSAM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct AddonJobHudSAM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct KenkiGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[3];
        [FieldOffset(0x0C)] public int MeditationStackCount;
        [FieldOffset(0x10)] public int KenkiValue;
        [FieldOffset(0x14)] public int KenkiMax;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct KenkiGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* KenkiContainer;
        [FieldOffset(0x18)] public AtkTextNode* KenkiValueText;
        [FieldOffset(0x20)] public AtkImageNode* KenkiBarFill;
        [FieldOffset(0x28)] public AtkImageNode* KenkiBarGain;
        [FieldOffset(0x30)] public AtkImageNode* KenkiBarLoss;
        [FieldOffset(0x38)] public AtkComponentBase* KenkiMarker;
        [FieldOffset(0x40)] public AtkResNode* MeditationContainer;

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x48)] public fixed byte MeditationGem[3 * 0x8];

        [FieldOffset(0x60)] public fixed byte HasMeditationStack[3];
        [FieldOffset(0x63)] public bool MeditationStacksGlowing;
        [FieldOffset(0x64)] public int MeditationStackCount;
        [FieldOffset(0x68)] public int GlowTimelineFrameId;
        [FieldOffset(0x6C)] public int MarkerPosition;
        [FieldOffset(0x70)] public int KenkiBarWidth; // Kenki Value * 2.76
        [FieldOffset(0x78)] public int KenkiBarMaxWidth; // 276
        [FieldOffset(0x7C)] public bool KenkiBarAnimating;
        [FieldOffset(0x7D)] public bool MarkerVisible;
        [FieldOffset(0x80)] public int MarkerOffset;
        [FieldOffset(0x84)] public float MarkerShift;
        [FieldOffset(0x88)] public bool KenkiCapped;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct KenkiGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;

        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* KenkiContainer;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* KenkiGaugeBar;
        [FieldOffset(0x28)] public AtkComponentTextNineGrid* KenkiValueDisplay;
        [FieldOffset(0x30)] public AtkResNode* MeditationContainer;

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x38)] public fixed byte MeditationStacks[3 * 0x8];

        [FieldOffset(0x50)] public fixed byte HasMeditationStack[3];
        [FieldOffset(0x53)] public bool MeditationStacksGlowing;
        [FieldOffset(0x54)] public int MeditationStackCount;
        [FieldOffset(0x58)] public int GlowTimelineFrameId;
        [FieldOffset(0x5C)] public bool KenkiCapped;
        [FieldOffset(0x5D)] public bool Visible;
    }

    [FieldOffset(0x260)] public KenkiGaugeData DataPrevious;
    [FieldOffset(0x278)] public KenkiGaugeData DataCurrent;
    [FieldOffset(0x290)] public KenkiGauge GaugeStandard;
    [FieldOffset(0x320)] public KenkiGaugeSimple GaugeSimple;
}

/// <summary>
/// SAM - Sen Gauge
/// </summary>
[Addon("JobHudSAM1")]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonJobHudSAM1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct SenGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[1];
        [FieldOffset(0x09)] public bool HasSetsu;
        [FieldOffset(0x0A)] public bool HasGetsu;
        [FieldOffset(0x0B)] public bool HasKa;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct SenGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* SetsuNode;
        [FieldOffset(0x20)] public AtkResNode* GetsuNode;
        [FieldOffset(0x28)] public AtkResNode* KaNode;
        [FieldOffset(0x30)] public AtkResNode* SetsuGlow;
        [FieldOffset(0x38)] public AtkResNode* GetsuGlow;
        [FieldOffset(0x40)] public AtkResNode* KaGlow;
        [FieldOffset(0x48)] public bool HasSetsu;
        [FieldOffset(0x49)] public bool HasGetsu;
        [FieldOffset(0x4A)] public bool HasKa;
        [FieldOffset(0x4C)] public int GlowTimelineFrameId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct SenGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Gems;
        [FieldOffset(0x20)] public AtkResNode* SetsuNode;
        [FieldOffset(0x28)] public AtkResNode* GetsuNode;
        [FieldOffset(0x30)] public AtkResNode* KaNode;
        [FieldOffset(0x38)] public AtkResNode* SetsuGlow;
        [FieldOffset(0x40)] public AtkResNode* GetsuGlow;
        [FieldOffset(0x48)] public AtkResNode* KaGlow;
        [FieldOffset(0x50)] public bool HasSetsu;
        [FieldOffset(0x51)] public bool HasGetsu;
        [FieldOffset(0x52)] public bool HasKa;
        [FieldOffset(0x53)] public bool HasAll;
    }

    [FieldOffset(0x260)] public SenGaugeData DataPrevious;
    [FieldOffset(0x270)] public SenGaugeData DataCurrent;
    [FieldOffset(0x280)] public SenGauge GaugeStandard;
    [FieldOffset(0x2D0)] public SenGaugeSimple GaugeSimple;
}

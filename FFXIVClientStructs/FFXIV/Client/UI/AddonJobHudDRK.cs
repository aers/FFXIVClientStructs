using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// DRK - Blood Gauge
/// </summary>
[Addon("JobHudDRK0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonJobHudDRK0 {
    [FieldOffset(0x270)] public BloodGaugeData DataPrevious;
    [FieldOffset(0x288)] public BloodGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public BloodGauge GaugeStandard;
    [FieldOffset(0x2E8)] public BloodGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct BloodGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<byte> _prerequisites;
        [FieldOffset(0x0A)] public byte TankStance;
        [FieldOffset(0x0C)] public int BloodValue;
        [FieldOffset(0x10)] public int BloodMax;
        [FieldOffset(0x14)] public int BloodMid;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct BloodGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* StanceGemContainer;
        [FieldOffset(0x20)] public AtkResNode* SwordGlow;
        [FieldOffset(0x28)] public AtkResNode* StanceGem;
        [FieldOffset(0x30)] public AtkTextNode* BloodValueText;
        [FieldOffset(0x38)] public AtkComponentGaugeBar* BloodGaugeBar;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct BloodGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* BarContainer;
        [FieldOffset(0x20)] public AtkComponentBase* StanceIcon;
        [FieldOffset(0x28)] public AtkComponentTextNineGrid* BloodValueDisplay;
        [FieldOffset(0x38)] public AtkComponentGaugeBar* BloodGaugeBar;
    }

}

/// <summary>
/// DRK - Darkside Gauge
/// </summary>
[Addon("JobHudDRK1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x348)]
public unsafe partial struct AddonJobHudDRK1 {
    [FieldOffset(0x270)] public DarksideGaugeData DataPrevious;
    [FieldOffset(0x288)] public DarksideGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public DarksideGauge GaugeStandard;
    [FieldOffset(0x300)] public DarksideGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct DarksideGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray3<byte> _prerequisites;
        [FieldOffset(0x0C)] public int DarksideTimeLeft;
        [FieldOffset(0x10)] public int DarksideTimeMax;
        [FieldOffset(0x14)] public int LivingShadowTimeLeft;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct DarksideGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* DarkArtsContainer;
        [FieldOffset(0x20)] public AtkResNode* DarkArts;
        [FieldOffset(0x30)] public AtkResNode* DarksideHelm;
        [FieldOffset(0x38)] public AtkTextNode* DarksideTimerText;
        [FieldOffset(0x48)] public AtkResNode* LivingShadowHelm;
        [FieldOffset(0x50)] public AtkTextNode* LivingShadowTimerText;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct DarksideGaugeSimple {
        [FieldOffset(0x10)] public AtkComponentBase* DarkArtsGem;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* DarksideGaugeBar;
        [FieldOffset(0x28)] public AtkComponentTextNineGrid* DarksideValueDisplay;
        [FieldOffset(0x30)] public AtkResNode* LivingShadow;
        [FieldOffset(0x38)] public AtkResNode* LivingShadowTimerDisplay;
    }
}

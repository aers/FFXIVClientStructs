using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// MCH - Heat Gauge
/// </summary>
[Addon("JobHudMCH0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe partial struct AddonJobHudMCH0 {

    [FieldOffset(0x270)] public HeatGaugeData DataPrevious;
    [FieldOffset(0x2A8)] public HeatGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public HeatGauge GaugeStandard;
    [FieldOffset(0x358)] public HeatGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct HeatGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<byte> _prerequisites;
        [FieldOffset(0x0C)] public int HeatValue;
        [FieldOffset(0x10)] public int HeatMax;
        [FieldOffset(0x14)] public int HeatMid;
        [FieldOffset(0x18)] public bool OverheatActive;
        [FieldOffset(0x1C)] public int OverheatTimeLeft;
        [FieldOffset(0x24)] public int BatteryValue;
        [FieldOffset(0x28)] public int BatteryMax;
        [FieldOffset(0x2C)] public int BatteryMid;
        [FieldOffset(0x30)] public bool SummonActive;
        [FieldOffset(0x34)] public int SummonTimeLeft;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public partial struct HeatGauge {
        [FieldOffset(0x10)] public AtkResNode* HeatContainer;
        [FieldOffset(0x18)] public AtkComponentGaugeBar* HeatGaugeBar;
        [FieldOffset(0x20)] public AtkComponentTextNineGrid* HeatValueDisplay;
        [FieldOffset(0x28)] public AtkResNode* OverheatTimer;
        [FieldOffset(0x30)] public AtkTextNode* OverheatTimerText;
        [FieldOffset(0x38)] public int OverheatState;
        [FieldOffset(0x40)] public AtkResNode* BatteryContainer;
        [FieldOffset(0x48)] public AtkComponentGaugeBar* BatteryGaugeBar;
        [FieldOffset(0x50)] public AtkComponentTextNineGrid* BatteryValueDisplay;
        [FieldOffset(0x58)] public AtkResNode* BatteryTimer;
        [FieldOffset(0x60)] public AtkResNode* BatteryTimerTextContainer;
        [FieldOffset(0x68)] public AtkTextNode* BatteryTimerText;
        [FieldOffset(0x70)] public int SummonState;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct HeatGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* HeatContainer;
        [FieldOffset(0x18)] public AtkComponentGaugeBar* HeatGaugeBar;
        [FieldOffset(0x20)] public AtkComponentTextNineGrid* HeatValueDisplay;
        [FieldOffset(0x28)] public AtkComponentTextNineGrid* OverheatTimerDisplay;
        [FieldOffset(0x30)] public int OverheatState;
        [FieldOffset(0x38)] public AtkResNode* BatteryContainer;
        [FieldOffset(0x40)] public AtkComponentGaugeBar* BatteryGaugeBar;
        [FieldOffset(0x48)] public AtkComponentTextNineGrid* BatteryValueDisplay;
        [FieldOffset(0x50)] public AtkResNode* BarFillContainer;
        [FieldOffset(0x58)] public AtkResNode* BatteryContainer2; // duplicate of 0x38
        [FieldOffset(0x60)] public AtkComponentTextNineGrid* SummonTimerDisplay;
    }
}

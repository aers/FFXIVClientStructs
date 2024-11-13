using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// WAR - Beast Gauge
/// </summary>
[Addon("JobHudWAR0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonJobHudWAR0 {
    [FieldOffset(0x278)] public BeastGaugeData DataPrevious;
    [FieldOffset(0x290)] public BeastGaugeData DataCurrent;
    [FieldOffset(0x2A8)] public BeastGauge GaugeStandard;
    [FieldOffset(0x300)] public BeastGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct BeastGaugeData {
        [FieldOffset(0x08)] public bool Enabled;
        [FieldOffset(0x09)] public bool BarEnabled;
        [FieldOffset(0x0A)] public bool TankStance;
        [FieldOffset(0x0C)] public int BeastValue;
        [FieldOffset(0x10)] public int BeastMax;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct BeastGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public AtkResNode* Container3;
        [FieldOffset(0x28)] public AtkComponentGaugeBar* BeastGaugeBar;
        [FieldOffset(0x30)] public AtkTextNode* BeastValueText;
        [FieldOffset(0x38)] public AtkComponentBase* StancePlateContainer;
        [FieldOffset(0x40)] public AtkResNode* StancePlate;
        [FieldOffset(0x48)] public AtkResNode* StanceGemLowLevel;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct BeastGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* BarContainer;
        [FieldOffset(0x18)] public AtkComponentGaugeBar* BeastGaugeBar;
        [FieldOffset(0x20)] public AtkResNode* BeastGaugeBarFill;
        [FieldOffset(0x28)] public AtkComponentTextNineGrid* BeastValueDisplay;
        [FieldOffset(0x30)] public AtkComponentBase* StanceIcon;
    }
}

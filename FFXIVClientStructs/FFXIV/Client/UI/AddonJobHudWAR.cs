using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// WAR - Beast Gauge
/// </summary>
[Addon("JobHudWAR0")]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonJobHudWAR0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct BeastGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[3];
        [FieldOffset(0x0C)] public int BeastValue;
        [FieldOffset(0x10)] public int BeastMax;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct BeastGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public AtkResNode* Container3;
        [FieldOffset(0x28)] public AtkComponentGaugeBar* BeastGaugeBar;
        [FieldOffset(0x30)] public AtkTextNode* BeastValueText;
        [FieldOffset(0x38)] public AtkComponentBase* StancePlateContainer;
        [FieldOffset(0x40)] public AtkResNode* StancePlate;
        [FieldOffset(0x48)] public AtkResNode* StanceGemLowLevel;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct BeastGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* BarContainer;
        [FieldOffset(0x18)] public AtkComponentGaugeBar* BeastGaugeBar;
        [FieldOffset(0x20)] public AtkResNode* BeastGaugeBarFill;
        [FieldOffset(0x28)] public AtkComponentTextNineGrid* BeastValueDisplay;
        [FieldOffset(0x30)] public AtkComponentBase* StanceIcon;
    }

    [FieldOffset(0x260)] public BeastGaugeData DataPrevious;
    [FieldOffset(0x278)] public BeastGaugeData DataCurrent;
    [FieldOffset(0x290)] public BeastGauge GaugeStandard;
    [FieldOffset(0x2E8)] public BeastGaugeSimple GaugeSimple;
}

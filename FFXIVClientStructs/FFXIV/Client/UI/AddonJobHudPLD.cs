using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// PLD - Oath Gauge
/// </summary>
[Addon("JobHudPLD0")]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe partial struct AddonJobHudPLD0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct OathGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[3];
        [FieldOffset(0x0C)] public int OathValue;
        [FieldOffset(0x10)] public int OathMax;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct OathGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* OathGaugeBar;
        [FieldOffset(0x28)] public AtkComponentBase* OathMarker;
        [FieldOffset(0x30)] public AtkTextNode* OathValueText;
        [FieldOffset(0x38)] public AtkComponentBase* StanceSigilContainer;
        [FieldOffset(0x40)] public AtkResNode* StanceSigil;
        [FieldOffset(0x48)] public AtkResNode* StanceGemLowLevel;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct OathGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x18)] public AtkResNode* Container;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* OathGaugeBar;
        [FieldOffset(0x28)] public AtkResNode* OathGaugeBarFill;
        [FieldOffset(0x30)] public AtkComponentTextNineGrid* OathValueDisplay;
        [FieldOffset(0x38)] public AtkComponentBase* StanceIcon;
    }

    [FieldOffset(0x260)] public OathGaugeData DataPrevious;
    [FieldOffset(0x278)] public OathGaugeData DataCurrent;
    [FieldOffset(0x290)] public OathGauge GaugeStandard;
    [FieldOffset(0x2E8)] public OathGaugeSimple GaugeSimple;
}

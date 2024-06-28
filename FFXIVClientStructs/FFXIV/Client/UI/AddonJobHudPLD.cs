using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// PLD - Oath Gauge
/// </summary>
[Addon("JobHudPLD0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonJobHudPLD0 {
    [FieldOffset(0x270)] public OathGaugeData DataPrevious;
    [FieldOffset(0x288)] public OathGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public OathGauge GaugeStandard;
    [FieldOffset(0x2F8)] public OathGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct OathGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray3<byte> _prerequisites;
        [FieldOffset(0x0C)] public int OathValue;
        [FieldOffset(0x10)] public int OathMax;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct OathGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* OathGaugeBar;
        [FieldOffset(0x28)] public AtkComponentBase* OathMarker;
        [FieldOffset(0x30)] public AtkTextNode* OathValueText;
        [FieldOffset(0x38)] public AtkComponentBase* StanceSigilContainer;
        [FieldOffset(0x40)] public AtkResNode* StanceSigil;
        [FieldOffset(0x48)] public AtkResNode* StanceGemLowLevel;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct OathGaugeSimple {
        [FieldOffset(0x18)] public AtkResNode* Container;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* OathGaugeBar;
        [FieldOffset(0x28)] public AtkResNode* OathGaugeBarFill;
        [FieldOffset(0x30)] public AtkComponentTextNineGrid* OathValueDisplay;
        [FieldOffset(0x38)] public AtkComponentBase* StanceIcon;
    }

}

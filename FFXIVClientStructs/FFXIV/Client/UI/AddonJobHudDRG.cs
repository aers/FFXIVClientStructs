using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// DRG - Dragon Gauge
/// </summary>
[Addon("JobHudDRG0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public unsafe partial struct AddonJobHudDRG0 {
    [FieldOffset(0x278)] public DragonGaugeData DataPrevious;
    [FieldOffset(0x298)] public DragonGaugeData DataCurrent;
    [FieldOffset(0x2B8)] public DragonGauge GaugeStandard;
    [FieldOffset(0x300)] public DragonGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct DragonGaugeData {
        [FieldOffset(0x08)] public bool Enabled;
        [FieldOffset(0x09)] public bool FirstMindsFocusEnabled;
        [FieldOffset(0x0C)] public int LotDStatus;
        [FieldOffset(0x10)] public int LotDTimer;
        [FieldOffset(0x14)] public int LotDMax;
        [FieldOffset(0x18)] public int FirstMindsFocusCount;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct DragonGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public int LotDStatus;
        [FieldOffset(0x28)] public AtkTextNode* LotDTimerText;
        [FieldOffset(0x30)] public AtkComponentGaugeBar* LotDTimerGaugeBar;
        [FieldOffset(0x38)] public AtkResNode* FirstMindsFocusContainer;
        [FieldOffset(0x40)] public AtkResNode* FirstMindsFocusContainer2;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public partial struct DragonGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkComponentTextNineGrid* LotDTimerDisplay;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* LotDTimerGaugeBar;
        [FieldOffset(0x28)] public AtkResNode* FirstMindsFocusContainer;
        [FieldOffset(0x30)] public AtkResNode* FirstMindsFocusContainer2;
        [FieldOffset(0x38)] public bool FirstMindsFocusReady;
        [FieldOffset(0x40)] public AtkComponentBase* FirstMindsFocus1;
        [FieldOffset(0x48)] public AtkResNode* FirstMindsFocusGlow1;
        [FieldOffset(0x50)] public AtkComponentBase* FirstMindsFocus2;
        [FieldOffset(0x58)] public AtkResNode* FirstMindsFocusGlow2;
    }
}

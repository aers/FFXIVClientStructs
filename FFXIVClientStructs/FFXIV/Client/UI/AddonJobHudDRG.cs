using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// DRG - Dragon Gauge
/// </summary>
[Addon("JobHudDRG0")]
[StructLayout(LayoutKind.Explicit, Size = 0x398)]
public unsafe partial struct AddonJobHudDRG0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct DragonGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[3];
        [FieldOffset(0x0C)] public int LotDStatus; // set to 2 while LotD is active (may get set to 1 at a lower level range?)
        [FieldOffset(0x10)] public int LotDTimer;
        [FieldOffset(0x14)] public int LotDMax;
        [FieldOffset(0x18)] public int EyeCount;
        [FieldOffset(0x1C)] public int FirstMindsFocusCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct DragonGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public int LotDStatus;
        [FieldOffset(0x28)] public AtkTextNode* LotDTimerText;
        [FieldOffset(0x30)] public AtkComponentGaugeBar* LotDTimerGaugeBar;
        [FieldOffset(0x38)] public AtkResNode* EyeNode;
        [FieldOffset(0x40)] public AtkResNode* DragonSilhouette;
        [FieldOffset(0x48)] public AtkResNode* FirstMindsFocusContainer;
        [FieldOffset(0x50)] public AtkResNode* FirstMindsFocusContainer2;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct DragonGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkComponentTextNineGrid* LotDTimerDisplay;
        [FieldOffset(0x20)] public AtkComponentGaugeBar* LotDTimerGaugeBar;
        [FieldOffset(0x28)] public AtkResNode* GemContainer;
        [FieldOffset(0x30)] public AtkResNode* EyeContainer;
        [FieldOffset(0x38)] public bool LotDReady;
        [FieldOffset(0x40)] public AtkComponentBase* Eye1;
        [FieldOffset(0x48)] public AtkResNode* EyeGlow1;
        [FieldOffset(0x50)] public AtkComponentBase* Eye2;
        [FieldOffset(0x58)] public AtkResNode* EyeGlow2;
        [FieldOffset(0x60)] public AtkResNode* FirstMindsFocusContainer;
        [FieldOffset(0x68)] public bool FirstMindsFocusReady;
        [FieldOffset(0x70)] public AtkComponentBase* FirstMindsFocus1;
        [FieldOffset(0x78)] public AtkResNode* FirstMindsFocusGlow1;
        [FieldOffset(0x80)] public AtkComponentBase* FirstMindsFocus2;
        [FieldOffset(0x88)] public AtkResNode* FirstMindsFocusGlow2;
    }

    [FieldOffset(0x260)] public DragonGaugeData DataPrevious;
    [FieldOffset(0x288)] public DragonGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public DragonGauge GaugeStandard;
    [FieldOffset(0x308)] public DragonGaugeSimple GaugeSimple;
}

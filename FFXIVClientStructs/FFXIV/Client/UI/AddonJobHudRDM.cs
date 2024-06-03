using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// RDM - Balance Gauge
/// </summary>
[Addon("JobHudRDM0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct AddonJobHudRDM0 {
    [FieldOffset(0x260)] public BalanceGaugeData DataPrevious;
    [FieldOffset(0x288)] public BalanceGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public BalanceGauge GaugeStandard;
    [FieldOffset(0x3B0)] public BalanceGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct BalanceGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray3<byte> _prerequisites;
        [FieldOffset(0x0C)] public int BlackMana;
        [FieldOffset(0x10)] public int WhiteMana;
        [FieldOffset(0x14)] public int MaxMana;
        [FieldOffset(0x18)] public int BlackMidMana;
        [FieldOffset(0x1C)] public int WhiteMidMana;
        [FieldOffset(0x20)] public int ManaStacks;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct BalanceGauge {
        [FieldOffset(0x10)] public ManaBar BlackManaBar;
        [FieldOffset(0x58)] public ManaBar WhiteManaBar;
        [FieldOffset(0xA0)] public AtkResNode* Container;
        [FieldOffset(0xA8)] public AtkResNode* EffectsContainer;
        [FieldOffset(0xB0)] public AtkResNode* Effects;
        [FieldOffset(0xB8)] public AtkResNode* BarContainer;
        [FieldOffset(0xC0)] public AtkResNode* BarBackDrop;
        [FieldOffset(0xC8)] public AtkComponentBase* ManaStackContainer;

        [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _manaStacks;

        [FieldOffset(0xE8)] public bool ComboFlash; // usually 0, flashes to 1 when combo becomes ready
        [FieldOffset(0xE9)] public bool NoComboFlash; // usually 1, flashes to 0 when combo becomes ready
        [FieldOffset(0xEC)] public int EffectsPosition; // the height to place animation effects (calculated based partly on the average of the two bars)
        [FieldOffset(0xF0)] public bool ComboReady;
        [FieldOffset(0xF4)] public int CrystalState; // 0 = default (Grey), 1 = Black Imbalance, 2 = White Imbalance, 3 = Combo Ready (Red)
        [FieldOffset(0xF8)] public int ManaStackCount;

        [StructLayout(LayoutKind.Explicit, Size = 0x48)]
        public partial struct ManaBar {
            [FieldOffset(0x00)] public AtkComponentBase* Container;
            [FieldOffset(0x08)] public AtkTextNode* ValueText;
            [FieldOffset(0x10)] public AtkImageNode* BarFill;
            [FieldOffset(0x18)] public AtkImageNode* BarGain;
            [FieldOffset(0x20)] public AtkImageNode* BarLoss;
            [FieldOffset(0x28)] public int BarHeight;
            [FieldOffset(0x2C)] public int BarTargetHeight;
            [FieldOffset(0x30)] public float HeightAdjust;
            [FieldOffset(0x34)] public int MaxHeight;
            [FieldOffset(0x38)] public int Value;
            [FieldOffset(0x3C)] public int IsAnimating;
            [FieldOffset(0x40)] public int TimelineFrameId;
        }
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public partial struct BalanceGaugeSimple {
        [FieldOffset(0x10)] public AtkComponentGaugeBar* BlackManaGaugeBar;
        [FieldOffset(0x18)] public AtkComponentGaugeBar* WhiteManaGaugeBar;

        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray2<Pointer<AtkComponentTextNineGrid>> _manaValueDisplay;

        [FieldOffset(0x38)] public AtkResNode* BarContainer;
        [FieldOffset(0x40)] public AtkResNode* Crystal;
        [FieldOffset(0x48)] public AtkComponentBase* Crystal2;
        [FieldOffset(0x50)] public AtkResNode* Container;
        [FieldOffset(0x58)] public AtkResNode* ManaStackContainer;
        [FieldOffset(0x60)] public AtkResNode* ManaStackGlow;
        [FieldOffset(0x68)] public AtkComponentBase* ManaStack1;
        [FieldOffset(0x70)] public AtkComponentBase* ManaStack2;
        [FieldOffset(0x78)] public AtkComponentBase* ManaStack3;

        [FieldOffset(0x80)] public int ComboReadyState; // becomes 1 at 50, 2 at 100
        [FieldOffset(0x84)] public int CrystalState; // 0 = default (Grey), 1 = Black Imbalance, 2 = White Imbalance, 3 = Combo Ready (Red)
        [FieldOffset(0x88)] public bool ComboReady; // becomes 1 at 50
        [FieldOffset(0x8C)] public int ManaStackCount;
    }
}

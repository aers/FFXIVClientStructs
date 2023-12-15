using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// RPR - Soul Gauge
/// </summary>
[Addon("JobHudRRP0")]
[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
public unsafe partial struct AddonJobHudRRP0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct SoulGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[2];
        [FieldOffset(0x0C)] public int SoulValue;
        [FieldOffset(0x10)] public int ShroudValue;
        [FieldOffset(0x14)] public int SoulMax;
        [FieldOffset(0x18)] public int ShroudMax;
        [FieldOffset(0x1C)] public int SoulMid;
        [FieldOffset(0x20)] public int ShroudMid;
        [FieldOffset(0x24)] public bool Enshrouded;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xF8)]
    public partial struct SoulGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* Container2;
        [FieldOffset(0x20)] public AtkComponentBase* SoulMarker;
        [FieldOffset(0x28)] public AtkResNode* SoulBarOutline;
        [FieldOffset(0x30)] public AtkResNode* SoulBarEffects;
        [FieldOffset(0x38)] public AtkImageNode* SoulBarFill;
        [FieldOffset(0x40)] public AtkImageNode* SoulBarGain;
        [FieldOffset(0x48)] public AtkImageNode* SoulBarLoss;
        [FieldOffset(0x80)] public AtkComponentBase* SoulTextContainer;
        [FieldOffset(0x88)] public AtkComponentBase* ShroudMarker;
        [FieldOffset(0x90)] public AtkResNode* ShroudBarOutline;
        [FieldOffset(0x98)] public AtkResNode* ShroudBarEffects;
        [FieldOffset(0xA0)] public AtkImageNode* ShroudBarFill;
        [FieldOffset(0xA8)] public AtkImageNode* ShroudBarGain;
        [FieldOffset(0xB0)] public AtkImageNode* ShroudBarLoss;
        [FieldOffset(0xE8)] public AtkComponentBase* ShroudTextContainer;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public partial struct SoulGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* ShroudContainer; // no equiv. pointer to SoulContainer, strangely
        [FieldOffset(0x20)] public AtkComponentGaugeBar* SoulGaugeBar;
        [FieldOffset(0x28)] public AtkComponentTextNineGrid* SoulValueDisplay;
        [FieldOffset(0x38)] public AtkComponentGaugeBar* ShroudGaugeBar;
        [FieldOffset(0x40)] public AtkComponentTextNineGrid* ShroudValueDisplay;
        [FieldOffset(0x4C)] public int GlowTimelineFrameId;
    }

    [FieldOffset(0x260)] public SoulGaugeData DataPrevious;
    [FieldOffset(0x288)] public SoulGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public SoulGauge GaugeStandard;
    [FieldOffset(0x3A8)] public SoulGaugeSimple GaugeSimple;
}

/// <summary>
/// RPR - Death Gauge
/// </summary>
[Addon("JobHudRRP1")]
[StructLayout(LayoutKind.Explicit, Size = 0x490)]
public unsafe partial struct AddonJobHudRRP1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct DeathGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[2];
        [FieldOffset(0x0C)] public int LemureShroudStacks;
        [FieldOffset(0x10)] public int VoidShroudStacks;
        [FieldOffset(0x14)] public int EnshroudTimer;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x118)]
    public partial struct DeathGauge {
        [FieldOffset(0x000)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x010)] public AtkResNode* Container;

        [StructLayout(LayoutKind.Explicit, Size = Size)]
        public partial struct ShroudStack {
            public const int Size = 0x30;
            [FieldOffset(0x08)] public AtkComponentBase* Container;
            [FieldOffset(0x10)] public AtkResNode* LemureStack;
            [FieldOffset(0x18)] public AtkResNode* LemureFlame;
            [FieldOffset(0x20)] public AtkResNode* VoidStack;
            [FieldOffset(0x28)] public AtkResNode* VoidFlame;
        }

        [FixedSizeArray<ShroudStack>(5)]
        [FieldOffset(0x018)] public fixed byte ShroudStacks[5 * ShroudStack.Size];

        [FieldOffset(0x110)] public AtkComponentTextNineGrid* EnshroudTimerDisplay;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct DeathGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x010)] public AtkResNode* Container;
        [FieldOffset(0x018)] public AtkResNode* EnshroudIndicator;

        [StructLayout(LayoutKind.Explicit, Size = Size)]
        public partial struct ShroudStackSimple {
            public const int Size = 0x20;
            [FieldOffset(0x04)] public AtkComponentBase* Container;
            [FieldOffset(0x0C)] public AtkResNode* GlowContainer;
            [FieldOffset(0x14)] public AtkResNode* Glow;
        }

        [FixedSizeArray<ShroudStackSimple>(5)]
        [FieldOffset(0x02C)] public fixed byte ShroudStacks[5 * ShroudStackSimple.Size];

        [FieldOffset(0xD0)] public AtkComponentTextNineGrid* EnshroudTimerDisplay;
    }

    [FieldOffset(0x260)] public DeathGaugeData DataPrevious;
    [FieldOffset(0x280)] public DeathGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public DeathGauge GaugeStandard;
    [FieldOffset(0x3B8)] public DeathGaugeSimple GaugeSimple;
}

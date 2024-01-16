using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// MNK - Master's Gauge
/// </summary>
[Addon("JobHudMNK0")]
[StructLayout(LayoutKind.Explicit, Size = 0x420)]
public unsafe partial struct AddonJobHudMNK0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct MastersGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[2];
        [FieldOffset(0x0C)] public int BeastChakra1;
        [FieldOffset(0x10)] public int BeastChakra2;
        [FieldOffset(0x14)] public int BeastChakra3;
        [FieldOffset(0x18)] public bool LunarNadi;
        [FieldOffset(0x19)] public bool SolarNadi;
        [FieldOffset(0x1C)] public int BlitzTimeRemaining;
        [FieldOffset(0x20)] public int BlitzType;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public partial struct MastersGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* NadiContainer;
        [FieldOffset(0x18)] public AtkComponentBase* BeastChakra1;
        [FieldOffset(0x20)] public AtkResNode* BeastChakraIcon1;
        [FieldOffset(0x28)] public AtkComponentBase* BeastChakra2;
        [FieldOffset(0x30)] public AtkResNode* BeastChakraIcon2;
        [FieldOffset(0x38)] public AtkComponentBase* BeastChakra3;
        [FieldOffset(0x40)] public AtkResNode* BeastChakraIcon3;
        [FieldOffset(0x60)] public AtkComponentBase* LunarNadi;
        [FieldOffset(0x68)] public AtkComponentBase* SolarNadi;
        [FieldOffset(0x70)] public AtkResNode* NadiIcons;
        [FieldOffset(0x80)] public AtkResNode* BlitzTimer;
        [FieldOffset(0x88)] public AtkTextNode* BlitzTimerText;
        [FieldOffset(0x90)] public bool BlitzActive;
        [FieldOffset(0x94)] public int BlitzType;
        [FieldOffset(0xA0)] public AtkResNode* Nadi;
        [FieldOffset(0xA8)] public AtkResNode* BeastChakraSlots;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public partial struct MastersGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
    }

    [FieldOffset(0x260)] public MastersGaugeData DataPrevious;
    [FieldOffset(0x288)] public MastersGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public MastersGauge GaugeStandard;
    [FieldOffset(0x360)] public MastersGaugeSimple GaugeSimple;
}

/// <summary>
/// MNK - Chakra Gauge
/// </summary>
[Addon("JobHudMNK1")]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonJobHudMNK1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct ChakraGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[1];
        [FieldOffset(0x0C)] public int ChakraCount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct ChakraGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;

        [FixedSizeArray<Pointer<AtkComponentBase>>(5)]
        [FieldOffset(0x18)] public fixed byte Chakra[5 * 0x8];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct ChakraGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;

        [FixedSizeArray<Pointer<AtkComponentBase>>(5)]
        [FieldOffset(0x18)] public fixed byte Chakra[5 * 0x8];

        [FieldOffset(0x40)] public bool ChakraCapped;
    }

    [FieldOffset(0x260)] public ChakraGaugeData DataPrevious;
    [FieldOffset(0x270)] public ChakraGaugeData DataCurrent;
    [FieldOffset(0x280)] public ChakraGauge GaugeStandard;
    [FieldOffset(0x2C0)] public ChakraGaugeSimple GaugeSimple;
}

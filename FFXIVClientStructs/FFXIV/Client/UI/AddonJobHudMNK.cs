using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// MNK - Beast Chakra Gauge
/// </summary>
[Addon("JobHudMNK0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x4A8)]
public unsafe partial struct AddonJobHudMNK0 {
    [FieldOffset(0x278)] public BeastChakraGaugeData DataPrevious;
    [FieldOffset(0x2B0)] public BeastChakraGaugeData DataCurrent;
    [FieldOffset(0x2E8)] public BeastChakraGauge GaugeStandard;
    [FieldOffset(0x3C0)] public BeastChakraGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct BeastChakraGaugeData {
        [FieldOffset(0x08)] public bool Enabled;
        [FieldOffset(0x09)] public bool BeastChakraEnabled;
        [FieldOffset(0x0A)] public bool NadiEnabled;
        [FieldOffset(0x0C)] public int BeastChakra1;
        [FieldOffset(0x10)] public int BeastChakra2;
        [FieldOffset(0x14)] public int BeastChakra3;
        [FieldOffset(0x18)] public bool LunarNadi;
        [FieldOffset(0x19)] public bool SolarNadi;
        [FieldOffset(0x1C)] public int BlitzTimeRemaining;
        [FieldOffset(0x20)] public int BlitzType;
        [FieldOffset(0x25)] public bool OpoOpoEnabled;
        [FieldOffset(0x26)] public bool RaptorEnabled;
        [FieldOffset(0x27)] public bool CoeurlEnabled;
        [FieldOffset(0x28)] public int OpoOpoCount;
        [FieldOffset(0x2C)] public int RaptorCount;
        [FieldOffset(0x30)] public int CoeurlCount;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xD8)]
    public partial struct BeastChakraGauge {
        [FieldOffset(0x10)] public AtkResNode* NadiContainer;
        [FieldOffset(0x18)] public AtkComponentBase* BeastChakra1;
        [FieldOffset(0x20)] public AtkResNode* BeastChakraIcon1;
        [FieldOffset(0x28)] public AtkResNode* BeastChakraId1;
        [FieldOffset(0x30)] public AtkComponentBase* BeastChakra2;
        [FieldOffset(0x38)] public AtkResNode* BeastChakraIcon2;
        [FieldOffset(0x40)] public AtkResNode* BeastChakraId2;
        [FieldOffset(0x48)] public AtkComponentBase* BeastChakra3;
        [FieldOffset(0x50)] public AtkResNode* BeastChakraIcon3;
        [FieldOffset(0x58)] public AtkResNode* BeastChakraId3;
        [FieldOffset(0x60)] public AtkComponentBase* LunarNadi;
        [FieldOffset(0x68)] public AtkComponentBase* SolarNadi;
        [FieldOffset(0x70)] public AtkResNode* NadiIcons;
        [FieldOffset(0x80)] public AtkResNode* BlitzTimer;
        [FieldOffset(0x88)] public AtkTextNode* BlitzTimerText;
        [FieldOffset(0x90)] public bool BlitzActive;
        [FieldOffset(0x94)] public int BlitzType;
        [FieldOffset(0xA0)] public AtkResNode* Nadi;
        [FieldOffset(0xA8)] public AtkResNode* BeastChakraSlots;
        [FieldOffset(0xB0)] public AtkResNode* Container;
        [FieldOffset(0xB8)] public AtkComponentBase* OpoOpoStack1;
        [FieldOffset(0xC0)] public AtkComponentBase* RaptorStack1;
        [FieldOffset(0xC8)] public AtkComponentBase* CoeurlStack1;
        [FieldOffset(0xD0)] public AtkComponentBase* CoeurlStack2;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xE8)]
    public partial struct BeastChakraGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* NadiContainer;
        [FieldOffset(0x18)] public AtkComponentBase* BeastChakra1;
        [FieldOffset(0x20)] public AtkResNode* BeastChakraIconContainer1;
        [FieldOffset(0x28)] public AtkResNode* BeastChakraIcon1;
        [FieldOffset(0x30)] public int BeastChakraId1;
        [FieldOffset(0x38)] public AtkComponentBase* BeastChakra2;
        [FieldOffset(0x40)] public AtkResNode* BeastChakraIconContainer2;
        [FieldOffset(0x48)] public AtkResNode* BeastChakraIcon2;
        [FieldOffset(0x50)] public int BeastChakraId2;
        [FieldOffset(0x58)] public AtkComponentBase* BeastChakra3;
        [FieldOffset(0x60)] public AtkResNode* BeastChakraIconContainer3;
        [FieldOffset(0x68)] public AtkResNode* BeastChakraIcon3;
        [FieldOffset(0x70)] public int BeastChakraId3;
        [FieldOffset(0x78)] public AtkComponentBase* LunarNadi;
        [FieldOffset(0x80)] public AtkComponentBase* SolarNadi;
        [FieldOffset(0x90)] public AtkResNode* BlitzTimer;
        [FieldOffset(0x98)] public AtkComponentTextNineGrid* BlitzTimerDisplay;
        [FieldOffset(0xA8)] public AtkResNode* LunarNadiFlash;
        [FieldOffset(0xB0)] public AtkResNode* SolarNadiFlash;
        [FieldOffset(0xC0)] public AtkResNode* Container;
        [FieldOffset(0xC8)] public AtkComponentBase* OpoOpoStack1;
        [FieldOffset(0xD0)] public AtkComponentBase* RaptorStack1;
        [FieldOffset(0xD8)] public AtkComponentBase* CoeurlStack1;
        [FieldOffset(0xE0)] public AtkComponentBase* CoeurlStack2;
    }
}

/// <summary>
/// MNK - Chakra Gauge
/// </summary>
[Addon("JobHudMNK1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x418)]
public unsafe partial struct AddonJobHudMNK1 {
    [FieldOffset(0x278)] public ChakraGaugeData DataPrevious;
    [FieldOffset(0x290)] public ChakraGaugeData DataCurrent;
    [FieldOffset(0x2A8)] public ChakraGauge GaugeStandard;
    [FieldOffset(0x348)] public ChakraGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct ChakraGaugeData {
        [FieldOffset(0x08)] public bool Enabled;
        [FieldOffset(0x0C)] public int ChakraCount;
        [FieldOffset(0x10)] public bool CounterGlowActive;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct ChakraGauge {

        [FieldOffset(0x10)] public AtkResNode* Container;

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public partial struct Chakra {
            //7FF716828A28
            [FieldOffset(0x08)] public AtkComponentBase* Icon;
            [FieldOffset(0x10)] public bool Active;
        }

        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray5<Chakra> _chakras;


        [FieldOffset(0x90)] public AtkResNode* CounterGlow;
        [FieldOffset(0x98)] public bool CounterGlowActive;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xD0)]
    public partial struct ChakraGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;

        [StructLayout(LayoutKind.Explicit, Size = 0x20)]
        public partial struct ChakraSimple {
            //7FF716828A88
            [FieldOffset(0x08)] public AtkComponentBase* Icon;
            [FieldOffset(0x10)] public bool Active;
        }

        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray5<ChakraSimple> _chakras;

        [FieldOffset(0xC0)] public AtkResNode* CounterGlow;
        [FieldOffset(0xC8)] public bool CounterGlowActive;
    }
}

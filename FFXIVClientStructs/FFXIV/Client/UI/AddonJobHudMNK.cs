using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// MNK - Master's Gauge
/// </summary>
[Addon("JobHudMNK0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x4C0)]
public unsafe partial struct AddonJobHudMNK0 {
    [FieldOffset(0x270)] public MastersGaugeData DataPrevious;
    [FieldOffset(0x2A8)] public MastersGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public MastersGauge GaugeStandard;
    [FieldOffset(0x3C8)] public MastersGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct MastersGaugeData {

        // Increased Size in 7.0, many fields likely similar

        /* [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<byte> _prerequisites;
         [FieldOffset(0x0C)] public int BeastChakra1;
         [FieldOffset(0x10)] public int BeastChakra2;
         [FieldOffset(0x14)] public int BeastChakra3;
         [FieldOffset(0x18)] public bool LunarNadi;
         [FieldOffset(0x19)] public bool SolarNadi;
         [FieldOffset(0x1C)] public int BlitzTimeRemaining;
         [FieldOffset(0x20)] public int BlitzType;*/
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xE8)]
    public partial struct MastersGauge {

        // Increased Size in 7.0, many fields likely similar

        /*  [FieldOffset(0x10)] public AtkResNode* NadiContainer;
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
          [FieldOffset(0xA8)] public AtkResNode* BeastChakraSlots;*/
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xF8)]
    public partial struct MastersGaugeSimple {

    }
}

/// <summary>
/// MNK - Chakra Gauge
/// </summary>
[Addon("JobHudMNK1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x410)]
public unsafe partial struct AddonJobHudMNK1 {
    [FieldOffset(0x270)] public ChakraGaugeData DataPrevious;
    [FieldOffset(0x288)] public ChakraGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public ChakraGauge GaugeStandard;
    [FieldOffset(0x340)] public ChakraGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct ChakraGaugeData {

        /*[FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray1<byte> _prerequisites;
        [FieldOffset(0x0C)] public int ChakraCount;*/
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct ChakraGauge {

        /*    [FieldOffset(0x10)] public AtkResNode* Container;
            [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentBase>> _chakra;*/
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xD0)]
    public partial struct ChakraGaugeSimple {
        /*  [FieldOffset(0x10)] public AtkResNode* Container;

          [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentBase>> _chakra;

          [FieldOffset(0x40)] public bool ChakraCapped;*/
    }
}

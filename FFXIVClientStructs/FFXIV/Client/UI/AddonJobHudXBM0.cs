using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// XBM - Beastmaster TP Gauge
/// </summary>
[Addon("JobHudXBM0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x458)]
public unsafe partial struct AddonJobHudXBM0 {
    [FieldOffset(0x278)] public TPGaugeData DataPrevious;
    [FieldOffset(0x298)] public TPGaugeData DataCurrent;
    [FieldOffset(0x2B8)] public TPGauge GaugeStandard;
    [FieldOffset(0x398)] public TPGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct TPGaugeData;

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public partial struct TPGauge {
        /// <summary>
        /// [0] = Self<br/>
        /// [1] = Beast
        /// </summary>
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray2<Gauge> _gauges;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x68)]
        public partial struct Gauge {
            [FieldOffset(0x0)] public TPGauge* Parent;
            /// <summary>
            /// Used to toggle the display of the component bases for the instinct marks.
            /// </summary>
            [FieldOffset(0x8)] public AtkResNode* InstinctContainer;
            /// <summary>
            /// Used to toggle the display of the image.<br/>
            /// This is not the actual AtkImageNode but the parent of the node to toggle visibility.
            /// </summary>
            [FieldOffset(0x10)] public AtkResNode* InstinctImageContainer;
            /// <summary>
            /// Used to toggle the display of the TP gauge.
            /// </summary>
            [FieldOffset(0x18)] public AtkResNode* GaugeContainer;
            /// <summary>
            /// Used to toggle the display of the image on the left of the TP gauge.<br/>
            /// This is not the actual AtkImageNode but the parent of the node to toggle visibility.
            /// </summary>
            [FieldOffset(0x20)] public AtkResNode* GaugeImageContainer;
            [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _instinctComponentBases;
            [FieldOffset(0x40)] public AtkComponentGaugeBar* TPGaugeBar;
            [FieldOffset(0x48)] public AtkComponentTextNineGrid* TPText;
            /// <summary>
            /// Holds an <see cref="AtkImageNode"/> as a child which is the outer glow used in tandem with timeline on the node.
            /// </summary>
            [FieldOffset(0x50)] private AtkResNode* InstinctGlowContainer;
        }
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public partial struct TPGaugeSimple {
        /// <summary>
        /// [0] = Self<br/>
        /// [1] = Beast
        /// </summary>
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray2<Gauge> _gauges;

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x58)]
        public partial struct Gauge {
            [FieldOffset(0x0)] public TPGaugeSimple* Parent;
            /// <summary>
            /// Used to toggle the display of the component bases for the instinct marks.
            /// </summary>
            [FieldOffset(0x8)] public AtkResNode* InstinctContainer;
            /// <summary>
            /// Used to toggle the display of the TP gauge.
            /// </summary>
            [FieldOffset(0x10)] public AtkResNode* GaugeContainer;
            /// <summary>
            /// Used to toggle the display of the image on the left of the TP gauge.<br/>
            /// This is not the actual AtkImageNode but the parent of the node to toggle visibility.
            /// </summary>
            [FieldOffset(0x18)] public AtkResNode* GaugeImageContainer;
            [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _instinctComponentBases;
            [FieldOffset(0x38)] public AtkComponentGaugeBar* TPGaugeBar;
            [FieldOffset(0x40)] public AtkComponentTextNineGrid* TPText;
        }
    }
}

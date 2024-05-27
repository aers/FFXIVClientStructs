namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentGaugeBar
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 5
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct AtkComponentGaugeBar {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;

    /// <summary>
    /// Data describing a value transition. Informs the fields in <see cref="GaugeValue"/>. These fields aren't overwritten until the next transition of the same type occurs.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeValueTransition {
        public const int Size = 0x10;
        [FieldOffset(0x00)] public int StartValue;
        [FieldOffset(0x04)] public int EndValue;
        [FieldOffset(0x08)] public float Progress;
        [FieldOffset(0x0C)] public float TransitionLength;
    }

    /// <summary>
    /// The most recent increase and most recent decrease of a gauge's value.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeValueTransitionData {
        public const int Size = 0x20;
        [FieldOffset(0x00)] public GaugeValueTransition Increase;
        [FieldOffset(0x10)] public GaugeValueTransition Decrease;
    }

    /// <summary>
    /// The gauge's current value, represented a few different ways. Float values are used as reference for animating the bar.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeValue {
        public const int Size = 0x10;
        [FieldOffset(0x0)] public int ValueInt; // true current value of the gauge
        [FieldOffset(0x4)] public float ValueFloatIncreasing; // increases gradually to match others (but decreases instantly)
        [FieldOffset(0x8)] public float ValueFloat;           // updates instantly to match ValueInt
        [FieldOffset(0xC)] public float ValueFloatDecreasing; // decreases gradually to match others (but increases instantly)
    }

    /// <summary>
    /// A set of three NineGrid nodes for the bar's fill level; one main fill node, and two nodes layered beneath in alternate colours.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeFill {
        public const int Size = 0x18;
        [FieldOffset(0x00)] public AtkNineGridNode* MainFillNode;
        [FieldOffset(0x08)] public AtkNineGridNode* IncreaseFillNode; // alt-colored fill shown during increases
        [FieldOffset(0x10)] public AtkNineGridNode* DecreaseFillNode;                     // same, for decreases
    }

    // There are fields and functions to track two values per gauge, but the vast majority of gauges only use the first value
    // The main (only?) use-case for the secondary gauge value is to display shields on Party List HP bars

    [FixedSizeArray<GaugeValueTransitionData>(2)]
    [FieldOffset(0xC0)] public fixed byte TransitionData[2 * GaugeValueTransitionData.Size];

    [FixedSizeArray<GaugeValue>(2)]
    [FieldOffset(0x100)] public fixed byte Values[2 * GaugeValue.Size];

    [FieldOffset(0x120)] public AtkImageNode* BackdropImageNode;
    [FieldOffset(0x128)] public GaugeFill PrimaryFill;

    // optional nodes not seen on all bars
    [FieldOffset(0x140)] public GaugeFill SecondaryFill;                // portion of shield that fits within the HP bar
    [FieldOffset(0x158)] public GaugeFill SecondaryOverflow;            // portion of shield that overflows onto a separate bar
    [FieldOffset(0x170)] public AtkImageNode* SecondaryOverflowMaxIcon; // the little "etc" icon that appears on a shield too big to display
    [FieldOffset(0x178)] public AtkNineGridNode* RestedExpNode;         // specific to Exp bar, naturally
    [FieldOffset(0x180)] public AtkNineGridNode* BorderNineGridNode;    // appears on crafting window bars
    [FieldOffset(0x188)] public AtkTextNode* ParameterTextNode;         // mainly seems to be used by the Parameter Widget; other gauges that have a text node won't necessarily use this field to point to it

    [FieldOffset(0x190)] public int MinValue;
    [FieldOffset(0x194)] public int MaxValue;

    [FieldOffset(0x1A0)] public short MarginX;
    [FieldOffset(0x1A2)] public short MaxFillPositionX;

    [MemberFunction("45 33 D2 48 8D 05 ?? ?? ?? ?? 4C 89 51 08")]
    public partial void Ctor();

    /// <summary>
    /// Sets the value of the gauge, prompting its visual elements to update.<br/>
    /// If the gauge has a ParameterTextNode, that node's text will update accordingly.<br/>
    /// If the gauge is able to display a secondary value, this function handles the visuals for both values.
    /// </summary>
    /// <param name="value">The value to set.</param>
    /// <param name="secondaryValue">The secondary value to set (n/a on most gauges)</param>
    /// <param name="instant">Set the value instantaneously without animating the fill nodes.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 44 24 20 45 33 C9")]
    public partial void SetGaugeValue(int value, int secondaryValue, bool instant);

    [MemberFunction("E8 ?? ?? ?? ?? 89 AF ?? ?? ?? ?? 48 8B 46 20")]
    public partial void SetGaugeRange(int value);
}

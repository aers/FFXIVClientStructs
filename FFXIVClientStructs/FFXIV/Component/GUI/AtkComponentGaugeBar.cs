namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentGaugeBar
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener

// size = 0xF0
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 5

[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct AtkComponentGaugeBar {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeValueTransition {
        public const int Size = 0x10;
        [FieldOffset(0x00)] public int StartValue;
        [FieldOffset(0x04)] public int EndValue;
        [FieldOffset(0x08)] public float Progress;
        [FieldOffset(0x0C)] public float TransitionLength;
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeValueTransitionData {
        public const int Size = 0x20;
        [FieldOffset(0x00)] public GaugeValueTransition Increase;
        [FieldOffset(0x10)] public GaugeValueTransition Decrease;
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeValue {
        public const int Size = 0x10;
        [FieldOffset(0x0)] public int ValueInt; // true current value of the gauge

        // used to calculate the bar animation
        [FieldOffset(0x4)] public float ValueFloatIncreasing; // increases gradually to match others (but decreases instantly)
        [FieldOffset(0x8)] public float ValueFloat;           // updates instantly to match ValueInt
        [FieldOffset(0xC)] public float ValueFloatDecreasing; // decreases gradually to match others (but increases instantly)
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct GaugeFill {
        public const int Size = 0x18;
        [FieldOffset(0x00)] public AtkNineGridNode* MainFillNode;
        [FieldOffset(0x08)] public AtkNineGridNode* IncreaseFillNode; // alt-colored fill shown during increases
        [FieldOffset(0x10)] public AtkNineGridNode* DecreaseFillNode;                     // same, for decreases
    }

    // There fields and functions to track and display both a primary value and a secondary value (ie, shields on partylist HP bars)
    // The vast majority of gauges only use the primary value

    // [0] Primary
    // [1] Secondary
    [FixedSizeArray<GaugeValueTransitionData>(2)]
    [FieldOffset(0xC0)] public fixed byte TransitionData[2 * GaugeValueTransitionData.Size];

    // [0] Primary
    // [1] Secondary
    [FixedSizeArray<GaugeValue>(2)]
    [FieldOffset(0x100)] public fixed byte Values[2 * GaugeValue.Size];

    [FieldOffset(0x120)] public AtkImageNode* BackdropImageNode;
    [FieldOffset(0x128)] public GaugeFill PrimaryFill;
    [FieldOffset(0x140)] public GaugeFill SecondaryFill;
    [FieldOffset(0x158)] public GaugeFill SecondaryOverflow;
    [FieldOffset(0x170)] public AtkImageNode* SecondaryOverflowMaxIcon; // the little "etc" icon that appears on a shield too big to display

    [FieldOffset(0x180)] public AtkNineGridNode* BorderNineGridNode; // appears on crafting window bars
    [FieldOffset(0x188)] public AtkTextNode* ParameterTextNode; // only seems to be used by the parameter widget

    [FieldOffset(0x190)] public int MinValue;
    [FieldOffset(0x194)] public int MaxValue;

    [FieldOffset(0x1A0)] public short MarginX;
    [FieldOffset(0x1A2)] public short MaxFillPositionX;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F")]
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
}

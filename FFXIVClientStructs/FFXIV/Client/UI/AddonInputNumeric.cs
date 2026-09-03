using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonInputNumeric
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("InputNumeric")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonInputNumeric {
    [FieldOffset(0x238)] public AtkComponentButton* OkButton;
    [FieldOffset(0x240)] public AtkComponentButton* CancelButton;
    [FieldOffset(0x248)] public AtkTextNode* PromptText;
    [FieldOffset(0x250)] public AtkComponentNumericInput* NumericInput;

    public InputNumericAtkValues* TypedAtkValues => (InputNumericAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 7)]
    public struct InputNumericAtkValues {
        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 0)] public AtkValue OkButtonText;

        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 1)] public AtkValue CancelButtonText;

        /// <remarks><see cref="AtkValueType.UInt"/>. Applied to <see cref="AtkUldComponentDataNumericInput.Min"/></remarks>
        [FieldOffset(AtkValue.StructSize * 2)] public AtkValue MinValue;

        /// <remarks><see cref="AtkValueType.UInt"/>. Applied to <see cref="AtkUldComponentDataNumericInput.Max"/></remarks>
        [FieldOffset(AtkValue.StructSize * 3)] public AtkValue MaxValue;

        /// <remarks><see cref="AtkValueType.UInt"/>. Initial numeric value</remarks>
        [FieldOffset(AtkValue.StructSize * 4)] public AtkValue Value;

        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 5)] public AtkValue NumericSuffix;

        /// <remarks><see cref="AtkValueType.String"/></remarks>
        [FieldOffset(AtkValue.StructSize * 6)] public AtkValue PromptText;
    }
}

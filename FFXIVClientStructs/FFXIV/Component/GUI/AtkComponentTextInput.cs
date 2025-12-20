using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTextInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
//   Component::GUI::AtkTextInput::AtkTextInputEventInterface
//   Client::System::Input::SoftKeyboardDeviceInterface::SoftKeyboardInputInterface
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 7
[GenerateInterop]
[Inherits<AtkComponentInputBase>]
[Inherits<AtkTextInput.AtkTextInputEventInterface>]
[Inherits<SoftKeyboardDeviceInterface.SoftKeyboardInputInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x600)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 9F ?? ?? ?? ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 88 9F", 3, 20)]
public unsafe partial struct AtkComponentTextInput : ICreatable {
    [FieldOffset(0x1F0)] public AtkUldComponentDataTextInput ComponentTextData;
    [FieldOffset(0x26C)] public AllowedEntities InputSanitizationFlags;

    /// <summary> The index in the <see cref="AtkTextInput.AtkHistory"/> array. </summary>
    /// <remarks> Requires <see cref="TextInputFlags1.EnableHistory"/> to be set. </remarks>
    [FieldOffset(0x272)] public short AtkHistoryIndex;

    [FieldOffset(0x278)] public bool Enabled;

    /// <remarks> Works only when Completion is disabled. </remarks>
    [FieldOffset(0x27D)] public bool EnableTabCallback;

    [FieldOffset(0x27E)] public bool EnableFocusSounds;

    [FieldOffset(0x280)] private Utf8String UnkText01;
    [FieldOffset(0x2E8)] private Utf8String UnkText02;

    [FieldOffset(0x350)] public Utf8String AvailableLines;

    [FieldOffset(0x3B8)] public AtkTextNode* AvailableLinesTextNode;
    [FieldOffset(0x3C0)] public AtkTextNode* AvailableCharsTextNode;
    [FieldOffset(0x3C8)] public AtkUnitBase* ContainingAddon2; // For whatever reason, the text input _also_ has this
    [FieldOffset(0x3D0)] public AtkResNode* AutoTranslateMenuNode;
    [FieldOffset(0x3D8)] public int CompletionOffset; // Offset into the total number of completion items- used for drawing the label

    [FieldOffset(0x3E0), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _autoTranslateMenuButtons;
    [FieldOffset(0x428)] public AtkTextNode* AutoTranslateMenuPageInfoTextNode;
    [FieldOffset(0x430)] public AtkNineGridNode* AutoTranslateMenuBackground;

    // Utf8Strings containing color macros that are wrapped around the highlighted AutoTranslate option
    [FieldOffset(0x450)] public Utf8String HighlightedAutoTranslateOptionColorPrefix;

    [FieldOffset(0x4B8)] public Utf8String HighlightedAutoTranslateOptionColorSuffix;

    [FieldOffset(0x528)] public TextInputHandlerValues HandlerValues;

    public bool EnableCompletion {
        get => InputSanitizationFlags.HasFlag(AllowedEntities.Payloads);
        set => InputSanitizationFlags = value
            ? InputSanitizationFlags | AllowedEntities.Payloads
            : InputSanitizationFlags & ~AllowedEntities.Payloads;
    }

    // 7.3: inlined, this is an orphaned (no x-ref) copy
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 C7 83")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 45 32 C0 33 D2"), GenerateStringOverloads]
    public partial void SetText(CStringPointer text);

    /// <summary>
    /// Insert text at the current cursor position.
    /// </summary>
    /// <param name="text">Text to insert.</param>
    /// <param name="unique">If true, only insert if the text is not already in the input.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 33 F6 45 33 C9"), GenerateStringOverloads]
    public partial void InsertText(CStringPointer text, bool unique = false);

    /// <summary>
    /// AtkValues for AtkModule handlers 7, 8, (9?), 10
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0xD0)]
    public struct TextInputHandlerValues {
        /// <remarks> Depending on the handler this was seen to be <see cref="ValueType.Undefined"/>, <see cref="ValueType.Bool"/> or <see cref="ValueType.String"/> for <see cref="EvaluatedString"/> </remarks>
        [FieldOffset(0x00)] public AtkValue VariableValue;
        [FieldOffset(0x10)] public AtkValue FontType;
        [FieldOffset(0x20)] public AtkValue FontSize;
        [FieldOffset(0x30)] public AtkValue TextColor;
        [FieldOffset(0x40)] public AtkValue IMEColor;
        [FieldOffset(0x50)] public AtkValue CandidateColor;
        [FieldOffset(0x60)] public AtkValue InputSanitizationFlags;
        [FieldOffset(0x70)] public AtkValue CharSetExtras;
        [FieldOffset(0x80)] public AtkValue MaxByte;
        [FieldOffset(0x90)] public AtkValue MaxChar;
        [FieldOffset(0xA0)] public AtkValue MaxWidth;
        [FieldOffset(0xB0)] public AtkValue MaxLine;
        [FieldOffset(0xC0)] public AtkValue AtkHistoryIndex;
    }
}

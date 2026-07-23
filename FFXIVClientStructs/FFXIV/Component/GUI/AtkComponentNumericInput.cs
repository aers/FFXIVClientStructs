using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentNumericInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
//   Component::GUI::AtkTextInput::AtkTextInputEventInterface

[GenerateInterop]
[Inherits<AtkComponentInputBase>]
[Inherits<AtkTextInput.AtkTextInputEventInterface>(0x1E0)]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct AtkComponentNumericInput : ICreatable<AtkComponentNumericInput> {
    [FieldOffset(0x1E8)] public AtkComponentButton* PlusButtonComponent;
    [FieldOffset(0x1F0)] public AtkComponentButton* MinusButtonComponent;
    [FieldOffset(0x1F8)] public int Value; // Found through SetValue function
    [FieldOffset(0x1FC)] public int ValueBeforeInput;

    /// <remarks>While focused for digit editing, this is only used when <see cref="AddZeroPadding"/> is enabled.</remarks>
    [FieldOffset(0x200)] public int Digits;

    /// <remarks>The mouse wheel path calls <see cref="SetValue"/> directly and does not appear to apply wrapping.</remarks>
    [FieldOffset(0x204)] public bool WrapValue;
    [FieldOffset(0x205)] public bool EnableTextInput;
    [FieldOffset(0x208)] public ByteColor DefaultTextColor;
    [FieldOffset(0x20C)] public int CurrentDigitMultiplier;

    /// <remarks>A visible guide depends on the owning addon and controller/navigation state.</remarks>
    [FieldOffset(0x210)] public bool EnableOperationGuide;
    [FieldOffset(0x212)] public bool AddZeroPadding;
    [FieldOffset(0x218)] public CStringPointer Suffix;
    [FieldOffset(0x220)] public ByteColor FocusColor;
    [FieldOffset(0x228)] public Utf8String HighlightedDigitColorPrefix;
    [FieldOffset(0x290)] public Utf8String HighlightedDigitColorSuffix;
    [FieldOffset(0x2F8)] public AtkUldComponentDataNumericInput Data;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B F1 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 C7 86 ?? ?? ?? ?? ?? ?? ?? ??")]
    public partial AtkComponentNumericInput* Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 81 4F ?? ?? ?? ?? ?? EB 07")]
    public partial void SetValue(int value);

    [MemberFunction("E8 ?? ?? ?? ?? 40 80 FE ?? 74")]
    public partial void InnerSetValue(int value, bool triggerCallback, bool playSoundEffect);

    /// <summary>
    /// Updates the text node with the currently stored Value and formats the
    /// text string according to the AtkComponentInputBase settings.
    /// </summary>
    /// <remarks>
    /// When inactive, formatting uses <see cref="AtkUldComponentDataNumericInput.Comma"/>, <see cref="Digits"/>,
    /// and <see cref="AddZeroPadding"/>. While focused for digit editing, the text is built manually so the selected
    /// digit can be highlighted, and comma formatting is not used.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? EB 20 48 8B CF")]
    public partial void UpdateTextNode();
}

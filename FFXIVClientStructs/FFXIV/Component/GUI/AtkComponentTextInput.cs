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
public unsafe partial struct AtkComponentTextInput : ICreatable {
    [FieldOffset(0x1F0)] public AtkUldComponentDataTextInput ComponentTextData;
    [FieldOffset(0x250), Obsolete("Use ComponentTextData.MaxByte instead", true)] public uint MaxTextLength;
    [FieldOffset(0x254), Obsolete("Use ComponentTextData.MaxChar instead", true)] public uint MaxTextLength2;
    [FieldOffset(0x26C)] public AllowedEntities InputSanitizationFlags;

    [FieldOffset(0x280)] public Utf8String UnkText01;
    [FieldOffset(0x2E8)] public Utf8String UnkText02;

    [FieldOffset(0x350), Obsolete("Renamed to AvailableLines", true)] public Utf8String UnkText03;
    [FieldOffset(0x350)] public Utf8String AvailableLines;

    [FieldOffset(0x3B8)] public AtkTextNode* AvailableLinesTextNode;
    [FieldOffset(0x3C0)] public AtkTextNode* AvailableCharsTextNode;
    [FieldOffset(0x3C8)] public AtkUnitBase* ContainingAddon2; // For whatever reason, the text input _also_ has this
    [FieldOffset(0x3D0)] public AtkResNode* AutoTranslateMenuNode;
    [FieldOffset(0x3D8)] public int CompletionOffset; // Offset into the total number of completion items- used for drawing the label

    [FieldOffset(0x3E0), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _autoTranslateMenuButtons;
    [FieldOffset(0x428)] public AtkTextNode* AutoTranslateMenuPageInfoTextNode;
    [FieldOffset(0x430)] public AtkNineGridNode* AutoTranslateMenuBackground;

    [FieldOffset(0x450), Obsolete("Renamed to HighlightedAutoTranslateOptionColorPrefix", true)] public Utf8String UnkText04;
    // Utf8Strings containing color macros that are wrapped around the highlighted AutoTranslate option
    [FieldOffset(0x450)] public Utf8String HighlightedAutoTranslateOptionColorPrefix;

    [FieldOffset(0x4B8), Obsolete("Renamed to HighlightedAutoTranslateOptionColorSuffix", true)] public Utf8String UnkText05;
    [FieldOffset(0x4B8)] public Utf8String HighlightedAutoTranslateOptionColorSuffix;

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
}

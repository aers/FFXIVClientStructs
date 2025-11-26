using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.Completion;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xCC0)]
public unsafe partial struct AtkTextInput {
    [FieldOffset(0x8)] public AtkTextInputEventInterface* TargetTextInputEventInterface;
    [FieldOffset(0x10)] public CompletionModule* CompletionModule;
    [FieldOffset(0x18)] public TextService* TextService;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray19<Pointer<RaptureAtkHistory>> _atkHistory;
    [FieldOffset(0xB8)] public int ActiveAtkHistoryIndex;
    [FieldOffset(0xC0)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0xC8)] public TextChecker* TextChecker;
    [FieldOffset(0xD0)] public AtkFontCodeModule* AtkFontCodeModule;

    [FieldOffset(0xDA)] public short CursorPos;
    [FieldOffset(0xDC)] public short TextLength;
    [FieldOffset(0xDE)] public short SelectionStart;
    [FieldOffset(0xE0)] public short SelectionEnd;

    [FieldOffset(0x1C0)] public ClipBoard ClipboardData;
    [FieldOffset(0x298)] public Utf8String CopyBufferRaw;
    [FieldOffset(0x300)] public Utf8String CopyBufferFiltered;

    [FieldOffset(0xBF0)] public ushort CompletionDepth;

    [FieldOffset(0xC10)] public AllowedEntities InputSanitizationFlags;

    /// <remarks> Call this only if <see cref="InputSanitizationFlags"/> has Payloads! </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4E 18 48 8B 01")]
    public partial void OpenCompletion();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 85 ?? ?? ?? ?? C6 44 24 ?? ??")]
    public partial bool ProcessKeyShortcut(SeVirtualKey key, KeyModifiers* modifiers);

    // Component::GUI::AtkTextInput::AtkTextInputEventInterface
    // no explicit constructor, just an event interface 
    [GenerateInterop(true)]
    [VirtualTable("48 89 86 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? E8 ?? ?? ?? ?? 40 F6 C5 01", 10, 5)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public partial struct AtkTextInputEventInterface {
        [VirtualFunction(1)]
        public partial void UpdateTextSelection(TextSelectionInfo* selectionInfo);

        [VirtualFunction(4)]
        public partial AtkResNode* GetOwnerNode();
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct TextSelectionInfo {
        [FieldOffset(0x0)] public short CharactersAdded;
        [FieldOffset(0x2)] public ushort SelectionStart;
        [FieldOffset(0x4)] public ushort SelectionEnd;
        [FieldOffset(0x6)] public ushort StringLength;
        [FieldOffset(0x8)] public Utf8String* String1;
        [FieldOffset(0x10)] public Utf8String* String2;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x06)]
    public struct KeyModifiers {
        [FieldOffset(0x00)] public bool IsControlDown;
        [FieldOffset(0x01)] public bool IsShiftDown;
        [FieldOffset(0x02)] public bool IsAltDown;
        [FieldOffset(0x03)] public bool IsCapitalDown;
        [FieldOffset(0x04)] public bool IsNumlockDown;
        [FieldOffset(0x05)] public bool IsScrollDown;
    }
}

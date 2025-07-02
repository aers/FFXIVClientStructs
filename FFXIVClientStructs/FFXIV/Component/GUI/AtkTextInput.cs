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
    [FieldOffset(0xC0)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0xC8)] public TextChecker* TextChecker;
    [FieldOffset(0xD0)] public AtkFontCodeModule* AtkFontCodeModule;

    [FieldOffset(0xDA)] public short CursorPos;
    [FieldOffset(0xDC)] public short TextLength;
    [FieldOffset(0xDE)] public short SelectionEnd;
    [FieldOffset(0xE0)] public short SelectionStart;

    [FieldOffset(0x1C0)] public ClipBoard ClipboardData;
    [FieldOffset(0x298)] public Utf8String CopyBufferRaw;
    [FieldOffset(0x300)] public Utf8String CopyBufferFiltered;

    [FieldOffset(0xBF0)] public uint CompletionDepth; // TODO: should be (u)short

    [FieldOffset(0xC10)] public AllowedEntities InputSanitizationFlags;

    /// <remarks> Call this only if <see cref="InputSanitizationFlags"/> has Payloads! </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4E 18 48 8B 01")]
    public partial void OpenCompletion();

    // Component::GUI::AtkTextInput::AtkTextInputEventInterface
    // no explicit constructor, just an event interface 
    [GenerateInterop(true)]
    [VirtualTable("48 89 86 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? E8 ?? ?? ?? ?? 40 F6 C5 01", 10, 5)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe partial struct AtkTextInputEventInterface {
        [VirtualFunction(4)]
        public partial AtkResNode* GetOwnerNode();
    }
}

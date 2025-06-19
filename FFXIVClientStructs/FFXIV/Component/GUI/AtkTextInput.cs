using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.Completion;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xCC0)]
public unsafe partial struct AtkTextInput {
    [FieldOffset(0x8)] public AtkTextInputEventInterface* TargetTextInputEventInterface;
    [FieldOffset(0x10)] public CompletionModule* CompletionModule;
    [FieldOffset(0x18)] public TextService* TextService;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray19<Pointer<RaptureAtkHistory>> _atkHistory;
    [FieldOffset(0xC0)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0xD0)] public AtkFontCodeModule* AtkFontCodeModule;
    [FieldOffset(0x1C0)] public ClipBoard ClipboardData;
    [FieldOffset(0x298)] public Utf8String CopyBufferRaw;
    [FieldOffset(0x300)] public Utf8String CopyBufferFiltered;
    [FieldOffset(0xBF0)] public uint CompletionDepth;

    // Component::GUI::AtkTextInput::AtkTextInputEventInterface
    // no explicit constructor, just an event interface 
    [GenerateInterop(true)]
    [VirtualTable("48 89 86 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? E8 ?? ?? ?? ?? 40 F6 C5 01", 10, 5)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe partial struct AtkTextInputEventInterface;
}

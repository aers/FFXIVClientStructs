using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.Completion;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0xCC0)]
public unsafe partial struct AtkTextInput {
    [FieldOffset(0x10)] public CompletionModule* CompletionModule;
    [FieldOffset(0x18)] public TextService* TextService;
    [FixedSizeArray<Pointer<RaptureAtkHistory>>(19)]
    [FieldOffset(0x20)] public fixed byte RaptureAtkHistories[0x8 * 19];
    [FieldOffset(0xC0)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0xD0)] public AtkFontCodeModule* AtkFontCodeModule;
    [FieldOffset(0x1C0)] public ClipBoard ClipboardData;
    [FieldOffset(0x298)] public Utf8String CopyBufferRaw;
    [FieldOffset(0x300)] public Utf8String CopyBufferFiltered;
}

using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

// Component::Text::TextChecker
[GenerateInterop]
[Inherits<MacroDecoder>]
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public unsafe partial struct TextChecker {
    [FieldOffset(0x90)] private Utf8String Unk90;

    // Component::Text::TextChecker::ExecNonMacroFunc
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public unsafe partial struct ExecNonMacroFunc {
        [VirtualFunction(1)]
        public partial Utf8String* ProcessString(Utf8String* value);
    }
}

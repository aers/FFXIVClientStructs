using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[GenerateInterop]
[Inherits<MacroDecoder>]
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public unsafe partial struct TextChecker {
    [FieldOffset(0x90)] public Utf8String Unk90;

    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public unsafe partial struct ExecNonMacroFunc {
        [VirtualFunction(1)]
        public partial Utf8String* ProcessString(Utf8String* value);
    }
}

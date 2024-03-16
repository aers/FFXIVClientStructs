using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public unsafe partial struct TextChecker {
    [FieldOffset(0x00)] public MacroDecoder MacroDecoder;
    [FieldOffset(0x90)] public Utf8String Unk90;
}

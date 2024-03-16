using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
public struct AtkFontCodeModule {
    [FieldOffset(0x00)] public MacroDecoder MacroDecoder;
}

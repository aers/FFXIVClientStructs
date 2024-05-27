using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
public unsafe struct AtkFontCodeModule {
    [FieldOffset(0x00)] public MacroDecoder MacroDecoder;
    [FieldOffset(0x60)] public ExcelModule* ExcelModule;
}

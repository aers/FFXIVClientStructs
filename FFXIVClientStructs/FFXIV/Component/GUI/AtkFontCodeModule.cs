using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<MacroDecoder>]
[StructLayout(LayoutKind.Explicit, Size = 0x1580)]
public unsafe partial struct AtkFontCodeModule {
    [FieldOffset(0x60)] public ExcelModule* ExcelModule;
}

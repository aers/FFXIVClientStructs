using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Text;

// this belongs into a Component::Text::Localize namespace but that causes namespace issues
[GenerateInterop, Inherits<ExcelLanguageEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct Localize {
    [FieldOffset(0x08)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x10)] public ExcelSheet* ExcelSheet;
    [FieldOffset(0x18)] public StdMap<Utf8String, nint> UnkMap;
}

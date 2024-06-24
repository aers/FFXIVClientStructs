using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelModuleInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelModuleInterface {
    [FieldOffset(0x08)] public ExdModule* ExdModule;

    [VirtualFunction(1)]
    public partial ExcelSheet* GetSheetByIndex(uint sheetIndex);

    [VirtualFunction(2), GenerateStringOverloads]
    public partial ExcelSheet* GetSheetByName(byte* sheetName);
}

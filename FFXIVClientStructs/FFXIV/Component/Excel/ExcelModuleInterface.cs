using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Component.Excel;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelModuleInterface
{
    [FieldOffset(0x08)] public ExdModule* ExdModule;

    [VirtualFunction(1)]
    public partial ExcelSheet* GetSheetByIndex(uint sheetIndex);

    [VirtualFunction(2)]
    [GenerateCStrOverloads]
    public partial ExcelSheet* GetSheetByName(byte* sheetName);
}
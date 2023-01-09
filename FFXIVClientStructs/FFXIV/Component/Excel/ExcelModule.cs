namespace FFXIVClientStructs.FFXIV.Component.Excel;

[StructLayout(LayoutKind.Explicit, Size = 0x818)]
public unsafe partial struct ExcelModule
{
    [VirtualFunction(1)]
    public partial ExcelSheet* GetSheetByIndex(uint sheetIndex);

    [VirtualFunction(2)]
    [GenerateCStrOverloads]
    public partial ExcelSheet* GetSheetByName(byte* sheetName);

    [VirtualFunction(3)]
    [GenerateCStrOverloads]
    public partial void LoadSheet(byte* sheetName, byte a3 = 0, byte a4 = 0);
}
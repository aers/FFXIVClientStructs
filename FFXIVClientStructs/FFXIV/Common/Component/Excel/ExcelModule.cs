namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x818)]
public unsafe partial struct ExcelModule {
    [VirtualFunction(1)]
    public partial ExcelSheet* GetSheetByIndex(uint sheetIndex);

    [VirtualFunction(2), GenerateStringOverloads]
    public partial ExcelSheet* GetSheetByName(byte* sheetName);

    [VirtualFunction(3), GenerateStringOverloads]
    public partial void LoadSheet(byte* sheetName, byte a3 = 0, byte a4 = 0);
}

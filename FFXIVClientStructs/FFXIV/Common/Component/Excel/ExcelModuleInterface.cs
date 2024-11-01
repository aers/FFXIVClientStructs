namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelModuleInterface
//   Common::Component::Excel::ExcelResourceListener
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ExcelModuleInterface {
    [VirtualFunction(1)]
    public partial ExcelSheet* GetSheetByIndex(uint sheetIndex);

    [VirtualFunction(2), GenerateStringOverloads]
    public partial ExcelSheet* GetSheetByName(byte* sheetName);

    [VirtualFunction(3), GenerateStringOverloads]
    public partial void LoadSheet(byte* sheetName, byte a3 = 0, byte a4 = 0);

    [VirtualFunction(6)]
    public partial ExcelLanguage GetLanguage();

    public enum ExcelLanguage {
        None,
        Japanese,
        English,
        German,
        French,
        ChineseSimplified,
        ChineseTraditional,
        Korean
    }
}

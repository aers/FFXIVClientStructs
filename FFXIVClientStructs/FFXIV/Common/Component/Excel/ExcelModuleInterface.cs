namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelModuleInterface
//   Common::Component::Excel::ExcelResourceListener
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ExcelModuleInterface {
    [VirtualFunction(1)]
    public partial ExcelSheet* GetSheetByIndex([CExporterTypeForce("Component::Exd::SheetsEnum")] uint sheetIndex);

    [VirtualFunction(2), GenerateStringOverloads]
    public partial ExcelSheet* GetSheetByName(CStringPointer sheetName);

    [VirtualFunction(3), GenerateStringOverloads]
    public partial void LoadSheet(CStringPointer sheetName, byte a3 = 0, byte a4 = 0);

    [VirtualFunction(6)]
    public partial ExcelLanguage GetLanguage();

    public enum ExcelLanguage {
        None,
        Japanese, // ja
        English, // en
        German, // de
        French, // fr
        ChineseSimplified, // chs
        ChineseTraditional, // cht
        Korean, // ko
        ChineseTraditional2 // tc
    }
}

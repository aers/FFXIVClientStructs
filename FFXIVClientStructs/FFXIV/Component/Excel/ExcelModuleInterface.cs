using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelModuleInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ExcelModuleInterface {
    [FieldOffset(0x08)] public ExdModule* ExdModule;

    [VirtualFunction(1)]
    public partial ExcelSheet* GetSheetByIndex([CExporterTypeForce("Component::Exd::SheetsEnum")] uint sheetIndex);

    [VirtualFunction(2), GenerateStringOverloads]
    public partial ExcelSheet* GetSheetByName(CStringPointer sheetName);

    [VirtualFunction(3)]
    public partial ExcelLanguage* GetLanguage(); // returns a pointer to ExcelModule->GetLanguage() - 1

    public enum ExcelLanguage {
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

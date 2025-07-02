using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Exd;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ExdModule {
    [FieldOffset(0x20)] public ExcelModule* ExcelModule;

    [MemberFunction("40 53 48 83 EC 20 45 8B D0 4C 8B CA")]
    public partial ExcelRow* GetRowBySheetAndRowId(ExcelSheet* sheet, uint rowId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 40 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 41 8B F8")]
    public partial ExcelRow* GetRowBySheetAndRowIndex(ExcelSheet* sheet, uint rowIndex);

    [MemberFunction("E8 ?? ?? ?? ?? EB 11 33 C0")]
    public partial ExcelRow* GetRowBySheetIndexAndRowId([CExporterTypeForce("Component::Exd::SheetsEnum")] uint sheetIndex, uint rowId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 1D FF C3")]
    public partial ExcelRow* GetRowBySheetIndexAndRowIndex([CExporterTypeForce("Component::Exd::SheetsEnum")] uint sheetIndex, uint rowIndex);

    [MemberFunction("48 85 D2 74 0D 48 8B 02 48 8B CA 48 FF A0 88 00 00 00")]
    public partial int GetRowCountBySheet(ExcelSheet* sheet);

    [MemberFunction("E8 ?? ?? ?? ?? 3B D8 73 35")]
    public partial int GetRowCountBySheetIndex([CExporterTypeForce("Component::Exd::SheetsEnum")] uint sheetIndex);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 48 8B FA 48 8B 49 20 48 8B 01"), GenerateStringOverloads]
    public partial int GetRowCountBySheetName(CStringPointer sheetName);

    [MemberFunction("E8 ?? ?? ?? ?? FE 47 30")]
    public partial ExcelSheet* GetSheetByIndex([CExporterTypeForce("Component::Exd::SheetsEnum")] uint sheetIndex);

    [MemberFunction("48 8B 49 20 48 8B 01 48 FF 60 10"), GenerateStringOverloads]
    public partial ExcelSheet* GetSheetByName(CStringPointer sheetName);

    [MemberFunction("48 83 EC 38 48 8B 05 ?? ?? ?? ?? 48 8B 88")]
    public partial bool IsColumnRsv([CExporterTypeForce("Component::Exd::SheetsEnum")] uint sheetIndex, uint rowId, uint subRowId, uint columnIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 75 00")]
    [CExporterExcel("Item")]
    public static partial void* GetItemRowById(uint itemId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 48 2F")]
    [CExporterExcel("BannerCondition")]
    public static partial void* GetBannerConditionByIndex(uint rowIndex);

    [MemberFunction("40 53 48 83 EC 20 0F B6 41 ?? 48 8B D9 84 C0 74")]
    public static partial int GetBannerConditionUnlockState([CExporterExcel("BannerCondition")] void* row);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 53 6C")]
    public static partial uint GetEnabledZoneSharedGroupRequirementIndex([CExporterExcel("ZoneSharedGroup")] void* row);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 5E ?? BA 05 00 00 00")]
    public static partial uint GetRoleForClassJobId(uint classJobId);
}

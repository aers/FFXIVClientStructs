using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Exd;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ExdModule {
    [FieldOffset(0x20)] public ExcelModule* ExcelModule;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 1D FF C3")]
    public partial void* GetRowBySheetIndexAndRowIndex(uint sheetId, uint rowId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 40 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 41 8B F8")]
    public partial void* GetRowBySheetAndRowIndex(ExcelSheet* sheet, uint rowId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 75 00")]
    public static partial void* GetItemRowById(uint itemId);
}

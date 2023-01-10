using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Exd;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ExdModule
{
    [FieldOffset(0x20)] public ExcelModule* ExcelModule;

    [MemberFunction("E8 ?? ?? ?? ?? 0F 57 F6 48 85 C0")]
    public partial void* GetEntryByIndex(uint sheetId, uint rowId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 40 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 41 8B F8")]
    public partial void* GetSheetRowById(void* sheet, uint rowId);

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 DD")]
    public static partial void* GetItemRowById(uint itemId);
}
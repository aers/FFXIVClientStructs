namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x810)]
public unsafe partial struct ExcelModule {
    [FieldOffset(0x7A8)] public ExcelSheet** SheetsByIndex;
}

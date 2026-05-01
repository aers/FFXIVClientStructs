namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelModule
//   Common::Component::Excel::ExcelResourceListener
[GenerateInterop]
[Inherits<ExcelResourceListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x810)]
public unsafe partial struct ExcelModule {
    [FieldOffset(0x7A8)] public ExcelSheet** SheetsByIndex;
}

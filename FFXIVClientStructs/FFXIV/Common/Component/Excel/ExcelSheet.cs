namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelSheet
//   Common::Component::Excel::LinkList<Common::Component::Excel::ExcelSheet>
//   Common::Component::Excel::ExcelSheetInterface
[GenerateInterop]
[Inherits<ExcelSheetInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe partial struct ExcelSheet {
    [FieldOffset(0x8)] public ExcelModuleInterface.ExcelLanguage Language;
    [FieldOffset(0x10)] public CStringPointer SheetName; // 32 Bytes
    [FieldOffset(0x20)] public uint RowCount;
    [FieldOffset(0x30)] public ColumnInfo* ColumnDefinitions;
    [FieldOffset(0x38)] public uint DataOffset;
    //[FieldOffset(0x3C)] public uint DataOffset2;

    //[FieldOffset(0x68)] public LinkList<ExcelPage> ExcelPages;

    [FieldOffset(0xC8)] public ExcelVariant Variant;
    [FieldOffset(0xCC)] public ushort ColumnCount;

    [FieldOffset(0xD0)] public ushort Version; //?
    [FieldOffset(0xD2)] public ushort SheetIndex;

    public Span<ColumnInfo> ColumnDefinitionSpan => new(ColumnDefinitions, ColumnCount);

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ColumnInfo {
        public ushort Type;
        public ushort Index;
        public ushort Offset;
    }
}

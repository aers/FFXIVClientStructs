namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelSheet
//   Common::Component::Excel::LinkList<Common::Component::Excel::ExcelSheet>
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe struct ExcelSheet {
    [FieldOffset(0x00), CExporterBaseType] public LinkList<ExcelSheet> Base;
    [FieldOffset(0x18)] public ExcelLanguage Language;
    [FieldOffset(0x20)] public CStringPointer SheetName; // 32 Bytes
    [FieldOffset(0x30)] public uint RowCount;
    [FieldOffset(0x38)] public ColumnInfo* ColumnDefinitions;
    [FieldOffset(0x40)] public uint DataOffset;
    //[FieldOffset(0x44)] public uint DataOffset2;

    //[FieldOffset(0x70)] public LinkList<ExcelPage> ExcelPages;

    //[FieldOffset(0xB0)] public IExcelPageRowResolver* RowResolver;

    [FieldOffset(0xD0)] public ExcelVariant Variant;
    [FieldOffset(0xD4)] public ushort ColumnCount;

    [FieldOffset(0xD8)] public ushort Version; //?
    [FieldOffset(0xDA)] public ushort SheetIndex;

    public Span<ColumnInfo> ColumnDefinitionSpan => new(ColumnDefinitions, ColumnCount);

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ColumnInfo {
        public ushort Type;
        public ushort Index;
        public ushort Offset;
    }
}

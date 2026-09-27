using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelSheet
//   Common::Component::Excel::LinkList<Common::Component::Excel::ExcelSheet>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe partial struct ExcelSheet {
    [FieldOffset(0x00), CExporterBaseType] public LinkList<ExcelSheet> Base;
    [FieldOffset(0x18)] public ExcelLanguage Language;
    [FieldOffset(0x20)] public ExcelSheetNameVar SheetNameVar;
    [FieldOffset(0x20), Obsolete("Use SheetNameVar.SheetName")] public CStringPointer SheetName; // 32 Bytes
    [FieldOffset(0x30)] public uint RowCount;
    [FieldOffset(0x38)] public ColumnInfo* ColumnDefinitions;
    [FieldOffset(0x40)] public uint DataOffset;
    [FieldOffset(0x44)] public uint RowLength; // in bytes

    [FieldOffset(0x70)] public LinkedListContainer ExcelPages;

    [FieldOffset(0xA8)] private uint CachedAllocatedRowCount; // not sure how it's cached yet. use the function which falls back to calling the function on RowResolver

    [FieldOffset(0xB0)] public IExcelPageRowResolver* RowResolver;

    [FieldOffset(0xD0)] public ExcelVariant Variant;
    [FieldOffset(0xD4)] public ushort ColumnCount;
    [FieldOffset(0xD6)] public short StartColumn; // initialized with -1. then, if -1, set to the current index in a loop over ColumnDefinitions. so technically always 0 unless there are no columns

    [FieldOffset(0xD8)] public ushort Version;
    [FieldOffset(0xDA)] public ushort SheetIndex;
    [FieldOffset(0xDD)] public bool ExcelPagesLinked;
    [FieldOffset(0xE0)] public WaiterContainer Waiters;
    [FieldOffset(0xF8), Obsolete("Use WaiterContainer.Count")] public uint WaiterCount;

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 BD")]
    public partial uint GetAllocatedRowCount();

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 48 8D 74 24")]
    public partial IExcelRowWrapper* GetRowByDescriptor(ExcelRowDescriptor* descriptor, uint* outErrorCode = null); // No xref possibly inlined somewhere

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 49 89 44 0E")]
    public partial IExcelRowWrapper* GetSubRowByDescriptor(ExcelRowDescriptor* descriptor, uint* outErrorCode = null);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 ?? B0 ?? EB")]
    public partial IExcelRowWrapper* GetRowByIndex(uint rowIndex, ExcelRowDescriptor* descriptor);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D3 48 8B F8")]
    public partial IExcelRowWrapper* GetRowById(uint rowId, uint* outErrorCode = null);

    [MemberFunction("E9 ?? ?? ?? ?? 13 6D")]
    public partial bool AddWaiter(ExcelSheetWaiter* waiter);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 ?? 44 8B C5")]
    public partial void RemoveWaiter(ExcelSheetWaiter* waiter);

    public Span<ColumnInfo> ColumnDefinitionSpan => new(ColumnDefinitions, ColumnCount);

    [StructLayout(LayoutKind.Explicit, Size = 0x06)]
    public struct ColumnInfo {
        [FieldOffset(0x00)] public ExcelColumnType ColumnType;
        [FieldOffset(0x00), Obsolete("Use ColumnType")] public ushort Type;
        [FieldOffset(0x02)] public ushort Index;
        [FieldOffset(0x04)] public ushort Offset;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public struct LinkedListContainer {
        [FieldOffset(0x00)] public LinkList<ExcelPage> List1;
        [FieldOffset(0x18)] public LinkList<ExcelPage> List2;
        [FieldOffset(0x30)] public int NumCreatedExcelPages;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct WaiterContainer {
        [FieldOffset(0x00), CExporterBaseType] public LinkList<WaiterEntry> Base;
        [FieldOffset(0x18)] public int Count;

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct WaiterEntry {
            [FieldOffset(0x00)] public ExcelSheetWaiter* Waiter;
            [FieldOffset(0x08)] public int Index; // ?
            [FieldOffset(0x10)] public WaiterEntry* Next;
        }
    }
}

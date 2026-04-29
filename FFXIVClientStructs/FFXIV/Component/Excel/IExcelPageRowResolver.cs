namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::IExcelPageRowResolver
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct IExcelPageRowResolver {
    [VirtualFunction(0)]
    public partial IExcelPageRowResolver* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void SetDesiredCapacity(uint capacity);

    [VirtualFunction(2)]
    public partial uint GetAllocatedRowCount();

    [VirtualFunction(3)]
    public partial bool StoreRow(ExcelRowDescriptor* descriptor, ExcelRow* row);

    // [VirtualFunction(4)]
    // public partial ?? ??(??);

    [VirtualFunction(5)]
    public partial void Clear();

    // [VirtualFunction(6)]
    // public partial ?? ??(??);

    [VirtualFunction(7)]
    public partial IExcelRowWrapper* GetRowByDescriptor(ExcelRowDescriptor* descriptor);

    [VirtualFunction(8)]
    public partial IExcelRowWrapper* GetRowByIndex(uint index, ExcelRowDescriptor* descriptor);

    // [VirtualFunction(9)]
    // public partial ?? EnumerateRows(??);
}

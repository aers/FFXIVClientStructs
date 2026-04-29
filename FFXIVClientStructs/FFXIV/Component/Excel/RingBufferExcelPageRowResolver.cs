namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::RingBufferExcelPageRowResolver
//   Component::Excel::IExcelPageRowResolver
[GenerateInterop]
[Inherits<IExcelPageRowResolver>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct RingBufferExcelPageRowResolver {
    [FieldOffset(0x10)] public Common.Component.Excel.LinkedList<RowWrapperList> First;
    [FieldOffset(0x28)] public Common.Component.Excel.LinkedList<RowWrapperList> Last;
    [FieldOffset(0x40)] public uint RowsAllocated;
    [FieldOffset(0x48)] public uint RowsCapacity;

    // Component::Excel::RingBufferExcelPageRowResolver::RowWrapperList
    //   Common::Component::Excel::LinkList<Component::Excel::RowWrapper>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe partial struct RowWrapperList {
        [FieldOffset(0x0)] public Common.Component.Excel.LinkedList<RowWrapperList> LinkedList;
        [FieldOffset(0x18)] public ExcelRowDescriptor RowDescriptor;
        [FieldOffset(0x28)] public RowWrapper RowWrapper;
    }

    // Component::Excel::RingBufferExcelPageRowResolver::RowWrapper
    //   Component::Excel::IExcelRowWrapper
    [GenerateInterop]
    [Inherits<IExcelRowWrapper>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe partial struct RowWrapper {
        [FieldOffset(0x8)] public ExcelRow* Row;
        [FieldOffset(0x10)] public uint RefCount;
    }
}

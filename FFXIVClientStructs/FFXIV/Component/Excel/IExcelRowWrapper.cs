namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::IExcelRowWrapper
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct IExcelRowWrapper {
    [FieldOffset(0x8)] public ExcelRow* Row;

    [VirtualFunction(0)]
    public partial IExcelRowWrapper* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void DecRef();
}

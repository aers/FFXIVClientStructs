namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::IExcelRowWrapper
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct IExcelRowWrapper {
    [VirtualFunction(0)]
    public partial IExcelRowWrapper* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void DecRef();
}

namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelResourceListener
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ExcelResourceListener {
    [VirtualFunction(0)]
    public partial ExcelResourceListener* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void OnResourceLoad(nint unk);
}

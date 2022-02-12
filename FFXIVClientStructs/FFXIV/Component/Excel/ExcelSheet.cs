namespace FFXIVClientStructs.FFXIV.Component.Excel;

[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe struct ExcelSheet
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x0)] public void** vfunc;
    [FieldOffset(0x10)] public byte* SheetName; // 32 Bytes
    [FieldOffset(0x20)] public uint RowCount;
}
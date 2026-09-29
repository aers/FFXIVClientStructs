namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelSheetNameVar
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct ExcelSheetNameVar {
    [FieldOffset(0x00)] public CStringPointer SheetNamePtr; // 32 Bytes
    [FieldOffset(0x00), CExporterIgnore, FixedSizeArray] internal FixedSizeArray8<byte> _sheetName;
    [FieldOffset(0x08)] public ushort SheetNameHash;
    [FieldOffset(0x0A)] public byte Type; // 0 = Pointer, 1 = Inline? not entirely sure
}

using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Excel;

// Component::Excel::ExcelPage
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct ExcelPage {
    [FieldOffset(0x00), CExporterBaseType] public LinkList<ExcelPage> Base;
    [FieldOffset(0x20)] ExcelSheet* Sheet;
    [FieldOffset(0x28)] ExcelSheetNameVar SheetNameVar;

    [FieldOffset(0x38)] public uint StartRowId;
    [FieldOffset(0x3C)] public uint EndRowId;
    [FieldOffset(0x40)] public uint RowCount;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 48 85 DB 74 ?? 48 8B 5B ?? 48 3B DD")]
    public partial bool ContainsRowId(ExcelRowDescriptor* descriptor);
}

using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Common.Component.Excel;

// Common::Component::Excel::ExcelSheetInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct ExcelSheetInterface {
    [VirtualFunction(1)]
    public partial bool IsAnyPageBeingLoaded();

    [VirtualFunction(2)]
    public partial ExcelColumnType GetColumnType(uint columnIndex);

    [VirtualFunction(3)]
    public partial ushort GetColumnOffset(uint columnIndex);

    [VirtualFunction(9)]
    public partial IExcelRowWrapper* GetRowById(uint rowId, int* outErrorCode);

    [VirtualFunction(10)]
    public partial IExcelRowWrapper* GetRowByDescriptor(ExcelRowDescriptor* descriptor, int* outErrorCode);

    [VirtualFunction(15)]
    public partial ExcelVariant GetVariant();

    [VirtualFunction(16)]
    public partial ushort GetColumnCount();

    [VirtualFunction(17)]
    public partial uint GetRowCount();
}

public enum ExcelVariant : uint {
    SingleRow,
    MultiRow
}

public enum ExcelColumnType : ushort {
    String = 0x0,
    Bool = 0x1,
    Int8 = 0x2,
    UInt8 = 0x3,
    Int16 = 0x4,
    UInt16 = 0x5,
    Int32 = 0x6,
    UInt32 = 0x7,

    Float32 = 0x9,
    Int64 = 0xA,
    UInt64 = 0xB,

    PackedBool0 = 0x19,
    PackedBool1 = 0x1A,
    PackedBool2 = 0x1B,
    PackedBool3 = 0x1C,
    PackedBool4 = 0x1D,
    PackedBool5 = 0x1E,
    PackedBool6 = 0x1F,
    PackedBool7 = 0x20,
}

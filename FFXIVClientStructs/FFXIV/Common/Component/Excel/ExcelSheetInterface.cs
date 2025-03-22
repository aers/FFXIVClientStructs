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

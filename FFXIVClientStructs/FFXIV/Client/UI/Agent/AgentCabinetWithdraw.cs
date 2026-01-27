using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.CabinetWithdraw)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentCabinetWithdraw {

    [FieldOffset(0x28)] public CabinetWithdrawData* Data;

    [GenerateInterop]
    [Inherits<AgentInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x1D8)]
    public partial struct CabinetWithdrawData {

        // Offsets for std::vector can be found inside the constructor "40 53 56 57 48 83 EC ? 83 89"
        // The rest can be found in "48 89 5C 24 ? 55 41 54 41 57 48 83 EC ? 48 8B 01" and its ReceiveEvent

        [FieldOffset(0x30)] public Utf8String SearchText;

        [FieldOffset(0xA8)] public StdVector<CabinetCategoryDetail> CabinetCategories;

        [FieldOffset(0xC0)] public StdVector<AvailableItemDetail> AvailableItems;

        [FieldOffset(0xD8)] public uint CurrentTabIndex;

        [FieldOffset(0xE8)] private ExcelSheetWaiter _sheetWaiter;

        [FieldOffset(0x1A8)] public StdVector<CurrentCategoryItemDetail> CurrentCategoryItems;

        [FieldOffset(0x1C0)] public uint CurrentCategorySelectedIndex;

        [FieldOffset(0x1C4)] public uint ContextMenuSelectedItemId;
        [FieldOffset(0x1D0)] public uint ContextMenuSelectedItemCabinetRowId;

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public struct CurrentCategoryItemDetail {
            [FieldOffset(0)] private void* ItemCache;
            [FieldOffset(0xC)] public uint CabinetRowId;
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public struct AvailableItemDetail {
            [FieldOffset(0)] private void* RowFromCabinetSheet;
            [FieldOffset(8)] public uint CabinetRowId;
        }

        [StructLayout(LayoutKind.Explicit, Size = 128)]
        public struct CabinetCategoryDetail {
            [FieldOffset(0)] private void* RowFromCategorySheet;

            [FieldOffset(0x8)] public uint CabinetCategoryRowId;

            [FieldOffset(0x10)] public Utf8String Name;
        }
    }
}

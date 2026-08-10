using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentInclusionShop
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.InclusionShop)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentInclusionShop {
    [FieldOffset(0x38)] public AgentData* Data;

    [MemberFunction("48 8B 41 38 4C 8B D1 80 88 ?? ?? ?? ?? ??")]
    public partial void SelectCategory(byte categoryIndex);

    [GenerateInterop]
    [Inherits<ExcelSheetWaiter>]
    [StructLayout(LayoutKind.Explicit, Size = 0x1290)]
    public unsafe partial struct AgentData {
        // only active when being requested, are nulled/defaulted when ready
        [FieldOffset(0x90)] private AgentInclusionShop* Agent;
        [FieldOffset(0x98)] private uint SheetId; // 922 InclusionShop, 1009 InclusionShopSeries
        [FieldOffset(0xA4)] private int SheetLoadState;

        [FieldOffset(0xB0)] public ExcelSheet* InclusionShopSeriesSheet;

        //[FieldOffset(0xB8), FixedSizeArray] internal FixedSizeArray2<Utf8String> _unkB8;

        [FieldOffset(0x188)] public uint InclusionShopId;
        [FieldOffset(0x190), FixedSizeArray] internal FixedSizeArray30<Category> _categories;

        /// <remarks>maps <see cref="SelectedCategoryIndex"/> to <see cref="_categories"/></remarks>
        [FieldOffset(0x1180), FixedSizeArray] internal FixedSizeArray30<byte> _categoryIndexMap;

        [FieldOffset(0x119F)] public byte CategoryCount;

        [FieldOffset(0x11A1)] public byte SelectedItemIndex;
        [FieldOffset(0x11A2)] public byte SelectedCurrencyCount; // # of valid _selectedCurrencies slots
        [FieldOffset(0x11A3)] private byte SelectedSpecialCurrencyCount; // # of _selectedCurrencies that are special currencies

        [FieldOffset(0x11A4), FixedSizeArray] internal FixedSizeArray3<SelectedCurrency> _selectedCurrencies; // filled when confirming a purchase

        [FieldOffset(0x11C8)] public uint PurchaseQuantity; // set after purchase, it's not the visible number in the inputint

        [FieldOffset(0x11D0)] public byte SelectedCategoryIndex;
        [FieldOffset(0x11D1)] public byte SelectedSubCategoryIndex;
        [FieldOffset(0x11D2)] private byte Unk11D2;

        /// <remarks>maps ui item index to <see cref="SubCategory._items"/></remarks>
        [FieldOffset(0x11D3), FixedSizeArray] internal FixedSizeArray60<byte> _itemIndexMap;

        [FieldOffset(0x124B)] public byte VisibleSubCategoryCount; // includes the default "-- select a subcategory --"
        [FieldOffset(0x124C)] public byte SelectedSubCategoryTab;
        /// <remarks>maps <see cref="SelectedSubCategoryTab"/> to <see cref="Category.SubCategories"/></remarks>
        [FieldOffset(0x124D), FixedSizeArray] internal FixedSizeArray60<byte> _subCategoryIndexMap;

        [BitField<bool>(nameof(NeedsAddonRefresh), 0)]
        [BitField<bool>(nameof(IsShopReady), 1)]
        [BitField<bool>(nameof(FilterEnabled), 2)]
        [FieldOffset(0x128E)] public byte Flags;

        public bool SelectSubCategory(byte tabIndex) {
            if (tabIndex >= VisibleSubCategoryCount)
                return false;

            SelectedSubCategoryTab = tabIndex;
            SelectedSubCategoryIndex = _subCategoryIndexMap[tabIndex];
            NeedsAddonRefresh = true;
            return true;
        }
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public unsafe partial struct Category {
        [FieldOffset(0x00)] private ulong Unk00;
        [FieldOffset(0x08)] public ushort InclusionShopRowId;
        [FieldOffset(0x0A)] public ushort InclusionShopSeriesId;
        [FieldOffset(0x0C)] private byte Unk0C;
        [FieldOffset(0x0D)] public byte SubCategoryCount;
        [FieldOffset(0x10)] public Utf8String Name;
        [FieldOffset(0x78)] public SubCategory* SubCategories;
        [FieldOffset(0x80)] public ExcelSheetWaiter* SeriesSheetWaiter;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1E80)]
    public unsafe partial struct SubCategory {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray60<Item> _items;
        [FieldOffset(0x1E78)] public byte ItemCount;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public unsafe partial struct Item {
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray2<uint> _giveItemOwnedCount;
        [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray3<uint> _costOwnedCount;
        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray2<uint> _giveAmount;
        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray3<uint> _costAmount;
        [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray2<uint> _giveItemId;
        /// <remarks>
        /// Meaning depends on <see cref="_costType"/>:
        /// 0/1 = item id, 2 = tomestone index (resolve via GetTomestonesItem), 3 = special currency id (resolve via CurrencyManager).
        /// </remarks>
        [FieldOffset(0x3C), FixedSizeArray] internal FixedSizeArray3<uint> _costItemId;
        /// <remarks>0 = item, 1 = HQ item, 2 = tomestone, 3 = special currency</remarks>
        [FieldOffset(0x6C), FixedSizeArray] internal FixedSizeArray3<byte> _costType;
        [FieldOffset(0x75), FixedSizeArray] internal FixedSizeArray2<byte> _giveItemHq;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct SelectedCurrency {
        [FieldOffset(0x00)] public uint ItemId;
        /// <remarks><see cref="InventoryType.Invalid"/> when unset</remarks>
        [FieldOffset(0x04)] public uint InventorySlot;
        [FieldOffset(0x08)] private uint Unk08;
    }
}

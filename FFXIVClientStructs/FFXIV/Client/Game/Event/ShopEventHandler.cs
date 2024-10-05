using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x32F0)]
public unsafe partial struct ShopEventHandler {
    // 0x210: second base class, related to context menu integration for selling items
    // 0x218: third base class, related to buying items, not sure how it's used exactly

    [FieldOffset(0x0220)] public Utf8String ShopName;
    [FieldOffset(0x0288)] public uint ShopIcon;
    [FieldOffset(0x028C)] public GameMain.Festival Festival;
    [FieldOffset(0x0290)] public uint UnlockQuestId;
    // 0x294: byte, col 5 in GilShop row
    [FieldOffset(0x0298), FixedSizeArray] internal FixedSizeArray60<ShopItem> _items;
    [FieldOffset(0x29F8)] public int ItemsCount; // num valid entries in Items array
    [FieldOffset(0x29FC), FixedSizeArray] internal FixedSizeArray60<int> _visibleItems; // indices of items in Items array that are to be shown in shop
    [FieldOffset(0x2AEC)] public int VisibleItemsCount; // num valid entries in VisibleItems array
    [FieldOffset(0x2AF0)] public bool NeedSorting; // set after GilShopItem rows are loaded, used later when Item rows are loaded
    // 0x2AF8: int, ???
    [FieldOffset(0x2AFC)] public int SellPriceBuy; // the vendor buy price of the item being sold
    [FieldOffset(0x2B00)] public int SellPrice; // the price vendor will pay for the item being sold (adjusted by materia etc)
    [FieldOffset(0x2B04)] public int SellStackMax; // max stack size of the item being sold
    [FieldOffset(0x2B08)] public bool SellIsUnique; // is item being sold unique?
    [FieldOffset(0x2B09)] public bool SellIsUntradeable; // is item attempted to be sold untradeable?
    [FieldOffset(0x2B0A)] public bool SellIsWithMateria; // is item being sold has attached materia?
    [FieldOffset(0x2B0B)] public bool SellIsFullySpiritbound; // is item being sold has full spiritbound?
    [FieldOffset(0x2B0C)] public bool SellIsCollectible; // is item being sold collectible?
    [FieldOffset(0x2B10)] public Utf8String SellItemName;
    [FieldOffset(0x2B78)] public int SellRarity;
    [FieldOffset(0x2B80), FixedSizeArray] internal FixedSizeArray10<BuybackItem> _buyback;
    [FieldOffset(0x32B0)] public int BuybackCount; // num valid entries in Buyback array
    [FieldOffset(0x32B4)] public bool StartingSell; // set while waiting for Item sheet reader to complete before to continue sell transaction
    [FieldOffset(0x32B5)] public bool StartingBuy; // set while waiting for Item sheet reader to complete before to continue buy transaction
    [FieldOffset(0x32B6)] public bool UpdatingBuybackItems; // set while waiting for Item sheet reader to update buyback item details
    [FieldOffset(0x32B7)] public bool BuybackTabActive;
    [FieldOffset(0x32B8)] public bool WaitingForSellConfirm;
    [FieldOffset(0x32B9)] public bool WaitingForTransactionToFinish;
    [FieldOffset(0x32BA)] public bool IsTradingWithRetainer; // if set, eg. will warn about transaction exceeding gil cap
    [FieldOffset(0x32BC)] public int CurrentMode; // 0 = none, 1 = normal, 2 = buyback
    [FieldOffset(0x32C0)] public int TransactionType; // 0 = n/a, 1 = buying, 2 = selling
    [FieldOffset(0x32C4)] public int BuyItemIndex; // index in Items or Buyback array, depending on mode
    [FieldOffset(0x32C8)] public uint TransactionItemId; // in Item row; set during all types of transactions
    [FieldOffset(0x32CC)] public int SellInventorySlot;
    [FieldOffset(0x32D0)] public int TransactionItemCount; // num items being bought/sold
    [FieldOffset(0x32D4)] public InventoryType SellInventoryType;
    // 0x32D8: int, ??? - related to sound effects being played, etcs
    [FieldOffset(0x32E0)] public void* SheetReader;
    [FieldOffset(0x32E8)] public ExcelSheet* CurrentSheet;

    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public unsafe partial struct ShopItem {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public int PriceBuy;
        [FieldOffset(0x08)] public int PriceSell;
        [FieldOffset(0x0C)] public int NumOwned;
        [FieldOffset(0x10)] public int StackSize;
        [FieldOffset(0x14)] public bool IsUnique;
        [FieldOffset(0x18)] public uint CategoryIcon;
        // 0x1C: byte, col 2 in GilShopItem row
        // 0x1D: byte, col 3 in GilShopItem row
        [FieldOffset(0x20)] public Utf8String ItemName;
        [FieldOffset(0x88)] public bool IsHQ;
        [FieldOffset(0x8C)] public uint QuestRequired1;
        [FieldOffset(0x90)] public uint QuestRequired2;
        // 0x94: byte, col 7 in GilShopItem row, something to do with showing items that aren't yet unlocked
        [FieldOffset(0x98)] public uint SubRowId; // in GilShopItem sheet, corresponding to this item; note that items could be sorted after loading
        [FieldOffset(0x9C)] public byte CategoryOrderMajor;
        [FieldOffset(0x9D)] public byte CategoryOrderMinor;
        // 0xA0: int, col 19 in Item row
        [FieldOffset(0xA4)] public ushort StateRequired; // column in GilShopItem row
        [FieldOffset(0xA6)] public ushort PatchAdded;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xB8)]
    public unsafe partial struct BuybackItem {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public int Quantity;
        [FieldOffset(0x08)] public int Price;
        [FieldOffset(0x0C)] public int NumOwned;
        [FieldOffset(0x10)] public InventoryItem.ItemFlags Flags;
        [FieldOffset(0x18)] public Utf8String ItemName;
        // 0x80: byte, ???
        [FieldOffset(0x84)] public uint CategoryIcon;
        [FieldOffset(0x88)] public uint ShopId;
        [FieldOffset(0x90)] public ulong CrafterContentId;
        [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray5<ushort> _materia;
        [FieldOffset(0xA2), FixedSizeArray] internal FixedSizeArray5<byte> _materiaGrades;
        [FieldOffset(0xA8)] public ushort Condition;
        [FieldOffset(0xAA)] public ushort Spiritbond;
        [FieldOffset(0xAC), FixedSizeArray] internal FixedSizeArray2<byte> _stains;
        [FieldOffset(0xB0)] public uint GlamourId;
        [FieldOffset(0xB4)] public bool IsUnique;
    }

    // there's a global singleton of this type, it's referenced by AgentShop.EventReceiver when shop is activated
    [GenerateInterop]
    [Inherits<AtkModuleInterface.AtkEventInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe partial struct AgentProxy {
        [FieldOffset(0x10)] public ShopEventHandler* Handler;
        [FieldOffset(0x18)] public uint AddonId;
    }

    // there's a global singleton of this type, it's referenced by confirmation addons
    [GenerateInterop]
    [Inherits<AtkModuleInterface.AtkEventInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe partial struct YesNoProxy {
        [FieldOffset(0x10)] public ShopEventHandler* Handler;
        [FieldOffset(0x18)] public uint AddonId;
    }

    /// <summary>
    /// Buy a bunch of items from the vendor.
    /// Note: BuyItemIndex field must be set before calling this function!
    /// </summary>
    /// <param name="count">Number of items to buy.</param>
    [MemberFunction("48 83 EC 38 80 B9 ?? ?? ?? ?? ?? C7 44 24")]
    public partial void ExecuteBuy(int count);
}

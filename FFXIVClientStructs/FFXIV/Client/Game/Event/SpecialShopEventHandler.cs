using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::SpecialShopEventHandler
//   Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct SpecialShopEventHandler {
    [FieldOffset(0x1C0)] public StdVector<SpecialShopItem> Items; // indexed by VisibleItems
    [FieldOffset(0x1D8)] private bool Unk1D8; // set as soon as items gets resolved?
    [FieldOffset(0x1E0)] private StdMap<uint, nint> Unk1E0; // key is an itemId, value is a struct with some info
    [FieldOffset(0x220)] public StdVector<uint> VisibleItems;
    [FieldOffset(0x238)] public ExcelSheetWaiter* SpecialShopSheetWaiter;
    [FieldOffset(0x240)] public ExcelSheet* SpecialShopSheet;
    [FieldOffset(0x248)] public Utf8String ShopName;
    [FieldOffset(0x2B0)] private int Unk2B0; // whether it's AgentShop or AgentFreeShop
    [FieldOffset(0x2B4)] private uint BuyItemIndex; // index into Items of the item currently being bought
    // 0x2B8 some other transaction state, int[3]
    [FieldOffset(0x2C4)] public bool WaitingForTransactionToFinish;
    [FieldOffset(0x2D8)] private int BuyItemCount;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
    public unsafe partial struct SpecialShopItem {
        [FieldOffset(0x00)] public byte Index;
        [FieldOffset(0x15C), FixedSizeArray] internal FixedSizeArray2<uint> _receiveItemIds;
        [FieldOffset(0x16C), FixedSizeArray] internal FixedSizeArray3<uint> _costItemIds; // meaning depends on CostTypes
        [FieldOffset(0x19C), FixedSizeArray] internal FixedSizeArray3<byte> _costTypes; // 2 = tomestone index, 3 = CurrencyManager special id, otherwise item id
        [FieldOffset(0x1A4)] private bool Unk1A4;
        [FieldOffset(0x1A5)] private bool ReceiveHq;
        [FieldOffset(0x1AC)] private byte CategoryOrderMajor; // ItemUICategory.OrderMajor
        [FieldOffset(0x1AD)] private byte CategoryOrderMinor; // ItemUICategory.OrderMinor
    }
}

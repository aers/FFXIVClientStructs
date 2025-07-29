namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSContentInventoryItem
//  Client::Game::ContentInventoryItem
//    Client::Game::InventoryItem
[GenerateInterop]
[Inherits<ContentInventoryItem>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public partial struct WKSContentInventoryItem {
    [FieldOffset(0x48)] public InventoryType WKSInventoryType;
    [FieldOffset(0x4C)] public short WKSItemSlot; // -1 = undefined
    // 2 bytes padding
    [FieldOffset(0x50)] public uint WKSItemId;
    [FieldOffset(0x54)] public short WKSItemQuantity;
    [FieldOffset(0x56)] public InventoryItem.ItemFlags WKSItemFlags;
    [FieldOffset(0x58)] public short WKSItemCollectability;
    // 6 bytes padding
}

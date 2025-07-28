namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSContentInventoryContainer
//  Client::Game::ContentInventoryContainer
//    Client::Game::InventoryContainer
[GenerateInterop]
[Inherits<ContentInventoryContainer>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public partial struct WKSContentInventoryContainer {
    [FieldOffset(0x28)] public StdVector<WKSContentInventoryItem> WKSItems;

    [VirtualFunction(7)]
    public partial void ClearItems();

    [VirtualFunction(8)]
    public partial void SetItem(InventoryType inventoryType, short slot, uint itemId, ushort quantity);

    [VirtualFunction(9)]
    public partial void SetItemEx(InventoryType inventoryType, short slot, uint itemId, ushort quantity, InventoryItem.ItemFlags flags, ushort collectability);
}

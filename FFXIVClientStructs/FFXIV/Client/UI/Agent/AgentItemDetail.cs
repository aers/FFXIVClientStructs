using FFXIVClientStructs.FFXIV.Client.Enums;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// TODO: remove with ItemKind field below
public enum ItemDetailKind : byte {
    ChatItem = 1,      // all items linked in chat, except event items, also used for some shops
    InventoryItem = 2, // all(?) items outside of chat, including event items
    ShopItem = 6,      // most shops use this, exceptions are grand company and sundry splendors
    ChatEventItem = 8  // event items linked in chat
}

// Client::UI::Agent::AgentItemDetail
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ItemDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[VirtualTable("48 89 18 48 8D 05 ?? ?? ?? ?? 48 89 07", 6)]
[StructLayout(LayoutKind.Explicit, Size = 0x220)]
public unsafe partial struct AgentItemDetail {
    [FieldOffset(0x118)] public DetailKind DetailKind;
    [FieldOffset(0x118), Obsolete($"Use {nameof(DetailKind)}")] public ItemDetailKind ItemKind;
    // Set to the item ID when hovering an item in the chat, otherwise it seems
    // to be different for each inventory. Doesn't appear to have any relation
    // to InventoryType.
    // -  4: EquippedItems
    // -  7: KeyItems
    // - 48: Inventory1
    // - 49: Inventory2
    // - 50: Inventory3
    // - 51: Inventory4
    // - 69: SaddleBag1
    // - 70: SaddleBag2
    // - 71: PremiumSaddleBag1
    // - 72: PremiumSaddleBag2
    [FieldOffset(0x11C)] public uint TypeOrId;
    [FieldOffset(0x120)] public uint Index; // The index of the item in the inventory. 0 for chat, ??? for KeyItems, position top-bottom inside a shop.
    [FieldOffset(0x124)] public int BuyQuantity; // The quantity selected for buying, which is previewed on the tooltip as "in bag" quantity, -1 outside shops
    [FieldOffset(0x128)] public byte Flag1; // Related to checking the inventory
    [FieldOffset(0x134)] public int MaxStackSize;
    [FieldOffset(0x138)] public uint ItemId;
    [FieldOffset(0x148)] public Utf8String String1;
    [FieldOffset(0x1B0)] public Utf8String String2;
    [FieldOffset(0x21A)] public byte Flag2; // This needs to be set to 1 for the item detail tooltip to show
    [FieldOffset(0x21E)] public byte Flag3; // If set to zero, avoids an early return in addon->Show()
}

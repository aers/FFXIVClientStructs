using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

public enum ItemDetailKind : byte {
    ChatItem = 1,      // all items linked in chat, except event items
    InventoryItem = 2, // all(?) items outside of chat, including event items
    ChatEventItem = 8  // event items linked in chat
}

// Client::UI::Agent::AgentItemDetail
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ItemDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1B8)]
public unsafe partial struct AgentItemDetail {
    [FieldOffset(0x118)] public ItemDetailKind ItemKind;
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
    [FieldOffset(0x120)] public uint Index; // The index of the item in the inventory. 0 for chat, ??? for KeyItems.
    [FieldOffset(0x128)] public byte Flag1; // Related to checking the inventory
    [FieldOffset(0x138)] public uint ItemId;
    [FieldOffset(0x148)] public Utf8String String1;
    [FieldOffset(0x1B2)] public byte Flag2; // This needs to be set to 1 for the item detail tooltip to show
    [FieldOffset(0x1B6)] public byte Flag3; // If set to zero, avoids an early return in addon->Show()
}

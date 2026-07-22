using FFXIVClientStructs.FFXIV.Client.Enums;
using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemDetail
//   Client::UI::Agent::AgentItemDetailBase
//     Client::UI::Agent::AgentInterface
//       Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ItemDetail)]
[GenerateInterop]
[Inherits<AgentItemDetailBase>]
[VirtualTable("48 89 18 48 8D 05 ?? ?? ?? ?? 48 89 07", 6)]
[StructLayout(LayoutKind.Explicit, Size = 0x220)]
public unsafe partial struct AgentItemDetail {
    [FieldOffset(0x118)] public DetailKind DetailKind;
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
    [FieldOffset(0x128)] public uint Flag1; // Related to checking the inventory
    [FieldOffset(0x134)] public int MaxStackSize;
    [FieldOffset(0x138)] public uint ItemId;
    [FieldOffset(0x13C)] private int Unk13C;
    [FieldOffset(0x148)] public Utf8String String1;
    [FieldOffset(0x1B0)] public Utf8String String2;
    [FieldOffset(0x21A)] public byte Flag2; // This needs to be set to 1 for the item detail tooltip to show
    [FieldOffset(0x21C)] private byte Unk21C;
    [FieldOffset(0x21E)] public byte Flag3; // If set to zero, avoids an early return in addon->Show()

    /// <remarks>
    /// <paramref name="flag1"/> is written as a 32-bit value at offset <c>0x128</c>.
    /// </remarks>
    [MemberFunction("48 89 5C 24 08 48 89 6C 24 10 48 89 74 24 18 57 48 83 EC 20 8B FA 41 8B E9 BA A1 00 00 00 41 8B F0 48 8B D9 E8 ?? ?? ?? ??")]
    public partial void HandleItemHover(DetailKind detailKind, uint typeOrId, uint index, int buyQuantity, uint flag1);

    [MemberFunction("40 55 53 56 57 41 54 41 55 41 56 41 57 48 8D 6C 24 F9 48 81 EC A8 00 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 F7 48 8B 5D 7F 4C 8B F1 8B 4D 77 49 8B F9 44 8B 6D 6F 49 8B F0 4C 89 4D AF 4C 8B FA")]
    public partial bool OnItemHovered(InventoryItem** item, InventoryType* inventoryType, ushort* slot, uint index, uint typeOrId, InventoryItem* fallbackItem);
}

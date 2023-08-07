using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Shop)]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct AgentShop {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x88)] public AtkEventInterface* EventReceiver; // can be an agent or something else

    [FieldOffset(0x98)] public byte* ShopName; // only for SpecialShop ?

    [FieldOffset(0xAC)] public uint DialogAddonId; // also not always used

    [FieldOffset(0xB8)] public ShopItem* ItemReceive;
    [FieldOffset(0xC0)] public ShopItem* ItemCost; // there is 3 of these for every item

    [FieldOffset(0xD0)] public int ItemReceiveCount;

    [FieldOffset(0xDC)] public int ItemCostCount;

    [FieldOffset(0x100)] public int SelectedItemIndex;
    [FieldOffset(0x104)] public int SelectedItemStackSize;

    public Span<ShopItem> ItemReceiveSpan => ItemReceive == null ? new Span<ShopItem>() : new Span<ShopItem>(ItemReceive, ItemReceiveCount);
    public Span<ShopItem> ItemCostSpan => ItemCost == null ? new Span<ShopItem>() : new Span<ShopItem>(ItemCost, ItemCostCount);

    [StructLayout(LayoutKind.Explicit, Size = 0x240)]
    public struct ShopItem {
        [FieldOffset(0x00)] public Utf8String ItemName;
        //[FieldOffset(0x68)] public Utf8String UnkString1;
        //[FieldOffset(0xD0)] public Utf8String UnkString2;
        [FieldOffset(0x138)] public Utf8String Qty;
        [FieldOffset(0x1A0)] public Utf8String Set;
        [FieldOffset(0x208)] public uint CategoryIconId;
        [FieldOffset(0x20C)] public uint ItemIconId;
        //[FieldOffset(0x210)] public uint Unk210;
        [FieldOffset(0x214)] public uint ItemCount;
        [FieldOffset(0x218)] public uint OwnedItemCount;
        [FieldOffset(0x21C)] public uint ItemId;
        //[FieldOffset(0x220)] public uint Unk220;
        [FieldOffset(0x224)] public uint MaxStack;
    }
}

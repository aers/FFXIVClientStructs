using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRetainer
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Client::UI::Agent::AgentInventoryContext::InventoryContextEvent
[Agent(AgentId.Retainer)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<AgentInventoryContext.InventoryContextEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x68D0)]
public unsafe partial struct AgentRetainer {
    [FieldOffset(0x58)] public InventoryType SellItemInventoryType;
    [FieldOffset(0x5C)] public ushort SellItemInventorySlot;
    
    [FieldOffset(0x4B74)] public int SellItemTotalPrice;
    [FieldOffset(0x4B78)] public int SellItemPriceLimit;
    [FieldOffset(0x4B7C)] public int SellItemUnitPrice;
    [FieldOffset(0x4B80)] public int SellItemQuantity;

    [FieldOffset(0x4B84)] public int ContextMenuIndex;
    [FieldOffset(0x4B88)] public int SellListEntryCount;

    [FieldOffset(0x4B90), FixedSizeArray] internal FixedSizeArray20<SellListEntry> _sellListEntries;

    [FieldOffset(0x688C)] public uint RetainerSellListAddonId;
    [FieldOffset(0x6890)] public uint RetainerSellAddonId;
    [FieldOffset(0x68B0)] public ShopEventHandler* ShopEventHandler;
    
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 83 BF ?? ?? ?? ?? ?? 74 ?? 8B CE")]
    public partial void OpenRetainerSell(InventoryType inventoryType, ushort inventorySlot);

    [StructLayout(LayoutKind.Explicit, Size = 0x168)]
    public struct SellListEntry {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x08)] public Utf8String ItemName;
        [FieldOffset(0x70)] public int Quantity;
        [FieldOffset(0x78)] public Utf8String TotalPriceText;
        [FieldOffset(0xE0)] public Utf8String UnitPriceText;
        [FieldOffset(0x148)] public ushort InventorySlot;
    }
}

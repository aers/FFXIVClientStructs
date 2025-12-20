using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMiragePrismPrismSetConvert
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MiragePrismPrismSetConvert)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentMiragePrismPrismSetConvert {
    [FieldOffset(0x28)] public AgentData* Data;

    [MemberFunction("40 53 41 55 48 81 EC ?? ?? ?? ?? 0F B7 84 24")]
    public partial void Open(uint itemId, InventoryType inventoryType, int slot, int openerAddonId, bool enableStoring);

    // OpenPreview in data.yml
    public void Open(uint itemId) => Open(itemId, InventoryType.Invalid, 0, 0, false);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1940)]
    public partial struct AgentData {
        [FieldOffset(0x18)] public int ContextMenuItemIndex;

        [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray5<ItemSet> _itemSets;
        [FieldOffset(0x2C0)] public uint NumItemsInSet;
        [FieldOffset(0x2C4), FixedSizeArray] internal FixedSizeArray5<ItemSetItem> _items;

        [StructLayout(LayoutKind.Explicit, Size = 0x80)]
        public struct ItemSet {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint IconId;

            [FieldOffset(0x10)] public Utf8String Name;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x24)]
        public struct ItemSetItem {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint IconId;
            [FieldOffset(0x08)] private uint SlotIndex; // probably? seems to match MainHand, OffHand, Head, Body etc.

            [FieldOffset(0x0C)] public InventoryType InventoryType;

            [FieldOffset(0x14)] public uint Slot;
        }
    }
}

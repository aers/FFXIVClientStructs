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

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 28 C6 40 02 0B")]
    public partial void Open(uint itemId, InventoryType inventoryType, int slot, int openerAddonId, bool enableStoring);

    // OpenPreview in data.yml
    public void Open(uint itemId) => Open(itemId, InventoryType.Invalid, 0, 0, false);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x18C0)]
    public partial struct AgentData {
        [FieldOffset(0x14)] public int ContextMenuItemIndex;

        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray5<ItemSet> _itemSets;
        [FieldOffset(0x288)] public uint NumItemsInSet;
        [FieldOffset(0x28C), FixedSizeArray] internal FixedSizeArray5<ItemSetItem> _items;
        [FieldOffset(0x380)] internal Utf8String Unk380;
        [FieldOffset(0x3F8)] internal Utf8String Unk3F8;

        [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
        public struct ItemSetItem {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint IconId;
            [FieldOffset(0x08)] public InventoryType InventoryType;
            [FieldOffset(0x10)] public uint Slot;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x78)]
        public struct ItemSet {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint IconId;
            [FieldOffset(0x08)] public Utf8String Name;
        }
    }
}

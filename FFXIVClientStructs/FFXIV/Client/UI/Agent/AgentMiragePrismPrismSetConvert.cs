using FFXIVClientStructs.FFXIV.Client.Game;

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
    public partial bool Open(uint itemId, InventoryType inventoryType, int slot, ushort crystallizeAddonId, ushort prismBoxAddonId, bool enableStoring);

    // OpenPreview in data.yml
    public void Open(uint itemId) => Open(itemId, InventoryType.Invalid, 0, 0, 0, false);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1940)]
    public partial struct AgentData {
        [FieldOffset(0x00)] public uint SourceItemId;
        [FieldOffset(0x04)] public InventoryType SourceContainer;
        [FieldOffset(0x08)] public uint SourceSlot;
        [FieldOffset(0x0C)] public ushort CrystallizeAddonId; // MiragePrismPrismBoxCrystallize, the opener
        [FieldOffset(0x0E)] public ushort PrismBoxAddonId; // MiragePrismPrismBoxAddonId

        [FieldOffset(0x10)] public SetConvertState State;
        [FieldOffset(0x14)] public uint SelectedSetIndex;
        [FieldOffset(0x18)] public int ContextMenuItemIndex;
        [FieldOffset(0x1C)] public uint YesNoAddonId;
        [FieldOffset(0x24)] public uint GlamourPrismCount;
        /// <summary>Index for <see cref="MirageManager.PrismBoxItemIds"/></summary>
        [FieldOffset(0x28)] public uint PrismBoxIndex;
        [FieldOffset(0x2C), Obsolete("Renamed to EnableStoring")] public bool EnableSorting;
        [FieldOffset(0x2C)] public bool EnableStoring; // false = preview mode
        [FieldOffset(0x2D)] public bool StoreInExistingOutfit; // false = will be a new outfit, set on Open
        [FieldOffset(0x38)] public uint ItemSetCount;

        [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray5<ItemSet> _itemSets;
        [FieldOffset(0x2C0)] public uint NumItemsInSet;
        [FieldOffset(0x2C4), FixedSizeArray] internal FixedSizeArray9<ItemSetItem> _items;
        [FieldOffset(0x408)] private uint Unk408;
        [FieldOffset(0x40C)] private uint Unk40C;
        [FieldOffset(0x410), FixedSizeArray] internal FixedSizeArray190<HandInItem> _handIns;
        [FieldOffset(0x18D8)] public Utf8String HandInItemName; // for tooltip?

        [StructLayout(LayoutKind.Explicit, Size = 0x80)]
        public struct ItemSet {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint IconId;
            [FieldOffset(0x08)] public uint SlotUnlockMask;

            [FieldOffset(0x10)] public Utf8String Name;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x24)]
        public struct ItemSetItem {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint IconId;
            [FieldOffset(0x08)] public uint MirageStoreSetItemColumn; // column index of MirageStoreSetItem

            [FieldOffset(0x0C)] public InventoryType InventoryType;

            [FieldOffset(0x14)] public uint Slot;
        }

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
        public partial struct HandInItem {
            [FieldOffset(0x00)] public uint ItemId;
            [FieldOffset(0x04)] public uint IconId;
            [BitField<bool>(nameof(HasStain0), 0)]
            [BitField<bool>(nameof(IsItemStainConditionLocked), 1)]
            [BitField<uint>(nameof(Stain0Color), 8, 24)]
            [FieldOffset(0x08)] private uint BitField1;
            [BitField<bool>(nameof(HasStain1), 0)]
            [BitField<uint>(nameof(Stain1Color), 8, 24)]
            [FieldOffset(0x0C)] private uint BitField2;
            [FieldOffset(0x10)] public InventoryType Container;
            [FieldOffset(0x14)] public uint Slot;
            [FieldOffset(0x18)] public bool IsLoaded;
        }
    }
}

public enum SetConvertState : uint {
    None = 0, // idle/closed
    Loading = 1, // loads the icons/names
    Unk2 = 2,
    Unk3 = 3,
    RefreshHandInSlots = 4,
    Ready = 5,
}

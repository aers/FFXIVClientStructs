using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRepair
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Repair)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xDE0)]
public unsafe partial struct AgentRepair {
    [FieldOffset(0x28)] private nint Unk28; // new VTable that seems to be used with the new "Repair all" function
    [FieldOffset(0x30)] public InventoryItem* TargetInventorySlot; // temporarily set when opening via rightlick on an item
    [FieldOffset(0x38)] public bool IsSelfRepairOpen;
    [FieldOffset(0x39)] public bool UseSelfRepair;
    [FieldOffset(0x40)] public NpcRepairCallback* NpcRepairCallback;
    [FieldOffset(0x48)] public InventoryItemRef SelectedItem;
    [FieldOffset(0x58)] public int DialogAddonId;
    [FieldOffset(0x5C)] public ItemFilter Filter;
    [FieldOffset(0x60)] public int SelectedItemIndex;
    [FieldOffset(0x64)] public int ShownRepairEntryAmount;
    [FieldOffset(0x68)] public int TotalRepairCost;
    /// <remarks> Temporarily used while refreshing. 3 per Item. </remarks>
    [FieldOffset(0x70)] private StdVector<Utf8String> Strings;
    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray140<InventoryItemRef> _filterItemRefs;
    [FieldOffset(0x948)] public bool IsAddonRefreshPending;
    /// <remarks> Amount of total inventory items for the selected <see cref="Filter"/> </remarks>
    [FieldOffset(0x94C)] public int FilterItemCount;
    [FieldOffset(0x950)] public int ProcessedFilterItemCount;
    /// <remarks> Holds all items of the selected Filter in the same order as ItemODR </remarks>
    [FieldOffset(0x954), FixedSizeArray] internal FixedSizeArray140<ItemEntry> _inventoryItemEntries;
    [FieldOffset(0xDB4)] private int UnkDB4; // This is checked in AgentRepair_Update for 1 or 2
    [FieldOffset(0xDB8)] private InventoryItemRef UnkDB8ItemRef; // from here on saved state when opening RepairAuto?
    [FieldOffset(0xDC8)] private ItemFilter UnkDC8Filter;
    [FieldOffset(0xDCC)] private byte UnkDCC;
    [FieldOffset(0xDD0)] private int UnkDD0AddonId;
    [FieldOffset(0xDD4)] private bool UnkDD4;
    [FieldOffset(0xDD5)] private bool UnkDD5;
    [FieldOffset(0xDD6)] private bool UnkDD6;
    [FieldOffset(0xDD8)] public int RepairAutoAddonId;

    [FieldOffset(0x48), Obsolete("Use SelectedItem.Container")] public int SelectedItemInventoryType;
    [FieldOffset(0x4C), Obsolete("Use SelectedItem.Slot")] public ushort SelectedItemInventorySlot;
    [FieldOffset(0x50), Obsolete("Use SelectedItem.ItemId")] public int SelectedItemId;
    [FieldOffset(0x58), Obsolete("Renamed to DialogAddonId")] public int AddonId_SelectYesno;
    [FieldOffset(0x5C), Obsolete("Renamed to Filter")] public int InventoryContainerIndex;
    [FieldOffset(0x64), Obsolete("Renamed to ShownRepairEntryAmount")] public int RepairableItemAmount;
    [FieldOffset(0x88), FixedSizeArray, Obsolete("Use to FilterItemRefs")] internal FixedSizeArray140<RepairItemInfo> _repairItemInfos;
    [FieldOffset(0x94C), Obsolete("Renamed to InventoryItemEntryAmount")] public int RepairEntriesAmount;
    [FieldOffset(0x954), FixedSizeArray, Obsolete("Use InventoryItemEntries")] internal FixedSizeArray140<RepairEntry> _repairEntries;
    
    [Obsolete("Use ChangeRepairInventory.")]
    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 08 74 2D")]
    public partial RepairEntry* ChangeInventoryContainer(bool arg0); // false for self- and NPC-Repair but will be set in 0xDCC. unsure for what that's used.

    /// <summary>
    /// Changes the selected inventory container of the repair gear dropdown.
    /// </summary>
	/// <remarks>
	/// Needs <see cref="Filter"/> to be set first.
	/// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 08 74 2D")]
    public partial ItemEntry* ChangeRepairInventory(bool arg0); // false for self- and NPC-Repair but will be set in 0xDCC. unsure for what that's used.

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct ItemEntry {
        [FieldOffset(0x0)] public InventoryType InventoryType;
        [FieldOffset(0x4)] public int Slot;
    }

    // TODO: remove (was replaced by InventoryItemRef)
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct RepairItemInfo {
        [FieldOffset(0x0)] public int InventoryType;
        [FieldOffset(0x4)] public ushort Slot;
        [FieldOffset(0x8)] public int ItemId;
    }

    // TODO: remove with ChangeInventoryContainer (was replaced by ItemEntry)
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct RepairEntry {
        [FieldOffset(0x0)] public uint InventoryType;
        [FieldOffset(0x4)] public uint Slot;
    }
	
    public enum ItemFilter {
        None = -1,
        Equipped,
        ArmouryMainHandOffHand,
        ArmouryHeadBodyHands,
        ArmouryLegsFeet,
        ArmouryNeckEars,
        ArmouryWristsRing,
        Inventory
    }
}

using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRepair
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Repair)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xDE0)]
public unsafe partial struct AgentRepair {
	[FieldOffset(0x28)] private nint Unk_28; // new VTable that seems to be used with the new "Repair all" function.  off_1420D26F0   dq offset sub_140C4F040 ; 
    [FieldOffset(0x30)] private nint Unk_30;
    [FieldOffset(0x38)] public bool IsSelfRepairOpen;
    [FieldOffset(0x39)] public bool UseSelfRepair;
    [FieldOffset(0x40)] private nint CustomTalkHandler; // assigned when using NPC. .data:0000000142740FB8 off_142740FB8   dq offset off_142175380 ;
    [FieldOffset(0x48)] public int SelectedItemInventoryType;
    [FieldOffset(0x4C)] public ushort SelectedItemInventorySlot;
    [FieldOffset(0x50)] public int SelectedItemId;
    [FieldOffset(0x58)] public int AddonId_SelectYesno;
    [Obsolete("InventoryContainerIndex is deprecated, please use InventoryContainer instead.")]
    [FieldOffset(0x5C)] public int InventoryContainerIndex; // Used to lookup static array. Mapped index ids of repair gear dropdown. (7 = Equipped, 0 = Main/Off Hand, 1 = Head/Body/Hands, ...)
    [FieldOffset(0x5C)] public InventoryContainer InventoryContainer;
    [FieldOffset(0x60)] public int SelectedItemIndex;
    [Obsolete("RepairableItemAmount is deprecated, please use ShownRepairEntryAmount instead.")]
    [FieldOffset(0x64)] public int RepairableItemAmount;
    [FieldOffset(0x64)] public int ShownRepairEntryAmount;
    [FieldOffset(0x68)] public int TotalRepairCost;
    [FieldOffset(0x70)] private nint Unk_70; // points to a data structure that holds all information about the currently shown repairable items. likely some Atk Data?
    [FieldOffset(0x78)] private nint Unk_78; // same pointer as in Unk_70
    [FieldOffset(0x80)] private nint Unk_80;
    [FieldOffset(0x88)][FixedSizeArray] internal FixedSizeArray140<RepairItemInfo> _repairItemInfos;
    [FieldOffset(0x948)] private byte Unk_948; // Loading state for InventoryItemEntries. Is true while InventoryItemEntryAmount and Unk_950 are unequal
    [FieldOffset(0x94C)] public int InventoryItemEntryAmount; // Amount of total inventory items for the selected InventoryContainerIndex
    [Obsolete("RepairEntriesAmount is deprecated, please use InventoryItemEntryAmount instead.")]
    [FieldOffset(0x94C)] public int RepairEntriesAmount; 
    [FieldOffset(0x950)] private int Unk_950; // Ends to be the same number as in InventoryItemEntryAmount. Could be the amount of items in InventoryItemEntries after it loaded.
    [FieldOffset(0x954)][FixedSizeArray] internal FixedSizeArray140<ItemEntry> _inventoryItemEntries; // Holds all items of the selected InventoryContainerIndex in the same order as ItemODR
    [Obsolete("_repairEntries is deprecated, please use _inventoryItemEntries instead.")]
    [FieldOffset(0x954)][FixedSizeArray] internal FixedSizeArray140<RepairEntry> _repairEntries;
    [FieldOffset(0xDB4)] private int Unk_DB4; // This is checked in AgentRepair_Update for 1 or 2
    [FieldOffset(0xDB8)] private int Unk_DB8; // Some InventoryType
	[FieldOffset(0xDBC)] private ushort Unk_DBC;
    [FieldOffset(0xDC0)] private nint Unk_DC0;
    [FieldOffset(0xDC8)] private int Unk_DC8;
    [FieldOffset(0xDCC)] private byte Unk_DCC;
    [FieldOffset(0xDD0)] private int Unk_DDD0; // Maybe some AddonId
    [FieldOffset(0xDD4)] private bool Unk_DD4; // Some state. Is set from argument in ChangeInventoryContainer. Changes for a short amount of time to true after "Repair all"
   
    [Obsolete("ChangeInventoryContainer is deprecated, please use ChangeRepairInventory instead.")]
    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 08 74 2D")]
    public partial RepairEntry* ChangeInventoryContainer(bool arg0); // false for self- and NPC-Repair but will be set in 0xDCC. unsure for what that's used.

    /// <summary>
    /// Changes the selected inventory container of the repair gear dropdown.
    /// </summary>
	/// <remarks>
	/// Needs InventoryContainerIndex to be set first. (7 = Equipped, 0 = Main/Off Hand, 1 = Head/Body/Hands, ...)
	/// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 08 74 2D")]
    public partial ItemEntry* ChangeRepairInventory(bool arg0); // false for self- and NPC-Repair but will be set in 0xDCC. unsure for what that's used.

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct RepairItemInfo {
        [FieldOffset(0x0)] public int InventoryType;
        [FieldOffset(0x4)] public ushort Slot;
        [FieldOffset(0x8)] public int ItemId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct ItemEntry {
        [FieldOffset(0x0)] public uint InventoryType;
        [FieldOffset(0x4)] public uint Slot;
    }

    [Obsolete("RepairEntry is deprecated, please use ItemEntry instead.")]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct RepairEntry {
        [FieldOffset(0x0)] public uint InventoryType;
        [FieldOffset(0x4)] public uint Slot;
    }
	
    public enum InventoryContainer : int {
        None = -1,
        Equipped,
        MainHandOffHand,
        HeadBodyHands,
        LegsFeet,
        NeckEars,
        WristsRing,
        Inventory
    }
}

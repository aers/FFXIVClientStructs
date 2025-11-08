using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRepair
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Repair)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xDD0)]
public unsafe partial struct AgentRepair {
    [FieldOffset(0x28)] private nint Unk_28;
    [FieldOffset(0x30)] public bool IsSelfRepairOpen;
    [FieldOffset(0x31)] public bool UseSelfRepair;
    [FieldOffset(0x38)] private nint CustomTalkHandler; // assigned when using NPC. .data:0000000142740FB8 off_142740FB8   dq offset off_142175380 ;
    [FieldOffset(0x40)] public int SelectedItemInventoryType;
    [FieldOffset(0x44)] public ushort SelectedItemInventorySlot;
    [FieldOffset(0x48)] public int SelectedItemId;
    [FieldOffset(0x50)] public int AddonId_SelectYesno;
    [FieldOffset(0x54)] public int InventoryContainerIndex; // Used to lookup static array. Mapped index ids of repair gear dropdown. (7 = Equipped, 0 = Main/Off Hand, 1 = Head/Body/Hands, ...)
    [FieldOffset(0x58)] public int SelectedItemIndex;
    [FieldOffset(0x5C)] public int ShownRepairEntryAmount;
    [FieldOffset(0x60)] public int TotalRepairCost;
    [FieldOffset(0x68)] private nint Unk_68; // points to a data structure that holds all information about the currently shown repairable items. likely some Atk Data?
    [FieldOffset(0x70)] private nint Unk_70; // same pointer as in Unk_68
    [FieldOffset(0x78)] private nint Unk_78;
    [FieldOffset(0x80)][FixedSizeArray] internal FixedSizeArray140<RepairItemInfo> _repairItemInfos;
    [FieldOffset(0x940)] private byte Unk_940; // Seems to be some loading state
    [FieldOffset(0x944)] public int RepairEntriesAmount;
    [FieldOffset(0x948)] private int Unk_948; // Ends to be the same number as in RepairEntriesAmount. Maybe some counter for adding up AtkEntries.
    [FieldOffset(0x94C)][FixedSizeArray] internal FixedSizeArray140<RepairEntry> _repairEntries;
    [FieldOffset(0xDAC)] private int Unk_DAC; // This is checked in AgentRepair_Update for 1 or 2
    [FieldOffset(0xDB0)] private int Unk_DB0; // Some InventoryType
    [FieldOffset(0xDB4)] private ushort Unk_DB4;
    [FieldOffset(0xDB8)] private nint Unk_DB8;
    [FieldOffset(0xDC0)] private int Unk_DC0;
    [FieldOffset(0xDC4)] private byte Unk_DC4;
    [FieldOffset(0xDC8)] private int Unk_DC8; // Maybe some AddonId
    [FieldOffset(0xDCC)] private bool Unk_DCC; // Some state. Is set from argument in ChangeInventoryContainer. Changes for a short amount of time to true after "Repair all"


    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 08 74 2D")]
    public partial RepairEntry* ChangeInventoryContainer(bool arg0); // false for self- and NPC-Repair but will be set in 0xDCC. unsure for what that's used.

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct RepairItemInfo {
        [FieldOffset(0x0)] public int InventoryType;
        [FieldOffset(0x4)] public ushort Slot;
        [FieldOffset(0x8)] public int ItemId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct RepairEntry {
        [FieldOffset(0x0)] public uint InventoryType;
        [FieldOffset(0x4)] private uint Unk_4;
    }
}

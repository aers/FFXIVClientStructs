using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentNpcTrade
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.NpcTrade)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x850)]
public unsafe partial struct AgentNpcTrade {
    [FieldOffset(0x114)] public sbyte SelectedTurnInSlot; // you can have multiple items to turn in. this defaults to -1 and when you select one of them it becomes its index (starts at 0)
    [FieldOffset(0x124)] public short SelectedTurnInSlotItemOptions; // after you select a SelectedTurnInSlot, you can have multiple varieties of the item, like HQ and NQ. this is the amount of options you have for this slot
    [FieldOffset(0x130), FixedSizeArray] internal FixedSizeArray140<Pointer<InventoryItem>> _selectedTurnInSlotItemOptionValues;
}

using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFreeCompanyChest
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FreeCompanyChest)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1EF0)]
public unsafe partial struct AgentFreeCompanyChest {
    [MemberFunction("E9 ?? ?? ?? ?? 84 C0 75 5C")]
    public partial void MoveItemInChest(InventoryType sourceInventory, uint sourceSlot, InventoryType destinationInventory, uint destinationSlot);
}

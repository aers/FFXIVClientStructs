namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentLoot
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Loot)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x388)]
public unsafe partial struct AgentLoot {
    [FieldOffset(0x34)] public byte HoveredSlotIndex;
    [FieldOffset(0x38)] public uint HoveredItemId;
    [FieldOffset(0x84)] public int SelectedSlotIndex;
    [FieldOffset(0x8C)] public int NumItems;
}

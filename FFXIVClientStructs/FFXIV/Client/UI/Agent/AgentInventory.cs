namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentInventory
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Inventory)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public partial struct AgentInventory {
    [FieldOffset(0x30)] public uint OpenTitleId;
    [FieldOffset(0x34)] public uint OpenAddonId;
    [FieldOffset(0x38)] public uint OpenType;
}

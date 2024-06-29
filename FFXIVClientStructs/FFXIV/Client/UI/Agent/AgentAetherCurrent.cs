namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentAetherCurrent
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.AetherCurrent)]
[GenerateInterop]
[Inherits<AgentInterface>]
[VirtualTable("C6 43 30 01 48 8D 05", 7)]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public partial struct AgentAetherCurrent {
    [FieldOffset(0x70)] public byte TabIndex;
}

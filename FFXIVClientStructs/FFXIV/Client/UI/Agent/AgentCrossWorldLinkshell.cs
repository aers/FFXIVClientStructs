namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCrossWorldLinkshell
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CrossWorldLinkShell)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x168)]
public unsafe partial struct AgentCrossWorldLinkshell {
    [FieldOffset(0x130)] public byte SelectedCWLSIndex;
}

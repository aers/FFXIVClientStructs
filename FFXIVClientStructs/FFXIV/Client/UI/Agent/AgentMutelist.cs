using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMutelist
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Mutelist)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct AgentMutelist {
    [FieldOffset(0x58)] public ulong SelectedPlayerAccountId;
    [FieldOffset(0x68)] public Utf8String SelectedPlayerFullName; // includes cross world icon
}

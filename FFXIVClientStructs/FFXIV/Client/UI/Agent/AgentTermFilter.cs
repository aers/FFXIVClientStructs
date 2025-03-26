namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTermFilter
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.TermFilter)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct AgentTermFilter {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4B 8B 8C C8"), GenerateStringOverloads]
    public partial void OpenNewFilterWindow(CStringPointer message = default);
}

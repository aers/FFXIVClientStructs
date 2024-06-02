namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentPartyMember
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.PartyMember)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct AgentPartyMember {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 56 20"), GenerateStringOverloads]
    public partial void Promote(byte* name, ushort parentAddonId, ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 66 49 8B 4E 20"), GenerateStringOverloads]
    public partial void Kick(byte* name, ushort parentAddonId, ulong contentId);
}

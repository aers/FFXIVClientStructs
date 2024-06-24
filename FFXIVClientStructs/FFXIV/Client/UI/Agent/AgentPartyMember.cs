namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentPartyMember
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.PartyMember)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct AgentPartyMember {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 0F 48 B8 ?? ?? ?? ?? ?? ?? ?? ??"), GenerateStringOverloads]
    public partial void Promote(byte* name, ushort parentAddonId, ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 6A 48 8B 07 49 8B 4F 20"), GenerateStringOverloads]
    public partial void Kick(byte* name, ushort parentAddonId, ulong contentId);
}

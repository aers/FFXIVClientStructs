namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentPartyMember
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.PartyMember)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct AgentPartyMember {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? ?? ?? ?? 48 8B 56"), GenerateStringOverloads]
    public partial void Promote(CStringPointer name, ushort parentAddonId, ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? ?? ?? ?? 48 8B 4E ?? 48 2B 4E"), GenerateStringOverloads]
    public partial void Kick(CStringPointer name, ushort parentAddonId, ulong contentId);
}

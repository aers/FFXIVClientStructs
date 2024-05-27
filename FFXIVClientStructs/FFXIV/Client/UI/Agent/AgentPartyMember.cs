namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.SocialPartyMember)]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentPartyMember {

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 56 20"), GenerateStringOverloads]
    public partial void Promote(byte* name, ushort parentAddonId, ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 66 49 8B 4E 20"), GenerateStringOverloads]
    public partial void Kick(byte* name, ushort parentAddonId, ulong contentId);
}

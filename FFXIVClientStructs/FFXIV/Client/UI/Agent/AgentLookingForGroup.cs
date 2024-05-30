namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.LookingForGroup)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x2D18)]
public partial struct AgentLookingForGroup {
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B FA 48 8B D9 E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 85 C9")]
    public partial bool OpenListing(ulong listingId);
}

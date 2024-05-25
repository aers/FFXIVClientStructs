using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.SocialPartyMember)]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct AgentPartyMember {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 56 20")]
    public partial void Promote(byte* name, ulong contentId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 66 49 8B 4E 20")]
    public partial void Kick(byte* name, ulong contentId);
}

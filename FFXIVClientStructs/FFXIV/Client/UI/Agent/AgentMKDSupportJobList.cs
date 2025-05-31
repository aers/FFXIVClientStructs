namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MKDSupportJobList)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AgentMKDSupportJobList {
    [MemberFunction("40 53 48 83 EC ?? 0F B6 DA E8 ?? ?? ?? ?? 48 85 C0 74 ?? 38 58")]
    public partial void ChangeSupportJob(byte id);
}

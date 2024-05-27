namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Achievement)]
[StructLayout(LayoutKind.Explicit, Size = 0xFD10)]
public partial struct AgentAchievement {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 8B 46 ?? 48 63 4E")]
    public partial void OpenById(uint achievementId);
}

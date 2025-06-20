namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.JournalResult)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public partial struct AgentJournalResult {
    [FieldOffset(0x30)] public StdVector<QuestRewardItem> RewardItems;
    [FieldOffset(0x4C)] public int ContextMenuSelectedRewardIndex;
}

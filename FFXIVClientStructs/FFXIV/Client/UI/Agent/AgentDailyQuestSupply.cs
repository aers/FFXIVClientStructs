namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DailyQuestSupply)]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
[GenerateInterop]
[Inherits<AgentInterface>]
public partial struct AgentDailyQuestSupply {
    [FieldOffset(0x54)] public uint ContextMenuItemId;
}

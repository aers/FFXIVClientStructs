namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DailyQuestSupply)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct AgentDailyQuestSupply {
    [FieldOffset(0x54)] public uint ContextMenuItemId;
}

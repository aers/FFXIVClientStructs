using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DailyQuestSupply)]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct AgentDailyQuestSupply {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x54)] public uint ContextMenuItemId;
}

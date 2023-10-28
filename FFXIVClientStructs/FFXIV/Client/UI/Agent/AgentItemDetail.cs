using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ItemDetail)]
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe partial struct AgentItemDetail {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x138)] public uint ItemId;
}

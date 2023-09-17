using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MiragePrismPrismItemDetail)]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AgentMiragePrismPrismItemDetail {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x54)] public uint ItemId;
}

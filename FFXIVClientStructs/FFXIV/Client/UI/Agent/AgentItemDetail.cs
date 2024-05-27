namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ItemDetail)]
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentItemDetail {
    [FieldOffset(0x138)] public uint ItemId;
}

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ItemDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe partial struct AgentItemDetail {
    [FieldOffset(0x138)] public uint ItemId;
}

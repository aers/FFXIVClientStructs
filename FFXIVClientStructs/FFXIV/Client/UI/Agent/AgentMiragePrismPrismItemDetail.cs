namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MiragePrismPrismItemDetail)]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentMiragePrismPrismItemDetail {
    [FieldOffset(0x54)] public uint ItemId;
}

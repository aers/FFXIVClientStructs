namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MiragePrismPrismItemDetail)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AgentMiragePrismPrismItemDetail {
    [FieldOffset(0x54)] public uint ItemId;
}

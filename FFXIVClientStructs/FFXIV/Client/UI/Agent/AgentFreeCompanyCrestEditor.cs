namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.FreeCompanyCrestEditor)]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentFreeCompanyCrestEditor {
    [FieldOffset(0x60)] public CrestData OriginalCrest;
    [FieldOffset(0x68)] public CrestData CurrentCrest;
}

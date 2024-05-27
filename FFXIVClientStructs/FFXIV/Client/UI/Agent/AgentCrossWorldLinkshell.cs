namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.CrossWorldLinkShell)]
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentCrossWorldLinkshell {
    [FieldOffset(0x120)] public byte SelectedCWLSIndex;
}

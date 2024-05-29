namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.CrossWorldLinkShell)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe partial struct AgentCrossWorldLinkshell {
    [FieldOffset(0x120)] public byte SelectedCWLSIndex;
}

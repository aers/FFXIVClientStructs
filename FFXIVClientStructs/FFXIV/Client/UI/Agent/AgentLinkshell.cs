namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Linkshell)]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentLinkshell {
    [FieldOffset(0xA8)] public byte SelectedLSIndex;
}

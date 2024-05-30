namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Linkshell)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct AgentLinkshell {
    [FieldOffset(0xA8)] public byte SelectedLSIndex;
}

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Linkshell)]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct AgentLinkshell {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0xA8)] public byte SelectedLSIndex;
}

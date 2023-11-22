using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.CrossWorldLinkShell)]
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe partial struct AgentCrossWorldLinkshell {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x120)] public byte SelectedCWLSIndex;
}

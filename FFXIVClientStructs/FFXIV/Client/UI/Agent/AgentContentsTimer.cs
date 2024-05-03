using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ContentsTimer)]
[StructLayout(LayoutKind.Explicit, Size = 0x1820)]
public partial struct AgentContentsTimer {
    [FieldOffset(0)] public AgentInterface AgentInterface;

    [FieldOffset(0x17CC)] public uint ContextMenuItemId;
}

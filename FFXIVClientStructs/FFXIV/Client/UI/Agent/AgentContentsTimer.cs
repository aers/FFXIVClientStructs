namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ContentsTimer)]
[StructLayout(LayoutKind.Explicit, Size = 0x1820)]
[GenerateInterop]
[Inherits<AgentInterface>]
public partial struct AgentContentsTimer {

    [FieldOffset(0x17CC)] public uint ContextMenuItemId;
}

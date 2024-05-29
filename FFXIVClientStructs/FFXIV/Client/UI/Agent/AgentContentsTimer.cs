namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ContentsTimer)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1820)]
public partial struct AgentContentsTimer {

    [FieldOffset(0x17CC)] public uint ContextMenuItemId;
}

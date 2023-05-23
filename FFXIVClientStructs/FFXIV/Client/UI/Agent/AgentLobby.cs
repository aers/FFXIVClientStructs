using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Lobby)]
[StructLayout(LayoutKind.Explicit, Size = 0x1DD0)]
public unsafe struct AgentLobby
{
    public static AgentLobby* Instance()
    {
        return (AgentLobby*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(
            AgentId.Lobby);
    }

    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x10E8)] public ulong SelectedCharacterId;
    [FieldOffset(0x10F0)] public byte DataCenter;
    [FieldOffset(0x10F4)] public ushort WorldId;
    [FieldOffset(0x1110)] public uint IdleTime;
}
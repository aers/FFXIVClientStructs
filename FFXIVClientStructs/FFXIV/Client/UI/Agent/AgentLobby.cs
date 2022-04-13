using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Lobby)]
[StructLayout(LayoutKind.Explicit, Size = 0x1A68)]
public unsafe struct AgentLobby
{
    public static AgentLobby* Instance()
    {
        return (AgentLobby*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(
            AgentId.Lobby);
    }

    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0xE78)] public ulong SelectedCharacterId;
    [FieldOffset(0xE80)] public byte DataCenter;
    [FieldOffset(0xE84)] public ushort WorldId;
    [FieldOffset(0xEA0)] public uint IdleTime;
}
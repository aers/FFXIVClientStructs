using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Lobby)]
[StructLayout(LayoutKind.Explicit, Size = 0x1C58)]
public unsafe struct AgentLobby
{
    public static AgentLobby* Instance()
    {
        return (AgentLobby*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(
            AgentId.Lobby);
    }

    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0xEC0)] public ulong SelectedCharacterId;
    [FieldOffset(0xEC8)] public byte DataCenter;
    [FieldOffset(0xECC)] public ushort WorldId;
    [FieldOffset(0xF98)] public uint IdleTime;
}
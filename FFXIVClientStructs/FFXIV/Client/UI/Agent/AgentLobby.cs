using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent {
    [Agent(AgentId.Lobby)]
    [StructLayout(LayoutKind.Explicit, Size = 0xA90)]
    public unsafe struct AgentLobby {

        public static AgentLobby* Instance() => (AgentLobby*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.Lobby);

        [FieldOffset(0x0)] public AgentInterface AgentInterface;
        [FieldOffset(0x818)] public ulong SelectedCharacterId;
        [FieldOffset(0x820)] public byte DataCenter;
        [FieldOffset(0x824)] public ushort WorldId;
        [FieldOffset(0x840)] public uint IdleTime;
    }
}

using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.IKDFishingLog)]
[StructLayout(LayoutKind.Explicit, Size = 0x460)]
public unsafe struct AgentIKDFishingLog
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    public static AgentIKDFishingLog* Instance() =>
        Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentIKDFishingLog();

    [FieldOffset(0x40)] public uint Points;
}

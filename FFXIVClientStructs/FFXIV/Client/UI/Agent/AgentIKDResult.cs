using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.IKDResult)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AgentIKDResult
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    public static AgentIKDResult* Instance() =>
        Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentIKDResult();

    [FieldOffset(0x28)] public ResultDataStruct* ResultData;

    [StructLayout(LayoutKind.Explicit, Size = 0x17A0)]
    public struct ResultDataStruct {
        [FieldOffset(0x380)] public uint TotalPoints;
    }
}

using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.RetainerTask)]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public struct AgentRetainerTask {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    // 00 - None
    // 01 - Request Assignment
    // 02 - Venture in Progress
    // 03 - Completed Venture
    [FieldOffset(0x28)] public uint DisplayType;

    // Set when venture is complete
    [FieldOffset(0x44)] public uint RewardXP;

    // Set when venture is complete
    [FieldOffset(0x50)] public uint RewardItemId;

    // Set when venture is complete
    [FieldOffset(0x58)] public uint RewardItemCount;

    [FieldOffset(0x74)] public uint RetainerTaskId;

    [FieldOffset(0x80)] public bool IsLoading;

    // Set when venture in progress
    [FieldOffset(0x84)] public uint XPToReward;

    public static unsafe AgentRetainerTask* Instance() =>
        Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentRetainerTask();
}

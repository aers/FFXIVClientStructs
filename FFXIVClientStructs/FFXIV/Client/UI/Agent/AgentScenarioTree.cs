namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentScenarioTree
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ScenarioTree)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentScenarioTree {
    [FieldOffset(0x28)] public AgentScenarioTreeData* Data;

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct AgentScenarioTreeData {
        [FieldOffset(0x00)] public ushort CurrentScenarioQuest; // CurrentScenarioQuest | 0x10000U = Quest row
        [FieldOffset(0x06)] public ushort CompleteScenarioQuest; // Only populated if no MSQ is accepted
    }
}

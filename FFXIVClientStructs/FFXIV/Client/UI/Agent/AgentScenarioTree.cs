using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentScenarioTree
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C5 33 D2 48 89 47 58"
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
[Agent(AgentId.ScenarioTree)]
public unsafe partial struct AgentScenarioTree {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public AgentScenarioTreeData* Data;

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct AgentScenarioTreeData {
        [FieldOffset(0x00)] public ushort CurrentScenarioQuest; // CurrentScenarioQuest | 0x10000U = Quest row
        [FieldOffset(0x06)] public ushort CompleteScenarioQuest; // Only populated if no MSQ is accepted
    }
}

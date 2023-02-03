using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContentsFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ContentsFinder)]
[StructLayout(LayoutKind.Explicit, Size = 0x2068)]
public unsafe partial struct AgentContentsFinder
{
    public static AgentContentsFinder* Instance() => (AgentContentsFinder*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.ContentsFinder);

    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    
    /// <summary>
    /// The ContentFinderCondition row index for the currently selected row in the ContentsFinder
    /// </summary>
    [FieldOffset(0x1B4C)] public int SelectedContentFinderCondition;
    
    /// <summary>
    /// Contains the value used to display "Weekly Reward Received" or "Rewards Received 2/3"
    /// </summary>
    [FieldOffset(0x1B58)] public byte NumCollectedRewards;

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B F9 41 0F B6 E8")]
    public partial void* OpenRegularDuty(uint contentsFinderCondition, byte a2 = 0);

    [MemberFunction("E9 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 48 83 C4 20")]
    public partial void* OpenRouletteDuty(byte roulette, byte a2 = 0);
}

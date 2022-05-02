using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRequest
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Request)]
[StructLayout(LayoutKind.Explicit, Size = 0x460)]
public unsafe partial struct AgentRequest
{
    public static AgentRequest* Instance() => (AgentRequest*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.Request);

    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x114)] public sbyte SelectedTurnInSlot; // you can have multiple items to turn in. this defaults to -1 and when you select one of them it becomes its index (starts at 0)
    [FieldOffset(0x124)] public short SelectedTurnInSlotItemOptions; // after you select a SelectedTurnInSlot, you can have multiple varieties of the item, like HQ and NQ. this is the amount of options you have for this slot
}

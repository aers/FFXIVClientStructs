namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentDailyQuestSupply
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.DailyQuestSupply)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct AgentDailyQuestSupply {
    [FieldOffset(0x54)] public uint ContextMenuItemId;
}

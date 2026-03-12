namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentJournalAccept
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.JournalAccept)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public partial struct AgentJournalAccept {
    [FieldOffset(0x30)] public StdVector<QuestRewardItem> RewardItems;
    [FieldOffset(0x4C)] public int ContextMenuSelectedRewardIndex;
}

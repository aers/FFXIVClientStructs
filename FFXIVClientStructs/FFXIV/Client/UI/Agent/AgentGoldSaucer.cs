namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGoldSaucer
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GoldSaucer)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct AgentGoldSaucer {
    [FieldOffset(0x5A)] public short GoldSaucerSelectedTab;
    [FieldOffset(0x5C)] public short ChocoboSeletedTab;
    [FieldOffset(0x100)] public int EditDeckSelectedPage;
    [FieldOffset(0x108)] public int EditDeckSelectedCardIndex;
}

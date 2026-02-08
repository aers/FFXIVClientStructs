namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMiragePrismPrismItemDetail
//   Client::UI::Agent::AgentItemDetailBase
//     Client::UI::Agent::AgentInterface
//       Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MiragePrismPrismItemDetail)]
[GenerateInterop]
[Inherits<AgentInterface>] // TODO: change to AgentItemDetailBase
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct AgentMiragePrismPrismItemDetail {
    [FieldOffset(0x54)] public uint ItemId;
}

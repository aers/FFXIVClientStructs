namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBannerParty
//   Client::UI::Agent::AgentBannerInterface
//     Client::UI::Agent::AgentInterface
//       Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.BannerParty)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentBannerParty {
    [FieldOffset(0x0)] public AgentBannerInterface AgentBannerInterface;
}

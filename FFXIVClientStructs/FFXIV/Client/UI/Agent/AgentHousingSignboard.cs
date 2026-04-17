using FFXIVClientStructs.FFXIV.Client.Game.Network;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingSignboard
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingSignboard)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AgentHousingSignboard {
    [MemberFunction("E9 ?? ?? ?? ?? 48 83 7B ?? ?? 74 16")]
    public partial void ReadPacket(HousingSignboardPacket* packet);
}

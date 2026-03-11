using FFXIVClientStructs.FFXIV.Client.Game.Network;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingPortal
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingPortal)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct AgentHousingPortal {
    [MemberFunction("40 55 53 41 54 41 55 41 57 48 8D AC 24 ?? ?? ?? ?? B8")]
    public partial void ReadPacket(HousingPortalPacket* packet);
}

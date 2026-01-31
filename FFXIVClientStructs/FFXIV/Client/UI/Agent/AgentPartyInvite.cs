using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRepair
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.PartyInvite)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct AgentPartyInvite {
    [FieldOffset(0x28)] public InfoProxyPartyInvite* InfoProxyPartyInvite;
    [FieldOffset(0x38)] public Utf8String InviterName;
    // This has also the AddonId of both Yesno windows, but as the Agent already inherits the same var name from AgentInterface
    // it is unclear how to properly name this one.
    //[FieldOffset(0xA0)] public uint AddonId;
}

using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTeleport
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Teleport)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentTeleport {
    [FieldOffset(0x60)] public int AetheryteCount;
    [FieldOffset(0x68)] public StdVector<TeleportInfo>* AetheryteList;
}

using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBlacklist
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Blacklist)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public unsafe partial struct AgentBlacklist {
    [FieldOffset(0x28)] public InfoProxyBlacklist* InfoProxy;
    [FieldOffset(0x40)] public Utf8String SelectedPlayerName;
    [FieldOffset(0xA8)] public Utf8String SelectedPlayerFullName; // includes cross world icon
    [FieldOffset(0x110)] public ulong SelectedPlayerId;
    [FieldOffset(0x118)] public ushort SelectYesnoAddonId; // remove confirmation
}

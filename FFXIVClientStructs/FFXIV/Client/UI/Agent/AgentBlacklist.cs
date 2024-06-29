using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBlacklist
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Blacklist)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct AgentBlacklist {
    [FieldOffset(0x28)] public InfoProxyBlacklist* InfoProxy;
    [FieldOffset(0x30)] public Utf8String SelectedPlayerName;
    [FieldOffset(0x98)] public Utf8String SelectedPlayerFullName; // includes cross world icon
    [FieldOffset(0x100)] public ulong SelectedPlayerContentId;
    [FieldOffset(0x108)] public ushort SelectYesnoAddonId; // remove confirmation
}

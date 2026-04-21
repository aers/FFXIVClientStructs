using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentLetterView
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.LetterView)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct AgentLetterView {
    [FieldOffset(0x28)] public InfoProxyLetter* InfoProxyLetter;
    [FieldOffset(0x30)] public uint OpenLetterIndex;
    [FieldOffset(0x34)] public uint SelectedAttachmentIndex;
    [FieldOffset(0x3C)] public uint YesNoAddonId;
}

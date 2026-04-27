using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentLetter
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.LetterList)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct AgentLetter {
    [FieldOffset(0x30)] public InfoProxyLetter* InfoProxyLetter;
    [FieldOffset(0x38)] public uint OpenLetterIndex;
    [FieldOffset(0x48)] public float RewardRequestCountdown;  // 10 Seconds
    [FieldOffset(0x4C)] public float TransferCountdown;  // 3 Seconds
}

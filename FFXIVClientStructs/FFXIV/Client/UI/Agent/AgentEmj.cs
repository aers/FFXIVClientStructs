using FFXIVClientStructs.FFXIV.Client.Game.Emj;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentEmj
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Emj)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentEmj {
    [FieldOffset(0x28)] public EmjGame* Game;
    [FieldOffset(0x30)] public uint MatchType;

    // Client::UI::Agent::AgentEmj::EmjGame
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xFB8)]
    public unsafe partial struct EmjGame {
        [FieldOffset(0xF80)] public EmjEngine* Engine;

        [FieldOffset(0xFA9)] public byte EmjVoiceNpc;
        [FieldOffset(0xFAB)] public byte EmjCostumeId;
    }
}

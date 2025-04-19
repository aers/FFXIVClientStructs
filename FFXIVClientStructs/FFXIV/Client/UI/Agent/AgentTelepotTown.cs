namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTelepotTown
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.TelepotTown)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentTelepotTown {
    [FieldOffset(0x28)] public AgentTelepotTownData* Data;

    [MemberFunction("E9 ?? ?? ?? ?? 83 F9 01 0F 85 ?? ?? ?? ?? 48 8B 4B 28")]
    public partial void TeleportToAetheryte(byte index);
}

[StructLayout(LayoutKind.Explicit, Size = 0xDE20)]
public struct AgentTelepotTownData {
    [FieldOffset(0x4)] public byte CurrentAetheryte; // the one you're standing at

    [FieldOffset(0x8)] public byte AetheryteCount;

    [FieldOffset(0x70E)] public byte SelectedAetheryte;

    [FieldOffset(0x710)] public byte Flags;
}

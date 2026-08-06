namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentPvPSpectator
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.PvPSpectator)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AgentPvPSpectator {
    [FieldOffset(0x88)] public AgentPvPSpectatorData* Data;

    [MemberFunction("E8 ?? ?? ?? ?? 80 BB ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? 48 8B 4B ?? 48 89 AC 24")]
    public partial void UpdateAddonVisibility();
}

[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public unsafe partial struct AgentPvPSpectatorData {
    [FieldOffset(0x354)] public uint AddonPvPSpectatorCameraList;
}

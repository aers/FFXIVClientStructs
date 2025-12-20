namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentReturn
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Return)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct AgentReturn {
    /// <remarks> in seconds </remarks>
    [FieldOffset(0x28)] public int Timeout;

    public bool CanReturn => Timeout == 0;

    [MemberFunction("E8 ?? ?? ?? ?? 66 0F 1F 84 ?? 00 00 00 00 48 83 EF")]
    public partial void Return();
}


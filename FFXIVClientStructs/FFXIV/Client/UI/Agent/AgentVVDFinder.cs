namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentVVDFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.VVDFinder)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentVVDFinder {
    [FieldOffset(0x28)] public VVDFinderData* Data;

    [StructLayout(LayoutKind.Explicit, Size = 0x4218)]
    public struct VVDFinderData {
        [FieldOffset(0x22D0)] public AgentContentsFinderInterface InterfaceSub;
    }
}

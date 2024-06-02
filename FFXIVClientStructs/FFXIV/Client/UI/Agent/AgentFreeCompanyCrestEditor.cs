namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFreeCompanyCrestEditor
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FreeCompanyCrestEditor)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct AgentFreeCompanyCrestEditor {
    [FieldOffset(0x60)] public CrestData OriginalCrest;
    [FieldOffset(0x68)] public CrestData CurrentCrest;
}

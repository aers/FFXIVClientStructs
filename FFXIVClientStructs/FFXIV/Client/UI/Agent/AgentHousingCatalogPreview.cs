namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingCatalogPreview
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingCatalogPreview)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x390)]
public unsafe partial struct AgentHousingCatalogPreview {
    [FieldOffset(0x380)] public byte SelectedStainId;
}

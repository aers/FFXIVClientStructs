namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentQuickPanel
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.QuickPanel)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentQuickPanel {
    [FieldOffset(0x30)] public uint ActivePanel;

    [MemberFunction("48 89 5C 24 ?? 57 41 54 41 57 48 83 EC ?? ?? ?? ?? 45 0F B6 E1")]
    public partial void OpenPanel(uint panel, bool closeIfAlreadyOpen = true, bool showFirstTimeHelp = true);
}

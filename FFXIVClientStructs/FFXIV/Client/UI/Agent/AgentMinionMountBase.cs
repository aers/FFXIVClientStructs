namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMinionMountBase
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop(isInherited: true)]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public partial struct AgentMinionMountBase {
    // RowId from Mount/Minion Excel Sheet for the currently selected item in MountNotebook or MinionNoteBook.
    [FieldOffset(0x5c)] public int SelectedId;
}

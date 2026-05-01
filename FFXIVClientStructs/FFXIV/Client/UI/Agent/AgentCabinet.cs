namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCabinet
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Cabinet)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x4AD8)]
public unsafe partial struct AgentCabinet {
    [FieldOffset(0x30)] public uint ConfirmationAddonId;
    [FieldOffset(0x34)] public uint SelectedIndex;

    [FieldOffset(0x4AB0)] public CabinetItem* Items; // length: Cabinet RowCount

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct CabinetItem {
        [FieldOffset(0x00), CExporterExcel("Cabinet")] public nint Row;
        [FieldOffset(0x08)] public uint Id;
    }
}

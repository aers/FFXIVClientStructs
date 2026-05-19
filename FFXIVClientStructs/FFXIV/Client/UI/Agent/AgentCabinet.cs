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
    [FieldOffset(0x34)] public uint SelectedIndex;         // index into Items[]
    [FieldOffset(0x38)] public uint OpenMode;              // 0 = normal cabinet, 2 = MiragePrism plate selection
    [FieldOffset(0x40)] public uint SelectedItemId;        // game item ID of the selected item

    [FieldOffset(0x49)] public byte SelectedCategoryIndex; // dropdown selection as (index + 1); 
    [FieldOffset(0x4A)] public bool PendingUpdate;         // set to true on category change; triggers item list rebuild in Update

    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray140<RaptureAtkModule.ItemCache> _itemCaches;

    [FieldOffset(0x4AB0)] public CabinetItem* Items;       // all valid Cabinet rows sorted by category; length: ItemCount
    [FieldOffset(0x4AB8)] public uint ItemCount;           // total valid Cabinet rows across all categories

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct CabinetItem {
        [FieldOffset(0x00), CExporterExcel("Cabinet")] public nint Row;
        [FieldOffset(0x08)] public uint Id;
    }
}

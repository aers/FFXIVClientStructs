using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingPlant
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Client::UI::Agent::AgentInventoryContext::InventoryContextEvent
[Agent(AgentId.HousingPlant)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<AgentInventoryContext.InventoryContextEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x950)]
public unsafe partial struct AgentHousingPlant {
    [FieldOffset(0x40)] public uint ContextAddonId;
    [FieldOffset(0x44)] public uint PlotType; // 27 indoor, 14 outdoor, 15 ? - not really sure, changes how the context menu is used

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray2<SelectedItem> _selectedItems;
    [FieldOffset(0x68), FixedSizeArray] internal FixedSizeArray2<SelectedItem> _selectedItems2;
    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray140<SelectableItem> _selectableItems;
    [FieldOffset(0x948)] public byte SelectableItemCount;
    //[FieldOffset(0x949)] public bool IsPlantPot_IsNotGardening; ?

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SelectedItem {
        [FieldOffset(0x00)] public InventoryType InventoryType;
        [FieldOffset(0x04)] public ushort InventorySlot;

        [FieldOffset(0x08)] public uint ItemId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SelectableItem {
        [FieldOffset(0x00)] public RaptureAtkModule.ItemCache* ItemCache;
        [FieldOffset(0x08)] public InventoryType InventoryType;
        [FieldOffset(0x0C)] public ushort InventorySlot;
    }
}

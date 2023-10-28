using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.HousingPlant)]
[StructLayout(LayoutKind.Explicit, Size = 0x950)]
public unsafe partial struct AgentHousingPlant {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x40)] public uint ContextAddonId;
    [FieldOffset(0x44)] public uint PlotType; // 27 indoor, 14 outdoor, 15 ? - not really sure, changes how the context menu is used

    [FixedSizeArray<SelectedItem>(2)]
    [FieldOffset(0x48)] public fixed byte SelectedItems[2 * 0x10];
    [FixedSizeArray<SelectedItem>(2)]
    [FieldOffset(0x68)] public fixed byte SelectedItems2[2 * 0x10];
    [FixedSizeArray<SelectableItem>(140)]
    [FieldOffset(0x88)] public fixed byte SelectableItems[140 * 0x10];
    [FieldOffset(0x948)] public byte SelectableItemCount;
    //[FieldOffset(0x949)] public bool IsPlantPot_IsNotGardening; ?

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SelectedItem {
        [FieldOffset(0x00)] public uint InventoryId;
        [FieldOffset(0x04)] public ushort InventorySlot;

        [FieldOffset(0x08)] public uint ItemId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SelectableItem {
        // looks like a Client::UI::RaptureAtkModule::ItemCache
        [FieldOffset(0x00)] public void* ItemCache;
        [FieldOffset(0x08)] public uint InventoryId;
        [FieldOffset(0x0C)] public ushort InventorySlot;
    }
}

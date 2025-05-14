using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMJIPouch
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MJIPouch)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentMJIPouch {

    [FieldOffset(0x28)] public PouchIndexInfo* InventoryIndex;
    [FieldOffset(0x30)] public PouchInventoryData* InventoryData;

    public StdVector<Pointer<PouchInventoryItem>>* GetInventoryByIndex(int index) {
        if (InventoryData == null) return null;
        if (index < 0 || index >= InventoryData->Inventories.Length) return null;
        return InventoryData->Inventories.GetPointer(index);
    }

    public StdVector<Pointer<PouchInventoryItem>>* GetSelectedInventory() {
        if (InventoryData == null || InventoryIndex == null) return null;
        return InventoryData->Inventories.GetPointer(InventoryIndex->CurrentIndex);
    }

    public StdVector<PouchInventoryItem>* GetInventory() {
        if (InventoryData == null) return null;
        return &InventoryData->Inventory;
    }

    [MemberFunction("48 83 EC ?? 4C 8B 41 ?? 41 3B 90")]
    public partial bool IsPouchItemUnlocked(uint rowId);

    [MemberFunction("E8 ?? ?? ?? ?? 3B F0 0F 87")]
    public partial int GetPouchItemCount(uint rowId);

    [MemberFunction("4C 8B 49 ?? 4D 85 C9 74 ?? 41 80 F8")]
    public partial uint GetPouchItemAllocation(uint rowId, sbyte allocationEntry = -1);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 41 ?? 33 DB 48 8B F9 39 98")]
    public partial bool HasMaterialDeficit();

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 49 8B D8 48 8B FA E8 ?? ?? ?? ?? 48 85 C0")]
    public partial bool IsItemUnlocked(PouchInventoryItem* item, int* outItemCount = null);

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct PouchIndexInfo {
        [FieldOffset(0x00)] public int CurrentIndex;
        [FieldOffset(0x04)] public int MaxIndex;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
    public partial struct PouchInventoryData {
        [FieldOffset(0xA0)] public StdVector<PouchInventoryItem> Inventory;
        [FieldOffset(0xB8), FixedSizeArray] internal FixedSizeArray4<StdVector<Pointer<PouchInventoryItem>>> _inventories;
        [FieldOffset(0xB8), CExportIgnore] public StdVector<Pointer<PouchInventoryItem>> Materials;
        [FieldOffset(0xD0), CExportIgnore] public StdVector<Pointer<PouchInventoryItem>> Produce;
        [FieldOffset(0xE8), CExportIgnore] public StdVector<Pointer<PouchInventoryItem>> StockStores;
        [FieldOffset(0x100), CExportIgnore] public StdVector<Pointer<PouchInventoryItem>> Tools;
        [FieldOffset(0x118)] public StdVector<Pointer<PouchInventoryItem>> ItemPouchItems;
        [FieldOffset(0x130)] public StdVector<Utf8String> InventoryNames;
        [FieldOffset(0x148)] public uint MJIItemPouchItemCount;
        [FieldOffset(0x150), FixedSizeArray] internal FixedSizeArray3<AgentMJICraftSchedule.MaterialAllocationEntry> _materialAllocation;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public struct PouchInventoryItem {
    [FieldOffset(0x00)] public uint ItemId;
    [FieldOffset(0x04)] public uint IconId;
    [FieldOffset(0x08), Obsolete("Use RowId instead")] public int SlotIndex;
    /// <remarks>MJIItemPouch or MJIKeyItem RowId</remarks>
    [FieldOffset(0x08)] public uint RowId;
    [FieldOffset(0x0C)] public int StackSize;
    [FieldOffset(0x10)] public int MaxStackSize;
    [FieldOffset(0x14)] public byte InventoryIndex;
    [FieldOffset(0x15)] public byte ItemCategory;
    [FieldOffset(0x16)] public byte SortIndex;
    [FieldOffset(0x17)] public byte MjiGatheringItemRowId;
    [FieldOffset(0x18)] public byte Undiscovered; // TODO: bool, also move this struct into the agent

    [FieldOffset(0x20)] public Utf8String Name;
}

using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ItemOrderModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC 30 45 33 FF 48 89 51 10"
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct ItemOrderModule {
    public static ItemOrderModule* Instance() => Framework.Instance()->GetUiModule()->GetItemOrderModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FieldOffset(0x40)] public ItemOrderModuleSorter* InventorySorter;
    [FixedSizeArray<Pointer<ItemOrderModuleSorter>>(12)]
    [FieldOffset(0x48)] public fixed byte ArmourySorter[12 * 8];
    [FieldOffset(0x48), CExportIgnore] public ItemOrderModuleSorter* ArmouryMainHandSorter;
    [FieldOffset(0x50), CExportIgnore] public ItemOrderModuleSorter* ArmouryHeadSorter;
    [FieldOffset(0x58), CExportIgnore] public ItemOrderModuleSorter* ArmouryBodySorter;
    [FieldOffset(0x60), CExportIgnore] public ItemOrderModuleSorter* ArmouryHandsSorter;
    [FieldOffset(0x68), CExportIgnore] public ItemOrderModuleSorter* ArmouryLegsSorter;
    [FieldOffset(0x70), CExportIgnore] public ItemOrderModuleSorter* ArmouryFeetSorter;
    [FieldOffset(0x78), CExportIgnore] public ItemOrderModuleSorter* ArmouryOffHandSorter;
    [FieldOffset(0x80), CExportIgnore] public ItemOrderModuleSorter* ArmouryEarsSorter;
    [FieldOffset(0x88), CExportIgnore] public ItemOrderModuleSorter* ArmouryNeckSorter;
    [FieldOffset(0x90), CExportIgnore] public ItemOrderModuleSorter* ArmouryWristsSorter;
    [FieldOffset(0x98), CExportIgnore] public ItemOrderModuleSorter* ArmouryRingsSorter;
    [FieldOffset(0xA0), CExportIgnore] public ItemOrderModuleSorter* ArmourySoulCrystalSorter;
    [FieldOffset(0xA8)] public ItemOrderModuleSorter* ArmouryWaistSorter; // no longer used
    [FieldOffset(0xB0)] public ulong ActiveRetainerId;
    [FieldOffset(0xB8)] public StdMap<ulong, Pointer<ItemOrderModuleSorter>> RetainerSorter;
    [FieldOffset(0xC8)] public ItemOrderModuleSorter* SaddleBagSorter;
    [FieldOffset(0xD0)] public ItemOrderModuleSorter* PremiumSaddleBagSorter;
}

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe struct ItemOrderModuleSorter {
    [FieldOffset(0x00)] public InventoryType InventoryType;

    [FieldOffset(0x08)] public StdVector<Pointer<ItemOrderModuleSorterItemEntry>> Items;

    [FieldOffset(0x28)] public int ItemsPerPage;

    [FieldOffset(0x38)] public int SortFunctionIndex; // set to -1 if done
    [FieldOffset(0x3C)] public int PercentComplete; // set to 100 if done
    [FieldOffset(0x40)] public StdVector<ItemOrderModuleSorterSortFunctionEntry> SortFunctions;
    [FieldOffset(0x58)] public ItemOrderModuleSorterPreviousOrderEntry* PreviousOrderArray;
    // [FieldOffset(0x60)] public bool UnkBool; Set to true, only when it's the InventorySorter?
}

[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public unsafe struct ItemOrderModuleSorterItemEntry {
    [FieldOffset(0x00)] public ushort Page;
    [FieldOffset(0x02)] public ushort Slot;

    [FieldOffset(0x08)] public ushort Index;
    [FieldOffset(0x0A)] public byte Flags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public unsafe struct ItemOrderModuleSorterPreviousOrderEntry {
    [FieldOffset(0x00)] public ushort Slot;
    [FieldOffset(0x02)] public ushort Page;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct ItemOrderModuleSorterSortFunctionEntry {
    [FieldOffset(0x00)] public nint FunctionPtr;
    [FieldOffset(0x08)] public bool Descending;
}

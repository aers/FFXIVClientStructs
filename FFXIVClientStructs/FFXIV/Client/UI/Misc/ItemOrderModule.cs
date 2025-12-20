using FFXIVClientStructs.FFXIV.Client.Game;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ItemOrderModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC 30 45 33 FF 48 89 51 10"
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct ItemOrderModule {
    public static ItemOrderModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetItemOrderModule();
    }

    [FieldOffset(0x48)] public ItemOrderModuleSorter* InventorySorter;
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray12<Pointer<ItemOrderModuleSorter>> _armourySorter;
    [FieldOffset(0x50), CExporterIgnore] public ItemOrderModuleSorter* ArmouryMainHandSorter;
    [FieldOffset(0x58), CExporterIgnore] public ItemOrderModuleSorter* ArmouryHeadSorter;
    [FieldOffset(0x60), CExporterIgnore] public ItemOrderModuleSorter* ArmouryBodySorter;
    [FieldOffset(0x68), CExporterIgnore] public ItemOrderModuleSorter* ArmouryHandsSorter;
    [FieldOffset(0x70), CExporterIgnore] public ItemOrderModuleSorter* ArmouryLegsSorter;
    [FieldOffset(0x78), CExporterIgnore] public ItemOrderModuleSorter* ArmouryFeetSorter;
    [FieldOffset(0x80), CExporterIgnore] public ItemOrderModuleSorter* ArmouryOffHandSorter;
    [FieldOffset(0x88), CExporterIgnore] public ItemOrderModuleSorter* ArmouryEarsSorter;
    [FieldOffset(0x90), CExporterIgnore] public ItemOrderModuleSorter* ArmouryNeckSorter;
    [FieldOffset(0x98), CExporterIgnore] public ItemOrderModuleSorter* ArmouryWristsSorter;
    [FieldOffset(0xA0), CExporterIgnore] public ItemOrderModuleSorter* ArmouryRingsSorter;
    [FieldOffset(0xA8), CExporterIgnore] public ItemOrderModuleSorter* ArmourySoulCrystalSorter;
    [FieldOffset(0xB0)] public ItemOrderModuleSorter* ArmouryWaistSorter; // no longer used
    [FieldOffset(0xB8)] public ulong ActiveRetainerId;
    [FieldOffset(0xC0)] public StdMap<ulong, Pointer<ItemOrderModuleSorter>> RetainerSorter;
    [FieldOffset(0xD0)] public ItemOrderModuleSorter* SaddleBagSorter;
    [FieldOffset(0xD8)] public ItemOrderModuleSorter* PremiumSaddleBagSorter;

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 41 ?? C3")]
    public partial ItemOrderModuleSorter* GetActiveRetainerSorter();
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
    // [FieldOffset(0x60)] private bool UnkBool; Set to true, only when it's the InventorySorter?
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

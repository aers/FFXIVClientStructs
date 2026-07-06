using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMiragePrismPrismBox
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MiragePrismPrismBox)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct AgentMiragePrismPrismBox {
    [FieldOffset(0x28)] public MiragePrismPrismBoxData* Data;
    [FieldOffset(0x30)] private nint OpenerCallbackPtr; // unsure about that
    [FieldOffset(0x38)] public bool IsDataLoaded;
    [FieldOffset(0x39)] public byte TabIndex;
    [FieldOffset(0x3A)] public byte PageIndex;
    [FieldOffset(0x3C)] public uint CrystalizeAddonId;
    [FieldOffset(0x40)] public uint ContextAddonId; // AddonId slot for active context dialogs (crystallize confirm, YesNo, prism-set preview)
    [FieldOffset(0x44)] public uint ContextAddon2Id; // AddonId slot for the restore-as-outfit dialog (addon 0x285).
    [FieldOffset(0x48)] public short SavedAddonX;
    [FieldOffset(0x4A)] public short SavedAddonY;
    [FieldOffset(0x50)] public InventoryItem TempDyeItem;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 43 3A")]
    public partial void UpdateItems(bool resetTabIndex, bool a2);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 46 28 C6 80 ?? ?? ?? ?? ??")]
    public partial bool PopulateCrystallizeAndFireRefresh();
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x123A00)]
public unsafe partial struct MiragePrismPrismBoxData {
    [FieldOffset(0x00)] private byte Unk00;
    [FieldOffset(0x01)] public bool IsAsyncLoadComplete; // Set to true once all async item-name loads have completed. gates the sort and page-index update in Update.
    [FieldOffset(0x02)] public byte PendingTabIndex; // Pending tab/slot filter to apply. written by context actions, cleared to 13 (All) once processed

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray8000<PrismBoxItem> _prismBoxItems;
    [FieldOffset(0x119408)] public PrismBoxItem TempContextItem;

    // [FieldOffset(0x11AD98), FixedSizeArray] internal FixedSizeArray800<ulong> _unk11AD98; // 800x 8 bytes each { dword, byte, padding byte, byte }

    [FieldOffset(0x11AD98), FixedSizeArray] internal FixedSizeArray50<int> _pageItemIndexes;
    [FieldOffset(0x11AE60)] public int TempContextItemIndex;
    [FieldOffset(0x11AE64)] public int SelectedPageIndex;
    [FieldOffset(0x11AE68)] private uint Unk11AE68;

    [FieldOffset(0x11AE6C)] public int UsedSlots;

    [FieldOffset(0x11AE70)] public uint ItemCount;
    [FieldOffset(0x11AE74)] public uint FilterSettingsAddonId;
    [FieldOffset(0x11AE78)] public bool IsPopulatingList;
    [FieldOffset(0x11AE79)] public bool IsPopulatingComplete;
    [FieldOffset(0x11AE7B)] private byte Unk11AE7B;
    [FieldOffset(0x11AE7C)] public bool IsAddonReady;
    [FieldOffset(0x11AE7D)] private byte Unk11AE7D;
    [FieldOffset(0x11AE7E)] private byte Unk11AE7E;
    [FieldOffset(0x11AE7F)] public bool IsPositionSaved;

    [FieldOffset(0x11AE80)] private int Unk11AE80; // something with the category
    [FieldOffset(0x11AE84)] public int CrystallizeCategory;
    [FieldOffset(0x11AE88)] public ushort CrystallizeItemIndex;
    [FieldOffset(0x11AE8A)] public ushort CrystallizeItemCount;
    [FieldOffset(0x11AE8C)] public ushort CrystallizeTreeRowCount;
    [FieldOffset(0x11AE8E)] private ushort Unk11AE8E; // cursor related?

    [FieldOffset(0x11AE90), FixedSizeArray] internal FixedSizeArray140<PrismBoxCrystallizeItem> _crystallizeItems;
    [FieldOffset(0x11BDE0)] public PrismBoxCrystallizeItem CrystallizeSelectedItem;

    [FieldOffset(0x11BE00), FixedSizeArray] internal FixedSizeArray1962<AtkValue> _atkValues;
    [FieldOffset(0x1238A0)] public uint PendingState;
    [FieldOffset(0x1238A4)] public uint PendingStateStep;
    [FieldOffset(0x1238A8)] public uint LastProcessedStep;

    [FieldOffset(0x1238AC)] public byte CrystallizeFilterFlags;
    [FieldOffset(0x1238AD)] public byte SortType; // 0 = Descending, 2 = Ascending

    [FieldOffset(0x1238B0)] internal AgentCabinet* AgentCabinet;
    [FieldOffset(0x1238B8)] internal AgentMiragePrismMiragePlate* AgentMiragePrismMiragePlate;
    [FieldOffset(0x1238C0)] public byte FilterLevel; // 0 = Unspecified = Max Level
    [FieldOffset(0x1238C1)] private byte Unk1238C1;

    [FieldOffset(0x1238C2)] public byte FilterSex; // 0 = Unspecified, 1 = Current, 2 = Male, 3 = Female
    [FieldOffset(0x1238C3)] public byte FilterGlamour; // 0 = Unspecified, 1 = Hide not eligible, 2 = Display only outfit glamours

    [FieldOffset(0x1238C8)] public Utf8String FilterString; // Inline Buffer only
    [FieldOffset(0x123930)] public Utf8String FilterString2; // Inline Buffer only 
    [FieldOffset(0x123998)] public Utf8String SearchString; // Inline Buffer only
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public partial struct PrismBoxItem {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public uint Slot;
    [FieldOffset(0x6C)] public uint ItemId;
    [FieldOffset(0x70)] public uint IconId;
    [FieldOffset(0x7A)] public byte EquipRestriction;
    [FieldOffset(0x7C)] private ushort Unk7C;
    [FieldOffset(0x7E)] public ushort ItemLevel;
    [FieldOffset(0x80)] public ushort LevelEquip;
    [FieldOffset(0x82), FixedSizeArray] internal FixedSizeArray2<byte> _stains;
    [FieldOffset(0x84)] private byte Unk84; // Zero = item name not yet async-loaded
    [FieldOffset(0x85)] public byte EquipSlotCategory;
    [FieldOffset(0x87)] public byte ClassJobCategory;
    [FieldOffset(0x88)] private byte Unk88; // Seemingly always 255
    [FieldOffset(0x89)] public byte NumOutfitPiecesAdded; // Only for outfit glamours
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public struct PrismBoxCrystallizeItem {
    [FieldOffset(0x00)] public InventoryType Inventory;
    [FieldOffset(0x04)] public int Slot;
    [FieldOffset(0x08)] public uint ItemId;
}

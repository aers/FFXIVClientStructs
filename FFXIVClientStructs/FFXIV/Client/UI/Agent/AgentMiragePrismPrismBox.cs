using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMiragePrismPrismBox
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MiragePrismPrismBox)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentMiragePrismPrismBox {
    [FieldOffset(0x28)] public MiragePrismPrismBoxData* Data;
    [FieldOffset(0x39)] public byte TabIndex;
    [FieldOffset(0x3A)] public byte PageIndex;
    [FieldOffset(0x48)] public InventoryItem TempDyeItem;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 43 3A")]
    public partial void UpdateItems(bool resetTabIndex, bool a2);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1239F8)]
public unsafe partial struct MiragePrismPrismBoxData {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray8000<PrismBoxItem> _prismBoxItems;
    [FieldOffset(0x119408)] public PrismBoxItem TempContextItem;

    // 7.1: 6,400 (0x1900) bytes were added here

    [FieldOffset(0x11AD98), FixedSizeArray] internal FixedSizeArray50<int> _pageItemIndexes;
    [FieldOffset(0x11AE60)] public int TempContextItemIndex;
    [FieldOffset(0x11AE64)] public int SelectedPageIndex;
    [FieldOffset(0x11AE68)] public int UsedSlots;

    // 7.1: a new 32-bit int was added between UsedSlots and CrystallizeCategory

    [FieldOffset(0x11AE80)] public int CrystallizeCategory;
    [FieldOffset(0x11AE84)] public ushort CrystallizeItemIndex;
    [FieldOffset(0x11AE86)] public ushort CrystallizeItemCount;
    [FieldOffset(0x11AE8C), FixedSizeArray] internal FixedSizeArray140<PrismBoxCrystallizeItem> _crystallizeItems;
    [FieldOffset(0x11BDDC)] public PrismBoxCrystallizeItem CrystallizeSelectedItem;

    [FieldOffset(0x1238A4)] public byte CrystallizeFilterFlags;
    [FieldOffset(0x1238A5)] public byte SortType; // 0 = Descending, 2 = Ascending

    [FieldOffset(0x1238A8)] internal AgentCabinet* AgentCabinet;
    [FieldOffset(0x1238B0)] internal AgentMiragePrismMiragePlate* AgentMiragePrismMiragePlate;
    [FieldOffset(0x1238B8)] public byte FilterLevel; // 0 = Unspecified = Max Level

    [FieldOffset(0x1238BA)] public byte FilterSex; // 0 = Unspecified, 1 = Current, 2 = Male, 3 = Female

    [FieldOffset(0x1238C0)] public Utf8String FilterString; // Inline buffer only
    [FieldOffset(0x123928)] public Utf8String SearchString; // Inline buffer only
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

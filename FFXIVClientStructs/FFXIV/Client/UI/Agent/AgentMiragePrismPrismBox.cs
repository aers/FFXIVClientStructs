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
[StructLayout(LayoutKind.Explicit, Size = 0x113F88)]
public unsafe partial struct MiragePrismPrismBoxData {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray8000<PrismBoxItem> _prismBoxItems;
    [FieldOffset(0x109A08)] public PrismBoxItem TempContextItem;

    // 7.1: 6,400 (0x1900) bytes were added here

    [FieldOffset(0x10B390), FixedSizeArray] internal FixedSizeArray50<int> _pageItemIndexes;
    [FieldOffset(0x10B458)] public int TempContextItemIndex;
    [FieldOffset(0x10B45C)] public int SelectedPageIndex;
    [FieldOffset(0x10B460)] public int UsedSlots;

    // 7.1: a new 32-bit int was added between UsedSlots and CrystallizeCategory

    [FieldOffset(0x10B478)] public int CrystallizeCategory;
    [FieldOffset(0x10B47C)] public ushort CrystallizeItemIndex;
    [FieldOffset(0x10B47E)] public ushort CrystallizeItemCount;
    [FieldOffset(0x10B484), FixedSizeArray] internal FixedSizeArray140<PrismBoxCrystallizeItem> _crystallizeItems;
    [FieldOffset(0x10C3D4)] public PrismBoxCrystallizeItem CrystallizeSelectedItem;
    [FieldOffset(0x113E9C)] public byte CrystallizeFilterFlags;

    [FieldOffset(0x113E9D)] public byte SortType; // 0 = Descending, 2 = Ascending
    [FieldOffset(0x113EB0)] public byte FilterLevel; // 0 = Unspecified = Max Level
    [FieldOffset(0x113EB2)] public byte FilterSex; // 0 = Unspecified, 1 = Current, 2 = Male, 3 = Female
    [FieldOffset(0x113EB8)] public Utf8String FilterString; // Inline buffer only
    [FieldOffset(0x113F20)] public Utf8String SearchString; // Inline buffer only

    [FieldOffset(0x113EA0)] internal AgentCabinet* AgentCabinet;
    [FieldOffset(0x113EA8)] internal AgentMiragePrismMiragePlate* AgentMiragePrismMiragePlate;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public partial struct PrismBoxItem {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public uint Slot;
    [FieldOffset(0x6C)] public uint ItemId;
    [FieldOffset(0x70)] public uint IconId;
    //[FieldOffset(0x74)] public uint Unk_SheetColumn19;
    [FieldOffset(0x7E), FixedSizeArray] internal FixedSizeArray2<byte> _stains;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public struct PrismBoxCrystallizeItem {
    [FieldOffset(0x00)] public InventoryType Inventory;
    [FieldOffset(0x04)] public int Slot;
    [FieldOffset(0x08)] public uint ItemId;
}

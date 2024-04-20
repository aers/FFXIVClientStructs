using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MiragePrismPrismBox)]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct AgentMiragePrismPrismBox {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public MiragePrismPrismBoxData* Data;
    [FieldOffset(0x39)] public byte TabIndex;
    [FieldOffset(0x3A)] public byte PageIndex;
    [FieldOffset(0x48)] public InventoryItem TempDyeItem;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 43 3A")]
    public partial void UpdateItems(bool resetTabIndex, bool a2);
}

[StructLayout(LayoutKind.Explicit, Size = 0x1BAE0)]
public unsafe partial struct MiragePrismPrismBoxData {
    [FixedSizeArray<PrismBoxItem>(800)]
    [FieldOffset(0x08)] public fixed byte PrismBoxItems[800 * 0x88]; // 800 * PrismBoxItem
    [FieldOffset(0x1A908)] public PrismBoxItem TempContextItem;
    [FieldOffset(0x1A990)] public fixed int PageItemIndexArray[50];
    [FieldOffset(0x1AA58)] public int TempContextItemIndex;
    [FieldOffset(0x1AA5C)] public int SelectedPageIndex;
    [FieldOffset(0x1AA60)] public int UsedSlots;

    [FieldOffset(0x1AA70)] public int CrystallizeCategory;
    [FieldOffset(0x1AA74)] public int CrystallizeItemIndex;
    [FieldOffset(0x1AA78)] public int CrystallizeItemCount;
    [FixedSizeArray<PrismBoxCrystallizeItem>(140)]
    [FieldOffset(0x1AA7C)] public fixed byte CrystallizeItems[140 * 0x1C]; // 140 * PrismBoxCrystallizeItem
    [FieldOffset(0x1B9CC)] public PrismBoxCrystallizeItem CrystallizeSelectedItem;

    [FieldOffset(0x1B9F4)] public uint FilterFlags;
    [FieldOffset(0x1B9F8)] public void* AgentCabinet;
    [FieldOffset(0x1BA00)] public AgentMiragePrismMiragePlate* AgentMiragePrismMiragePlate;
    [FieldOffset(0x1BA08)] public byte FilterLevel;
    [FieldOffset(0x1BA0A)] public byte FilterSex;
    [Obsolete("Renamed to FilterSex")]
    [FieldOffset(0x1BA0A)] public byte FilterGender;
    [FieldOffset(0x1BA10)] public Utf8String FilterString;
    [FieldOffset(0x1BA78)] public Utf8String SearchString;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public struct PrismBoxItem {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x6C)] public uint ItemId;
    [FieldOffset(0x70)] public uint IconId;
    //[FieldOffset(0x74)] public uint Unk_SheetColumn19;
    [FieldOffset(0x7E)] public byte Stain;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public struct PrismBoxCrystallizeItem {
    [FieldOffset(0x00)] public InventoryType Inventory;
    [FieldOffset(0x04)] public int Slot;
    [FieldOffset(0x08)] public uint ItemId;
}

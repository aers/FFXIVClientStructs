using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MJIAnimalManagement)]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct AgentMJIAnimalManagement {
    [FieldOffset(0x000)] public AgentInterface AgentInterface;
    // 0x28 struct of size 0xA0 used for reading excel sheets
    // 0xC8 bool[3] pending initialization requests
    [FieldOffset(0x0D0)] public AtkEventInterface* OpHandler; // pointer to some class derived from AtkEventInterface of size 0x30
    // 0xD8..0xFC - a bunch of different addon handles
    [FieldOffset(0x100)] public StdVector<Slot> Slots;
    [FieldOffset(0x118)] public StdVector<AnimalDesc> AnimalDescs;
    [FieldOffset(0x130)] public StdVector<ItemDesc> ItemDescs;
    [FieldOffset(0x148)] public StdVector<Pointer<ItemDesc>> EntrustAvailableFood; // filled and updated on entrust
    [FieldOffset(0x160)] public int NumPastureSlots;
    [FieldOffset(0x164)] public int CurContextMenuRow;
    [FieldOffset(0x168)] public uint PendingReleaseObjectId;
    [FieldOffset(0x170)] public Utf8String ProposedNickname;
    [FieldOffset(0x1D8)] public bool DuringCapture; // true if agent was opened to free up a slot for captured animal
    [FieldOffset(0x1D9)] public bool DataInitialized;
    [FieldOffset(0x1DA)] public bool UpdateNeeded;
    [FieldOffset(0x1DC)] public int ExpectedCollectLeavings; // set when confirm dialog is shown, validated when user confirms

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public unsafe partial struct AnimalDesc {
        [FieldOffset(0x00)] public byte AnimalRowId;
        [FieldOffset(0x01)] public byte Rarity;
        [FieldOffset(0x02)] public byte Sort;
        [FieldOffset(0x04)] public uint IconId;
        [FieldOffset(0x08)] public uint Leaving1ItemId;
        [FieldOffset(0x0C)] public uint Leaving2ItemId;
        [FieldOffset(0x10)] public uint BNpcNameId;
        [FieldOffset(0x18)] public Utf8String Nickname;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public unsafe partial struct ItemDesc {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint CategoryId;
        [FieldOffset(0x08)] public uint CountInInventory;
        [FieldOffset(0x0C)] public uint IconId;
        [FieldOffset(0x10)] public Utf8String Name;
        [FieldOffset(0x78)] public Utf8String Link;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x170)]
    public unsafe partial struct Slot {
        [FieldOffset(0x000)] public uint ObjectId;
        [FieldOffset(0x008)] public AnimalDesc Desc;
        [FieldOffset(0x088)] public uint FoodItemId;
        [FieldOffset(0x08C)] public uint FoodItemCategoryId;
        [FieldOffset(0x090)] public uint FoodCount;
        [FieldOffset(0x094)] public uint FoodIconId;
        [FieldOffset(0x098)] public Utf8String FoodName;
        [FieldOffset(0x100)] public Utf8String FoodLink;
        [FieldOffset(0x168)] public byte Mood;
        [FieldOffset(0x169)] public byte FoodLevel;
        [FieldOffset(0x16A)] public byte AvailLeavings1;
        [FieldOffset(0x16B)] public byte AvailLeavings2;
        [FieldOffset(0x16C)] public bool HaveUngatheredLeavings;
        [FieldOffset(0x16D)] public bool UnderCare;
        [FieldOffset(0x16E)] public bool CareHalted;
        [FieldOffset(0x16F)] public bool WasCared;
    }
}

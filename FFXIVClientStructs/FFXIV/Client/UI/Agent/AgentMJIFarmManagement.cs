using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MJIFarmManagement)]
[StructLayout(LayoutKind.Explicit, Size = 0x13D8)]
public unsafe partial struct AgentMJIFarmManagement {
    public const int MaxSlots = 20;

    [FieldOffset(0x0000)] public AgentInterface AgentInterface;
    [FieldOffset(0x0028)] public AtkEventInterface* OpHandler; // pointer to some class derived from AtkEventInterface of size 0x30
    // 0x30..0x40 - a bunch of different addon handles

    [FixedSizeArray<Slot>(MaxSlots)]
    [FieldOffset(0x0048)] public fixed byte Slots[MaxSlots * 0xF8];

    [FieldOffset(0x13A8)] public StdVector<Seed> Seeds;

    [FieldOffset(0x13C0)] public int NumSlots;
    [FieldOffset(0x13C4)] public int CurContextMenuRow;
    [FieldOffset(0x13C8)] public int CurContextOpType;
    [FieldOffset(0x13CC)] public bool DelayShow;
    [FieldOffset(0x13D0)] public int TotalAvailableYield;
    [FieldOffset(0x13D4)] public int ExpectedTotalAvailableYield; // for collect-all operation

    [StructLayout(LayoutKind.Explicit, Size = 0xF8)]
    public unsafe partial struct Slot {
        [FieldOffset(0x00)] public Utf8String YieldName;
        [FieldOffset(0x68)] public uint YieldIconId;
        [FieldOffset(0x70)] public uint SeedItemId;
        [FieldOffset(0x74)] public uint SeedInventoryCount;
        [FieldOffset(0x78)] public uint SeedIconId;
        [FieldOffset(0x80)] public Utf8String SeedName;
        [FieldOffset(0xE8)] public byte WaterLevel;
        [FieldOffset(0xE9)] public byte GrowthLevel;
        [FieldOffset(0xEC)] public uint YieldItemId;
        [FieldOffset(0xF0)] public uint YieldAvailable;
        [FieldOffset(0xF4)] public bool UnderCare;
        [FieldOffset(0xF5)] public bool CareHalted;
        [FieldOffset(0xF6)] public bool WasUnderCare;
        [FieldOffset(0xF7)] public bool Flag8;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public unsafe partial struct Seed {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint Count;
        [FieldOffset(0x08)] public uint IconId;
        [FieldOffset(0x10)] public Utf8String Name;
    }
}

namespace FFXIVClientStructs.FFXIV.Client.Game.MJI; 

// vast majority of struct info from E8 ?? ?? ?? ?? 8B 4C 24 24 E8
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct MJIFarmState {
    [FieldOffset(0x00)] public void* VTable;
    [FieldOffset(0x08)] public void* vtbl2; // ??

    [FieldOffset(0x20)] public fixed byte SeedType[20];
    [FieldOffset(0x34)] public fixed byte GrowthLevel[20];
    [FieldOffset(0x48)] public fixed byte WaterLevel[20];
    [FieldOffset(0x5C)] public fixed byte GardenerYield[20];
    
    [FixedSizeArray<FarmSlotFlags>(20)]
    [FieldOffset(0x70)] public fixed byte FarmSlotFlags[20];
}

[Flags]
public enum FarmSlotFlags : byte {
    UnderCare = 1,
    WasUnderCare = 2, // ???
    CareHalted = 4,
    Flag8 = 8
}
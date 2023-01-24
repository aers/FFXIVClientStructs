namespace FFXIVClientStructs.FFXIV.Client.Game.MJI; 


// ctor 1413EA840 ? - extends EventHandler
[StructLayout(LayoutKind.Explicit, Size = 0xAE0)]
public unsafe partial struct MJIPastureHandler {
    [FieldOffset(0x0)] public void* vtbl;
    
    [FixedSizeArray<MJIAnimal>(20)]
    [FieldOffset(0x2E8)] public fixed byte MJIAnimals[MJIAnimal.Size * 20];
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct MJIAnimal {
    public const int Size = 0x34;

    [FieldOffset(0x0)] public byte SlotId;
    [FieldOffset(0x1C)] public uint BNPCNameId;
    [FieldOffset(0x24)] public byte AnimalType;
    [FieldOffset(0x25)] public byte FoodLevel;
    [FieldOffset(0x26)] public byte Mood;
    [FieldOffset(0x27)] public ushort Leavings; // ??
}
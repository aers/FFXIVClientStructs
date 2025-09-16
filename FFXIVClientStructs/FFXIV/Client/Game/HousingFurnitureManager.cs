namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x9680)]
public partial struct HousingFurnitureManager {
    // Index 731 is for the temporary object
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray732<HousingFurniture> _furnitureMemory;
    [FieldOffset(0x8940)] public StdVector<Pointer<HousingFurniture>> FurnitureVector;
    [FieldOffset(0x8958)] public HousingObjectManager ObjectManager;
    
    [FieldOffset(0x9678)] public long LastUpdate; // every ~200ms
}

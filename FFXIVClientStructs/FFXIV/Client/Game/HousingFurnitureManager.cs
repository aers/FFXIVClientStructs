namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x125B0)]
public partial struct HousingFurnitureManager {
    // Index 1461 is for the temporary object
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray1462<HousingFurniture> _furnitureMemory;
    [FieldOffset(0x11220)] public StdVector<Pointer<HousingFurniture>> FurnitureVector;
    [FieldOffset(0x11238)] public HousingObjectManager ObjectManager;

    [FieldOffset(0x12598)] public long LastUpdate; // every ~200ms
}

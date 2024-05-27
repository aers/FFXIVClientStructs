using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

// 0xA160 for Indoor, 0xAE30 for Outdoor
[StructLayout(LayoutKind.Explicit, Size = 0xA160)]
public unsafe partial struct HousingTerritory { // this should be renamed to IndoorHousingTerritory and the fields should be copied to OutdoorHousingTerritory
    [FixedSizeArray<HousingFurniture>(732)]
    [FieldOffset(0x10)] public fixed byte Furniture[732 * 0x30];
    [FieldOffset(0x8968)] public HousingObjectManager HousingObjectManager;
    [FieldOffset(0x96A0)] public uint HouseID; // Combines Ward, Plot, and Room
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct HousingFurniture {
    [FieldOffset(0x00)] public uint Id; // If Indoors: (0x20000 | Id) = HousingFurniture Row, If Outdoors: (0x30000 | Id) = HousingFurniture Row
    [FieldOffset(0x04)] public byte Stain;
    [FieldOffset(0x10)] public Vector3 Position;
    [FieldOffset(0x20)] public float Rotation;
    [FieldOffset(0x24)] public int Index; // Index into the HousingObjectManager
}

[StructLayout(LayoutKind.Explicit, Size = 0xC98)]
public unsafe partial struct HousingObjectManager {
    [FixedSizeArray<Pointer<GameObject>>(400)]
    [FieldOffset(0x18)] public fixed byte Objects[400 * 8];
}

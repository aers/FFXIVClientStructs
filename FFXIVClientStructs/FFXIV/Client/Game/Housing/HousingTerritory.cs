using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

// 0xA160 for Indoor, 0xAE30 for Outdoor
[StructLayout(LayoutKind.Explicit, Size = 0xA160)]
[GenerateInterop]
public unsafe partial struct HousingTerritory { // this should be renamed to IndoorHousingTerritory and the fields should be copied to OutdoorHousingTerritory
    [FieldOffset(0x10)] [FixedSizeArray] internal FixedSizeArray732<HousingFurniture> _furniture; 
    [FieldOffset(0x8968)] public HousingObjectManager HousingObjectManager;
    [FieldOffset(0x96A0)] public uint HouseId; // Combines Ward, Plot, and Room
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
[GenerateInterop]
public unsafe partial struct HousingObjectManager {
    [FieldOffset(0x18)] [FixedSizeArray] internal FixedSizeArray400<Pointer<GameObject>> _objects;
}

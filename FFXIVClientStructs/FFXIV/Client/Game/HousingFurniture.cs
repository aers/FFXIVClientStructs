using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct HousingFurniture {
    [FieldOffset(0x00)] public uint Id; // If Indoors: (0x20000 | Id) = HousingFurniture Row, If Outdoors: (0x30000 | Id) = HousingFurniture Row
    [FieldOffset(0x04)] public byte Stain;
    [FieldOffset(0x10)] public Vector3 Position;
    [FieldOffset(0x20)] public float Rotation;
    [FieldOffset(0x24)] public int Index; // Index into the HousingObjectManager
}

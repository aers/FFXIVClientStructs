namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct HousingTerritory {
    [FieldOffset(0x96A0)] public uint HouseID; // Combines Ward, Plot, and Room
}

namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

// 0xA160 for Indoor, 0xAE30 for Outdoor
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct HousingTerritory {
    [FieldOffset(0x96A0)] public uint HouseID; // Combines Ward, Plot, and Room
}

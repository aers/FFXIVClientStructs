namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// ctor (2023.07.06.0000.0000):
// E9 ?? ?? ?? ?? 3D ?? ?? ?? ?? 0F 87 ?? ?? ?? ?? 3D ?? ?? ?? ?? 0F 83 ?? ?? ?? ?? 05 ?? ?? ?? ?? 83 F8 05
// has id >63000 in InstanceContent sheet
[StructLayout(LayoutKind.Explicit, Size = 0x1CA8 + 0x650)]
public unsafe partial struct InstanceContentOceanFishing {
    [FieldOffset(0x0)] public InstanceContentDirector InstanceContentDirector;

    // Row ID for IKDRoute sheet
    // Each zone (and their time of day) can be extracted from sheet
    [FieldOffset(0x1CD0)] public uint CurrentRoute;

    [FieldOffset(0x1CD8)] public byte CurrentZone; // 0, 1, 2

    // InstanceContentDirector.ContentDirector.ContentTimeLeft - TimeOffset = time left in current zone
    // After changing zones, seems to tick down independent of the UI and then jump up
    [FieldOffset(0x1CE0)] public uint TimeOffset;

    [FieldOffset(0x1CE4)] public uint WeatherID;

    [FieldOffset(0x1CE8)] public bool SpectralCurrentActive;

    // Offest can be found with this sig "45 8B 84 CF ?? ?? ?? ?? 48 8B CD"
    // Struct size can be found with "83 C7 ?? 49 83 EE ?? 75 ?? FF C6"
    // Array size can be found with "83 FF ?? 72 ?? 4C 8B 74 24 ?? 49 8D 9F"
    [FixedSizeArray<FishDataStruct>(60)]
    [FieldOffset(0x1D3C)] public fixed byte FishData[0x10 * 60];

    // Row ID for IKDPlayerMissionCondition sheet
    // Description and required amount can be extracted from sheet
    [FieldOffset(0x22E0)] public uint Mission1Type;
    [FieldOffset(0x22E4)] public uint Mission2Type;
    [FieldOffset(0x22E8)] public uint Mission3Type;

    // Progress can be larger than the mission's required amount
    [FieldOffset(0x22EC)] public ushort Mission1Progress;
    [FieldOffset(0x22EE)] public ushort Mission2Progress;
    [FieldOffset(0x22F0)] public ushort Mission3Progress;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct FishDataStruct {
        [FieldOffset(0x0)] public uint ItemId;
        // Row id for IKDFishParam sheet, can be used to retrieve fish type like jellyfish, seahorse etc.
        [FieldOffset(0x4)] public ushort FishParamId;
        [FieldOffset(0x6)] public ushort NqAmount;
        [FieldOffset(0x8)] public uint HqAmount;
        [FieldOffset(0xC)] public uint TotalScore;
    }
}

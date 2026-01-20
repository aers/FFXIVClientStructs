namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::MapDiscoveryManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1024)]
public unsafe partial struct MapDiscoveryManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 0F B6 87 ?? ?? ?? ?? 88 05", 3)]
    public static partial MapDiscoveryManager* Instance();

    /// <summary> Maps with up to 16 discoverable regions </summary>
    /// <remarks> Index is DiscoveryIndex, used when DiscoveryArrayByte is true (from Map sheet) </remarks>
    [FieldOffset(0x000), FixedSizeArray] internal FixedSizeArray162<DiscoveryTable16> _mapsWithUpTo16Regions;
    /// <summary> Maps with up to 32 discoverable regions </summary>
    /// <remarks> Index is DiscoveryIndex, used when DiscoveryArrayByte is false (from Map sheet) </remarks>
    [FieldOffset(0xA20), FixedSizeArray] internal FixedSizeArray48<DiscoveryTable32> _mapsWithUpTo32Regions;
    [FieldOffset(0x1020)] public float ReportCooldown;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 05 ?? ?? ?? ?? 8B FA")]
    public partial bool IsDiscoveryEnabledForMap(uint mapId);

    /// <summary>
    /// Checks if a map region was discovered.<br/>
    /// This runs an internal Map sheet lookup!
    /// </summary>
    /// <param name="mapId">The Map RowId</param>
    /// <param name="regionIndex">The region index</param>
    /// <returns><see langword="true"/> if discovered, <see langword="false"/> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 44 0B F7")]
    public partial bool IsMapRegionDiscovered(uint mapId, byte regionIndex);

    /// <summary>
    /// Checks if a map region was discovered, without Map sheet lookup.
    /// </summary>
    /// <param name="discoveryIndex">DiscoveryIndex from the Map sheet</param>
    /// <param name="regionIndex">The region index</param>
    /// <param name="isMapWithUpTo16Regions">DiscoveryArrayByte from the Map sheet</param>
    /// <returns><see langword="true"/> if discovered, <see langword="false"/> otherwise.</returns>
    [MemberFunction("33 C0 4C 8B D1 66 3B C2 7F ?? 45 84 C9 74 ?? B8 ?? ?? ?? ?? 66 3B D0 73 ?? 48 0F BF C2")]
    public partial bool IsRegionDiscovered(ushort discoveryIndex, byte regionIndex, bool isMapWithUpTo16Regions);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public partial struct DiscoveryTable16 {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray16<bool> _discoveries;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public partial struct DiscoveryTable32 {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray32<bool> _discoveries;
    }
}

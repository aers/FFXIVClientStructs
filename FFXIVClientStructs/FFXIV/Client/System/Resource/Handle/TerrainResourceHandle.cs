namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::TerrainResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
// .tera
/// <summary>
/// Terrain resources define a grid layout and specify tiles with models assigned to them.
/// </summary>
/// <remarks>
/// Each terrain tile has a corresponding model with the path <c>####.mdl</c> relative to the terrain resource according to their index in it,
/// starting at <c>0000.mdl</c>.
/// </remarks>
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct TerrainResourceHandle {

    [StructLayout(LayoutKind.Explicit, Size = 0x38)] // 0x34 header, plus the tile coordinates array
    public partial struct TeraFile {
        [FieldOffset(0x00)] public uint Version;
        [FieldOffset(0x04)] public uint TileCount;
        [FieldOffset(0x08)] public uint GridSize;
        [FieldOffset(0x0C)] public float ClipDistance;
        [FieldOffset(0x10)] private float _unk10;
        [FieldOffset(0x14)] public uint Flags;

        [FieldOffset(0x34)] internal FixedSizeArray1<TerrainGridCoordinates> _tileCoordinates;
        public Span<TerrainGridCoordinates> TileCoordinates => MemoryMarshal.CreateSpan(ref _tileCoordinates[0], (int)TileCount);
    }

    [Obsolete("Use the TeraFile overload")]
    [VirtualFunction(23u)]
    public partial byte* GetData();

    [VirtualFunction(23u)]
    public partial TeraFile* GetTeraFileData();

    /// <summary>
    /// Gets the version of the terrain resource.
    /// </summary>
    /// <remarks>The current version is <c>0x1000003</c></remarks>
    [MemberFunction("48 83 EC 28 48 8B 01 FF 90 ?? ?? ?? ?? 8B 00")]
    public partial uint GetFileVersion();

    /// <summary>
    /// Gets the number of tiles in the terrain resource.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 81 FF")]
    public partial uint GetTileCount();

    /// <summary>
    /// Gets the horizontal size of the grid tiles in the terrain resource.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 89 85 ?? ?? ?? ?? 44 8B E0")]
    public partial uint GetTileWidth();

    /// <summary>
    /// Gets the clip distance stored in the terrain resource, or 0.0f for files older than version <c>0x1000002</c>.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 59 C0 F3 0F 11 87")]
    public partial float GetClipDistance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB F3 0F 11 87")]
    internal partial float GetUnk10();

    /// <summary>
    /// Returns whether the flag with the given index is enabled in the terrain resource.
    /// </summary>
    /// <param name="flagIndex">Which flag to get.</param>
    /// <returns>1 if the flag is set, or 0 otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 87 ?? ?? ?? ?? 48 8B 7C 24")]
    public partial uint GetFlag(TerrainResourceFlag flagIndex);

    /// <summary>
    /// Gets the array of grid coordinates for the tiles in the terrain resource.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B F8 44 8B D5")]
    public partial TerrainGridCoordinates* GetTileCoordinateArray();
}

/// <summary>
/// The flags that can be specified in a terrain resource.
/// </summary>
public enum TerrainResourceFlag : uint {
    Flag0, // Value assigned to TerrainRenderer+0x43B5
    Flag1, // Value assigned to TerrainRenderer+0x43B6
    Flag2, // Value assigned to TerrainRenderer+0x43B7
}

/// <summary>
/// The X and Z coordinates of a tile on a terrain grid.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public partial struct TerrainGridCoordinates {
    [FieldOffset(0x0)] public short TileX;
    [FieldOffset(0x2)] public short TileZ;
}

using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Terrain
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe partial struct Terrain {
    [FieldOffset(0x90), Obsolete("Use TerrainResourceHandle instead.")] public ResourceHandle* ResourceHandle;
    [FieldOffset(0x90)] public TerrainResourceHandle* TerrainResourceHandle;
    [FieldOffset(0x98)] public ModelResourceHandle** TileModelResourceHandlesPtr;
    [FieldOffset(0xA0)] public uint TileCount;
    [FieldOffset(0xA4)] public uint TerrainPlateCount;
    [FieldOffset(0xA8)] public uint WaterPlateCount;
    [FieldOffset(0xAC)] public uint VerticalFogPlateCount;
    [FieldOffset(0xB0)] internal TerrainPlate** _terrainPlates;
    [FieldOffset(0xB8)] internal WaterPlate** _waterPlates;
    [FieldOffset(0xC0)] internal VerticalFogPlate** _verticalFogPlates;
    [FieldOffset(0xC8)] internal void** _terrainPlateCullingHandles;
    [FieldOffset(0xD0)] internal void** _waterPlateCullingHandles;
    [FieldOffset(0xD8)] internal void** _verticalFogPlateCullingHandles;

    [FieldOffset(0xE0)] public byte ModelLoadPhase; // 1 -> Load the models with GetResourceAsync next UpdateRender, 2 -> Waiting for plate models to load, and each frame checks the model resource handles until they are loaded.
    [FieldOffset(0xE1)][FixedSizeArray(isString: true)] internal FixedSizeArray256<byte> _terrainGameFolder; // The folder to read the plate models and grass zone data from
    [FieldOffset(0x1E1)] internal byte Unk1E1;
    [FieldOffset(0x1E2)] public byte EnableGrass;

    public Span<Pointer<ModelResourceHandle>> TileModelResourceHandles => new(TileModelResourceHandlesPtr, (int)TileCount);

    /// <summary>
    /// The terrain plates for each of the tile models that have terrain meshes.
    /// </summary>
    public Span<Pointer<TerrainPlate>> TerrainPlates => new(_terrainPlates, (int)TerrainPlateCount);
    /// <summary>
    /// The water plates for each of the tile models that have water meshes.
    /// </summary>
    public Span<Pointer<WaterPlate>> WaterPlates => new(_waterPlates, (int)WaterPlateCount);
    /// <summary>
    /// The vertical fog plates for each of the tile models that have vertical fog meshes.
    /// </summary>
    public Span<Pointer<VerticalFogPlate>> VerticalFogPlates => new(_verticalFogPlates, (int)VerticalFogPlateCount);

    public Span<IntPtr> TerrainPlateCullingHandles => new(_terrainPlateCullingHandles, (int)TerrainPlateCount);
    public Span<IntPtr> WaterPlateCullingHandles => new(_waterPlateCullingHandles, (int)WaterPlateCount);
    public Span<IntPtr> VerticalFogPlateCullingHandles => new(_verticalFogPlateCullingHandles, (int)VerticalFogPlateCount);

    /// <summary>
    /// Loads <see cref="TerrainResourceHandle"/> by category and path.
    /// </summary>
    /// <param name="terrainResourceCategory">The resource category of the terrain resource.</param>
    /// <param name="terrainResourcePath">The path of the terrain resource.</param>
    /// <param name="unk1E1"></param>
    /// <param name="enableGrass">Whether to enable grass loading, which will happen later.</param>
    [MemberFunction("E8 ?? ?? ?? ?? B3 01 EB 02 32 DB 48 8B 55 E8"), GenerateStringOverloads]
    public partial void Load(ResourceCategory* terrainResourceCategory, CStringPointer terrainResourcePath, bool unk1E1, bool enableGrass);

    /// <summary>
    /// Populates <see cref="TileModelResourceHandles"/> by loading one model resource for every tile in <see cref="TerrainResourceHandle"/>
    /// using the path <c>####.mdl</c> with the tile's index.
    /// </summary>
    [MemberFunction("40 53 41 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 45 33 F6")]
    public partial void LoadTileModels();

    /// <summary>
    /// Loads grass data from <c>grass_zone_data.gzd</c> into the grass renderer.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 33 D2 C7 40")]
    public partial void LoadGrass();

    /// <summary>
    /// Populates <see cref="TerrainPlates"/> by creating one plate per model resource in <see cref="TileModelResourceHandles"/> that has a terrain mesh.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 74 24 ?? 48 8B 6C 24 ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B CB")]
    public partial bool CreateTerrainPlates();

    /// <summary>
    /// Populates <see cref="WaterPlates"/> by creating one plate per model resource in <see cref="TileModelResourceHandles"/> that has a water mesh.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 84 C0 74 7D")]
    public partial bool CreateWaterPlates();

    /// <summary>
    /// Populates <see cref="VerticalFogPlates"/> by creating one plate per model resource in <see cref="TileModelResourceHandles"/> that has a vertical fog mesh.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 7D 80 BB")]
    public partial bool CreateVerticalFogPlates();
}

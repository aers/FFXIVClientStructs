using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Terrain;

// Client::LayoutEngine::Terrain::TerrainManager
//   Client::LayoutEngine::IManagerBase
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<IManagerBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe partial struct TerrainManager {
    [FieldOffset(0x018)] public Graphics.Scene.Terrain* GfxTerrain; // Client::Graphics::Scene::Terrain*
    [FieldOffset(0x020)] public ColliderStreamed* Collider;
    [FieldOffset(0x028), FixedSizeArray(isString: true)] internal FixedSizeArray260<byte> _path;
    [FieldOffset(0x12C)] public int State;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 89 51 10"), GenerateStringOverloads]
    public partial void Load(uint terrainManagerId, CStringPointer terrainResourcePath, bool loadGrass, bool disableCollision);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 36 C7 83")]
    public partial bool CreateGraphics(CStringPointer terrainFolder, bool loadGrass); // Looks for <terrainFolder>/bgplate/terrain.tera

    [MemberFunction("E8 ?? ?? ?? ?? C7 83 ?? ?? ?? ?? ?? ?? ?? ?? EB B7")]
    public partial void CreateCollision(CStringPointer terrainFolder); // Looks for <terrainFolder>/collision/list.pcb
}

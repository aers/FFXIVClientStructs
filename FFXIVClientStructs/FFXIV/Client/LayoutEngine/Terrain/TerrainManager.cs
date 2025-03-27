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
}

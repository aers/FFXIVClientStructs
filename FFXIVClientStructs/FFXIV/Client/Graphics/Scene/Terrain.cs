using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Terrain
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1F0)] // size probably outdated
public unsafe partial struct Terrain {
    [FieldOffset(0x90)] public ResourceHandle* ResourceHandle; // Client::System::Resource::Handle::TerrainResourceHandle
}

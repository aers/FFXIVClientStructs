using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe struct LayoutTerrain {
    [FieldOffset(0x000)] public IManagerBase IManagerBase;
    [FieldOffset(0x018)] public void* GfxTerrain; // Client::Graphics::Scene::Terrain*
    [FieldOffset(0x020)] public ColliderStreamed* Collider;
    [FieldOffset(0x028)] public fixed byte Path[260];
    [FieldOffset(0x12C)] public int State;
}

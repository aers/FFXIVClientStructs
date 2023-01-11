namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;
// Client::Graphics::Render::OffscreenRenderingManager
// renderer responsible for UI character models - tryon, inspect, etc

// size = 0x150
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe struct OffscreenRenderingManager
{
    [FieldOffset(0x0)] public void* vtbl;

    // OffscreenRenderingManager::RenderJobSystem - size is at least 0xB8
    [FieldOffset(0x8)] public void* JobSystem_vtbl;

    // actually an array but C#
    [FieldOffset(0xC8)] public void* Camera_1; // Client::Graphics::Render::Camera
    [FieldOffset(0xD0)] public void* Camera_2;
    [FieldOffset(0xD8)] public void* Camera_3;
    [FieldOffset(0xE0)] public void* Camera_4;
}
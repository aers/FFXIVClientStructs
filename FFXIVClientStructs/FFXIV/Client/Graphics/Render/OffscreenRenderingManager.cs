namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::OffscreenRenderingManager
// renderer responsible for UI character models - tryon, inspect, etc
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe struct OffscreenRenderingManager {
    // actually an array but C#
    [FieldOffset(0xC8)] public void* Camera_1; // Client::Graphics::Render::Camera
    [FieldOffset(0xD0)] public void* Camera_2;
    [FieldOffset(0xD8)] public void* Camera_3;
    [FieldOffset(0xE0)] public void* Camera_4;
}

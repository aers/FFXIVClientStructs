using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::VfxObject
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct VfxObject {
    [FieldOffset(0x2A0)] public unsafe VfxResourceInstance* VfxResourceInstance;
}

using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::VfxObject
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
//   Apricot::ApricotInstanceListenner
//     Apricot::IInstanceListenner
//   Client::Graphics::Vfx::VfxResourceInstanceListenner
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct VfxObject {
    [FieldOffset(0x2A0)] public VfxResourceInstance* VfxResourceInstance;
}

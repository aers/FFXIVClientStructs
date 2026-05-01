using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Decal
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct Decal {
    [FieldOffset(0x98)] public TextureResourceHandle* TextureResourceHandle;
    [FieldOffset(0xA0)] private TextureResourceHandle* UnkTextureResourceHandle;
    [FieldOffset(0xA8)] private TextureResourceHandle* UnkTextureResourceHandle2;
}

using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::EnvSpace
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct EnvSpace {
    [FieldOffset(0x90)] public ResourceHandle* EnvSetResourceHandle; // is an EnvSetResourceHandle, .envb
    [FieldOffset(0x98)] public ResourceHandle* SoundSetResourceHandle; // is a SoundSetResourceHandle, .essb
    [FieldOffset(0xB0)] public EnvLocation* EnvLocation;
}

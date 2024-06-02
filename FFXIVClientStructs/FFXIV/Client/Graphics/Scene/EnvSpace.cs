namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::EnvSpace
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct EnvSpace {
    [FieldOffset(0xB0)] public EnvLocation* EnvLocation;
}

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::World
//   Client::Graphics::Scene::Object
//   Client::Graphics::Singleton
[GenerateInterop]
[Inherits<Object>]
[StructLayout(LayoutKind.Explicit, Size = 0x160)]
public unsafe partial struct World {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 48 8B 50 40", 3, isPointer: true)]
    public static partial World* Instance();
}

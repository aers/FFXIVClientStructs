using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.File;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::EnvLocation
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
//   Client::Graphics::Vfx::VfxResourceInstanceListenner @ 0x240
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x4E0)]
public unsafe partial struct EnvLocation {
    [FieldOffset(0x90)] public ResourceHandle* AmbientSetResource; // AmbientSetResourceHandle, .amb
    [FieldOffset(0x98)] public TextureResourceHandle* EnvironmentCubemapResource;
    [FieldOffset(0xA0)] public void* AmbientSet;
    [FieldOffset(0xA8)] public Texture* EnvironmentCubemap;
    [FieldOffset(0xB0)] private float _unk_B0;
    [FieldOffset(0xB8)] private byte _unk_B8;
    [FieldOffset(0xB9)] private ushort _unk_B9;
    [FieldOffset(0xC0)] public FileAccessPath AmbientSetResourcePath;
    [FieldOffset(0x2D0)] public FileAccessPath EnvironmentCubemapResourcePath;    

    // There can only be 32 at once--beyond that, returns null.
    [MemberFunction("40 53 48 83 EC 20 83 3D ?? ?? ?? ?? ?? 7D 4E")]
    public static partial EnvLocation* TryCreate();

    [MemberFunction("E9 ?? ?? ?? ?? 48 83 C4 20 5B C3 CC CC CC CC CC CC C2 00 00")]
    public static partial void TryDestroy(EnvLocation** locationPointer);
}

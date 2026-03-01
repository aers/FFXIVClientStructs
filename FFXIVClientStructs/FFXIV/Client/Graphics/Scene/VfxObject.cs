using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;
using FFXIVClientStructs.FFXIV.Common.Math;

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

    [FieldOffset(0x128)] public int ActorCaster;

    [FieldOffset(0x130)] public int ActorTarget;

    [FieldOffset(0x1B8)] public int StaticCaster;

    [FieldOffset(0x1C0)] public int StaticTarget;

    [FieldOffset(0x248)] internal byte SomeFlags;

    [FieldOffset(0x260)] public Vector4 Color;

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 10 35 ?? ?? ?? ?? 48 89 43 08")]
    public static partial VfxObject* Create(byte* vfxGamePath, byte* pool);

    [MemberFunction("E8 ?? ?? ?? ?? ?? ?? ?? 8B 4A ?? 85 C9")]
    public partial uint Update(float deltaSeconds, uint flags = uint.MaxValue);
}

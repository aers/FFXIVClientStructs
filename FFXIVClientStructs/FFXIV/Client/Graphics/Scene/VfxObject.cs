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
[StructLayout(LayoutKind.Explicit, Size = 0x390)]
public unsafe partial struct VfxObject {
    [FieldOffset(0x128)] public int ActorCaster;

    [FieldOffset(0x130)] public int ActorTarget;

    [FieldOffset(0x1B8)] public int StaticCaster;

    [FieldOffset(0x1C0)] public int StaticTarget;

    [FieldOffset(0x248)] public byte SomeFlags; // bit 0x40 is set to 1 when fadeout

    [FieldOffset(0x250)] public float Speed;

    [FieldOffset(0x258)] public float FadeOutFrames; // 1.0f = 1/60 s, not actually related with frame rate

    [FieldOffset(0x260)] public Vector4 Color;

    [FieldOffset(0x2A0)] public VfxResourceInstance* VfxResourceInstance;

    [GenerateStringOverloads]
    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 10 35 ?? ?? ?? ?? 48 89 43 08")]
    public static partial VfxObject* Create(CStringPointer vfxGamePath, CStringPointer poolName);

    [MemberFunction("E8 ?? ?? ?? ?? ?? ?? ?? 8B 4A ?? 85 C9")]
    public partial void Update(float deltaSeconds, int flags = -1);
}

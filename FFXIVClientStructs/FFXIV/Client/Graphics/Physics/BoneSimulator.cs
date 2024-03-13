using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::BoneSimulator
// ctor "33 D2 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B C1 89 51 10"
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe struct BoneSimulator {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public uint PhysicsGroup;
    [FieldOffset(0x18)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton
    [FieldOffset(0x20)] public Vector3 CharacterPosition;
    [FieldOffset(0x30)] public Vector3 Gravity;
    [FieldOffset(0x40)] public Vector3 Wind;
    [FieldOffset(0x54)] public float Spring; // Default is ~60, intense jitter happens above that value. Lesser values remove the spring in the bone.
}

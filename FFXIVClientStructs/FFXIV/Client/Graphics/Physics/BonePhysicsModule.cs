using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct BoneSimulators
{
    [FieldOffset(0x00)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_1;
    [FieldOffset(0x18)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_2;
    [FieldOffset(0x30)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_3;
    [FieldOffset(0x48)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_4;
    [FieldOffset(0x60)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_5;
}

// Client::Graphics::Physics::BonePhysicsModule

// size = 0x1C0
// ctor - 48 8D 05 ?? ?? ?? ?? C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 45 33 C9 
[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public unsafe struct BonePhysicsModule
{
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x10)] public Matrix4x4 SkeletonWorldMatrix;
    [FieldOffset(0x50)] public Matrix4x4 SkeletonInvWorldMatrix;
    [FieldOffset(0x90)] public float WindScale;
    [FieldOffset(0x94)] public float WindVariation;
    [FieldOffset(0x98)] public Skeleton* Skeleton; 
    [FieldOffset(0xA0)] public BoneSimulators BoneSimulators;
}
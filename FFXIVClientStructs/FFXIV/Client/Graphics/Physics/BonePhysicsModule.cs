using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct BoneSimulators {
    [FieldOffset(0x00)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_1;
    [FieldOffset(0x18)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_2;
    [FieldOffset(0x30)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_3;
    [FieldOffset(0x48)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_4;
    [FieldOffset(0x60)] public StdVector<Pointer<BoneSimulator>> BoneSimulator_5;
}

// Client::Graphics::Physics::BonePhysicsModule
[StructLayout(LayoutKind.Explicit, Size = 0x590)]
[GenerateInterop]
public unsafe partial struct BonePhysicsModule {
    [FieldOffset(0x10)] public Matrix4x4 SkeletonWorldMatrix;
    [FieldOffset(0x50)] public Matrix4x4 SkeletonInvWorldMatrix;
    [FieldOffset(0x90)] public float WindScale;
    [FieldOffset(0x94)] public float WindVariation;
    [FieldOffset(0x98)] public Skeleton* Skeleton;
    [FieldOffset(0xA0)] public BoneSimulators BoneSimulators;
    [FieldOffset(0x190), FixedSizeArray] internal FixedSizeArray5<Pointer<ResourceHandle>> _bonePhysicsResourceHandles;
}

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
    [FieldOffset(0x1B8)] public float FrameDeltaTime;

    /// <summary> Used to set BoneSimulator.SimulationTimeInv. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 2F C6 76 ?? 48 8B CE")]
    public partial float GetSimulationTimeInv();

    /// <summary> Limits the returned value to 60 FPS, used to set BoneSimulator.SimulationTime. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5E F0 F3 0F 11 43")]
    public partial float GetSimulationTime();
}

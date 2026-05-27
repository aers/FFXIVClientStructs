using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

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
    [FieldOffset(0x118)] public BoneCollisions BoneCollisions;
    [FieldOffset(0x190), FixedSizeArray] internal FixedSizeArray5<Pointer<ResourceHandle>> _bonePhysicsResourceHandles; // TODO: change element type to Pointer<BonePhysicsResourceHandle>
    [FieldOffset(0x1B8)] public float FrameDeltaTime;
    [FieldOffset(0x578)] public float OverrideSimulationTime;
    /// <remarks> If <see langword="true"/>, returns <see cref="OverrideSimulationTime"/> when <see cref="GetSimulationTime"/> is called and <see cref="FrameDeltaTime"/> is above <c>~0.01667</c> (60 FPS.) </remarks>
    [FieldOffset(0x588)] public bool UseOverrideSimulationTime;

    /// <summary> Used to set <see cref="BoneSimulator.SimulationTimeInv"/>, and in turn calls <see cref="GetSimulationTime"/>. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 2F C6 76 ?? 48 8B CE")]
    public partial float GetSimulationTimeInv();

    /// <summary> Limits the returned value to 60 FPS, used to set <see cref="BoneSimulator.SimulationTime"/>. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5E F0 F3 0F 11 43")]
    public partial float GetSimulationTime();

    /// <summary> Creates job data based on the lists in <see cref="BoneSimulators"/> and <see cref="BoneCollisions"/>. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 7F ?? 48 83 EB ?? 75 ?? 48 8B 45")]
    public partial void CreateJobData(BonePhysicsUpdater* updater);

    /// <summary>
    /// Loads data into the vector in <see cref="BoneSimulators"/> and <see cref="BoneCollisions"/> corresponding to resourceIndex.
    /// This resource handle is then stored in <see cref="BonePhysicsResourceHandles"/>.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 03 48 8B CB FF C6")]
    public partial void Load(BonePhysicsResourceHandle* handle, uint resourceIndex);
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct BoneSimulators {
    [FieldOffset(0x00)] public StdVector<Pointer<BoneSimulator>> BoneSimulator1;
    [FieldOffset(0x18)] public StdVector<Pointer<BoneSimulator>> BoneSimulator2;
    [FieldOffset(0x30)] public StdVector<Pointer<BoneSimulator>> BoneSimulator3;
    [FieldOffset(0x48)] public StdVector<Pointer<BoneSimulator>> BoneSimulator4;
    [FieldOffset(0x60)] public StdVector<Pointer<BoneSimulator>> BoneSimulator5;
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public struct BoneCollisions {
    [FieldOffset(0x00)] public StdVector<Pointer<CollisionBase>> BoneCollision1;
    [FieldOffset(0x18)] public StdVector<Pointer<CollisionBase>> BoneCollision2;
    [FieldOffset(0x30)] public StdVector<Pointer<CollisionBase>> BoneCollision3;
    [FieldOffset(0x48)] public StdVector<Pointer<CollisionBase>> BoneCollision4;
    [FieldOffset(0x60)] public StdVector<Pointer<CollisionBase>> BoneCollision5;
}

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Singleton
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct BonePhysicsUpdater {
    [FieldOffset(0x20)] public JobSystem CollisionObjectJob;
    [FieldOffset(0xE0)] public JobSystem BoneSimulatorJob;
    [FieldOffset(0x1A0)] public JobSystem TransformUpdaterJob;

    /// <remarks> This is executed by BoneSimulatorJob. </remarks>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? ?? ?? ?? 33 ED 4C 8B F2")] // don't use the lea instruction sig
    public partial void BoneSimulatorTask(UpdateBoneSimulatorJobData* data);

    /// <remarks> This is executed by CollisionObjectJob. </remarks>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B 3A 48 8B 5F")]
    public partial void CollisionObjectTask(CollisionObjectJobData* data);

    /// <remarks> Structure passed to BoneSimulatorTask. </remarks>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct UpdateBoneSimulatorJobData {
        [FieldOffset(0x0)] public BoneSimulator* BoneSimulator;
        [FieldOffset(0x8)] public BonePhysicsModule* BonePhysicsModule;
    }

    /// <remarks> Structure passed to CollisionObjectTask. </remarks>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public partial struct CollisionObjectJobData {
        [FieldOffset(0x0)] public CollisionBase* CollisionObject;
    }
}

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Singleton
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct BonePhysicsUpdater {
    [FieldOffset(0x20)] public JobSystem CollisionObjectJob;
    [FieldOffset(0xE0)] public JobSystem BoneSimulatorJob;
    [FieldOffset(0x1A0)] public JobSystem TransformUpdaterJob;

    /// <remarks> This is executed by BoneSimulatorUpdateJob. </remarks>
    [MemberFunction("48 8D 05 ?? ?? ?? ?? 48 89 6B ?? 48 89 43")]
    public partial void BoneSimulatorTask(UpdateBoneSimulatorJobData* data);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct UpdateBoneSimulatorJobData {
        [FieldOffset(0x0)] BoneSimulator* BoneSimulator;
        [FieldOffset(0x8)] BonePhysicsModule* BonePhysicsModule;
    }
}

using FFXIVClientStructs.Havok.Animation.Playback.SampleAndBlend;
using FFXIVClientStructs.Havok.Common.Base.Container.Array;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::SkeletonUpdater
//   Client::Graphics::Singleton<Client::Graphics::Render::SkeletonUpdater>
/// <summary> Samples skeleton animations on the job pool, 8 skeletons per job. </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe partial struct SkeletonUpdater {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 48 8B D9 F3 0F 11 88 F0 00 00 00", 3, isPointer: true)]
    public static partial SkeletonUpdater* Instance();

    [FieldOffset(0x08)] private fixed byte Lock[0x28]; // CRITICAL_SECTION, guards SampleJobs
    /// <summary> Writers are found through TLS block +0x298. </summary>
    [FieldOffset(0x30)] public JobSystem UpdaterJobs; // Client::Graphics::JobSystem<Client::Graphics::Render::SkeletonUpdater,Client::Graphics::Render::SkeletonUpdater::UpdaterJob,8>
    [FieldOffset(0xF0)] public float DeltaTime;
    /// <summary> Havok sample jobs collected by <see cref="UpdaterJobs"/>, run on the Havok job queue after <see cref="SampleAnimations"/> returns. </summary>
    [FieldOffset(0xF8)] public hkArray<Pointer<hkaSampleBlendJob>>* SampleJobs;

    /// <summary> Appends every skeleton from <paramref name="first"/> on, then runs <see cref="UpdaterJobs"/> and waits. </summary>
    [MemberFunction("48 89 5C 24 08 48 89 74 24 10 57 48 83 EC 20 48 8B 05 ?? ?? ?? ?? 48 8B D9 F3 0F 11 88 F0 00 00 00")]
    public static partial void SampleAnimations(Skeleton* first, float deltaTime, hkArray<Pointer<hkaSampleBlendJob>>* sampleJobs);

    /// <summary> Adds one skeleton to the calling thread's writer of <see cref="UpdaterJobs"/>. </summary>
    [MemberFunction("40 53 55 41 54 48 83 EC 20 8B 0D ?? ?? ?? ?? 4C 8B E2 65 48 8B 04 25 ?? ?? ?? ?? BD 98 02 00 00")]
    public partial void AppendSkeleton(Skeleton* skeleton);
}

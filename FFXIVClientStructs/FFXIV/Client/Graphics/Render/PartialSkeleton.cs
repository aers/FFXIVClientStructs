using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.Havok.Animation.Playback;
using FFXIVClientStructs.Havok.Animation.Playback.SampleAndBlend;
using FFXIVClientStructs.Havok.Animation.Rig;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x220)]
public unsafe partial struct PartialSkeleton {
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray2<hkaSampleBlendJob> _jobs;
    [FieldOffset(0x120)] public short ConnectedParentBoneIndex;
    [FieldOffset(0x122)] public short ConnectedBoneIndex;
    [FieldOffset(0x130), FixedSizeArray] internal FixedSizeArray2<ulong> _havokAnimatedSkeletons;
    [FieldOffset(0x140), FixedSizeArray] internal FixedSizeArray4<ulong> _havokPoses;
    [FieldOffset(0x160)] public Skeleton* Skeleton;
    [FieldOffset(0x180)] public void* SkeletonParameterResourceHandle;
    [FieldOffset(0x188)] public SkeletonResourceHandle* SkeletonResourceHandle;
    // 190, 1A0, 1B0 are std set i think, dont know what of

    public hkaAnimatedSkeleton* GetHavokAnimatedSkeleton(int index) {
        if (index is < 0 or > 1) throw new ArgumentOutOfRangeException(nameof(index));
        return (hkaAnimatedSkeleton*)HavokAnimatedSkeletons[index];
    }

    public hkaPose* GetHavokPose(int index) {
        if (index is < 0 or > 3) throw new ArgumentOutOfRangeException(nameof(index));
        return (hkaPose*)HavokPoses[index];
    }
}

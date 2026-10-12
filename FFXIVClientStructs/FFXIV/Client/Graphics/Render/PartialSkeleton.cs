using FFXIVClientStructs.FFXIV.Client.Graphics.Animation;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.Havok.Animation.Playback;
using FFXIVClientStructs.Havok.Animation.Playback.SampleAndBlend;
using FFXIVClientStructs.Havok.Animation.Rig;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// TODO: Move to correct namespace
// Client::Graphics::Animation::PartialSkeleton
//   Client::Graphics::Animation::IAnimationControllerListener;
[Inherits<IAnimationControllerListener>]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct PartialSkeleton {
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray2<hkaSampleBlendJob> _jobs;
    [FieldOffset(0x120)] public short ConnectedParentBoneIndex;
    [FieldOffset(0x122)] public short ConnectedBoneIndex;
    [FieldOffset(0x138), FixedSizeArray] internal FixedSizeArray2<ulong> _havokAnimatedSkeletons; // TODO: hkaAnimatedSkeleton*
    [FieldOffset(0x148), FixedSizeArray] internal FixedSizeArray4<ulong> _havokPoses; // TODO: hkaPose*
    [FieldOffset(0x168)] public Skeleton* Skeleton;
    [FieldOffset(0x188)] public SkeletonParamResourceHandle* SkeletonParamResourceHandle;
    [FieldOffset(0x188), Obsolete("Use SkeletonParamResourceHandle")] public void* SkeletonParameterResourceHandle;
    [FieldOffset(0x190)] public SkeletonResourceHandle* SkeletonResourceHandle;
    [FieldOffset(0x198)] public StdSet<Pointer<AnimationController>> AnimationControllers; // Includes easing & eased out
    [FieldOffset(0x1A8)] public StdSet<Pointer<AnimationController>> AnimationControllersEasingOut;
    [FieldOffset(0x1B8)] public StdSet<Pointer<AnimationController>> AnimationControllersEasedOut;

    public hkaAnimatedSkeleton* GetHavokAnimatedSkeleton(int index) {
        if (index is < 0 or > 1) throw new ArgumentOutOfRangeException(nameof(index));
        return (hkaAnimatedSkeleton*)HavokAnimatedSkeletons[index];
    }

    public hkaPose* GetHavokPose(int index) {
        if (index is < 0 or > 3) throw new ArgumentOutOfRangeException(nameof(index));
        return (hkaPose*)HavokPoses[index];
    }
}

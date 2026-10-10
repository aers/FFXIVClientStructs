using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

// TODO: This type is not a resource handle and needs a better name. Could just be a container of loaded paps... but could this be related the reclusive AnimationTree?
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xF8)] // Unknown size
public unsafe partial struct AnimationResourceHandle {
    [FieldOffset(0x0)] public SkeletonResourceHandle* SkeletonResourceHandle;
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray10<StdVector<Pointer<PartialAnimationPackResourceHandle>>> _papVectors;
}

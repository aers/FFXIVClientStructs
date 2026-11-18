using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct SlopeIkModule {
    [FieldOffset(0x04)] internal float Unk4;

    [FieldOffset(0x18)] public Skeleton* Skeleton;
    [FieldOffset(0x20)] public SkeletonParamResourceHandle.SklpSlope* SlopeParamsCopy;
}

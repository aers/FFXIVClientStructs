using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.Havok;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public unsafe partial struct PartialSkeleton {
	[FieldOffset(0x0)] public void* vtbl;
	[FixedSizeArray<hkaSampleBlendJob>(2)]
	[FieldOffset(0x20)] public fixed byte Jobs[2 * 0x80]; // 2 * hkaSampleBlendJob
	[FieldOffset(0x120)] public short ConnectedParentBoneIndex;
	[FieldOffset(0x122)] public short ConnectedBoneIndex;
	[FieldOffset(0x130)] public fixed ulong HavokAnimatedSkeleton[2];
	[FieldOffset(0x140)] public fixed ulong HavokPoses[4];
	[FieldOffset(0x160)] public Skeleton* Skeleton;
	[FieldOffset(0x180)] public void* SkeletonParameterResourceHandle;
	[FieldOffset(0x188)] public SkeletonResourceHandle* SkeletonResourceHandle;
	// 190, 1A0, 1B0 are std set i think, dont know what of

	public hkaAnimatedSkeleton* GetHavokAnimatedSkeleton(int index)
	{
		if (index is < 0 or > 1) throw new ArgumentOutOfRangeException(nameof(index));
		return (hkaAnimatedSkeleton*)HavokAnimatedSkeleton[index];
	}
	
	public hkaPose* GetHavokPose(int index)
	{
		if (index is < 0 or > 3) throw new ArgumentOutOfRangeException(nameof(index));
		return (hkaPose*)HavokPoses[index];
	}
}

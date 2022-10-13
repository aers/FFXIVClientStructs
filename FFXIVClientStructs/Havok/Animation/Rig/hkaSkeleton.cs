namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkaSkeleton
{
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LocalFrameOnBone
	{
		public hkRefPtr<hkLocalFrame> LocalFrame;
		public short BoneIndex;
	}
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct Partition
	{
		public hkStringPtr Name;
		public short StartBoneIndex;
		public short NumBones;
	}
	
	public hkReferencedObject hkReferencedObject;
	public hkStringPtr Name;
	public hkArray<short> ParentIndices;
	public hkArray<hkaBone> Bones;
	public hkArray<hkQsTransformf> ReferencePose;
	public hkArray<float> ReferenceFloats;
	public hkArray<hkStringPtr> FloatSlots;
	public hkArray<LocalFrameOnBone> LocalFrames;
	public hkArray<Partition> Partitions;
	
	// [MemberFunction("")]
	// public partial hkLocalFrame* GetLocalFrameForBone(int boneIndex);

	// [MemberFunction("")] 
	// public partial short GetPartitionIndexFromName(char* partitionName);

	// [MemberFunction("")]
	// public partial short GetPartitionIndexForBone(short boneIndex);
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 16)]
public unsafe partial struct hkaSkeletonMapperData
{
	enum MappingType
	{
		Ragdoll = 0x0,
		Retargeting = 0x1,
	}

	[StructLayout(LayoutKind.Sequential)]
	struct SimpleMapping
	{
		short BoneA;
		short BoneB;
		hkQsTransformf AFromBTransform;
	}

	[StructLayout(LayoutKind.Sequential)]
	struct PartitionMappingRange
	{
		int StartMappingIndex;
		int NumMappings;
	}

	[StructLayout(LayoutKind.Sequential)]
	struct ChainMapping
	{
		short StartBoneA;
		short EndBoneA;
		short StartBoneB;
		short EndBoneB;
		hkQsTransformf StartAFromBTransform;
		hkQsTransformf EndAFromBTransform;
	}

	hkRefPtr<hkaSkeleton> SkeletonA;
	hkRefPtr<hkaSkeleton> SkeletonB;
	hkArray<short> PartitionMap;
	hkArray<PartitionMappingRange> SimpleMappingPartitionRanges;
	hkArray<PartitionMappingRange> ChainMappingPartitionRanges;
	hkArray<SimpleMapping> SimpleMappings;
	hkArray<ChainMapping> ChainMappings;
	hkArray<short> UnmappedBones;
	hkQsTransformf ExtractedMotionMapping;
	byte KeepUnmappedLocal;
	hkEnum<MappingType, int> Type;
}
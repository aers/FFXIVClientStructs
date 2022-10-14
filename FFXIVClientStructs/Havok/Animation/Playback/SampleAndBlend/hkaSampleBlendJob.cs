namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 16)]
public unsafe struct hkaSampleBlendJob
{
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SingleAnimation
	{
		enum ChunkNums
		{
			MaxAnimationChunks = 11,
			MaxChunks = 21
		}

		public enum SampleFlags
		{
			HasBoneWeights = (1 << 0),
			HasFloatWeights = (1 << 1),
			HasBoneBinding = (1 << 2),
			HasFloatBinding = (1 << 3),
			HasMapper = (1 << 4),
			BlendModeAdditive = (1 << 5),
			HasPartitions = (1 << 6),
			Deprecated = (1 << 7),
		};

		public uint FrameIndex;
		public float FrameDelta;
		public float Weight;
		public hkaAnimation.AnimationType Type;
		public fixed byte Chunks[(int)ChunkNums.MaxChunks * 16];
		public int NumChunks;
		public hkFlags<SampleFlags, int> Flags;
		public int NumBones;
		public int NumFloats;
		public hkQsTransformf* BonesOut;
		public float* FloatsOut;
		public hkaSkeleton.Partition* PartitionArray;
		public short NumPartitions;
	};

	public hkJob hkJob;
	public hkaAnimatedSkeleton* Skeleton;
	public hkQsTransformf* ReferenceBones;
	public float* ReferenceFloats;
	public hkaBone* Bones;
	public short* ParentIndices;
	public SingleAnimation* Animations;
	public hkQsTransformf* BonesOut;
	public float* FloatsOut;
	public hkaJobDoneNotifier JobDoneNotifier;
	public short NumBones;
	public short NumSkeletonBones;
	public int NumFloats;
	public int ChunkBufferSize;
	public float ReferencePoseWeightThreshold;
	public ushort NumAnimationsAllocated;
	public ushort NumAnims;
	public byte ConvertToModel;
	public byte SampleOnly;
	public byte UseSlerpForQuantized;
}
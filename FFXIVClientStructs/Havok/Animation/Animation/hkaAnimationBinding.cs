namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public unsafe struct hkaAnimationBinding
{
	public enum BlendHintEnum
	{
		Normal = 0x0,
		AdditiveDeprecated = 0x1,
		Additive = 0x2,
	}

	public struct DefaultStruct
	{
		public fixed int DefaultOffsets[6];
		public byte BlendHint;
	}
	
	public hkReferencedObject hkReferencedObject;
	public hkStringPtr OriginalSkeletonName;
	public hkRefPtr<hkaAnimation> Animation;
	public hkArray<short> TransformTrackToBoneIndices;
	public hkArray<short> FloatTrackToFloatSlotIndices;
	public hkArray<short> PartitionIndices;
	public hkEnum<BlendHintEnum, sbyte> BlendHint;
}
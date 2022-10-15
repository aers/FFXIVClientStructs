namespace FFXIVClientStructs.Havok;

public unsafe partial struct hkaDefaultAnimationControl
{
	public enum EaseStatusEnum
	{
		EasingIn,
		EasedIn,
		EasingOut,
		EasedOut,
	};

	public struct hkaDefaultAnimationControlListener
	{
		public void* vtbl;
	}

	public struct hkaDefaultAnimationControlMapperData
	{
		public hkReferencedObject hkReferencedObject;
		public hkaSkeletonMapper* Mapper;
		public hkArray<short> SrcBoneToTrackIndices;
		public hkArray<short> DstBoneToTrackIndices;
		public hkArray<short> DstTrackToBoneIndices;
	}

	public hkaAnimationControl hkaAnimationControl;
	public float MasterWeight;
	public float PlaybackSpeed;
	public uint OverflowCount;
	public uint UnderflowCount;
	public int MaxCycles;
	private uint pad;
	public hkVector4f EaseInCurve;
	public hkVector4f EaseOutCurve;
	public float EaseInvDuration;
	public float EaseT;
	public EaseStatusEnum EaseStatus;
	public float CropStartAmountLocalTime;
	public float CropEndAmountLocalTime;
	private uint pad2;
	public hkArray<hkaDefaultAnimationControlListener> DefaultListeners;
	public hkaDefaultAnimationControlMapperData* Mapper;

	[MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B DA 48 8B F9 48 8B 52 38")]
	public partial void Ctor1(hkaDefaultAnimationControl* other);
}
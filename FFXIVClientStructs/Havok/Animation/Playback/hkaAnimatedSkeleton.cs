namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 16)]
public unsafe partial struct hkaAnimatedSkeleton
{
	[StructLayout(LayoutKind.Sequential)]
	public struct BoneAnnotation
	{
		public ushort BoneID;
		public hkaAnnotationTrack.Annotation Annotation;
	};
	
	public hkReferencedObject hkReferencedObject;
	public hkaAnimationControlListener hkaAnimationControlListener;
	private nint Padding;
	public hkArray<Pointer<hkaDefaultAnimationControl>> AnimationControls;
	public hkaSkeleton* Skeleton;
	public float ReferencePoseWeightThreshold;
	public int NumQuantizedAnimations;

	[MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 8B C3 48 89 07 48 83 C7")]
	public partial hkaAnimatedSkeleton* Ctor1(hkaSkeleton* skeleton);

	[MemberFunction("48 89 5C 24 ?? 41 56 48 83 EC 20 48 8D 05")]
	public partial void Dtor();
	
	[MemberFunction("48 83 EC 38 48 89 5C 24 ?? 48 89 74 24")]
	public partial void stepDeltaTime(float time);

	[MemberFunction("48 83 EC 38 4D 8B C8 C6 44 24 ?? ?? 4C 8B 41 30")]
	public partial void sampleAndCombineAnimations(hkQsTransformf* poseLocalSpaceOut, float* floatSlotsOut);
	
	[MemberFunction("48 83 EC 38 8B 44 24 60 C6 44 24 ?? ?? 89 44 24 20 E8 ?? ?? ?? ?? 48 83 C4 38 C3 CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC 66 44 89 44 24")]
	public partial void sampleAndCombinePartialAnimations(hkQsTransformf* poseLocalSpaceOut, uint maxBones, float* floatSlotsOut, uint maxFloatSlots);

	[MemberFunction("66 44 89 44 24 ?? 48 83 EC 48 33 C0")]
	public partial void sampleAndCombineSingleBone(hkQsTransformf* localSpaceOut, short bone);

	[MemberFunction("66 44 89 44 24 ?? 48 83 EC 48 48 89 54 24")]
	public partial void sampleAndCombineSingleSlot(float* floatOut, short slot);

	[MemberFunction("48 83 EC 48 41 8B C1")]
	public partial void sampleAndCombineIndividualBones(hkQsTransformf* localSpaceOut, short* bones, uint numBones);

	[MemberFunction("48 83 EC 48 48 89 54 24 ?? 33 D2")]
	public partial void sampleAndCombineIndividualSlots(float* floatOut, short* slots, uint numSlots);

	// [MemberFunction("")]
	// public partial hkaSkeleton* getSkeleton();

	// [MemberFunction("")]
	// public partial float getReferencePoseWeightThreshold();

	// [MemberFunction("")]
	// public partial void setReferencePoseWeightThreshold(float val);

	[MemberFunction("48 8B C4 48 81 EC ?? ?? ?? ?? 48 89 58 10 49 8B D8")]
	public partial void getDeltaReferenceFrame(float deltaTimestep, hkQsTransformf* deltaMotionOut);

	[MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 8B 41 2C 48 8B DA")]
	public partial void addAnimationControl(hkaAnimationControl* animation);
	
	[MemberFunction("40 53 48 83 EC 20 48 63 41 28")]
	public partial void removeAnimationControl(hkaAnimationControl* animation);

	// [MemberFunction("")]
	// public partial int getNumAnimationControls();

	// [MemberFunction("")]
	// public partial hkaAnimationControl* getAnimationControl(int i);
		
	// [MemberFunction("")]
	// public partial uint getNumAnnotations(float deltaTime);

	// [MemberFunction("")]
	// public partial uint getAnnotations(float deltaTime, BoneAnnotation* annotationsOut, uint maxNumAnnotations) ;

	// [MemberFunction("")]
	// public partial bool hasOnlyQuantizedAnimations();

	// [MemberFunction("")]
	// public partial void controlDeletedCallback(hkaAnimationControl* control);

	[MemberFunction("48 89 5C 24 ?? 4C 89 4C 24 ?? 44 89 44 24 ?? 48 89 4C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 8D AC 24")]
	public partial void sampleAndCombineInternal(hkQsTransformf* poseLocalSpaceOut, uint maxBones, float* floatSlotsOut, uint maxFloatSlots, bool partial);
	
	[MemberFunction("48 8B C4 4C 89 48 20 4C 89 40 18 89 50 10 48 89 48 08 55 53 56 57 41 54")]
	public partial void sampleAndCombineIndividual(uint numBones, short* individualBones, hkQsTransformf* poseLocalSpaceOut, uint numFloatSlots, short* individualSlots, float* floatSlotsOut);
}
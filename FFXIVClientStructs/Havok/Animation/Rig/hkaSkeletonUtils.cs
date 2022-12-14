namespace FFXIVClientStructs.Havok;

public unsafe delegate int hkStringCompareFunc(char* a, char* b);

public unsafe partial struct hkaSkeletonUtils
{
	[MemberFunction("E8 ?? ?? ?? ?? 41 8B FF 85 DB")]
	public static partial void transformLocalPoseToModelPose(int numTransforms, short* parentIndices, hkQsTransformf* poseLocal, hkQsTransformf* poseModelOut);
	
	// [MemberFunction("")]
	// public static partial void transformLocalBoneToModelBone(int boneIndex, short* parentIndices, hkQsTransformf* poseLocal, hkQsTransformf* boneModelOut);
	
	[MemberFunction("48 83 EC 38 4C 89 4C 24 ?? 4D 8B C8 4C 8D 05 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 C4 38 C3 CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC 48 83 EC 18")]
	public static partial void transformModelPoseToLocalPose(int numTransforms, short* parentIndices, hkQsTransformf* poseModel, hkQsTransformf* poseLocalOut);
	
	// [MemberFunction("")]
	// public static partial void transformModelPoseToWorldPose(int numTransforms, hkQsTransformf* worldFromModel, hkQsTransformf* poseModel, hkQsTransformf* poseWorldOut);
	
	// [MemberFunction("")]
	// public static partial void transformWorldPoseToModelPose(int numTransforms, hkQsTransformf* worldFromModel, hkQsTransformf* poseWorld, hkQsTransformf* poseModelOut);
	
	[MemberFunction("40 57 48 83 EC 10 48 63 F9")]
	public static partial void transformLocalPoseToWorldPose(int numTransforms, short* parentIndices, hkQsTransformf* worldFromModel, hkQsTransformf* poseLocal, hkQsTransformf* poseWorldOut);
	
	[MemberFunction("85 C9 0F 8E ?? ?? ?? ?? 48 8B C4 55")]
	public static partial void transformWorldPoseToLocalPose(int numTransforms, short* parentIndices, hkQsTransformf* worldFromModel, hkQsTransformf* poseWorld, hkQsTransformf* poseLocalOut);
	
	// [MemberFunction("")]
	// public static partial void blendPoses(uint numBones, hkQsTransformf* poseA, hkQsTransformf* poseB, hkReal* weights, hkQsTransformf* poseOut);
	
	// [MemberFunction("")]
	// public static partial void blendPoses(uint numBones, hkQsTransformf* poseA, hkQsTransformf* poseB, hkReal weight, hkQsTransformf* poseOut);
	
	// [MemberFunction("")]
	// public static partial void blendPosesNoAlias(uint numBones, hkQsTransformf* poseA, hkQsTransformf* poseB, hkReal* weights, hkQsTransformf* poseOut);
	
	// [MemberFunction("")]
	// public static partial void blendPosesNoAlias(uint numBones, hkQsTransformf* poseA, hkQsTransformf* poseB, hkReal weight, hkQsTransformf* poseOut);
	
	// [MemberFunction("")]
	// public static partial void blendPartialPoses(uint numBones, short* bones, hkQsTransformf* poseA, hkQsTransformf* poseB, hkReal weight, hkQsTransformf* poseOut);
	
	// [MemberFunction("")]
	// public static partial void enforceSkeletonConstraintsLocalSpace(hkaSkeleton* skeleton, hkQsTransformf* poseLocalInOut);
	
	// [MemberFunction("")]
	// public static partial void enforceSkeletonConstraintsModelSpace(hkaSkeleton* skeleton, hkQsTransformf* poseModelInOut);
	
	// [MemberFunction("")]
	// public static partial void enforcePoseConstraintsLocalSpace(hkaSkeleton* skeleton, hkQsTransformf* constraintsLocal, hkQsTransformf* poseInOut);
	
	[MemberFunction("40 57 48 83 EC 10 48 63 79 30")]
	public static partial void enforcePoseConstraintsModelSpace(hkaSkeleton* skeleton, hkQsTransformf* constraintsLocal, hkQsTransformf* poseModelInOut);
	
	// [MemberFunction("")]
	// public static partial short findBoneWithName(hkaSkeleton* skeleton, char* name, hkStringCompareFunc compare);
	
	// [MemberFunction("")]
	// public static partial void lockTranslations(hkaSkeleton* skeleton, byte exceptRoots);
	
	// [MemberFunction("")]
	// public static partial void unlockTranslations(hkaSkeleton* skeleton);
	
	// [MemberFunction("")]
	// public static partial byte getBoneChain(hkaSkeleton* skeleton, short startBone, short endBone, hkArray<short>* bonesOut);
	
	// [MemberFunction("")]
	// public static partial byte getBoneChainWithinPartition(hkaSkeleton* skeleton, short startBone, short endBone, hkArray<short>* bonesOut);
	
	// [MemberFunction("")]
	// public static partial void getDescendants(hkaSkeleton* skeleton, short startBone, hkArray<short>* bonesOut, bool includeStart = false);
	
	[MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B 41 18 49 8B D8")]
	public static partial void getAncestors(hkaSkeleton* skeleton, short startPoint, hkArray<short>* bonesOut);
	
	[MemberFunction("48 89 7C 24 ?? 45 0F B6 D9")]
	public static partial void markDescendants(hkaSkeleton* skeleton, int startBone, bool* boolOut, bool includeStart);
	
	// [MemberFunction("")]
	// public static partial void getLeaves(hkaSkeleton* skeleton, hkArray<short>* leavesOut);
	
	// [MemberFunction("")]
	// public static partial byte isBindingOk(hkaSkeleton* skeleton, hkaAnimationBinding* binding);
	
	// [MemberFunction("")]
	// public static partial void getModelSpaceScale(hkaSkeleton* skeleton, hkQsTransformf* poseLocal, int boneId, hkVector4f* scaleOut);
	
	// [MemberFunction("")]
	// public static partial void normalizeRotations(hkQsTransformf* transformsInOut, int numTransforms);
	
	// [MemberFunction("")]
	// public static partial hkResult bindByName(hkaSkeleton* skeleton, hkaAnimation* anim, hkStringCompareFunc compare, hkaAnimationBinding* bindingOut);
	
	[MemberFunction("4C 8B DC 49 89 5B 10 49 89 6B 18 49 89 73 20 57 41 56 41 57 48 83 EC 40")]
	public static partial void calcAabb(uint numBones, hkQsTransformf* poseLocal, short* parentIndices, hkQsTransformf* worldFromModel, hkAabb* aabbOut);
	
	[MemberFunction("E8 ?? ?? ?? ?? 80 38 00 0F 84 ?? ?? ?? ?? 4C 8B 4B 08")]
	public static partial byte hasValidPartitions(hkaSkeleton* skeleton);
}
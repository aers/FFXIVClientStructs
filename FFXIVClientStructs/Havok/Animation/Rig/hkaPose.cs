namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct hkaPose
{
	public enum PoseSpace
	{
		ModelSpace = 0,
		LocalSpace = 1,
	}

	public enum PropagateOrNot
	{
		DontPropagate = 0,
		Propagate = 1,
	}

	public enum BoneFlag
	{
		BoneLocalDirty = 0,
		BoneModelDirty = 1,
	}
	
	public hkaSkeleton* Skeleton;
	public hkArray<hkQsTransformf> LocalPose;
	public hkArray<hkQsTransformf> ModelPose;
	public hkArray<uint> BoneFlags;
	public byte ModelInSync;
	public byte LocalInSync;
	public hkArray<float> FloatSlotValues;
	
	[MemberFunction("40 53 48 83 EC 20 4C 89 01 33 C0")]
	public partial void Ctor1(PoseSpace space, hkaSkeleton* skeleton, hkArray<hkQsTransformf>* pose);

	[MemberFunction("40 53 48 83 EC 30 4C 89 01")]
	public partial void Ctor2(PoseSpace space, hkaSkeleton* skeleton, hkQsTransformf* pose, int numBones);
	
	// [MemberFunction("")]
	// public partial hkaSkeleton* GetSkeleton();
	
	[MemberFunction("E8 ?? ?? ?? ?? 48 8B 4C 24 ?? 48 8B D0 E8 ?? ?? ?? ?? 48 83 C4 20")]
	public partial hkArray<hkQsTransformf>* GetSyncedPoseLocalSpace();
	
	[MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 43 18")]
	public partial hkArray<hkQsTransformf>* GetSyncedPoseModelSpace();
	
	// [MemberFunction("")]
	// public partial hkArray<float>* GetFloatSlotValues_const();
	
	[MemberFunction("48 8B 01 4C 8B C1 4C 63 48 30 48 8B 02 48 8B 51 08")]
	public partial void SetPoseLocalSpace(hkArray<hkQsTransformf>* poseLocal);
	
	[MemberFunction("48 8B 01 4C 8B C1 4C 63 48 30 48 8B 02 48 8B 51 18")]
	public partial void SetPoseModelSpace(hkArray<hkQsTransformf>* poseModel);
	
	// [MemberFunction("")]
	// public partial void SetFloatSlotValues(hkArray<float>* floatSlotValues);
	
	// [MemberFunction("")]
	// public partial hkQsTransformf* GetBoneLocalSpace(int boneIdx);
	
	// [MemberFunction("")]
	// public partial hkQsTransformf* GetBoneModelSpace(int boneIdx);
	
	// [MemberFunction("")]
	// public partial float GetFloatSlotValue(int floatSlotIdx);
	
	// [MemberFunction("")]
	// public partial void SetBoneLocalSpace(int boneIdx, hkQsTransformf* boneLocal);
	
	// [MemberFunction("")]
	// public partial void SetBoneModelSpace(int boneIdx, hkQsTransformf* boneModel, PropagateOrNot propagateOrNot);
	
	// [MemberFunction("")]
	// public partial void SetFloatSlotValue(int floatSlotIdx, float value);
	
	[MemberFunction("4C 8B DC 53 48 81 EC ?? ?? ?? ?? 80 79 39 00")]
	public partial void SyncLocalSpace();
	
	[MemberFunction("48 83 EC 18 80 79 38 00")]
	public partial void SyncModelSpace();
	
	[MemberFunction("4C 8B DC 53 55 56 57 41 54 41 56 48 81 EC")]
	public partial hkQsTransformf* AccessBoneLocalSpace(int boneIdx);
	
	[MemberFunction("48 8B C4 89 50 10 53 57")]
	public partial hkQsTransformf* AccessBoneModelSpace(int boneIdx, PropagateOrNot propagateOrNot);
	
	[MemberFunction("E8 ?? ?? ?? ?? 4D 8B 4E 40")]
	public partial hkArray<hkQsTransformf>* AccessSyncedPoseLocalSpace();
	
	[MemberFunction("E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 8B 58 08")]
	public partial hkArray<hkQsTransformf>* AccessSyncedPoseModelSpace();
	
	[MemberFunction("E8 ?? ?? ?? ?? EB 05 E8 ?? ?? ?? ?? 4D 8B 4E 40")]
	public partial hkArray<hkQsTransformf>* AccessUnsyncedPoseLocalSpace();
	
	// [MemberFunction("")]
	// public partial hkArray<float>* GetFloatSlotValues();
	
	[MemberFunction("48 8B 01 4C 8B C9")]
	public partial void SetToReferencePose();
	
	[MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B 01 48 8B D9 48 63 78 30")]
	public partial void EnforceSkeletonConstraintsLocalSpace();
	
	[MemberFunction("40 53 48 83 EC 30 48 8B 01 48 8B D9 48 89 74 24")]
	public partial void EnforceSkeletonConstraintsModelSpace();
	
	[MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 0F 28 05")]
	public partial void GetModelSpaceAabb(hkAabb* aabbOut);
	
	[MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 57 41 56 48 83 EC 30 48 8B 01 49 8B E9")]
	public partial void Init(PoseSpace space, hkaSkeleton* skeleton, hkArray<hkQsTransformf>* pose);

	[MemberFunction("E8 ?? ?? ?? ?? 0F 28 48 10")]
	public partial hkQsTransformf* CalculateBoneModelSpace(int boneIdx);
	
	[MemberFunction("48 89 5C 24 ?? 48 8B 01 45 33 C0")]
	public partial byte CheckPoseValidity();

	[MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 48 8B 01 33 FF")]
	public partial byte CheckPoseTransformsValidity();
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct hkQsTransformf
{
	public hkVector4f Translation;
	public hkQuaternionf Rotation;
	public hkVector4f Scale;

	// [MemberFunction("")]
	// public partial void setFromTransformNoScale(hkTransformf* transform);

	// [MemberFunction("")]
	// public partial void copyToTransformNoScale(hkTransformf* transformOut);

	// [MemberFunction("")]
	// public partial void setFromTransform(hkTransformf* transform);

	// [MemberFunction("")]
	// public partial void setFromTransform(hkQTransformf* qt);

	// [MemberFunction("")]
	// public partial void copyToTransform(hkTransformf* transformOut);

	[MemberFunction("E8 ?? ?? ?? ?? 0F 28 5D F0 44 0F 28 55")]
	public partial void get4x4ColumnMajor(float* p);

	[MemberFunction("E9 ?? ?? ?? ?? CC CC CC CC CC CC CC CC CC CC CC 0F 28 02")]
	public partial bool set4x4ColumnMajor(float* p);

	[MemberFunction("40 53 48 81 EC ?? ?? ?? ?? 48 8B C2 48 8B D9 48 8B C8 48 8D 54 24 ?? E8 ?? ?? ?? ?? 0F 28 44 24 ?? 33 C0 38 84 24 ?? ?? ?? ?? 0F 28 4C 24 ?? 0F 29 03 0F 94 C0 0F 28 44 24 ?? 0F 29 43 20 0F 29 4B 10 48 81 C4 ?? ?? ?? ?? 5B C3 CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC 48 83 EC 48")]
	public partial bool set(hkMatrix4f* m);

	[MemberFunction("48 83 EC 48 0F 29 74 24 ?? 0F 28 31")]
	public partial bool isOk(float epsilon);

	// [MemberFunction("")]
	// bool isApproximatelyEqual(hkQsTransformf* other, float epsilon);

	[MemberFunction("45 85 C0 74 4B 48 8B C1")]
	public static partial void fastRenormalizeBatch1(hkQsTransformf* poseOut, float* weight, uint numTransforms);
	
	[MemberFunction("F3 0F 11 4C 24 ?? 48 83 EC 28 F3 0F 10 44 24")]
	public static partial void fastRenormalizeBatch2(hkQsTransformf* poseOut, float weight, uint numTransforms);
	
	[MemberFunction("48 83 EC 28 8B C2 C1 E8 02")]
	public static partial void fastRenormalizeQuaternionBatch(hkQsTransformf* poseOut, uint numTransforms);
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 16)]
public struct hkJob
{
	public enum hkJobType
	{
		Dynamics,
		Collide,
		CollisionQuery,
		RayCastQuery,
		AnimationSampleAndCombine,
		AnimationSampleAndBlend,
		AnimationMapping,
		Behavior,
		Cloth,
		Destruction,
		UnitTest,
		CharacterProxy,
		Vehicle,

		CollideStaticCompound,

		HavokMax,
		User0 = HavokMax,
		//HK_JOB_TYPE_USER_1,
		Max
	};
	
	public enum hkJobSpuType
	{
		Invalid,
		Enabled,
		Disabled,
	};
	
	public byte JobSubType;
	public hkEnum<hkJobType, byte> JobType;
	public hkEnum<hkJobSpuType, byte> SpuType;
	public ushort Size;
	public short ThreadAffinity;
}
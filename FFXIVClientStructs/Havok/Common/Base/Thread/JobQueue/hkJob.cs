using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Common.Base.Thread.JobQueue;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public partial struct hkJob {
    public enum hkJobType {
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
    }

    public enum hkJobSpuType {
        Invalid,
        Enabled,
        Disabled,
    }

    [FieldOffset(0x00)] public byte JobSubType;
    [FieldOffset(0x01)] public hkEnum<hkJobType, byte> JobType;
    [FieldOffset(0x02)] public hkEnum<hkJobSpuType, byte> SpuType;
    [FieldOffset(0x04)] public ushort Size;
    [FieldOffset(0x06)] public short ThreadAffinity;
}

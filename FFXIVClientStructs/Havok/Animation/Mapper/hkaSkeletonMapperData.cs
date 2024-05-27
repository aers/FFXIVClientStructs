using FFXIVClientStructs.Havok.Animation.Rig;
using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Math.QsTransform;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Animation.Mapper;

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public struct hkaSkeletonMapperData {
    public enum MappingType {
        Ragdoll = 0x0,
        Retargeting = 0x1,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x34)]
    public struct SimpleMapping {
        [FieldOffset(0x00)] public short BoneA;
        [FieldOffset(0x02)] public short BoneB;
        [FieldOffset(0x04)] public hkQsTransformf AFromBTransform;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct PartitionMappingRange {
        [FieldOffset(0x00)] public int StartMappingIndex;
        [FieldOffset(0x04)] public int NumMappings;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct ChainMapping {
        [FieldOffset(0x00)] public short StartBoneA;
        [FieldOffset(0x02)] public short EndBoneA;
        [FieldOffset(0x04)] public short StartBoneB;
        [FieldOffset(0x06)] public short EndBoneB;
        [FieldOffset(0x08)] public hkQsTransformf StartAFromBTransform;
        [FieldOffset(0x38)] public hkQsTransformf EndAFromBTransform;
    }

    [FieldOffset(0x00)] public hkRefPtr<hkaSkeleton> SkeletonA;
    [FieldOffset(0x08)] public hkRefPtr<hkaSkeleton> SkeletonB;
    [FieldOffset(0x10)] public hkArray<short> PartitionMap;
    [FieldOffset(0x20)] public hkArray<PartitionMappingRange> SimpleMappingPartitionRanges;
    [FieldOffset(0x30)] public hkArray<PartitionMappingRange> ChainMappingPartitionRanges;
    [FieldOffset(0x40)] public hkArray<SimpleMapping> SimpleMappings;
    [FieldOffset(0x50)] public hkArray<ChainMapping> ChainMappings;
    [FieldOffset(0x60)] public hkArray<short> UnmappedBones;
    [FieldOffset(0x70)] public hkQsTransformf ExtractedMotionMapping;
    [FieldOffset(0xA0)] public byte KeepUnmappedLocal;
    [FieldOffset(0xA4)] public hkEnum<MappingType, int> Type;
}

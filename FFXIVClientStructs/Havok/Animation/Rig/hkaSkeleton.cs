using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Container.String;
using FFXIVClientStructs.Havok.Common.Base.Math.QsTransform;
using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Types;
using FFXIVClientStructs.Havok.Common.Base.Types.Geometry.LocalFrame;

namespace FFXIVClientStructs.Havok.Animation.Rig;

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public struct hkaSkeleton {
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct LocalFrameOnBone {
        [FieldOffset(0x00)] public hkRefPtr<hkLocalFrame> LocalFrame;
        [FieldOffset(0x08)] public short BoneIndex;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Partition {
        [FieldOffset(0x00)] public hkStringPtr Name;
        [FieldOffset(0x08)] public short StartBoneIndex;
        [FieldOffset(0x0A)] public short NumBones;
    }

    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public hkStringPtr Name;
    [FieldOffset(0x18)] public hkArray<short> ParentIndices;
    [FieldOffset(0x28)] public hkArray<hkaBone> Bones;
    [FieldOffset(0x38)] public hkArray<hkQsTransformf> ReferencePose;
    [FieldOffset(0x48)] public hkArray<float> ReferenceFloats;
    [FieldOffset(0x58)] public hkArray<hkStringPtr> FloatSlots;
    [FieldOffset(0x68)] public hkArray<LocalFrameOnBone> LocalFrames;
    [FieldOffset(0x78)] public hkArray<Partition> Partitions;

    // [MemberFunction("")]
    // public partial hkLocalFrame* GetLocalFrameForBone(int boneIndex);

    // [MemberFunction("")] 
    // public partial short GetPartitionIndexFromName(char* partitionName);

    // [MemberFunction("")]
    // public partial short GetPartitionIndexForBone(short boneIndex);
}

using FFXIVClientStructs.Havok.Animation.Animation;
using FFXIVClientStructs.Havok.Animation.Playback.Multithreaded;
using FFXIVClientStructs.Havok.Animation.Rig;
using FFXIVClientStructs.Havok.Common.Base.Math.QsTransform;
using FFXIVClientStructs.Havok.Common.Base.Thread.JobQueue;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Animation.Playback.SampleAndBlend;

[GenerateInterop]
[Inherits<hkJob>]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct hkaSampleBlendJob {
    [StructLayout(LayoutKind.Explicit, Size = 0x190)]
    public struct SingleAnimation {
        public enum ChunkNums {
            MaxAnimationChunks = 11,
            MaxChunks = 21
        }

        public enum SampleFlags {
            HasBoneWeights = 1 << 0,
            HasFloatWeights = 1 << 1,
            HasBoneBinding = 1 << 2,
            HasFloatBinding = 1 << 3,
            HasMapper = 1 << 4,
            BlendModeAdditive = 1 << 5,
            HasPartitions = 1 << 6,
            Deprecated = 1 << 7,
        }

        [FieldOffset(0x00)] public uint FrameIndex;
        [FieldOffset(0x04)] public float FrameDelta;
        [FieldOffset(0x08)] public float Weight;
        [FieldOffset(0x0C)] public hkaAnimation.AnimationType Type;
        [FieldOffset(0x10)] public fixed byte Chunks[(int)ChunkNums.MaxChunks * 16];
        [FieldOffset(0x160)] public int NumChunks;
        [FieldOffset(0x164)] public hkFlags<SampleFlags, int> Flags;
        [FieldOffset(0x168)] public int NumBones;
        [FieldOffset(0x16C)] public int NumFloats;
        [FieldOffset(0x170)] public hkQsTransformf* BonesOut;
        [FieldOffset(0x178)] public float* FloatsOut;
        [FieldOffset(0x180)] public hkaSkeleton.Partition* PartitionArray;
        [FieldOffset(0x188)] public short NumPartitions;
    }

    [FieldOffset(0x08)] public hkaAnimatedSkeleton* Skeleton;
    [FieldOffset(0x10)] public hkQsTransformf* ReferenceBones;
    [FieldOffset(0x18)] public float* ReferenceFloats;
    [FieldOffset(0x20)] public hkaBone* Bones;
    [FieldOffset(0x28)] public short* ParentIndices;
    [FieldOffset(0x30)] public SingleAnimation* Animations;
    [FieldOffset(0x38)] public hkQsTransformf* BonesOut;
    [FieldOffset(0x40)] public float* FloatsOut;
    [FieldOffset(0x48)] public hkaJobDoneNotifier JobDoneNotifier;
    [FieldOffset(0x58)] public short NumBones;
    [FieldOffset(0x5A)] public short NumSkeletonBones;
    [FieldOffset(0x5C)] public int NumFloats;
    [FieldOffset(0x60)] public int ChunkBufferSize;
    [FieldOffset(0x64)] public float ReferencePoseWeightThreshold;
    [FieldOffset(0x68)] public ushort NumAnimationsAllocated;
    [FieldOffset(0x6A)] public ushort NumAnims;
    [FieldOffset(0x6C)] public byte ConvertToModel;
    [FieldOffset(0x6D)] public byte SampleOnly;
    [FieldOffset(0x6E)] public byte UseSlerpForQuantized;
}

using FFXIVClientStructs.Havok.Animation.Motion;
using FFXIVClientStructs.Havok.Common.Base.Container.Array;
using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Animation.Animation;

[GenerateInterop, Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public partial struct hkaAnimation {
    public enum AnimationType {
        UnknownAnimation = 0x0,
        InterleavedAnimation = 0x1,
        MirroredAnimation = 0x2,
        SplineCompressedAnimation = 0x3,
        QuantizedCompressedAnimation = 0x4,
        PredictiveCompressedAnimation = 0x5,
        ReferencePoseAnimation = 0x6,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct DataChunk {
        [FieldOffset(0x00)] public byte* Data;
        [FieldOffset(0x08)] public uint Size;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct TrackAnnotation {
        [FieldOffset(0x00)] public ushort TrackId;
        [FieldOffset(0x08)] public hkaAnnotationTrack.Annotation Annotation;
    }

    [FieldOffset(0x10)] public AnimationType Type;
    [FieldOffset(0x14)] public float Duration;
    [FieldOffset(0x18)] public int NumberOfTransformTracks;
    [FieldOffset(0x1C)] public int NumberOfFloatTracks;
    [FieldOffset(0x20)] public hkRefPtr<hkaAnimatedReferenceFrame> ExtractedMotion;
    [FieldOffset(0x28)] public hkArray<hkaAnnotationTrack> AnnotationTracks;
}

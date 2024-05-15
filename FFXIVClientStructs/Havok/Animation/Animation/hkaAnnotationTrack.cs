namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct hkaAnnotationTrack {
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Annotation {
        [FieldOffset(0x00)] public float Time;
        [FieldOffset(0x08)] public hkStringPtr Text;
    }

    [FieldOffset(0x00)] public hkStringPtr TrackName;
    [FieldOffset(0x08)] public hkArray<Annotation> Annotations;
}

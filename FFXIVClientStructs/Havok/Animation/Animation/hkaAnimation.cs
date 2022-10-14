namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkaAnimation
{
	public enum AnimationType : int
	{
		UnknownAnimation = 0x0,
		InterleavedAnimation = 0x1,
		MirroredAnimation = 0x2,
		SplineCompressedAnimation = 0x3,
		QuantizedCompressedAnimation = 0x4,
		PredictiveCompressedAnimation = 0x5,
		ReferencePoseAnimation = 0x6,
	}
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public unsafe struct DataChunk
	{
		public byte* Data;
		public uint Size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct TrackAnnotation
	{
		public ushort TrackId;
		public hkaAnnotationTrack.Annotation Annotation;
	}

	public hkReferencedObject hkReferencedObject;
	public AnimationType Type;
	public float Duration;
	public int NumberOfTransformTracks;
	public int NumberOfFloatTracks;
	public hkRefPtr<hkaAnimatedReferenceFrame> ExtractedMotion;
	public hkArray<hkaAnnotationTrack> AnnotationTracks;
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkaAnnotationTrack
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Annotation
	{
		public float Time;
		public hkStringPtr Text;
	}
	
	public hkStringPtr TrackName;
	public hkArray<Annotation> Annotations;
}
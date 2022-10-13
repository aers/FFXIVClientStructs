namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkaAnimatedReferenceFrame
{
	public enum hkaReferenceFrameTypeEnum : int
	{
		Unknown = 0,
		Default = 1,
		Parametric = 2,
	}
	
	public hkReferencedObject hkReferencedObject;
	public hkaReferenceFrameTypeEnum FrameType;
}
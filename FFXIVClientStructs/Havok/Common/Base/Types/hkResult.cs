namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkResult
{
	public enum hkResultEnum : int
	{
		Success = 0,
		Failure = 1,
	}
	
	public hkResultEnum Result;
}
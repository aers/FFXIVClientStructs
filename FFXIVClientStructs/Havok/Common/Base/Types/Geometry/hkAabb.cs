namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct hkAabb
{
	public hkVector4f Min;
	public hkVector4f Max;
}
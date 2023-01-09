namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct hkStringPtr
{
	public byte* StringAndFlag;
	
	public string? String => Marshal.PtrToStringUTF8((IntPtr)((ulong) StringAndFlag & ~1LU));
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct hkRefPtr<T> where T : unmanaged
{
	public T* ptr;
}
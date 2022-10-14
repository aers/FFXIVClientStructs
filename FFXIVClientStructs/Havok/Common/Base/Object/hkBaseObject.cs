namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct hkBaseObject
{
	public hkBaseObjectVtbl *vfptr;
	
	public unsafe struct hkBaseObjectVtbl
	{
		public void* dtor;
		public void* __first_virtual_table_function__;
	}
}
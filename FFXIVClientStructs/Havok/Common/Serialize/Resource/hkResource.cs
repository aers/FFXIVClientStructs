namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct hkResource
{
	[VirtualFunction(7)]
	[GenerateCStrOverloads]
	public partial void* GetContentsPointer(byte* className, hkTypeInfoRegistry* typeInfoRegistry);
}
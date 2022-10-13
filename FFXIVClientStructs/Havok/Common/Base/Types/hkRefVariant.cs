namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct hkRefVariant
{
	public hkRefPtr<hkReferencedObject> hkRefPtr;

	[MemberFunction("E8 ?? ?? ?? ?? 49 8D 4E 10 E8 ?? ?? ?? ?? 48 85 C0")]
	public partial void set(void* o, hkClass* k);
	
	[MemberFunction("48 8B 11 48 85 D2 74 0E")]
	public partial hkClass* getClass();
}
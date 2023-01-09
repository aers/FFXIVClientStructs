namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct hkLoader
{
	public hkReferencedObject hkReferencedObject;
	public hkArray<Pointer<hkResource>> LoadedData;

	// [MemberFunction("")]
	// public partial hkRootLevelContainer* load(byte* filename );
	
	[MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 48 8B DA 48 8B 0D ?? ?? ?? ?? 48 8B 01 FF 50 20 4C 8B 0F 48 8B D3 4C 8B C0 48 8B CF 48 8B 5C 24 ?? 48 83 C4 20 5F 49 FF 61 40")]
	public partial hkRootLevelContainer* load(hkStreamReader* reader);
	
	// [MemberFunction("")]
	// public partial hkRootLevelContainer* load(byte* filename, hkTypeInfoRegistry* finish);
	
	// [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 48 8B DA 48 8B 0D ?? ?? ?? ?? 48 8B 01 FF 50 20 4C 8B 0F 48 8B D3 4C 8B C0 48 8B CF 48 8B 5C 24 ?? 48 83 C4 20 5F 49 FF 61 40")]
	// public partial hkRootLevelContainer* load(hkStreamReader* reader, hkTypeInfoRegistry* finish);
	
	// [MemberFunction("")]
	// public partial void* load(byte* filename, hkClass* expectedTopLevelClass);
		
	// [MemberFunction("")]
	// public partial void* load(hkStreamReader* reader, hkClass* expectedTopLevelClass);
	
	// [MemberFunction("")]
	// public partial void* load(byte* filename, hkClass* expectedTopLevelClass, hkTypeInfoRegistry* finish);
	
	// [MemberFunction("")]
	// public partial void* load(hkStreamReader* reader, hkClass* expectedTopLevelClass, hkTypeInfoRegistry* finish);
}
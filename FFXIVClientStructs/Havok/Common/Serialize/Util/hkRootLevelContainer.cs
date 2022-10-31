namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct hkRootLevelContainer
{
	public struct NamedVariant
	{
		public hkStringPtr Name;
		public hkStringPtr ClassName;
		public hkRefPtr<hkReferencedObject> Variant;
	};
	
	public hkArray<NamedVariant> NamedVariants;
	
	[MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC 20 33 DB 48 8B EA")]
	public partial void* findObjectByType(char* typeName, void* prevObject);
	
	[MemberFunction("E8 ?? ?? ?? ?? 44 8B 45 1B")]
	public partial void* findObjectByName(char* objectName, void* prevObject);
}
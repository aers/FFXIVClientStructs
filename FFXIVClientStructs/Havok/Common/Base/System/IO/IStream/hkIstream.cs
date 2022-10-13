namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct hkIstream
{
	public hkReferencedObject hkReferencedObject;
	public hkRefPtr<hkStreamReader> StreamReader;

	[MemberFunction("E8 ?? ?? ?? ?? 33 FF 41 39 7C 24")]
	public partial void Ctor1(hkStreamReader* sr);

	[MemberFunction("E8 ?? ?? ?? ?? 4C 8B C3 48 8B D7 48 8B 48 10")]
	public partial void Ctor2(byte* filename);

	[MemberFunction("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 4C 8B CF")]
	public partial void Ctor3(void* mem, int memSize);

	// [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 C7 41 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B D9 33 FF 48 8B F2 48 89 79 10 8B 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 8D 57 28 48 8B 48 58 48 8B 01 FF 50 08 48 85 C0 74 15")]
	// public partial void Ctor4(hkMemoryTrack* track );

	[MemberFunction("E8 ?? ?? ?? ?? EB 3D 48 85 FF")]
	public partial void Dtor();

	[MemberFunction("E8 ?? ?? ?? ?? 80 38 00 74 19")]
	public partial byte isOk();
	
	[MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 54 41 56 41 57 48 83 EC 20 48 8B E9")]
	public partial int getline(char* str, int maxsize, char delim = '\n');

	// [MemberFunction("")]
	// public partial hkIstream* get(char& c);

	// [MemberFunction("")]
	// public partial int read(void* buf, int nbytes);

	// [MemberFunction("")]
	// hkStreamReader* getStreamReader();
}
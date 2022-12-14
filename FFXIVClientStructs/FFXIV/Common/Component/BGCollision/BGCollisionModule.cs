using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision; 

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct BGCollisionModule {

	[MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 0F B6 D6")] // ex to avoid generated name collision
	public partial bool RaycastEx(RaycastHit* hitInfo, Vector3 origin, Vector3 direction, float maxDistance, int layerMask, int* flags);

	[MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 F0 84 C0 74 ?? 40 38 BD")]
	public static partial bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, RaycastHit* hitInfo, int *flags);

	[MemberFunction("48 83 EC 48 48 8B 05 ?? ?? ?? ?? 4D 8B D1")]
	public static partial bool Raycast2(Vector3 origin, Vector3 direction, float maxDistance, RaycastHit* hitInfo, int *flags);

	public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance = 1000000f) {
		var flags = stackalloc int[] { 0x4000, 0, 0x4000 , 0};
		var hit = stackalloc RaycastHit[1];
		var result = Raycast(origin, direction, maxDistance, hit, flags);
		hitInfo = *hit;
		return result;
	}

	public static bool Raycast2(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance = 1000000f) {
		var flags = stackalloc int[] { 0x4000, 0, 0x4000 , 0};
		var hit = stackalloc RaycastHit[1];
		var result = Raycast2(origin, direction, maxDistance, hit, flags);
		hitInfo = *hit;
		return result;
	}
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct RaycastHit {
	[FieldOffset(0x00)] public Vector3 Point;

	// the triangle that got hit
	[FieldOffset(0x0C)] public Vector3 V1;
	[FieldOffset(0x18)] public Vector3 V2;
	[FieldOffset(0x24)] public Vector3 V3;

	[FieldOffset(0x30)] public Vector3 Unk30;
	[FieldOffset(0x3C)] public int Flags; // layers i guess?
	[FieldOffset(0x40)] public int Unk40;
	[FieldOffset(0x44)] public float Distance;
	[FieldOffset(0x48)] public Object* Object;
}
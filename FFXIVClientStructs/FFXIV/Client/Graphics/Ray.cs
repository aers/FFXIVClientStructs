namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct Ray {
	[FieldOffset(0x00)] public Vec3 Origin;
	[FieldOffset(0x10)] public Vec3 Direction;

	public Ray(Vec3 origin, Vec3 direction) {
		Origin = origin;
		Direction = direction;
	}

	public Vec3 GetPoint(float distance) => Origin + Direction * distance;
}
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct Ray {
	[FieldOffset(0x00)] public Vector3 Origin;
	[FieldOffset(0x10)] public Vector3 Direction;

	public Ray(Vector3 origin, Vector3 direction) {
		Origin = origin;
		Direction = direction;
	}

	public Vector3 GetPoint(float distance) => Origin + Direction * distance;
}
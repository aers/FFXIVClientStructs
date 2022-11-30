using NumVector3 = System.Numerics.Vector3;

namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct Ray {
	[FieldOffset(0x00)] public NumVector3 Origin;
	[FieldOffset(0x10)] public NumVector3 Direction;

	public Ray(NumVector3 origin, NumVector3 direction) {
		Origin = origin;
		Direction = direction;
	}

	public NumVector3 GetPoint(float distance) => Origin + Direction * distance;
}
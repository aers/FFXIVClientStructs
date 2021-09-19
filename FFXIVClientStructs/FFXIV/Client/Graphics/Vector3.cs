using System.Runtime.InteropServices;
using NumVector3 = System.Numerics.Vector3;

namespace FFXIVClientStructs.FFXIV.Client.Graphics
{
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Vector3
    {
        [FieldOffset(0x0)] public float X;
        [FieldOffset(0x4)] public float Y;
        [FieldOffset(0x8)] public float Z;
        [FieldOffset(0xC)] private readonly uint _padC;
		
		public static implicit operator NumVector3(Vector3 vector) {
			return new NumVector3(vector.X, vector.Y, vector.Z);
		}
    }
}

using System.Runtime.InteropServices;
using NumQuaternion = System.Numerics.Quaternion;

namespace FFXIVClientStructs.FFXIV.Client.Graphics
{
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Quarternion
    {
        [FieldOffset(0x0)] public float X;
        [FieldOffset(0x4)] public float Y;
        [FieldOffset(0x8)] public float Z;
        [FieldOffset(0xC)] public float W;

        public static implicit operator NumQuaternion(Quarternion quat) {
            return new NumQuaternion(quat.X, quat.Y, quat.Z, quat.W);
        }
    }
}

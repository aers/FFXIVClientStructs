using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Graphics
{
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Vector3
    {
        [FieldOffset(0x0)] public float X;
        [FieldOffset(0x4)] public float Y;
        [FieldOffset(0x8)] public float Z;
        [FieldOffset(0xC)] private readonly uint _padC;
    }
}
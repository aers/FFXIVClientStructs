using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Graphics
{
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct Transform
    {
        [FieldOffset(0x0)] public Vector3 Position;
        [FieldOffset(0x10)] public Quarternion Rotation;
        [FieldOffset(0x20)] public Vector3 Scale;
    }
}
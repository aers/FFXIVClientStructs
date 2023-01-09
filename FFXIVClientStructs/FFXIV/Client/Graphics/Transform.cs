using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct Transform
{
    [FieldOffset(0x00)] public Vector3 Position;
    [FieldOffset(0x10)] public Quaternion Rotation;
    [FieldOffset(0x20)] public Vector3 Scale;
}
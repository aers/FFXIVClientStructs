namespace FFXIVClientStructs.FFXIV.Client.Graphics;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct Transform
{
    [FieldOffset(0x00)] public Vec3 Position;
    [FieldOffset(0x10)] public Quat Rotation;
    [FieldOffset(0x20)] public Vec3 Scale;
}
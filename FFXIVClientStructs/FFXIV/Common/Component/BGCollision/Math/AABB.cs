using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Common.Component.BGCollision.Math;

// 3D axis-aligned bounding box
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct AABB {
    [FieldOffset(0x00)] public Vector3 Min;
    [FieldOffset(0x0C)] public Vector3 Max;
}

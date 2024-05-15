using FFXIVClientStructs.Havok.Common.Base.Math.Vector;

namespace FFXIVClientStructs.Havok.Common.Base.Types.Geometry;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct hkAabb {
    [FieldOffset(0x00)] public hkVector4f Min;
    [FieldOffset(0x10)] public hkVector4f Max;
}

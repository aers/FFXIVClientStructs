using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Common.Base.Types.Geometry.LocalFrame;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct hkLocalFrame {
    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
}

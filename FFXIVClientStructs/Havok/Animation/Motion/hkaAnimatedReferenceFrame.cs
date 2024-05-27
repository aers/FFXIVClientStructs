using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Animation.Motion;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct hkaAnimatedReferenceFrame {
    public enum hkaReferenceFrameTypeEnum {
        Unknown = 0,
        Default = 1,
        Parametric = 2,
    }

    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public hkaReferenceFrameTypeEnum FrameType;
}

using FFXIVClientStructs.Havok.Common.Base.Object;

namespace FFXIVClientStructs.Havok.Animation.Motion;

[GenerateInterop]
[Inherits<hkReferencedObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct hkaAnimatedReferenceFrame {
    public enum hkaReferenceFrameTypeEnum {
        Unknown = 0,
        Default = 1,
        Parametric = 2,
    }

    [FieldOffset(0x10)] public hkaReferenceFrameTypeEnum FrameType;
}

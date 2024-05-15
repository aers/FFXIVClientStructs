using FFXIVClientStructs.Havok.Common.Base.Container.String;
using FFXIVClientStructs.Havok.Common.Base.Math.Matrix;
using FFXIVClientStructs.Havok.Common.Base.Object;
using FFXIVClientStructs.Havok.Common.Base.Types;

namespace FFXIVClientStructs.Havok.Animation.Rig;

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public struct hkaBoneAttachment {
    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public hkStringPtr OriginalSkeletonName;
    [FieldOffset(0x18)] public hkMatrix4f BoneFromAttachment;
    [FieldOffset(0x58)] public hkRefVariant Attachment;
    [FieldOffset(0x60)] public hkStringPtr Name;
    [FieldOffset(0x68)] public short BoneIndex;
}

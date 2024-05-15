namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public struct hkaBoneAttachment {
    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public hkStringPtr OriginalSkeletonName;
    [FieldOffset(0x18)] public hkMatrix4f BoneFromAttachment;
    [FieldOffset(0x58)] public hkRefVariant Attachment;
    [FieldOffset(0x60)] public hkStringPtr Name;
    [FieldOffset(0x68)] public short BoneIndex;
}

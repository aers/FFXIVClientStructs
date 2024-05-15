namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public struct hkaAnimationContainer {
    [FieldOffset(0x00)] public hkReferencedObject hkReferencedObject;
    [FieldOffset(0x10)] public hkArray<hkRefPtr<hkaSkeleton>> Skeletons;
    [FieldOffset(0x20)] public hkArray<hkRefPtr<hkaAnimation>> Animations;
    [FieldOffset(0x30)] public hkArray<hkRefPtr<hkaAnimationBinding>> Bindings;
    [FieldOffset(0x40)] public hkArray<hkRefPtr<hkaBoneAttachment>> Attachments;
    [FieldOffset(0x50)] public hkArray<hkRefPtr<hkaMeshBinding>> Skins;

    // hkaSkeleton* findSkeletonByName(byte* name);
    // hkaBoneAttachment* findBoneAttachmentByName(byte* name);
}

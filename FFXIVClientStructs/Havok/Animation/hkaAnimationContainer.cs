namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct hkaAnimationContainer
{
	public hkReferencedObject hkReferencedObject;
	public hkArray<hkRefPtr<hkaSkeleton>> Skeletons;
	public hkArray<hkRefPtr<hkaAnimation>> Animations;
	public hkArray<hkRefPtr<hkaAnimationBinding>> Bindings;
	hkArray<hkRefPtr<hkaBoneAttachment>> Attachments;
	hkArray<hkRefPtr<hkaMeshBinding>> Skins;
	
	// hkaSkeleton* findSkeletonByName(byte* name);
	// hkaBoneAttachment* findBoneAttachmentByName(byte* name);
}
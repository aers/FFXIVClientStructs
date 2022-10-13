namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 16)]
public unsafe partial struct hkaBoneAttachment
{
	public hkReferencedObject hkReferencedObject;
	public hkStringPtr OriginalSkeletonName;
	public hkMatrix4f BoneFromAttachment;
	public hkRefVariant Attachment;
	public hkStringPtr Name;
	public short BoneIndex;
	
	
}
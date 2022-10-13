namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkaMeshBinding
{
	public struct Mapping
	{
		public hkArray<short> _Mapping;
	}
	
	public hkReferencedObject hkReferencedObject;
	hkRefPtr<hkxMesh> Mesh;
	hkStringPtr OriginalSkeletonName;
	hkStringPtr Name;
	hkRefPtr<hkaSkeleton> Skeleton;
	hkArray<Mapping> Mappings;
	hkArray<hkTransformf> BoneFromSkinMeshTransforms;
}
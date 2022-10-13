namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct hkReferencedObject
{
	public hkBaseObject hkBaseObject;
	public uint MemSizeAndRefCount;
	// private uint Padding;
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct hkaBone
{
	public hkStringPtr Name;
	public byte LockTranslation;
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkTransformf
{
	public hkRotationf Rotation;
	public hkVector4f Translation;
}
namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct hkSimdFloat32
{
	public fixed float f32[4];
}
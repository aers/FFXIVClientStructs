namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit)]
public struct hkMatrix3f
{
	[FieldOffset(0x00)] public float M00;
	[FieldOffset(0x04)] public float M10;
	[FieldOffset(0x08)] public float M20;
	[FieldOffset(0x0C)] public float pad;
	[FieldOffset(0x10)] public float M01;
	[FieldOffset(0x14)] public float M11;
	[FieldOffset(0x18)] public float M21;
	[FieldOffset(0x1C)] public float pad2;
	[FieldOffset(0x20)] public float M02;
	[FieldOffset(0x24)] public float M12;
	[FieldOffset(0x28)] public float M22;
	[FieldOffset(0x2C)] public float pad3;
	
	[FieldOffset(0x00)] public hkVector4f Column0;
	[FieldOffset(0x10)] public hkVector4f Column1;
	[FieldOffset(0x20)] public hkVector4f Column2;
}
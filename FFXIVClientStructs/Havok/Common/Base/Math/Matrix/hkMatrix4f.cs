namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Explicit)]
public struct hkMatrix4f
{
	[FieldOffset(0x00)] public float M00;
	[FieldOffset(0x04)] public float M10;
	[FieldOffset(0x08)] public float M20;
	[FieldOffset(0x0C)] public float M30;
	[FieldOffset(0x10)] public float M01;
	[FieldOffset(0x14)] public float M11;
	[FieldOffset(0x18)] public float M21;
	[FieldOffset(0x1C)] public float M31;
	[FieldOffset(0x20)] public float M02;
	[FieldOffset(0x24)] public float M12;
	[FieldOffset(0x28)] public float M22;
	[FieldOffset(0x2C)] public float M32;
	[FieldOffset(0x30)] public float M03;
	[FieldOffset(0x34)] public float M13;
	[FieldOffset(0x38)] public float M23;
	[FieldOffset(0x3C)] public float M33;
	
	[FieldOffset(0x00)] public hkVector4f Column0;
	[FieldOffset(0x10)] public hkVector4f Column1;
	[FieldOffset(0x20)] public hkVector4f Column2;
	[FieldOffset(0x30)] public hkVector4f Column3;
}
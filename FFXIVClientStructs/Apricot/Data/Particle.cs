namespace FFXIVClientStructs.Apricot.Data;

[StructLayout(LayoutKind.Explicit, Size = 0x238)]
public struct Particle {
	[FieldOffset(0x70)] public unsafe RgbFunctionCurve* Rgb;
}

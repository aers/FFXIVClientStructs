namespace FFXIVClientStructs.Apricot.Data;

[StructLayout(LayoutKind.Explicit)]
public struct Document {
	[FieldOffset(0x40)] public unsafe Particle* Particles;

	[FieldOffset(0xE6)] public byte ParticleCount;
}

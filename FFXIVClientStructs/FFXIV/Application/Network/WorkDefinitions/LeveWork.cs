namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct LeveWork {
	[FieldOffset(0x08)] public ushort LeveId;
	[FieldOffset(0x09)] public byte Sequence;
	[FieldOffset(0x0C)] public ushort Flags;
	[FieldOffset(0x0E)] public ushort LeveSeed;
	[FieldOffset(0x10)] public byte ClearClass;

	public bool IsHidden => (Flags & 0x4000) != 0;
	public bool IsPriority => (Flags & 0x8000) != 0;
}

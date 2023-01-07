namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct QuestWork {
	[FieldOffset(0x08)] public ushort QuestId;
	[FieldOffset(0x0A)] public byte Sequence;
	[FieldOffset(0x0B)] public byte Flags;
	[FieldOffset(0x0C)] public fixed byte Variables[6];
	[FieldOffset(0x12)] public byte AcceptClassJob;

	public int RewardItemArrayIndex => Flags >> 1 & 3;
	public bool IsHidden => (Flags & 8) != 0;
	public bool IsPriority => (Flags & 1) != 0;
}

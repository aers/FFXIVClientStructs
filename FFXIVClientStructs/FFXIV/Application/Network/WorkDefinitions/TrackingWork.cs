namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct TrackingWork {
	[FieldOffset(0x08)] public byte QuestType;
	[FieldOffset(0x09)] public byte Index;
}

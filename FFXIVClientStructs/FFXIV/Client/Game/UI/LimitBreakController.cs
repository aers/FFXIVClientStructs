namespace FFXIVClientStructs.FFXIV.Client.Game.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct LimitBreakController {
	[FieldOffset(0x08)] public byte BarCount;
	[FieldOffset(0x0A)] public ushort CurrentValue;
	[FieldOffset(0x0C)] public uint BarValue;
}

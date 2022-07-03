namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent; 

[StructLayout(LayoutKind.Explicit, Size = 0x1790)]
public unsafe struct InstanceContentDirector
{
	[FieldOffset(0x00)] public ContentDirector ContentDirector;
	//[FieldOffset(0x730)] public fixed byte InstanceContentExcelRow[0xA8];
}
namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent; 

[StructLayout(LayoutKind.Explicit, Size = 0x1CA0)]
public unsafe struct InstanceContentDirector
{
	[FieldOffset(0x00)] public ContentDirector ContentDirector;
	//[FieldOffset(0x730)] public fixed byte InstanceContentExcelRow[0xA8];
	// 2=dungeon, 9=deepdungeon, 4=trial, 1=raid, 8=beginnertraining, 6=frontlines
	[FieldOffset(0xCD4)] public byte InstanceContentType;
}
﻿namespace FFXIVClientStructs.FFXIV.Client.Game; 

[StructLayout(LayoutKind.Explicit, Size = 0x58D0)]
public unsafe partial struct GameMain {
	[FieldOffset(0x0)]
	public fixed uint ActiveFestivals[4];

	[FieldOffset(0x40)]
	public fixed uint QueuedFestivals[4];

	[StaticAddress("48 8D 0D ?? ?? ?? ?? 38 05", 3)]
	public static partial GameMain* Instance();

	[MemberFunction("E8 ?? ?? ?? ?? 44 8B B3 ?? ?? ?? ?? 33 FF")]
	public partial bool IsInInstanceArea();

	[MemberFunction("E8 ?? ?? ?? ?? 3C ?? BB")]
	public static partial bool IsInPvPArea();

	[MemberFunction("40 53 48 83 EC ?? 48 8B 1D ?? ?? ?? ?? 48 85 DB 75 ?? 32 C0 48 83 C4 ?? 5B C3 48 8D 0D")]
	public static partial bool IsInPvPInstance();

	[MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 21 48 8B 4F 10")]
	public static partial bool IsInSanctuary();

	[MemberFunction("E8 ?? ?? ?? ?? E9 08 29 00 00")]
	public partial void QueueActiveFestivals(uint festival1, uint festival2, uint festival3, uint festival4); // Applies once the current "event" is done (GPose, Cutscene etc)

	[MemberFunction("E8 ?? ?? ?? ?? 80 63 50 FE")]
	public partial void SetActiveFestivals(uint festival1, uint festival2, uint festival3, uint festival4); // Applies immediately regardless of client state
}
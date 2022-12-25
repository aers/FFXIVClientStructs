namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent; 

[StructLayout(LayoutKind.Explicit, Size = 0xBB8)]
public struct PublicContentDirector {
	[FieldOffset(0x00)] public ContentDirector ContentDirector;
}

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent; 

[StructLayout(LayoutKind.Explicit, Size = 0x1080)]
public struct PublicContentDirector {
	[FieldOffset(0x00)] public ContentDirector ContentDirector;
}

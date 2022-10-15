using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

[StructLayout(LayoutKind.Explicit, Size = 0x770)]
public struct ContentDirector
{
	[FieldOffset(0x00)] public Director Director;

	[FieldOffset(0x740)] public float ContentTimeLeft;
}
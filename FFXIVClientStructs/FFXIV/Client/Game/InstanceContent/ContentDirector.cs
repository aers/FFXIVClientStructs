using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

[StructLayout(LayoutKind.Explicit, Size = 0xC38)]
public struct ContentDirector
{
	[FieldOffset(0x00)] public Director Director;

	[FieldOffset(0xC08)] public float ContentTimeLeft;
}
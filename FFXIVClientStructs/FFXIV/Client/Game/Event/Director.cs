using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x4B8)]
public unsafe struct Director
{
	[FieldOffset(0x00)] public LuaEventHandler LuaEventHandler;
	[FieldOffset(0x330)] public EventHandlerInfo* EventHandlerInfo;
	[FieldOffset(0x338)] public uint ContentId;
	[FieldOffset(0x33C)] public byte ContentFlags; // 1 = Tourism (Explorer Mode)
	[FieldOffset(0x340)] public byte Sequence;
	[FieldOffset(0x342)] public fixed byte UnionData[10]; // I8A-I8J, UI8A-UI8J, Branch etc.
	[FieldOffset(0x350)] public Utf8String String0;
	[FieldOffset(0x3B8)] public Utf8String String1;
	[FieldOffset(0x420)] public Utf8String String2;
}

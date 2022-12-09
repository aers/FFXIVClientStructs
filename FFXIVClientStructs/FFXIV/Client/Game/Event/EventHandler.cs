namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe struct EventHandler
{
	[FieldOffset(0x18)] public EventSceneModuleUsualImpl* EventSceneModule;
	[FieldOffset(0x20)] public EventHandlerInfo Info;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public struct EventHandlerInfo {
	[FieldOffset(0x00)] public ushort ContentId;
	[FieldOffset(0x02)] public ushort EventHandlerType;
	[FieldOffset(0x04)] public bool IsActive;
}

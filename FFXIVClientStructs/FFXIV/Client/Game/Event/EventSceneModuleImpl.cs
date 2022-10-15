namespace FFXIVClientStructs.FFXIV.Client.Game.Event; 

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct EventSceneModuleUsualImpl {
	[FieldOffset(0x00)] public EventSceneModuleImplBase ImplBase;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct EventSceneModuleImplBase {
	[FieldOffset(0x08)] public EventSceneModule* EventSceneModule;
}
namespace FFXIVClientStructs.FFXIV.Client.Game.Event; 

[StructLayout(LayoutKind.Explicit, Size = 0x31A0)]
public unsafe struct EventSceneModule {
	[FieldOffset(0x00)] public EventSceneModuleUsualImpl EventSceneModuleUsualImpl;
	[FieldOffset(0x10)] public EventSceneModuleImplBase EventSceneModuleImplBase;
	[FieldOffset(0x20)] public EventSceneModuleImplBase* EventSceneModuleImpl;
}
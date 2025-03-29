namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventSceneModule
[StructLayout(LayoutKind.Explicit, Size = 0x31C0)]
public unsafe struct EventSceneModule {
    [FieldOffset(0x18)] public EventSceneModuleUsualImpl EventSceneModuleUsualImpl;
    [FieldOffset(0x28)] public EventSceneModuleImplBase EventSceneModuleImplBase;
    [FieldOffset(0x38)] public EventSceneModuleImplBase* EventSceneModuleImpl;
    [FieldOffset(0x98)] public EventSceneModuleTaskManager TaskManager;
    [FieldOffset(0x200)] public EventGPoseController EventGPoseController;
}

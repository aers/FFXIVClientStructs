namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventSceneModule
// ctor "E8 ?? ?? ?? ?? 33 F6 49 8D 8D ?? ?? ?? ?? 41 89 B5"
[StructLayout(LayoutKind.Explicit, Size = 0x31C0)]
public unsafe struct EventSceneModule {
    [FieldOffset(0x18)] public EventSceneModuleUsualImpl EventSceneModuleUsualImpl;
    [FieldOffset(0x28)] public EventSceneModuleImplBase EventSceneModuleImplBase;
    [FieldOffset(0x38)] public EventSceneModuleImplBase* EventSceneModuleImpl;
    [FieldOffset(0x1F0)] public EventGPoseController EventGPoseController;
}
